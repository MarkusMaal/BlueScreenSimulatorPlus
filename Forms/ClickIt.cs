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
    public partial class ClickIt : Form
    {
        int num;
        public ClickIt()
        {
            InitializeComponent();
        }
        private void Click9_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("You finished impossible! You are awesome!");
        }

        private void Click9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are a hacker!");
        }

        private void Click1_MouseMove(object sender, MouseEventArgs e)
        {
            click1.Visible = false;
            click2.Visible = true;
            num++;
            label2.Text = num.ToString();
            Ccode();
        }

        private void Click2_MouseMove(object sender, MouseEventArgs e)
        {
            click2.Visible = false;
            click3.Visible = true;
            num++;
            label2.Text = num.ToString();
            Ccode();
        }

        private void Click3_MouseMove(object sender, MouseEventArgs e)
        {

            click3.Visible = false;
            click4.Visible = true;
            num++;
            label2.Text = num.ToString();
            Ccode();
        }

        private void Click4_MouseMove(object sender, MouseEventArgs e)
        {

            click4.Visible = false;
            click5.Visible = true;
            num++;
            label2.Text = num.ToString();
            Ccode();
        }

        private void Click5_MouseMove(object sender, MouseEventArgs e)
        {

            click5.Visible = false;
            click6.Visible = true;
            num++;
            label2.Text = num.ToString();
            Ccode();
        }

        private void Click6_MouseMove(object sender, MouseEventArgs e)
        {

            click6.Visible = false;
            click7.Visible = true;
            num++;
            label2.Text = num.ToString();
            Ccode();
        }

        private void Click7_MouseMove(object sender, MouseEventArgs e)
        {

            click7.Visible = false;
            click8.Visible = true;
            num++;
            label2.Text = num.ToString();
            Ccode();
        }

        private void Click8_MouseMove(object sender, MouseEventArgs e)
        {

            click8.Visible = false;
            click9.Visible = true;
            num++;
            label2.Text = num.ToString();
            Ccode();
        }

        private void Click9_MouseMove(object sender, MouseEventArgs e)
        {

            click9.Visible = false;
            click1.Visible = true;
            num++;
            label2.Text = num.ToString();
            Ccode();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            string[] words = s.Split('.');
            foreach (string word in words)
            {
                listBox1.Items.Add(word);
            }
            if (listBox1.Items.Count > 2)
            {
                this.Close();
            }
            listBox1.SelectedIndex = 0;
            Int32.TryParse(listBox1.SelectedItem.ToString(), out num);
            listBox1.SelectedIndex = 1;
            Int32.TryParse(listBox1.SelectedItem.ToString(), out int g);
            click1.Visible = false;
            click2.Visible = false;
            click3.Visible = false;
            click4.Visible = false;
            click5.Visible = false;
            click6.Visible = false;
            click7.Visible = false;
            click8.Visible = false;
            click9.Visible = false;
            if (g == 1)
            {
                click1.Visible = true;
            }
            else if (g == 2)
            {
                click2.Visible = true;
            }
            else if (g == 3)
            {
                click2.Visible = true;
            }
            else if (g == 4)
            {
                click2.Visible = true;
            }
            else if (g == 5)
            {
                click2.Visible = true;
            }
            else if (g == 6)
            {
                click2.Visible = true;
            }
            else if (g == 7)
            {
                click2.Visible = true;
            }
            else if (g == 8)
            {
                click2.Visible = true;
            }
            else if (g == 9)
            {
                click2.Visible = true;
            }
            label2.Text = num.ToString();
            listBox1.Items.Clear();
        }
        void Ccode()
        {
            int vb = 0;
            if (click1.Visible == true) { vb = 1; }
            if (click2.Visible == true) { vb = 2; }
            if (click3.Visible == true) { vb = 3; }
            if (click4.Visible == true) { vb = 4; }
            if (click5.Visible == true) { vb = 5; }
            if (click6.Visible == true) { vb = 6; }
            if (click7.Visible == true) { vb = 7; }
            if (click8.Visible == true) { vb = 8; }
            if (click9.Visible == true) { vb = 9; }
            textBox1.Text = num + "." + vb;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "1.0";
            label2.Text = "0";
            click1.Visible = true;
            click2.Visible = false;
            click3.Visible = false;
            click4.Visible = false;
            click5.Visible = false;
            click6.Visible = false;
            click7.Visible = false;
            click8.Visible = false;
            click9.Visible = false;
            num = 0;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (textBox1.Text != "1.0")
            {
                button1.PerformClick();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ClickIt2 ci2 = new ClickIt2();
            ci2.Show();
            this.Close();
        }
    }
}
