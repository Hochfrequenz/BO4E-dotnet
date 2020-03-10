
using System;
using System.Linq;
using System.Reflection;
using BO4E.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtoBuf;

namespace TestBO4E
{
    [TestClass]
    public class TestProtobufAttributes
    {
        [TestMethod]
        public void TestUniqueProtobufMemberId()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t => typeof(BusinessObject).IsAssignableFrom(t)))
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
            }
        }
    }
}
