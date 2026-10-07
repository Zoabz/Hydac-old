using Hydac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HydacTest
{
    [TestClass]
    public class MedarbejderTest
    {
        [TestMethod]
        public void TjekKode_RigtigKode_ReturnererTrue()
        {
            Medarbejder medarbejder = new Medarbejder("Lars Hansen", "LH1234");

            Assert.IsTrue(medarbejder.TjekKode("LH1234"));
        }

        [TestMethod]
        public void TjekKode_ForkertKode_ReturnererFalse()
        {
            Medarbejder medarbejder = new Medarbejder("Lars Hansen", "LH1234");

            Assert.IsFalse(medarbejder.TjekKode("forkert"));
        }
    }
}
