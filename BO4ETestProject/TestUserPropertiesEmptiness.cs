using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AwesomeAssertions;
using BO4E;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E;

/// <summary>
///     Tests for <see cref="UserPropertiesExtensions.HasEmptyUserProperties{TParent}" /> and
///     <see cref="UserPropertiesExtensions.HasAllEmptyUserPropertiesRecursive{TParent}" />.
/// </summary>
[TestClass]
public class TestUserPropertiesEmptiness
{
    #region HasEmptyUserProperties - Simple Check Tests

    [TestMethod]
    public void TestHasEmptyUserProperties_NullObject_ReturnsTrue()
    {
        Messlokation melo = null;
        melo.HasEmptyUserProperties().Should().BeTrue();
    }

    [TestMethod]
    public void TestHasEmptyUserProperties_NullUserProperties_ReturnsTrue()
    {
        var melo = new Messlokation
        {
            MesslokationsId = "DE0123456789012345678901234567890",
            Sparte = Sparte.STROM,
            UserProperties = null,
        };
        melo.HasEmptyUserProperties().Should().BeTrue();
    }

    [TestMethod]
    public void TestHasEmptyUserProperties_EmptyDictionary_ReturnsTrue()
    {
        var melo = new Messlokation
        {
            MesslokationsId = "DE0123456789012345678901234567890",
            Sparte = Sparte.STROM,
            UserProperties = new Dictionary<string, object>(),
        };
        melo.HasEmptyUserProperties().Should().BeTrue();
    }

    [TestMethod]
    public void TestHasEmptyUserProperties_NonEmptyDictionary_ReturnsFalse()
    {
        var melo = new Messlokation
        {
            MesslokationsId = "DE0123456789012345678901234567890",
            Sparte = Sparte.STROM,
            UserProperties = new Dictionary<string, object> { { "customKey", "customValue" } },
        };
        melo.HasEmptyUserProperties().Should().BeFalse();
    }

    [TestMethod]
    public void TestHasEmptyUserProperties_COM_NullUserProperties_ReturnsTrue()
    {
        var adresse = new Adresse
        {
            Postleitzahl = "12345",
            Ort = "Berlin",
            UserProperties = null,
        };
        adresse.HasEmptyUserProperties().Should().BeTrue();
    }

    [TestMethod]
    public void TestHasEmptyUserProperties_COM_NonEmpty_ReturnsFalse()
    {
        var adresse = new Adresse
        {
            Postleitzahl = "12345",
            Ort = "Berlin",
            UserProperties = new Dictionary<string, object> { { "extra", 123 } },
        };
        adresse.HasEmptyUserProperties().Should().BeFalse();
    }

    #endregion

    #region HasAllEmptyUserPropertiesRecursive - Null and Empty Tests

