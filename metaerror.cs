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
    public partial class Metaerror : Form
    {
        internal string message = "";
        internal string stack_trace = "";
        internal string type = "GreenScreen";
        public Metaerror()
        {
            InitializeComponent();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                    break;
                case Keys.Enter:
                    this.DialogResult = DialogResult.Ignore;
                    this.Close();
                    break;
                case Keys.Space:
                    this.DialogResult = DialogResult.Retry;
                    this.Close();
                    break;
            }
        }

        private void Metaerror_Load(object sender, EventArgs e)
        {
            technicalinfoLabel.Text = type + " Exception\n\n" + message + "\n\n" + stack_trace;
            switch (type)
            {
                case "GreenScreen":
                    this.BackColor = Color.ForestGreen;
                    this.ForeColor = Color.White;
                    break;
                case "OrangeScreen":
                    this.BackColor = Color.DarkOrange;
                    this.ForeColor = Color.White;
                    break;
                case "VioletScreen":
                    this.BackColor = Color.BlueViolet;
                    this.ForeColor = Color.White;
                    retryButton.Visible = true;
                    abortButton.Visible = true;
                    break;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void Metaerror_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F7))
            {
                Close();
            }
        }
    }
}
