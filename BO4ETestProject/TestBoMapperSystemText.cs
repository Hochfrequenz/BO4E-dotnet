using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using BO4E;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//using BO4E.Extensions;

namespace TestBO4E
{
    [TestClass]
    public class TestBoMapperSystemText
    {
        [TestMethod]
        public void TestBoMapping()
        {
            var files = Directory.GetFiles("BoMapperTests/", "*.json");
            foreach (var file in files)
            {
                Trace.WriteLine($"testing file {file}");
                JsonDocument json;
                using (var r = new StreamReader(file))
                {
                    var jsonString = r.ReadToEnd();
                    json = JsonSerializer.Deserialize<JsonDocument>(jsonString);
                }

                Assert.IsNotNull(json.RootElement.GetProperty("objectName"),
                    $"You have to specify the object name in test file {file}");
                var lenients = LenientParsing.STRICT; // default
                if (json.RootElement.TryGetProperty("lenientDateTime", out var boolElement) && boolElement.GetBoolean())
                    lenients |= LenientParsing.DATE_TIME;

                if (json.RootElement.TryGetProperty("lenientEnumList", out var listElement) && listElement.GetBoolean())
                    lenients |= LenientParsing.ENUM_LIST;

                if (json.RootElement.TryGetProperty("lenientBo4eUri", out var urlElement) && urlElement.GetBoolean())
                    lenients |= LenientParsing.BO4_E_URI;

                if (json.RootElement.TryGetProperty("lenientStringToInt", out var intElement) &&
                    intElement.GetBoolean()) lenients |= LenientParsing.STRING_TO_INT;
                BusinessObject bo = null;
                try
                {
                    bo = JsonSerializer.Deserialize<BusinessObject>(json.RootElement.GetProperty("input").GetRawText(),
                        lenients.GetJsonSerializerOptions());
                }
                catch (Exception e)
                {
                    bo = JsonSerializer.Deserialize(json.RootElement.GetProperty("input").GetRawText(),
                        BoMapper.GetTypeForBoName(json.RootElement.GetProperty("objectName").GetString()),
                        lenients.GetJsonSerializerOptions()) as BusinessObject;
                }

                var regularOutputString = JsonSerializer.Serialize(bo, bo.GetType());
                if (bo.GetType() == typeof(Rechnung)) continue; // todo: fix this!
                /*if (json["input"]["boTyp"] != null)
                {
                    //BusinessObject bo2 = BoMapper.MapObject((JObject)json["input"], lenients);
                    BusinessObject bo2 = JsonConvert.DeserializeObject<BusinessObject>(json["input"].ToString(), BoMapper.GetJsonSerializerSettings(lenients));
                    //string regularOutputString2 = JsonConvert.SerializeObject(bo2, new StringEnumConverter());
                    Assert.AreEqual(bo, bo2);
                    switch (json["input"]["boTyp"].ToString().ToLower())
                    {
                        case "energiemenge":
                            //Assert.AreEqual((Energiemenge)bo, BoMapper.MapObject<Energiemenge>((JObject)json["input"], lenients));
                            Assert.AreEqual((Energiemenge)bo, JsonConvert.DeserializeObject<Energiemenge>(json["input"].ToString(), BoMapper.GetJsonSerializerSettings(lenients)));
                            break;
                        case "messlokation":
                            //Assert.AreEqual((Messlokation)bo, BoMapper.MapObject<Messlokation>((JObject)json["input"], lenients));
                            Assert.AreEqual((Messlokation)bo, JsonConvert.DeserializeObject<Messlokation>(json["input"].ToString(), BoMapper.GetJsonSerializerSettings(lenients)));
                            break;
                            // add more if you feel like
                    }
                }*/
                HashSet<string> whitelist;
                if (json.RootElement.TryGetProperty("userPropWhiteList", out var whiteList))
                    whitelist = new HashSet<string>(JsonSerializer.Deserialize<List<string>>(whiteList.GetRawText()));
                else
                    whitelist = new HashSet<string>();
                if (lenients == LenientParsing.STRICT)
                    foreach (LenientParsing lenient in Enum.GetValues(typeof(LenientParsing)))
                    {
                        // strict mappings must also work with lenient mapping
                        BusinessObject boLenient;
                        try
                        {
                            boLenient = JsonSerializer.Deserialize<BusinessObject>(
                                json.RootElement.GetProperty("input").GetRawText(), lenient.GetJsonSerializerOptions());
                        }
                        catch (Exception)
                        {
                            _ = JsonSerializer.Deserialize(json.RootElement.GetProperty("input").GetRawText(),
                                BoMapper.GetTypeForBoName(json.RootElement.GetProperty("objectName").GetString()),
                                lenients.GetJsonSerializerOptions()) as BusinessObject;
                        }

                        //string dateLenietOutputString = JsonConvert.SerializeObject(boLenient, new StringEnumConverter());
                        //if (whitelist.Count ==0) {
                        //Assert.AreEqual(regularOutputString, dateLenietOutputString);
                        //}
                        //else
                        // {
                        //    Assert.AreEqual(regularOutputString, dateLenietOutputString);
                        //}
                    }
            }
        }

