using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E
{
    /// <summary>
    /// This is a class to create MWE (Ent)sperraufträge
    /// </summary>
    [TestClass]
    public class TestSperrauftrag
    {
        private JsonSerializerOptions options = new()
        {
            Converters = { new JsonStringEnumConverter() }
        };
        [TestMethod]
        public void TestSperrauftragSerializationRoundTrip()
        {
            var sperrauftrag = new Sperrauftrag
            {
                Ausfuehrungsdatum = new DateTimeOffset(2022, 1, 5, 1, 1, 1, TimeSpan.Zero),
                Bemerkung = "Der Typ erwartet uns mit Baseballschläger am Zähler",
                Lieferanschrift = new Adresse
                {
                    Strasse = "Rathausgasse",
                    Hausnummer = "8",
                    Landescode = Landescode.DE,
                    Postleitzahl = "04109",
                    Ort = "Leipzig"
                },
                MarktlokationsId = "54321012345",
                IstVomGerichtsvollzieherAngeordnet = true,
                ExterneReferenzen = new List<ExterneReferenz>
                {
                    new()
                    {
                        ExRefName = "Blocking service internal ID",
                        ExRefWert = Guid.NewGuid().ToString(),
                    }
                }
            };

            var sperrauftragJson = System.Text.Json.JsonSerializer.Serialize(sperrauftrag, options);
            sperrauftragJson.Should().NotBe(null);
        }
        
    }
}