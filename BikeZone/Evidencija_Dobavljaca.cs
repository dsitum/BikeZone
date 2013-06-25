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
    public partial class Evidencija_Dobavljaca : Form
    {

        private bool Dodaj_Promijeni { get; set; }

        public Evidencija_Dobavljaca()
        {
            InitializeComponent();
            this.CenterToParent();
                        
            selektiraj_dobavljaca();
            
        }

        private void selektiraj_dobavljaca()
        {
            string upit = string.Format("SELECT*FROM \"Dobavljaci\";");
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
        }

        private void upisi_dobavljaca_u_kontrole()
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Nema niti jednog dobavljaca!");
            }
            else
            {
                #region upisi podatke u kontrole

                int indeks = dataGridView1.CurrentCell.RowIndex;
                txtSifra.Text = dataGridView1.Rows[indeks].Cells[1].Value.ToString();
                txtNaziv.Text = dataGridView1.Rows[indeks].Cells[2].Value.ToString();
                txtAdresa.Text = dataGridView1.Rows[indeks].Cells[3].Value.ToString();
                txtTelefon.Text = dataGridView1.Rows[indeks].Cells[4].Value.ToString();

                #endregion

                upisi_dobavljaca_u_kontrole();
            }
        }

        private void btnEvidentiraj_Click(object sender, EventArgs e)
        {
            string upit = "";

            if (txtSifra.Text == "")
            {
                MessageBox.Show("Niste unijeli šifru");
            }
            else if (txtNaziv.Text == "")
            {
                MessageBox.Show("Niste unijeli naziv");
            }

            else if (txtAdresa.Text == "")
            {
                MessageBox.Show("Niste unijeli adresu");
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
                        upit = string.Format("UPDATE \"Dobavljaci\" SET idDobavljaca='{0}',nazivDobavljaca='{1}', adresa='{2}',telefon='{3}' WHERE \"idDobavljaca\"='{0}';",
                                               txtSifra.Text, txtNaziv.Text, txtAdresa.Text, txtTelefon.Text, dataGridView1.Rows[indeks].Cells[0].Value.ToString());
                        MessageBox.Show("Uspješno ažuriran klijent");

                   }
                    else
                    {

                        upit = string.Format("INSERT INTO \"Dobavljaci\" VALUES ('{0}','{1}','{2}','{3}');", txtSifra.Text, txtNaziv.Text,txtAdresa.Text, txtTelefon.Text);
                        MessageBox.Show("Uspješno upisan klijent");
                    }
                    DB.Instance.izvrsi_upit(upit);

                    txtSifra.Text = "";
                    txtAdresa.Text = "";
                    txtNaziv.Text = "";
                    txtTelefon.Text = "";

                    selektiraj_dobavljaca();
                }
                catch
                {
                    MessageBox.Show("Nije uspješno upisano!");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Ne mogu obaviti brisanje dobavljača!");
            }

            
            if (MessageBox.Show("Da li želite zaista obrisati dobavljača?", "BikeZone ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string upit = string.Format("DELETE FROM" +
                         "\"Dobavljaci\" WHERE \"idDobavljaca\"='{0}';"
                         , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    DB.Instance.izvrsi_upit(upit);
                    MessageBox.Show("Uspješno obrisan Dobavljača!");
                    selektiraj_dobavljaca();
                    if (Dodaj_Promijeni == true)
                    {
                        upisi_dobavljaca_u_kontrole();
                    }
                }
            catch
                {
                    MessageBox.Show("Pogrešno ste odabrali!\nNe mogu obaviti brisanje dobavljača!");
                }
            }
                            
                                  
        }
            
      }
}