        [TestMethod]
        public void TestVertragQuickFix()
        {
            var jsonInput = GetInputNodeAsJson("BoMapperTests/vertragLokationsIdUp.json");
            var vertrag =
                JsonSerializer.Deserialize<Vertrag>(jsonInput, LenientParsing.MOST_LENIENT.GetJsonSerializerOptions());
            Assert.IsNotNull(vertrag);
            Assert.IsNotNull(vertrag.Vertragsteile);
            Assert.AreEqual("DE54321", vertrag.Vertragsteile.First().Lokation);
        }

        [TestMethod]
        public void TestMesslokation()
        {
            var jsonInput = GetInputNodeAsJson("BoMapperTests/messlokation_userProps.json");
            var melo = JsonSerializer.Deserialize<Messlokation>(jsonInput,
                LenientParsing.MOST_LENIENT.GetJsonSerializerOptions());
            Assert.IsNotNull(melo);
            Assert.AreEqual(true, melo.Abrechnungmessstellenbetriebnna);
        }

        [TestMethod]
        public void TestMarktlokation()
        {
            var jsonInput = GetInputNodeAsJson("BoMapperTests/marktlokation_simple.json");
            var malo = JsonSerializer.Deserialize<Marktlokation>(jsonInput,
                LenientParsing.MOST_LENIENT.GetJsonSerializerOptions());
            Assert.IsNotNull(malo);
            Assert.AreEqual(Gebiettyp.VERTEILNETZ, malo.GebietTyp);
        }

        [TestMethod]
        public void TestVertragNullableDateTimeOffset()
        {
            var jsonInput = GetInputNodeAsJson("BoMapperTests/vertrag.json");
            var v = JsonSerializer.Deserialize<Vertrag>(jsonInput,
                LenientParsing.MOST_LENIENT.GetJsonSerializerOptions());
            Assert.IsNotNull(v);
            Assert.IsNotNull(v.Vertragsteile);
        }

        [TestMethod]
        public void TestZählerHerstellerKontaktweg()
        {
            using var r = new StreamReader("testjsons/zähler.json");
            var jsonString = r.ReadToEnd();
            var zaehler =
                JsonSerializer.Deserialize<Zaehler>(jsonString, LenientParsing.MOST_LENIENT.GetJsonSerializerOptions());
            Assert.IsNotNull(zaehler);
            Assert.IsNotNull(zaehler.Zaehlerhersteller);
        }

        [TestMethod]
        public void TestConversionFromMinSystemTextJson()
        {
            var options = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
            var json = "{\"EventOccured\": \"0001-01-01T00:00:00\"}"; // does contain a min value
            var myEvent = JsonSerializer.Deserialize<TestDateTime>(json, options);
            DateTimeOffset _ = myEvent.EventOccured;
        }

