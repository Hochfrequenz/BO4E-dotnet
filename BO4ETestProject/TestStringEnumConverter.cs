#nullable enable
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using AwesomeAssertions;
using BO4E.ENUM;
using BO4E.meta.LenientConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E;

/// <summary>
/// gasqualitaet enum before https://github.com/Hochfrequenz/BO4E-dotnet/pull/508
/// </summary>
/// <remarks>I opened a bug at System.Text for this: https://github.com/dotnet/runtime/issues/107296</remarks>
public enum LegacyGasQualitaet
{
    /// <summary>High Caloric Gas</summary>
    [EnumMember(Value = "H_GAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("H_GAS")]
    H_GAS = 1,

    /// <summary>Low Caloric Gas</summary>
    [EnumMember(Value = "L_GAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("L_GAS")]
    L_GAS = 2,

    /// <summary>High Caloric Gas</summary>
    [EnumMember(Value = "HGAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HGAS")]
    HGAS = 1,

    /// <summary>Low Caloric Gas</summary>
    [EnumMember(Value = "LGAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LGAS")]
    LGAS = 2,
}

public class SomethingWithGasqualitaet
{
    public LegacyGasQualitaet Gasqualitaet { get; set; }
}

[TestClass]
public class TestStringEnumConverter
{
    private readonly IList<Mengeneinheit> einheiten = new List<Mengeneinheit> { Mengeneinheit.TAG };

    [TestMethod]
    public void TestMengeneinheitNewtonsoft()
    {
        var jsonString = JsonConvert.SerializeObject(einheiten, new StringEnumConverter());
        Assert.IsTrue(jsonString.Contains("TAG"));
    }

    [TestMethod]
    public void TestMengeneinheit()
    {
        var options = new JsonSerializerOptions
        {
            Converters = { new StringNullableEnumConverter() },
        };
        var jsonString = JsonSerializer.Serialize(einheiten, options);
        Assert.IsTrue(jsonString.Contains("TAG"));
    }

    [TestMethod]
    [DataRow(LegacyGasQualitaet.LGAS)]
    [DataRow(LegacyGasQualitaet.L_GAS)]
    [DataRow(LegacyGasQualitaet.HGAS)]
    [DataRow(LegacyGasQualitaet.H_GAS)]
    [Ignore(
        "This test/the newtonsoft.json code path just worked accidentally, as a commenter in https://github.com/dotnet/runtime/issues/107296 pointed out"
    )]
    public void Test_Newtonsoft_With_Degenerate_Enum(LegacyGasQualitaet qualiaet)
    {
        var jsonString = JsonConvert.SerializeObject(
            new SomethingWithGasqualitaet { Gasqualitaet = qualiaet },
            new StringEnumConverter()
        );
        jsonString.Should().ContainAny("H_GAS", "L_GAS").And.NotContainAny("HGAS", "LGAS");
    }

    [TestMethod]
    [DataRow(LegacyGasQualitaet.LGAS)]
    [DataRow(LegacyGasQualitaet.L_GAS)]
    [DataRow(LegacyGasQualitaet.HGAS)] // as of 2024-09-03 both H-GAS test cases fail but both L-GAS test cases pass 🤯
    [DataRow(LegacyGasQualitaet.H_GAS)]
    [Ignore(
        "this test fails but at least I understand it now: See https://github.com/dotnet/runtime/issues/107296"
    )]
    public void Test_System_Text_With_Degenerate_Enum(LegacyGasQualitaet qualiaet)
    {
        var options = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };
        var jsonString = JsonSerializer.Serialize(
            new SomethingWithGasqualitaet { Gasqualitaet = qualiaet },
            options
        );
        jsonString.Should().ContainAny("H_GAS", "L_GAS").And.NotContainAny("HGAS", "LGAS");
    }

    public class ClassWithNullableGasqualitaet
    {
        public Gasqualitaet? Foo { get; set; }
    }

    public class ClassWithNonNullableGasqualitaet
    {
        public Gasqualitaet Foo { get; set; }
    }

    [TestMethod]
    [DataRow("HGAS", Gasqualitaet.H_GAS, false)]
    [DataRow("h_GAS", Gasqualitaet.H_GAS, false)]
    [DataRow("H_GAS", Gasqualitaet.H_GAS, false)]
    [DataRow("LGAS", Gasqualitaet.L_GAS, false)]
    [DataRow("L_GAS", Gasqualitaet.L_GAS, false)]
    [DataRow(null, null, false)]
    [DataRow("HGAS", Gasqualitaet.H_GAS, true)]
    [DataRow("h_GAS", Gasqualitaet.H_GAS, true)]
    [DataRow("H_GAS", Gasqualitaet.H_GAS, true)]
    [DataRow("LGAS", Gasqualitaet.L_GAS, true)]
    [DataRow("L_GAS", Gasqualitaet.L_GAS, true)]
    [DataRow(null, null, true)]
    public void Test_System_Text_Gasqualitaet_Legacy_Converter_With_Nullable_Gasqualitaet(
        string? jsonValue,
        Gasqualitaet? expectedGasqualitaet,
        bool useMostLenient
    )
    {
        string jsonString;
        if (jsonValue != null)
        {
            jsonString = "{\"Foo\": \"" + jsonValue + "\"}";
        }
        else
        {
            jsonString = "{\"Foo\": null}";
        }

        JsonSerializerOptions settings;
        if (useMostLenient)
        {
            settings = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
        }
        else
        {
            settings = new JsonSerializerOptions
            {
                Converters = { new SystemTextNullableGasqualitaetStringEnumConverter() },
            };
        }

        var actual = System.Text.Json.JsonSerializer.Deserialize<ClassWithNullableGasqualitaet>(
            jsonString,
            settings
        );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedGasqualitaet);

        var reSerializedJsonString = System.Text.Json.JsonSerializer.Serialize(actual, settings);
        reSerializedJsonString.Should().Contain(expectedGasqualitaet?.ToString() ?? "null");
    }

    [TestMethod]
    [DataRow("HGAS", Gasqualitaet.H_GAS, false)]
    [DataRow("h_GAS", Gasqualitaet.H_GAS, false)]
    [DataRow("H_GAS", Gasqualitaet.H_GAS, false)]
    [DataRow("LGAS", Gasqualitaet.L_GAS, false)]
    [DataRow("L_GAS", Gasqualitaet.L_GAS, false)]
    [DataRow("HGAS", Gasqualitaet.H_GAS, true)]
    [DataRow("h_GAS", Gasqualitaet.H_GAS, true)]
    [DataRow("H_GAS", Gasqualitaet.H_GAS, true)]
    [DataRow("LGAS", Gasqualitaet.L_GAS, true)]
    [DataRow("L_GAS", Gasqualitaet.L_GAS, true)]
    public void Test_System_Text_Gasqualitaet_Legacy_Converter_With_Non_Nullable_Gasqualitaet(
        string? jsonValue,
        Gasqualitaet expectedGasqualitaet,
        bool useMostLenient
    )
    {
        string jsonString;
        if (jsonValue != null)
        {
            jsonString = "{\"Foo\": \"" + jsonValue + "\"}";
        }
        else
        {
            jsonString = "{\"Foo\": null}";
        }

        JsonSerializerOptions settings;
        if (useMostLenient)
        {
            settings = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
        }
        else
        {
            settings = new JsonSerializerOptions
            {
                Converters = { new SystemTextGasqualitaetStringEnumConverter() },
            };
        }
        var actual = System.Text.Json.JsonSerializer.Deserialize<ClassWithNonNullableGasqualitaet>(
            jsonString,
            settings
        );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedGasqualitaet);

        var reSerializedJsonString = System.Text.Json.JsonSerializer.Serialize(actual, settings);
        reSerializedJsonString.Should().Contain(expectedGasqualitaet.ToString());
    }

    [TestMethod]
    [DataRow("HGAS", Gasqualitaet.H_GAS, false)]
    [DataRow("H_GAS", Gasqualitaet.H_GAS, false)]
    [DataRow("h_GAS", Gasqualitaet.H_GAS, false)]
    [DataRow("LGAS", Gasqualitaet.L_GAS, false)]
    [DataRow("L_GAS", Gasqualitaet.L_GAS, false)]
    [DataRow(null, null, false)]
    [DataRow("HGAS", Gasqualitaet.H_GAS, true)]
    [DataRow("H_GAS", Gasqualitaet.H_GAS, true)]
    [DataRow("h_GAS", Gasqualitaet.H_GAS, true)]
    [DataRow("LGAS", Gasqualitaet.L_GAS, true)]
    [DataRow("L_GAS", Gasqualitaet.L_GAS, true)]
    [DataRow(null, null, true)]
    public void Test_Newtonsoft_Gasqualitaet_Legacy_Converter_With_Nullable_Gasqualitaet(
        string? jsonValue,
        Gasqualitaet? expectedGasqualitaet,
        bool useMostLenient
    )
    {
        string jsonString;
        if (jsonValue != null)
        {
            jsonString = "{\"Foo\": \"" + jsonValue + "\"}";
        }
        else
        {
            jsonString = "{\"Foo\": null}";
        }

        JsonSerializerSettings settings;
        if (useMostLenient)
        {
            settings = LenientParsing.MOST_LENIENT.GetJsonSerializerSettings();
        }
        else
        {
            settings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                Converters =
                {
                    new NewtonsoftGasqualitaetStringEnumConverter(),
                    new StringEnumConverter(),
                },
            };
        }
        var actual = Newtonsoft.Json.JsonConvert.DeserializeObject<ClassWithNullableGasqualitaet>(
            jsonString,
            settings
        );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedGasqualitaet);

