using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeZone.Podobrasci
{
    public partial class Evidencija_Primke : Form
    {
        private bool DodajNovuPrimku;

        public Evidencija_Primke(bool dodajNovuPrimku, DataGridViewRow primka = null)
        {
            InitializeComponent();

            UnesiDobavljaceUPadajuciIzbornik();

            this.DodajNovuPrimku = dodajNovuPrimku;

            //Ovisno o tome dodajemo li novu primku ili ažuriramo postojeću primku, popunjavaju se polja i/ili datagrid sa stavkama primke
            if (dodajNovuPrimku == true)
            {
                PodaciOPrimci.Text = "Dodaj novu primku";
                EvidencijaPrimke_btn.Text = "Dodaj";

                //upisujemo zaglavlje u datagrid sa stavkama primke
                string upit = "SELECT \"StavkePrimke\".\"idDijelaBicikla\", \"DijeloviBicikli\".naziv AS \"Naziv robe\", \"StavkePrimke\".kolicina AS \"Količina\", \"StavkePrimke\".cijena AS \"Jedinična nabavna cijena\" FROM \"StavkePrimke\" JOIN \"DijeloviBicikli\" USING (\"idDijelaBicikla\") WHERE false";
                using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    StavkePrimke_datagrid.DataSource = dt;
                }
                UrediPostavkeDatagrida();
            }
            else
            {
                PodaciOPrimci.Text = "Promijeni postojeću primku";
                EvidencijaPrimke_btn.Text = "Ažuriraj";
                //popunjavamo polja s informacijama
                Dobavljaci_combobox.SelectedValue = int.Parse(primka.Cells["dobavljac"].Value.ToString());
                DatumZaprimanja_datepicker.Text = primka.Cells["Datum dospijeća"].Value.ToString();
                if (primka.Cells["Plaćeno"].Value.ToString() == "True")
                {
                    Placeno_checkbox.Checked = true;
                }
                else
                {
                    Placeno_checkbox.Checked = false;
                }

                //popunjavamo datagrid sa stavkama primke
                string idPrimke = primka.Cells["idPrimke"].Value.ToString();
                string upit = "SELECT \"StavkePrimke\".\"idDijelaBicikla\", \"DijeloviBicikli\".naziv AS \"Naziv robe\", \"StavkePrimke\".kolicina AS \"Količina\", \"StavkePrimke\".cijena AS \"Jedinična nabavna cijena\" FROM \"StavkePrimke\" JOIN \"DijeloviBicikli\" USING (\"idDijelaBicikla\") WHERE primka = " + idPrimke;
                using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    while (dr.Read())
                    {
                        dt.Load(dr);
                    }
                    StavkePrimke_datagrid.DataSource = dt;
                }

                UrediPostavkeDatagrida();
            }
        }


        /// <summary>
        /// Ova metoda služi za uređivanje vizualnih postavki datagrida
        /// </summary>
        private void UrediPostavkeDatagrida()
        {
            //skrivamo stupac u kojem se nalazi idDijelaBicikla
            StavkePrimke_datagrid.Columns[0].Visible = false;
            //zaključavamo datagrid kako bi spriječili direktne promjene u njemu (za to imamo obrazac)
            StavkePrimke_datagrid.ReadOnly = true;
            //sprječavamo da korisnik selektira više redaka
            StavkePrimke_datagrid.MultiSelect = false;
            //omogućavamo full row select umjesto single column select
            StavkePrimke_datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //sprječavamo korisnika da dodaje nove zapise u datagrid
            StavkePrimke_datagrid.AllowUserToAddRows = false;
        }


        private void UnesiDobavljaceUPadajuciIzbornik()
        {
            string upit = "SELECT \"idDobavljaca\", \"nazivDobavljaca\" FROM \"Dobavljaci\"";
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                while (dr.Read())
                {
                    dt.Load(dr);
                }
                Dobavljaci_combobox.DataSource = dt;
                Dobavljaci_combobox.DisplayMember = "nazivDobavljaca";
                Dobavljaci_combobox.ValueMember = "idDobavljaca";
            }
        }

        private void Odustani_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DodajStavkuPrimke_btn_Click(object sender, EventArgs e)
        {
            Evidencija_Stavke_Primke evidencijaStavkePrimke = new Evidencija_Stavke_Primke();
            evidencijaStavkePrimke.ShowDialog();

            //podatke koje je prethodni obrazac zapisao u globalne varijable sada dohvaćamo i zapisujemo pomoću DataRow-a u DataTable
            if (evidencijaStavkePrimke.odustani == false)
            {
                //dodajemo novi redak u prethodni obrazac
                DataTable dt = StavkePrimke_datagrid.DataSource as DataTable;
                DataRow stavka = dt.NewRow();
                stavka["idDijelaBicikla"] = evidencijaStavkePrimke.idProizvoda;
                stavka["Naziv robe"] = evidencijaStavkePrimke.nazivProizvoda;
                stavka["Količina"] = evidencijaStavkePrimke.kolicina;
                stavka["Jedinična nabavna cijena"] = evidencijaStavkePrimke.cijena;

                dt.Rows.Add(stavka);
                StavkePrimke_datagrid.DataSource = dt;
            }
        }

        private void UrediStavkuPrimke_btn_Click(object sender, EventArgs e)
        {
            if (StavkePrimke_datagrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Odaberite stavku primke za promjenu!");
            }
            else
            {
                Evidencija_Stavke_Primke evidencijaStavkePrimke = new Evidencija_Stavke_Primke();
                evidencijaStavkePrimke.ShowDialog();

                //podatke koje je prethodni obrazac zapisao u globalne varijable sada dohvaćamo i zapisujemo u DataGrid
                StavkePrimke_datagrid.CurrentRow.Cells["idDijelaBicikla"].Value = evidencijaStavkePrimke.idProizvoda;
                StavkePrimke_datagrid.CurrentRow.Cells["Naziv robe"].Value = evidencijaStavkePrimke.nazivProizvoda;
                StavkePrimke_datagrid.CurrentRow.Cells["Količina"].Value = evidencijaStavkePrimke.kolicina;
                StavkePrimke_datagrid.CurrentRow.Cells["Jedinična nabavna cijena"].Value = evidencijaStavkePrimke.cijena;
            }
        }

        private void ObrisiStavkuPrimke_btn_Click(object sender, EventArgs e)
        {
            if (StavkePrimke_datagrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Odaberite stavku primke za brisanje!");
            }
            else
            {
                int idOznacenogReda = StavkePrimke_datagrid.CurrentRow.Index;
                StavkePrimke_datagrid.Rows.RemoveAt(idOznacenogReda);
            }
        }

        private void EvidencijaPrimke_btn_Click(object sender, EventArgs e)
        {
            if (DodajNovuPrimku == true)
            {
                string upit = string.Format("INSERT INTO \"Primke\" (datum, placeno, dobavljac) VALUES ('{0}', {1}, {2})", DatumZaprimanja_datepicker.Text, Placeno_checkbox.Checked.ToString(), Dobavljaci_combobox.SelectedValue);
                DB.Instance.izvrsi_upit(upit);

                foreach (DataGridViewRow red in StavkePrimke_datagrid.Rows)
                {
                    
                }
            }
            else
            {
                
            }
        }
        
    }
}