        [TestMethod]
        public void TestSummerTimeBug()
        {
            var jsonInput = GetInputNodeAsJson("BoMapperTests/energiemenge_sommerzeit_bug.json");
            var em = JsonSerializer.Deserialize<Energiemenge>(jsonInput,
                LenientParsing.MOST_LENIENT.GetJsonSerializerOptions());
            if (TimeZoneInfo.Local == CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo)
                Assert.AreEqual(2, em.Energieverbrauch.Count); // weil 2 verschiedene status
        }

        [TestMethod]
        public void TestVertragStringToInt()
        {
            var jsonInput = GetInputNodeAsJson("BoMapperTests/Vertrag_lenient_String.json");
            var lenients = LenientParsing.STRING_TO_INT;
            var v = JsonSerializer.Deserialize<Vertrag>(jsonInput, lenients.GetJsonSerializerOptions());
            Assert.AreEqual(Vertragstatus.AKTIV, v.Vertragstatus);
            Assert.AreEqual(v.Vertragskonditionen.AnzahlAbschlaege, 12);
        }

        [TestMethod]
        public void TestProfDecimalsVerbrauchBug()
        {
            var jsonInput = GetInputNodeAsJson("BoMapperTests/energiemenge_profdecimal_verbrauch_bug.json");
            var em = JsonSerializer.Deserialize<Energiemenge>(jsonInput,
                LenientParsing.MOST_LENIENT.GetJsonSerializerOptions());
            Assert.IsNotNull(em);
            Assert.AreEqual(4, em.Energieverbrauch.Count);
            Assert.AreEqual(59.0M, em.Energieverbrauch[0].Wert);
            Assert.AreEqual(58.0M, em.Energieverbrauch[1].Wert);
            Assert.AreEqual(57.0M, em.Energieverbrauch[2].Wert);
            Assert.AreEqual(57.123M, em.Energieverbrauch[3].Wert);
        }

        [TestMethod]
        public void TestProfDecimalsEnergiemengeBug()
        {
            var jsonInput = GetInputNodeAsJson("BoMapperTests/energiemenge_profdecimal_em_bug.json");
            var em = JsonSerializer.Deserialize<Energiemenge>(jsonInput,
                LenientParsing.MOST_LENIENT.GetJsonSerializerOptions());
            Assert.IsNotNull(em);
            Assert.AreEqual(1.375000M, em.Energieverbrauch.First().Wert);
            Assert.AreEqual(1.2130000M, em.Energieverbrauch.Last().Wert);
        }

