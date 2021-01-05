
using BO4E.BO;
using BO4E.COM;
using BO4E.meta;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

using ProtoBuf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestBO4E
{
    [TestClass]
    public class TestProtobufAttributes
    {
        [TestMethod]
        public void TestProtobufDateTimeWorkaroundCOM() => TestProtobufDateTimeWorkaround(typeof(COM));
        [TestMethod]
        public void TestUniqueProtobufMemberIdCOM() => TestUniqueProtobufMemberIdAbstract(typeof(COM));
        [TestMethod]
        public void TestUniqueProtoIncludeTagsCOM() => TestUniqueProtoIncludeTagAbstract(typeof(COM));

        [TestMethod]
        public void TestProtobufDateTimeWorkaroundBO() => TestProtobufDateTimeWorkaround(typeof(BusinessObject));
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
            IEnumerable<FieldInfo> fieldsWithProtoMemberAttribute;
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

            var nonOfficialFieldsWithProtoMember = allFields.Where(field => field.GetCustomAttributes(typeof(NonOfficialAttribute)).Any()) // those fields having an [NonOfficial(...)] attribute
                .Where(field => ((NonOfficialAttribute)field.GetCustomAttributes(typeof(NonOfficialAttribute)).First()).HasCategory(NonOfficialCategory.CUSTOMER_REQUIREMENTS)) // and the customer_requirements category
                .Intersect(fieldsWithProtoMemberAttribute); // and a [ProtoMember(<id>)] attribute

            var wrongTagsNonOfficial = nonOfficialFieldsWithProtoMember.Where(f => ((ProtoMemberAttribute)f.GetCustomAttributes(typeof(ProtoMemberAttribute)).First()).Tag < 1000);
            Assert.AreEqual(0, wrongTagsNonOfficial.Count(), $"Fields in {type} are non official and do not have proto tags >= 1000: {string.Join(", ", wrongTagsNonOfficial.Select(f => f.Name))}");
            var wrongTagsOfficial = fieldsWithProtoMemberAttribute.Except(nonOfficialFieldsWithProtoMember).Where(f => ((ProtoMemberAttribute)f.GetCustomAttributes(typeof(ProtoMemberAttribute)).First()).Tag > 1000);
            Assert.AreEqual(0, wrongTagsOfficial.Count(), $"Fields in {type} are official but have proto tags >= 1000: {string.Join(", ", wrongTagsOfficial.Select(f => f.Name))}");

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
                throw;
            }

            if (isDirectBase) // because protobuf-net doesn't support multiple levels of inheritance
            {
                var duplicateTags = fieldsWithProtoMemberAttribute
                    .Select(f => f.GetCustomAttributes(typeof(ProtoMemberAttribute), true).First())
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

        protected void TestProtobufDateTimeWorkaround(Type abstractBaseType)
        {
            if (!abstractBaseType.IsAbstract)
            {
                throw new ArgumentException($"The type {abstractBaseType} is not abstract", nameof(abstractBaseType));
            }
            var relevantTypes = typeof(BusinessObject).Assembly.GetTypes()
                                    .Where(t => abstractBaseType.IsAssignableFrom(t));
            foreach (var relevantType in relevantTypes)
            {
                var dtProperties = relevantType.GetProperties().Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTimeOffset));
                foreach (var dtProperty in dtProperties)
                {
                    // there must be an attribute like described in https://github.com/protobuf-net/protobuf-net.Grpc/issues/56#issuecomment-580509687
                    var pma = dtProperty.GetCustomAttributes<ProtoMemberAttribute>().FirstOrDefault();
                    Assert.IsNotNull(pma, $"The property {dtProperty.Name} of type {relevantType.Name} is missing the ProtoMemberAttribute.");
                    Assert.AreEqual(DataFormat.WellKnown, pma.DataFormat, $"The property {dtProperty.Name} of type {relevantType.Name} has the wrong dataformat in the protomember attribute");
                }
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
        public void TestProtoEnumConsistency()//https://github.com/protobuf-net/protobuf-net/issues/60
        {
            var enumTypes = typeof(BO4E.ENUM.AbgabeArt).Assembly.GetTypes()
                .Where(t => t.IsEnum && t.Namespace.StartsWith("BO4E.ENUM") && !t.Namespace.StartsWith("BO4E.ENUM.EDI"));
            var allValues = new List<Tuple<Type, string>>();
            foreach (var enumType in enumTypes)
            {
                var naturalEnumValues = enumType.GetFields().Where(f => !f.GetCustomAttributes<ProtoEnumAttribute>().Any()).Select(f => new Tuple<Type, string>(enumType, f.Name));
                allValues.AddRange(naturalEnumValues);
                //var protoEnumValues = enumType.GetFields().SelectMany(f => f.GetCustomAttributes<ProtoEnumAttribute>()).Select(pea => new Tuple<Type, string>(enumType, pea.Name));
                //allValues.AddRange(protoEnumValues);
                foreach (var field in enumType.GetFields().Where(f => f.GetCustomAttributes<ProtoEnumAttribute>().Any()))
                {
                    var pea = field.GetCustomAttributes<ProtoEnumAttribute>().First();
                    Assert.AreEqual(enumType.Name + "_" + field.Name, pea.Name);
                    allValues.Add(new Tuple<Type, string>(enumType, pea.Name));
                }
                Assert.IsTrue(Enum.IsDefined(enumType, (int)0), $"Any enum must define a ZERO like value for Protobuf3 but {enumType} doesn't.");
            }
            var nonDistinctValues = allValues
                .GroupBy(tuple => tuple.Item2) // group by field/protoenum name
                .Where(g => g.Count() > 1 && g.Key != "value__")
                .ToDictionary(x => x.Key, y => y.Select(t => t.Item1.Name));
            Assert.IsFalse(nonDistinctValues.Any(), $"There are non-distinct Enum values. Add a matching [ProtoEnum] attribute to: {JsonConvert.SerializeObject(nonDistinctValues)}");
        }
        [TestMethod]
        public void TestExplicitProtobufInheritance()
        {
            var businessObjectTypes = typeof(BusinessObject).Assembly.GetTypes().Where(t => typeof(BusinessObject).IsAssignableFrom(t));
            var boTypesCrossProduct =
                from baseType in businessObjectTypes
                from inheritingType in businessObjectTypes
                where baseType.IsAssignableFrom(inheritingType) && baseType != inheritingType
                select new { baseType, inheritingType };
            // Background: https://github.com/protobuf-net/protobuf-net#inheritance
            // The base type must have an attribute that refers to the inherited type.
            // Both types need to carry the ProtoContract attribute.
            foreach (var typePair in boTypesCrossProduct.Distinct())
            {
                // Assert.IsTrue(typePair.baseType.GetCustomAttributes(typeof(ProtoContractAttribute), false).Any(), $"The (base) type {typePair.baseType} has not [ProtoContract] attribute."); // ToDo: re-add this line because fields on BO / COM level are not properly proto-serialized as of now!
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
