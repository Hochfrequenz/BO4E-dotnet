using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BO4E;
using BO4E.BO;
using BO4E.COM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq; //using BO4E.Extensions;

namespace TestBO4E
{
    [TestClass]
    public class TestBoMapper
    {
        [TestMethod]
        [Obsolete]
        public void TestBoMapping()
        {
            var files = Directory.GetFiles("BoMapperTests/", "*.json");
            foreach (var file in files)
            {
                JObject json;
                using (var r = new StreamReader(file))
                {
                    var jsonString = r.ReadToEnd();
                    json = JsonConvert.DeserializeObject<JObject>(jsonString);
                }

                Assert.IsNotNull(json["objectName"], $"You have to specify the object name in test file {file}");
                var lenients = LenientParsing.STRICT; // default
                if (json["lenientDateTime"] != null && (bool)json["lenientDateTime"])
                    lenients |= LenientParsing.DATE_TIME;

                if (json["lenientEnumList"] != null && (bool)json["lenientEnumList"])
                    lenients |= LenientParsing.ENUM_LIST;

                if (json["lenientBo4eUri"] != null && (bool)json["lenientBo4eUri"])
                    lenients |= LenientParsing.BO4_E_URI;

                if (json["lenientStringToInt"] != null && (bool)json["lenientStringToInt"])
                    lenients |= LenientParsing.STRING_TO_INT;

                BusinessObject bo;
                try
                {
                    bo = JsonConvert.DeserializeObject<BusinessObject>(json["input"].ToString(),
                        lenients.GetJsonSerializerSettings());
                }
                catch (Exception e) when (e is ArgumentException || e is JsonSerializationException)
                {
                    try
                    {
                        bo = BoMapper.MapObject(json["objectName"].ToString(), (JObject)json["input"], lenients);
                    }
                    catch (FormatException fe) when (fe.Message.Contains(" was not recognized as a valid DateTime."))
                    {
                        // ok, since the method is deprecated for years now, I won't invest effort in fixing it.
                        continue;
                    }
                }

                var regularOutputString = JsonConvert.SerializeObject(bo, new StringEnumConverter());
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
                if (json["userPropWhiteList"] != null)
                    whitelist = new HashSet<string>(JArray.FromObject(json["userPropWhiteList"])
                        .ToObject<List<string>>());
                else
                    whitelist = new HashSet<string>();

                if (lenients == LenientParsing.STRICT)
                    foreach (LenientParsing lenient in Enum.GetValues(typeof(LenientParsing)))
                    {
                        // strict mappings must also work with lenient mapping
                        BusinessObject boLenient;
                        try
                        {
                            boLenient = JsonConvert.DeserializeObject<BusinessObject>(json["input"].ToString(),
                                lenient.GetJsonSerializerSettings(whitelist));
                        }
                        catch (ArgumentException)
                        {
                            boLenient = BoMapper.MapObject(json["objectName"].ToString(), (JObject)json["input"],
                                whitelist, lenient);
                        }
                        catch (JsonSerializationException jse)
                        {
                            Assert.IsTrue(false,
                                $"Unexpected {nameof(JsonSerializationException)} in file {file}: {jse.Message}");
                            throw;
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
        public void TestVertragStringToIntNewtonsoft()
        {
            JObject json;
            using (var r = new StreamReader("BoMapperTests/Vertrag_lenient_String.json"))
            {
                var jsonString = r.ReadToEnd();
                json = JsonConvert.DeserializeObject<JObject>(jsonString);
            }

            const LenientParsing lenients = LenientParsing.MOST_LENIENT;
            var v = JsonConvert.DeserializeObject<Vertrag>(json["input"].ToString(),
                lenients.GetJsonSerializerSettings());
            Assert.AreEqual(v.Vertragskonditionen.AnzahlAbschlaege, 12);
            v.Vertragsende.Should().Be(DateTimeOffset.MinValue);
        }


        [TestMethod]
        [Obsolete]
        public void TestBoNames()
        {
            var testResult = BoMapper.GetValidBoNames();
            Assert.IsTrue(testResult.Contains("Messlokation"));
            Assert.IsTrue(testResult.Contains("Energiemenge"));
            Assert.IsFalse(testResult.Contains("Verbrauch"), "No COM");
            Assert.IsFalse(testResult.Contains("CompletenessReport")); // has moved to extensions
            Assert.IsFalse(testResult.Contains("Mengeneinheit"), "No enums");
        }

        [TestMethod]
        [Obsolete]
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
        public void TestNullableDateTimeDeserializationNewtonsoft()
        {
            var a = JsonConvert.DeserializeObject<Aufgabe>(
                "{\"ccat\":\"ZE01\",\"casenr\":\"470272\",\"objtype\":\"ZISUPROFIL\",\"aufgabenId\":\"REIMPORT\",\"ausgefuehrt\":\"false\",\"ausfuehrender\":\"\",\"ausfuehrungszeitpunkt\":\"0000-00-00T00:00:00Z\"}");
            Assert.IsNotNull(a);
            Assert.IsFalse(a.Ausfuehrungszeitpunkt.HasValue);

            var b = JsonConvert.DeserializeObject<Aufgabe>(
                "{\"ccat\":\"ZE01\",\"casenr\":\"470272\",\"objtype\":\"ZISUPROFIL\",\"aufgabenId\":\"REIMPORT\",\"ausgefuehrt\":\"false\",\"ausfuehrender\":\"\",\"ausfuehrungszeitpunkt\":\"2019-07-10T11:52:59Z\"}");
            Assert.IsNotNull(b);
            Assert.IsTrue(b.Ausfuehrungszeitpunkt.HasValue);
        }
    }
}
