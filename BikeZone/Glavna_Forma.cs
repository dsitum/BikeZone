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
using System.Threading;

namespace BikeZone
{
    public partial class Glavna_Forma : Form
    {
        public Glavna_Forma(int idZaposlenika)
        {
            InitializeComponent();
            this.CenterToParent();
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

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Evidencija_Zaposlenika evidencijaZaposlenika = new Evidencija_Zaposlenika(false);
            evidencijaZaposlenika.ShowDialog();
        }

        private void urediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Evidencija_Zaposlenika evidencijaZaposlenika = new Evidencija_Zaposlenika(true);
            evidencijaZaposlenika.ShowDialog();
        }

        private void urediToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Evidencija_Proizvoda evidencijaProizvoda = new Evidencija_Proizvoda(true);
            evidencijaProizvoda.ShowDialog();
        }

        private void dodajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Evidencija_Proizvoda evidencijaProizvoda = new Evidencija_Proizvoda(false);
            evidencijaProizvoda.ShowDialog();
        }

        private void backupBazePodatakaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread dretva = new Thread(new ThreadStart(BackupBaze));
            dretva.Start();
            try
            {
                BackupBaze();
            }
            catch
            {
                MessageBox.Show("Nije uspješno napravljen backup!");
            }
        }

        private static void BackupBaze()
        {
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            cmd.StartInfo = startInfo;
            cmd.Start();
            if (cmd != null)
            {
                cmd.StandardInput.WriteLine(@"cd C:\Program Files\PostgreSQL\9.2\bin");
                cmd.StandardInput.WriteLine(@"pg_dump -U postgres -C -f C:\Program Files\PostgreSQL\BikeZone___" + DateTime.Today.ToShortDateString() + ".dump BikeZone");
                cmd.StandardInput.Close();
            }
            MessageBox.Show(@"Uspješno napravljen backup, nalazi se na C:\Program Files\PostgreSQL\9.2\bin");
        }
    }
}
