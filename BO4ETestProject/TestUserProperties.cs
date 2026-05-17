using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using AwesomeAssertions;
using BO4E;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta.LenientConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E;

[TestClass]
public class TestUserProperties
{
    private const string meloJson =
        @"{""messlokationsId"": ""DE0123456789012345678901234567890"", ""sparte"": ""STROM"", ""myCustomInfo"": ""some_value_not_covered_by_bo4e"", ""myCustomValue"": 123.456, ""myNullProp"": null}";

    [TestMethod]
    public void TestNetExample()
    {
        using var r = new StreamReader("testjsons/weatherforecast.json");
        var jsonString = r.ReadToEnd();
        var zaehler = JsonSerializer.Deserialize<WeatherForecastWithExtensionData>(jsonString);
    }

    [TestMethod]
    public void TestDeserialization()
    {
        var meloJson =
            @"{'messlokationsId': 'DE0123456789012345678901234567890', 'sparte': 'STROM', 'myCustomInfo': 'some_value_not_covered_by_bo4e', 'myCustomValue': 123.456}";
        var melo = JsonConvert.DeserializeObject<Messlokation>(meloJson);
        Assert.IsTrue(melo.IsValid());
        Assert.IsNotNull(melo.UserProperties);
        Assert.AreEqual(
            "some_value_not_covered_by_bo4e",
            melo.UserProperties["myCustomInfo"] as string
        );
        Assert.AreEqual(123.456M, (decimal)(double)melo.UserProperties["myCustomValue"]);
    }

    [TestMethod]
    public void TestConvertingUserPropertyToBoolean()
    {
        var options = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
        var meloJson =
            @"{""messlokationsId"": ""DE0123456789012345678901234567890"", ""sparte"": ""STROM"", ""myCustomInfo"": ""some_value_not_covered_by_bo4e"", ""myCustomValue"": ""not a boolean""}";
        var melo = JsonSerializer.Deserialize<Messlokation>(meloJson, options);
        melo.Should().NotBeNull();
        melo.IsValid().Should().BeTrue();
        melo.UserProperties.Should().NotBeEmpty();
        melo.UserProperties.Should()
            .ContainKey("myCustomValue")
            .WhoseValue.ToString()
            .Should()
            .Be("not a boolean");

        var flagHasBeenSet = melo.SetFlag("myCustomValue", true);
        flagHasBeenSet
            .Should()
            .BeTrue(
                because: "the non-boolean existing value (which is overwritten) should not crash the code"
            );
        melo.TryGetUserProperty("myCustomValue", out bool booleanValue).Should().BeTrue();
        booleanValue.Should().BeTrue();
    }

    [TestMethod]
    public void TestDeserializationSystemTextJson()
    {
        var options = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
        var meloJson =
            @"{""messlokationsId"": ""DE0123456789012345678901234567890"", ""sparte"": ""STROM"", ""myCustomInfo"": ""some_value_not_covered_by_bo4e"", ""myCustomValue"": 123.456}";
        var melo = JsonSerializer.Deserialize<Messlokation>(meloJson, options);
        Assert.IsTrue(melo.IsValid());
        Assert.IsNotNull(melo.UserProperties);
        Assert.AreEqual(
            "some_value_not_covered_by_bo4e",
            melo.UserProperties["myCustomInfo"].ToString()
        );
        Assert.AreEqual(123.456M, ((JsonElement)melo.UserProperties["myCustomValue"]).GetDecimal());
    }

    private void _AssertUserProperties(Messlokation melo)
    {
        Assert.IsTrue(melo.TryGetUserProperty("myCustomInfo", out string myCustomValue));
        Assert.AreEqual("some_value_not_covered_by_bo4e", myCustomValue);
        Assert.IsTrue(melo.UserPropertyEquals("myCustomValue", 123.456M));
        Assert.IsFalse(melo.UserPropertyEquals("myCustomValue", "foo"));

        Assert.IsFalse(melo.TryGetUserProperty("something else", out string _));
        Assert.AreEqual("default value", melo.GetUserProperty("something else", "default value"));
        Assert.IsFalse(melo.UserPropertyEquals("myCustomInfo", 888.999M)); // the cast exception is catched inside.
        Assert.IsFalse(melo.UserPropertyEquals("myCustomValue", "asd")); // the cast exception is catched inside.
        Assert.IsFalse(melo.UserPropertyEquals("some_key_that_was_not_found", "asd"));
        Assert.IsTrue(
            melo.EvaluateUserProperty<string, bool, Messlokation>(
                "myCustomInfo",
                up => !string.IsNullOrEmpty(up)
            )
        );

        melo.UserProperties = null;
        Assert.IsFalse(melo.UserPropertyEquals("there are no user properties", "asd"));
        Assert.IsFalse(melo.TryGetUserProperty("there are no user properties", out string _));
        var invalidAttempt = () =>
            melo.EvaluateUserProperty<string, bool, Messlokation>(
                "there are no user properties",
                _ => default
            );
        invalidAttempt.Should().Throw<ArgumentNullException>();
        Assert.IsFalse(melo.UserPropertyEquals("myNullProp", true));
    }

    [TestMethod]
    public void TestTryGetUserProperties()
    {
        var melo = JsonConvert.DeserializeObject<Messlokation>(meloJson);
        _AssertUserProperties(melo);
    }

    [TestMethod]
    public void TestTryGetUserPropertiesNet5()
    {
        var options = LenientParsing.STRICT.GetJsonSerializerOptions();
        var melo = JsonSerializer.Deserialize<Messlokation>(meloJson, options);
        _AssertUserProperties(melo);
    }

