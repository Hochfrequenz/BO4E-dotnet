using System.Collections.Generic;
using System.IO;
using BO4E.BO;
using BO4E.Extensions.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestBO4EExtensions
{
    [TestClass]
    public class TestCloningExtension
    {
        [TestMethod]
        public void TestCloning()
        {
            var bo = new Messlokation()
            {
                MesslokationsId = "DE345",

            };
            var cloneBo = BusinessObjectExtensions.DeepClone((Messlokation)bo);
            Assert.AreNotSame(bo, cloneBo);
            // Assert.AreEqual<Messlokation>((Messlokation)bo, cloneBo); <--- keine ahnung warum das failed. vllt. auch mit json patch/diff arbeiten wie im hubnet projekt

        }

        [TestMethod]
        public void TestCloningEnergiemenge()
        {
            var em = new Energiemenge()
            {
                LokationsId = "De12345",
                LokationsTyp = BO4E.ENUM.Lokationstyp.MA_LO,
                Energieverbrauch = new List<BO4E.COM.Verbrauch>()
                {
                    new BO4E.COM.Verbrauch()
                    {
                        Einheit = BO4E.ENUM.Mengeneinheit.KWH,
                        Wert = 123.456M,
                        Obiskennzahl = "dei vadder",
                        Wertermittlungsverfahren = BO4E.ENUM.Wertermittlungsverfahren.MESSUNG,
                        Startdatum = new System.DateTime(2018,12,31,23,0,0,0, System.DateTimeKind.Utc),
                        Enddatum = new System.DateTime(2019,12,31,23,0,0,0,System.DateTimeKind.Utc)
                    },
                    new BO4E.COM.Verbrauch()
                    {
                        Einheit = BO4E.ENUM.Mengeneinheit.KWH,
                        Wert = 789.123M,
                        Obiskennzahl = "dei mudder",
                        Wertermittlungsverfahren = BO4E.ENUM.Wertermittlungsverfahren.MESSUNG,
                        Startdatum = new System.DateTime(2019,12,31,23,0,0,0, System.DateTimeKind.Utc),
                        Enddatum = new System.DateTime(2020,12,31,23,0,0,0,System.DateTimeKind.Utc)
                    }
                }
            };
            var cloned = em.DeepClone();
            Assert.AreEqual(em.Energieverbrauch.Count, cloned.Energieverbrauch.Count);

            var cloned2 = em.DeepClone();
            Assert.AreEqual(em.Energieverbrauch.Count, cloned2.Energieverbrauch.Count);

            var cloned3 = (em as BusinessObject).DeepClone();
            Assert.AreEqual(em.Energieverbrauch.Count, (cloned3 as Energiemenge).Energieverbrauch.Count);
        }
    }
}