﻿using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace UltimateBlueScreenSimulator
{
    public partial class TextView : MaterialForm
    {
        internal string Title = "";
        public TextView()
        {
            MaterialSkinManager materialSkinManager = Program.f1.materialSkinManager;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
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
