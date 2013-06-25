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
            this.CenterToParent();
            UnesiPodatkeUDatagrid();
        }

        /// <summary>
        /// Unose se postojeće primke (bez njihovih stavki) u datagrid
        /// </summary>
        private void UnesiPodatkeUDatagrid()
        {
            string upit = "SELECT \"Primke\".\"idPrimke\", \"Primke\".datum::varchar(10) AS \"Datum dospijeća\", \"Primke\".dobavljac, \"Dobavljaci\".\"nazivDobavljaca\" AS \"Naziv dobavljača\", \"Primke\".placeno AS \"Plaćeno\" FROM \"Primke\" JOIN \"Dobavljaci\" ON \"Primke\".dobavljac = \"Dobavljaci\".\"idDobavljaca\" ORDER BY 2";

            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                System.Data.DataTable dt = new System.Data.DataTable();
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
                string upit = "SELECT \"StavkePrimke\".\"idDijelaBicikla\", \"DijeloviBicikli\".naziv AS \"Naziv robe\", \"TipDijelaBicikla\".bicikl AS \"Bicikl\", \"StavkePrimke\".kolicina AS \"Količina\", \"StavkePrimke\".cijena AS \"Jedinična nabavna cijena\" FROM \"StavkePrimke\" JOIN \"DijeloviBicikli\" USING (\"idDijelaBicikla\") JOIN \"TipDijelaBicikla\" USING (\"idTipa\") WHERE \"StavkePrimke\".primka = " + idSelektiranePrimke;

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

            //Ažuriramo datagrid
            UnesiPodatkeUDatagrid();
        }

        private void PromijeniPrimku_btn_Click(object sender, EventArgs e)
        {
            if (Primke_datagrid.SelectedRows.Count == 1)
            {
                Evidencija_Primke evidencijaPrimke = new Evidencija_Primke(false, Primke_datagrid.CurrentRow);
                evidencijaPrimke.ShowDialog();

                //Ažuriramo datagrid
                UnesiPodatkeUDatagrid();
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
                    //Umanjujemo količine na skladištu za sve stavke primke koje će se obrisati
                    UmanjiKolicinuNaSkladistu(idSelektiranogReda);
                    //brišemo postojeću primku iz baze podataka
                    string upit = "DELETE FROM \"Primke\" WHERE \"idPrimke\" = " + idSelektiranogReda;
                    DB.Instance.izvrsi_upit(upit);
                }

                //ažuriramo datagridview s novim podacima
                UnesiPodatkeUDatagrid();
            }
        }

        public static void UmanjiKolicinuNaSkladistu(string idSelektiranogReda)
        {
            //prije nego li obrišemo primku, potrebno je količinu na skladištu smanjiti za iznose koje brišemo
            string upit = "SELECT \"idDijelaBicikla\", kolicina FROM \"StavkePrimke\" WHERE primka = " + idSelektiranogReda;

            //količine i pripadajuće ID-ove ćemo pohranjivati u 2 liste
            List<string> idStavke = new List<string>();
            List<string> kolicinaStavke = new List<string>();

            //pronađemo sve količine stavki koje će se brisati s postojeće primke
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                while (dr.Read())
                {
                    idStavke.Add(dr[0].ToString());
                    kolicinaStavke.Add(dr[1].ToString());
                }
            }

            //ažuriramo sve količine u bazi podataka
            for (int i = 0; i < idStavke.Count; i++)
            {
                upit = string.Format("UPDATE \"DijeloviBicikli\" SET kolicina=kolicina-{0} WHERE \"idDijelaBicikla\" = {1}", kolicinaStavke[i], idStavke[i]);
                DB.Instance.izvrsi_upit(upit);
            }
        }

        private void IspisPrimke_btn_Click(object sender, EventArgs e)
        {
            if (Primke_datagrid.SelectedRows.Count == 1)
            {
                // Create the Word application and declare a document
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();

                // Define an object to pass to the API for missing parameters
                object missing = System.Type.Missing;

                int trenutna_selekcija = Primke_datagrid.CurrentCell.RowIndex;
                object fileName = @"C:\Users\Public\Documents\Primka.docx";
                doc = word.Documents.Open(ref fileName,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing);
               // MessageBox.Show(Primke_datagrid.Rows[trenutna_selekcija].Cells[4].Value.ToString());
                // Activate the document
                doc.Activate();
                try
                {
                    object n = @"C:\Users\Public\Documents\Primka1.docx";
                    doc.SaveAs2(n);

                    missing = pretrazi_zamijeni(doc, missing,"@dat",
                        Primke_datagrid.Rows[trenutna_selekcija].Cells[1].Value.ToString());

                    if (string.Compare(Primke_datagrid.Rows[trenutna_selekcija].Cells[4].Value.ToString(), "False") == 0)
                    {
                        missing = pretrazi_zamijeni(doc, missing, "@dn", "NE");
                    }
                    else
                    {
                        missing = pretrazi_zamijeni(doc, missing, "@dn", "DA");
                    }
                    missing = pretrazi_zamijeni(doc, missing, "@naz",
                       Primke_datagrid.Rows[trenutna_selekcija].Cells[3].Value.ToString());
                    float ukupno = 0;
                    //\"DijeloviBicikli\".naziv AS \"Naziv robe\", \"TipDijelaBicikla\".bicikl AS \"Bicikl\", \"StavkePrimke\".kolicina AS \"Količina\", \"StavkePrimke\".cijena AS \"Jedinična nabavna cijena\" 
                    string sve = "Naziv robe\t\t\tKoličina\tNabavna cijena"+Environment.NewLine+Environment.NewLine;
                    for (int i = 0; i < StavkePrimke_datagrid.Rows.Count; i++)
                    {
                        sve += StavkePrimke_datagrid.Rows[i].Cells[1].Value.ToString() + "\t\t\t" + StavkePrimke_datagrid.Rows[i].Cells[3].Value.ToString() +
                            "\t\t" + StavkePrimke_datagrid.Rows[i].Cells[4].Value.ToString() + Environment.NewLine;
                        sve += "-----------------------------------------------------------------------------"+Environment.NewLine;
                        ukupno += float.Parse(StavkePrimke_datagrid.Rows[i].Cells[4].Value.ToString()) * float.Parse(StavkePrimke_datagrid.Rows[i].Cells[3].Value.ToString()); 
                    }
                    sve += Environment.NewLine + "Ukupno: " + ukupno.ToString()+Environment.NewLine;
                    missing = pretrazi_zamijeni(doc, missing, "@sad",sve);
                    //Prikaži dokument
                    word.Visible = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    doc.Close(ref missing, ref missing, ref missing);
                    word.Application.Quit(ref missing, ref missing, ref missing);
                }
            }
            else
            {
                MessageBox.Show("Niti jedna primka nije označena!");
            }
        }

        private static object pretrazi_zamijeni(Microsoft.Office.Interop.Word.Document doc, object missing,string zamijeni,string zamjenski)
        {
            foreach (Microsoft.Office.Interop.Word.Range tmpRange in doc.StoryRanges)
            {
                tmpRange.Find.Text = zamijeni;
                tmpRange.Find.Replacement.Text = zamjenski;
                tmpRange.Find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
                object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
                tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref replaceAll,
                    ref missing, ref missing, ref missing, ref missing);
            }
            return missing;
        }
    }
}
