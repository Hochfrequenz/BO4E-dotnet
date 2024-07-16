using System;
using System.Collections.Generic;
using BO4E.BO;
using BO4E.COM;
using BO4E.Extensions.BusinessObjects.Benachrichtigung;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4E.Extensions;

[TestClass]
public class TestBenachrichtigungExtension
{
    [TestMethod]
    public void TestHas()
    {
        var b = new Benachrichtigung
        {
            BenachrichtigungsId = "1234",
            Bearbeiter = "dei mudder",
            Infos = new List<GenericStringStringInfo>
            {
                new GenericStringStringInfo {KeyColumn = "ads", Value = "xyz"},
                new GenericStringStringInfo {KeyColumn = "null", Value = null}
            }
        };

        Assert.IsTrue(b.Has("ads", "xyz"));
        Assert.IsFalse(b.Has("null", "not-null"));
        Assert.IsTrue(b.Has("null", null));
        Assert.IsFalse(b.Has("someothervalue", null));
        Assert.IsFalse(b.Has("someothervalue"));
        Assert.IsTrue(b.Has("ads"));
        Assert.IsTrue(b.Has("null"));
        Assert.IsFalse(b.Has((string)null));

        Assert.IsFalse(new Benachrichtigung().Has("abc"));
    }

    [TestMethod]
    public void TestMoveInfo2UP()
    {
        var b = JsonConvert.DeserializeObject<Benachrichtigung>(
            "{\"versionStruktur\":1,\"boTyp\":\"BENACHRICHTIGUNG\",\"benachrichtigungsId\":\"468985\",\"prioritaet\":2,\"bearbeitungsstatus\":0,\"kurztext\":\"Manuelles Überschreiben von Profilwerten\",\"erstellungsZeitpunkt\":\"2019-04-01T14:27:23Z\",\"kategorie\":\"ZE01\",\"bearbeiter\":\"\",\"notizen\":null,\"deadline\":null,\"aufgaben\":null,\"infos\":null,\"aufgaben\":[{\"ccat\":\"ZE01\",\"objtype\":\"ZISUPROFIL\",\"aufgabenId\":\"OVERWRITE\",\"ausgefuehrt\":\"true\"},{\"ccat\":\"ZE01\",\"objtype\":\"ZISUPROFIL\",\"aufgabenId\":\"DISPLAY\",\"ausgefuehrt\":\"true\"}],\"infos\":[{\"keyColumn\":\"MESSLOKATIONSID\",\"value\":\"DE000360478090000000\",\"boolean_true_column\":false},{\"keyColumn\":\"TIMESPAN_FROM\",\"value\":\"2019-02-25T23:00:00Z\",\"boolean_true_column\":false},{\"keyColumn\":\"TIMESPAN_TO\",\"value\":\"2019-03-19T22:44:59Z\",\"boolean_true_column\":false}],\"notizen\":[]}");
        Assert.IsTrue(b.Has("MESSLOKATIONSID"));
        Assert.IsTrue(b.UserProperties == null || b.UserProperties.Count == 0);
        b.MoveInfosToUserProperties();
        Assert.IsNotNull(b.UserProperties);
        Assert.IsTrue(b.UserProperties.ContainsKey("MESSLOKATIONSID"));
        Assert.IsNull(b.Infos);
    }

