using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeZone;
namespace BikeZoneTest
{
    [TestClass]
    public class EvidencijaDobavljaca
    {
        [TestMethod]
        public void TestMethod1()
        {
            Evidencija_Dobavljaca frm = new Evidencija_Dobavljaca(true);
            Assert.AreEqual(true, frm.DodajNovogDobavljaca, "Krivo proslijeđen parametar bool!");
        }
    }
}
