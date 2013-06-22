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

#endregion

namespace BikeZone
{
    public partial class Evidencija_Proizvoda : Form
    {
        private bool Dodaj_Promijeni { get; set; }

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


        private void selektiraj_proizvode()
        {
            string upit = string.Format("SELECT \"idDijelaBicikla\", \"DijeloviBicikli\".naziv, \"TipDijelaBicikla\".naziv, \"godinaProizvodnje\","
                                        +" kolicina, \"minimalnaKolicina\", cijena FROM \"DijeloviBicikli\" JOIN \"TipDijelaBicikla\" ON \"tip\"=\"idTipa\";");
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Ne mogu obaviti brisanje proizvoda!");
            }

        }
    }
}
