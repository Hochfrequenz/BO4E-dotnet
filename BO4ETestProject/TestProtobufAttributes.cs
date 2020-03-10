
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
        public void TestUniqueProtobufMemberIdBO() => TestUniqueProtobufMemberIdAbstract(typeof(BusinessObject));

        protected void TestUniqueProtobufMemberIdAbstract(Type abstractType)
        {
            if (!abstractType.IsAbstract)
            {
                throw new ArgumentException($"The type {abstractType} is not abstract", nameof(abstractType));
            }
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t => abstractType.IsAssignableFrom(t)))
            {
                TestProtobufType(type);
            }
        }

        protected void TestProtobufType(Type type)
        {
            var allFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            var fieldsWithProtoMemberAttribute = type.GetFields(BindingFlags.Public | BindingFlags.Instance).Where(f => f.GetCustomAttributes(typeof(ProtoMemberAttribute), inherit: true).Any());
            try
            {
                Assert.AreEqual(allFields.Count(), fieldsWithProtoMemberAttribute.Count(), $"Missing protobuf attributes for {type} for: " + string.Join(", ", allFields.Except(fieldsWithProtoMemberAttribute)));
            }
            catch (ArgumentOutOfRangeException aoore) when (aoore.ParamName == "tag")
            {
                Assert.IsTrue(false, $"Do you have any ProtoMember attributes with an id<=0 in {type}?");
                throw aoore;
            }
            var duplicateTags = fieldsWithProtoMemberAttribute
                .Select(f => f.GetCustomAttributes(typeof(ProtoMemberAttribute), inherit: true).First())
                .Cast<ProtoMemberAttribute>()
                .GroupBy(pma => pma.Tag)
                .Where(g => g.Count() > 1)
                .ToDictionary(pma => pma.Key, y => y.Count());
            Assert.AreEqual(0, duplicateTags.Count, $"The folllowing [(ProtoMember(<tag>)] tags in {type} are not unique: {string.Join(", ", duplicateTags.Keys)}");
        }

        [TestMethod]
        public void TestExplicitProtobufInheritance()
        {
            var businessObjectTypes = typeof(BusinessObject).Assembly.GetTypes().Where(t => typeof(BusinessObject).IsAssignableFrom(t));
            var boTypesCrossProduct = 
                from baseType in businessObjectTypes
                from inheritingType in businessObjectTypes
                where (baseType.IsAssignableFrom(inheritingType) && baseType!=inheritingType)
                select new { baseType, inheritingType };
            // Background: https://github.com/protobuf-net/protobuf-net#inheritance
            // The base type must have an attribute that refers to the inherited type.
            // Both types need to carry the ProtoContract attribute.
            foreach (var typePair in boTypesCrossProduct.Distinct())
            {
                Assert.IsTrue(typePair.baseType.GetCustomAttributes(typeof(ProtoContractAttribute), false).Any(), $"The (base) type {typePair.baseType} has not [ProtoContract] attribute.");
                Assert.IsTrue(typePair.inheritingType.GetCustomAttributes(typeof(ProtoContractAttribute), false).Any(), $"The (inheriting) type {typePair.inheritingType} has not [ProtoContract] attribute.");
                Assert.IsTrue(typePair.baseType.GetCustomAttributes(typeof(ProtoIncludeAttribute), false).Any(), $"The base type {typePair.baseType} must refer to the inheriting type {typePair.inheritingType} using a [ProtoInclude] attribute.");
                //Assert.IsTrue(typePair.baseType.GetCustomAttributes(typeof(ProtoIncludeAttribute), false).Cast<ProtoIncludeAttribute>().Where(pia=>pia..Any(), $"The base type {typePair.baseType} must refer to the inheriting type {typePair.inheritingType} using a [ProtoInclude] attribute.");
            }
        }
    }
}
