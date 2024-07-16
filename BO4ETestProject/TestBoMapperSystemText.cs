using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

using BO4E;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta.LenientConverters;

using Microsoft.VisualStudio.TestTools.UnitTesting; //using BO4E.Extensions;

namespace TestBO4E;

[TestClass]
public class TestBoMapperSystemText
{
    [TestMethod]
    [Obsolete]
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
            catch (Exception)
            {
                bo = JsonSerializer.Deserialize(json.RootElement.GetProperty("input").GetRawText(),
                    BoMapper.GetTypeForBoName(json.RootElement.GetProperty("objectName").GetString()),
                    LenientParsing.MOST_LENIENT.GetJsonSerializerOptions()) as BusinessObject;
            }

            var regularOutputString = JsonSerializer.Serialize(bo, bo.GetType());
            if (bo.GetType() == typeof(Rechnung)) continue; // todo: fix this!
               /*if (json["input"]["boTyp"] != null)

                

                    /BusinessObject bo2 = BoMapper.MapObject((JObject)json["input"], lenients);

                    usinessObject bo2 = JsonConvert.DeserializeObject<BusinessObject>(json["input"].ToString(), BoMapper.GetJsonSerializerSettings(lenients));

                    /string regularOutputString2 = JsonConvert.SerializeObject(bo2, new StringEnumConverter());

                    ssert.AreEqual(bo, bo2);

                    witch (json["input"]["boTyp"].ToString().ToLower())

                    

                        ase "energiemenge":

                            /Assert.AreEqual((Energiemenge)bo, BoMapper.MapObject<Energiemenge>((JObject)json["input"], lenients));

                            ssert.AreEqual((Energiemenge)bo, JsonConvert.DeserializeObject<Energiemenge>(json["input"].ToString(), BoMapper.GetJsonSerializerSettings(lenients)));

                            reak;

                        ase "messlokation":

                            /Assert.AreEqual((Messlokation)bo, BoMapper.MapObject<Messlokation>((JObject)json["input"], lenients));

                            ssert.AreEqual((Messlokation)bo, JsonConvert.DeserializeObject<Messlokation>(json["input"].ToString(), BoMapper.GetJsonSerializerSettings(lenients)));

                            reak;

                            / add more if you feel like

                    

                *//
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
    public void TestVertragStringToInt()
    {
        var jsonInput = GetInputNodeAsJson("BoMapperTests/Vertrag_lenient_String.json");
        var lenients = LenientParsing.MOST_LENIENT;
        var v = JsonSerializer.Deserialize<Vertrag>(jsonInput, lenients.GetJsonSerializerOptions());
        Assert.AreEqual(Vertragstatus.AKTIV, v.Vertragstatus);
        Assert.AreEqual(v.Vertragskonditionen.AnzahlAbschlaege, 12);
    }

    [TestMethod]
    public async Task TestVertragSerializerParallel()
    {
        var jsonInput = GetInputNodeAsJson("BoMapperTests/Vertrag_lenient_String.json");
        var lenients = LenientParsing.MOST_LENIENT;
        var serializeOptions = lenients.GetJsonSerializerOptions();
        serializeOptions.Converters.Add(new VertragsConverter());
        var v = JsonSerializer.Deserialize<Vertrag>(jsonInput, serializeOptions);
        Assert.AreEqual(Vertragstatus.AKTIV, v.Vertragstatus);
        Assert.AreEqual(v.Vertragskonditionen.AnzahlAbschlaege, 12);
        Vertrag.VertragsSerializerOptions = null;
        var taskList = new List<Task>();
        for (int i = 0; i < 10; i++)
        {
            taskList.Add(Task.Run(() =>
            {
                JsonSerializer.Serialize<Vertrag>(v, serializeOptions);
            }));
        }
        await Task.WhenAll(taskList);
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

            ool argumentExceptionThrown = false;

            ry

            

                oMapper.GetTypeForBoName("dei mudder ihr business object");

            

            atch (ArgumentException)

            

                rgumentExceptionThrown = true;

            

            ssert.IsTrue(argumentExceptionThrown, "invalid argument must result in a ArgumentException");

            //
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
