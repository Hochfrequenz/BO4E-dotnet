using BO4E.BO;
using BO4E.ENUM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E
{
    [TestClass]
    public class TestMaLoMeLoId
    {
        [TestMethod]
        public void TestMeLoIdValidity()
        {
            Assert.IsFalse(Messlokation.ValidateId(null));
            Assert.IsFalse(Messlokation.ValidateId(" "));
            Assert.IsTrue(Messlokation.ValidateId("DE1234567890123456789012345678901"));
            Assert.IsTrue(Messlokation.ValidateId("DE00056266802AO6G56M11SN51G21M24S"));
            Assert.IsFalse(Messlokation.ValidateId("deimudderihrfalschemeldoid"));
            Assert.IsFalse(Messlokation.ValidateId("kleinbuchstabensindnichterlaubt01"));
        }

        [TestMethod]
        public void TestMaLoIdValidity()
        {
            Assert.IsFalse(Marktlokation.ValidateId(null));
            Assert.IsFalse(Marktlokation.ValidateId(" "));
            Assert.IsTrue(Marktlokation.ValidateId("51238696781"));
            Assert.IsTrue(Marktlokation.ValidateId("41373559241"));
            Assert.IsTrue(Marktlokation.ValidateId("56789012345"));
            Assert.IsTrue(Marktlokation.ValidateId("52935155442"));
            Assert.IsFalse(Marktlokation.ValidateId("512386967890"));
            Assert.IsFalse(Marktlokation.ValidateId("41373559240"));
            Assert.IsFalse(Marktlokation.ValidateId("12345"));
            Assert.IsFalse(Marktlokation.ValidateId("asdFG"));
            Assert.IsFalse(Marktlokation.ValidateId("DE1234567890123456789012345678901"));
        }

        [TestMethod]
        public void TestMeLoValidity()
        {
            var malo = new Marktlokation
            {
                MarktlokationsId = "1235678901",
                Sparte = Sparte.STROM,
                Energierichtung = Energierichtung.AUSSP
            };
            Assert.IsFalse(malo.IsValid()); // because the obligatory bilanzierungsmethode is not set
            malo.Bilanzierungsmethode = Bilanzierungsmethode.SLP;
            Assert.IsTrue(malo.IsValid(false)); // because all obligatory fields are set
            Assert.IsFalse(malo.IsValid()); // but the marklokationsId is wrong
            malo.MarktlokationsId = "51238696781"; // matches the appropriate regex and has the right check sum
            Assert.IsTrue(malo.IsValid());
        }
    }
}