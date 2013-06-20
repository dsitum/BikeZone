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
    public partial class Evidencija_Zaposlenika : Form
    {
        private bool dodaj_promijeni;
        public Evidencija_Zaposlenika(bool dodaj_promijeni)
        {
            InitializeComponent();
            this.CenterToParent();
            this.dodaj_promijeni = dodaj_promijeni;
            if (dodaj_promijeni == false)
            {
                grpEvidencija.Text = "Dodaj zaposlenika";
            }
            else
            {
                grpEvidencija.Text = "Uredi zaposlenika";
            }
            selektirajZaposlenike();
        }

        private void selektirajZaposlenike()
        {
            string upit = string.Format("SELECT*FROM \"Zaposlenici\";");
            using (NpgsqlDataReader dr = DB.Instance.dohvati_podatke(upit))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {

        }

        private void btnEvidentiraj_Click(object sender, EventArgs e)
        {

        }
    }
}
