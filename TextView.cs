﻿using System;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
{
    public partial class TextView : Form
    {
        internal string Title = "";
        public TextView()
        {
            InitializeComponent();
        }

        private void TextView_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.Text;
            this.Text = Title;
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 0;
            textBox1.DeselectAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 0;
            textBox1.DeselectAll();
        }
    }
}
