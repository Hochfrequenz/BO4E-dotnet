using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E.Reporting
{
    [TestClass]
    public class TestCompletenessReportSorting
    {
        [TestMethod]
        public void TestStartdatumSorting()
        {
            BO4E.Reporting.CompletenessReport cr1 = new BO4E.Reporting.CompletenessReport()
            {
                referenceTimeFrame = new BO4E.COM.Zeitraum()
                {
                    Startdatum = new System.DateTime(2001, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)
                }
            };
            BO4E.Reporting.CompletenessReport cr2 = new BO4E.Reporting.CompletenessReport()
            {
                referenceTimeFrame = new BO4E.COM.Zeitraum()
                {
                    Startdatum = new System.DateTime(2002, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)
                }
            };
            BO4E.Reporting.CompletenessReport cr3 = new BO4E.Reporting.CompletenessReport()
            {
                referenceTimeFrame = new BO4E.COM.Zeitraum()
                {
                    Startdatum = new System.DateTime(2003, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)
                }
            };
            List<BO4E.Reporting.CompletenessReport> crList = new List<BO4E.Reporting.CompletenessReport>() { cr2, cr3, cr1 };
            // before sorting
            Assert.IsTrue(crList.First().referenceTimeFrame.Startdatum.Value.Year == 2002);
            Assert.IsTrue(crList[1].referenceTimeFrame.Startdatum.Value.Year == 2003);
            Assert.IsTrue(crList.Last().referenceTimeFrame.Startdatum.Value.Year == 2001);

            crList.Sort();
            //after sorting
            Assert.IsTrue(crList.First().referenceTimeFrame.Startdatum.Value.Year == 2001);
            Assert.IsTrue(crList[1].referenceTimeFrame.Startdatum.Value.Year == 2002);
            Assert.IsTrue(crList.Last().referenceTimeFrame.Startdatum.Value.Year == 2003);

            BO4E.Reporting.CompletenessReport crNull = new BO4E.Reporting.CompletenessReport();
            crList.Add(crNull);
            BO4E.Reporting.CompletenessReport cr0 = new BO4E.Reporting.CompletenessReport()
            {
                referenceTimeFrame = new BO4E.COM.Zeitraum()
                {
                    Startdatum = new System.DateTime(1999, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)
                }
            };
            crList.Add(cr0);
            crList.Sort();
            Assert.IsNull(crList.First().referenceTimeFrame);
            Assert.IsTrue(crList[1].referenceTimeFrame.Startdatum.Value.Year == 1999);
        }
    }
}
