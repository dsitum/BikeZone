using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeZone;
namespace BikeZoneTest
{
    [TestClass]
    public class GlavnaFormaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Glavna_Forma glavna = new Glavna_Forma(5);
            int id = glavna.Id_zaposlenika;
            Assert.AreEqual(5, id, "Nije dobro alociran id!");
        }
    }
}
