﻿using System;
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
    public partial class Evidencija_Proizvoda : Form
    {
        public Evidencija_Proizvoda()
        {
            InitializeComponent();

            //postavljamo da se polje šifre ne može promijeniti (read-only)
            this.Sifra.ReadOnly = true;
        }
    }
}
