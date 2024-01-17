using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using BO4E.BO;
using BO4E.meta.LenientConverters;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E
{
    [TestClass]
    public class TestVerwendungszweckeDeserialization
    {
        private void _TestVerwendungszweckeDeserialization(Func<Marktlokation, string> serializer, Func<string, Marktlokation> deserializer)
        {
            var jsonString = File.ReadAllText("testjsons/marktlokation_with_verwendungszwecke.json");
            var malo = deserializer(jsonString);
            malo.Should().NotBeNull();
            malo.Zaehlwerke.Single().Verwendungszwecke.Should().NotBeEmpty();
        }

        [TestMethod]
        public void TestVerwendunszweckDeserializationNewtonsoft()
        {
            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new VerwendungszweckJsonNetConverter(), new StringEnumConverter() }
            };
            _TestVerwendungszweckeDeserialization(_malo => JsonConvert.SerializeObject(_malo, settings), str => JsonConvert.DeserializeObject<Marktlokation>(str, settings));
        }

        [TestMethod]
        public void TestVerwendunszweckDeserializationSystemText()
        {
            var jsonOptions = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter(), new VerwendungszweckJsonConverter() }
            };
            _TestVerwendungszweckeDeserialization(_malo => JsonSerializer.Serialize(_malo, jsonOptions), str => JsonSerializer.Deserialize<Marktlokation>(str, jsonOptions));
        }
    }
}
