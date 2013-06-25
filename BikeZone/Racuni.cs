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
    public partial class Racuni : Form
    {
        public Racuni()
        {
            InitializeComponent();

            UnesiPodatkeUDatagrid();
        }

        /// <summary>
        /// Unose se postojeći računi (bez njihovih stavki) u datagrid
        /// </summary>
        private void UnesiPodatkeUDatagrid()
        {
            string upit = "SELECT \"Racuni\".\"idRacuna\", \"Racuni\".\"datumProdaje\" AS \"Datum prodaje\", \"Racuni\".kupio, \"Klijenti\".ime || ' ' || \"Klijenti\".prezime AS \"Kupac\", \"Racuni\".prodao, \"Zaposlenici\".ime || ' ' || \"Zaposlenici\".prezime AS \"Prodavač\", \"ZKI\", \"JIR\" FROM \"Racuni\" JOIN \"Klijenti\" ON \"Racuni\".kupio = \"Klijenti\".\"idKlijenta\" JOIN \"Zaposlenici\" ON \"Racuni\".prodao = \"Zaposlenici\".\"idZaposlenika\" ORDER BY 2";

            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                while (dr.Read())
                {
                    dt.Load(dr);
                }
                Racuni_datagrid.DataSource = dt;

                //skrivamo stupce u kojima se nalaze ID racuna, ID kupca i ID prodavača
                Racuni_datagrid.Columns[0].Visible = false;
                Racuni_datagrid.Columns[2].Visible = false;
                Racuni_datagrid.Columns[4].Visible = false;
                Racuni_datagrid.Columns[6].Visible = false;
                Racuni_datagrid.Columns[7].Visible = false;
                //zaključavamo datagrid kako bi spriječili direktne promjene u njemu (za to imamo obrazac)
                Racuni_datagrid.ReadOnly = true;
                //sprječavamo da korisnik selektira više redaka
                Racuni_datagrid.MultiSelect = false;
                //omogućavamo full row select umjesto single column select
                Racuni_datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //sprječavamo korisnika da dodaje nove zapise u datagrid
                Racuni_datagrid.AllowUserToAddRows = false;
            }
        }


        private void Racuni_datagrid_SelectionChanged(object sender, EventArgs e)
        {
            //funkcija se izvršava jedino u slučaju kada je označen jedan redak
            if (Racuni_datagrid.SelectedRows.Count == 1)
            {
                //Popunjavamo datagrid sa stavkama računa
                string idSelektiranogRacuna = Racuni_datagrid.CurrentRow.Cells[0].Value.ToString();
                StavkeRacuna_datagrid.DataSource = IspisiStavkeRacuna(idSelektiranogRacuna);

                //uklanjamo stupce tipa ID i slične koje ne želimo da vidi korisnik
                StavkeRacuna_datagrid.Columns["id"].Visible = false;
                StavkeRacuna_datagrid.Columns["popravci_ili_dijelovibicikli"].Visible = false;
                //zaključavamo datagrid kako bi spriječili direktne promjene u njemu (za to imamo obrazac)
                StavkeRacuna_datagrid.ReadOnly = true;
                //sprječavamo da korisnik selektira više redaka
                StavkeRacuna_datagrid.MultiSelect = false;
                //omogućavamo full row select umjesto single column select
                StavkeRacuna_datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //sprječavamo korisnika da dodaje nove zapise u datagrid
                StavkeRacuna_datagrid.AllowUserToAddRows = false;
            }
        }

        public static DataTable IspisiStavkeRacuna(string idSelektiranogRacuna = null)
        {
            //ako se radi o stvaranju novog računa, ispisat ćemo samo zaglavlje
            if (idSelektiranogRacuna == null)
            {
                DataTable dt = new DataTable();
                //ispišemo zaglavlje u slučaju da račun nema niti jedne stavke
                string upit = "SELECT \"PopravciDijeloviBicikli\".id, \"Popravci\".naziv AS \"Naziv\", \"StavkeRacuna\".kolicina AS \"Količina\", \"PopravciDijeloviBicikli\".popravci_ili_dijelovibicikli, \"Popravak\".popravljen AS \"Popravljen\", \"Popravak\".\"datumPopravka\" AS \"Datum Popravka\" FROM \"StavkeRacuna\" JOIN \"PopravciDijeloviBicikli\" ON \"idPopravciDijeloviBicikli\" = id JOIN \"Popravci\" ON id = \"idPopravka\" JOIN \"Popravak\" ON (\"StavkeRacuna\".\"idRacuna\" = \"Popravak\".\"idRacuna\" AND \"StavkeRacuna\".\"idPopravciDijeloviBicikli\" = \"Popravak\".usluga) WHERE false";
                using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                {
                    dr.Read();
                    dt.Load(dr);
                }
                return dt;
            }
            //ako se radi o uređivanju postojećeg računa
            else
            {
                //najprije dohvatimo sve stavke selektiranog računa
                string upit = "SELECT \"StavkeRacuna\".\"idPopravciDijeloviBicikli\", \"PopravciDijeloviBicikli\".popravci_ili_dijelovibicikli FROM \"StavkeRacuna\" JOIN \"PopravciDijeloviBicikli\" ON \"idPopravciDijeloviBicikli\" = id WHERE \"StavkeRacuna\".\"idRacuna\" = " + idSelektiranogRacuna;

                List<string> idProizvodaUsluge = new List<string>();
                List<string> proizvodIliUsluga = new List<string>();
                using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                {
                    while (dr.Read())
                    {
                        idProizvodaUsluge.Add(dr[0].ToString());
                        proizvodIliUsluga.Add(dr[1].ToString());
                    }
                }

                DataTable dt = new DataTable();
                //ispišemo zaglavlje u slučaju da račun nema niti jedne stavke
                upit = "SELECT \"PopravciDijeloviBicikli\".id, \"Popravci\".naziv AS \"Naziv\", \"StavkeRacuna\".kolicina AS \"Količina\", \"PopravciDijeloviBicikli\".popravci_ili_dijelovibicikli, \"Popravak\".popravljen AS \"Popravljen\", \"Popravak\".\"datumPopravka\" AS \"Datum Popravka\" FROM \"StavkeRacuna\" JOIN \"PopravciDijeloviBicikli\" ON \"idPopravciDijeloviBicikli\" = id JOIN \"Popravci\" ON id = \"idPopravka\" JOIN \"Popravak\" ON (\"StavkeRacuna\".\"idRacuna\" = \"Popravak\".\"idRacuna\" AND \"StavkeRacuna\".\"idPopravciDijeloviBicikli\" = \"Popravak\".usluga) WHERE false";
                using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                {
                    dr.Read();
                    dt.Load(dr);
                }

                for (int i = 0; i < idProizvodaUsluge.Count; i++)
                {
                    //ako se radi o proizvodu (D označava DIO)
                    if (proizvodIliUsluga[i] == "D")
                    {
                        upit = string.Format("SELECT \"PopravciDijeloviBicikli\".id, \"DijeloviBicikli\".naziv AS \"Naziv\", \"StavkeRacuna\".kolicina AS \"Količina\", \"PopravciDijeloviBicikli\".popravci_ili_dijelovibicikli, NULL AS \"Popravljen\", NULL AS \"Datum Popravka\" FROM \"StavkeRacuna\" JOIN \"PopravciDijeloviBicikli\" ON \"idPopravciDijeloviBicikli\" = id JOIN \"DijeloviBicikli\" ON id = \"idDijelaBicikla\" WHERE \"idRacuna\" = {0} AND \"idPopravciDijeloviBicikli\" = {1}", idSelektiranogRacuna, idProizvodaUsluge[i]);
                        using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                        {
                            dt.Load(dr);
                            dr.Read();
                            dt.Load(dr);
                        }
                    }
                    //ako se radi o popravku (P)
                    else
                    {
                        upit = string.Format("SELECT \"PopravciDijeloviBicikli\".id, \"Popravci\".naziv AS \"Naziv\", \"StavkeRacuna\".kolicina AS \"Količina\", \"PopravciDijeloviBicikli\".popravci_ili_dijelovibicikli, \"Popravak\".popravljen AS \"Popravljen\", \"Popravak\".\"datumPopravka\" AS \"Datum Popravka\" FROM \"StavkeRacuna\" JOIN \"PopravciDijeloviBicikli\" ON \"idPopravciDijeloviBicikli\" = id JOIN \"Popravci\" ON id = \"idPopravka\" JOIN \"Popravak\" ON (\"Popravak\".\"idRacuna\" = \"StavkeRacuna\".\"idRacuna\" AND \"Popravak\".usluga = \"StavkeRacuna\".\"idPopravciDijeloviBicikli\") WHERE \"StavkeRacuna\".\"idRacuna\" = {0} AND \"StavkeRacuna\".\"idPopravciDijeloviBicikli\" = {1}", idSelektiranogRacuna, idProizvodaUsluge[i]);
                        using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                        {
                            dt.Load(dr);
                            dr.Read();
                            dt.Load(dr);
                        }
                    }
                }
                return dt;
            }
        }

        private void DodajRacun_btn_Click(object sender, EventArgs e)
        {
            Evidencija_Racuna evidencijaRacuna = new Evidencija_Racuna(true);
            evidencijaRacuna.ShowDialog();

            //Ažuriramo datagrid
            UnesiPodatkeUDatagrid();
        }

        private void PromijeniRacun_btn_Click(object sender, EventArgs e)
        {
            if (Racuni_datagrid.SelectedRows.Count == 1)
            {
                Evidencija_Racuna evidencijaRacuna = new Evidencija_Racuna(false, Racuni_datagrid.CurrentRow);
                evidencijaRacuna.ShowDialog();

                //Ažuriramo datagrid
                UnesiPodatkeUDatagrid();
            }
            else
            {
                MessageBox.Show("Niti jedan račun nije odabran!");
            }
        }

        private void ObrisiRacun_btn_Click(object sender, EventArgs e)
        {
            //najprije provjeravamo je li označen ijedan redak u datagridu
            if (Racuni_datagrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niti jedan račun nije označen!");
            }
            else
            {
                DialogResult odgovor = MessageBox.Show("Jeste li sigurni da želite obrisati odabrani račun?", "Potvrda Brisanja", MessageBoxButtons.YesNo);
                if (odgovor == DialogResult.Yes)
                {
                    string idSelektiranogReda = Racuni_datagrid.CurrentRow.Cells[0].Value.ToString();
                    //Uvećavamo količine na skladištu za sve stavke računa koje će se obrisati
                    PovecajKolicinuNaSkladistu(idSelektiranogReda);
                    //brišemo postojeći račun iz baze podataka
                    string upit = "DELETE FROM \"Racuni\" WHERE \"idRacuna\" = " + idSelektiranogReda;
                    DB.Instance.izvrsi_upit(upit);
                }

                //ažuriramo datagridview s novim podacima
                UnesiPodatkeUDatagrid();
            }
        }

        public static void PovecajKolicinuNaSkladistu(string idSelektiranogReda)
        {
            //najprije dohvatimo sve stavke selektiranog računa
            string upit = "SELECT \"StavkeRacuna\".\"idPopravciDijeloviBicikli\", \"PopravciDijeloviBicikli\".popravci_ili_dijelovibicikli, \"StavkeRacuna\".kolicina FROM \"StavkeRacuna\" JOIN \"PopravciDijeloviBicikli\" ON \"idPopravciDijeloviBicikli\" = id WHERE \"StavkeRacuna\".\"idRacuna\" = " + idSelektiranogReda;

            List<string> idProizvodaUsluge = new List<string>();
            List<string> proizvodIliUsluga = new List<string>();
            List<string> kolicinaProizvoda = new List<string>();
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                while (dr.Read())
                {
                    idProizvodaUsluge.Add(dr[0].ToString());
                    proizvodIliUsluga.Add(dr[1].ToString());
                    kolicinaProizvoda.Add(dr[2].ToString());
                }
            }


            for (int i = 0; i < idProizvodaUsluge.Count; i++)
            {
                //ako se radi o proizvodu (D označava DIO)
                if (proizvodIliUsluga[i] == "D")
                {
                    upit = string.Format("UPDATE \"DijeloviBicikli\" SET kolicina = kolicina + {0} WHERE \"idDijelaBicikla\" = {1}", kolicinaProizvoda[i], idProizvodaUsluge[i]);
                    DB.Instance.izvrsi_upit(upit);
                }
            }
        }

        private void IspisRacune_btn_Click(object sender, EventArgs e)
        {
            if (Racuni_datagrid.SelectedRows.Count == 1)
            {

            }
            else
            {
                MessageBox.Show("Niti jedan račun nije označen!");
            }
        }
    }
}
