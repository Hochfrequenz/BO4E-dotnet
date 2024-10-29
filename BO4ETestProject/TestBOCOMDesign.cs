using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BO4E.BO;
using BO4E.COM;
using BO4E.meta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4E;

[TestClass]
public class TestBOCOMDesign
{
    private static readonly HashSet<Type> NO_KEYS_WHITELIST =
        new() { typeof(Kosten), typeof(Wechsel) };

    [TestMethod]
    public void TestNoBOFields()
    {
        foreach (
            var type in typeof(BusinessObject)
                .Assembly.GetTypes()
                .Where(t => typeof(BusinessObject).IsAssignableFrom(t))
        )
        {
            var fields = type.GetFields().Where(f => f.IsPublic && !f.IsLiteral && !f.IsStatic);
            Assert.IsFalse(
                fields.Any(),
                $"Type {type} must not contain fields but has: {string.Join(", ", fields.ToList())}"
            );
        }
    }

    [TestMethod]
    public void TestBoAllPublic()
    {
        foreach (
            var type in typeof(BusinessObject)
                .Assembly.GetTypes()
                .Where(t => t.BaseType == typeof(BusinessObject))
        )
            Assert.IsTrue(
                type.IsPublic,
                $"Type {type} is derived from {nameof(BusinessObject)} but is not public."
            );
    }

    private static void AssertConsistentIgnores(Type type)
    {
        if (type.IsEnum)
        {
            // todo: write a test here
        }
        else
        {
            var newtonSoftIgnoredProperties = type.GetProperties(
                    BindingFlags.NonPublic | BindingFlags.Instance
                )
                .Where(p =>
                    p.GetCustomAttributes(typeof(Newtonsoft.Json.JsonIgnoreAttribute)).Any()
                )
                .ToHashSet();
            var systemTextIgnoreProperties = type.GetProperties(
                    BindingFlags.NonPublic | BindingFlags.Instance
                )
                .Where(p =>
                    p.GetCustomAttributes(
                            typeof(System.Text.Json.Serialization.JsonIgnoreAttribute)
                        )
                        .Any()
                )
                .ToHashSet();
            Assert.AreEqual(
                newtonSoftIgnoredProperties.Count,
                systemTextIgnoreProperties.Count,
                $"Type {type} has inconsistent JsonIgnores"
            );
            // todo: name the properties in a useful error message

            var newtonSoftIgnoredFields = type.GetFields(
                    BindingFlags.NonPublic | BindingFlags.Instance
                )
                .Where(p =>
                    p.GetCustomAttributes(typeof(Newtonsoft.Json.JsonIgnoreAttribute)).Any()
                )
                .ToHashSet();
            var systemTextIgnoreFields = type.GetFields(
                    BindingFlags.NonPublic | BindingFlags.Instance
                )
                .Where(p =>
                    p.GetCustomAttributes(
                            typeof(System.Text.Json.Serialization.JsonIgnoreAttribute)
                        )
                        .Any()
                )
                .ToHashSet();
            Assert.AreEqual(
                newtonSoftIgnoredFields.Count,
                systemTextIgnoreFields.Count,
                $"Type {type} has inconsistent JsonIgnores"
            );
        }
    }

    [TestMethod]
    public void TestConsistentIgnoresBo()
    {
        foreach (
            var type in typeof(BusinessObject)
                .Assembly.GetTypes()
                .Where(t => t.BaseType == typeof(BusinessObject))
        )
        {
            AssertConsistentIgnores(type);
        }
    }

    [TestMethod]
    public void TestConsistentIgnoresCom()
    {
        foreach (var type in typeof(COM).Assembly.GetTypes().Where(t => t.BaseType == typeof(COM)))
        {
            AssertConsistentIgnores(type);
        }
    }

    [TestMethod]
    public void TestNoCOMFields()
    {
        foreach (
            var type in typeof(COM).Assembly.GetTypes().Where(t => typeof(COM).IsAssignableFrom(t))
        )
        {
            var fields = type.GetFields().Where(f => f.IsPublic && !f.IsStatic);
            Assert.IsFalse(
                fields.Any(),
                $"Type {type} must not contain public fields but has: {string.Join(", ", fields.ToList())}"
            );
        }
    }

    [TestMethod]
    public void TestCOMAllPublic()
    {
        foreach (
            var type in typeof(BusinessObject)
                .Assembly.GetTypes()
                .Where(t => t.BaseType == typeof(COM))
        )
            Assert.IsTrue(
                type.IsPublic,
                $"Type {type} is derived from {nameof(COM)} but is not public."
            );
    }

