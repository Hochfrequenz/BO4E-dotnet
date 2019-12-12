using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BO4E;
using BO4E.BO;
using BO4E.COM;
//using BO4E.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using static BO4E.BoMapper;

namespace TestBO4E
{
    [TestClass]
    public class TestBoMapper
    {
        [TestMethod]
        public void TestFieldAnnotationFinder()
        {
            FieldInfo[] result = BoMapper.GetAnnotatedFields("Messlokation");
            Assert.IsTrue(result.Length > 0);
        }

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

                BusinessObject bo = BoMapper.MapObject(json["objectName"].ToString(), (JObject)json["input"], lenients);
                string regularOutputString = JsonConvert.SerializeObject(bo, new StringEnumConverter());
                if (bo.GetType() == typeof(Rechnung))
                {
                    continue; // todo: fix this!
                }
                if (json["input"]["boTyp"] != null)
                {
                    BusinessObject bo2 = BoMapper.MapObject((JObject)json["input"], lenients);
                    //string regularOutputString2 = JsonConvert.SerializeObject(bo2, new StringEnumConverter());
                    Assert.AreEqual(bo, bo2);
                    switch (json["input"]["boTyp"].ToString().ToLower())
                    {
                        case "energiemenge":
                            Assert.AreEqual((Energiemenge)bo, BoMapper.MapObject<Energiemenge>((JObject)json["input"], lenients));
                            break;
                        case "messlokation":
                            Assert.AreEqual((Messlokation)bo, BoMapper.MapObject<Messlokation>((JObject)json["input"], lenients));
                            break;
                            // add more if you feel like
                    }
                }
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
                        BusinessObject boLenient = BoMapper.MapObject(json["objectName"].ToString(), (JObject)json["input"], whitelist, lenient);
                        string dateLenietOutputString = JsonConvert.SerializeObject(boLenient, new StringEnumConverter());
                        //if (whitelist.Count ==0) {
                        Assert.AreEqual(regularOutputString, dateLenietOutputString);
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
            var v = BoMapper.MapObject<Vertrag>((JObject)json["input"], LenientParsing.MOST_LENIENT);
            Assert.IsNotNull(v.vertragsteile);
            Assert.AreEqual("DE54321", v.vertragsteile.First().lokation);
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
            Energiemenge em = BoMapper.MapObject<Energiemenge>((JObject)json["input"], LenientParsing.MOST_LENIENT);
            if (TimeZoneInfo.Local == Verbrauch.CENTRAL_EUROPE_STANDARD_TIME)
            {
                Assert.AreEqual(2, em.energieverbrauch.Count); // weil 2 verschiedene status
            }
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
            Energiemenge em = BoMapper.MapObject<Energiemenge>((JObject)json["input"], LenientParsing.MOST_LENIENT);
            Assert.AreEqual(4, em.energieverbrauch.Count);
            Assert.AreEqual(59.0M, em.energieverbrauch[0].wert);
            Assert.AreEqual(58.0M, em.energieverbrauch[1].wert);
            Assert.AreEqual(57.0M, em.energieverbrauch[2].wert);
            Assert.AreEqual(57.123M, em.energieverbrauch[3].wert);
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
            Energiemenge em = BoMapper.MapObject<Energiemenge>((JObject)json["input"], LenientParsing.MOST_LENIENT);
            Assert.AreEqual(1.375000M, em.energieverbrauch.First().wert);
            Assert.AreEqual(1.2130000M, em.energieverbrauch.Last().wert);
        }

