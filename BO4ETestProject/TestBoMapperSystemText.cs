using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta.LenientConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E;

[TestClass]
public class TestBoMapperSystemText
{
    [TestMethod]
    public void TestMesslokation()
    {
        var jsonInput = GetInputNodeAsJson("BoMapperTests/messlokation_userProps.json");
        var melo = JsonSerializer.Deserialize<Messlokation>(
            jsonInput,
            LenientParsing.MOST_LENIENT.GetJsonSerializerOptions()
        );
        Assert.IsNotNull(melo);
        Assert.AreEqual(true, melo.Abrechnungmessstellenbetriebnna);
    }

    [TestMethod]
    public void TestMarktlokation()
    {
        var jsonInput = GetInputNodeAsJson("BoMapperTests/marktlokation_simple.json");
        var malo = JsonSerializer.Deserialize<Marktlokation>(
            jsonInput,
            LenientParsing.MOST_LENIENT.GetJsonSerializerOptions()
        );
        Assert.IsNotNull(malo);
        Assert.AreEqual(Gebiettyp.VERTEILNETZ, malo.GebietTyp);
    }

    [TestMethod]
    public void TestZählerHerstellerKontaktweg()
    {
        using var r = new StreamReader("testjsons/zähler.json");
        var jsonString = r.ReadToEnd();
        var zaehler = JsonSerializer.Deserialize<Zaehler>(
            jsonString,
            LenientParsing.MOST_LENIENT.GetJsonSerializerOptions()
        );
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
            taskList.Add(
                Task.Run(() =>
                {
                    JsonSerializer.Serialize<Vertrag>(v, serializeOptions);
                })
            );
        }
        await Task.WhenAll(taskList);
    }

    [TestMethod]
    public void TestNullableDateTimeDeserialization()
    {
        var a = JsonSerializer.Deserialize<Aufgabe>(
            "{\"ccat\":\"ZE01\",\"casenr\":\"470272\",\"objtype\":\"ZISUPROFIL\",\"aufgabenId\":\"REIMPORT\",\"ausgefuehrt\":\"false\",\"ausfuehrender\":\"\",\"ausfuehrungszeitpunkt\":\"0000-00-00T00:00:00Z\"}",
            LenientParsing.DATE_TIME.GetJsonSerializerOptions()
        );
        Assert.IsNotNull(a);
        Assert.IsFalse(a.Ausfuehrungszeitpunkt.HasValue);

        var b = JsonSerializer.Deserialize<Aufgabe>(
            "{\"ccat\":\"ZE01\",\"casenr\":\"470272\",\"objtype\":\"ZISUPROFIL\",\"aufgabenId\":\"REIMPORT\",\"ausgefuehrt\":\"false\",\"ausfuehrender\":\"\",\"ausfuehrungszeitpunkt\":\"2019-07-10T11:52:59Z\"}",
            LenientParsing.DATE_TIME.GetJsonSerializerOptions()
        );
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
                {
                    eventOccured = new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                }
                else
                {
                    eventOccured = value;
                }
            }
        }
    }
}
