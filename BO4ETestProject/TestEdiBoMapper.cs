using System.Collections.Generic;
using BO4E;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E
{
    [TestClass]
    public class TestEdiBoMapper
    {
        private readonly Dictionary<string, Dictionary<string, string>> _expectedResults = new Dictionary<string, Dictionary<string, string>>();
        public TestEdiBoMapper()
        {
            _expectedResults.Add("Netzebene", new Dictionary<string, string>() {
                {"E06", "NSP"}, // EDI -> BO4E (power)
                {"HSP", "HSP"}, // BO4E preserving
                {"Y02", "MD"}, // EDI -> BO4E (gas)
            });
            _expectedResults.Add("Zaehlertyp", new Dictionary<string, string>() {
                {"BGZ", "BALGENGASZAEHLER" }, // EDI -> BO4E
                {"MAZ", "MAXIMUMZAEHLER"},
                {"IVA", null} // what to do?
            });
            _expectedResults.Add("Geraetetyp", new Dictionary<string, string>() {
                {"DKZ", "DREHKOLBENGASZAEHLER" }, // EDI -> BO4E
                {"MME", "MODERNE_MESSEINRICHTUNG"},
                {"ELEKTRONISCHER_HAUSHALTSZAEHLER", "ELEKTRONISCHER_HAUSHALTSZAEHLER"},
                {"IVA", null  }
            });
            _expectedResults.Add("Zaehlerauspraegung", new Dictionary<string, string>() {
                {"ERZ", "EINRICHTUNGSZAEHLER"}, // EDI -> BO4E
                {"ZRZ", "ZWEIRICHTUNGSZAEHLER"}
            });
            _expectedResults.Add("Tarifart", new Dictionary<string, string>() {
                {"ETZ", "EINTARIF"}, // EDI -> BO4E
                {"ZTZ", "ZWEITARIF"},
                {"NTZ", "MEHRTARIF"}
            });
            _expectedResults.Add("Energierichtung", new Dictionary<string, string>() {
                {"Z06", "EINSP"}, // EDI -> BO4E
                {"Z07", "AUSSP"}
            });
            _expectedResults.Add("Rollencodetyp", new Dictionary<string, string>() {
                {"293", "BDEW"}, // EDI -> BO4E
                {"332", "DVGW"}
            });
            _expectedResults.Add("Landescode", new Dictionary<string, string>() {
                {"DE", "DE"},
                {"AT", "AT"}
            });
            _expectedResults.Add("Wertermittlungsverfahren", new Dictionary<string, string>() {
                {"220", "MESSUNG"}
            });
            _expectedResults.Add("BDEWArtikelnummer", new Dictionary<string, string>() {
                {"9990001000152", "NOTSTROMLIEFERUNG_LEISTUNG"},
                {"9990001000798", "MSB_INKL_MESSUNG" }
            });
        }
        [TestMethod]
        public void TestSimpleEnums()
        {
            foreach (var objectName in _expectedResults.Keys)
            {
                var map = _expectedResults[objectName];
                foreach (var teststring in map.Keys)
                {
                    var expectedResult = map[teststring];
                    var result = EdiBoMapper.FromEdi(objectName, teststring);
                    Assert.AreEqual(expectedResult, result);
                }
            }
        }
    }
}
