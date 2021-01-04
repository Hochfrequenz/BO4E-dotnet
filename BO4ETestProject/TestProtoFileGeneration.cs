
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using BO4E.BO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProtoBuf;

namespace TestBO4E
{
    [TestClass]
    public class TestProtoFileGeneration
    {
        static readonly HashSet<Type> PROTO_SERIALIZABLE_TYPES = new HashSet<Type>()
        {
            typeof(Angebot),
            typeof(Ansprechpartner),
            typeof(Benachrichtigung),
            typeof(Energiemenge),
            typeof(Geschaeftspartner),
            typeof(Kosten),
            typeof(Marktlokation),
            //typeof(Marktteilnehmer),
            typeof(Messlokation),
            typeof(Preisblatt),
            typeof(Rechnung),
            typeof(Region),
            typeof(Vertrag),
            typeof(Zaehler)
        };

        [TestMethod]
        public void TestProtoGenerationBo() 
        {
            foreach (var type in PROTO_SERIALIZABLE_TYPES)
            {
                var method = typeof(Serializer).GetMethod(nameof(Serializer.GetProto), new Type[] { typeof(ProtoBuf.Meta.ProtoSyntax)});
                method = method.MakeGenericMethod(type);
                Assert.IsNotNull(method);
                var protoString = (string)method.Invoke(null, new object[] { ProtoBuf.Meta.ProtoSyntax.Proto3 });
                Assert.IsFalse(string.IsNullOrWhiteSpace(protoString));
                var path = $"../../../../BO4E-dotnet/protobuf-files/{type}.proto"; // not elegant but ok ;)
                if (!File.Exists(path))
                {
                    var stream = File.Create(path);
                    stream.Close();
                }
                File.WriteAllText(path, protoString, Encoding.UTF8);
                
            }
        }
    }
}