    [TestMethod]
    public void TestBoInheritance()
    {
        foreach (
            var type in typeof(BusinessObject)
                .Assembly.GetTypes()
                .Where(t =>
                    t.IsClass
                    && t.IsPublic
                    && t.Namespace == "BO4E.BO"
                    && !t.Name.EndsWith("Converter")
                )
        )
            Assert.IsTrue(
                type.IsSubclassOf(typeof(BusinessObject)) || type == typeof(BusinessObject),
                $"Type {type} does not inherit from {nameof(BusinessObject)}."
            );
    }

    [TestMethod]
    public void TestCOMInheritance()
    {
        foreach (
            var type in typeof(BusinessObject)
                .Assembly.GetTypes()
                .Where(t =>
                    t.IsClass
                    && t.IsPublic
                    && t.Namespace == "BO4E.COM"
                    && !t.Name.EndsWith("Converter")
                )
        )
            Assert.IsTrue(
                type.IsSubclassOf(typeof(COM)) || type == typeof(COM),
                $"Type {type} does not inherit from {nameof(COM)}."
            );
    }

    [TestMethod]
    public void TestEnumNamespace()
    {
        foreach (
            var type in typeof(BusinessObject)
                .Assembly.GetTypes()
                .Where(t => t.IsPublic && t.Namespace == "BO4E.ENUM")
        )
            Assert.IsTrue(
                type.IsEnum,
                $"Type {type} is in namespace BO4E.ENUM but no enum! Consinder moving the definition to another namespace or adding an internal / private modifier."
            );
    }

