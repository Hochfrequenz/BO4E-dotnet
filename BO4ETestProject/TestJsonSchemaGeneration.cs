using System;
using System.IO;
using System.Linq;
using System.Text;
using BO4E.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Schema;

namespace TestBO4E
{
    [TestClass]
    public class TestJsonSchemaGeneration
    {
        [TestMethod]
        public void BasicTest()
        {
            var melo = new Messlokation();
            var result = melo.GetJsonScheme().ToString();

            var em = new Energiemenge();
            result = em.GetJsonScheme().ToString();

            var result2 = BusinessObject.GetJsonSchema(typeof(Energiemenge)).ToString();
            Assert.AreEqual(result, result2);
        }

        [TestMethod]
        public void NegativeTest()
        {
            Assert.ThrowsException<ArgumentException>(() => BusinessObject.GetJsonSchema(typeof(string)),
                "Illegal types must result in a ArgumentException.");
        }



        [TestMethod]
        [DataRow(0)]
        [DataRow(10)]
        [DataRow(20)]
        [DataRow(30)]
        [DataRow(40)]

        public void TestJSchemaFileGenerationBo(int offset)
        {
            try
            {
                foreach (var type in typeof(BusinessObject).Assembly.GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(BusinessObject))).Skip(offset))
                {
                    var schema = BusinessObject.GetJsonSchema(type);
                    Assert.IsNotNull(schema);
                    var path = $"../../../../json-schema-files/{type}.json"; // not elegant but ok ;)
                    if (!File.Exists(path))
                    {
                        var stream = File.Create(path);
                        stream.Close();
                    }
                    var utf8WithoutByteOrderMark = new UTF8Encoding(false);
                    File.WriteAllText(path, schema.ToString(SchemaVersion.Draft7), utf8WithoutByteOrderMark);
                }
            }
            catch (JSchemaException jse)
            {
                Console.Out.WriteLine(jse.Message);
                // thats life. pay for it if you'd like to :P
            }
        }
    }
}
