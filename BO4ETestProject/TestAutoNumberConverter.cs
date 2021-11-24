using BO4E.BO;
using BO4E.ENUM;
using BO4E.meta.LenientConverters;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E
{
    [TestClass]
    public class TestAutoNumberConverter
    {

        [TestMethod]
        public void TestConverter()
        {
            string jsonString;
            using (var r = new StreamReader("testjsons/vertrag_numeric_versionstruktur.json"))
            {
                jsonString = r.ReadToEnd();

            }

            var options = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();


            var vertrag = JsonSerializer.Deserialize<Vertrag>(jsonString, options);
            Assert.IsNotNull(vertrag);
        }
    }
}