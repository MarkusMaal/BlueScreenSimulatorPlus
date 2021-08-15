﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
{
    public partial class Gen : Form
    {
        public Gen()
        {
            InitializeComponent();
        }

        private void Gen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.loadfinished)
            {
                this.Dispose();
                this.Close();
            }
        }
    }
}
