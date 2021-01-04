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
            var cr1 = new BO4E.Reporting.CompletenessReport()
            {
                ReferenceTimeFrame = new BO4E.COM.Zeitraum()
                {
                    Startdatum = new System.DateTime(2001, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)
                }
            };
            var cr2 = new BO4E.Reporting.CompletenessReport()
            {
                ReferenceTimeFrame = new BO4E.COM.Zeitraum()
                {
                    Startdatum = new System.DateTime(2002, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)
                }
            };
            var cr3 = new BO4E.Reporting.CompletenessReport()
            {
                ReferenceTimeFrame = new BO4E.COM.Zeitraum()
                {
                    Startdatum = new System.DateTime(2003, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)
                }
            };
            var crList = new List<BO4E.Reporting.CompletenessReport>() { cr2, cr3, cr1 };
            // before sorting
            Assert.IsTrue(crList.First().ReferenceTimeFrame.Startdatum.Value.Year == 2002);
            Assert.IsTrue(crList[1].ReferenceTimeFrame.Startdatum.Value.Year == 2003);
            Assert.IsTrue(crList.Last().ReferenceTimeFrame.Startdatum.Value.Year == 2001);

            crList.Sort();
            //after sorting
            Assert.IsTrue(crList.First().ReferenceTimeFrame.Startdatum.Value.Year == 2001);
            Assert.IsTrue(crList[1].ReferenceTimeFrame.Startdatum.Value.Year == 2002);
            Assert.IsTrue(crList.Last().ReferenceTimeFrame.Startdatum.Value.Year == 2003);

            var crNull = new BO4E.Reporting.CompletenessReport();
            crList.Add(crNull);
            var cr0 = new BO4E.Reporting.CompletenessReport()
            {
                ReferenceTimeFrame = new BO4E.COM.Zeitraum()
                {
                    Startdatum = new System.DateTime(1999, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)
                }
            };
            crList.Add(cr0);
            crList.Sort();
            Assert.IsNull(crList.First().ReferenceTimeFrame);
            Assert.IsTrue(crList[1].ReferenceTimeFrame.Startdatum.Value.Year == 1999);
        }
    }
}
