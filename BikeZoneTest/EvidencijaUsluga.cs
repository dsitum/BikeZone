using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeZone;

namespace BikeZoneTest
{
    [TestClass]
    public class EvidencijaUsluga
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            Evidencija_Usluga frm = new Evidencija_Usluga(false);
            Assert.AreEqual(false,frm.DodajNovuUslugu, "Nije dobro proslijeđen parameter bool");
        }
    }
}