    [TestMethod]
    public void TestBoKeys()
    {
        foreach (
            var type in typeof(BusinessObject)
                .Assembly.GetTypes()
                .Where(t =>
                    t.BaseType == typeof(BusinessObject)
                    && !t.IsAbstract
                    && !NO_KEYS_WHITELIST.Contains(t)
                )
        )
        {
            var keyProps = type.GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(BoKey), false).Length > 0)
                .OrderBy(ap => ap.GetCustomAttribute<JsonPropertyAttribute>()?.Order)
                .ToArray();
            Assert.IsTrue(
                keyProps.Any(),
                $"Type {type} is derived from {nameof(BusinessObject)} but has no [{nameof(BoKey)}] attribute."
            );
        }
    }

    /// <summary>
    ///     There must be no fields in BusinessObjects or COMponents where you cannot distinguish no value (null) and initial
    ///     value (e.g. ENUM default values or integer 0)
    /// </summary>
    [TestMethod]
    public void NullableDefaultEnums()
    {
        // In the past, we thought that it's ok to have non-nullable enums (= enums, that default to a value other than null even if they're not explicitly set)
        // as long as they are only marked with a Newtonsoft JsonProperty Required.Always attribute.
        // This design was wrong but it is there now, at least for a handful of existing BOs and COMs.
        // In the future we don't want any more non-nullable enums.
        // But those who are there already are grandfathered in.
        var enumPropertiesThatAreHistoricallyNotNullable = new HashSet<string>
        {
            "BO4E.COM.Angebotsvariante->Angebotsstatus",
            "BO4E.COM.Aufgabe->Ausgefuehrt",
            "BO4E.COM.Ausschreibungsdetail->NetzebeneLieferung",
            "BO4E.COM.Ausschreibungsdetail->NetzebeneMessung",
            "BO4E.COM.Ausschreibungslos->Preismodell",
            "BO4E.COM.Ausschreibungslos->Energieart",
            "BO4E.COM.Ausschreibungslos->WunschRechnungslegung",
            "BO4E.COM.Ausschreibungslos->WunschVertragsform",
            "BO4E.COM.Ausschreibungslos->AnzahlLieferstellen",
            "BO4E.COM.Avisposition->IstStorno",
            "BO4E.COM.Betrag->Waehrung",
            "BO4E.COM.Dienstleistung->Dienstleistungstyp",
            "BO4E.COM.Energiemix->Energiemixnummer",
            "BO4E.COM.Energiemix->Energieart",
            "BO4E.COM.Energiemix->Gueltigkeitsjahr",
            "BO4E.COM.Geraeteeigenschaften->Geraetetyp",
            "BO4E.COM.Handelsunstimmigkeitsbegruendung->Grund",
            "BO4E.COM.Konzessionsabgabe->Satz",
            "BO4E.COM.KriteriumsWert->Kriterium",
            "BO4E.COM.PhysikalischerWert->Einheit",
            "BO4E.COM.PositionsAufAbschlag->AufAbschlagstyp",
            "BO4E.COM.PositionsAufAbschlag->AufAbschlagswaehrung",
            "BO4E.COM.Preisgarantie->Preisgarantietyp",
            "BO4E.COM.Preisposition->Berechnungsmethode",
            "BO4E.COM.Preisposition->Leistungstyp",
            "BO4E.COM.Preisposition->Preiseinheit",
            "BO4E.COM.Rechenschritt->RechenschrittBestandteilId",
            "BO4E.COM.Rechenschritt->ReferenzRechenschrittId",
            "BO4E.COM.Rechenschritt->Operation",
            "BO4E.COM.Rechnungsposition->Positionsnummer",
            "BO4E.COM.RechnungspositionFlat->Positionsnummer",
            "BO4E.COM.RegionaleGueltigkeit->Gueltigkeitstyp",
            "BO4E.COM.RegionaleTarifpreisposition->Preistyp",
            "BO4E.COM.RegionaleTarifpreisposition->Bezugseinheit",
            "BO4E.COM.Regionskriterium->Gueltigkeitstyp",
            "BO4E.COM.Regionskriterium->Mengenoperator",
            "BO4E.COM.Regionskriterium->Regionskriteriumtyp",
            "BO4E.COM.Rufnummer->Nummerntyp",
            "BO4E.COM.Steuerbetrag->Steuerkennzeichen",
            "BO4E.COM.Steuerbetrag->Waehrung",
            "BO4E.COM.Tarifpreisposition->Preistyp",
            "BO4E.COM.Tarifpreisposition->Einheit",
            "BO4E.COM.Tarifpreisposition->Bezugseinheit",
            "BO4E.COM.Verbrauch->Einheit",
            "BO4E.COM.Verwendungszweck->Marktrolle",
            "BO4E.BO.Anfrage->LokationsTyp",
            "BO4E.BO.Anfrage->Anfragekategorie",
            "BO4E.BO.Angebot->Sparte",
            "BO4E.BO.Benachrichtigung->Prioritaet",
            "BO4E.BO.Benachrichtigung->Bearbeitungsstatus",
            "BO4E.BO.Berechnungsformel->Notwendigkeit",
            "BO4E.BO.Geschaeftspartner->Gewerbekennzeichnung",
            "BO4E.BO.Handelsunstimmigkeit->Typ",
            "BO4E.BO.Kosten->Kostenklasse",
            "BO4E.BO.Marktlokation->Sparte",
            "BO4E.BO.Messlokation->Sparte",
            "BO4E.BO.Netzlokation->Sparte",
            "BO4E.BO.Produktpaket->PaketId",
            "BO4E.BO.Rechnung->Storno",
            "BO4E.BO.Rechnung->Rechnungsstyp",
            "BO4E.BO.Reklamation->LokationsTyp",
            "BO4E.BO.Reklamation->Reklamationsgrund",
            "BO4E.BO.Tranche->Sparte",
            "BO4E.BO.Vertrag->Sparte",
            "BO4E.BO.Wechsel->Sparte",
            "BO4E.BO.Zaehler->Sparte",
        };
        foreach (
            var boType in typeof(BusinessObject)
                .Assembly.GetTypes()
                .Where(t =>
                    (t.BaseType == typeof(BusinessObject) || t.BaseType == typeof(COM))
                    && !t.IsAbstract
                )
        )
        {
            foreach (
                var obligDefaultField in boType.GetProperties(
                    BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance
                )
            )
            {
                if (
                    Nullable.GetUnderlyingType(obligDefaultField.PropertyType) != null
                    || obligDefaultField.PropertyType == typeof(string)
                )
                {
                    // it is already nullable.
                    continue;
                }
                if (
                    !obligDefaultField.PropertyType.IsPrimitive
                    && !obligDefaultField.PropertyType.IsEnum
                )
                {
                    continue;
                }

                var isLegacyNonNullableEnum = enumPropertiesThatAreHistoricallyNotNullable.Contains(
                    $"{boType.FullName}->{obligDefaultField.Name}"
                );
                if (isLegacyNonNullableEnum)
                {
                    continue;
                }
                Assert.IsTrue(
                    false,
                    $"The type {obligDefaultField.PropertyType} of {boType.FullName}.{obligDefaultField.Name} is not nullable but should be"
                );
            }
        }
    }
}
