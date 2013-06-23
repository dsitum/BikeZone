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
using System.Text.RegularExpressions;

#endregion

namespace BikeZone
{
    public partial class Evidencija_Proizvoda : Form
    {
        private bool Dodaj_Promijeni { get; set; }
        private string id { get; set; }

        /// <summary>
        /// Upiši podatke u datagrid 
        /// </summary>
        /// <param name="dodaj_promijeni">Da znamo radi li se o uređivanju proizvoda ili dodavanju novog</param>
        public Evidencija_Proizvoda(bool dodaj_promijeni)
        {
            InitializeComponent();
            this.CenterToParent();
            Dodaj_Promijeni = dodaj_promijeni;
            if (Dodaj_Promijeni == false)
            {
                groupBox1.Text = "Dodaj proizvod";
            }
            else
            {
                groupBox1.Text = "Uredi proizvod";
            }
            selektiraj_proizvode();
        }




        /// <summary>
        /// popuni datagridview sa proizvodima i nazivom kategorije kojoj ti proizvodi pripadaju
        /// popuni combo box tippovi proizvoda sa pripadajućim tipovima proizvoda
        /// </summary>
        private void selektiraj_proizvode()
        {
            string upit = string.Format("SELECT \"idDijelaBicikla\", \"DijeloviBicikli\".naziv, \"TipDijelaBicikla\".naziv AS \"Tip dijela\",\"TipDijelaBicikla\".bicikl, \"godinaProizvodnje\","
                                        +" kolicina, \"minimalnaKolicina\", cijena FROM \"DijeloviBicikli\" JOIN \"TipDijelaBicikla\" ON \"DijeloviBicikli\".\"idTipa\"="
                                        +"\"TipDijelaBicikla\".\"idTipa\";");
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            if (chkBicikl.Checked)
            {
                upit = "SELECT \"idTipa\",naziv FROM \"TipDijelaBicikla\" WHERE bicikl=true;";
            }
            else
            {
                upit = "SELECT \"idTipa\",naziv FROM \"TipDijelaBicikla\" WHERE bicikl=false;";
            }
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                cmbTip.Items.Clear();
                while (dr.Read())
                {
                    cmbTip.Items.Add(dr["idTipa"].ToString() + " " + dr["naziv"].ToString());
                }
                cmbTip.SelectedIndex = 0;
            }
        }



        /// <summary>
        /// Kad se klikne evidentiraj,
        /// prvo se provjeri jesu li svi podaci uneseni u kontrole ispravno,
        /// zatim se provjeri radi li se o insert ili update upitu, pa se prema tome generira sql
        /// napravi se upit i refreshaju se podaci u datagridu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            #region provjeri podatke u tekstualnim okvirima

            Regex reg = new Regex("^[0-9]{4,4}$");

            if (!reg.IsMatch(txtGodina.Text))
            {
                MessageBox.Show("Krivo ste unijeli godinu!");
            }
            else if (txtGodina.Text == "")
            {
                MessageBox.Show("Morate unijeti godinu");
            }
            else if (txtCijena.Text == "")
            {
                MessageBox.Show("Morate unijeti cijenu");
            }
            else if (txtKolicina.Text == "")
            {
                MessageBox.Show("Morate unijeti količinu");
            }
            else if (txtMinKolicina.Text == "")
            {
                MessageBox.Show("Morate unijeti minimalnu količinu");
            }
            else if (txtNaziv.Text == "")
            {
                MessageBox.Show("Morate unijeti naziv");
            }

            #endregion

