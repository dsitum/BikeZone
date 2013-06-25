using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeZone
{
    public partial class Evidencija_Usluga : Form
    {
        public bool DodajNovuUslugu;

        public Evidencija_Usluga(bool dodajNovuUslugu)
        {
            InitializeComponent();
            this.CenterToParent();
            //sprječavamo mogućnost uređivanja combobox-a
            DioZaPopravak_combobox.DropDownStyle = ComboBoxStyle.DropDownList;

            if (dodajNovuUslugu == true)
            {
                Usluga_groupbox.Text = "Dodaj novu uslugu:";
                UnosUBazu_btn.Text = "Dodaj";
                DodajNovuUslugu = true;
            }
            else
            {
                Usluga_groupbox.Text = "Promijeni postojeću uslugu:";
                UnosUBazu_btn.Text = "Ažuriraj";
                DodajNovuUslugu = false;
            }

            UnesiPodatkeUDatagrid();
            UnesiDijeloveUPadajućiIzbornik();
        }


        /// <summary>
        /// Upiši postojeće popravke u Datagrid
        /// </summary>
        private void UnesiPodatkeUDatagrid()
        {
            string upit = "SELECT \"Popravci\".\"idPopravka\", \"Popravci\".naziv AS \"Naziv Popravka\", \"idTipa\", \"TipDijelaBicikla\".naziv AS \"Dio\", \"PopravciDijeloviBicikli\".cijena AS \"Cijena\" FROM \"Popravci\" JOIN \"TipDijelaBicikla\" USING (\"idTipa\") JOIN \"PopravciDijeloviBicikli\" ON \"Popravci\".\"idPopravka\" = \"PopravciDijeloviBicikli\".id";
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

            //skrivamo stupce u kojima se nalaze ID popravka i ID dijela za popravak
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            //zaključavamo datagrid kako bi spriječili direktne promjene u njemu (za to imamo obrazac)
            dataGridView1.ReadOnly = true;
            //sprječavamo da korisnik selektira više redaka
            dataGridView1.MultiSelect = false;
            //omogućavamo full row select umjesto single column select
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //sprječavamo korisnika da dodaje nove zapise u datagrid
            dataGridView1.AllowUserToAddRows = false;
        }


        /// <summary>
        /// Unose se tipovi dijelova na biciklu (npr. kotač, prednji mjenač, ...) u padajući izbornik
        /// </summary>
        private void UnesiDijeloveUPadajućiIzbornik()
        {
            string upit = "SELECT \"idTipa\", naziv FROM \"TipDijelaBicikla\" WHERE NOT bicikl";
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                while (dr.Read())
                {
                    dt.Load(dr);
                }
                DioZaPopravak_combobox.DataSource = dt;
                DioZaPopravak_combobox.DisplayMember = "naziv";
                DioZaPopravak_combobox.ValueMember = "idTipa";
            }
        }


        /// <summary>
        /// Kada se klikne na dugme za dodavanje/ažuriranje, ažuriraju se podaci unutar baze podataka
        /// </summary>
        private void UnosUBazu_btn_Click(object sender, EventArgs e)
        {
            //Prije unosa podataka u bazu provjeravamo jesu li u polja uneseni svi podaci
            Regex reg = new Regex(@"^\d+(\.\d+)?$");

            if (! reg.IsMatch(Cijena_textbox.Text))
            {
                MessageBox.Show("Polje s cijenom mora sadržavati cijeli ili decimalni broj s decimalnom točkom!");
            }
            else if (OpisPopravka_textbox.Text == "")
            {
                MessageBox.Show("Unesite naziv popravka!");
            }
            else if (DioZaPopravak_combobox.SelectedIndex == -1)
            {
                MessageBox.Show("Odaberite barem jedan dio iz padajućeg izbornika");
            }
            else
            {
                //Ako su svi podaci uneseni, provjeravamo radi li se o unosu nove usluge ili promjeni postojeće
                if (DodajNovuUslugu == true)
                {
                    //Ako se radi o dodavanju nove vrste popravka, dodamo novi zapis u BP. P označava da se radi o unosu popravka
                    string upit = string.Format("INSERT INTO \"PopravciDijeloviBicikli\" (id, cijena, popravci_ili_dijelovibicikli) VALUES (DEFAULT, {0}, 'P')", Cijena_textbox.Text);
                    DB.Instance.izvrsi_upit(upit);

                    //potom saznajemo ID upravo dodanog retka i koristimo ga za unos u tablicu popravaka
                    upit = "SELECT MAX(id) FROM \"PopravciDijeloviBicikli\"";
                    string maxId;
                    using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                    {
                        dr.Read();
                        maxId = dr[0].ToString();
                    }

                    //I na kraju zapis s ID-om koji smo sanzali dodajemo u tablicu Popravci
                    upit = string.Format("INSERT INTO \"Popravci\" (\"idPopravka\", naziv, \"idTipa\") VALUES ({0}, '{1}', {2})", maxId, OpisPopravka_textbox.Text, DioZaPopravak_combobox.SelectedValue);
                    DB.Instance.izvrsi_upit(upit);

                    //na kraju ažuriramo datagridview s novim podacima
                    UnesiPodatkeUDatagrid();

                    //i praznimo sva polja za unos
                    OpisPopravka_textbox.Text = "";
                    Cijena_textbox.Text = "";
                    DioZaPopravak_combobox.SelectedIndex = 0;
                }
                else
                {
                    //Ako se radi o uređivanju postojećeg popravka

                    //najprije dohvaćamo sve potrebne podatke selektiranog popravka
                    //provjeravamo je li barem jedan red selektiran kako se ne bi dogodilo da pokušavamo ažurirati redak u slučaju kada su datagrid i tablica u bazi prazni
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        string idPopravka = dataGridView1.CurrentRow.Cells[0].Value.ToString();


                        //Ažuriramo cijenu postojećeg zapisa u bazi podataka
                        string upit = string.Format("UPDATE \"PopravciDijeloviBicikli\" SET cijena={0} WHERE id={1}", Cijena_textbox.Text, idPopravka);
                        DB.Instance.izvrsi_upit(upit);

                        //Nakon toga ažuriramo ostale podatke
                        upit = string.Format("UPDATE \"Popravci\" SET naziv = '{0}', \"idTipa\" = {1} WHERE \"idPopravka\" = {2}", OpisPopravka_textbox.Text, DioZaPopravak_combobox.SelectedValue, idPopravka);
                        DB.Instance.izvrsi_upit(upit);

                        //na kraju ažuriramo datagridview s novim podacima
                        UnesiPodatkeUDatagrid();
                        MessageBox.Show("Popravak ažuriran");
                    }
                    else
                    {
                        MessageBox.Show("Niti jedan redak nije odabran!");
                    }
                }
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //funkcija se izvršava jedino u slučaju kada je korisnik u modu za ažuriranje i kada je označen jedan redak
            if (DodajNovuUslugu == false && dataGridView1.SelectedRows.Count == 1)
            {
                //Popunjavamo polja za unos s podacima iz datagrida
                OpisPopravka_textbox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Cijena_textbox.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                DioZaPopravak_combobox.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }


        private void Obrisi_btn_Click(object sender, EventArgs e)
        {
            //najprije provjeravamo je li označen ijedan redak u datagridu
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niti jedan redak nije označen!");
            }
            else
            {
                DialogResult odgovor = MessageBox.Show("Jeste li sigurni da želite obrisati odabranu uslugu?", "Potvrda Brisanja", MessageBoxButtons.YesNo);
                if (odgovor == DialogResult.Yes)
                {
                    string idSelektiranogReda = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string upit = "DELETE FROM \"PopravciDijeloviBicikli\" WHERE id = " + idSelektiranogReda;
                    DB.Instance.izvrsi_upit(upit);
                }

                //praznimo sva polja za unos
                OpisPopravka_textbox.Text = "";
                Cijena_textbox.Text = "";

                //na kraju ažuriramo datagridview s novim podacima
                UnesiPodatkeUDatagrid();
            }
        }
    }
}
