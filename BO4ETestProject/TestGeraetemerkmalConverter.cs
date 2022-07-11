using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta.LenientConverters;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;

namespace TestBO4E
{
    [TestClass]
    public class TestGeraeteerkmalDeserialization
    {
        private const string JsonString = "{\"merkmal\":\"G4\"}";
        internal class SomethingWithAGeraetemerkmal
        {
            [JsonProperty(PropertyName = "merkmal")] // system.text
            [JsonPropertyName("merkmal")] // newtonsoft
            public Geraetemerkmal Merkmal { get; set; }
        }

        internal class SomethingWithANullableGeraetemerkmal
        {
            [JsonProperty(PropertyName = "merkmal")] // system.text
            [JsonPropertyName("merkmal")] // newtonsoft
            public Geraetemerkmal? Merkmal { get; set; }
        }

        [TestMethod]
        public void TestNewtonsoft_Error()
        {
            var errorAction = () => Newtonsoft.Json.JsonConvert.DeserializeObject<SomethingWithAGeraetemerkmal>(JsonString);
            errorAction.Should().Throw<JsonSerializationException>().Which.Message.StartsWith("Error converting value \"G4\" to type");
        }
        [TestMethod]
        public void TestSystemText_Error()
        {
            var errorAction = () => System.Text.Json.JsonSerializer.Deserialize<SomethingWithAGeraetemerkmal>(JsonString);
            errorAction.Should().Throw<JsonException>().Which.Message.StartsWith("The JSON value could not be converted to BO4E.ENUM.Geraetemerkmal");
        }

        [TestMethod]
        public void TestNewtonsoft_Success_NonNullable()
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<SomethingWithAGeraetemerkmal>(JsonString, new LenientGeraetemerkmalGasConverter());
            result.Merkmal.Should().Be(Geraetemerkmal.GAS_G4);
        }
        [TestMethod]
        public void TestNewtonsoft_Success_Nullable()
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<SomethingWithANullableGeraetemerkmal>(JsonString, new LenientGeraetemerkmalGasConverter());
            result.Merkmal.Should().Be(Geraetemerkmal.GAS_G4);
        }

        // todo: someone should write the system.text equivalent once there's time.
    }
}
