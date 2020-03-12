
using System;
using System.IO;
using System.Linq;
using BO4E.BO;
using BO4E.COM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtoBuf;

namespace TestBO4E
{
    [TestClass]
    public class TestProtFileGeneration
    {
        [TestMethod]
        public void TestProtoGenerationBo()  //=> TestProtoForAbstractType(typeof(BusinessObject));
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Angebot>()));
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Ansprechpartner>()));
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Benachrichtigung>()));
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Energiemenge>()));
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Geschaeftspartner>()));
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Kosten>()));
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Marktlokation>()));
            //Serializer.GetProto<Marktteilnehmer>(); // doenst work!
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Messlokation>()));
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Preisblatt>()));
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Rechnung>()));
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Rechnung>()));
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Region>()));
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Vertrag>()));
            Assert.IsFalse(string.IsNullOrWhiteSpace(Serializer.GetProto<Zaehler>()));
            var protoEm = Serializer.GetProto<Energiemenge>();
            
        }
        /*
         protected void TestProtoForAbstractType(Type abstractBaseType)
         {
             if (!abstractBaseType.IsAbstract)
             {
                 throw new ArgumentException($"The type {abstractBaseType} is not abstract", nameof(abstractBaseType));
             }
             foreach(var type in typeof(BusinessObject).Assembly.GetTypes()
                 .Where(t => abstractBaseType.IsAssignableFrom(t)
                     && t != abstractBaseType ) // because of bug in protobuf-net (or I don't get it ;))
                 )
             {
                 // var proto = Serializer.GetProto<type>()
             }
         }
         */
    }
}
