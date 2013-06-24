using BikeZone.Podobrasci;
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

namespace BikeZone
{
    public partial class Primke : Form
    {
        public Primke()
        {
            InitializeComponent();

            UnesiPodatkeUDatagrid();
        }

        /// <summary>
        /// Unose se postojeće primke (bez njihovih stavki) u datagrid
        /// </summary>
        private void UnesiPodatkeUDatagrid()
        {
            string upit = "SELECT \"Primke\".\"idPrimke\", \"Primke\".datum AS \"Datum dospijeća\", \"Primke\".dobavljac, \"Dobavljaci\".\"nazivDobavljaca\" AS \"Naziv dobavljača\", \"Primke\".placeno AS \"Plaćeno\" FROM \"Primke\" JOIN \"Dobavljaci\" ON \"Primke\".dobavljac = \"Dobavljaci\".\"idDobavljaca\" ORDER BY 2";

            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                while (dr.Read())
                {
                    dt.Load(dr);
                }
                Primke_datagrid.DataSource = dt;

                //skrivamo stupce u kojima se nalaze ID primke i ID dobavljaca
                Primke_datagrid.Columns[0].Visible = false;
                Primke_datagrid.Columns[2].Visible = false;
                //zaključavamo datagrid kako bi spriječili direktne promjene u njemu (za to imamo obrazac)
                Primke_datagrid.ReadOnly = true;
                //sprječavamo da korisnik selektira više redaka
                Primke_datagrid.MultiSelect = false;
                //omogućavamo full row select umjesto single column select
                Primke_datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //sprječavamo korisnika da dodaje nove zapise u datagrid
                Primke_datagrid.AllowUserToAddRows = false;
            }
        }


        private void Primke_datagrid_SelectionChanged(object sender, EventArgs e)
        {
            //funkcija se izvršava jedino u slučaju kada je označen jedan redak
            if (Primke_datagrid.SelectedRows.Count == 1)
            {
                //Popunjavamo datagrid sa stavkama primke
                string idSelektiranePrimke = Primke_datagrid.CurrentRow.Cells[0].Value.ToString();
                string upit = "SELECT \"StavkePrimke\".\"idDijelaBicikla\", \"DijeloviBicikli\".naziv AS \"Naziv robe\", \"StavkePrimke\".kolicina AS \"Količina\", \"StavkePrimke\".cijena AS \"Jedinična nabavna cijena\" FROM \"StavkePrimke\" JOIN \"DijeloviBicikli\" USING (\"idDijelaBicikla\") WHERE \"StavkePrimke\".primka = " + idSelektiranePrimke;

                using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    while (dr.Read())
                    {
                        dt.Load(dr);
                    }
                    StavkePrimke_datagrid.DataSource = dt;

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
            }
        }

        private void DodajPrimku_btn_Click(object sender, EventArgs e)
        {
            Evidencija_Primke evidencijaPrimke = new Evidencija_Primke(true);
            evidencijaPrimke.ShowDialog();
        }

        private void PromijeniPrimku_btn_Click(object sender, EventArgs e)
        {
            if (Primke_datagrid.SelectedRows.Count == 1)
            {
                Evidencija_Primke evidencijaPrimke = new Evidencija_Primke(false, Primke_datagrid.CurrentRow);
                evidencijaPrimke.ShowDialog();
            }
            else
            {
                MessageBox.Show("Niti jedna primka nije odabrana!");
            }
        }

        private void ObrisiPrimku_btn_Click(object sender, EventArgs e)
        {
            //najprije provjeravamo je li označen ijedan redak u datagridu
            if (Primke_datagrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niti jedna primka nije označena!");
            }
            else
            {
                DialogResult odgovor = MessageBox.Show("Jeste li sigurni da želite obrisati odabranu primku?", "Potvrda Brisanja", MessageBoxButtons.YesNo);
                if (odgovor == DialogResult.Yes)
                {
                    string idSelektiranogReda = Primke_datagrid.CurrentRow.Cells[0].Value.ToString();
                    string upit = "DELETE FROM \"Primke\" WHERE \"idPrimke\" = " + idSelektiranogReda;
                    DB.Instance.izvrsi_upit(upit);
                }

                //ažuriramo datagridview s novim podacima
                UnesiPodatkeUDatagrid();
            }
        }
    }
}
