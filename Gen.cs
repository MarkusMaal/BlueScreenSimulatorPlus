using System;
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
            this.Text = Program.load_message;
            if (Program.loadfinished)
            {
                this.Dispose();
                this.Close();
            }
            if (Program.load_progress < 100)
            {
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.Value = Program.load_progress;
            }
            else if (Program.load_progress > 100)
            {
                progressBar1.Value = progressBar1.Maximum;
            }
            else
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
            }
        }
    }
}
