﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1_AdonetCustomer
{
    public partial class FrmMap : Form
    {
        public FrmMap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCity frmCity = new FrmCity();
            frmCity.Show();


        }

        private void FrmMap_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenCustomer_Click(object sender, EventArgs e)
        {
            FrmCustomer frmCustomer=new FrmCustomer();
            frmCustomer.Show();
        }
    }
}
