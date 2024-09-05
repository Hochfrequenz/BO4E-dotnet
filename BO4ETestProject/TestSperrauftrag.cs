using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E;

/// <summary>
/// This is a class to create MWE (Ent)sperraufträge
/// </summary>
[TestClass]
public class TestSperrauftrag
{
    private readonly JsonSerializerOptions _options =
        new() { Converters = { new JsonStringEnumConverter() }, IgnoreNullValues = true };

    [TestMethod]
    public void TestSperrauftragSerializationMaximal()
    {
        var sperrauftrag = new Sperrauftrag
        {
            Ausfuehrungsdatum = new DateTimeOffset(2022, 1, 5, 1, 1, 1, TimeSpan.Zero),
            Bemerkungen = new List<string>
            {
                "Der Typ erwartet uns mit Baseballschläger am Zähler",
            },
            Sparte = Sparte.STROM,
            Zaehlernummer = "1YSE29183123",
            Lieferanschrift = new Adresse
            {
                Strasse = "Rathausgasse",
                Hausnummer = "8",
                Landescode = Landescode.DE,
                Postleitzahl = "04109",
                Ort = "Leipzig",
            },
            MarktlokationsId = "54321012345",
            IstVomGerichtsvollzieherAngeordnet = true,
            ExterneReferenzen = new List<ExterneReferenz>
            {
                new()
                {
                    ExRefName =
                        "Blocking service internal ID, you can choose any key here that you recognize",
                    ExRefWert = Guid.NewGuid().ToString(),
                },
            },
            Sperrauftragsstatus = Auftragsstatus.ZUGESTIMMT,
            Mindestpreis = new Preis
            {
                Bezugswert = Mengeneinheit.ANZAHL,
                Einheit = Waehrungseinheit.EUR,
                Status = Preisstatus.VORLAEUFIG,
                Wert = 10.00M,
            },
            Hoechstpreis = new Preis
            {
                Bezugswert = Mengeneinheit.ANZAHL,
                Einheit = Waehrungseinheit.EUR,
                Status = Preisstatus.VORLAEUFIG,
                Wert = 20.00M,
            },
        };
        sperrauftrag.IsValid().Should().BeTrue();
        var sperrauftragJson = JsonSerializer.Serialize(sperrauftrag, _options);
        sperrauftragJson.Should().NotBe(null);
    }

    [TestMethod]
    public void TestSperrauftragSerializationMinimal()
    {
        var sperrauftrag = new Sperrauftrag
        {
            Ausfuehrungsdatum = new DateTimeOffset(2022, 1, 5, 1, 1, 1, TimeSpan.Zero),
            Lieferanschrift = new Adresse
            {
                Strasse = "Rathausgasse",
                Hausnummer = "8",
                Landescode = Landescode.DE,
                Postleitzahl = "04109",
                Ort = "Leipzig",
            },
            MarktlokationsId = "54321012345",
            IstVomGerichtsvollzieherAngeordnet = true,
        };
        sperrauftrag.IsValid().Should().BeTrue();
        var sperrauftragJson = JsonSerializer.Serialize(sperrauftrag, _options);
        sperrauftragJson.Should().NotBe(null);
    }

    [TestMethod]
    public void TestEntsperrauftragMaximal()
    {
        var entsperrauftrag = new Entsperrauftrag
        {
            Ausfuehrungsdatum = new DateTimeOffset(2022, 6, 15, 1, 1, 1, TimeSpan.Zero),
            Bemerkungen = new List<string> { "Der Typ erwartet uns mit Blumenstrauß am Eingang" },
            Lieferanschrift = new Adresse
            {
                Strasse = "Rathausgasse",
                Hausnummer = "8",
                Landescode = Landescode.DE,
                Postleitzahl = "04109",
                Ort = "Leipzig",
            },
            MarktlokationsId = "54321012345",
            Zaehlernummer = "1Yasdasdasd",
            IstNurInnerhalbDerArbeitszeitZuEntsperren = true,
            ExterneReferenzen = new List<ExterneReferenz>
            {
                new()
                {
                    ExRefName = "Blocking service internal ID",
                    ExRefWert = Guid.NewGuid().ToString(),
                },
            },
        };
        entsperrauftrag.IsValid().Should().BeTrue();
        var entsperrauftragJson = JsonSerializer.Serialize(entsperrauftrag, _options);
        entsperrauftragJson.Should().NotBe(null);
    }
}
