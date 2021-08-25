﻿using System.IO;
using System.Text.Json;
using BO4E.BO;
using BO4E.meta.LenientConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E
{
    [TestClass]
    public class TestAbstractDeserialization
    {
        /// <summary>
        ///     Tests Abstract Deserialization using Newtonsoft.Json
        /// </summary>
        /// <seealso cref="TestAbstractDeserializationSystemText" />
        [TestMethod]
        public void TestMaLoDeserializationNewtonsoft()
        {
            JObject json;
            using (var r = new StreamReader("BoMapperTests/marktlokation_simple.json"))
            {
                var jsonString = r.ReadToEnd();
                json = JObject.Parse(jsonString);
            }

            var maloString = json["input"].ToString();
            var malo = JsonConvert.DeserializeObject<Marktlokation>(maloString);
            Assert.IsNotNull(malo);
            var bo = JsonConvert.DeserializeObject<BusinessObject>(maloString);
            Assert.IsNotNull(bo);
            Assert.IsInstanceOfType(bo, typeof(Marktlokation));
        }

        /// <summary>
        ///     Tests Abstract Deserialization using System.Text
        /// </summary>
        /// <seealso cref="TestMaLoDeserializationNewtonsoft" />
        [TestMethod]
        public void TestMaLoDeserializationSystemText()
        {
            JsonDocument json;
            using (var r = new StreamReader("BoMapperTests/marktlokation_simple.json"))
            {
                var jsonString = r.ReadToEnd();
                json = JsonDocument.Parse(jsonString);
            }

            var options = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();

            var maloString = json.RootElement.GetProperty("input").GetRawText();
            Assert.IsNotNull(maloString);
            var malo = JsonSerializer.Deserialize<Marktlokation>(maloString, options);
            Assert.IsNotNull(malo);
            var bo = JsonSerializer.Deserialize<BusinessObject>(maloString, options);
            Assert.IsNotNull(bo);
            Assert.IsInstanceOfType(bo, typeof(Marktlokation));
        }

        [TestMethod]
        public void TestMaLoTypeNameHandlingDeserializationNewtonsoft()
        {
            JObject json;
            using (var r = new StreamReader("BoMapperTests/marktlokation_with_typenamehandling.json"))
            {
                var jsonString = r.ReadToEnd();
                json = JObject.Parse(jsonString);
            }

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            var maloString = json["input"].ToString();
            var malo = JsonConvert.DeserializeObject<Marktlokation>(maloString, settings);
            Assert.IsNotNull(malo);
            var bo = JsonConvert.DeserializeObject<BusinessObject>(maloString, settings);
            Assert.IsNotNull(bo);
            Assert.IsInstanceOfType(bo, typeof(Marktlokation));
        }

        /// <summary>
        ///     similar to <see cref="TestMaLoDeserializationNewtonsoft" /> but with .NET5
        /// </summary>
        [TestMethod]
        public void TestMaLoDeserializationNet5()
        {
            JsonDocument json;
            using (var r = new StreamReader("BoMapperTests/marktlokation_simple.json"))
            {
                var jsonString = r.ReadToEnd();
                json = JsonDocument.Parse(jsonString);
            }

            var options = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
            var maloString = json.RootElement.GetProperty("input").GetRawText();
            var malo = JsonSerializer.Deserialize<Marktlokation>(maloString, options);
            Assert.IsNotNull(malo);
            var bo = JsonSerializer.Deserialize<BusinessObject>(maloString, options);
            Assert.IsNotNull(bo);
            Assert.IsInstanceOfType(bo, typeof(Marktlokation));
        }

        // no typename handling test in .NET as this is a JsonConvert feature 
    }
}