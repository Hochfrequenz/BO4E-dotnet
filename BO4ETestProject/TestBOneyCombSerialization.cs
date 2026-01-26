using System;
using System.Collections.Generic;
using System.Text.Json;
using AwesomeAssertions;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.Marktkommunikation;
using BO4E.meta.LenientConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using BOneyCombV1 = BO4E.Marktkommunikation.v1.BOneyComb;
using BOneyCombV2 = BO4E.Marktkommunikation.v2.BOneyComb;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E;

/// <summary>
/// Roundtrip serialization tests for BOneyComb (v1 and v2).
/// Tests that BOneyComb instances with polymorphic BusinessObject content
/// can be serialized and deserialized correctly with both Newtonsoft and STJ.
/// </summary>
[TestClass]
public class TestBOneyCombSerialization
{
    private static readonly JsonSerializerOptions StjOptions =
        LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();

    #region Test Data Helpers

    private static BOneyCombV1 CreateSimpleBOneyComb()
    {
        return new BOneyCombV1
        {
            Stammdaten =
            [
                new Marktlokation
                {
                    MarktlokationsId = "51238696781",
                    Sparte = Sparte.STROM,
                    Energierichtung = Energierichtung.AUSSP,
                },
                new Messlokation
                {
                    MesslokationsId = "DE0001234567890123456789012345678",
                    Sparte = Sparte.STROM,
                },
            ],
            Transaktionsdaten = new Dictionary<string, string>
            {
                { "Nachrichtendatum", "2024-01-15" },
                { "Pruefidentifikator", "11001" },
            },
            Links = new Dictionary<string, List<string>>
            {
                {
                    "bo4e://Marktlokation/51238696781",
                    ["bo4e://Messlokation/DE0001234567890123456789012345678"]
                },
            },
        };
    }

    private static BOneyCombV1 CreateComplexBOneyComb()
    {
        return new BOneyCombV1
        {
            Stammdaten =
            [
                new Marktlokation
                {
                    MarktlokationsId = "51238696781",
                    Sparte = Sparte.STROM,
                    Energierichtung = Energierichtung.AUSSP,
                    Bilanzierungsmethode = Bilanzierungsmethode.SLP,
                    Netzebene = Netzebene.NSP,
                },
                new Messlokation
                {
                    MesslokationsId = "DE0001234567890123456789012345678",
                    Sparte = Sparte.STROM,
                    Messadresse = new Adresse
                    {
                        Strasse = "Musterstraße",
                        Hausnummer = "42",
                        Postleitzahl = "50667",
                        Ort = "Köln",
                        Landescode = Landescode.DE,
                    },
                },
                new Zaehler
                {
                    Zaehlernummer = "1ABC0123456",
                    Sparte = Sparte.STROM,
                    Zaehlerauspraegung = Zaehlerauspraegung.EINRICHTUNGSZAEHLER,
                    Zaehlertyp = Zaehlertyp.DREHSTROMZAEHLER,
                },
                new Geschaeftspartner
                {
                    Gewerbekennzeichnung = true,
                    Name1 = "Musterfirma GmbH",
                    Partneradresse = new Adresse
                    {
                        Strasse = "Industrieweg",
                        Hausnummer = "1",
                        Postleitzahl = "12345",
                        Ort = "Berlin",
                        Landescode = Landescode.DE,
                    },
                },
            ],
            Transaktionsdaten = new Dictionary<string, string>
            {
                { "Nachrichtendatum", "2024-01-15T10:30:00Z" },
                { "Pruefidentifikator", "11001" },
                { "Referenznummer", "REF-2024-001" },
                { "Dokumentennummer", "DOK-2024-001" },
            },
            Links = new Dictionary<string, List<string>>
            {
                {
                    "bo4e://Marktlokation/51238696781",
                    [
                        "bo4e://Messlokation/DE0001234567890123456789012345678",
                        "bo4e://Zaehler/1ABC0123456",
                    ]
                },
                {
                    "bo4e://Messlokation/DE0001234567890123456789012345678",
                    ["bo4e://Zaehler/1ABC0123456"]
                },
            },
        };
    }