    [TestMethod]
    public void TestHasWithMesslokationsId()
    {
        var b = JsonConvert.DeserializeObject<Benachrichtigung>(
            "{\"versionStruktur\":1,\"boTyp\":\"BENACHRICHTIGUNG\",\"benachrichtigungsId\":\"483052\",\"prioritaet\":2,\"bearbeitungsstatus\":2,\"kurztext\":\"Manuelles Überschreiben von Profilwerten\",\"erstellungsZeitpunkt\":\"2019-05-22T12:14:32Z\",\"kategorie\":\"ZE01\",\"bearbeiter\":\"SCHLEBDA\",\"notizen\":[],\"deadline\":null,\"aufgaben\":[{\"aufgabenId\":\"OVERWRITE\",\"beschreibung\":null,\"deadline\":null,\"ausgefuehrt\":true,\"ausfuehrungszeitpunkt\":\"2019-05-22T12:18:50Z\",\"ausfuehrender\":\"SCHLEBDA\",\"ccat\":\"ZE01\",\"casenr\":\"483052\",\"objtype\":\"ZISUPROFIL\"},{\"aufgabenId\":\"DISPLAY\",\"beschreibung\":null,\"deadline\":null,\"ausgefuehrt\":false,\"ausfuehrungszeitpunkt\":null,\"ausfuehrender\":\"\",\"ccat\":\"ZE01\",\"casenr\":\"483052\",\"objtype\":\"ZISUPROFIL\"},{\"aufgabenId\":\"REIMPORT\",\"beschreibung\":null,\"deadline\":null,\"ausgefuehrt\":false,\"ausfuehrungszeitpunkt\":null,\"ausfuehrender\":\"\",\"ccat\":\"ZE01\",\"casenr\":\"483052\",\"objtype\":\"ZISUPROFIL\"},{\"aufgabenId\":\"EXTERN_IGNORE\",\"beschreibung\":null,\"deadline\":null,\"ausgefuehrt\":false,\"ausfuehrungszeitpunkt\":null,\"ausfuehrender\":\"\",\"ccat\":\"ZE01\",\"casenr\":\"483052\",\"objtype\":\"ZISUPROFIL\"}],\"infos\":[{\"keyColumn\":\"MESS\",\"value\":\"9905048000007\",\"boolean_true_column\":false},{\"keyColumn\":\"MESSLOKATIONSID\",\"value\":\"DE0003604780400000000000010000176\",\"boolean_true_column\":false},{\"keyColumn\":\"TIMESPAN_FROM\",\"value\":\"2019-04-16T22:00:00Z\",\"boolean_true_column\":false},{\"keyColumn\":\"TIMESPAN_TO\",\"value\":\"2019-04-17T21:59:59Z\",\"boolean_true_column\":false}],\"casenr\":\"483052\"}");
        Assert.IsTrue(b.Has("MESSLOKATIONSID")); // funktioniert wahrscheinlich
        Assert.IsTrue(b.Has("MESSLOKATIONSID", "DE0003604780400000000000010000176"));
    }

    [TestMethod]
    public void TestDateTimePredicates()
    {
        var b = JsonConvert.DeserializeObject<Benachrichtigung>(
            "{\"versionStruktur\":1,\"boTyp\":\"BENACHRICHTIGUNG\",\"benachrichtigungsId\":\"469568\",\"prioritaet\":2,\"bearbeitungsstatus\":1,\"kurztext\":\"Manuelles \u00dcberschreiben von Profilwerten\",\"erstellungsZeitpunkt\":\"2019-04-02T13:35:03Z\",\"kategorie\":\"ZE01\",\"bearbeiter\":\"SCHLEBDA\",\"notizen\":[],\"deadline\":null,\"aufgaben\":[{\"aufgabenId\":\"OVERWRITE\",\"beschreibung\":null,\"deadline\":null,\"ausgefuehrt\":true,\"ausfuehrungsdatum\":null,\"ausfuehrender\":null,\"ccat\":\"ZE01\",\"objtype\":\"ZISUPROFIL\"},{\"aufgabenId\":\"DISPLAY\",\"beschreibung\":null,\"deadline\":null,\"ausgefuehrt\":true,\"ausfuehrungsdatum\":null,\"ausfuehrender\":null,\"ccat\":\"ZE01\",\"objtype\":\"ZISUPROFIL\"}],\"infos\":null,\"MESS\":\"9977768000005\",\"MESSLOKATIONSID\":\"DE0003604763800000000000010376811\",\"TIMESPAN_FROM\":\"2019-03-11T23:30:00Z\",\"TIMESPAN_TO\":\"2019-03-12T22:59:59Z\"}");
        Assert.IsTrue(b.UserProperties.TryGetValue("TIMESPAN_FROM", out var jtLower));
        _ = (DateTime)jtLower;
        Assert.IsTrue(b.UserProperties.TryGetValue("TIMESPAN_TO", out var jtUpper));
        _ = (DateTime)jtUpper;
    }
}
