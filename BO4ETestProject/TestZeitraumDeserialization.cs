using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BO4E.COM;
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
            };
            var jsonString = serializer(zeitraum);
            var jsonDict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString); // we deserialize into an anonymous dict just to be decoupled from the json hacks, it is not important that we use system.text for that
            jsonDict["startdatum"].Should().NotBeNull();
            jsonDict["enddatum"].Should().NotBeNull();
            jsonDict["startzeitpunkt"].Should().BeEquivalentTo(jsonDict["startdatum"]);
            jsonDict["endzeitpunkt"].Should().BeEquivalentTo(jsonDict["endzeitpunkt"]);

            // now we remove the datümer and deserialize again into a zeitraum
            jsonDict.Remove("startdatum");
            jsonDict.Remove("enddatum");

            jsonString = System.Text.Json.JsonSerializer.Serialize(jsonDict);
            var deserializedZeitraum = deserializer(jsonString);
            deserializedZeitraum.Should().BeEquivalentTo(zeitraum, opts => opts.Excluding(zr => zr.Dauer).Excluding(zr => zr.Einheit));
            // excluding the two props because they are part of a not so glorious hack `FillNullValues` in the Zeitraum class which I don't want to touch here.
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