    private static BOneyCombV2 CreateV2BOneyComb()
    {
        return new BOneyCombV2
        {
            Stammdaten =
            [
                new Marktlokation { MarktlokationsId = "51238696781", Sparte = Sparte.STROM },
                new Messlokation
                {
                    MesslokationsId = "DE0001234567890123456789012345678",
                    Sparte = Sparte.STROM,
                },
            ],
            Transaktionsdaten = new Dictionary<string, string>
            {
                { "Nachrichtendatum", "2024-01-15" },
            },
            Links = new Dictionary<string, List<string>>
            {
                {
                    "bo4e://Marktlokation/51238696781",
                    ["bo4e://Messlokation/DE0001234567890123456789012345678"]
                },
            },
            ZeitabhaengigeLinks =
            [
                new ZeitabhaengigeBeziehung
                {
                    ParentId = "bo4e://Marktlokation/51238696781",
                    ChildId = "bo4e://Messlokation/DE0001234567890123456789012345678",
                    GueltigVon = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
                    GueltigBis = new DateTimeOffset(2024, 12, 31, 23, 59, 59, TimeSpan.Zero),
                },
            ],
        };
    }

    #endregion

    #region Newtonsoft Roundtrip Tests

    [TestMethod]
    public void TestSimpleBOneyComb_Roundtrip_Newtonsoft()
    {
        var original = CreateSimpleBOneyComb();

        var json = JsonConvert.SerializeObject(original, Formatting.Indented);
        var deserialized = JsonConvert.DeserializeObject<BOneyCombV1>(json);

        deserialized.Should().NotBeNull();
        deserialized!.Stammdaten.Should().HaveCount(2);
        deserialized.Stammdaten[0].Should().BeOfType<Marktlokation>();
        deserialized.Stammdaten[1].Should().BeOfType<Messlokation>();

        var malo = (Marktlokation)deserialized.Stammdaten[0];
        malo.MarktlokationsId.Should().Be("51238696781");
        malo.Sparte.Should().Be(Sparte.STROM);

        var melo = (Messlokation)deserialized.Stammdaten[1];
        melo.MesslokationsId.Should().Be("DE0001234567890123456789012345678");

        deserialized.Transaktionsdaten.Should().ContainKey("Nachrichtendatum");
        deserialized.Links.Should().ContainKey("bo4e://Marktlokation/51238696781");
    }

    [TestMethod]
    public void TestComplexBOneyComb_Roundtrip_Newtonsoft()
    {
        var original = CreateComplexBOneyComb();

        var json = JsonConvert.SerializeObject(original, Formatting.Indented);
        var deserialized = JsonConvert.DeserializeObject<BOneyCombV1>(json);

        deserialized.Should().NotBeNull();
        deserialized!.Stammdaten.Should().HaveCount(4);

        // Verify each type was correctly deserialized
        deserialized.Stammdaten[0].Should().BeOfType<Marktlokation>();
        deserialized.Stammdaten[1].Should().BeOfType<Messlokation>();
        deserialized.Stammdaten[2].Should().BeOfType<Zaehler>();
        deserialized.Stammdaten[3].Should().BeOfType<Geschaeftspartner>();

        // Verify nested COM objects
        var melo = (Messlokation)deserialized.Stammdaten[1];
        melo.Messadresse.Should().NotBeNull();
        melo.Messadresse!.Strasse.Should().Be("Musterstraße");
        melo.Messadresse.Ort.Should().Be("Köln");

        var gp = (Geschaeftspartner)deserialized.Stammdaten[3];
        gp.Partneradresse.Should().NotBeNull();
        gp.Partneradresse!.Ort.Should().Be("Berlin");
    }

