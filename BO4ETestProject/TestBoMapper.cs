using BO4E;
using BO4E.BO;
using BO4E.COM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
//using BO4E.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestBO4E
{
    [TestClass]
    public class TestBoMapper
    {
        [TestMethod]
        public void TestBoMapping()
        {
            string[] files = Directory.GetFiles($"BoMapperTests/", "*.json");
            foreach (string file in files)
            {
                JObject json;
                using (StreamReader r = new StreamReader(file))
                {
                    string jsonString = r.ReadToEnd();
                    json = JsonConvert.DeserializeObject<JObject>(jsonString);
                }
                Assert.IsNotNull(json["objectName"], $"You have to specify the object name in test file {file}");
                LenientParsing lenients = LenientParsing.Strict; // default
                if (json["lenientDateTime"] != null && (bool)json["lenientDateTime"])
                {
                    lenients |= LenientParsing.DateTime;
                }

                if (json["lenientEnumList"] != null && (bool)json["lenientEnumList"])
                {
                    lenients |= LenientParsing.EnumList;
                }

                if (json["lenientBo4eUri"] != null && (bool)json["lenientBo4eUri"])
                {
                    lenients |= LenientParsing.Bo4eUri;
                }

                if (json["lenientStringToInt"] != null && (bool)json["lenientStringToInt"])
                {
                    lenients |= LenientParsing.StringToInt;
                }
                BusinessObject bo;
                try
                {
                    bo = JsonConvert.DeserializeObject<BusinessObject>(json["input"].ToString(), lenients.GetJsonSerializerSettings());
                }
                catch (Exception e) when (e is ArgumentException || e is JsonSerializationException)
                {
                    bo = BoMapper.MapObject(json["objectName"].ToString(), (JObject)json["input"], lenients);
                }
                string regularOutputString = JsonConvert.SerializeObject(bo, new StringEnumConverter());
                if (bo.GetType() == typeof(Rechnung))
                {
                    continue; // todo: fix this!
                }
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
                if (json["userPropWhiteList"] != null)
                {
                    whitelist = new HashSet<string>(JArray.FromObject(json["userPropWhiteList"]).ToObject<List<string>>());
                }
                else
                {
                    whitelist = new HashSet<string>();
                }
                if (lenients == LenientParsing.Strict)
                {
                    foreach (LenientParsing lenient in Enum.GetValues(typeof(LenientParsing)))
                    {
                        // strict mappings must also work with lenient mapping
                        BusinessObject boLenient;
                        try
                        {
                            boLenient = JsonConvert.DeserializeObject<BusinessObject>(json["input"].ToString(), lenient.GetJsonSerializerSettings(whitelist));
                        }
                        catch (ArgumentException)
                        {
                            boLenient = BoMapper.MapObject(json["objectName"].ToString(), (JObject)json["input"], whitelist, lenient);
                        }
                        catch (JsonSerializationException jse)
                        {
                            Assert.IsTrue(false, $"Unexpected {nameof(JsonSerializationException)} in file {file}: {jse.Message}");
                            throw jse;
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
                else
                {
                    // non-strict test cases are designed such that they are not parseble in strict mode.
                    // bool exceptionThrown;
                    // try
                    //{
                    //    BusinessObject boStrict = BoMapper.MapObject(json["objectName"].ToString(), (JObject)json["input"], LenientParsing.Strict);
                    //    exceptionThrown = false;
                    //}
                    //catch (Exception)
                    //{
                    //    exceptionThrown = true;
                    // }
                    //Assert.IsTrue(exceptionThrown);
                }
            }
        }

        [TestMethod]
        public void TestVertragQuickFix()
        {
            JObject json;
            using (StreamReader r = new StreamReader("BoMapperTests/vertragLokationsIdUp.json"))
            {
                string jsonString = r.ReadToEnd();
                json = JsonConvert.DeserializeObject<JObject>(jsonString);
            }
            var v = JsonConvert.DeserializeObject<Vertrag>(json["input"].ToString(), LenientParsing.MOST_LENIENT.GetJsonSerializerSettings());
            Assert.IsNotNull(v.Vertragsteile);
            Assert.AreEqual("DE54321", v.Vertragsteile.First().Lokation);
        }

        [TestMethod]
        public void TestSummerTimeBug()
        {
            // first test serialization of complete business object
            JObject json;
            using (StreamReader r = new StreamReader("BoMapperTests/energiemenge_sommerzeit_bug.json"))
            {
                string jsonString = r.ReadToEnd();
                json = JsonConvert.DeserializeObject<JObject>(jsonString);
            }
            Energiemenge em = JsonConvert.DeserializeObject<Energiemenge>(json["input"].ToString(), LenientParsing.MOST_LENIENT.GetJsonSerializerSettings());
            if (TimeZoneInfo.Local == CentralEuropeStandardTime.CENTRAL_EUROPE_STANDARD_TIME)
            {
                Assert.AreEqual(2, em.Energieverbrauch.Count); // weil 2 verschiedene status
            }
        }

        [TestMethod]
        public void TestVertragStringToInt()
        {
            // first test serialization of complete business object
            JObject json;
            using (StreamReader r = new StreamReader("BoMapperTests/Vertrag_lenient_String.json"))
            {
                string jsonString = r.ReadToEnd();
                json = JsonConvert.DeserializeObject<JObject>(jsonString);
            }
            LenientParsing lenients = LenientParsing.StringToInt;
            Vertrag v = JsonConvert.DeserializeObject<Vertrag>(json["input"].ToString(), lenients.GetJsonSerializerSettings());
            Assert.AreEqual(v.Vertragskonditionen.AnzahlAbschlaege, 12);
        }

        [TestMethod]
        public void TestProfDecimalsVerbrauchBug()
        {
            // first test serialization of complete business object
            JObject json;
            using (StreamReader r = new StreamReader("BoMapperTests/energiemenge_profdecimal_verbrauch_bug.json"))
            {
                string jsonString = r.ReadToEnd();
                json = JsonConvert.DeserializeObject<JObject>(jsonString);
            }
            Energiemenge em = JsonConvert.DeserializeObject<Energiemenge>(json["input"].ToString(), LenientParsing.MOST_LENIENT.GetJsonSerializerSettings());
            Assert.AreEqual(4, em.Energieverbrauch.Count);
            Assert.AreEqual(59.0M, em.Energieverbrauch[0].Wert);
            Assert.AreEqual(58.0M, em.Energieverbrauch[1].Wert);
            Assert.AreEqual(57.0M, em.Energieverbrauch[2].Wert);
            Assert.AreEqual(57.123M, em.Energieverbrauch[3].Wert);
        }

        [TestMethod]
        public void TestProfDecimalsEnergiemengeBug()
        {
            // first test serialization of complete business object
            JObject json;
            using (StreamReader r = new StreamReader("BoMapperTests/energiemenge_profdecimal_em_bug.json"))
            {
                string jsonString = r.ReadToEnd();
                json = JsonConvert.DeserializeObject<JObject>(jsonString);
            }
            Energiemenge em = JsonConvert.DeserializeObject<Energiemenge>(json["input"].ToString(), LenientParsing.MOST_LENIENT.GetJsonSerializerSettings());
            Assert.AreEqual(1.375000M, em.Energieverbrauch.First().Wert);
            Assert.AreEqual(1.2130000M, em.Energieverbrauch.Last().Wert);
        }

        [TestMethod]
        public void TestSapTimeZoneUserProperties()
        {
            Verbrauch v1 = JsonConvert.DeserializeObject<Verbrauch>("{\"startdatum\":\"2019-03-30T02:45:00\",\"enddatum\":\"2019-03-30T03:15:00\",\"wertermittlungsverfahren\":1,\"obiskennzahl\":\"1-0:1.29.0\",\"wert\":0.0,\"einheit\":1,\"zw\":\"000000000030000301\",\"Status\":\"IU015\",\"sap_timezone\":\"CET\"}");
            Assert.AreEqual(DateTimeKind.Utc, v1.Startdatum.Kind);
            Assert.AreEqual(DateTimeKind.Utc, v1.Enddatum.Kind);
            Assert.AreEqual(2.75, v1.Startdatum.TimeOfDay.TotalHours);
            Assert.AreEqual(3.25, v1.Enddatum.TimeOfDay.TotalHours);

            Verbrauch v2 = JsonConvert.DeserializeObject<Verbrauch>("{\"startdatum\":\"2019-03-30T02:45:00\",\"enddatum\":\"2019-03-30T03:15:00\",\"wertermittlungsverfahren\":1,\"obiskennzahl\":\"1-0:1.29.0\",\"wert\":0.0,\"einheit\":1,\"zw\":\"000000000030000301\",\"Status\":\"IU015\",\"sap_timezone\":\"UTC\"}");
            Assert.AreEqual(DateTimeKind.Utc, v2.Startdatum.Kind);
            Assert.AreEqual(DateTimeKind.Utc, v2.Enddatum.Kind);
            Assert.AreEqual(2.75, v2.Startdatum.TimeOfDay.TotalHours);
            Assert.AreEqual(3.25, v2.Enddatum.TimeOfDay.TotalHours);

            Verbrauch v3 = JsonConvert.DeserializeObject<Verbrauch>("{\"startdatum\":\"2019-10-27T02:30:00\",\"enddatum\":\"2019-10-27T02:45:00\",\"wertermittlungsverfahren\":1,\"obiskennzahl\":\"1-0:1.29.0\",\"wert\":0.0,\"einheit\":1,\"zw\":\"000000000030000301\",\"Status\":\"IU015\",\"sap_timezone\":\"CEST\"}");
            Assert.AreEqual(DateTimeKind.Utc, v3.Startdatum.Kind);
            Assert.AreEqual(DateTimeKind.Utc, v3.Enddatum.Kind);
            Assert.AreEqual(2.5, v3.Startdatum.TimeOfDay.TotalHours);
            Assert.AreEqual(2.75, v3.Enddatum.TimeOfDay.TotalHours);

            Verbrauch v4 = JsonConvert.DeserializeObject<Verbrauch>("{\"startdatum\":\"2019-10-27T02:45:00\",\"enddatum\":\"2019-10-27T03:15:00\",\"wertermittlungsverfahren\":1,\"obiskennzahl\":\"1-0:1.29.0\",\"wert\":0.0,\"einheit\":1,\"zw\":\"000000000030000301\",\"Status\":\"IU015\",\"sap_timezone\":\"CEST\"}");
            Assert.AreEqual(DateTimeKind.Utc, v4.Startdatum.Kind);
            Assert.AreEqual(DateTimeKind.Utc, v4.Enddatum.Kind);
            Assert.AreEqual(2.75, v4.Startdatum.TimeOfDay.TotalHours);
            Assert.AreEqual(3.25, v4.Enddatum.TimeOfDay.TotalHours);
        }

        [TestMethod]
        public void TestSommerzeitumstellung()
        {
            // endzeitpunkt wird im sap aus startzeitpunkt + 1 std zusammengesetzt. bei umstellung auf sommerzeit entsteht als artefakt ein shift
            Verbrauch v1 = JsonConvert.DeserializeObject<Verbrauch>("{\"zw\":\"000000000020720475\",\"startdatum\":\"201903310100\",\"enddatum\":\"201903310300\",\"wert\":263,\"status\":\"IU021\",\"obiskennzahl\":\"7-10:99.33.17\",\"wertermittlungsverfahren\":\"MESSUNG\",\"einheit\":\"KWH\",\"sap_timezone\":\"CET\"}",
                new LenientDateTimeConverter());
            Assert.AreEqual(new DateTimeOffset(2019, 3, 31, 2, 0, 0, TimeSpan.Zero), v1.Enddatum);

            // negativ test: nur in der sommerzeit soll das nicht passieren
            Verbrauch v2 = JsonConvert.DeserializeObject<Verbrauch>("{\"zw\":\"000000000020720475\",\"startdatum\":\"201905310100\",\"enddatum\":\"201905310300\",\"wert\":263,\"status\":\"IU021\",\"obiskennzahl\":\"7-10:99.33.17\",\"wertermittlungsverfahren\":\"MESSUNG\",\"einheit\":\"KWH\",\"sap_timezone\":\"CET\"}",
                new LenientDateTimeConverter());
            Assert.AreEqual(new DateTimeOffset(2019, 5, 31, 3, 0, 0, TimeSpan.Zero), v2.Enddatum);

            // negativ test: nur in der winterzeit soll das nicht passieren
            Verbrauch v3 = JsonConvert.DeserializeObject<Verbrauch>("{\"zw\":\"000000000020720475\",\"startdatum\":\"201901310100\",\"enddatum\":\"201901310300\",\"wert\":263,\"status\":\"IU021\",\"obiskennzahl\":\"7-10:99.33.17\",\"wertermittlungsverfahren\":\"MESSUNG\",\"einheit\":\"KWH\",\"sap_timezone\":\"CET\"}",
                new LenientDateTimeConverter());
            Assert.AreEqual(new DateTimeOffset(2019, 1, 31, 3, 0, 0, TimeSpan.Zero), v3.Enddatum);
        }


        [TestMethod]
        public void TestBoNames()
        {
            HashSet<string> testResult = BoMapper.GetValidBoNames();
            Assert.IsTrue(testResult.Contains("Messlokation"));
            Assert.IsTrue(testResult.Contains("Energiemenge"));
            Assert.IsFalse(testResult.Contains("Verbrauch"), "No COM");
            Assert.IsFalse(testResult.Contains("CompletenessReport")); // has moved to extensions
            Assert.IsFalse(testResult.Contains("Mengeneinheit"), "No enums");
        }

        [TestMethod]
        public void TestBoNameTyping()
        {
            Assert.AreEqual(typeof(Benachrichtigung), BoMapper.GetTypeForBoName("Benachrichtigung"));
            Assert.AreEqual(typeof(Benachrichtigung), BoMapper.GetTypeForBoName("bEnAcHriCHTIGuNg"));

            Assert.ThrowsException<ArgumentNullException>(() => BoMapper.GetTypeForBoName(null), "null as argument must result in a ArgumentNullException");
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
            Assert.IsNull(BoMapper.GetTypeForBoName("dei mudder ihr business object"), "invalid business object names must result in null");
        }

        /* // has moved to extensions
        [TestMethod]
        public void TestJsonSchemeGeneration()
        {
            Assert.IsNotNull(BoMapper.GetJsonSchemeFor("Messlokation"));
            Assert.IsNull(BoMapper.GetJsonSchemeFor("Schwurbeldings"));
            Newtonsoft.Json.Schema.JSchema crScheme = BoMapper.GetJsonSchemeFor("CompletenessReport");
            Assert.IsTrue(crScheme.ToString().Count() > 100);
        }
        */

        [TestMethod]
        public void TestNullableDateTimeDeserialization()
        {
            Aufgabe a = JsonConvert.DeserializeObject<Aufgabe>("{\"ccat\":\"ZE01\",\"casenr\":\"470272\",\"objtype\":\"ZISUPROFIL\",\"aufgabenId\":\"REIMPORT\",\"ausgefuehrt\":\"false\",\"ausfuehrender\":\"\",\"ausfuehrungszeitpunkt\":\"0000-00-00T00:00:00Z\"}");
            Assert.IsNotNull(a);
            Assert.IsFalse(a.Ausfuehrungszeitpunkt.HasValue);

            Aufgabe b = JsonConvert.DeserializeObject<Aufgabe>("{\"ccat\":\"ZE01\",\"casenr\":\"470272\",\"objtype\":\"ZISUPROFIL\",\"aufgabenId\":\"REIMPORT\",\"ausgefuehrt\":\"false\",\"ausfuehrender\":\"\",\"ausfuehrungszeitpunkt\":\"2019-07-10T11:52:59Z\"}");
            Assert.IsNotNull(b);
            Assert.IsTrue(b.Ausfuehrungszeitpunkt.HasValue);
        }
    }
}
