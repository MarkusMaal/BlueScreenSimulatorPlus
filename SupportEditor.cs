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
    public partial class SupportEditor : Form
    {
        public SupportEditor()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Program.gs.SupportText = textBox1.Text;
        }

        private void SupportEditor_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.gs.SupportText;
        }
    }
}
