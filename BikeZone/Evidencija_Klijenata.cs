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
    public partial class Evidencija_Klijenata : Form
    {
        private bool Dodaj_Promijeni { get; set; }

        public Evidencija_Klijenata(bool dodajPromijeni)
        {
            InitializeComponent();
            Dodaj_Promijeni = dodajPromijeni;
            this.CenterToParent();
            if (dodajPromijeni == true)
            {
                grpDodajPromijeni.Text = "Uredi klijenta";
            }
            else
            {
                grpDodajPromijeni.Text = "Dodaj klijenta";
            }
            selektiraj_klijente();
        }

        private void selektiraj_klijente()
        {
            string upit = string.Format("SELECT \"idKlijenta\", ime AS \"Ime\", prezime AS \"Prezime\", telefon AS \"Telefon\" FROM \"Klijenti\"");
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void upisi_klijenta_u_kontrole()
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Nema niti jednog klijenta!");
            }
            else
            {
                #region upisi podatke u kontrole

                int indeks = dataGridView1.CurrentCell.RowIndex;
                txtIme.Text=dataGridView1.Rows[indeks].Cells[1].Value.ToString();
                txtPrezime.Text = dataGridView1.Rows[indeks].Cells[2].Value.ToString();
                txtTelefon.Text = dataGridView1.Rows[indeks].Cells[3].Value.ToString();

                #endregion
            }
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Ne mogu obaviti brisanje klijenta!");
            }
            else
            {
                string upit = string.Format("DELETE FROM" +
                    "\"Klijenti\" WHERE \"idKlijenta\"='{0}';"
                    , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                DB.Instance.izvrsi_upit(upit);
                MessageBox.Show("Uspješno obrisan klijent!");
                selektiraj_klijente();
                if (Dodaj_Promijeni == true)
                {
                   upisi_klijenta_u_kontrole();
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (Dodaj_Promijeni == true)
            {
                upisi_klijenta_u_kontrole();
            }
        }

        private void btnEvidentiraj_Click(object sender, EventArgs e)
        {
             string upit = "";

             if (txtIme.Text == "")
             {
                 MessageBox.Show("Niste unijeli ime");
             }
             else if (txtPrezime.Text == "")
             {
                 MessageBox.Show("Niste unijeli prezime");
             }
             else if (txtTelefon.Text == "")
             {
                 MessageBox.Show("Niste unijeli telefon");
             }

             else
             {
                 try
                 {
                     if (Dodaj_Promijeni == true)
                     {
                         int indeks = dataGridView1.CurrentCell.RowIndex;
                         upit = string.Format("UPDATE \"Klijenti\" SET ime='{0}',prezime='{1}',telefon='{2}' WHERE \"idKlijenta\"='{3}';",
                                                txtIme.Text, txtPrezime.Text, txtTelefon.Text, dataGridView1.Rows[indeks].Cells[0].Value.ToString());
                         MessageBox.Show("Uspješno ažuriran klijent");
                     }
                     else
                     {
                         upit = string.Format("INSERT INTO \"Klijenti\" VALUES (DEFAULT,'{0}','{1}','{2}');", txtIme.Text, txtPrezime.Text, txtTelefon.Text);
                         MessageBox.Show("Uspješno upisan klijent");
                     }
                     DB.Instance.izvrsi_upit(upit);

                     txtIme.Text = "";
                     txtPrezime.Text = "";
                     txtTelefon.Text = "";

                     selektiraj_klijente();
                 }
                 catch
                 {
                     MessageBox.Show("Nije uspješno upisano!");
                 }
             }
        }
    }
}
