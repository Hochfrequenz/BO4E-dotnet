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
            var cr1 = new BO4E.Reporting.CompletenessReport
            {
                ReferenceTimeFrame = new BO4E.COM.Zeitraum
                {
                    Startdatum = new System.DateTime(2001, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)
                }
            };
            var cr2 = new BO4E.Reporting.CompletenessReport
            {
                ReferenceTimeFrame = new BO4E.COM.Zeitraum
                {
                    Startdatum = new System.DateTime(2002, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)
                }
            };
            var cr3 = new BO4E.Reporting.CompletenessReport
            {
                ReferenceTimeFrame = new BO4E.COM.Zeitraum
                {
                    Startdatum = new System.DateTime(2003, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)
                }
            };
            var crList = new List<BO4E.Reporting.CompletenessReport> { cr2, cr3, cr1 };
            // before sorting
            Assert.AreEqual(2002, crList.First().ReferenceTimeFrame.Startdatum.Value.Year);
            Assert.AreEqual(2003, crList[1].ReferenceTimeFrame.Startdatum.Value.Year);
            Assert.AreEqual(2001, crList.Last().ReferenceTimeFrame.Startdatum.Value.Year);

            crList.Sort();
            //after sorting
            Assert.AreEqual(2001, crList.First().ReferenceTimeFrame.Startdatum.Value.Year);
            Assert.AreEqual(2002, crList[1].ReferenceTimeFrame.Startdatum.Value.Year);
            Assert.AreEqual(2003, crList.Last().ReferenceTimeFrame.Startdatum.Value.Year);

            var crNull = new BO4E.Reporting.CompletenessReport();
            crList.Add(crNull);
            var cr0 = new BO4E.Reporting.CompletenessReport
            {
                ReferenceTimeFrame = new BO4E.COM.Zeitraum
                {
                    Startdatum = new System.DateTime(1999, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)
                }
            };
            crList.Add(cr0);
            crList.Sort();
            Assert.IsNull(crList.First().ReferenceTimeFrame);
            Assert.AreEqual(1999, crList[1].ReferenceTimeFrame.Startdatum.Value.Year);
        }
    }
}
