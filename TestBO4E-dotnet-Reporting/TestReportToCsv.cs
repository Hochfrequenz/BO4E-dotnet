using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using BO4E.Reporting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4E.Reporting
{
    [TestClass]
    public class TestReportToCsv
    {
        [TestMethod]
        public void TestCompletenessReportToCsv()
        {
            CompletenessReport cr = new CompletenessReport()
            {
                lokationsId = "DE12345",
                coverage = 0.87M, // 87%
                wertermittlungsverfahren = BO4E.ENUM.Wertermittlungsverfahren.PROGNOSE,
                referenceTimeFrame = new BO4E.COM.Zeitraum()
                {
                    Startdatum = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Enddatum = new DateTime(2019, 3, 1, 0, 0, 0, DateTimeKind.Utc)
                },
            };
            string result = cr.ToCsv(';', true, Environment.NewLine);
            var lines = new List<string>(result.Split(Environment.NewLine));
            Assert.AreEqual(2, lines.Count);

            // reihenfolge
            List<Dictionary<string, string>> reihenfolge = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>() { ["lokationsId"] = "messlokationsId" },
                new Dictionary<string, string>() { ["coverage"] = "Newcoverage" },
                new Dictionary<string, string>() { ["Zeitraum.startdatum"] = "time.startdatum" },
                new Dictionary<string, string>() { ["Zeitraum.enddatum"] = "time.enddatum" }
            };

            //string JSONdata = "{'completenessZfa':[{'lokationsId':'lokationsId'},{'coverage':'coverage'},{'Zeitraum.einheit':'einheit'},{'Zeitraum.dauer':'dauer'},{'Zeitraum.startdatum':'startdatum'},{'Zeitraum.enddatum':'enddatum'},{'obiskennzahl':'obiskennzahl'},{'einheit':'einheit'},{'wertermittlungsverfahren':'wertermittlungsverfahren'},{'startdatum':'Verbrauch.startdatum'},{'enddatum':'Verbrauch.enddatum'},{'wert':'Verbrauch.wert'},{'headerLine':'1'}]}";
            //var alldata = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(JSONdata);
            //List<Dictionary<string, string>> reihenfolge = alldata["completenessZfa"];

            var Newresult = cr.ToCsv(';', true, Environment.NewLine, reihenfolge);
            lines = new List<string>(Newresult.Split(Environment.NewLine));
            Assert.AreEqual(2, lines.Count);
            var headerline = lines.First();
            //for (int i = 0; i < reihenfolge.Count; i++)
            //{
            //    Assert.AreEqual(reihenfolge[i].Values.First(), headerline.Split(";")[i]);
            //}
            string decimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            Assert.AreEqual("DE12345;0" + decimalSeparator + "87;2019-01-01T00:00:00Z;2019-03-01T00:00:00Z;", lines[1]);
            var commaResult = cr.ToCsv(',', lineTerminator: Environment.NewLine, reihenfolge: reihenfolge);
            Assert.AreEqual("DE12345,0" + decimalSeparator + "87,2019-01-01T00:00:00Z,2019-03-01T00:00:00Z,", commaResult.Split(Environment.NewLine)[1]);
            var dpunktResult = cr.ToCsv(':', lineTerminator: Environment.NewLine, reihenfolge: reihenfolge);
            Assert.AreEqual("DE12345:0" + decimalSeparator + "87:\"2019-01-01T00:00:00Z\":\"2019-03-01T00:00:00Z\":", dpunktResult.Split(Environment.NewLine)[1]);

            cr.values = new List<CompletenessReport.BasicVerbrauch>
            {
                new CompletenessReport.BasicVerbrauch()
                {
                    wert = 17,
                    startdatum = new DateTime(2019,1,1,0,0,0, DateTimeKind.Utc),
                    enddatum = new DateTime(2019,1,2,0,0,0, DateTimeKind.Utc)
                },
                new CompletenessReport.BasicVerbrauch()
                {
                    wert = 21,
                    startdatum = new DateTime(2019,1,7,0,0,0, DateTimeKind.Utc),
                    enddatum = new DateTime(2019,1,8,0,0,0, DateTimeKind.Utc)
                },
                new CompletenessReport.BasicVerbrauch()
                {
                    wert = 35,
                    startdatum = new DateTime(2019,1,12,0,0,0, DateTimeKind.Utc),
                    enddatum = new DateTime(2019,1,13,0,0,0, DateTimeKind.Utc)
                }
            };

            reihenfolge.Add(new Dictionary<string, string>() { ["wert"] = "V.wert" });
            reihenfolge.Add(new Dictionary<string, string>() { ["startdatum"] = "V.startdatum" });
            reihenfolge.Add(new Dictionary<string, string>() { ["enddatum"] = "V.enddatum" });

            var multiplicityResult = cr.ToCsv(lineTerminator: Environment.NewLine, reihenfolge: reihenfolge);
            Assert.AreEqual(2 + cr.values.Count, new List<string>(multiplicityResult.Split(Environment.NewLine)).Count);
        }
        [TestMethod]
        public void TestDeserialisationCompletenessReportColumnsToCsv()
        {
            string jsonData = "{'completenessZfa':[{'lokationsId':'lokationsId'},{'coverage':'coverage'},{'referenceTimeFrame.einheit':'referenceTimeFrame.einheit'},{'referenceTimeFrame.dauer':'referenceTimeFrame.dauer'},{'referenceTimeFrame.startdatum':'referenceTimeFrame.startdatum'},{'referenceTimeFrame.enddatum':'referenceTimeFrame.enddatum'},{'obiskennzahl':'obiskennzahl'},{'einheit':'einheit'},{'wertermittlungsverfahren':'wertermittlungsverfahren'},{'values.startdatum':'Verbrauch.startdatum'},{'values.enddatum':'Verbrauch.enddatum'},{'values.wert':'Verbrauch.wert'},{'headerLine':'1'}]}";
            var Reihenfolge = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(jsonData);
            Assert.AreEqual("coverage", Reihenfolge["completenessZfa"][1].Values.First());
        }

        [TestMethod]
        public void TestDeserialisationCompletenessReportToCsv()
        {
            string jsonData = "[{\"versionStruktur\":1,\"boTyp\":\"COMPLETENESSREPORT\",\"referenceTimeFrame\":{\"$type\":\"BO4E.COM.Zeitraum, BO4Enet\",\"einheit\":null,\"dauer\":null,\"startdatum\":\"2019-09-30T22:00:00Z\",\"enddatum\":\"2019-10-31T23:00:00Z\"},\"_errorMessage\":\"Text of Message\",\"lokationsId\":\"50985149762\",\"obiskennzahl\":\"1-1:1.29.0\",\"einheit\":2000,\"wertermittlungsverfahren\":1,\"coverage\":0.8402684564,\"values\":[],\"gaps\":[{\"$type\":\"BO4E.Reporting.CompletenessReport+BasicVerbrauch, BO4Enet\",\"startdatum\":\"2019-10-27T00:00:00Z\",\"enddatum\":\"2019-10-31T23:00:00Z\",\"wert\":null}],\"profil\":\"000000000111127365\",\"profilRolle\":\"0001\",\"anlagennummer\":\"5000080657\",\"zw\":\"000000000020708905\",\"sap_time_zone\":\"CET\",\"sapSanitized\":true,\"valueCount\":0,\"overallGapStart\":\"2019-10-31T23:00:00Z\",\"overallGapEnd\":\"2019-11-30T23:00:00Z\"},{\"$type\":\"BO4E.Reporting.CompletenessReport, BO4Enet\",\"versionStruktur\":1,\"boTyp\":\"COMPLETENESSREPORT\",\"referenceTimeFrame\":{\"$type\":\"BO4E.COM.Zeitraum, BO4Enet\",\"einheit\":null,\"dauer\":null,\"startdatum\":\"2019-09-30T22:00:00Z\",\"enddatum\":\"2019-10-31T23:00:00Z\"},\"_errorMessage\":null,\"lokationsId\":\"DE0004096816100000000000000200712\",\"obiskennzahl\":\"1-1:1.29.0\",\"einheit\":2000,\"wertermittlungsverfahren\":1,\"coverage\":0.8402684564,\"values\":[],\"gaps\":[{\"$type\":\"BO4E.Reporting.CompletenessReport+BasicVerbrauch, BO4Enet\",\"startdatum\":\"2019-10-27T00:00:00Z\",\"enddatum\":\"2019-10-31T23:00:00Z\",\"wert\":null}],\"profil\":\"000000000111127365\",\"profilRolle\":\"0001\",\"anlagennummer\":\"5001065966\",\"zw\":\"000000000020708905\",\"sap_time_zone\":\"CET\",\"sapSanitized\":true,\"valueCount\":0,\"overallGapStart\":\"2019-10-31T23:00:00Z\",\"overallGapEnd\":\"2019-11-30T23:00:00Z\"},{\"versionStruktur\":1,\"boTyp\":\"COMPLETENESSREPORT\",\"referenceTimeFrame\":{\"$type\":\"BO4E.COM.Zeitraum, BO4Enet\",\"einheit\":null,\"dauer\":null,\"startdatum\":\"2019-10-31T23:00:00Z\",\"enddatum\":\"2019-11-30T23:00:00Z\"},\"_errorMessage\":null,\"lokationsId\":\"50985149762\",\"obiskennzahl\":\"1-1:1.29.0\",\"einheit\":2000,\"wertermittlungsverfahren\":1,\"coverage\":0.3,\"values\":[],\"gaps\":[{\"$type\":\"BO4E.Reporting.CompletenessReport+BasicVerbrauch, BO4Enet\",\"startdatum\":\"2019-10-31T23:00:00Z\",\"enddatum\":\"2019-11-13T00:00:00Z\",\"wert\":null},{\"$type\":\"BO4E.Reporting.CompletenessReport+BasicVerbrauch, BO4Enet\",\"startdatum\":\"2019-11-22T00:00:00Z\",\"enddatum\":\"2019-11-30T23:00:00Z\",\"wert\":null}],\"profil\":\"000000000111127365\",\"profilRolle\":\"0001\",\"anlagennummer\":\"5000080657\",\"zw\":\"000000000020708905\",\"sap_time_zone\":\"CET\",\"sapSanitized\":true,\"valueCount\":0,\"overallGapStart\":\"2019-10-31T23:00:00Z\",\"overallGapEnd\":\"2019-11-30T23:00:00Z\"},{\"$type\":\"BO4E.Reporting.CompletenessReport, BO4Enet\",\"versionStruktur\":1,\"boTyp\":\"COMPLETENESSREPORT\",\"referenceTimeFrame\":{\"$type\":\"BO4E.COM.Zeitraum, BO4Enet\",\"einheit\":null,\"dauer\":null,\"startdatum\":\"2019-10-31T23:00:00Z\",\"enddatum\":\"2019-11-30T23:00:00Z\"},\"_errorMessage\":null,\"lokationsId\":\"DE0004096816100000000000000200712\",\"obiskennzahl\":\"1-1:1.29.0\",\"einheit\":2000,\"wertermittlungsverfahren\":1,\"coverage\":0.3,\"values\":[],\"gaps\":[{\"$type\":\"BO4E.Reporting.CompletenessReport+BasicVerbrauch, BO4Enet\",\"startdatum\":\"2019-10-31T23:00:00Z\",\"enddatum\":\"2019-11-13T00:00:00Z\",\"wert\":null},{\"$type\":\"BO4E.Reporting.CompletenessReport+BasicVerbrauch, BO4Enet\",\"startdatum\":\"2019-11-22T00:00:00Z\",\"enddatum\":\"2019-11-30T23:00:00Z\",\"wert\":null}],\"profil\":\"000000000111127365\",\"profilRolle\":\"0001\",\"anlagennummer\":\"5001065966\",\"zw\":\"000000000020708905\",\"sap_time_zone\":\"CET\",\"sapSanitized\":true,\"valueCount\":0,\"overallGapStart\":\"2019-10-31T23:00:00Z\",\"overallGapEnd\":\"2019-11-30T23:00:00Z\"}]";
            var reports = JsonConvert.DeserializeObject<List<CompletenessReport>>(jsonData);
            string lastCsvText = string.Empty;
            int counter = 1;
            foreach (var report in reports)
            {
                lastCsvText += report.ToCsv(';', (counter == 1 ? true : false), Environment.NewLine, null) + Environment.NewLine;
                counter++;
            }
            Assert.IsTrue(lastCsvText.Length > 0);
        }

        [TestMethod]
        public void TestPrivateFieldsAndUserProperties()
        {
            string jsonData = "[{\"versionStruktur\":1,\"boTyp\":\"COMPLETENESSREPORT\",\"referenceTimeFrame\":{\"$type\":\"BO4E.COM.Zeitraum, BO4Enet\",\"einheit\":null,\"dauer\":null,\"startdatum\":\"2019-09-30T22:00:00Z\",\"enddatum\":\"2019-10-31T23:00:00Z\"},\"_errorMessage\":null,\"lokationsId\":\"50985149762\",\"obiskennzahl\":\"1-1:1.29.0\",\"einheit\":2000,\"wertermittlungsverfahren\":1,\"coverage\":0.8402684564,\"values\":[],\"gaps\":[{\"$type\":\"BO4E.Reporting.CompletenessReport+BasicVerbrauch, BO4Enet\",\"startdatum\":\"2019-10-27T00:00:00Z\",\"enddatum\":\"2019-10-31T23:00:00Z\",\"wert\":null}],\"profil\":\"000000000111127365\",\"profilRolle\":\"0001\",\"anlagennummer\":\"5000080657\",\"zw\":\"000000000020708905\",\"sap_time_zone\":\"CET\",\"sapSanitized\":true,\"valueCount\":0,\"overallGapStart\":\"2019-10-31T23:00:00Z\",\"overallGapEnd\":\"2019-11-30T23:00:00Z\"},{\"$type\":\"BO4E.Reporting.CompletenessReport, BO4Enet\",\"versionStruktur\":1,\"boTyp\":\"COMPLETENESSREPORT\",\"referenceTimeFrame\":{\"$type\":\"BO4E.COM.Zeitraum, BO4Enet\",\"einheit\":null,\"dauer\":null,\"startdatum\":\"2019-09-30T22:00:00Z\",\"enddatum\":\"2019-10-31T23:00:00Z\"},\"_errorMessage\":null,\"lokationsId\":\"DE0004096816100000000000000200712\",\"obiskennzahl\":\"1-1:1.29.0\",\"einheit\":2000,\"wertermittlungsverfahren\":1,\"coverage\":0.8402684564,\"values\":[],\"gaps\":[{\"$type\":\"BO4E.Reporting.CompletenessReport+BasicVerbrauch, BO4Enet\",\"startdatum\":\"2019-10-27T00:00:00Z\",\"enddatum\":\"2019-10-31T23:00:00Z\",\"wert\":null}],\"profil\":\"000000000111127365\",\"profilRolle\":\"0001\",\"anlagennummer\":\"5001065966\",\"zw\":\"000000000020708905\",\"sap_time_zone\":\"CET\",\"sapSanitized\":true,\"valueCount\":0,\"overallGapStart\":\"2019-10-31T23:00:00Z\",\"overallGapEnd\":\"2019-11-30T23:00:00Z\"},{\"$type\":\"BO4E.Reporting.CompletenessReport, BO4Enet\",\"versionStruktur\":1,\"boTyp\":\"COMPLETENESSREPORT\",\"referenceTimeFrame\":{\"$type\":\"BO4E.COM.Zeitraum, BO4Enet\",\"einheit\":null,\"dauer\":null,\"startdatum\":\"2019-10-31T23:00:00Z\",\"enddatum\":\"2019-11-30T23:00:00Z\"},\"_errorMessage\":null,\"lokationsId\":\"50985149762\",\"obiskennzahl\":\"1-1:1.29.0\",\"einheit\":2000,\"wertermittlungsverfahren\":1,\"coverage\":0.3,\"values\":[],\"gaps\":[{\"$type\":\"BO4E.Reporting.CompletenessReport+BasicVerbrauch, BO4Enet\",\"startdatum\":\"2019-10-31T23:00:00Z\",\"enddatum\":\"2019-11-13T00:00:00Z\",\"wert\":null},{\"$type\":\"BO4E.Reporting.CompletenessReport+BasicVerbrauch, BO4Enet\",\"startdatum\":\"2019-11-22T00:00:00Z\",\"enddatum\":\"2019-11-30T23:00:00Z\",\"wert\":null}],\"profil\":\"000000000111127365\",\"profilRolle\":\"0001\",\"anlagennummer\":\"5000080657\",\"zw\":\"000000000020708905\",\"sap_time_zone\":\"CET\",\"sapSanitized\":true,\"valueCount\":0,\"overallGapStart\":\"2019-10-31T23:00:00Z\",\"overallGapEnd\":\"2019-11-30T23:00:00Z\"},{\"$type\":\"BO4E.Reporting.CompletenessReport, BO4Enet\",\"versionStruktur\":1,\"boTyp\":\"COMPLETENESSREPORT\",\"referenceTimeFrame\":{\"$type\":\"BO4E.COM.Zeitraum, BO4Enet\",\"einheit\":null,\"dauer\":null,\"startdatum\":\"2019-10-31T23:00:00Z\",\"enddatum\":\"2019-11-30T23:00:00Z\"},\"_errorMessage\":null,\"lokationsId\":\"DE0004096816100000000000000200712\",\"obiskennzahl\":\"1-1:1.29.0\",\"einheit\":2000,\"wertermittlungsverfahren\":1,\"coverage\":0.3,\"values\":[],\"gaps\":[{\"$type\":\"BO4E.Reporting.CompletenessReport+BasicVerbrauch, BO4Enet\",\"startdatum\":\"2019-10-31T23:00:00Z\",\"enddatum\":\"2019-11-13T00:00:00Z\",\"wert\":null},{\"$type\":\"BO4E.Reporting.CompletenessReport+BasicVerbrauch, BO4Enet\",\"startdatum\":\"2019-11-22T00:00:00Z\",\"enddatum\":\"2019-11-30T23:00:00Z\",\"wert\":null}],\"profil\":\"000000000111127365\",\"profilRolle\":\"0001\",\"anlagennummer\":\"5001065966\",\"zw\":\"000000000020708905\",\"sap_time_zone\":\"CET\",\"sapSanitized\":true,\"valueCount\":0,\"overallGapStart\":\"2019-10-31T23:00:00Z\",\"overallGapEnd\":\"2019-11-30T23:00:00Z\"}]";
            var reports = JsonConvert.DeserializeObject<List<CompletenessReport>>(jsonData);
            string lastCsvText = string.Empty;
            int counter = 1;
            foreach (var report in reports)
            {
                lastCsvText += report.ToCsv(';', (counter == 1 ? true : false), Environment.NewLine, null) + Environment.NewLine;
                counter++;
            }
            Assert.IsTrue(lastCsvText.Length > 0);
            Assert.IsFalse(lastCsvText.Contains(BO4E.BO.BusinessObject.userPropertiesName));
            Assert.IsFalse(lastCsvText.Contains("_errorMessage"));
        }

        [TestMethod]
        public void TestCompletenessReportMitGapToCsv()
        {
            CompletenessReport cr = new CompletenessReport()
            {
                lokationsId = "DE12345",
                coverage = 0.87M, // 87%
                wertermittlungsverfahren = BO4E.ENUM.Wertermittlungsverfahren.PROGNOSE,
                referenceTimeFrame = new BO4E.COM.Zeitraum()
                {
                    Startdatum = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Enddatum = new DateTime(2019, 3, 1, 0, 0, 0, DateTimeKind.Utc)
                },
            };
            cr.values = new List<CompletenessReport.BasicVerbrauch>
            {
                new CompletenessReport.BasicVerbrauch()
                {
                    wert = 17,
                    startdatum = new DateTime(2019,1,1,0,0,0, DateTimeKind.Utc),
                    enddatum = new DateTime(2019,1,2,0,0,0, DateTimeKind.Utc)
                },
                new CompletenessReport.BasicVerbrauch()
                {
                    wert = 21,
                    startdatum = new DateTime(2019,1,7,0,0,0, DateTimeKind.Utc),
                    enddatum = new DateTime(2019,1,8,0,0,0, DateTimeKind.Utc)
                },
                new CompletenessReport.BasicVerbrauch()
                {
                    wert = 35,
                    startdatum = new DateTime(2019,1,12,0,0,0, DateTimeKind.Utc),
                    enddatum = new DateTime(2019,1,13,0,0,0, DateTimeKind.Utc)
                }
            };
            cr.gaps = new List<CompletenessReport.BasicVerbrauch>
            {
                new CompletenessReport.BasicVerbrauch()
                {
                    wert = 0,
                    startdatum = new DateTime(2017,1,1,0,0,0, DateTimeKind.Utc),
                    enddatum = new DateTime(2017,1,2,0,0,0, DateTimeKind.Utc)
                },
                new CompletenessReport.BasicVerbrauch()
                {
                    wert = 0,
                    startdatum = new DateTime(2017,1,7,0,0,0, DateTimeKind.Utc),
                    enddatum = new DateTime(2017,1,8,0,0,0, DateTimeKind.Utc)
                },
                new CompletenessReport.BasicVerbrauch()
                {
                    wert = 0,
                    startdatum = new DateTime(2017,1,12,0,0,0, DateTimeKind.Utc),
                    enddatum = new DateTime(2017,1,13,0,0,0, DateTimeKind.Utc)
                }
            };
            var multiplicityResult = cr.ToCsv(lineTerminator: Environment.NewLine);
            Assert.AreEqual(2 + cr.values.Count + cr.gaps.Count, new List<string>(multiplicityResult.Split(Environment.NewLine)).Count);
        }

        [TestMethod]
        public void TestCompletenessReportToCsvExceptions()
        {
            CompletenessReport cr = new CompletenessReport()
            {
                lokationsId = "DE12345",
                coverage = 0.87M, // 87%
                wertermittlungsverfahren = BO4E.ENUM.Wertermittlungsverfahren.PROGNOSE,
                referenceTimeFrame = new BO4E.COM.Zeitraum()
                {
                    Startdatum = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Enddatum = new DateTime(2019, 3, 1, 0, 0, 0, DateTimeKind.Utc)
                },
            };

            // reihenfolge
            List<Dictionary<string, string>> reihenfolge = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>() { ["lokationsId"] = "messlokationsId" },
                new Dictionary<string, string>() { ["coverage"] = "Newcoverage" },
                new Dictionary<string, string>() { ["Zeitraum.startdatum"] = "time.startdatum" },
                new Dictionary<string, string>() { ["Zeitraum.enddatum"] = "time.enddatum" },
                new Dictionary<string, string>() { ["wert"] = null },
                new Dictionary<string, string>() { ["startdatum"] = "V.startdatum" },
                new Dictionary<string, string>() { ["enddatum"] = "V.enddatum" },
                null
            };
            string newResult = string.Empty;
            Assert.ThrowsException<ArgumentNullException>(() => cr.ToCsv(';', true, Environment.NewLine, reihenfolge));
            Assert.AreEqual(newResult, "");


            // reihenfolge
            List<Dictionary<string, string>> reihenfolge2 = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>() { ["lokationsId"] = "messlokationsId" },
                new Dictionary<string, string>() { ["coverage"] = "Newcoverage" },
                new Dictionary<string, string>() { ["Zeitraum.startdatum"] = "time.startdatum" },
                new Dictionary<string, string>() { ["Zeitraum.enddatum"] = "time.enddatum" },
                new Dictionary<string, string>() { ["wert"] = "V.wert" },
                new Dictionary<string, string>() { ["startdatum"] = "V.startdatum" },
                new Dictionary<string, string>() { ["enddatum"] = "V.enddatum" },
                new Dictionary<string, string>() { ["asdasd"] = "000" }
            };
            Assert.ThrowsException<ArgumentException>(() => cr.ToCsv(';', true, Environment.NewLine, reihenfolge2));
            Assert.AreEqual(newResult, "");
        }
    }
}
