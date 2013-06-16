using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace BikeZone
{
    public partial class Glavna_Forma : Form
    {
        public Glavna_Forma()
        {
            InitializeComponent();
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite izaći iz aplikacije?", "Izlaz iz aplikacije", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Unos_dijelova_Menu_Click(object sender, EventArgs e)
        {
            //Unos_dijelova unos_dijelova = new Unos_dijelova();
            //unos_dijelova.ShowDialog();
        }

        private void EvidencijaProizvoda_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Proizvoda evidencijaProizvoda = new Evidencija_Proizvoda();
            evidencijaProizvoda.ShowDialog();
        }

        private void EvidencijaUsluga_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Usluga evidencijaUsluga = new Evidencija_Usluga();
            evidencijaUsluga.ShowDialog();
        }

        private void OTvrtki_Menu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tvrtka BikeZone osnovana je 2005. godine u Vinkovcima.", "BikeZone");
        }

        private void EvidencijaDobavljača_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Dobavljaca evidencijaDobavljaca = new Evidencija_Dobavljaca();
            evidencijaDobavljaca.ShowDialog();
        }

        private void EvidencijaKupaca_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Klijenata evidencijaKlijenata = new Evidencija_Klijenata();
            evidencijaKlijenata.ShowDialog();
        }

        private void EvidencijaZaposlenika_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Zaposlenika evidencijaZaposlenika = new Evidencija_Zaposlenika();
            evidencijaZaposlenika.ShowDialog();
        }
    }
}
