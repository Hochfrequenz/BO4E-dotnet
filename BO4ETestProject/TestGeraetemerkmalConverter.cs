using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta.LenientConverters;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;

namespace TestBO4E;

[TestClass]
public class TestGeraeteerkmalDeserialization
{
    private const string JsonString = "{\"merkmal\":\"G4\"}";
    private const string JsonStringWithPeriod = "{\"merkmal\":\"G2Period5\"}";
    private const string JsonStringWithLiteralFullstop = "{\"merkmal\":\"G2.5\"}";
    private const string JsonStringWasser = "{\"merkmal\":\"WASSER_MWZW\"}";

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
        var errorAction = () =>
            Newtonsoft.Json.JsonConvert.DeserializeObject<SomethingWithAGeraetemerkmal>(JsonString);
        errorAction
            .Should()
            .Throw<JsonSerializationException>()
            .Which.Message.StartsWith("Error converting value \"G4\" to type");
    }

    [TestMethod]
    public void TestSystemText_Error()
    {
        var errorAction = () =>
            System.Text.Json.JsonSerializer.Deserialize<SomethingWithAGeraetemerkmal>(JsonString);
        errorAction
            .Should()
            .Throw<JsonException>()
            .Which.Message.StartsWith(
                "The JSON value could not be converted to BO4E.ENUM.Geraetemerkmal"
            );
    }

    [TestMethod]
    public void TestNewtonsoft_Success_NonNullable()
    {
        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<SomethingWithAGeraetemerkmal>(
            JsonString,
            new LenientGeraetemerkmalGasConverter()
        );
        result.Merkmal.Should().Be(Geraetemerkmal.GAS_G4);
    }

    [TestMethod]
    public void TestNewtonsoft_Success_NonNullable_GPointSomething()
    {
        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<SomethingWithAGeraetemerkmal>(
            JsonStringWithPeriod,
            new LenientGeraetemerkmalGasConverter()
        );
        result.Merkmal.Should().Be(Geraetemerkmal.GAS_G2P5);
    }

    [TestMethod]
    public void TestNewtonsoft_Success_Nullable()
    {
        var result =
            Newtonsoft.Json.JsonConvert.DeserializeObject<SomethingWithANullableGeraetemerkmal>(
                JsonString,
                new LenientGeraetemerkmalGasConverter()
            );
        result.Merkmal.Should().Be(Geraetemerkmal.GAS_G4);
    }

    [TestMethod]
    public void TestNewtonsoft_Success_Nullable_Serialization()
    {
        var myInstance = new SomethingWithANullableGeraetemerkmal()
        {
            Merkmal = Geraetemerkmal.GAS_G4,
        };
        var result = JsonConvert.SerializeObject(
            myInstance,
            new JsonSerializerSettings()
            {
                Converters = new List<Newtonsoft.Json.JsonConverter>()
                {
                    new LenientGeraetemerkmalGasConverter(),
                    new Newtonsoft.Json.Converters.StringEnumConverter(),
                },
            }
        );
        result.Should().NotBeNullOrWhiteSpace().And.Contain("\"GAS_G4\"").And.NotContain("\"G4\"");
    }

    [TestMethod]
    public void TestNewtonsoft_Success_Nullable_WASSER_MWZW()
    {
        var result =
            Newtonsoft.Json.JsonConvert.DeserializeObject<SomethingWithANullableGeraetemerkmal>(
                JsonString,
                new LenientGeraetemerkmalGasConverter()
            );
        result.Merkmal.Should().Be(Geraetemerkmal.GAS_G4);
    }

    [TestMethod]
    public void TestNewtonsoft_Success_Nullable_GPointSomething()
    {
        var result =
            Newtonsoft.Json.JsonConvert.DeserializeObject<SomethingWithANullableGeraetemerkmal>(
                JsonStringWasser,
                new LenientGeraetemerkmalGasConverter()
            );
        result.Merkmal.Should().Be(Geraetemerkmal.WASSER_MWZW);
    }

    [TestMethod]
    public void TestSystemText_Success_NonNullable()
    {
        var settings = new System.Text.Json.JsonSerializerOptions()
        {
            Converters = { new LenientSystemTextGeraetemerkmalGasConverter() },
        };
        var result = System.Text.Json.JsonSerializer.Deserialize<SomethingWithAGeraetemerkmal>(
            JsonString,
            settings
        );
        result.Merkmal.Should().Be(Geraetemerkmal.GAS_G4);
    }

    [TestMethod]
    public void TestSystemText_Success_NonNullable_Serialization()
    {
        var myInstance = new SomethingWithANullableGeraetemerkmal()
        {
            Merkmal = Geraetemerkmal.GAS_G4,
        };
        var settings = new System.Text.Json.JsonSerializerOptions()
        {
            Converters = { new LenientSystemTextGeraetemerkmalGasConverter() },
        };
        var result = System.Text.Json.JsonSerializer.Serialize(myInstance, settings);
        result.Should().NotBeNullOrWhiteSpace().And.Contain("\"GAS_G4\"").And.NotContain("\"G4\"");
    }

    [TestMethod]
    public void TestSystemText_Success_NonNullable_WASSER_MWZW()
    {
        var settings = new System.Text.Json.JsonSerializerOptions()
        {
            Converters = { new LenientSystemTextGeraetemerkmalGasConverter() },
        };
        var result = System.Text.Json.JsonSerializer.Deserialize<SomethingWithAGeraetemerkmal>(
            JsonStringWasser,
            settings
        );
        result.Merkmal.Should().Be(Geraetemerkmal.WASSER_MWZW);
    }

    [TestMethod]
    public void TestSystemText_Success_GPointSomething()
    {
        var settings = new System.Text.Json.JsonSerializerOptions()
        {
            Converters = { new LenientSystemTextGeraetemerkmalGasConverter() },
        };
        var result = System.Text.Json.JsonSerializer.Deserialize<SomethingWithAGeraetemerkmal>(
            JsonStringWithPeriod,
            settings
        );
        result.Merkmal.Should().Be(Geraetemerkmal.GAS_G2P5);
    }

    [TestMethod]
    public void TestSystemText_Nullable_Success_GPointSomething()
    {
        var settings = new System.Text.Json.JsonSerializerOptions()
        {
            Converters = { new LenientSystemTextNullableGeraetemerkmalGasConverter() },
        };
        var result =
            System.Text.Json.JsonSerializer.Deserialize<SomethingWithANullableGeraetemerkmal>(
                JsonStringWithPeriod,
                settings
            );
        result.Merkmal.Should().Be(Geraetemerkmal.GAS_G2P5);
    }

    [TestMethod]
    public void TestNewtonsoft_Success_Nullable_With_Literal_Fullstop()
    {
        var result =
            Newtonsoft.Json.JsonConvert.DeserializeObject<SomethingWithANullableGeraetemerkmal>(
                JsonStringWithLiteralFullstop,
                new LenientGeraetemerkmalGasConverter()
            );
        result.Merkmal.Should().Be(Geraetemerkmal.GAS_G2P5);
    }

    [TestMethod]
    public void TestSystemText_Success_With_Literal_Fullstop()
    {
        var settings = new System.Text.Json.JsonSerializerOptions()
        {
            Converters = { new LenientSystemTextGeraetemerkmalGasConverter() },
        };
        var result = System.Text.Json.JsonSerializer.Deserialize<SomethingWithAGeraetemerkmal>(
            JsonStringWithLiteralFullstop,
            settings
        );
        result.Merkmal.Should().Be(Geraetemerkmal.GAS_G2P5);
    }

    [TestMethod]
    public void TestSystemText_Success_With_Nullable_Literal_Fullstop()
    {
        var settings = new System.Text.Json.JsonSerializerOptions()
        {
            Converters = { new LenientSystemTextGeraetemerkmalGasConverter() },
        };
        var result =
            System.Text.Json.JsonSerializer.Deserialize<SomethingWithANullableGeraetemerkmal>(
                JsonStringWithLiteralFullstop,
                settings
            );
        result.Merkmal.Should().Be(Geraetemerkmal.GAS_G2P5);
    }

    [TestMethod]
    public void TestSystemText_Write_NonNullable()
    {
        var settings = new System.Text.Json.JsonSerializerOptions()
        {
            Converters = { new LenientSystemTextGeraetemerkmalGasConverter() },
        };
        var instance = new SomethingWithAGeraetemerkmal { Merkmal = Geraetemerkmal.GAS_G4 };
        var json = System.Text.Json.JsonSerializer.Serialize(instance, settings);
        json.Should().Be($"{{\"merkmal\":\"{Geraetemerkmal.GAS_G4.ToString()}\"}}");
    }

    [TestMethod]
    public void TestSystemText_Write_Nullable()
    {
        var settings = new System.Text.Json.JsonSerializerOptions()
        {
            Converters = { new LenientSystemTextNullableGeraetemerkmalGasConverter() },
        };
        var instance = new SomethingWithANullableGeraetemerkmal
        {
            Merkmal = Geraetemerkmal.GAS_G2P5,
        };
        var json = System.Text.Json.JsonSerializer.Serialize(instance, settings);
        json.Should().Be("{\"merkmal\":\"GAS_G2P5\"}");
    }

    [TestMethod]
    public void TestSystemText_Write_Nullable_Null()
    {
        var settings = new System.Text.Json.JsonSerializerOptions()
        {
            Converters = { new LenientSystemTextNullableGeraetemerkmalGasConverter() },
        };
        var instance = new SomethingWithANullableGeraetemerkmal { Merkmal = null };
        var json = System.Text.Json.JsonSerializer.Serialize(instance, settings);
        json.Should().Be("{\"merkmal\":null}");
    }
}