        var reSerializedJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(actual, settings);
        reSerializedJsonString.Should().Contain(expectedGasqualitaet?.ToString() ?? "null");
    }

    [TestMethod]
    [DataRow("HGAS", Gasqualitaet.H_GAS, true)]
    [DataRow("H_GAS", Gasqualitaet.H_GAS, true)]
    [DataRow("h_GAS", Gasqualitaet.H_GAS, true)]
    [DataRow("LGAS", Gasqualitaet.L_GAS, true)]
    [DataRow("L_GAS", Gasqualitaet.L_GAS, true)]
    [DataRow("HGAS", Gasqualitaet.H_GAS, false)]
    [DataRow("H_GAS", Gasqualitaet.H_GAS, false)]
    [DataRow("h_GAS", Gasqualitaet.H_GAS, false)]
    [DataRow("LGAS", Gasqualitaet.L_GAS, false)]
    [DataRow("L_GAS", Gasqualitaet.L_GAS, false)]
    public void Test_Newtonsoft_Gasqualitaet_Legacy_Converter_With_Non_Nullable_Gasqualitaet(
        string? jsonValue,
        Gasqualitaet expectedGasqualitaet,
        bool useMostLenient
    )
    {
        string jsonString;
        if (jsonValue != null)
        {
            jsonString = "{\"Foo\": \"" + jsonValue + "\"}";
        }
        else
        {
            jsonString = "{\"Foo\": null}";
        }
        JsonSerializerSettings settings;
        if (useMostLenient)
        {
            settings = LenientParsing.MOST_LENIENT.GetJsonSerializerSettings();
        }
        else
        {
            settings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                Converters =
                {
                    new NewtonsoftGasqualitaetStringEnumConverter(),
                    new StringEnumConverter(),
                },
            };
        }

        var actual =
            Newtonsoft.Json.JsonConvert.DeserializeObject<ClassWithNonNullableGasqualitaet>(
                jsonString,
                settings
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedGasqualitaet);

        var reSerializedJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(actual, settings);
        reSerializedJsonString.Should().Contain(expectedGasqualitaet.ToString());
    }

    [TestMethod]
    [DataRow(1, Gasqualitaet.H_GAS)]
    [DataRow(2, Gasqualitaet.L_GAS)]
    public void Test_SystemText_Gasqualitaet_Legacy_Converter_With_Non_Nullable_Gasqualitaet_Integer(
        int jsonValue,
        Gasqualitaet expectedGasqualitaet
    )
    {
        string jsonString = "{\"Foo\": " + jsonValue + "}";
        var settings = new JsonSerializerOptions
        {
            Converters = { new SystemTextGasqualitaetStringEnumConverter() },
        };
        var actual = System.Text.Json.JsonSerializer.Deserialize<ClassWithNonNullableGasqualitaet>(
            jsonString,
            settings
        );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedGasqualitaet);

        var reSerializedJsonString = System.Text.Json.JsonSerializer.Serialize(actual, settings);
        reSerializedJsonString.Should().Contain(expectedGasqualitaet.ToString());
    }

    [TestMethod]
    [DataRow(1, Gasqualitaet.H_GAS)]
    [DataRow(2, Gasqualitaet.L_GAS)]
    public void Test_Newtonsoft_Gasqualitaet_Legacy_Converter_With_Non_Nullable_Gasqualitaet_Integer(
        int jsonValue,
        Gasqualitaet expectedGasqualitaet
    )
    {
        string jsonString = "{\"Foo\": " + jsonValue + "}";
        var settings = new Newtonsoft.Json.JsonSerializerSettings()
        {
            Converters =
            {
                new NewtonsoftGasqualitaetStringEnumConverter(),
                new StringEnumConverter(),
            },
        };
        var actual =
            Newtonsoft.Json.JsonConvert.DeserializeObject<ClassWithNonNullableGasqualitaet>(
                jsonString,
                settings
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedGasqualitaet);

        var reSerializedJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(actual, settings);
        reSerializedJsonString.Should().Contain(expectedGasqualitaet.ToString());
    }

    public class ClassWithNullableVerwendungszweck
    {
        public Verwendungszweck? Foo { get; set; }
    }

    public class ClassWithNonNullableVerwendungszweck
    {
        public Verwendungszweck Foo { get; set; }
    }

    [TestMethod]
    [DataRow("MEHRMINDERMENGENABRECHNUNG", Verwendungszweck.MEHRMINDERMENGENABRECHNUNG)]
    [DataRow("MEHRMINDERMBENGENABRECHNUNG", Verwendungszweck.MEHRMINDERMENGENABRECHNUNG)]
    [DataRow(null, null)]
    public void Test_System_Text_Verwendungszweck_Legacy_Converter_With_Nullable_Verwendungszweck(
        string? jsonValue,
        Verwendungszweck? expectedVerwendungszweck
    )
    {
        string jsonString;
        if (jsonValue != null)
        {
            jsonString = "{\"Foo\": \"" + jsonValue + "\"}";
        }
        else
        {
            jsonString = "{\"Foo\": null}";
        }

        var settings = new JsonSerializerOptions
        {
            Converters = { new SystemTextNullableVerwendungszweckStringEnumConverter() },
        };
        var actual = System.Text.Json.JsonSerializer.Deserialize<ClassWithNullableVerwendungszweck>(
            jsonString,
            settings
        );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedVerwendungszweck);

        var reSerializedJsonString = System.Text.Json.JsonSerializer.Serialize(actual, settings);
        reSerializedJsonString.Should().Contain(expectedVerwendungszweck?.ToString() ?? "null");
    }

    [TestMethod]
    [DataRow("MEHRMINDERMENGENABRECHNUNG", Verwendungszweck.MEHRMINDERMENGENABRECHNUNG)]
    [DataRow("MEHRMINDERMBENGENABRECHNUNG", Verwendungszweck.MEHRMINDERMENGENABRECHNUNG)]
    public void Test_System_Text_Verwendungszweck_Legacy_Converter_With_Non_Nullable_Verwendungszweck(
        string? jsonValue,
        Verwendungszweck expectedVerwendungszweck
    )
    {
        string jsonString;
        if (jsonValue != null)
        {
            jsonString = "{\"Foo\": \"" + jsonValue + "\"}";
        }
        else
        {
            jsonString = "{\"Foo\": null}";
        }
        var settings = new JsonSerializerOptions
        {
            Converters = { new SystemTextVerwendungszweckStringEnumConverter() },
        };
        var actual =
            System.Text.Json.JsonSerializer.Deserialize<ClassWithNonNullableVerwendungszweck>(
                jsonString,
                settings
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedVerwendungszweck);

        var reSerializedJsonString = System.Text.Json.JsonSerializer.Serialize(actual, settings);
        reSerializedJsonString.Should().Contain(expectedVerwendungszweck.ToString());
    }

    [TestMethod]
    [DataRow("MEHRMINDERMENGENABRECHNUNG", Verwendungszweck.MEHRMINDERMENGENABRECHNUNG)]
    [DataRow("MEHRMINDERMBENGENABRECHNUNG", Verwendungszweck.MEHRMINDERMENGENABRECHNUNG)]
    [DataRow(null, null)]
    public void Test_Newtonsoft_Verwendungszweck_Legacy_Converter_With_Nullable_Verwendungszweck(
        string? jsonValue,
        Verwendungszweck? expectedVerwendungszweck
    )
    {
        string jsonString;
        if (jsonValue != null)
        {
            jsonString = "{\"Foo\": \"" + jsonValue + "\"}";
        }
        else
        {
            jsonString = "{\"Foo\": null}";
        }

        var settings = new Newtonsoft.Json.JsonSerializerSettings()
        {
            Converters =
            {
                new NewtonsoftVerwendungszweckStringEnumConverter(),
                new StringEnumConverter(),
            },
        };
        var actual =
            Newtonsoft.Json.JsonConvert.DeserializeObject<ClassWithNullableVerwendungszweck>(
                jsonString,
                settings
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedVerwendungszweck);

        var reSerializedJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(actual, settings);
        reSerializedJsonString.Should().Contain(expectedVerwendungszweck?.ToString() ?? "null");
    }

    [TestMethod]
    [DataRow("MEHRMINDERMENGENABRECHNUNG", Verwendungszweck.MEHRMINDERMENGENABRECHNUNG)]
    [DataRow("MEHRMINDERMBENGENABRECHNUNG", Verwendungszweck.MEHRMINDERMENGENABRECHNUNG)]
    public void Test_Newtonsoft_Verwendungszweck_Legacy_Converter_With_Non_Nullable_Verwendungszweck(
        string? jsonValue,
        Verwendungszweck expectedVerwendungszweck
    )
    {
        string jsonString = "{\"Foo\": \"" + jsonValue + "\"}";
        var settings = new Newtonsoft.Json.JsonSerializerSettings()
        {
            Converters =
            {
                new NewtonsoftVerwendungszweckStringEnumConverter(),
                new StringEnumConverter(),
            },
        };
        var actual =
            Newtonsoft.Json.JsonConvert.DeserializeObject<ClassWithNonNullableVerwendungszweck>(
                jsonString,
                settings
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedVerwendungszweck);

        var reSerializedJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(actual, settings);
        reSerializedJsonString.Should().Contain(expectedVerwendungszweck.ToString());
    }

    [TestMethod]
    [DataRow(
        (int)Verwendungszweck.MEHRMINDERMENGENABRECHNUNG,
        Verwendungszweck.MEHRMINDERMENGENABRECHNUNG
    )]
    public void Test_SystemText_Verwendungszweck_Legacy_Converter_With_Non_Nullable_Verwendungszweck_Integer(
        int jsonValue,
        Verwendungszweck expectedVerwendungszweck
    )
    {
        string jsonString = "{\"Foo\": " + jsonValue + "}";
        var settings = new JsonSerializerOptions
        {
            Converters =
            {
                new SystemTextNullableVerwendungszweckStringEnumConverter(),
                new JsonStringEnumConverter(),
            },
        };
        var actual =
            System.Text.Json.JsonSerializer.Deserialize<ClassWithNonNullableVerwendungszweck>(
                jsonString,
                settings
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedVerwendungszweck);

        var reSerializedJsonString = System.Text.Json.JsonSerializer.Serialize(actual, settings);
        reSerializedJsonString.Should().Contain(expectedVerwendungszweck.ToString());
    }

    [TestMethod]
    [DataRow(
        (int)Verwendungszweck.MEHRMINDERMENGENABRECHNUNG,
        Verwendungszweck.MEHRMINDERMENGENABRECHNUNG
    )]
    public void Test_Newtonsoft_Verwendungszweck_Legacy_Converter_With_Non_Nullable_Verwendungszweck_Integer(
        int jsonValue,
        Verwendungszweck expectedVerwendungszweck
    )
    {
        string jsonString = "{\"Foo\": " + jsonValue + "}";
        var settings = new Newtonsoft.Json.JsonSerializerSettings()
        {
            Converters =
            {
                new NewtonsoftVerwendungszweckStringEnumConverter(),
                new StringEnumConverter(),
            },
        };
        var actual =
            Newtonsoft.Json.JsonConvert.DeserializeObject<ClassWithNonNullableVerwendungszweck>(
                jsonString,
                settings
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedVerwendungszweck);

        var reSerializedJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(actual, settings);
        reSerializedJsonString.Should().Contain(expectedVerwendungszweck.ToString());
    }

    public class ClassWithListOfVerwendungszweck
    {
        public List<Verwendungszweck>? Foo { get; set; }
    }

    [TestMethod]
    [DataRow("MEHRMINDERMENGENABRECHNUNG", Verwendungszweck.MEHRMINDERMENGENABRECHNUNG)]
    [DataRow("MEHRMINDERMBENGENABRECHNUNG", Verwendungszweck.MEHRMINDERMENGENABRECHNUNG)]
    public void Test_Newtonsoft_List_of_Verwendungszweck_Conversion(
        string? jsonValue,
        Verwendungszweck expectedVerwendungszweck
    )
    {
        var jsonString = "{\"Foo\": [\"" + jsonValue + "\"]}";
        var result = JsonConvert.DeserializeObject<ClassWithListOfVerwendungszweck>(jsonString);
        result.Should().NotBeNull();
        result.Foo.Should().NotBeNullOrEmpty().And.ContainInOrder(expectedVerwendungszweck);
    }

    [TestMethod]
    public void Test_Newtonsoft_List_of_Verwendungszweck_Conversion_With_Null()
    {
        var jsonString = "{\"Foo\": null}";
        var result = JsonConvert.DeserializeObject<ClassWithListOfVerwendungszweck>(jsonString);
        result.Should().NotBeNull();
        result.Foo.Should().BeNull();
    }

    [TestMethod]
    [DataRow("MEHRMINDERMENGENABRECHNUNG", Verwendungszweck.MEHRMINDERMENGENABRECHNUNG)]
    [DataRow("MEHRMINDERMBENGENABRECHNUNG", Verwendungszweck.MEHRMINDERMENGENABRECHNUNG)]
    public void Test_SystemText_List_of_Verwendungszweck_Conversion(
        string? jsonValue,
        Verwendungszweck expectedVerwendungszweck
    )
    {
        var jsonString = "{\"Foo\": [\"" + jsonValue + "\"]}";
        var result = JsonSerializer.Deserialize<ClassWithListOfVerwendungszweck>(jsonString);
        result.Should().NotBeNull();
        result.Foo.Should().NotBeNullOrEmpty().And.ContainInOrder(expectedVerwendungszweck);
    }

    [TestMethod]
    public void Test_SystemText_List_of_Verwendungszweck_Conversion_With_Null()
    {
        var jsonString = "{\"Foo\": null}";
        var result = JsonSerializer.Deserialize<ClassWithListOfVerwendungszweck>(jsonString);
        result.Should().NotBeNull();
        result.Foo.Should().BeNull();
    }

    public class ClassWithComVerwendungszweck
    {
        public BO4E.COM.Verwendungszweck? Foo { get; set; }
    }

    public class ClassWithAnnotatedComVerwendungszweck
    {
        [System.Text.Json.Serialization.JsonConverter(
            typeof(SystemTextVerwendungszweckEnumToComConverter)
        )]
        [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftVerwendungszweckEnumToComConverter))]
        public BO4E.COM.Verwendungszweck? Foo { get; set; }
    }

    [TestMethod]
    [DataRow("{\"Foo\": \"MEHRMINDERMENGENABRECHNUNG\"}")]
    [DataRow("{\"Foo\": \"MEHRMINDERMBENGENABRECHNUNG\"}")]
    [DataRow("{\"Foo\": {\"zweck\":[\"MEHRMINDERMENGENABRECHNUNG\"]}}")]
    [DataRow("{\"Foo\": {\"zweck\":[\"MEHRMINDERMBENGENABRECHNUNG\"]}}")]
    public void Test_Newtonsoft_VerwendungszweckEnum_To_COM_Converter(string jsonString)
    {
        var settings = new Newtonsoft.Json.JsonSerializerSettings
        {
            Converters = new List<Newtonsoft.Json.JsonConverter>
            {
                new NewtonsoftVerwendungszweckEnumToComConverter(),
            },
        };
        var result = JsonConvert.DeserializeObject<ClassWithComVerwendungszweck>(
            jsonString,
            settings
        );
        result
            .Should()
            .NotBeNull()
            .And.Subject.As<ClassWithComVerwendungszweck>()
            .Foo?.Zweck.Should()
            .NotBeNull()
            .And.ContainEquivalentOf(BO4E.ENUM.Verwendungszweck.MEHRMINDERMENGENABRECHNUNG);

        settings.Converters.Add(new StringEnumConverter());
        var reSerializedJsonString = JsonConvert.SerializeObject(result, settings);
        reSerializedJsonString.Should().Contain("MEHRMINDERMENGENABRECHNUNG");
    }

    [TestMethod]
    [DataRow("{\"Foo\": \"MEHRMINDERMENGENABRECHNUNG\"}")]
    [DataRow("{\"Foo\": \"MEHRMINDERMBENGENABRECHNUNG\"}")]
    [DataRow("{\"Foo\": {\"zweck\":[\"MEHRMINDERMENGENABRECHNUNG\"]}}")]
    [DataRow("{\"Foo\": {\"zweck\":[\"MEHRMINDERMBENGENABRECHNUNG\"]}}")]
    public void Test_Newtonsoft_VerwendungszweckEnum_To_COM_Converter_With_Annotated_Property(
        string jsonString
    )
    {
        var result = JsonConvert.DeserializeObject<ClassWithAnnotatedComVerwendungszweck>(
            jsonString
        );
        result
            .Should()
            .NotBeNull()
            .And.Subject.As<ClassWithAnnotatedComVerwendungszweck>()
            .Foo?.Zweck.Should()
            .NotBeNull()
            .And.ContainEquivalentOf(BO4E.ENUM.Verwendungszweck.MEHRMINDERMENGENABRECHNUNG);
        var reSerializedJsonString = JsonConvert.SerializeObject(
            result,
            new JsonSerializerSettings
            {
                Converters = new List<Newtonsoft.Json.JsonConverter> { new StringEnumConverter() },
            }
        );
        reSerializedJsonString.Should().Contain("MEHRMINDERMENGENABRECHNUNG");
    }

    [TestMethod]
    [DataRow("{\"Foo\": \"MEHRMINDERMENGENABRECHNUNG\"}")]
    [DataRow("{\"Foo\": \"MEHRMINDERMBENGENABRECHNUNG\"}")]
    [DataRow("{\"Foo\": {\"zweck\":[\"MEHRMINDERMENGENABRECHNUNG\"]}}")]
    [DataRow("{\"Foo\": {\"zweck\":[\"MEHRMINDERMBENGENABRECHNUNG\"]}}")]
    public void Test_STJ_VerwendungszweckEnum_To_COM_Converter(string jsonString)
    {
        var settings = new System.Text.Json.JsonSerializerOptions()
        {
            Converters =
            {
                new SystemTextVerwendungszweckStringEnumConverter(),
                new SystemTextVerwendungszweckEnumToComConverter(),
            },
        };
        var result = System.Text.Json.JsonSerializer.Deserialize<ClassWithComVerwendungszweck>(
            jsonString,
            settings
        );
        result
            .Should()
            .NotBeNull()
            .And.Subject.As<ClassWithComVerwendungszweck>()
            .Foo?.Zweck.Should()
            .NotBeNull()
            .And.ContainEquivalentOf(BO4E.ENUM.Verwendungszweck.MEHRMINDERMENGENABRECHNUNG);

        var reSerializedJsonString = System.Text.Json.JsonSerializer.Serialize(result, settings);
        reSerializedJsonString.Should().Contain("MEHRMINDERMENGENABRECHNUNG");
    }

    [TestMethod]
    [DataRow("{\"Foo\": \"MEHRMINDERMENGENABRECHNUNG\"}")]
    [DataRow("{\"Foo\": \"MEHRMINDERMBENGENABRECHNUNG\"}")]
    [DataRow("{\"Foo\": {\"zweck\":[\"MEHRMINDERMENGENABRECHNUNG\"]}}")]
    [DataRow("{\"Foo\": {\"zweck\":[\"MEHRMINDERMBENGENABRECHNUNG\"]}}")]
    public void Test_STJ_VerwendungszweckEnum_To_COM_Converter_With_Annotated_Property(
        string jsonString
    )
    {
        var result =
            System.Text.Json.JsonSerializer.Deserialize<ClassWithAnnotatedComVerwendungszweck>(
                jsonString
            );
        result
            .Should()
            .NotBeNull()
            .And.Subject.As<ClassWithAnnotatedComVerwendungszweck>()
            .Foo?.Zweck.Should()
            .NotBeNull()
            .And.ContainEquivalentOf(BO4E.ENUM.Verwendungszweck.MEHRMINDERMENGENABRECHNUNG);
        var reSerializedJsonString = System.Text.Json.JsonSerializer.Serialize(result);
        reSerializedJsonString.Should().Contain("MEHRMINDERMENGENABRECHNUNG");
    }

    public class ClassWithNullableMarktteilnehmerrolle
    {
        public Marktteilnehmerrolle? Foo { get; set; }
    }

    public class ClassWithNonNullableMarktteilnehmerrolle
    {
        public Marktteilnehmerrolle Foo { get; set; }
    }

    [TestMethod]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI, false)]
    [DataRow("ANDEREPARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, false)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, false)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER, false)]
    [DataRow(null, null, false)]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI, true)]
    [DataRow("ANDEREPARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, true)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, true)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER, true)]
    [DataRow(null, null, true)]
    public void Test_System_Text_Marktteilnehmerrolle_Legacy_Converter_With_Nullable(
        string? jsonValue,
        Marktteilnehmerrolle? expectedMarktteilnehmerrolle,
        bool useMostLenient
    )
    {
        string jsonString;
        if (jsonValue != null)
        {
            jsonString = "{\"Foo\": \"" + jsonValue + "\"}";
        }
        else
        {
            jsonString = "{\"Foo\": null}";
        }

        JsonSerializerOptions settings;
        if (useMostLenient)
        {
            settings = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
        }
        else
        {
            settings = new JsonSerializerOptions
            {
                Converters = { new SystemTextNullableMarktteilnehmerrolleStringEnumConverter() },
            };
        }

        var actual =
            System.Text.Json.JsonSerializer.Deserialize<ClassWithNullableMarktteilnehmerrolle>(
                jsonString,
                settings
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedMarktteilnehmerrolle);

        var reSerializedJsonString = System.Text.Json.JsonSerializer.Serialize(actual, settings);
        reSerializedJsonString.Should().Contain(expectedMarktteilnehmerrolle?.ToString() ?? "null");
    }

    [TestMethod]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI, false)]
    [DataRow("ANDEREPARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, false)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, false)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER, false)]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI, true)]
    [DataRow("ANDEREPARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, true)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, true)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER, true)]
    public void Test_System_Text_Marktteilnehmerrolle_Legacy_Converter_With_Non_Nullable(
        string? jsonValue,
        Marktteilnehmerrolle expectedMarktteilnehmerrolle,
        bool useMostLenient
    )
    {
        string jsonString = "{\"Foo\": \"" + jsonValue + "\"}";

        JsonSerializerOptions settings;
        if (useMostLenient)
        {
            settings = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
        }
        else
        {
            settings = new JsonSerializerOptions
            {
                Converters = { new SystemTextMarktteilnehmerrolleStringEnumConverter() },
            };
        }
        var actual =
            System.Text.Json.JsonSerializer.Deserialize<ClassWithNonNullableMarktteilnehmerrolle>(
                jsonString,
                settings
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedMarktteilnehmerrolle);

        var reSerializedJsonString = System.Text.Json.JsonSerializer.Serialize(actual, settings);
        reSerializedJsonString.Should().Contain(expectedMarktteilnehmerrolle.ToString());
    }

    [TestMethod]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI, false)]
    [DataRow("ANDEREPARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, false)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, false)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER, false)]
    [DataRow(null, null, false)]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI, true)]
    [DataRow("ANDEREPARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, true)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, true)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER, true)]
    [DataRow(null, null, true)]
    public void Test_Newtonsoft_Marktteilnehmerrolle_Legacy_Converter_With_Nullable(
        string? jsonValue,
        Marktteilnehmerrolle? expectedMarktteilnehmerrolle,
        bool useMostLenient
    )
    {
        string jsonString;
        if (jsonValue != null)
        {
            jsonString = "{\"Foo\": \"" + jsonValue + "\"}";
        }
        else
        {
            jsonString = "{\"Foo\": null}";
        }

        Newtonsoft.Json.JsonSerializerSettings settings;
        if (useMostLenient)
        {
            settings = LenientParsing.MOST_LENIENT.GetJsonSerializerSettings();
        }
        else
        {
            settings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                Converters =
                {
                    new NewtonsoftMarktteilnehmerrolleStringEnumConverter(),
                    new StringEnumConverter(),
                },
            };
        }
        var actual =
            Newtonsoft.Json.JsonConvert.DeserializeObject<ClassWithNullableMarktteilnehmerrolle>(
                jsonString,
                settings
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedMarktteilnehmerrolle);

        var reSerializedJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(actual, settings);
        reSerializedJsonString.Should().Contain(expectedMarktteilnehmerrolle?.ToString() ?? "null");
    }

    [TestMethod]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI, true)]
    [DataRow("ANDEREPARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, true)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, true)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER, true)]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI, false)]
    [DataRow("ANDEREPARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, false)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI, false)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER, false)]
    public void Test_Newtonsoft_Marktteilnehmerrolle_Legacy_Converter_With_Non_Nullable(
        string? jsonValue,
        Marktteilnehmerrolle expectedMarktteilnehmerrolle,
        bool useMostLenient
    )
    {
        string jsonString = "{\"Foo\": \"" + jsonValue + "\"}";
        Newtonsoft.Json.JsonSerializerSettings settings;
        if (useMostLenient)
        {
            settings = LenientParsing.MOST_LENIENT.GetJsonSerializerSettings();
        }
        else
        {
            settings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                Converters =
                {
                    new NewtonsoftMarktteilnehmerrolleStringEnumConverter(),
                    new StringEnumConverter(),
                },
            };
        }

        var actual =
            Newtonsoft.Json.JsonConvert.DeserializeObject<ClassWithNonNullableMarktteilnehmerrolle>(
                jsonString,
                settings
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedMarktteilnehmerrolle);

        var reSerializedJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(actual, settings);
        reSerializedJsonString.Should().Contain(expectedMarktteilnehmerrolle.ToString());
    }

    [TestMethod]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER)]
    public void Test_Marktteilnehmer_Deserialization_With_Legacy_Rolle_Newtonsoft(
        string jsonValue,
        Marktteilnehmerrolle expectedRolle
    )
    {
        var jsonString = "{\"rolle\": \"" + jsonValue + "\"}";
        var settings = LenientParsing.MOST_LENIENT.GetJsonSerializerSettings();
        var actual = Newtonsoft.Json.JsonConvert.DeserializeObject<BO4E.BO.Marktteilnehmer>(
            jsonString,
            settings
        );
        actual.Should().NotBeNull();
        actual.Rolle.Should().Be(expectedRolle);
    }

    [TestMethod]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER)]
    public void Test_Marktteilnehmer_Deserialization_With_Legacy_Rolle_SystemText(
        string jsonValue,
        Marktteilnehmerrolle expectedRolle
    )
    {
        var jsonString = "{\"rolle\": \"" + jsonValue + "\"}";
        var settings = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
        var actual = System.Text.Json.JsonSerializer.Deserialize<BO4E.BO.Marktteilnehmer>(
            jsonString,
            settings
        );
        actual.Should().NotBeNull();
        actual.Rolle.Should().Be(expectedRolle);
    }

    [TestMethod]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER)]
    public void Test_Marktteilnehmer_Deserialization_Default_Settings_Newtonsoft(
        string jsonValue,
        Marktteilnehmerrolle expectedRolle
    )
    {
        // Proves that the type-level [JsonConverter] attribute on the enum works
        // for the actual Marktteilnehmer BO without any converter registration.
        var jsonString = "{\"rolle\": \"" + jsonValue + "\"}";
        var actual = Newtonsoft.Json.JsonConvert.DeserializeObject<BO4E.BO.Marktteilnehmer>(
            jsonString
        );
        actual.Should().NotBeNull();
        actual.Rolle.Should().Be(expectedRolle);
    }

    [TestMethod]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER)]
    public void Test_Marktteilnehmer_Deserialization_Default_Settings_SystemText(
        string jsonValue,
        Marktteilnehmerrolle expectedRolle
    )
    {
        // Proves that the property-level [JsonConverter] attribute on Marktteilnehmer.Rolle
        // works without any converter registration or lenient options.
        var jsonString = "{\"rolle\": \"" + jsonValue + "\"}";
        var actual = System.Text.Json.JsonSerializer.Deserialize<BO4E.BO.Marktteilnehmer>(
            jsonString
        );
        actual.Should().NotBeNull();
        actual.Rolle.Should().Be(expectedRolle);
    }

    [TestMethod]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER)]
    public void Test_Newtonsoft_Marktteilnehmerrolle_Default_Settings(
        string jsonValue,
        Marktteilnehmerrolle expectedRolle
    )
    {
        // Proves that the type-level [JsonConverter] attribute works without any explicit
        // converter registration — this is the core design assumption for Newtonsoft.
        var jsonString = "{\"Foo\": \"" + jsonValue + "\"}";
        var actual =
            Newtonsoft.Json.JsonConvert.DeserializeObject<ClassWithNullableMarktteilnehmerrolle>(
                jsonString
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedRolle);
    }

    [TestMethod]
    [DataRow("anderepartei", Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow("ANDERE_PARTEI", Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow("EMPFAENGER", Marktteilnehmerrolle.EMPFAENGER)]
    public void Test_SystemText_Marktteilnehmerrolle_Default_Settings_Non_Nullable(
        string jsonValue,
        Marktteilnehmerrolle expectedRolle
    )
    {
        // Proves that the type-level [JsonConverter] attribute works without any explicit
        // converter registration for non-nullable properties.
        var jsonString = "{\"Foo\": \"" + jsonValue + "\"}";
        var actual =
            System.Text.Json.JsonSerializer.Deserialize<ClassWithNonNullableMarktteilnehmerrolle>(
                jsonString
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedRolle);
    }

    [TestMethod]
    [DataRow((int)Marktteilnehmerrolle.ANDERE_PARTEI, Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow((int)Marktteilnehmerrolle.EMPFAENGER, Marktteilnehmerrolle.EMPFAENGER)]
    public void Test_SystemText_Marktteilnehmerrolle_Integer_Deserialization(
        int jsonValue,
        Marktteilnehmerrolle expectedRolle
    )
    {
        string jsonString = "{\"Foo\": " + jsonValue + "}";
        var settings = new JsonSerializerOptions
        {
            Converters = { new SystemTextMarktteilnehmerrolleStringEnumConverter() },
        };
        var actual =
            System.Text.Json.JsonSerializer.Deserialize<ClassWithNonNullableMarktteilnehmerrolle>(
                jsonString,
                settings
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedRolle);
    }

    [TestMethod]
    [DataRow((int)Marktteilnehmerrolle.ANDERE_PARTEI, Marktteilnehmerrolle.ANDERE_PARTEI)]
    [DataRow((int)Marktteilnehmerrolle.EMPFAENGER, Marktteilnehmerrolle.EMPFAENGER)]
    public void Test_Newtonsoft_Marktteilnehmerrolle_Integer_Deserialization(
        int jsonValue,
        Marktteilnehmerrolle expectedRolle
    )
    {
        string jsonString = "{\"Foo\": " + jsonValue + "}";
        var settings = new Newtonsoft.Json.JsonSerializerSettings()
        {
            Converters =
            {
                new NewtonsoftMarktteilnehmerrolleStringEnumConverter(),
                new StringEnumConverter(),
            },
        };
        var actual =
            Newtonsoft.Json.JsonConvert.DeserializeObject<ClassWithNonNullableMarktteilnehmerrolle>(
                jsonString,
                settings
            );
        actual.Should().NotBeNull();
        actual.Foo.Should().Be(expectedRolle);
    }

    [TestMethod]
    public void Test_Newtonsoft_Marktteilnehmerrolle_Invalid_Value_Throws()
    {
        var jsonString = "{\"Foo\": \"NONSENSE\"}";
        var settings = new Newtonsoft.Json.JsonSerializerSettings()
        {
            Converters =
            {
                new NewtonsoftMarktteilnehmerrolleStringEnumConverter(),
                new StringEnumConverter(),
            },
        };
        var act = () =>
            Newtonsoft.Json.JsonConvert.DeserializeObject<ClassWithNullableMarktteilnehmerrolle>(
                jsonString,
                settings
            );
        act.Should().Throw<Newtonsoft.Json.JsonSerializationException>().WithMessage("*NONSENSE*");
    }

    [TestMethod]
    public void Test_SystemText_Marktteilnehmerrolle_Invalid_Value_Throws()
    {
        var jsonString = "{\"Foo\": \"NONSENSE\"}";
        var settings = new JsonSerializerOptions
        {
            Converters = { new SystemTextMarktteilnehmerrolleStringEnumConverter() },
        };
        var act = () =>
            System.Text.Json.JsonSerializer.Deserialize<ClassWithNonNullableMarktteilnehmerrolle>(
                jsonString,
                settings
            );
        act.Should().Throw<System.Text.Json.JsonException>().WithMessage("*NONSENSE*");
    }
}