    [TestMethod]
    public void TestFlags()
    {
        var melo = new Messlokation
        {
            MesslokationsId = "DE0123456789012345678901234567890",
            Sparte = Sparte.STROM,
        };
        Assert.IsNull(melo.UserProperties);
        Assert.IsFalse(melo.HasFlagSet("foo"));
        Assert.IsTrue(melo.SetFlag("foo"));
        Assert.IsNotNull(melo.UserProperties);
        Assert.IsTrue(melo.UserProperties.TryGetValue("foo", out var upValue) && (bool)upValue);
        Assert.IsTrue(melo.HasFlagSet("foo"));
        Assert.IsFalse(melo.SetFlag("foo"));
        Assert.IsTrue(melo.SetFlag("foo", false));
        Assert.IsFalse(melo.HasFlagSet("foo"));
        Assert.IsTrue(melo.SetFlag("foo", null));
        Assert.IsFalse(melo.UserProperties.TryGetValue("foo", out var _));
        Assert.IsFalse(melo.SetFlag("foo", null));
        Assert.IsFalse(melo.HasFlagSet("foo"));
        Assert.IsTrue(melo.SetFlag("foo"));

        melo.UserProperties["foo"] = null;
        Assert.IsFalse(melo.HasFlagSet("foo"));
    }

    /// <summary>
    ///     Tests to set and get a UserProperty
    /// </summary>
    [TestMethod]
    public void TestSetterGetter()
    {
        var melo = new Messlokation
        {
            MesslokationsId = "DE0123456789012345678901234567890",
            Sparte = Sparte.STROM,
        };
        Assert.IsNull(melo.UserProperties);

        var value1 = "BarFoo";
        var value2 = "BigFoot";
        melo.SetUserProperty("foo", new Bar { FooBar = value1 });
        Assert.IsNotNull(melo.UserProperties);
        Assert.IsTrue(melo.UserProperties.TryGetValue("foo", out var upValue));
        Assert.IsInstanceOfType(upValue, typeof(Bar));
        Assert.AreEqual(value1, (upValue as Bar)?.FooBar);

        // Update the value
        melo.SetUserProperty("foo", new Bar { FooBar = value2 });
        Assert.IsTrue(melo.UserProperties.TryGetValue("foo", out upValue));
        Assert.AreEqual(value2, (upValue as Bar)?.FooBar);
    }

    /// <summary>
    ///     Tests to remove UserProperty
    /// </summary>
    [TestMethod]
    public void TestDeletion()
    {
        var melo = new Messlokation
        {
            MesslokationsId = "DE0123456789012345678901234567890",
            Sparte = Sparte.STROM,
        };
        Assert.IsNull(melo.UserProperties);

        var value1 = "BarFoo";
        // Add a value
        melo.SetUserProperty("foo", new Bar { FooBar = value1 });
        Assert.IsNotNull(melo.UserProperties);
        Assert.IsTrue(melo.UserProperties.TryGetValue("foo", out var upValue));
        Assert.AreEqual(value1, (upValue as Bar)?.FooBar);
        // remove it again
        melo.RemoveUserProperty("foo");
        Assert.IsFalse(melo.UserProperties.TryGetValue("foo", out upValue));
        Assert.IsNotNull(melo.UserProperties);
    }

    public class WeatherForecastWithExtensionData
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }

        [System.Text.Json.Serialization.JsonExtensionData]
        public Dictionary<string, object> ExtensionData { get; set; }
    }

    /// <summary>
    ///     Test Class to append a UserProperty
    /// </summary>
    private class Bar
    {
        public string FooBar;
    }

    [TestMethod]
    public void TestBusinessObjectHasAmbiguousUserProperties()
    {
        var zaehlerWithAmbiguousProperties = new Zaehler()
        {
            Zaehlergroesse = Geraetemerkmal.GAS_G6,
            UserProperties = new Dictionary<string, object>
            {
                { "zaehlergroesse", "Foo" },
                { "BoTyp", "Dei Mudder" },
            },
        };
        zaehlerWithAmbiguousProperties.HasAmbiguousUserProperties().Should().BeTrue();
        zaehlerWithAmbiguousProperties
            .GetAmbiguousUserPropertiesKeys()
            .Should()
            .Contain("zaehlergroesse")
            .And.Contain("BoTyp")
            .And.HaveCount(2);

        var zaehlerWithoutAmbiguousProperties = new Zaehler()
        {
            Zaehlergroesse = Geraetemerkmal.GAS_G6,
            UserProperties = new Dictionary<string, object> { { "foo", "bar" } },
        };
        zaehlerWithoutAmbiguousProperties.HasAmbiguousUserProperties().Should().BeFalse();
        zaehlerWithoutAmbiguousProperties.GetAmbiguousUserPropertiesKeys().Should().BeEmpty();
    }

    [TestMethod]
    public void TestComHasAmbiguousUserProperties()
    {
        var adresseWithAmbiguousProperties = new Adresse()
        {
            Hausnummer = "17",
            UserProperties = new Dictionary<string, object>
            {
                { "Hausnummer", 423 },
                { "Postleitzahl", "foobar" },
            },
        };
        adresseWithAmbiguousProperties.HasAmbiguousUserProperties().Should().BeTrue();
        adresseWithAmbiguousProperties
            .GetAmbiguousUserPropertiesKeys()
            .Should()
            .Contain("Hausnummer")
            .And.Contain("Postleitzahl")
            .And.HaveCount(2);

        var adresseWithoutAmbiguousProperties = new Adresse()
        {
            Hausnummer = "17",
            UserProperties = new Dictionary<string, object> { { "foo", "bar" } },
        };
        adresseWithoutAmbiguousProperties.HasAmbiguousUserProperties().Should().BeFalse();
        adresseWithoutAmbiguousProperties.GetAmbiguousUserPropertiesKeys().Should().BeEmpty();
    }
}