    [TestMethod]
    public void TestV2BOneyComb_Roundtrip_Newtonsoft()
    {
        var original = CreateV2BOneyComb();

        var json = JsonConvert.SerializeObject(original, Formatting.Indented);
        var deserialized = JsonConvert.DeserializeObject<BOneyCombV2>(json);

        deserialized.Should().NotBeNull();
        deserialized!.Stammdaten.Should().HaveCount(2);
        deserialized.ZeitabhaengigeLinks.Should().HaveCount(1);

        var link = deserialized.ZeitabhaengigeLinks![0];
        link.ParentId.Should().Be("bo4e://Marktlokation/51238696781");
        link.GueltigVon.Should().Be(new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero));
    }

    #endregion

    #region System.Text.Json Roundtrip Tests

    [TestMethod]
    public void TestSimpleBOneyComb_Roundtrip_SystemTextJson()
    {
        var original = CreateSimpleBOneyComb();

        var json = JsonSerializer.Serialize(original, StjOptions);
        var deserialized = JsonSerializer.Deserialize<BOneyCombV1>(json, StjOptions);

        deserialized.Should().NotBeNull();
        deserialized!.Stammdaten.Should().HaveCount(2);
        deserialized.Stammdaten[0].Should().BeOfType<Marktlokation>();
        deserialized.Stammdaten[1].Should().BeOfType<Messlokation>();

        var malo = (Marktlokation)deserialized.Stammdaten[0];
        malo.MarktlokationsId.Should().Be("51238696781");
        malo.Sparte.Should().Be(Sparte.STROM);

        var melo = (Messlokation)deserialized.Stammdaten[1];
        melo.MesslokationsId.Should().Be("DE0001234567890123456789012345678");

        deserialized.Transaktionsdaten.Should().ContainKey("Nachrichtendatum");
        deserialized.Links.Should().ContainKey("bo4e://Marktlokation/51238696781");
    }

    [TestMethod]
    public void TestComplexBOneyComb_Roundtrip_SystemTextJson()
    {
        var original = CreateComplexBOneyComb();

        var json = JsonSerializer.Serialize(original, StjOptions);
        var deserialized = JsonSerializer.Deserialize<BOneyCombV1>(json, StjOptions);

        deserialized.Should().NotBeNull();
        deserialized!.Stammdaten.Should().HaveCount(4);

        // Verify each type was correctly deserialized
        deserialized.Stammdaten[0].Should().BeOfType<Marktlokation>();
        deserialized.Stammdaten[1].Should().BeOfType<Messlokation>();
        deserialized.Stammdaten[2].Should().BeOfType<Zaehler>();
        deserialized.Stammdaten[3].Should().BeOfType<Geschaeftspartner>();

        // Verify nested COM objects
        var melo = (Messlokation)deserialized.Stammdaten[1];
        melo.Messadresse.Should().NotBeNull();
        melo.Messadresse!.Strasse.Should().Be("Musterstraße");
        melo.Messadresse.Ort.Should().Be("Köln");

        var gp = (Geschaeftspartner)deserialized.Stammdaten[3];
        gp.Partneradresse.Should().NotBeNull();
        gp.Partneradresse!.Ort.Should().Be("Berlin");
    }

    [TestMethod]
    public void TestV2BOneyComb_Roundtrip_SystemTextJson()
    {
        var original = CreateV2BOneyComb();

        var json = JsonSerializer.Serialize(original, StjOptions);
        var deserialized = JsonSerializer.Deserialize<BOneyCombV2>(json, StjOptions);

        deserialized.Should().NotBeNull();
        deserialized!.Stammdaten.Should().HaveCount(2);
        deserialized.ZeitabhaengigeLinks.Should().HaveCount(1);

        var link = deserialized.ZeitabhaengigeLinks![0];
        link.ParentId.Should().Be("bo4e://Marktlokation/51238696781");
        link.GueltigVon.Should().Be(new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero));
    }

    #endregion

    #region Cross-Serializer Compatibility Tests

    [TestMethod]
    public void TestBOneyComb_NewtonsoftToStj_Compatibility()
    {
        // Serialize with Newtonsoft, deserialize with STJ
        var original = CreateComplexBOneyComb();

        var newtonsoftJson = JsonConvert.SerializeObject(original);
        var deserialized = JsonSerializer.Deserialize<BOneyCombV1>(newtonsoftJson, StjOptions);

        deserialized.Should().NotBeNull();
        deserialized!.Stammdaten.Should().HaveCount(4);
        deserialized.Stammdaten[0].Should().BeOfType<Marktlokation>();
        deserialized.Stammdaten[1].Should().BeOfType<Messlokation>();
        deserialized.Stammdaten[2].Should().BeOfType<Zaehler>();
        deserialized.Stammdaten[3].Should().BeOfType<Geschaeftspartner>();
    }

    [TestMethod]
    public void TestBOneyComb_StjToNewtonsoft_Compatibility()
    {
        // Serialize with STJ, deserialize with Newtonsoft
        var original = CreateComplexBOneyComb();

        var stjJson = JsonSerializer.Serialize(original, StjOptions);
        var deserialized = JsonConvert.DeserializeObject<BOneyCombV1>(stjJson);

        deserialized.Should().NotBeNull();
        deserialized!.Stammdaten.Should().HaveCount(4);
        deserialized.Stammdaten[0].Should().BeOfType<Marktlokation>();
        deserialized.Stammdaten[1].Should().BeOfType<Messlokation>();
        deserialized.Stammdaten[2].Should().BeOfType<Zaehler>();
        deserialized.Stammdaten[3].Should().BeOfType<Geschaeftspartner>();
    }

    #endregion

    #region Edge Cases

    [TestMethod]
    public void TestEmptyBOneyComb_Roundtrip_Newtonsoft()
    {
        var original = new BOneyCombV1();

        var json = JsonConvert.SerializeObject(original);
        var deserialized = JsonConvert.DeserializeObject<BOneyCombV1>(json);

        deserialized.Should().NotBeNull();
        deserialized!.Stammdaten.Should().BeEmpty();
        deserialized.Transaktionsdaten.Should().BeEmpty();
    }

    [TestMethod]
    public void TestEmptyBOneyComb_Roundtrip_SystemTextJson()
    {
        var original = new BOneyCombV1();

        var json = JsonSerializer.Serialize(original, StjOptions);
        var deserialized = JsonSerializer.Deserialize<BOneyCombV1>(json, StjOptions);

        deserialized.Should().NotBeNull();
        deserialized!.Stammdaten.Should().BeEmpty();
        deserialized.Transaktionsdaten.Should().BeEmpty();
    }

    [TestMethod]
    public void TestBOneyComb_WithMixedCaseBoTyp_Newtonsoft()
    {
        // JSON with mixed case boTyp values
        var json = """
            {
                "stammdaten": [
                    { "boTyp": "marktlokation", "marktlokationsId": "12345678901" },
                    { "boTyp": "MESSLOKATION", "messlokationsId": "DE0001234567890123456789012345678" }
                ],
                "transaktionsdaten": {}
            }
            """;

        var deserialized = JsonConvert.DeserializeObject<BOneyCombV1>(json);

        deserialized.Should().NotBeNull();
        deserialized!.Stammdaten.Should().HaveCount(2);
        deserialized.Stammdaten[0].Should().BeOfType<Marktlokation>();
        deserialized.Stammdaten[1].Should().BeOfType<Messlokation>();
    }

    [TestMethod]
    public void TestBOneyComb_WithMixedCaseBoTyp_SystemTextJson()
    {
        // JSON with mixed case boTyp values
        var json = """
            {
                "stammdaten": [
                    { "boTyp": "marktlokation", "marktlokationsId": "12345678901" },
                    { "boTyp": "MESSLOKATION", "messlokationsId": "DE0001234567890123456789012345678" }
                ],
                "transaktionsdaten": {}
            }
            """;

        var deserialized = JsonSerializer.Deserialize<BOneyCombV1>(json, StjOptions);

        deserialized.Should().NotBeNull();
        deserialized!.Stammdaten.Should().HaveCount(2);
        deserialized.Stammdaten[0].Should().BeOfType<Marktlokation>();
        deserialized.Stammdaten[1].Should().BeOfType<Messlokation>();
    }

    #endregion
}
