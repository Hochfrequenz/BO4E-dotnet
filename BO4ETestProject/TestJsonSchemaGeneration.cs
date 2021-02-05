using BO4E.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Schema;
using System;
using System.IO;
using System.Linq;
using System.Text;

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
        public void TestJSchemaFileGenerationBo()
        {
            try
            {
                foreach (var type in typeof(BusinessObject).Assembly.GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(BusinessObject))).Reverse())
                {
                    var schema = BusinessObject.GetJsonSchema(type);
                    Assert.IsNotNull(schema);
                    var path = $"../../../../json-schema-files/{type}.json"; // not elegant but ok ;)
                    if (!File.Exists(path))
                    {
                        var stream = File.Create(path);
                        stream.Close();
                    }

                    File.WriteAllText(path, schema.ToString(SchemaVersion.Draft7), Encoding.UTF8);
                }
            }
            catch (JSchemaException)
            {
                // thats life. pay for it if you'd like to :P
            }
        }
    }
}