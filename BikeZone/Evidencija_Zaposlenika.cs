#region biblioteke
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
                txtEmail.Text = dataGridView1.Rows[indeks].Cells[1].Value.ToString();
                txtIme.Text = dataGridView1.Rows[indeks].Cells[2].Value.ToString();
                txtKorisnicko.Text = dataGridView1.Rows[indeks].Cells[3].Value.ToString();
                txtLozinka.Text = dataGridView1.Rows[indeks].Cells[4].Value.ToString();
                txtPlaca.Text = dataGridView1.Rows[indeks].Cells[7].Value.ToString();
                txtPrezime.Text = dataGridView1.Rows[indeks].Cells[6].Value.ToString();
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