            else
            {
                string upit = "";
                string id_tip = "";
                foreach (char c in cmbTip.Text)
                {
                    if (c == ' ') break;
                    else
                    {
                        id_tip += c;
                    }
                }
                if (Dodaj_Promijeni == true)
                {

                    int indeks = dataGridView1.CurrentCell.RowIndex;
                    upit = string.Format("UPDATE \"DijeloviBicikli\" SET naziv='{0}', \"idTipa\"='{1}',\"godinaProizvodnje\"='{2}',"
                                       + "kolicina='{3}',\"minimalnaKolicina\"='{4}',cijena='{5}' WHERE \"idDijelaBicikla\"='{6}';"
                                       , txtNaziv.Text, id_tip, txtGodina.Text, txtKolicina.Text, txtMinKolicina.Text, txtCijena.Text, dataGridView1.Rows[indeks].Cells[0].Value.ToString());
                }
                else
                {
                    upit = "INSERT INTO \"PopravciDijeloviBicikli\" VALUES(DEFAULT,'D');";
                    DB.Instance.izvrsi_upit(upit);

                    upit = "SELECT MAX(id) FROM \"PopravciDijeloviBicikli\";";
                    string id = "";
                    using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                    {
                        while (dr.Read())
                        {
                            id = dr[0].ToString();
                        }
                    }
                    upit = string.Format("INSERT INTO \"DijeloviBicikli\" VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}');",
                                        txtNaziv.Text, id_tip, txtGodina.Text, txtKolicina.Text, txtMinKolicina.Text, txtCijena.Text, id);
                }

                DB.Instance.izvrsi_upit(upit);

                #region isprazni kontrole

                txtCijena.Text = "";
                txtGodina.Text = "";
                txtKolicina.Text = "";
                txtMinKolicina.Text = "";
                txtNaziv.Text = "";

                #endregion

                MessageBox.Show("Uspješno izvršen upit");
                selektiraj_proizvode();
            }
        }


        /// <summary>
        /// Izbriši proizvod i ukoliko se radi o formi za uređivanje proizvoda, 
        /// ponovno ubaci selektirani proizvod unutar tekstualnih okvira i kontrola
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Ne mogu obaviti brisanje proizvoda!");
            }
            else
            {
                string upit = string.Format("DELETE FROM" +
                   "\"DijeloviBicikli\" WHERE \"idDijelaBicikla\"='{0}';"
                   , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                DB.Instance.izvrsi_upit(upit);

                upit = string.Format("DELETE FROM" +
                   "\"PopravciDijeloviBicikli\" WHERE \"id\"='{0}';"
                   , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                DB.Instance.izvrsi_upit(upit);

                MessageBox.Show("Uspješno obrisan proizvod!");
                selektiraj_proizvode();
                if (Dodaj_Promijeni == true)
                {
                    //upisi proizvod u kontrole();
                }
            }
        }


        /// <summary>
        /// Ako se promijeni stanje checkboxa, selektiraj ili dijelove ili bicikle i ubaci ih unutar checkboxa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBicikl_CheckedChanged(object sender, EventArgs e)
        {
            string upit = "";
            if (chkBicikl.Checked)
            {
                upit = "SELECT \"idTipa\",naziv FROM \"TipDijelaBicikla\" WHERE bicikl=true;";
            }
            else
            {
                upit = "SELECT \"idTipa\",naziv FROM \"TipDijelaBicikla\" WHERE bicikl=false;";
            }
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                cmbTip.Items.Clear();
                while (dr.Read())
                {
                    cmbTip.Items.Add(dr["idTipa"].ToString() + " " + dr["naziv"].ToString());
                }
                cmbTip.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void upisi_proizvod_u_kontrole()
        {
            if (dataGridView1.Rows.Count == 1)
            {

            }
            else
            {
                #region popuni kontrole sa selektiranim podacima

                int indeks = dataGridView1.CurrentCell.RowIndex;
                id = dataGridView1.Rows[indeks].Cells[0].Value.ToString();

                txtNaziv.Text = dataGridView1.Rows[indeks].Cells[1].Value.ToString();
                int i = 0;
                foreach (string dio in cmbTip.Items)
                {
                    if (string.Compare(dataGridView1.Rows[indeks].Cells[2].ToString(),dio) == 0)
                    {
                        cmbTip.SelectedIndex = i;
                    }
                    i++;
                }

                if (string.Compare(dataGridView1.Rows[indeks].Cells[3].Value.ToString(), "True") == 0)
                {
                    chkBicikl.Checked = true;
                }

                else
                {
                    chkBicikl.Checked = false;
                }

                txtGodina.Text = dataGridView1.Rows[indeks].Cells[4].Value.ToString();
                txtKolicina.Text = dataGridView1.Rows[indeks].Cells[5].Value.ToString();
                txtMinKolicina.Text = dataGridView1.Rows[indeks].Cells[6].Value.ToString();
                txtCijena.Text = dataGridView1.Rows[indeks].Cells[7].Value.ToString();

                #endregion
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (Dodaj_Promijeni == true)
            {
                upisi_proizvod_u_kontrole();
                int indeks = dataGridView1.CurrentCell.RowIndex;
                picSlika.ImageLocation = @"..\..\Slike/Proizvodi/" + dataGridView1.Rows[indeks].Cells[0].Value.ToString() + ".jpg";
            }
        }
        

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string upit = "SELECT MAX(id)+1 FROM \"PopravciDijeloviBicikli\";";
                string id = "";
                using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                {
                    while (dr.Read())
                    {
                        id = dr[0].ToString();
                    }
                }
                string fileToOpen = FD.FileName;
                if (Dodaj_Promijeni == false)
                {
                    try
                    {
                        System.IO.File.Delete(@"..\..\Slike/Proizvodi/" + (id).ToString() + ".jpg");
                    }
                    catch
                    {

                    }
                    System.IO.File.Copy(FD.FileName, @"..\..\Slike/Proizvodi/" + (id).ToString() + ".jpg");
                    picSlika.ImageLocation=@"..\..\Slike/Proizvodi/"+(id).ToString()+".jpg";
                }
                else
                {
                    try
                    {
                        int indeks = dataGridView1.CurrentCell.RowIndex;
                        try
                        {
                            System.IO.File.Delete(@"..\..\Slike/Proizvodi/" + dataGridView1.Rows[indeks].Cells[0].Value.ToString() + ".jpg");
                        }
                        catch
                        {

                        }
                        System.IO.File.Copy(FD.FileName, @"..\..\Slike/Proizvodi/" + dataGridView1.Rows[indeks].Cells[0].Value.ToString() + ".jpg");
                        picSlika.ImageLocation = @"..\..\Slike/Proizvodi/" + dataGridView1.Rows[indeks].Cells[0].Value.ToString() + ".jpg";
                    }
                    catch
                    {

                    }
                }        
                MessageBox.Show("Uspješno pohranjena slika");
            }
        }
    }
}
