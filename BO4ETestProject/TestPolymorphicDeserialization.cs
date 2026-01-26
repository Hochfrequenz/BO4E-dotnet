using System;
using System.Text.Json;
using AwesomeAssertions;
using BO4E.BO;
using BO4E.meta.LenientConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E;

/// <summary>
/// Tests for polymorphic deserialization of BusinessObject via boTyp discriminator.
/// The custom converters (BusinessObjectBaseConverter for Newtonsoft, BusinessObjectSystemTextJsonBaseConverter for STJ)
/// provide case-insensitive boTyp matching and allow boTyp to appear anywhere in the JSON.
/// </summary>
/// <remarks>
/// Why we don't use [JsonPolymorphic] / [JsonDerivedType]:
/// 1. STJ's built-in polymorphic handling requires the discriminator to be the FIRST property in the JSON
/// 2. STJ's built-in polymorphic handling is CASE-SENSITIVE for discriminator values
/// 3. The custom converters support boTyp anywhere in the JSON and case-insensitive matching
/// </remarks>
[TestClass]
public class TestPolymorphicDeserialization
{
    private static readonly JsonSerializerOptions StjOptions =
        LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();

    #region Case Sensitivity Tests

    [TestMethod]
    [DataRow("MARKTLOKATION", DisplayName = "Uppercase boTyp")]
    [DataRow("marktlokation", DisplayName = "Lowercase boTyp")]
    [DataRow("Marktlokation", DisplayName = "PascalCase boTyp")]
    [DataRow("MarkTLokaTION", DisplayName = "Mixed case boTyp")]
    public void TestCaseInsensitiveBoTyp_SystemTextJson(string boTypValue)
    {
        var json = $$"""
            {
                "boTyp": "{{boTypValue}}",
                "marktlokationsId": "12345678901"
            }
            """;

        var result = JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Marktlokation));
        Assert.AreEqual("12345678901", ((Marktlokation)result).MarktlokationsId);
    }

    [TestMethod]
    [DataRow("MARKTLOKATION", DisplayName = "Uppercase boTyp")]
    [DataRow("marktlokation", DisplayName = "Lowercase boTyp")]
    [DataRow("Marktlokation", DisplayName = "PascalCase boTyp")]
    [DataRow("MarkTLokaTION", DisplayName = "Mixed case boTyp")]
    public void TestCaseInsensitiveBoTyp_Newtonsoft(string boTypValue)
    {
        var json = $$"""
            {
                "boTyp": "{{boTypValue}}",
                "marktlokationsId": "12345678901"
            }
            """;

        var result = JsonConvert.DeserializeObject<BusinessObject>(json);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Marktlokation));
        Assert.AreEqual("12345678901", ((Marktlokation)result).MarktlokationsId);
    }

    #endregion

    #region Property Position Tests

    [TestMethod]
    public void TestBoTypFirst_SystemTextJson()
    {
        var json = """
            {
                "boTyp": "MESSLOKATION",
                "messlokationsId": "DE0001234567890123456789012345678"
            }
            """;

        var result = JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Messlokation));
    }

    [TestMethod]
    public void TestBoTypMiddle_SystemTextJson()
    {
        var json = """
            {
                "versionStruktur": "1",
                "boTyp": "MESSLOKATION",
                "messlokationsId": "DE0001234567890123456789012345678"
            }
            """;

        var result = JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Messlokation));
    }

    [TestMethod]
    public void TestBoTypLast_SystemTextJson()
    {
        var json = """
            {
                "versionStruktur": "1",
                "messlokationsId": "DE0001234567890123456789012345678",
                "boTyp": "MESSLOKATION"
            }
            """;

        var result = JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Messlokation));
    }

    [TestMethod]
    public void TestBoTypFirst_Newtonsoft()
    {
        var json = """
            {
                "boTyp": "MESSLOKATION",
                "messlokationsId": "DE0001234567890123456789012345678"
            }
            """;

        var result = JsonConvert.DeserializeObject<BusinessObject>(json);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Messlokation));
    }

    [TestMethod]
    public void TestBoTypMiddle_Newtonsoft()
    {
        var json = """
            {
                "versionStruktur": "1",
                "boTyp": "MESSLOKATION",
                "messlokationsId": "DE0001234567890123456789012345678"
            }
            """;

        var result = JsonConvert.DeserializeObject<BusinessObject>(json);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Messlokation));
    }

    [TestMethod]
    public void TestBoTypLast_Newtonsoft()
    {
        var json = """
            {
                "versionStruktur": "1",
                "messlokationsId": "DE0001234567890123456789012345678",
                "boTyp": "MESSLOKATION"
            }
            """;

        var result = JsonConvert.DeserializeObject<BusinessObject>(json);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Messlokation));
    }

    #endregion

    #region Property Name Case Tests (STJ only)

    [TestMethod]
    public void TestBoTypPropertyCamelCase_SystemTextJson()
    {
        // STJ converter checks for both "boTyp" (camelCase) and "BoTyp" (PascalCase)
        var json = """
            {
                "boTyp": "ENERGIEMENGE"
            }
            """;

        var result = JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Energiemenge));
    }

    [TestMethod]
    public void TestBoTypPropertyPascalCase_SystemTextJson()
    {
        // STJ converter checks for both "boTyp" (camelCase) and "BoTyp" (PascalCase)
        var json = """
            {
                "BoTyp": "ENERGIEMENGE"
            }
            """;

        var result = JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Energiemenge));
    }

    [TestMethod]
    public void TestBoTypPropertyCamelCase_Newtonsoft()
    {
        // Newtonsoft converter uses case-insensitive property lookup
        var json = """
            {
                "boTyp": "ENERGIEMENGE"
            }
            """;

        var result = JsonConvert.DeserializeObject<BusinessObject>(json);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Energiemenge));
    }

    [TestMethod]
    public void TestBoTypPropertyPascalCase_Newtonsoft()
    {
        // Newtonsoft converter uses case-insensitive property lookup
        var json = """
            {
                "BoTyp": "ENERGIEMENGE"
            }
            """;

        var result = JsonConvert.DeserializeObject<BusinessObject>(json);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Energiemenge));
    }

    #endregion

    #region All BusinessObject Types Tests

    [TestMethod]
    [DataRow("ANGEBOT", typeof(Angebot))]
    [DataRow("ANFRAGE", typeof(Anfrage))]
    [DataRow("ANSPRECHPARTNER", typeof(Ansprechpartner))]
    [DataRow("AVIS", typeof(Avis))]
    [DataRow("BENACHRICHTIGUNG", typeof(Benachrichtigung))]
    [DataRow("BERECHNUNGSFORMEL", typeof(Berechnungsformel))]
    [DataRow("BILANZIERUNG", typeof(Bilanzierung))]
    [DataRow("EINSPEISUNG", typeof(Einspeisung))]
    [DataRow("ENERGIEMENGE", typeof(Energiemenge))]
    [DataRow("ENTSPERRAUFTRAG", typeof(Entsperrauftrag))]
    [DataRow("GESCHAEFTSPARTNER", typeof(Geschaeftspartner))]
    [DataRow("HANDELSUNSTIMMIGKEIT", typeof(Handelsunstimmigkeit))]
    [DataRow("KOSTEN", typeof(Kosten))]
    [DataRow("LEISTUNGSKURVENDEFINITION", typeof(Leistungskurvendefinition))]
    [DataRow("LOKATIONSZUORDNUNG", typeof(Lokationszuordnung))]
    [DataRow("MABISZAEHLPUNKT", typeof(MabisZaehlpunkt))]
    [DataRow("MARKTLOKATION", typeof(Marktlokation))]
    [DataRow("MESSLOKATION", typeof(Messlokation))]
    [DataRow("NETZLOKATION", typeof(Netzlokation))]
    [DataRow("PREISBLATT", typeof(Preisblatt))]
    [DataRow("PRODUKTPAKET", typeof(Produktpaket))]
    [DataRow("RECHNUNG", typeof(Rechnung))]
    [DataRow("REGION", typeof(Region))]
    [DataRow("REKLAMATION", typeof(Reklamation))]
    [DataRow("SCHALTZEITDEFINITION", typeof(Schaltzeitdefinition))]
    [DataRow("SPERRAUFTRAG", typeof(Sperrauftrag))]
    [DataRow("STATUSBERICHT", typeof(Statusbericht))]
    [DataRow("STEUERBARERESSOURCE", typeof(SteuerbareRessource))]
    [DataRow("SUMMENZEITREIHE", typeof(Summenzeitreihe))]
    [DataRow("TECHNISCHERESSOURCE", typeof(TechnischeRessource))]
    [DataRow("TRANCHE", typeof(Tranche))]
    [DataRow("VERTRAG", typeof(Vertrag))]
    [DataRow("WECHSEL", typeof(Wechsel))]
    [DataRow("ZAEHLER", typeof(Zaehler))]
    [DataRow("ZAEHLZEITDEFINITION", typeof(Zaehlzeitdefinition))]
    public void TestAllBusinessObjectTypes_SystemTextJson(string boTyp, Type expectedType)
    {
        var json = $$"""{ "boTyp": "{{boTyp}}" }""";

        var result = JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, expectedType);
        Assert.AreEqual(boTyp, result.BoTyp);
    }

    [TestMethod]
    [DataRow("ANGEBOT", typeof(Angebot))]
    [DataRow("ANFRAGE", typeof(Anfrage))]
    [DataRow("ANSPRECHPARTNER", typeof(Ansprechpartner))]
    [DataRow("AVIS", typeof(Avis))]
    [DataRow("BENACHRICHTIGUNG", typeof(Benachrichtigung))]
    [DataRow("BERECHNUNGSFORMEL", typeof(Berechnungsformel))]
    [DataRow("BILANZIERUNG", typeof(Bilanzierung))]
    [DataRow("EINSPEISUNG", typeof(Einspeisung))]
    [DataRow("ENERGIEMENGE", typeof(Energiemenge))]
    [DataRow("ENTSPERRAUFTRAG", typeof(Entsperrauftrag))]
    [DataRow("GESCHAEFTSPARTNER", typeof(Geschaeftspartner))]
    [DataRow("HANDELSUNSTIMMIGKEIT", typeof(Handelsunstimmigkeit))]
    [DataRow("KOSTEN", typeof(Kosten))]
    [DataRow("LEISTUNGSKURVENDEFINITION", typeof(Leistungskurvendefinition))]
    [DataRow("LOKATIONSZUORDNUNG", typeof(Lokationszuordnung))]
    [DataRow("MABISZAEHLPUNKT", typeof(MabisZaehlpunkt))]
    [DataRow("MARKTLOKATION", typeof(Marktlokation))]
    [DataRow("MESSLOKATION", typeof(Messlokation))]
    [DataRow("NETZLOKATION", typeof(Netzlokation))]
    [DataRow("PREISBLATT", typeof(Preisblatt))]
    [DataRow("PRODUKTPAKET", typeof(Produktpaket))]
    [DataRow("RECHNUNG", typeof(Rechnung))]
    [DataRow("REGION", typeof(Region))]
    [DataRow("REKLAMATION", typeof(Reklamation))]
    [DataRow("SCHALTZEITDEFINITION", typeof(Schaltzeitdefinition))]
    [DataRow("SPERRAUFTRAG", typeof(Sperrauftrag))]
    [DataRow("STATUSBERICHT", typeof(Statusbericht))]
    [DataRow("STEUERBARERESSOURCE", typeof(SteuerbareRessource))]
    [DataRow("SUMMENZEITREIHE", typeof(Summenzeitreihe))]
    [DataRow("TECHNISCHERESSOURCE", typeof(TechnischeRessource))]
    [DataRow("TRANCHE", typeof(Tranche))]
    [DataRow("VERTRAG", typeof(Vertrag))]
    [DataRow("WECHSEL", typeof(Wechsel))]
    [DataRow("ZAEHLER", typeof(Zaehler))]
    [DataRow("ZAEHLZEITDEFINITION", typeof(Zaehlzeitdefinition))]
    public void TestAllBusinessObjectTypes_Newtonsoft(string boTyp, Type expectedType)
    {
        var json = $$"""{ "boTyp": "{{boTyp}}" }""";

        var result = JsonConvert.DeserializeObject<BusinessObject>(json);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, expectedType);
        Assert.AreEqual(boTyp, result.BoTyp);
    }

    #endregion

    #region Error Handling Tests

    [TestMethod]
    public void TestMissingBoTyp_SystemTextJson_Throws()
    {
        // When boTyp is missing, the STJ converter throws ArgumentException
        // with a descriptive message.
        var json = """{ "messlokationsId": "DE0001234567890123456789012345678" }""";

        Action action = () => JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        action.Should().Throw<ArgumentException>().WithMessage("*boTyp*");
    }

    [TestMethod]
    public void TestMissingBoTyp_Newtonsoft_Throws()
    {
        var json = """{ "messlokationsId": "DE0001234567890123456789012345678" }""";

        Action action = () => JsonConvert.DeserializeObject<BusinessObject>(json);

        action.Should().Throw<ArgumentException>().WithMessage("*boTyp*");
    }

    [TestMethod]
    public void TestUnknownBoTyp_SystemTextJson_Throws()
    {
        var json = """{ "boTyp": "UNKNOWN_TYPE" }""";

        Action action = () => JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        action.Should().Throw<NotImplementedException>().WithMessage("*UNKNOWN_TYPE*");
    }

    [TestMethod]
    public void TestUnknownBoTyp_Newtonsoft_Throws()
    {
        var json = """{ "boTyp": "UNKNOWN_TYPE" }""";

        Action action = () => JsonConvert.DeserializeObject<BusinessObject>(json);

        action.Should().Throw<NotImplementedException>().WithMessage("*UNKNOWN_TYPE*");
    }

    [TestMethod]
    public void TestNullInput_SystemTextJson()
    {
        var json = "null";

        var result = JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        Assert.IsNull(result);
    }

    [TestMethod]
    public void TestNullInput_Newtonsoft()
    {
        var json = "null";

        var result = JsonConvert.DeserializeObject<BusinessObject>(json);

        Assert.IsNull(result);
    }

    [TestMethod]
    public void TestNullBoTypValue_SystemTextJson_Throws()
    {
        var json = """{ "boTyp": null }""";

        Action action = () => JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        action.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void TestNullBoTypValue_Newtonsoft_Throws()
    {
        var json = """{ "boTyp": null }""";

        Action action = () => JsonConvert.DeserializeObject<BusinessObject>(json);

        action.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void TestEmptyBoTypValue_SystemTextJson_Throws()
    {
        var json = """{ "boTyp": "" }""";

        Action action = () => JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        action.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void TestEmptyBoTypValue_Newtonsoft_Throws()
    {
        var json = """{ "boTyp": "" }""";

        Action action = () => JsonConvert.DeserializeObject<BusinessObject>(json);

        action.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void TestWhitespaceBoTypValue_SystemTextJson_Throws()
    {
        var json = """{ "boTyp": "   " }""";

        Action action = () => JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        action.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void TestWhitespaceBoTypValue_Newtonsoft_Throws()
    {
        var json = """{ "boTyp": "   " }""";

        Action action = () => JsonConvert.DeserializeObject<BusinessObject>(json);

        action.Should().Throw<ArgumentException>();
    }

    #endregion

    #region Serialization Tests

    [TestMethod]
    public void TestSerialization_SystemTextJson()
    {
        var malo = new Marktlokation { MarktlokationsId = "12345678901" };

        var json = JsonSerializer.Serialize<BusinessObject>(malo, StjOptions);

        Assert.IsTrue(json.Contains("\"boTyp\":\"MARKTLOKATION\""));
        Assert.IsTrue(json.Contains("\"marktlokationsId\":\"12345678901\""));
    }

    [TestMethod]
    public void TestSerialization_Newtonsoft()
    {
        var malo = new Marktlokation { MarktlokationsId = "12345678901" };

        var json = JsonConvert.SerializeObject(malo);

        Assert.IsTrue(json.Contains("\"boTyp\":\"MARKTLOKATION\""));
        Assert.IsTrue(json.Contains("\"marktlokationsId\":\"12345678901\""));
    }

    [TestMethod]
    public void TestRoundTrip_SystemTextJson()
    {
        var original = new Messlokation
        {
            MesslokationsId = "DE0001234567890123456789012345678",
            Sparte = BO4E.ENUM.Sparte.STROM,
        };

        var json = JsonSerializer.Serialize<BusinessObject>(original, StjOptions);
        var deserialized = JsonSerializer.Deserialize<BusinessObject>(json, StjOptions);

        Assert.IsNotNull(deserialized);
        Assert.IsInstanceOfType(deserialized, typeof(Messlokation));
        var result = (Messlokation)deserialized;
        Assert.AreEqual(original.MesslokationsId, result.MesslokationsId);
        Assert.AreEqual(original.Sparte, result.Sparte);
    }

    [TestMethod]
    public void TestRoundTrip_Newtonsoft()
    {
        var original = new Messlokation
        {
            MesslokationsId = "DE0001234567890123456789012345678",
            Sparte = BO4E.ENUM.Sparte.STROM,
        };

        var json = JsonConvert.SerializeObject(original);
        var deserialized = JsonConvert.DeserializeObject<BusinessObject>(json);

        Assert.IsNotNull(deserialized);
        Assert.IsInstanceOfType(deserialized, typeof(Messlokation));
        var result = (Messlokation)deserialized;
        Assert.AreEqual(original.MesslokationsId, result.MesslokationsId);
        Assert.AreEqual(original.Sparte, result.Sparte);
    }

    #endregion

    #region List Deserialization Tests

    [TestMethod]
    public void TestListOfMixedTypes_SystemTextJson()
    {
        var json = """
            [
                { "boTyp": "MARKTLOKATION", "marktlokationsId": "11111111111" },
                { "boTyp": "MESSLOKATION", "messlokationsId": "DE0001111111111111111111111111111" },
                { "boTyp": "ENERGIEMENGE" }
            ]
            """;

        var result = JsonSerializer.Deserialize<BusinessObject[]>(json, StjOptions);

        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Length);
        Assert.IsInstanceOfType(result[0], typeof(Marktlokation));
        Assert.IsInstanceOfType(result[1], typeof(Messlokation));
        Assert.IsInstanceOfType(result[2], typeof(Energiemenge));
    }

    [TestMethod]
    public void TestListOfMixedTypes_Newtonsoft()
    {
        var json = """
            [
                { "boTyp": "MARKTLOKATION", "marktlokationsId": "11111111111" },
                { "boTyp": "MESSLOKATION", "messlokationsId": "DE0001111111111111111111111111111" },
                { "boTyp": "ENERGIEMENGE" }
            ]
            """;

        var result = JsonConvert.DeserializeObject<BusinessObject[]>(json);

        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Length);
        Assert.IsInstanceOfType(result[0], typeof(Marktlokation));
        Assert.IsInstanceOfType(result[1], typeof(Messlokation));
        Assert.IsInstanceOfType(result[2], typeof(Energiemenge));
    }

    [TestMethod]
    public void TestListWithMixedCaseBoTyp_SystemTextJson()
    {
        var json = """
            [
                { "boTyp": "marktlokation" },
                { "boTyp": "MESSLOKATION" },
                { "boTyp": "Energiemenge" }
            ]
            """;

        var result = JsonSerializer.Deserialize<BusinessObject[]>(json, StjOptions);

        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Length);
        Assert.IsInstanceOfType(result[0], typeof(Marktlokation));
        Assert.IsInstanceOfType(result[1], typeof(Messlokation));
        Assert.IsInstanceOfType(result[2], typeof(Energiemenge));
    }

    #endregion
}