    [TestMethod]
    public void TestRecursive_NullObject_ReturnsTrue()
    {
        Messlokation melo = null;
        var result = melo.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_EmptyObjectNoNested_ReturnsTrue()
    {
        var melo = new Messlokation
        {
            MesslokationsId = "DE0123456789012345678901234567890",
            Sparte = Sparte.STROM,
        };
        var result = melo.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_RootHasUserProperties_ReturnsFalse()
    {
        var melo = new Messlokation
        {
            MesslokationsId = "DE0123456789012345678901234567890",
            Sparte = Sparte.STROM,
            UserProperties = new Dictionary<string, object> { { "unmappedField", "value" } },
        };
        var result = melo.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();
        paths.Should().HaveCount(1);
        paths.Should().Contain("(root)");
    }

    #endregion

    #region HasAllEmptyUserPropertiesRecursive - Single Nested Property Tests

    [TestMethod]
    public void TestRecursive_NestedCOMProperty_Null_ReturnsTrue()
    {
        var marktlokation = new Marktlokation
        {
            MarktlokationsId = "51238696781",
            Sparte = Sparte.STROM,
            Lokationsadresse = null,
        };
        var result = marktlokation.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_NestedCOMProperty_Empty_ReturnsTrue()
    {
        var marktlokation = new Marktlokation
        {
            MarktlokationsId = "51238696781",
            Sparte = Sparte.STROM,
            Lokationsadresse = new Adresse { Postleitzahl = "12345", Ort = "Berlin" },
        };
        var result = marktlokation.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_NestedCOMProperty_NonEmpty_ReturnsFalse()
    {
        var marktlokation = new Marktlokation
        {
            MarktlokationsId = "51238696781",
            Sparte = Sparte.STROM,
            Lokationsadresse = new Adresse
            {
                Postleitzahl = "12345",
                Ort = "Berlin",
                UserProperties = new Dictionary<string, object> { { "unmapped", "data" } },
            },
        };
        var result = marktlokation.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();
        paths.Should().HaveCount(1);
        paths.Should().Contain("Lokationsadresse");
    }

    #endregion

    #region HasAllEmptyUserPropertiesRecursive - List Property Tests

    [TestMethod]
    public void TestRecursive_ListProperty_EmptyList_ReturnsTrue()
    {
        var energiemenge = new Energiemenge
        {
            LokationsId = "DE0123456789012345678901234567890",
            LokationsTyp = Lokationstyp.MELO,
            Energieverbrauch = new List<Verbrauch>(),
        };
        var result = energiemenge.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_ListProperty_NullList_ReturnsTrue()
    {
        var energiemenge = new Energiemenge
        {
            LokationsId = "DE0123456789012345678901234567890",
            LokationsTyp = Lokationstyp.MELO,
            Energieverbrauch = null,
        };
        var result = energiemenge.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_ListProperty_AllItemsEmpty_ReturnsTrue()
    {
        var energiemenge = new Energiemenge
        {
            LokationsId = "DE0123456789012345678901234567890",
            LokationsTyp = Lokationstyp.MELO,
            Energieverbrauch = new List<Verbrauch>
            {
                new Verbrauch { Einheit = Mengeneinheit.KWH, Wert = 100 },
                new Verbrauch { Einheit = Mengeneinheit.KWH, Wert = 200 },
            },
        };
        var result = energiemenge.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_ListProperty_OneItemNonEmpty_ReturnsFalse()
    {
        var energiemenge = new Energiemenge
        {
            LokationsId = "DE0123456789012345678901234567890",
            LokationsTyp = Lokationstyp.MELO,
            Energieverbrauch = new List<Verbrauch>
            {
                new Verbrauch { Einheit = Mengeneinheit.KWH, Wert = 100 },
                new Verbrauch
                {
                    Einheit = Mengeneinheit.KWH,
                    Wert = 200,
                    UserProperties = new Dictionary<string, object> { { "extra", "data" } },
                },
                new Verbrauch { Einheit = Mengeneinheit.KWH, Wert = 300 },
            },
        };
        var result = energiemenge.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();
        paths.Should().HaveCount(1);
        paths.Should().Contain("Energieverbrauch[1]");
    }

    [TestMethod]
    public void TestRecursive_ListProperty_MultipleItemsNonEmpty_ReturnsFalse()
    {
        var energiemenge = new Energiemenge
        {
            LokationsId = "DE0123456789012345678901234567890",
            LokationsTyp = Lokationstyp.MELO,
            Energieverbrauch = new List<Verbrauch>
            {
                new Verbrauch
                {
                    Einheit = Mengeneinheit.KWH,
                    Wert = 100,
                    UserProperties = new Dictionary<string, object> { { "a", 1 } },
                },
                new Verbrauch { Einheit = Mengeneinheit.KWH, Wert = 200 },
                new Verbrauch
                {
                    Einheit = Mengeneinheit.KWH,
                    Wert = 300,
                    UserProperties = new Dictionary<string, object> { { "b", 2 } },
                },
            },
        };
        var result = energiemenge.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();
        paths.Should().HaveCount(2);
        paths.Should().Contain("Energieverbrauch[0]");
        paths.Should().Contain("Energieverbrauch[2]");
    }

    [TestMethod]
    public void TestRecursive_ListProperty_RootAndItemsNonEmpty_ReturnsFalse()
    {
        var energiemenge = new Energiemenge
        {
            LokationsId = "DE0123456789012345678901234567890",
            LokationsTyp = Lokationstyp.MELO,
            UserProperties = new Dictionary<string, object> { { "rootExtra", "rootValue" } },
            Energieverbrauch = new List<Verbrauch>
            {
                new Verbrauch
                {
                    Einheit = Mengeneinheit.KWH,
                    Wert = 100,
                    UserProperties = new Dictionary<string, object>
                    {
                        { "itemExtra", "itemValue" },
                    },
                },
            },
        };
        var result = energiemenge.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();
        paths.Should().HaveCount(2);
        paths.Should().Contain("(root)");
        paths.Should().Contain("Energieverbrauch[0]");
    }

    #endregion

    #region HasAllEmptyUserPropertiesRecursive - Deep Nesting Tests

    [TestMethod]
    public void TestRecursive_DeepNesting_AllEmpty_ReturnsTrue()
    {
        // Rechnung -> Rechnungspositionen (List) -> each has nested COM objects
        var rechnung = new Rechnung
        {
            Rechnungsnummer = "R-2024-001",
            Rechnungspositionen = new List<Rechnungsposition>
            {
                new Rechnungsposition
                {
                    Positionsnummer = 1,
                    LieferungVon = System.DateTimeOffset.Now,
                    LieferungBis = System.DateTimeOffset.Now.AddDays(30),
                    TeilsummeNetto = new Betrag { Wert = 100, Waehrung = Waehrungscode.EUR },
                },
            },
        };
        var result = rechnung.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_DeepNesting_DeepPropertyNonEmpty_ReturnsFalse()
    {
        var rechnung = new Rechnung
        {
            Rechnungsnummer = "R-2024-001",
            Rechnungspositionen = new List<Rechnungsposition>
            {
                new Rechnungsposition
                {
                    Positionsnummer = 1,
                    LieferungVon = System.DateTimeOffset.Now,
                    LieferungBis = System.DateTimeOffset.Now.AddDays(30),
                    TeilsummeNetto = new Betrag
                    {
                        Wert = 100,
                        Waehrung = Waehrungscode.EUR,
                        UserProperties = new Dictionary<string, object>
                        {
                            { "deepExtra", "value" },
                        },
                    },
                },
            },
        };
        var result = rechnung.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();
        paths.Should().HaveCount(1);
        paths.Should().Contain("Rechnungspositionen[0].TeilsummeNetto");
    }

    #endregion

    #region HasAllEmptyUserPropertiesRecursive - Mixed Scenarios

    [TestMethod]
    public void TestRecursive_MixedScenario_SomeEmptySomeNot()
    {
        var marktlokation = new Marktlokation
        {
            MarktlokationsId = "51238696781",
            Sparte = Sparte.STROM,
            Lokationsadresse = new Adresse
            {
                Postleitzahl = "12345",
                Ort = "Berlin",
                // Empty UserProperties
            },
            Geoadresse = new Geokoordinaten
            {
                Breitengrad = 52.52m,
                Laengengrad = 13.405m,
                UserProperties = new Dictionary<string, object> { { "precision", "high" } },
            },
        };
        var result = marktlokation.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();
        paths.Should().HaveCount(1);
        paths.Should().Contain("Geoadresse");
    }

    #endregion

    #region HasAllEmptyUserPropertiesRecursive - JSON Deserialization Tests

    [TestMethod]
    public void TestRecursive_NewtonsoftDeserialized_WithExtensionData_ReturnsFalse()
    {
        var json =
            @"{
            ""messlokationsId"": ""DE0123456789012345678901234567890"",
            ""sparte"": ""STROM"",
            ""unmappedField"": ""this goes to UserProperties""
        }";
        var melo = JsonConvert.DeserializeObject<Messlokation>(json);

        melo.Should().NotBeNull();
        melo.HasEmptyUserProperties().Should().BeFalse();
        melo.UserProperties.Should().ContainKey("unmappedField");

        var result = melo.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();
        paths.Should().Contain("(root)");
    }

    [TestMethod]
    public void TestRecursive_NewtonsoftDeserialized_NoExtensionData_ReturnsTrue()
    {
        var json =
            @"{
            ""messlokationsId"": ""DE0123456789012345678901234567890"",
            ""sparte"": ""STROM""
        }";
        var melo = JsonConvert.DeserializeObject<Messlokation>(json);

        melo.Should().NotBeNull();
        melo.HasEmptyUserProperties().Should().BeTrue();

        var result = melo.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_SystemTextJsonDeserialized_WithExtensionData_ReturnsFalse()
    {
        var options = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
        var json =
            @"{
            ""messlokationsId"": ""DE0123456789012345678901234567890"",
            ""sparte"": ""STROM"",
            ""unmappedField"": ""this goes to UserProperties""
        }";
        var melo = JsonSerializer.Deserialize<Messlokation>(json, options);

        melo.Should().NotBeNull();
        melo.HasEmptyUserProperties().Should().BeFalse();

        var result = melo.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();
        paths.Should().Contain("(root)");
    }

    [TestMethod]
    public void TestRecursive_SystemTextJsonDeserialized_NoExtensionData_ReturnsTrue()
    {
        var options = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
        var json =
            @"{
            ""messlokationsId"": ""DE0123456789012345678901234567890"",
            ""sparte"": ""STROM""
        }";
        var melo = JsonSerializer.Deserialize<Messlokation>(json, options);

        melo.Should().NotBeNull();
        melo.HasEmptyUserProperties().Should().BeTrue();

        var result = melo.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_NewtonsoftDeserialized_NestedWithExtensionData_ReturnsFalse()
    {
        var json =
            @"{
            ""lokationsId"": ""DE0123456789012345678901234567890"",
            ""lokationsTyp"": ""MELO"",
            ""energieverbrauch"": [
                {
                    ""einheit"": ""KWH"",
                    ""wert"": 100,
                    ""unmappedInVerbrauch"": ""extra data""
                }
            ]
        }";
        var energiemenge = JsonConvert.DeserializeObject<Energiemenge>(json);

        energiemenge.Should().NotBeNull();
        energiemenge.HasEmptyUserProperties().Should().BeTrue();
        energiemenge.Energieverbrauch.Should().HaveCount(1);
        energiemenge.Energieverbrauch[0].HasEmptyUserProperties().Should().BeFalse();

        var result = energiemenge.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();
        paths.Should().HaveCount(1);
        paths.Should().Contain("Energieverbrauch[0]");
    }

    #endregion

    #region Thread Safety Tests

    [TestMethod]
    public void TestRecursive_ConcurrentAccess_DoesNotThrow()
    {
        // Test that concurrent access to the cache doesn't cause issues
        var tasks = Enumerable
            .Range(0, 100)
            .Select(_ =>
                Task.Run(() =>
                {
                    var energiemenge = new Energiemenge
                    {
                        LokationsId = "DE0123456789012345678901234567890",
                        LokationsTyp = Lokationstyp.MELO,
                        Energieverbrauch = new List<Verbrauch>
                        {
                            new Verbrauch { Einheit = Mengeneinheit.KWH, Wert = 100 },
                        },
                    };

                    for (var i = 0; i < 100; i++)
                    {
                        energiemenge.HasAllEmptyUserPropertiesRecursive(out var unusedPaths);
                        energiemenge.HasEmptyUserProperties();
                    }
                })
            )
            .ToArray();

        var act = () => Task.WaitAll(tasks);
        act.Should().NotThrow();
    }

    #endregion

    #region Edge Cases

    [TestMethod]
    public void TestRecursive_ListWithNullItems_HandlesGracefully()
    {
        var energiemenge = new Energiemenge
        {
            LokationsId = "DE0123456789012345678901234567890",
            LokationsTyp = Lokationstyp.MELO,
            Energieverbrauch = new List<Verbrauch>
            {
                new Verbrauch { Einheit = Mengeneinheit.KWH, Wert = 100 },
                null, // null item in list
                new Verbrauch { Einheit = Mengeneinheit.KWH, Wert = 300 },
            },
        };

        var act = () => energiemenge.HasAllEmptyUserPropertiesRecursive(out _);
        act.Should().NotThrow();

        var result = energiemenge.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_EmptyUserPropertiesDictionary_IsConsideredEmpty()
    {
        var melo = new Messlokation
        {
            MesslokationsId = "DE0123456789012345678901234567890",
            Sparte = Sparte.STROM,
            UserProperties = new Dictionary<string, object>(), // explicitly empty, not null
        };

        melo.HasEmptyUserProperties().Should().BeTrue();

        var result = melo.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_PathFormat_IsCorrect()
    {
        var rechnung = new Rechnung
        {
            Rechnungsnummer = "R-2024-001",
            UserProperties = new Dictionary<string, object> { { "rootKey", "rootValue" } },
            Rechnungspositionen = new List<Rechnungsposition>
            {
                new Rechnungsposition
                {
                    Positionsnummer = 1,
                    LieferungVon = System.DateTimeOffset.Now,
                    LieferungBis = System.DateTimeOffset.Now.AddDays(30),
                    UserProperties = new Dictionary<string, object> { { "posKey", "posValue" } },
                    TeilsummeNetto = new Betrag
                    {
                        Wert = 100,
                        Waehrung = Waehrungscode.EUR,
                        UserProperties = new Dictionary<string, object>
                        {
                            { "betragKey", "betragValue" },
                        },
                    },
                },
            },
        };

        var result = rechnung.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();

        paths.Should().Contain("(root)");
        paths.Should().Contain("Rechnungspositionen[0]");
        paths.Should().Contain("Rechnungspositionen[0].TeilsummeNetto");
    }

    [TestMethod]
    public void TestRecursive_COM_Standalone_Works()
    {
        var adresse = new Adresse
        {
            Postleitzahl = "12345",
            Ort = "Berlin",
            UserProperties = new Dictionary<string, object> { { "extra", "data" } },
        };

        adresse.HasEmptyUserProperties().Should().BeFalse();

        var result = adresse.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();
        paths.Should().HaveCount(1);
        paths.Should().Contain("(root)");
    }

    #endregion

    #region Real-World BO4E Scenarios

    [TestMethod]
    public void TestRecursive_RealWorldEnergiemenge_AllMapped_ReturnsTrue()
    {
        var energiemenge = new Energiemenge
        {
            LokationsId = "DE0001234567890123456789012345678901",
            LokationsTyp = Lokationstyp.MALO,
            Energieverbrauch = new List<Verbrauch>
            {
                new Verbrauch
                {
                    Startdatum = System.DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                    Enddatum = System.DateTimeOffset.Parse("2024-01-01T00:15:00Z"),
                    Einheit = Mengeneinheit.KWH,
                    Wert = 1.5m,
                    Obiskennzahl = "1-1:1.8.0",
                    Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG,
                },
                new Verbrauch
                {
                    Startdatum = System.DateTimeOffset.Parse("2024-01-01T00:15:00Z"),
                    Enddatum = System.DateTimeOffset.Parse("2024-01-01T00:30:00Z"),
                    Einheit = Mengeneinheit.KWH,
                    Wert = 1.7m,
                    Obiskennzahl = "1-1:1.8.0",
                    Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG,
                },
            },
        };

        var result = energiemenge.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_RealWorldZaehler_WithGeraet_AllMapped_ReturnsTrue()
    {
        var zaehler = new Zaehler
        {
            Zaehlernummer = "1234567890",
            Sparte = Sparte.STROM,
            Zaehlerauspraegung = Zaehlerauspraegung.EINRICHTUNGSZAEHLER,
            Zaehlwerke = new List<Zaehlwerk>
            {
                new Zaehlwerk
                {
                    ZaehlwerkId = "ZW1",
                    ObisKennzahl = "1-1:1.8.0",
                    Einheit = Mengeneinheit.KWH,
                    Richtung = Energierichtung.EINSP,
                },
            },
        };

        var result = zaehler.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    #endregion

    #region Circular Reference Protection Tests

    /// <summary>
    ///     Test model with a self-reference to verify circular reference protection.
    /// </summary>
    private class SelfReferencingModel : BO4E.COM.COM
    {
        public SelfReferencingModel? Self { get; set; }
        public SelfReferencingModel? Other { get; set; }
    }

    [TestMethod]
    public void TestRecursive_CircularReference_SelfReference_DoesNotStackOverflow()
    {
        var model = new SelfReferencingModel();
        model.Self = model; // circular self-reference

        var act = () => model.HasAllEmptyUserPropertiesRecursive(out _);
        act.Should().NotThrow();

        var result = model.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_CircularReference_WithNonEmptyUserProperties_ReportsCorrectly()
    {
        var model = new SelfReferencingModel
        {
            UserProperties = new Dictionary<string, object> { { "key", "value" } },
        };
        model.Self = model; // circular self-reference

        var result = model.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();
        paths.Should().HaveCount(1);
        paths.Should().Contain("(root)");
        // Should NOT contain "Self" because the visited set prevents re-checking the same object
    }

    [TestMethod]
    public void TestRecursive_CircularReference_ParentChildBackReference_DoesNotStackOverflow()
    {
        var parent = new SelfReferencingModel();
        var child = new SelfReferencingModel();
        parent.Self = child;
        child.Other = parent; // back-reference to parent creates a cycle

        var act = () => parent.HasAllEmptyUserPropertiesRecursive(out _);
        act.Should().NotThrow();

        var result = parent.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeTrue();
        paths.Should().BeEmpty();
    }

    [TestMethod]
    public void TestRecursive_CircularReference_ChainWithNonEmptyInMiddle_ReportsAllNonEmpty()
    {
        var a = new SelfReferencingModel();
        var b = new SelfReferencingModel
        {
            UserProperties = new Dictionary<string, object> { { "middle", "data" } },
        };
        var c = new SelfReferencingModel();

        a.Self = b;
        b.Self = c;
        c.Other = a; // cycle back to start

        var result = a.HasAllEmptyUserPropertiesRecursive(out var paths);
        result.Should().BeFalse();
        paths.Should().HaveCount(1);
        paths.Should().Contain("Self"); // b is at path "Self" from a
    }

    #endregion
}
