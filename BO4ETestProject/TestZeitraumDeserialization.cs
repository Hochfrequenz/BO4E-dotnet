using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestBO4E
{
    [TestClass]
    public class TestZeitraumDeserialization
    {
        private void _TestZeitraumDeserialization(Func<Zeitraum, string> serializer, Func<string, Zeitraum> deserializer)
        {
            var zeitraum = new Zeitraum
            {
                Startdatum = new DateTimeOffset(2022, 1, 1, 0, 0, 0, TimeSpan.Zero),
                Enddatum = new DateTimeOffset(2022, 1, 2, 0, 0, 0, TimeSpan.Zero),
                Dauer = 1,
                Einheit = Zeiteinheit.TAG,
            };
            var jsonString = serializer(zeitraum);
            var jsonDict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString); // we deserialize into an anonymous dict just to be decoupled from the json hacks, it is not important that we use system.text for that
            // excuse the .ToStrings() but i couldnt deserialize into Dict<string,string> because of the "Dauer" which is itself part of a not so glorious hack ;)
            jsonDict["startdatum"].ToString().Should().NotBeNull();
            jsonDict["enddatum"].ToString().Should().NotBeNull();
            jsonDict["startzeitpunkt"].ToString().Should().BeEquivalentTo(jsonDict["startdatum"].ToString());
            jsonDict["endzeitpunkt"].ToString().Should().BeEquivalentTo(jsonDict["endzeitpunkt"].ToString());

            // now we remove the datümer and deserialize again into a zeitraum
            jsonDict.Remove("startdatum");
            jsonDict.Remove("enddatum");

            jsonString = System.Text.Json.JsonSerializer.Serialize(jsonDict);
            var deserializedZeitraum = deserializer(jsonString);
            deserializedZeitraum.Should().BeEquivalentTo(zeitraum);
        }

        [TestMethod]
        public void TestZeitraumDeserializationNewtonsoft()
        {
            _TestZeitraumDeserialization(zr => JsonConvert.SerializeObject(zr, new StringEnumConverter()), str => JsonConvert.DeserializeObject<Zeitraum>(str));
        }

        [TestMethod]
        public void TestZeitraumDeserializationSystemText()
        {
            var jsonOptions = new JsonSerializerOptions()
            {
                Converters = { new JsonStringEnumConverter() }
            };
            _TestZeitraumDeserialization(zr => System.Text.Json.JsonSerializer.Serialize(zr, jsonOptions), str => System.Text.Json.JsonSerializer.Deserialize<Zeitraum>(str, jsonOptions));
        }
    }
}
