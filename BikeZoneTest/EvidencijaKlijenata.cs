using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeZone;
namespace BikeZoneTest
{
    [TestClass]
    public class EvidencijaKlijenata
    {
        [TestMethod]
        public void TestMethod1()
        {
            Evidencija_Klijenata frm = new Evidencija_Klijenata(false);
            Assert.AreEqual(false, frm.Dodaj_Promijeni, "Krivo proslijeđen parametar bool!");
        }
    }
}
