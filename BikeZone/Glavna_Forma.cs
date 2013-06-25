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
        public int Id_zaposlenika { get; set; }

        public Glavna_Forma(int idZaposlenika)
        {
            InitializeComponent();
            Id_zaposlenika = idZaposlenika;
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

        private void dodajDobavljaca_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Dobavljaca evidencijaDobavljaca = new Evidencija_Dobavljaca(true);
            evidencijaDobavljaca.ShowDialog();
        }

        private void urediDobavljaca_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Dobavljaca evidencijaDobavljaca = new Evidencija_Dobavljaca(false);
            evidencijaDobavljaca.ShowDialog();
        }

        private void dodajZaoposlenika_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Zaposlenika evidencijaZaposlenika = new Evidencija_Zaposlenika(false, Id_zaposlenika);
            evidencijaZaposlenika.ShowDialog();
        }

        private void urediZaoposlenika_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Zaposlenika evidencijaZaposlenika = new Evidencija_Zaposlenika(true, Id_zaposlenika);
            evidencijaZaposlenika.ShowDialog();
        }

        private void urediProizvod_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Proizvoda evidencijaProizvoda = new Evidencija_Proizvoda(true);
            evidencijaProizvoda.ShowDialog();
        }

        private void dodajProizvod_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Proizvoda evidencijaProizvoda = new Evidencija_Proizvoda(false);
            evidencijaProizvoda.ShowDialog();
        }

        private void backupBazePodataka_Menu_Click(object sender, EventArgs e)
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

        private void dodajKlijenta_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Klijenata evidencijaKlijenata = new Evidencija_Klijenata(false);
            evidencijaKlijenata.ShowDialog();
        }

        private void urediKlijenta_Menu_Click(object sender, EventArgs e)
        {
            Evidencija_Klijenata evidencijaKlijenata = new Evidencija_Klijenata(true);
            evidencijaKlijenata.ShowDialog();
        }

        private void racuni_Menu_Click(object sender, EventArgs e)
        {
            Racuni racuni = new Racuni();
            racuni.ShowDialog();
        }

        private void primke_Menu_Click(object sender, EventArgs e)
        {
            Primke primka = new Primke();
            primka.ShowDialog();
        }
    }
}
