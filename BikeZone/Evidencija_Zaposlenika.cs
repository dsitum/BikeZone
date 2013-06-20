﻿#region biblioteke
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
#endregion

namespace BikeZone
{
    public partial class Evidencija_Zaposlenika : Form
    {
        private bool dodaj_promijeni;
        private string id;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dodaj_promijeni">Ako je true onda se radi o dodavanju novog zaposlenika, ako je false onda mijenjamo postojeceg clana</param>
        public Evidencija_Zaposlenika(bool dodaj_promijeni)
        {
            InitializeComponent();
            this.CenterToParent();
            this.dodaj_promijeni = dodaj_promijeni;
            selektirajZaposlenike();
            if (dodaj_promijeni == false)
            {
                grpEvidencija.Text = "Dodaj zaposlenika";
            }
            else
            {
                grpEvidencija.Text = "Uredi zaposlenika";
            }
        }

        private void upisi_zaposlenika_u_kontrole()
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Nema niti jednog zaposlenika!");
            }
            else
            {
                #region Ubaci selektirane podatke u kontrole

                int indeks = dataGridView1.CurrentCell.RowIndex;
                id = dataGridView1.Rows[indeks].Cells[0].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[indeks].Cells[6].Value.ToString();
                txtIme.Text = dataGridView1.Rows[indeks].Cells[3].Value.ToString();
                txtKorisnicko.Text = dataGridView1.Rows[indeks].Cells[1].Value.ToString();
                txtLozinka.Text = dataGridView1.Rows[indeks].Cells[2].Value.ToString();
                txtPlaca.Text = dataGridView1.Rows[indeks].Cells[7].Value.ToString();
                txtPrezime.Text = dataGridView1.Rows[indeks].Cells[4].Value.ToString();
                txtTelefon.Text = dataGridView1.Rows[indeks].Cells[5].Value.ToString();

                #endregion
            }
        }

        private void selektirajZaposlenike()
        {
            string upit = string.Format("SELECT*FROM \"Zaposlenici\";");
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Ne mogu obaviti brisanje zaposlenika!");
            }
            else
            {
                string upit = string.Format("DELETE FROM" +
                    "\"Zaposlenici\" WHERE \"idZaposlenika\"='{0}';"
                    , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                DB.Instance.izvrsi_upit(upit);
                MessageBox.Show("Uspješno obrisan zaposlenik!");
                selektirajZaposlenike();
                if (dodaj_promijeni == true)
                {
                    upisi_zaposlenika_u_kontrole();
                }
            }
        }

        private void btnEvidentiraj_Click(object sender, EventArgs e)
        {
            #region Provjera jesu li pravilno upisani podaci

            if (txtTelefon.Text == "")
            {
                MessageBox.Show("Niste upisali telefon!");
            }
            else if (txtPrezime.Text == "")
            {
                MessageBox.Show("Niste upisali prezime!");
            }
            else if (txtPlaca.Text == "")
            {
                MessageBox.Show("Niste upisali plaću!");
            }
            else if (txtLozinka.Text == "")
            {
                MessageBox.Show("Niste upisali lozinku!");
            }
            else if (txtKorisnicko.Text == "")
            {
                MessageBox.Show("Niste upisali korisničko ime!");
            }
            else if (txtIme.Text == "")
            {
                MessageBox.Show("Niste upisali ime!");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Niste upisali Email!");
            }

            #endregion

            string upit = "";

            try
            {
                if(dodaj_promijeni==true){
                    upit = string.Format("UPDATE \"Zaposlenik\" SET \"korisnickoIme\"='{0}', lozinka='{1}', ime='{2}', prezime='{3}', telefon='{4}', email='{5}', placa='{6}'"
                        + " WHERE \"idZaposlenika\"='{7}';",txtKorisnicko.Text, txtLozinka.Text, txtIme.Text,txtPrezime.Text,txtTelefon.Text,txtEmail.Text,txtPlaca.Text,
                        id);
                    MessageBox.Show(upit);
                }
                else{

                }
            }
            catch
            {
                MessageBox.Show("Nije uspješno ažurirano");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dodaj_promijeni == true)
            {
                upisi_zaposlenika_u_kontrole();
            }
        }
    }
}
