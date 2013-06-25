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
        public bool DodajNovogDobavljaca { get; set; }

        public Evidencija_Dobavljaca(bool dodajNovogDobavljaca)
        {
            InitializeComponent();
            this.CenterToParent();
            this.DodajNovogDobavljaca = dodajNovogDobavljaca;
                        
            selektiraj_dobavljace();
        }

        private void selektiraj_dobavljace()
        {
            string upit = string.Format("SELECT \"idDobavljaca\", \"nazivDobavljaca\" AS \"Naziv Dobavljača\", adresa AS \"Adresa\", telefon AS \"Telefon\" FROM \"Dobavljaci\"");
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                while (dr.Read())
                {
                    dt.Load(dr);
                }
                dataGridView1.DataSource = dt;
            }
            dataGridView1.Columns[0].Visible = false;
        }

        private void upisi_dobavljaca_u_kontrole()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Nema niti jednog dobavljaca!");
            }
            else
            {
                #region upisi podatke u kontrole

                txtNaziv.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtAdresa.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtTelefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                #endregion
            }
        }

        private void btnEvidentiraj_Click(object sender, EventArgs e)
        {
            string upit = "";

            if (txtNaziv.Text == "")
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
                    if (DodajNovogDobavljaca == true)
                    {
                        upit = string.Format("INSERT INTO \"Dobavljaci\" (\"idDobavljaca\", \"nazivDobavljaca\", adresa, telefon) VALUES (DEFAULT,'{0}','{1}','{2}')", txtNaziv.Text, txtAdresa.Text, txtTelefon.Text);
                        MessageBox.Show("Dobavljač unesen u bazu");
                        DB.Instance.izvrsi_upit(upit);
                    }
                    else
                    {
                        string idDobavljaca = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        upit = string.Format("UPDATE \"Dobavljaci\" SET \"nazivDobavljaca\" = '{0}', adresa = '{1}', telefon = '{2}' WHERE \"idDobavljaca\" = {3}", txtNaziv.Text, txtAdresa.Text, txtTelefon.Text, idDobavljaca);
                        DB.Instance.izvrsi_upit(upit);
                    }

                    txtAdresa.Text = "";
                    txtNaziv.Text = "";
                    txtTelefon.Text = "";

                    selektiraj_dobavljace();
            }
        }

        private void Obrisi_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Na popisu ne postoji niti jedan dobavljač!");
            }
            else
            {
                if (MessageBox.Show("Jeste li sigurni da želite obrisati dobavljača?", "Brisanje dobavljača", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string upit = "DELETE FROM \"Dobavljaci\" WHERE \"idDobavljaca\" = " + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        DB.Instance.izvrsi_upit(upit);
                        selektiraj_dobavljace();

                        if (DodajNovogDobavljaca == false)
                        {
                            upisi_dobavljaca_u_kontrole();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Nemoguće obrisati dobavljača! Obrišite najprije njegove primke");
                    }
                }
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (DodajNovogDobavljaca == false)
            {
                upisi_dobavljaca_u_kontrole();
            }
        }
            
      }
}
