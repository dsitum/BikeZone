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

namespace BikeZone
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
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
            else
            {
          DB.
            }
        }
    }
}
