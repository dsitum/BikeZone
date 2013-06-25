using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeZone;
namespace BikeZoneTest
{
    [TestClass]
    public class EvidencijaZaposlenika
    {
        [TestMethod]
        public void TestMethod1()
        {
            Evidencija_Zaposlenika frm = new Evidencija_Zaposlenika(false, 10);
            Assert.AreEqual(false, frm.Dodaj_Promijeni, "Nije dobro proslijeđen bool parametar!");
        }
    }
}
