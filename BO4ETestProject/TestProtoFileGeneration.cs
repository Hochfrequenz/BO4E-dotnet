
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;

//using BO4E.BO;

//using Microsoft.VisualStudio.TestTools.UnitTesting;

//using ProtoBuf;

//namespace TestBO4E
//{
//    [TestClass]
//    public class TestProtoFileGeneration
//    {
//        static readonly HashSet<Type> PROTO_SERIALIZABLE_TYPES = new HashSet<Type>
//        {
//            typeof(Angebot),
//            typeof(Ansprechpartner),
//            typeof(Benachrichtigung),
//            typeof(Energiemenge),
//            typeof(Geschaeftspartner),
//            typeof(Kosten),
//            typeof(Marktlokation),
//            //typeof(Marktteilnehmer),
//            typeof(Messlokation),
//            typeof(Preisblatt),
//            typeof(Rechnung),
//            typeof(Region),
//            typeof(Vertrag),
//            typeof(Zaehler)
//        };

//        [TestMethod]
//        public void TestProtoGenerationBo()
//        {
//            //foreach (var type in PROTO_SERIALIZABLE_TYPES)
//            {
//                var method = typeof(Serializer).GetMethod(nameof(Serializer.GetProto), new Type[] { typeof(ProtoBuf.Meta.SchemaGenerationOptions) });

//                Assert.IsNotNull(method);
//                var options = new ProtoBuf.Meta.SchemaGenerationOptions()
//                {
//                    Syntax = ProtoBuf.Meta.ProtoSyntax.Proto3,
//                    Flags = ProtoBuf.Meta.SchemaGenerationFlags.MultipleNamespaceSupport,
//                    Package = "bo4e",
//                };
//                options.Types.AddRange(PROTO_SERIALIZABLE_TYPES.ToList());
//                string protoString = (string)method.Invoke(null, new object[] { options });
//                Assert.IsFalse(string.IsNullOrWhiteSpace(protoString));
//                string path = $"../../../../BO4E-dotnet/protobuf-files/bo4e.proto";
//                if (!File.Exists(path))
//                {
//                    var stream = File.Create(path);
//                    stream.Close();
//                }
//                File.WriteAllText(path, protoString, Encoding.UTF8);

//            }
//        }
//    }
//}
