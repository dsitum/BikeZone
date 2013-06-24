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

        private void DodajUslugu_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Usluga evidencijaUsluga = new Evidencija_Usluga(true);
            evidencijaUsluga.ShowDialog();
        }

        private void UrediUslugu_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Usluga evidencijaUsluga = new Evidencija_Usluga(false);
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
        }

        private static void BackupBaze()
        {
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
           // startInfo.UserName = "Administrator";
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
                cmd.StandardInput.WriteLine(@"pg_dump -U postgres -f C:\Users\Public\Documents\BikeZone___"
                                            + DateTime.Today.ToShortDateString() + ".sql BikeZone");
                cmd.StandardInput.Close();
            }
            MessageBox.Show(@"Uspješno napravljen backup, nalazi se na C:\Users\Public\Documents");
        }

        private void restoreBazePodatakaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread dretva = new Thread(new ThreadStart(RestoreBaze));
            dretva.SetApartmentState(ApartmentState.STA);
            dretva.Start();
        }


        private static void RestoreBaze()
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
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
                        MessageBox.Show(FD.FileName);
                        cmd.StandardInput.WriteLine(@"psql -U postgres -f " + FD.FileName + " BikeZone3");
                        MessageBox.Show("tu");
                        cmd.StandardInput.Close();
                    }
                    MessageBox.Show(@"Uspješno napravljen restore!");
                }
                catch
                {
                    MessageBox.Show("Nije uspješno napravljen restore!");
                }
            }
        }

        private void dodajToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Evidencija_Klijenata evidencijaKlijenata = new Evidencija_Klijenata(false);
            evidencijaKlijenata.ShowDialog();
        }

        private void urediToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Evidencija_Klijenata evidencijaKlijenata = new Evidencija_Klijenata(true);
            evidencijaKlijenata.ShowDialog();
        }
    }
}