        [TestMethod]
        public void TestSapTimeZoneUserProperties()
        {
            var v1 = JsonSerializer.Deserialize<Verbrauch>(
                "{\"startdatum\":\"2019-03-30T02:45:00\",\"enddatum\":\"2019-03-30T03:15:00\",\"wertermittlungsverfahren\":1,\"obiskennzahl\":\"1-0:1.29.0\",\"wert\":0.0,\"einheit\":1,\"zw\":\"000000000030000301\",\"Status\":\"IU015\",\"sap_timezone\":\"CET\"}",
                LenientParsing.DATE_TIME.GetJsonSerializerOptions());
            Assert.AreEqual(DateTimeKind.Utc, v1.Startdatum.Kind);
            Assert.AreEqual(DateTimeKind.Utc, v1.Enddatum.Kind);
            Assert.AreEqual(2.75, v1.Startdatum.TimeOfDay.TotalHours);
            Assert.AreEqual(3.25, v1.Enddatum.TimeOfDay.TotalHours);

            var v2 = JsonSerializer.Deserialize<Verbrauch>(
                "{\"startdatum\":\"2019-03-30T02:45:00\",\"enddatum\":\"2019-03-30T03:15:00\",\"wertermittlungsverfahren\":1,\"obiskennzahl\":\"1-0:1.29.0\",\"wert\":0.0,\"einheit\":1,\"zw\":\"000000000030000301\",\"Status\":\"IU015\",\"sap_timezone\":\"UTC\"}",
                LenientParsing.DATE_TIME.GetJsonSerializerOptions());
            Assert.AreEqual(DateTimeKind.Utc, v2.Startdatum.Kind);
            Assert.AreEqual(DateTimeKind.Utc, v2.Enddatum.Kind);
            Assert.AreEqual(2.75, v2.Startdatum.TimeOfDay.TotalHours);
            Assert.AreEqual(3.25, v2.Enddatum.TimeOfDay.TotalHours);

            var v3 = JsonSerializer.Deserialize<Verbrauch>(
                "{\"startdatum\":\"2019-10-27T02:30:00\",\"enddatum\":\"2019-10-27T02:45:00\",\"wertermittlungsverfahren\":1,\"obiskennzahl\":\"1-0:1.29.0\",\"wert\":0.0,\"einheit\":1,\"zw\":\"000000000030000301\",\"Status\":\"IU015\",\"sap_timezone\":\"CEST\"}",
                LenientParsing.DATE_TIME.GetJsonSerializerOptions());
            Assert.AreEqual(DateTimeKind.Utc, v3.Startdatum.Kind);
            Assert.AreEqual(DateTimeKind.Utc, v3.Enddatum.Kind);
            Assert.AreEqual(2.5, v3.Startdatum.TimeOfDay.TotalHours);
            Assert.AreEqual(2.75, v3.Enddatum.TimeOfDay.TotalHours);

            var v4 = JsonSerializer.Deserialize<Verbrauch>(
                "{\"startdatum\":\"2019-10-27T02:45:00\",\"enddatum\":\"2019-10-27T03:15:00\",\"wertermittlungsverfahren\":1,\"obiskennzahl\":\"1-0:1.29.0\",\"wert\":0.0,\"einheit\":1,\"zw\":\"000000000030000301\",\"Status\":\"IU015\",\"sap_timezone\":\"CEST\"}",
                LenientParsing.DATE_TIME.GetJsonSerializerOptions());
            Assert.AreEqual(DateTimeKind.Utc, v4.Startdatum.Kind);
            Assert.AreEqual(DateTimeKind.Utc, v4.Enddatum.Kind);
            Assert.AreEqual(2.75, v4.Startdatum.TimeOfDay.TotalHours);
            Assert.AreEqual(3.25, v4.Enddatum.TimeOfDay.TotalHours);
        }

        [TestMethod]
        public void TestSommerzeitumstellung()
        {
            // endzeitpunkt wird im sap aus startzeitpunkt + 1 std zusammengesetzt. bei umstellung auf sommerzeit entsteht als artefakt ein shift
            var v1 = JsonSerializer.Deserialize<Verbrauch>(
                "{\"zw\":\"000000000020720475\",\"startdatum\":\"201903310100\",\"enddatum\":\"201903310300\",\"wert\":263,\"status\":\"IU021\",\"obiskennzahl\":\"7-10:99.33.17\",\"wertermittlungsverfahren\":\"MESSUNG\",\"einheit\":\"KWH\",\"sap_timezone\":\"CET\"}",
                LenientParsing.DATE_TIME.GetJsonSerializerOptions());
            Assert.AreEqual(new DateTimeOffset(2019, 3, 31, 2, 0, 0, TimeSpan.Zero), v1.Enddatum);

            // negativ test: nur in der sommerzeit soll das nicht passieren
            var v2 = JsonSerializer.Deserialize<Verbrauch>(
                "{\"zw\":\"000000000020720475\",\"startdatum\":\"201905310100\",\"enddatum\":\"201905310300\",\"wert\":263,\"status\":\"IU021\",\"obiskennzahl\":\"7-10:99.33.17\",\"wertermittlungsverfahren\":\"MESSUNG\",\"einheit\":\"KWH\",\"sap_timezone\":\"CET\"}",
                LenientParsing.DATE_TIME.GetJsonSerializerOptions());
            Assert.AreEqual(new DateTimeOffset(2019, 5, 31, 3, 0, 0, TimeSpan.Zero), v2.Enddatum);

            // negativ test: nur in der winterzeit soll das nicht passieren
            var v3 = JsonSerializer.Deserialize<Verbrauch>(
                "{\"zw\":\"000000000020720475\",\"startdatum\":\"201901310100\",\"enddatum\":\"201901310300\",\"wert\":263,\"status\":\"IU021\",\"obiskennzahl\":\"7-10:99.33.17\",\"wertermittlungsverfahren\":\"MESSUNG\",\"einheit\":\"KWH\",\"sap_timezone\":\"CET\"}",
                LenientParsing.DATE_TIME.GetJsonSerializerOptions());
            Assert.AreEqual(new DateTimeOffset(2019, 1, 31, 3, 0, 0, TimeSpan.Zero), v3.Enddatum);
        }

