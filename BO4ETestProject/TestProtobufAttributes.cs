
using System;
using System.Linq;
using System.Reflection;
using BO4E.BO;
using BO4E.COM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtoBuf;

namespace TestBO4E
{
    [TestClass]
    public class TestProtobufAttributes
    {
        [TestMethod]
        public void TestUniqueProtobufMemberIdCOM() => TestUniqueProtobufMemberIdAbstract(typeof(COM));
        [TestMethod]
        public void TestUniqueProtoIncludeTagsCOM() => TestUniqueProtoIncludeTagAbstract(typeof(COM));

        [TestMethod]
        public void TestUniqueProtobufMemberIdBO() => TestUniqueProtobufMemberIdAbstract(typeof(BusinessObject));
        [TestMethod]
        public void TestUniqueProtoIncludeTagsBO() => TestUniqueProtoIncludeTagAbstract(typeof(BusinessObject));

        protected void TestUniqueProtobufMemberIdAbstract(Type abstractType)
        {
            if (!abstractType.IsAbstract)
            {
                throw new ArgumentException($"The type {abstractType} is not abstract", nameof(abstractType));
            }
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t => abstractType.IsAssignableFrom(t)))
            {
                TestProtobufType(type, type.BaseType == abstractType || type == abstractType);
            }
        }

        protected void TestProtobufType(Type type, bool isDirectBase)
        {
            FieldInfo[] allFields;
            System.Collections.Generic.IEnumerable<FieldInfo> fieldsWithProtoMemberAttribute;
            if (isDirectBase)
            {
                allFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                fieldsWithProtoMemberAttribute = type.GetFields(BindingFlags.Public | BindingFlags.Instance).Where(f => f.GetCustomAttributes(typeof(ProtoMemberAttribute), true).Any());
            }
            else
            {
                allFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                fieldsWithProtoMemberAttribute = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(f => f.GetCustomAttributes(typeof(ProtoMemberAttribute), false).Any());
            }
            try
            {
                if (isDirectBase)
                {
                    Assert.AreEqual(allFields.Count(), fieldsWithProtoMemberAttribute.Count(), $"Missing protobuf attributes for {type} for: " + string.Join(", ", allFields.Except(fieldsWithProtoMemberAttribute)));
                }
            }
            catch (ArgumentOutOfRangeException aoore) when (aoore.ParamName == "tag")
            {
                Assert.IsTrue(false, $"Do you have any ProtoMember attributes with an id<=0 in {type}?");
                throw aoore;
            }

            if (isDirectBase) // because protobuf-net doesn't support multiple levels of inheritance
            {
                var duplicateTags = fieldsWithProtoMemberAttribute
                    .Select(f => f.GetCustomAttributes(typeof(ProtoMemberAttribute), inherit: true).First())
                    .Cast<ProtoMemberAttribute>()
                    .GroupBy(pma => pma.Tag)
                    .Where(g => g.Count() > 1)
                    .ToDictionary(pma => pma.Key, y => y.Count());
                Assert.AreEqual(0, duplicateTags.Count, $"The following [(ProtoMember(<tag>)] tags in {type} are not unique: {string.Join(", ", duplicateTags.Keys)}");
            }
            else
            {
                Assert.AreEqual(0, fieldsWithProtoMemberAttribute.Count(), $"Classes like {type} not directly inheriting from BusinessObject or COM must not have Protobuf Attributes (due to protobuf-net bugs)");
            }
        }

        protected void TestUniqueProtoIncludeTagAbstract(Type abstractBaseType) // ToDo: test this with preisblatt
        {
            if (!abstractBaseType.IsAbstract)
            {
                throw new ArgumentException($"The type {abstractBaseType} is not abstract", nameof(abstractBaseType));
            }
            var duplicateIncludeTags = typeof(BusinessObject).Assembly.GetTypes()
                .Where(t => abstractBaseType.IsAssignableFrom(t))
                .SelectMany(t => t.GetCustomAttributes(typeof(ProtoIncludeAttribute), false))
                .Cast<ProtoIncludeAttribute>()
                .GroupBy(pia => pia.Tag)
                .Where(g => g.Count() > 1)
                .ToDictionary(pia => pia.Key, tag => tag.Count());
            Assert.AreEqual(0, duplicateIncludeTags.Count, $"The following [(ProtoInclude(<tag>, ...)] attributes are not unique: {string.Join(", ", duplicateIncludeTags.Keys)}");
        }

        [TestMethod]
        public void TestExplicitProtobufInheritance()
        {
            var businessObjectTypes = typeof(BusinessObject).Assembly.GetTypes().Where(t => typeof(BusinessObject).IsAssignableFrom(t));
            var boTypesCrossProduct =
                from baseType in businessObjectTypes
                from inheritingType in businessObjectTypes
                where (baseType.IsAssignableFrom(inheritingType) && baseType != inheritingType)
                select new { baseType, inheritingType };
            // Background: https://github.com/protobuf-net/protobuf-net#inheritance
            // The base type must have an attribute that refers to the inherited type.
            // Both types need to carry the ProtoContract attribute.
            foreach (var typePair in boTypesCrossProduct.Distinct())
            {
                Assert.IsTrue(typePair.baseType.GetCustomAttributes(typeof(ProtoContractAttribute), false).Any(), $"The (base) type {typePair.baseType} has not [ProtoContract] attribute.");
                if (typePair.inheritingType.BaseType == typeof(BusinessObject))//because protobuf-net doesn't support mutliple levels of inheritance
                {
                    Assert.IsTrue(typePair.inheritingType.GetCustomAttributes(typeof(ProtoContractAttribute), false).Any(), $"The (inheriting) type {typePair.inheritingType} has not [ProtoContract] attribute.");
                }
                else
                {
                    Assert.IsFalse(typePair.inheritingType.GetCustomAttributes(typeof(ProtoContractAttribute), false).Any(), $"The (INDIRECTLY inheriting) type {typePair.inheritingType} has the [ProtoContract] attribute."); // bug in protobuf-net
                }
                if (typePair.inheritingType.BaseType == typePair.baseType && typePair.baseType != typeof(BusinessObject))
                {
                    // remove the if-block around this statement as soon as protobuf-net supports multiple levels of inheritance
                    // Symptomes: 
                    // 1: ProtoBuf.ProtoException: Type 'BO4E.COM.Preisgarantie' can only participate in one inheritance hierarchy (BO4E.COM.Verbrauch) ---> System.InvalidOperationException: Type 'BO4E.COM.Preisgarantie' can only participate in one inheritance hierarchy
                    // 2: System.InvalidOperationException: Duplicate field-number detected; 
                    var typesReferencedByBase = typePair.baseType.GetCustomAttributes(typeof(ProtoIncludeAttribute), false).Cast<ProtoIncludeAttribute>().Select(pia => pia.KnownType);
                    Assert.IsFalse(typesReferencedByBase.Contains(typePair.inheritingType), $"The base type {typePair.baseType} does not reference the inheriting type {typePair.inheritingType} in a [ProtoInclude(<tag>, {typePair.inheritingType})] attribute.");

                    continue;
                }
                Assert.IsTrue(typePair.baseType.GetCustomAttributes(typeof(ProtoIncludeAttribute), false).Any(), $"The base type {typePair.baseType} must refer to the inheriting type {typePair.inheritingType} using a [ProtoInclude] attribute.");
                if (typePair.inheritingType.BaseType == typePair.baseType)
                {
                    var typesReferencedByBase = typePair.baseType.GetCustomAttributes(typeof(ProtoIncludeAttribute), false).Cast<ProtoIncludeAttribute>().Select(pia => pia.KnownType);
                    Assert.IsTrue(typesReferencedByBase.Contains(typePair.inheritingType), $"The base type {typePair.baseType} does not reference the inheriting type {typePair.inheritingType} in a [ProtoInclude(<tag>, {typePair.inheritingType})] attribute.");
                }
            }
        }
    }
}
