using BO4E.EnergyIdentificationCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E
{
    /// <summary>
    /// Tests <see cref="BO4E.EnergyIdentificationCodes.EnergyIdentificationCodeExtensions"/>
    /// </summary>
    [TestClass]
    public class TestEnergyIdentificationCodeExtensions
    {
        /// <summary>
        /// Tests <see cref="EnergyIdentificationCodeExtensions.IsValidEIC"/>
        /// </summary>
        /// <param name="eicCode"></param>
        /// <param name="expectedValidity"></param>
        [TestMethod]
        [DataRow("", false)]
        [DataRow(null, false)]
        [DataRow("soooasdasdmk", false)]
        [DataRow("11XRWENET12345-2",
            true)] // example from section 7 https://eepublicdownloads.entsoe.eu/clean-documents/EDI/Library/cim_based/02%20EIC%20Code%20implementation%20guide_final.pdf
        [DataRow("11XRWENET12345-3",
            false)] // example from section 7 https://eepublicdownloads.entsoe.eu/clean-documents/EDI/Library/cim_based/02%20EIC%20Code%20implementation%20guide_final.pdf
        // other examples taken from https://www.entsoe.eu/data/energy-identification-codes-eic/eic-approved-codes/
        [DataRow("10X1001A1001A361", true)] // TENNET_TSO
        [DataRow("10X1001A1001A360", false)] // TENNET_TSO with wrong check sum
        [DataRow("10X1001A1001A523", true)] // CYPRUS_TSO
        [DataRow("10X1001A1001A524", false)] // CYPRUS_TSO with wrong check sum
        [DataRow("59XEH1ALL9ORA116", true)] // CALORGAS ITALIA S.R.L.
        [DataRow("59XEH1ALL9ORA117", false)] // CALORGAS ITALIA S.R.L. with wrong checksum
        [DataRow("18XCONJH-12345-9", true)] // CONTRUCCIONES JAVIER HERRAN, S.L.
        [DataRow("18XCONJH-12345-0", false)] // CONTRUCCIONES JAVIER HERRAN, S.L. with wrong checksum
        public void TestEICValidity(string eicCode, bool expectedValidity)
        {
            var actualValidity = eicCode.IsValidEIC();
            Assert.AreEqual(expected: expectedValidity, actual: actualValidity);
        }

        /// <summary>
        /// Tests <see cref="EnergyIdentificationCodeExtensions.IsValidEICBDEW"/>
        /// </summary>
        /// <param name="eicCode"></param>
        /// <param name="expectedValidity"></param>
        [TestMethod]
        [DataRow("foobar", false)]
        [DataRow("18XCONJH-12345-9", false)] // CONTRUCCIONES JAVIER HERRAN, S.L. is not BDEW managed
        [DataRow("11YW-WALLDUERN-L", true)] // Stadtwerke Walldürn GmbH
        [DataRow("11YW-FAS-------D", true)] // EGC Infrastruktur und Netz GmbH
        [DataRow("11YW-HIRSCHBERKK", true)] // Netzbetrieb Hirschberg GmbH & Co. KG
        public void TestEICBdew(string eicCode, bool expectedValidity)
        {
            var actualValidity = eicCode.IsValidEICBDEW();
            Assert.AreEqual(expected: expectedValidity, actual: actualValidity);
        }

        /// <summary>
        /// Tests <see cref="EnergyIdentificationCodeExtensions.IsValidBilanzierungsGebietId"/>
        /// </summary>
        [TestMethod]
        [DataRow("foo bar", false)]
        [DataRow("11YW-FAS-------D", true)] // EGC Infrastruktur und Netz GmbH
        [DataRow("11YW-HIRSCHBERKK", true)] // Netzbetrieb Hirschberg GmbH & Co. KG
        [DataRow("11XVER-SWHEI---3", false)] // Stadtwerke Heide are not a Bilanzierungsgebiet
        public void TestBilanzierungsgebietValidity(string eicCode, bool expectedValidity)
        {
            var actualValidity = eicCode.IsValidBilanzierungsGebietId();
            Assert.AreEqual(expected: expectedValidity, actual: actualValidity);
        }

        /// <summary>
        /// Tests <see cref="EnergyIdentificationCodeExtensions.IsGermanControlArea"/>
        /// </summary>
        /// <param name="eicCode"></param>
        /// <param name="expectedValidity"></param>
        [TestMethod]
        [DataRow("10YDE-EON------1", true)]
        [DataRow("10YDE-RWENET---I", true)]
        [DataRow("10YDE-VE-------2", true)]
        [DataRow("10YDE-ENBW-----N", true)]
        [DataRow("foobar", false)]
        public void TestGermanRegelZone(string eicCode, bool expectedValidity)
        {
            Assert.AreEqual(expectedValidity, eicCode.IsGermanControlArea());
        }
    }
}