        [TestMethod]
        public void TestBoNameTyping()
        {
            Assert.AreEqual(typeof(Benachrichtigung), BoMapper.GetTypeForBoName("Benachrichtigung"));
            Assert.AreEqual(typeof(Benachrichtigung), BoMapper.GetTypeForBoName("bEnAcHriCHTIGuNg"));

            Assert.ThrowsException<ArgumentNullException>(() => BoMapper.GetTypeForBoName(null),
                "null as argument must result in a ArgumentNullException");
            /*
            bool argumentExceptionThrown = false;
            try
            {
                BoMapper.GetTypeForBoName("dei mudder ihr business object");
            }
            catch (ArgumentException)
            {
                argumentExceptionThrown = true;
            }
            Assert.IsTrue(argumentExceptionThrown, "invalid argument must result in a ArgumentException");
            */
            Assert.IsNull(BoMapper.GetTypeForBoName("dei mudder ihr business object"),
                "invalid business object names must result in null");
        }

        [TestMethod]
        public void TestNullableDateTimeDeserialization()
        {
            var a = JsonSerializer.Deserialize<Aufgabe>(
                "{\"ccat\":\"ZE01\",\"casenr\":\"470272\",\"objtype\":\"ZISUPROFIL\",\"aufgabenId\":\"REIMPORT\",\"ausgefuehrt\":\"false\",\"ausfuehrender\":\"\",\"ausfuehrungszeitpunkt\":\"0000-00-00T00:00:00Z\"}",
                LenientParsing.DATE_TIME.GetJsonSerializerOptions());
            Assert.IsNotNull(a);
            Assert.IsFalse(a.Ausfuehrungszeitpunkt.HasValue);

            var b = JsonSerializer.Deserialize<Aufgabe>(
                "{\"ccat\":\"ZE01\",\"casenr\":\"470272\",\"objtype\":\"ZISUPROFIL\",\"aufgabenId\":\"REIMPORT\",\"ausgefuehrt\":\"false\",\"ausfuehrender\":\"\",\"ausfuehrungszeitpunkt\":\"2019-07-10T11:52:59Z\"}",
                LenientParsing.DATE_TIME.GetJsonSerializerOptions());
            Assert.IsNotNull(b);
            Assert.IsTrue(b.Ausfuehrungszeitpunkt.HasValue);
        }


        /// <summary>
        ///     Parses the file at <paramref name="filepath" /> as json object, extracts the "input" node.
        /// </summary>
        /// <remarks>Somehow the test had been setup this way.</remarks>
        /// <returns></returns>
        private static string GetInputNodeAsJson(string filepath)
        {
            JsonDocument json;
            using (var r = new StreamReader(filepath))
            {
                var jsonString = r.ReadToEnd();
                json = JsonDocument.Parse(jsonString);
            }

            var result = json.RootElement.GetProperty("input").GetRawText();
            return result;
        }

        protected class TestDateTime
        {
            private DateTime eventOccured;

            /// <summary>
            ///     DateTime on which the event occured
            /// </summary>
            public DateTime EventOccured
            {
                get => eventOccured;
                set
                {
                    if (value == DateTime.MinValue)
                        eventOccured = new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    else
                        eventOccured = value;
                }
            }
        }
    }
}