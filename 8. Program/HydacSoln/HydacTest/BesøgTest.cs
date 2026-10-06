using Hydac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HydacTest
{
    [TestClass]
    public class BesøgTest
    {
        // Testdata fra objektmodellen (b1, g1 og m1). Datoen er i morgen,
        // fordi et besøg ikke må oprettes med en dato før i dag.
        private static readonly DateTime dato = DateTime.Today.AddDays(1);
        private static readonly DateTime forventetAnkomsttid = dato.AddHours(12);
        private static readonly DateTime forventetAfgangstid = dato.AddHours(16);
        private static readonly Medarbejder ansvarlig = new Medarbejder("Lars Hansen", "LH1234");

        private static Besøg OpretBesøg()
        {
            return new Besøg("Søren Mortensen", "Bilka", ansvarlig, dato,
                forventetAnkomsttid, forventetAfgangstid, "X01", 81507192);
        }

        [TestMethod]
        public void Constructor_GyldigeOplysninger_GemmerDemPåBesøget()
        {
            // Act
            Besøg besøg = OpretBesøg();

            // Assert
            Assert.AreEqual("Søren Mortensen", besøg.GæstNavn);
            Assert.AreEqual("Bilka", besøg.Firma);
            Assert.AreSame(ansvarlig, besøg.Ansvarlig);
            Assert.AreEqual(dato, besøg.Dato);
            Assert.AreEqual(forventetAnkomsttid, besøg.ForventetAnkomsttid);
            Assert.AreEqual(forventetAfgangstid, besøg.ForventetAfgangstid);
            Assert.AreEqual("X01", besøg.Lokale);
            Assert.AreEqual(81507192, besøg.Indtjekningskode);
            Assert.AreEqual(Besøg.IkkeTjekketInd, besøg.Status);
            Assert.IsNull(besøg.Indtjekningstid);
            Assert.IsNull(besøg.Udtjekningstid);
            Assert.IsFalse(besøg.SikkerhedsfolderModtaget);
        }

        [TestMethod]
        public void Constructor_DatoIGår_KasterArgumentException()
        {
            DateTime iGår = DateTime.Today.AddDays(-1);

            Assert.ThrowsExactly<ArgumentException>(() => new Besøg("Søren Mortensen", "Bilka", ansvarlig, iGår,
                iGår.AddHours(12), iGår.AddHours(16), "X01", 81507192));
        }

        [TestMethod]
        public void Constructor_AfgangstidFørAnkomsttid_KasterArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() => new Besøg("Søren Mortensen", "Bilka", ansvarlig, dato,
                forventetAfgangstid, forventetAnkomsttid, "X01", 81507192));
        }

        [TestMethod]
        public void Constructor_TomtNavn_KasterArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() => new Besøg("", "Bilka", ansvarlig, dato,
                forventetAnkomsttid, forventetAfgangstid, "X01", 81507192));
        }

        [TestMethod]
        public void TjekInd_IkkeTjekketInd_SætterStatusTidOgSikkerhedsfolder()
        {
            // Arrange
            Besøg besøg = OpretBesøg();

            // Act
            besøg.TjekInd(true);

            // Assert
            Assert.AreEqual(Besøg.TjekketInd, besøg.Status);
            Assert.IsNotNull(besøg.Indtjekningstid);
            Assert.IsTrue(besøg.SikkerhedsfolderModtaget);
        }

        [TestMethod]
        public void TjekInd_AlleredeTjekketInd_KasterInvalidOperationException()
        {
            Besøg besøg = OpretBesøg();
            besøg.TjekInd(true);

            Assert.ThrowsExactly<InvalidOperationException>(() => besøg.TjekInd(true));
        }

        [TestMethod]
        public void TjekUd_TjekketInd_SætterStatusOgTid()
        {
            // Arrange
            Besøg besøg = OpretBesøg();
            besøg.TjekInd(true);

            // Act
            besøg.TjekUd();

            // Assert
            Assert.AreEqual(Besøg.TjekketUd, besøg.Status);
            Assert.IsNotNull(besøg.Udtjekningstid);
        }

        [TestMethod]
        public void TjekUd_IkkeTjekketInd_KasterInvalidOperationException()
        {
            Besøg besøg = OpretBesøg();

            Assert.ThrowsExactly<InvalidOperationException>(() => besøg.TjekUd());
        }
    }
}
