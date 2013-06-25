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
    public partial class Evidencija_Racuna : Form
    {
        private bool DodajNoviRacun;
        private string idRacuna;

        public Evidencija_Racuna(bool dodajNoviRacun, DataGridViewRow racun = null)
        {
            InitializeComponent();

            UnesiProdavaceUPadajuciIzbornik();
            UnesiKupceUPadajuciIzbornik();

            this.DodajNoviRacun = dodajNoviRacun;
            if (dodajNoviRacun == false)
            {
                this.idRacuna = racun.Cells["idRacuna"].Value.ToString();
            }

            //Ovisno o tome dodajemo li novi račun ili ažuriramo postojeći račun, popunjavaju se polja i/ili datagrid sa stavkama računa
            if (dodajNoviRacun == true)
            {
                PodaciORacunu.Text = "Dodaj novi račun";
                EvidencijaRacuna_btn.Text = "Dodaj";

                //upisujemo zaglavlje u datagrid sa stavkama računa
                StavkeRacuna_datagrid.DataSource = Racuni.IspisiStavkeRacuna();
                UrediPostavkeDatagrida();
            }
            else
            {
                PodaciORacunu.Text = "Promijeni postojeću primku";
                EvidencijaRacuna_btn.Text = "Ažuriraj";
                //popunjavamo polja s informacijama
                Prodavaci_combobox.SelectedValue = int.Parse(racun.Cells["prodao"].Value.ToString());
                Kupci_combobox.SelectedValue = int.Parse(racun.Cells["kupio"].Value.ToString());
                DatumProdaje_datepicker.Text = racun.Cells["Datum prodaje"].Value.ToString();

                //popunjavamo datagrid sa stavkama primke
                StavkeRacuna_datagrid.DataSource = Racuni.IspisiStavkeRacuna(idRacuna);

                UrediPostavkeDatagrida();
            }
        }


        /// <summary>
        /// Ova metoda služi za uređivanje vizualnih postavki datagrida
        /// </summary>
        private void UrediPostavkeDatagrida()
        {
            //zaključavamo datagrid kako bi spriječili direktne promjene u njemu (za to imamo obrazac)
            StavkeRacuna_datagrid.ReadOnly = true;
            //sprječavamo da korisnik selektira više redaka
            StavkeRacuna_datagrid.MultiSelect = false;
            //omogućavamo full row select umjesto single column select
            StavkeRacuna_datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //sprječavamo korisnika da dodaje nove zapise u datagrid
            StavkeRacuna_datagrid.AllowUserToAddRows = false;
        }


        private void UnesiProdavaceUPadajuciIzbornik()
        {
            string upit = "SELECT \"idZaposlenika\", ime || ' ' || prezime as \"nazivZaposlenika\" FROM \"Zaposlenici\"";
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                while (dr.Read())
                {
                    dt.Load(dr);
                }
                Prodavaci_combobox.DataSource = dt;
                Prodavaci_combobox.DisplayMember = "nazivZaposlenika";
                Prodavaci_combobox.ValueMember = "idZaposlenika";
            }
        }

        private void UnesiKupceUPadajuciIzbornik()
        {
            string upit = "SELECT \"idKlijenta\", ime || ' ' || prezime as \"nazivKlijenta\" FROM \"Klijenti\"";
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                while (dr.Read())
                {
                    dt.Load(dr);
                }
                Kupci_combobox.DataSource = dt;
                Kupci_combobox.DisplayMember = "nazivKlijenta";
                Kupci_combobox.ValueMember = "idKlijenta";
            }
        }

        private void Odustani_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void DodajStavkuRacuna_btn_Click(object sender, EventArgs e)
        {
            Evidencija_Stavke_Racuna evidencijaStavkeRacuna = new Evidencija_Stavke_Racuna();
            evidencijaStavkeRacuna.ShowDialog();

            //podatke koje je prethodni obrazac zapisao u globalne varijable sada dohvaćamo i zapisujemo pomoću DataRow-a u DataTable
            if (evidencijaStavkeRacuna.odustani == false)
            {
                //dodajemo novi redak u prethodni obrazac
                DataTable dt = StavkeRacuna_datagrid.DataSource as DataTable;
                DataRow stavka = dt.NewRow();
                stavka["id"] = evidencijaStavkeRacuna.idProizvodaUsluge;
                stavka["Naziv"] = evidencijaStavkeRacuna.nazivProizvodaUsluge;
                stavka["Količina"] = evidencijaStavkeRacuna.kolicina;
                if (evidencijaStavkeRacuna.usluga == true)
                {
                    stavka["popravci_ili_dijelovibicikli"] = "P";   //P kao popravak
                    //ako se radilo o usluzi, umećemo još 2 vrijednosti (popravljeno i datum popravka)
                    stavka["Popravljen"] = evidencijaStavkeRacuna.popravljeno;
                    //ako je stavka popravljena, dodajemo datum popravka
                    if (evidencijaStavkeRacuna.popravljeno == true)
                    {
                        stavka["Datum Popravka"] = evidencijaStavkeRacuna.datumPopravka;
                    }
                }
                else
                {
                    stavka["popravci_ili_dijelovibicikli"] = "D";   //D kao dio
                }

                dt.Rows.Add(stavka);
                StavkeRacuna_datagrid.DataSource = dt;
            }
        }

        private void UrediStavkuRacuna_btn_Click(object sender, EventArgs e)
        {
            if (StavkeRacuna_datagrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Odaberite stavku računa za promjenu!");
            }
            else
            {
                //Obrascu ćemo poslati podatke za uređivanje kojima treba popuniti svoja polja
                string idProizvodaUsluge = StavkeRacuna_datagrid.CurrentRow.Cells["id"].Value.ToString();
                bool usluga;
                bool popravljeno = false;
                string datumPopravka = null;
                if (StavkeRacuna_datagrid.CurrentRow.Cells["popravci_ili_dijelovibicikli"].Value.ToString() == "P")
                {
                    usluga = true;
                    //ako se radilo o usluzi, dodajemo još 2 vrijednosti (popravljeno i datum popravka)
                    if (StavkeRacuna_datagrid.CurrentRow.Cells["Popravljen"].Value.ToString() == "True")
                    {
                        popravljeno = true;
                        //ako je stavka popravljena, dodajemo datum popravka
                        datumPopravka = StavkeRacuna_datagrid.CurrentRow.Cells["Datum Popravka"].Value.ToString();
                    }
                    else
                    {
                        popravljeno = false;
                    }
                }
                else
                {
                    usluga = false;
                }
                string kolicina = StavkeRacuna_datagrid.CurrentRow.Cells["Količina"].Value.ToString();
                Evidencija_Stavke_Racuna evidencijaStavkeRacuna = new Evidencija_Stavke_Racuna(idProizvodaUsluge, usluga, popravljeno, datumPopravka, kolicina);
                evidencijaStavkeRacuna.ShowDialog();

                //podatke koje je prethodni obrazac (evidencijaStavkePrimke) zapisao u globalne varijable sada dohvaćamo i zapisujemo u DataGrid
                if (evidencijaStavkeRacuna.odustani == false)
                {
                    StavkeRacuna_datagrid.CurrentRow.Cells["id"].Value = evidencijaStavkeRacuna.idProizvodaUsluge;
                    StavkeRacuna_datagrid.CurrentRow.Cells["Naziv"].Value = evidencijaStavkeRacuna.nazivProizvodaUsluge;
                    if (evidencijaStavkeRacuna.usluga == true)
                    {
                        StavkeRacuna_datagrid.CurrentRow.Cells["popravci_ili_dijelovibicikli"].Value = "P";
                        StavkeRacuna_datagrid.CurrentRow.Cells["Popravljen"].Value = evidencijaStavkeRacuna.popravljeno;
                        StavkeRacuna_datagrid.CurrentRow.Cells["Datum Popravka"].Value = evidencijaStavkeRacuna.datumPopravka;
                    }
                    else
                    {
                        StavkeRacuna_datagrid.CurrentRow.Cells["popravci_ili_dijelovibicikli"].Value = "D";
                        StavkeRacuna_datagrid.CurrentRow.Cells["Popravljen"].Value = false;
                        StavkeRacuna_datagrid.CurrentRow.Cells["Datum Popravka"].Value = "";
                    }
                    StavkeRacuna_datagrid.CurrentRow.Cells["Količina"].Value = evidencijaStavkeRacuna.kolicina;
                }
            }
        }

        private void ObrisiStavkuRacuna_btn_Click(object sender, EventArgs e)
        {
            if (StavkeRacuna_datagrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Odaberite stavku primke za brisanje!");
            }
            else
            {
                int idOznacenogReda = StavkeRacuna_datagrid.CurrentRow.Index;
                StavkeRacuna_datagrid.Rows.RemoveAt(idOznacenogReda);
            }
        }

        private void EvidencijaRacuna_btn_Click(object sender, EventArgs e)
        {
            //prvo provjeravamo imamo li duplikata u stavkama računa
            List<string> duplikati = new List<string>();
            bool imaDuplikata = false;
            foreach (DataGridViewRow redak in StavkeRacuna_datagrid.Rows)
            {
                if (duplikati.IndexOf(redak.Cells[0].Value.ToString()) == -1)
                {
                    duplikati.Add(redak.Cells[0].Value.ToString());
                }
                else
                {
                    imaDuplikata = true;
                }
            }
            duplikati.Clear();


            //potom provjerimo imamo li dovoljno stavki na skladištu za isporučiti
            List<string> prekoraceni = new List<string>();
            foreach (DataGridViewRow redak in StavkeRacuna_datagrid.Rows)
            {
                string idStavke = redak.Cells["id"].Value.ToString();
                string naziv = redak.Cells["Naziv"].Value.ToString();
                string kolicinaZaProdaju = redak.Cells["Količina"].Value.ToString();
                string popravakIliDio = redak.Cells["popravci_ili_dijelovibicikli"].Value.ToString();

                if (popravakIliDio == "D")
                {
                    string upit = "SELECT kolicina, \"minimalnaKolicina\" FROM \"DijeloviBicikli\" WHERE \"idDijelaBicikla\" = " + idStavke;
                    string trenutnaPravaKolicina;
                    using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                    {
                        dr.Read();
                        trenutnaPravaKolicina = dr["kolicina"].ToString();
                    }

                    if (DodajNoviRacun == true)
                    {
                        if (int.Parse(trenutnaPravaKolicina) - int.Parse(kolicinaZaProdaju) < 0)
                        {
                            prekoraceni.Add(naziv);
                        }
                    }
                    else
                    {
                        string staraKolicinaStavke;
                        upit = string.Format("SELECT kolicina FROM \"StavkeRacuna\" WHERE \"idRacuna\" = {0} AND \"idPopravciDijeloviBicikli\" = {1}", idRacuna, idStavke);
                        using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                        {
                            dr.Read();
                            staraKolicinaStavke = dr[0].ToString();
                        }

                        if (int.Parse(trenutnaPravaKolicina) - int.Parse(kolicinaZaProdaju) + int.Parse(staraKolicinaStavke) < 0)
                        {
                            prekoraceni.Add(naziv);
                        }
                    }
                }
            }

            if (prekoraceni.Count > 0)
            {
                string poruka = "Navedene stavke je nemoguće prodati zbog manjka na skladištu:\n\n";
                foreach (string proizvod in prekoraceni)
                {
                    poruka += proizvod + ", ";
                }
                MessageBox.Show(poruka);
            }
            else
            {
                if (imaDuplikata == true)
                {
                    MessageBox.Show("Među stavkama računa postoje duplikati! Potrebno ih je ukloniti.");
                }
                else
                {
                    if (DodajNoviRacun == true)
                    {
                        DodajRacunUBazu();
                    }
                    else
                    {
                        //najprije smanjujemo količine na skladištu za sve stavke računa koje će se obrisati
                        Racuni.PovecajKolicinuNaSkladistu(idRacuna);
                        //potom brišemo postojeći račun iz baze podataka (kaskadno se brišu i stavke računa)
                        string upit = "DELETE FROM \"Racuni\" WHERE \"idRacuna\" = " + idRacuna;
                        DB.Instance.izvrsi_upit(upit);

                        //na kraju umećemo novu primku zadanu obrascem
                        DodajRacunUBazu();
                    }

                    //javljamo informaciju o tome kojih proizvoda je na skladištu ostalo malo
                    string upitZaProizvode = "SELECT naziv, kolicina, \"minimalnaKolicina\" FROM \"DijeloviBicikli\"";
                    using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upitZaProizvode))
                    {
                        string poruka = "";
                        while (dr.Read())
	                    {
                            if (int.Parse(dr[1].ToString()) - int.Parse(dr[2].ToString()) <= 0)
                            {
                                poruka += dr[0].ToString() + " (minimalna količina: " + int.Parse(dr[2].ToString()) + ", stvarna količina: " + int.Parse(dr[1].ToString()) + ")\n";
                            }
	                    }

                        //ako postoje takvi proizvodi, tj ako string poruke nije ostao prazan
                        if (poruka != "")
                        {
                            poruka = "Sljedeće stavke je potrebno naručiti:\n" + poruka;
                            MessageBox.Show(poruka);
                        }
                    }

                    this.Close();
                }
            }
        }

        private void DodajRacunUBazu()
        {
            //dodavamo novi račun u bazu podataka
            string datum = DatumProdaje_datepicker.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string prodao = Prodavaci_combobox.SelectedValue.ToString();
            string kupio = Kupci_combobox.SelectedValue.ToString();
            string upit = string.Format("INSERT INTO \"Racuni\" (\"ZKI\", \"JIR\", \"datumProdaje\", prodao, kupio) VALUES ('{0}', '{1}', '{2}', {3}, {4})", "1", "1", datum, prodao, kupio);
            DB.Instance.izvrsi_upit(upit);

            //dohvaćamo ID računa koji je upravo dodan u bazu
            upit = "SELECT MAX(\"idRacuna\") FROM \"Racuni\"";
            string idRacuna;
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                dr.Read();
                idRacuna = dr[0].ToString();
            }

            //dodavamo sve stavke računa u bazu
            foreach (DataGridViewRow red in StavkeRacuna_datagrid.Rows)
            {
                string idPopravciDijeloviBicikli = red.Cells["id"].Value.ToString();
                string kolicina = red.Cells["Količina"].Value.ToString();
                string popravakIliUsluga = red.Cells["popravci_ili_dijelovibicikli"].Value.ToString();
                upit = string.Format("INSERT INTO \"StavkeRacuna\" (\"idRacuna\", \"idPopravciDijeloviBicikli\", kolicina) VALUES ({0}, {1}, {2})", idRacuna, idPopravciDijeloviBicikli, kolicina);
                DB.Instance.izvrsi_upit(upit);

                //ako se radi o usluzi (popravku), dohvaćamo još informacije o popravku
                if (popravakIliUsluga == "P")
                {
                    string popravljen = red.Cells["Popravljen"].Value.ToString();
                    string datumPopravka = red.Cells["Datum Popravka"].Value.ToString();
                    if (datumPopravka == "")
                    {
                        upit = string.Format("INSERT INTO \"Popravak\" (\"idRacuna\", usluga, popravljen, \"datumPopravka\") VALUES ({0}, {1}, {2}, {3})", idRacuna, idPopravciDijeloviBicikli, popravljen, "NULL");
                    }
                    else
                    {
                        upit = string.Format("INSERT INTO \"Popravak\" (\"idRacuna\", usluga, popravljen, \"datumPopravka\") VALUES ({0}, {1}, {2}, '{3}')", idRacuna, idPopravciDijeloviBicikli, popravljen, datumPopravka);
                    }
                    DB.Instance.izvrsi_upit(upit);
                }
                //ako se ipak radilo o proizvodu (biciklu, dijelu), smanjimo količinu na skladištu
                else
                {
                    //smanjimo količine određenih dijelova na skladištu
                    upit = string.Format("UPDATE \"DijeloviBicikli\" SET kolicina = kolicina - {0} WHERE \"idDijelaBicikla\" = {1}", kolicina, idPopravciDijeloviBicikli);
                    DB.Instance.izvrsi_upit(upit);
                }
            }
        }
    }
}