        [TestMethod]
        public void TestSapTimeZoneUserProperties()
        {
            Verbrauch v1 = JsonConvert.DeserializeObject<Verbrauch>("{\"startdatum\":\"2019-03-30T02:45:00\",\"enddatum\":\"2019-03-30T03:15:00\",\"wertermittlungsverfahren\":1,\"obiskennzahl\":\"1-0:1.29.0\",\"wert\":0.0,\"einheit\":1,\"zw\":\"000000000030000301\",\"Status\":\"IU015\",\"sap_timezone\":\"CET\"}");
            Assert.AreEqual(DateTimeKind.Utc, v1.startdatum.Kind);
            Assert.AreEqual(DateTimeKind.Utc, v1.enddatum.Kind);
            Assert.AreEqual(2.75, v1.startdatum.TimeOfDay.TotalHours);
            Assert.AreEqual(3.25, v1.enddatum.TimeOfDay.TotalHours);

            Verbrauch v2 = JsonConvert.DeserializeObject<Verbrauch>("{\"startdatum\":\"2019-03-30T02:45:00\",\"enddatum\":\"2019-03-30T03:15:00\",\"wertermittlungsverfahren\":1,\"obiskennzahl\":\"1-0:1.29.0\",\"wert\":0.0,\"einheit\":1,\"zw\":\"000000000030000301\",\"Status\":\"IU015\",\"sap_timezone\":\"UTC\"}");
            Assert.AreEqual(DateTimeKind.Utc, v2.startdatum.Kind);
            Assert.AreEqual(DateTimeKind.Utc, v2.enddatum.Kind);
            Assert.AreEqual(2.75, v2.startdatum.TimeOfDay.TotalHours);
            Assert.AreEqual(3.25, v2.enddatum.TimeOfDay.TotalHours);

            Verbrauch v3 = JsonConvert.DeserializeObject<Verbrauch>("{\"startdatum\":\"2019-10-27T02:30:00\",\"enddatum\":\"2019-10-27T02:45:00\",\"wertermittlungsverfahren\":1,\"obiskennzahl\":\"1-0:1.29.0\",\"wert\":0.0,\"einheit\":1,\"zw\":\"000000000030000301\",\"Status\":\"IU015\",\"sap_timezone\":\"CEST\"}");
            Assert.AreEqual(DateTimeKind.Utc, v3.startdatum.Kind);
            Assert.AreEqual(DateTimeKind.Utc, v3.enddatum.Kind);
            Assert.AreEqual(2.5, v3.startdatum.TimeOfDay.TotalHours);
            Assert.AreEqual(2.75, v3.enddatum.TimeOfDay.TotalHours);

            Verbrauch v4 = JsonConvert.DeserializeObject<Verbrauch>("{\"startdatum\":\"2019-10-27T02:45:00\",\"enddatum\":\"2019-10-27T03:15:00\",\"wertermittlungsverfahren\":1,\"obiskennzahl\":\"1-0:1.29.0\",\"wert\":0.0,\"einheit\":1,\"zw\":\"000000000030000301\",\"Status\":\"IU015\",\"sap_timezone\":\"CEST\"}");
            Assert.AreEqual(DateTimeKind.Utc, v4.startdatum.Kind);
            Assert.AreEqual(DateTimeKind.Utc, v4.enddatum.Kind);
            Assert.AreEqual(2.75, v4.startdatum.TimeOfDay.TotalHours);
            Assert.AreEqual(3.25, v4.enddatum.TimeOfDay.TotalHours);
        }

        [TestMethod]
        public void TestSommerzeitumstellung()
        {
            // endzeitpunkt wird im sap aus startzeitpunkt + 1 std zusammengesetzt. bei umstellung auf sommerzeit entsteht als artefakt ein shift
            Verbrauch v1 = JsonConvert.DeserializeObject<Verbrauch>("{\"zw\":\"000000000020720475\",\"startdatum\":\"201903310100\",\"enddatum\":\"201903310300\",\"wert\":263,\"status\":\"IU021\",\"obiskennzahl\":\"7-10:99.33.17\",\"wertermittlungsverfahren\":\"MESSUNG\",\"einheit\":\"KWH\",\"sap_timezone\":\"CET\"}",
                new LenientDateTimeConverter());
            Assert.AreEqual(new DateTime(2019, 3, 31, 2, 0, 0, DateTimeKind.Utc), v1.enddatum);

            // negativ test: nur in der sommerzeit soll das nicht passieren
            Verbrauch v2 = JsonConvert.DeserializeObject<Verbrauch>("{\"zw\":\"000000000020720475\",\"startdatum\":\"201905310100\",\"enddatum\":\"201905310300\",\"wert\":263,\"status\":\"IU021\",\"obiskennzahl\":\"7-10:99.33.17\",\"wertermittlungsverfahren\":\"MESSUNG\",\"einheit\":\"KWH\",\"sap_timezone\":\"CET\"}",
                new LenientDateTimeConverter());
            Assert.AreEqual(new DateTime(2019, 5, 31, 3, 0, 0, DateTimeKind.Utc), v2.enddatum);

            // negativ test: nur in der winterzeit soll das nicht passieren
            Verbrauch v3 = JsonConvert.DeserializeObject<Verbrauch>("{\"zw\":\"000000000020720475\",\"startdatum\":\"201901310100\",\"enddatum\":\"201901310300\",\"wert\":263,\"status\":\"IU021\",\"obiskennzahl\":\"7-10:99.33.17\",\"wertermittlungsverfahren\":\"MESSUNG\",\"einheit\":\"KWH\",\"sap_timezone\":\"CET\"}",
                new LenientDateTimeConverter());
            Assert.AreEqual(new DateTime(2019, 1, 31, 3, 0, 0, DateTimeKind.Utc), v3.enddatum);
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

            bool nullExceptionThrown = false;
            try
            {
                BoMapper.GetTypeForBoName(null);
            }
            catch (ArgumentNullException)
            {
                nullExceptionThrown = true;
            }
            Assert.IsTrue(nullExceptionThrown, "null as argument must result in a ArgumentNullException");

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
            Assert.IsFalse(a.ausfuehrungszeitpunkt.HasValue);

            Aufgabe b = JsonConvert.DeserializeObject<Aufgabe>("{\"ccat\":\"ZE01\",\"casenr\":\"470272\",\"objtype\":\"ZISUPROFIL\",\"aufgabenId\":\"REIMPORT\",\"ausgefuehrt\":\"false\",\"ausfuehrender\":\"\",\"ausfuehrungszeitpunkt\":\"2019-07-10T11:52:59Z\"}");
            Assert.IsNotNull(b);
            Assert.IsTrue(b.ausfuehrungszeitpunkt.HasValue);
        }
    }
}
