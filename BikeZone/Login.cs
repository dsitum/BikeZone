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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Niste unijeli lozinku!");
            }
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Niste unijeli korisničko ime!");
            }
            //ispravno uneseni podaci
            else
            {
                string upit=string.Format("SELECT \"idZaposlenika\" FROM \"Zaposlenici\" "
                                          + "WHERE \"korisnickoIme\"='{0}' AND lozinka='{1}';"
                                            ,txtUsername.Text,txtPassword.Text);

                NpgsqlDataReader korisnik = DB.Instance.dohvati_podatke(upit);
                if (korisnik.HasRows)
                {
                    int id_zaposlenika=0;
                    while (korisnik.Read())
                    {
                        id_zaposlenika = int.Parse(korisnik["idZaposlenika"].ToString());
                    }
                    korisnik.Close();
                    Glavna_Forma glavna = new Glavna_Forma(id_zaposlenika);
                    this.Hide();
                    glavna.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ne postoji ovaj korisnik u bazi");
                }
            }
        }
    }
}
