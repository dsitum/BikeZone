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

namespace BikeZone.Podobrasci
{
    public partial class Evidencija_Stavke_Primke : Form
    {
        //ako korisnik pritisne na gumb odustani, ova će kontrola na to ukazivati
        public bool odustani = true;
        public int idProizvoda;
        public string nazivProizvoda;
        public int kolicina;
        public float cijena;

        public Evidencija_Stavke_Primke()
        {
            InitializeComponent();

            UnesiStavkePrimkeUPadajuciIzbornik();
        }

        private void UnesiStavkePrimkeUPadajuciIzbornik()
        {
            string upit;
            //ako je checkbox Bicikl označen, dohvaćamo samo bicikle
            if (Bicikl_checkbox.Checked == true)
            {
                upit = "SELECT \"DijeloviBicikli\".\"idDijelaBicikla\", \"DijeloviBicikli\".naziv FROM \"DijeloviBicikli\" JOIN \"TipDijelaBicikla\" USING (\"idTipa\") WHERE bicikl ORDER BY 2";
            }
            //ako checkbox Bicikl nije označen, dohvaćamo dijelove
            else
            {
                upit = "SELECT \"DijeloviBicikli\".\"idDijelaBicikla\", \"DijeloviBicikli\".naziv FROM \"DijeloviBicikli\" JOIN \"TipDijelaBicikla\" USING (\"idTipa\") WHERE NOT bicikl ORDER BY 2";
            }


            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                while (dr.Read())
                {
                    dt.Load(dr);
                }
                Proizvodi_combobox.DataSource = dt;
                Proizvodi_combobox.DisplayMember = "naziv";
                Proizvodi_combobox.ValueMember = "idDijelaBicikla";
            }
        }


        private void Bicikl_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            UnesiStavkePrimkeUPadajuciIzbornik();
        }

        private void Odustani_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Pohrani_btn_Click(object sender, EventArgs e)
        {
            Regex kolicina = new Regex(@"^\d+$");
            Regex cijena = new Regex(@"^\d+(\.\d+)?$");

            if (!kolicina.IsMatch(Kolicina_textbox.Text))
            {
                MessageBox.Show("Unesite ispravnu količinu!");
            }
            else if (!cijena.IsMatch(Cijena_textbox.Text))
            {
                MessageBox.Show("Unesite ispravnu cijenu!");
            }
            else
            {
                //kada korisnik klikne na OK, postavljamo sve parametre koji će se iskoristiti u glavnoj formi
                //također postavljamo odustani na FALSE, što će dati znak drugoj formi da slobodno može prikupiti ove podatke ispod
                this.odustani = false;
                this.idProizvoda = int.Parse(Proizvodi_combobox.SelectedValue.ToString());
                this.nazivProizvoda = Proizvodi_combobox.Text;
                this.kolicina = int.Parse(Kolicina_textbox.Text);
                this.cijena = float.Parse(Cijena_textbox.Text);

                //Nakon postavljenih parametara, zatvaramo prozor
                this.Close();
            }
        }
    }
}
