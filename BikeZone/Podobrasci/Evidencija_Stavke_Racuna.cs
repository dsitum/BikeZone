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
    public partial class Evidencija_Stavke_Racuna : Form
    {
        //ako korisnik pritisne na gumb odustani, ova će kontrola na to ukazivati
        public bool odustani = true;
        public bool usluga;
        public int idProizvodaUsluge;
        public string nazivProizvodaUsluge;
        public string kolicina;
        public bool popravljeno;
        public string datumPopravka;

        public Evidencija_Stavke_Racuna(string idProizvodaUsluge = null, bool usluga = false, bool popravljeno = false, string datumPopravka = null, string kolicina = null)
        {
            InitializeComponent();
            UnesiProizvodeUslugeUPadajuciIzbornik();
            if (idProizvodaUsluge != null)
            {
                Usluga_checkbox.Checked = usluga;
                ProizvodiUsluge_combobox.SelectedValue = idProizvodaUsluge;
                Kolicina_textbox.Text = kolicina;
                if (Usluga_checkbox.Checked == true)
                {
                    Popravljen_checkbox.Checked = popravljeno;
                    if (Popravljen_checkbox.Checked == true)
                    {
                        DatumPopravka_datepicker.Value = DateTime.Parse(datumPopravka);
                    }
                }
            }
        }

        private void UnesiProizvodeUslugeUPadajuciIzbornik()
        {
            if (Usluga_checkbox.Checked == false)
            {
                string upit = "SELECT \"idDijelaBicikla\", naziv FROM \"DijeloviBicikli\"";
                using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    while (dr.Read())
                    {
                        dt.Load(dr);
                    }
                    ProizvodiUsluge_combobox.DataSource = dt;
                    ProizvodiUsluge_combobox.ValueMember = "idDijelaBicikla";
                    ProizvodiUsluge_combobox.DisplayMember = "naziv";
                }
            }
            else
            {
                string upit = "SELECT \"idPopravka\", naziv FROM \"Popravci\"";
                using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    while (dr.Read())
                    {
                        dt.Load(dr);
                    }
                    ProizvodiUsluge_combobox.DataSource = dt;
                    ProizvodiUsluge_combobox.ValueMember = "idPopravka";
                    ProizvodiUsluge_combobox.DisplayMember = "naziv";
                }
            }
        }

        private void Usluga_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Usluga_checkbox.Checked == true)
            {
                Popravljen_checkbox.Enabled = true;
                DatumPopravka_datepicker.Enabled = true;
            }
            else
            {
                Popravljen_checkbox.Checked = false;
                Popravljen_checkbox.Enabled = false;
                DatumPopravka_datepicker.Enabled = false;
            }

            UnesiProizvodeUslugeUPadajuciIzbornik();
        }

        private void Odustani_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pohrani_btn_Click(object sender, EventArgs e)
        {
            Regex kolicina = new Regex(@"^\d+$");

            if (!kolicina.IsMatch(Kolicina_textbox.Text))
            {
                MessageBox.Show("Unesite ispravnu količinu!");
            }
            else
            {
                //kada korisnik klikne na OK, postavljamo sve parametre koji će se iskoristiti u glavnoj formi
                //također postavljamo odustani na FALSE, što će dati znak drugoj formi da slobodno može prikupiti ove podatke ispod
                this.odustani = false;
                this.usluga = Usluga_checkbox.Checked;
                this.idProizvodaUsluge = int.Parse(ProizvodiUsluge_combobox.SelectedValue.ToString());
                this.nazivProizvodaUsluge = ProizvodiUsluge_combobox.Text;
                this.kolicina = Kolicina_textbox.Text;
                this.popravljeno = Popravljen_checkbox.Checked;
                this.datumPopravka = DatumPopravka_datepicker.Value.ToString("yyyy-MM-dd HH:mm:ss");
                

                //Nakon postavljenih parametara, zatvaramo prozor
                this.Close();
            }
        }

        private void Popravljen_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Popravljen_checkbox.Checked == true)
            {
                DatumPopravka_datepicker.Enabled = true;
            }
            else
            {
                DatumPopravka_datepicker.Enabled = false;
            }
        }


    }
}
