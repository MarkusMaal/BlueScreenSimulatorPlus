using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
{
    public partial class ClickIt2 : Form
    {
        private bool dm = false;
        private long t = 0;
        private int val = 1;
        private int colored = 0;
        // int seed = 0;
        // Koodinimi: Vaarikas
        public ClickIt2()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            helpLabel1.Text = "";
            if (t == 666) { t = 667; }
            if (comboBox1.SelectedIndex == 0)
            {
                if (checkBox1.Checked == true) { string s = "1"; textBox1.Text = t + "." + s + "." + "1" + "." + val + "." + colored; }
                if (checkBox1.Checked == false) { string s = "0"; textBox1.Text = t + "." + s + "." + "1" + "." + val + "." + colored; }
                label1.Text = "Proovikordi: " + t;
            }
            else if (comboBox1.SelectedIndex == 1)
            {

                if (checkBox1.Checked == true) { string s = "1"; textBox1.Text = t + "." + s + "." + "2" + "." + val + "." + colored; }
                if (checkBox1.Checked == false) { string s = "0"; textBox1.Text = t + "." + s + "." + "2" + "." + val + "." + colored; }
                label1.Text = "Attempts: " + t;
            }
            else if (comboBox1.SelectedIndex == 2)
            {

                if (checkBox1.Checked == true) { string s = "1"; textBox1.Text = t + "." + s + "." + "3" + "." + val + "." + colored; }
                if (checkBox1.Checked == false) { string s = "0"; textBox1.Text = t + "." + s + "." + "3" + "." + val + "." + colored; }
                label1.Text = "Attempts: " + t;
            }
        }

        public void Rndgen()
        {
            Random rnd = new Random();
            for (int val = 0; val < 100; ++val)
            {
                ;
            }

            val = rnd.Next(1, 40);
            if (val == 1) { button1.Visible = true; }
            if (val == 2) { button2.Visible = true; }
            if (val == 3) { button3.Visible = true; }
            if (val == 4) { button4.Visible = true; }
            if (val == 5) { button5.Visible = true; }
            if (val == 6) { button6.Visible = true; }
            if (val == 7) { button7.Visible = true; }
            if (val == 8) { button8.Visible = true; }
            if (val == 9) { button9.Visible = true; }
            if (val == 10) { button10.Visible = true; }
            if (val == 11) { button11.Visible = true; }
            if (val == 12) { button12.Visible = true; }
            if (val == 13) { button13.Visible = true; }
            if (val == 14) { button14.Visible = true; }
            if (val == 15) { button15.Visible = true; }
            if (val == 16) { button16.Visible = true; }
            if (val == 17) { button17.Visible = true; }
            if (val == 18) { button18.Visible = true; }
            if (val == 19) { button19.Visible = true; }
            if (val == 20) { button20.Visible = true; }
            if (val == 21) { button21.Visible = true; }
            if (val == 22) { button22.Visible = true; }
            if (val == 23) { button23.Visible = true; }
            if (val == 24) { button24.Visible = true; }
            if (val == 25) { button25.Visible = true; }
            if (val == 26) { button26.Visible = true; }
            if (val == 27) { button27.Visible = true; }
            if (val == 28) { button28.Visible = true; }
            if (val == 29) { button29.Visible = true; }
            if (val == 30) { button30.Visible = true; }
            if (val == 31) { button31.Visible = true; }
            if (val == 32) { button32.Visible = true; }
            if (val == 33) { button33.Visible = true; }
            if (val == 34) { button34.Visible = true; }
            if (val == 35) { button35.Visible = true; }
            if (val == 36) { button36.Visible = true; }
            if (val == 37) { button37.Visible = true; }
            if (val == 38) { button38.Visible = true; }
            if (val == 39) { button39.Visible = true; }
            if (val == 40) { button40.Visible = true; }

            if (checkBox1.Checked == false) { comboBox1.BackColor = BackColor; textBox1.BackColor = Color.WhiteSmoke; goto endof; }
            for (int colored = 0; colored < 100; ++colored)
            {
                ;
            }

            colored = rnd.Next(1, 120);
            if (DateTime.Today.Month == 12)
            {
                if (DateTime.Today.Day == 24)
                {
                    colored = 94;
                }
                else if (DateTime.Today.Day == 25)
                {
                    colored = 94;
                }
                else if (DateTime.Today.Day == 26)
                {
                    colored = 94;
                }
            }
            // I'm not fixing this spaghetti, because:
            //      a) it's funny
            //      b) it's history
            //      c) it's only run when you trigger the easter egg
            if (colored == 1) { BackColor = Color.AliceBlue; }
            if (colored == 2) { BackColor = Color.AntiqueWhite; }
            if (colored == 3) { BackColor = Color.Aqua; }
            if (colored == 4) { BackColor = Color.Aquamarine; }
            if (colored == 5) { BackColor = Color.Azure; }
            if (colored == 6) { BackColor = Color.Beige; }
            if (colored == 7) { BackColor = Color.Bisque; }
            if (colored == 8) { BackColor = Color.BlanchedAlmond; }
            if (colored == 9) { BackColor = Color.Blue; }
            if (colored == 10) { BackColor = Color.BlueViolet; }
            if (colored == 11) { BackColor = Color.Brown; }
            if (colored == 12) { BackColor = Color.BurlyWood; }
            if (colored == 13) { BackColor = Color.CadetBlue; }
            if (colored == 14) { BackColor = Color.Chartreuse; }
            if (colored == 15) { BackColor = Color.Chocolate; }
            if (colored == 16) { BackColor = Color.Coral; }
            if (colored == 17) { BackColor = Color.CornflowerBlue; }
            if (colored == 18) { BackColor = Color.Cornsilk; }
            if (colored == 19) { BackColor = Color.Crimson; }
            if (colored == 20) { BackColor = Color.Cyan; }
            if (colored == 21) { BackColor = Color.DeepPink; }
            if (colored == 22) { BackColor = Color.DeepSkyBlue; }
            if (colored == 23) { BackColor = Color.DodgerBlue; }
            if (colored == 24) { BackColor = Color.Firebrick; }
            if (colored == 25) { BackColor = Color.FloralWhite; }
            if (colored == 26) { BackColor = Color.ForestGreen; }
            if (colored == 27) { BackColor = Color.Fuchsia; }
            if (colored == 28) { BackColor = Color.Gainsboro; }
            if (colored == 29) { BackColor = Color.GhostWhite; }
            if (colored == 30) { BackColor = Color.Gold; }
            if (colored == 31) { BackColor = Color.Goldenrod; }
            if (colored == 32) { BackColor = Color.Green; }
            if (colored == 33) { BackColor = Color.GreenYellow; }
            if (colored == 34) { BackColor = Color.Honeydew; }
            if (colored == 35) { BackColor = Color.HotPink; }
            if (colored == 36) { BackColor = Color.IndianRed; }
            if (colored == 37) { BackColor = Color.Indigo; }
            if (colored == 38) { BackColor = Color.Ivory; }
            if (colored == 39) { BackColor = Color.Khaki; }
            if (colored == 40) { BackColor = Color.Lavender; }
            if (colored == 41) { BackColor = Color.LavenderBlush; }
            if (colored == 42) { BackColor = Color.LawnGreen; }
            if (colored == 43) { BackColor = Color.LemonChiffon; }
            if (colored == 44) { BackColor = Color.LightBlue; }
            if (colored == 45) { BackColor = Color.LightCoral; }
            if (colored == 46) { BackColor = Color.LightCyan; }
            if (colored == 47) { BackColor = Color.LightGoldenrodYellow; }
            if (colored == 48) { BackColor = Color.LightGray; }
            if (colored == 49) { BackColor = Color.LightGreen; }
            if (colored == 50) { BackColor = Color.LightPink; }
            if (colored == 51) { BackColor = Color.LightSalmon; }
            if (colored == 52) { BackColor = Color.LightSeaGreen; }
            if (colored == 53) { BackColor = Color.LightSkyBlue; }
            if (colored == 54) { BackColor = Color.LightSlateGray; }
            if (colored == 55) { BackColor = Color.LightSteelBlue; }
            if (colored == 56) { BackColor = Color.LightYellow; }
            if (colored == 57) { BackColor = Color.Lime; }
            if (colored == 58) { BackColor = Color.LimeGreen; }
            if (colored == 59) { BackColor = Color.Linen; }
            if (colored == 60) { BackColor = Color.Magenta; }
            if (colored == 61) { BackColor = Color.Maroon; }
            if (colored == 62) { BackColor = Color.MediumAquamarine; }
            if (colored == 63) { BackColor = Color.MediumBlue; }
            if (colored == 64) { BackColor = Color.MediumOrchid; }
            if (colored == 65) { BackColor = Color.MediumPurple; }
            if (colored == 66) { BackColor = Color.MediumSeaGreen; }
            if (colored == 67) { BackColor = Color.MediumSlateBlue; }
            if (colored == 68) { BackColor = Color.MediumSpringGreen; }
            if (colored == 69) { BackColor = Color.MediumTurquoise; }
            if (colored == 70) { BackColor = Color.MediumVioletRed; }
            if (colored == 71) { BackColor = Color.MidnightBlue; }
            if (colored == 72) { BackColor = Color.MintCream; }
            if (colored == 73) { BackColor = Color.MistyRose; }
            if (colored == 74) { BackColor = Color.Moccasin; }
            if (colored == 75) { BackColor = Color.NavajoWhite; }
            if (colored == 76) { BackColor = Color.Navy; }
            if (colored == 77) { BackColor = Color.OldLace; }
            if (colored == 78) { BackColor = Color.Olive; }
            if (colored == 79) { BackColor = Color.OliveDrab; }
            if (colored == 80) { BackColor = Color.Orange; }
            if (colored == 81) { BackColor = Color.OrangeRed; }
            if (colored == 82) { BackColor = Color.Orchid; }
            if (colored == 83) { BackColor = Color.PaleGoldenrod; }
            if (colored == 84) { BackColor = Color.PaleGreen; }
            if (colored == 85) { BackColor = Color.PaleTurquoise; }
            if (colored == 86) { BackColor = Color.PaleVioletRed; }
            if (colored == 87) { BackColor = Color.PapayaWhip; }
            if (colored == 88) { BackColor = Color.PeachPuff; }
            if (colored == 89) { BackColor = Color.Peru; }
            if (colored == 90) { BackColor = Color.Pink; }
            if (colored == 91) { BackColor = Color.Plum; }
            if (colored == 92) { BackColor = Color.PowderBlue; }
            if (colored == 93) { BackColor = Color.Purple; }
            if (colored == 94) { BackColor = Color.Red; }
            if (colored == 95) { BackColor = Color.RosyBrown; }
            if (colored == 96) { BackColor = Color.RoyalBlue; }
            if (colored == 97) { BackColor = Color.SaddleBrown; }
            if (colored == 98) { BackColor = Color.Salmon; }
            if (colored == 99) { BackColor = Color.SandyBrown; }
            if (colored == 100) { BackColor = Color.SeaGreen; }
            if (colored == 101) { BackColor = Color.SeaShell; }
            if (colored == 102) { BackColor = Color.Sienna; }
            if (colored == 103) { BackColor = Color.Silver; }
            if (colored == 104) { BackColor = Color.SkyBlue; }
            if (colored == 105) { BackColor = Color.SlateBlue; }
            if (colored == 106) { BackColor = Color.SlateGray; }
            if (colored == 107) { BackColor = Color.Snow; }
            if (colored == 108) { BackColor = Color.SpringGreen; }
            if (colored == 109) { BackColor = Color.SteelBlue; }
            if (colored == 110) { BackColor = Color.Tan; }
            if (colored == 111) { BackColor = Color.Teal; }
            if (colored == 112) { BackColor = Color.Thistle; }
            if (colored == 113) { BackColor = Color.Tomato; }
            if (colored == 114) { BackColor = Color.Turquoise; }
            if (colored == 115) { BackColor = Color.Violet; }
            if (colored == 116) { BackColor = Color.Wheat; }
            if (colored == 117) { BackColor = Color.White; }
            if (colored == 118) { BackColor = Color.WhiteSmoke; }
            if (colored == 119) { BackColor = Color.Yellow; }
            if (colored == 120) { BackColor = Color.YellowGreen; }
            ForeColor = Color.FromArgb(255 - BackColor.R, 255 - BackColor.G, 255 - BackColor.B);
            comboBox1.ForeColor = Color.FromArgb(255 - BackColor.R, 255 - BackColor.G, 255 - BackColor.B);
            textBox1.ForeColor = Color.FromArgb(255 - BackColor.R, 255 - BackColor.G, 255 - BackColor.B);
            if (colored == 13) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 15) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 16) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 17) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 22) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 23) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 35) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 36) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 45) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 52) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 54) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 58) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 64) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 65) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 66) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 67) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 78) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 79) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 80) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 81) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 82) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 86) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 89) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 91) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 95) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 96) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 98) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 100) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 105) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 106) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 109) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 111) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 113) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
            if (colored == 115) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }

            if (DateTime.Today.Month == 12)
            {
                if (DateTime.Today.Day == 24)
                {
                    ForeColor = Color.ForestGreen; comboBox1.ForeColor = Color.ForestGreen; textBox1.ForeColor = Color.ForestGreen;
                }
                else if (DateTime.Today.Day == 25)
                {
                    ForeColor = Color.ForestGreen; comboBox1.ForeColor = Color.ForestGreen; textBox1.ForeColor = Color.ForestGreen;
                }
                else if (DateTime.Today.Day == 26)
                {
                    ForeColor = Color.ForestGreen; comboBox1.ForeColor = Color.ForestGreen; textBox1.ForeColor = Color.ForestGreen;
                }
            }
            textBox1.BackColor = BackColor;
            comboBox1.BackColor = BackColor;
        endof:;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Random rnd = new Random();
            //seed = rnd.Next(-2147483648, 2147483647);
            comboBox1.SelectedIndex = 1;
            Rndgen();
        }

        private void Button38_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Palun lõpeta see...", "TÕRGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                MessageBox.Show("Yeah, stop hacking please...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                MessageBox.Show("Yeah, stop hacking please...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button38_MouseClick(object sender, MouseEventArgs e)
        {
            dm = false;
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Kuidas te seda tegite??? Te olete geenius!", "Õnnitlus", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                MessageBox.Show("How did you do this??? You are a genius!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                MessageBox.Show("How did you do this??? You are a genius!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                BackColor = Color.WhiteSmoke;
                textBox1.BackColor = Color.WhiteSmoke;
                comboBox1.BackColor = Color.WhiteSmoke;
                ForeColor = Color.Black;
                comboBox1.ForeColor = Color.Black;
                textBox1.ForeColor = Color.Black;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                if (checkBox1.Checked == true) { string s = "1"; textBox1.Text = t + "." + s + "." + "1" + "." + val + "." + colored; }
                if (checkBox1.Checked == false) { string s = "0"; textBox1.Text = t + "." + s + "." + "1" + "." + val + "." + colored; }
                label1.Text = "Proovikordi: " + t;
            }
            else if (comboBox1.SelectedIndex == 1)
            {

                if (checkBox1.Checked == true) { string s = "1"; textBox1.Text = t + "." + s + "." + "2" + "." + val + "." + colored; }
                if (checkBox1.Checked == false) { string s = "0"; textBox1.Text = t + "." + s + "." + "2" + "." + val + "." + colored; }
                label1.Text = "Attempts: " + t;
            }
            else if (comboBox1.SelectedIndex == 2)
            {

                if (checkBox1.Checked == true) { string s = "1"; textBox1.Text = t + "." + s + "." + "3" + "." + val + "." + colored; }
                if (checkBox1.Checked == false) { string s = "0"; textBox1.Text = t + "." + s + "." + "3" + "." + val + "." + colored; }
                label1.Text = "Attempts: " + t;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                this.Text = "Kliki seda 2.0";
                label1.Text = "Proovikordi: " + t;
                checkBox1.Text = "Muuda värve";
                button1.Text = "Kliki siia";
                button2.Text = "Kliki siia";
                button3.Text = "Kliki siia";
                button4.Text = "Kliki siia";
                button5.Text = "Kliki siia";
                button6.Text = "Kliki siia";
                button7.Text = "Kliki siia";
                button8.Text = "Kliki siia";
                button9.Text = "Kliki siia";
                button10.Text = "Kliki siia";
                button11.Text = "Kliki siia";
                button12.Text = "Kliki siia";
                button13.Text = "Kliki siia";
                button14.Text = "Kliki siia";
                button15.Text = "Kliki siia";
                button16.Text = "Kliki siia";
                button17.Text = "Kliki siia";
                button18.Text = "Kliki siia";
                button19.Text = "Kliki siia";
                button20.Text = "Kliki siia";
                button21.Text = "Kliki siia";
                button22.Text = "Kliki siia";
                button23.Text = "Kliki siia";
                button24.Text = "Kliki siia";
                button25.Text = "Kliki siia";
                button26.Text = "Kliki siia";
                button27.Text = "Kliki siia";
                button28.Text = "Kliki siia";
                button29.Text = "Kliki siia";
                button30.Text = "Kliki siia";
                button31.Text = "Kliki siia";
                button32.Text = "Kliki siia";
                button33.Text = "Kliki siia";
                button34.Text = "Kliki siia";
                button35.Text = "Kliki siia";
                button36.Text = "Kliki siia";
                button37.Text = "Kliki siia";
                button38.Text = "Kliki siia";
                button39.Text = "Kliki siia";
                button40.Text = "Kliki siia";
                button41.Text = "Kopeeri lõikelauale";
                button42.Text = "Kasuta koodi";
            }
            else if (comboBox1.SelectedIndex == 1)
            {

                this.Text = "Click it 2.0";
                label1.Text = "Attempts: " + t;
                checkBox1.Text = "Change colors";
                button1.Text = "Click here";
                button2.Text = "Click here";
                button3.Text = "Click here";
                button4.Text = "Click here";
                button5.Text = "Click here";
                button6.Text = "Click here";
                button7.Text = "Click here";
                button8.Text = "Click here";
                button9.Text = "Click here";
                button10.Text = "Click here";
                button11.Text = "Click here";
                button12.Text = "Click here";
                button13.Text = "Click here";
                button14.Text = "Click here";
                button15.Text = "Click here";
                button16.Text = "Click here";
                button17.Text = "Click here";
                button18.Text = "Click here";
                button19.Text = "Click here";
                button20.Text = "Click here";
                button21.Text = "Click here";
                button22.Text = "Click here";
                button23.Text = "Click here";
                button24.Text = "Click here";
                button25.Text = "Click here";
                button26.Text = "Click here";
                button27.Text = "Click here";
                button28.Text = "Click here";
                button29.Text = "Click here";
                button30.Text = "Click here";
                button31.Text = "Click here";
                button32.Text = "Click here";
                button33.Text = "Click here";
                button34.Text = "Click here";
                button35.Text = "Click here";
                button36.Text = "Click here";
                button37.Text = "Click here";
                button38.Text = "Click here";
                button39.Text = "Click here";
                button40.Text = "Click here";
                button41.Text = "Copy to clipboard";
                button42.Text = "Use code";
            }
            else if (comboBox1.SelectedIndex == 2)
            {

                this.Text = "Click it 2.0";
                label1.Text = "Attempts: " + t;
                checkBox1.Text = "Change colours";
                button1.Text = "Click here";
                button2.Text = "Click here";
                button3.Text = "Click here";
                button4.Text = "Click here";
                button5.Text = "Click here";
                button6.Text = "Click here";
                button7.Text = "Click here";
                button8.Text = "Click here";
                button9.Text = "Click here";
                button10.Text = "Click here";
                button11.Text = "Click here";
                button12.Text = "Click here";
                button13.Text = "Click here";
                button14.Text = "Click here";
                button15.Text = "Click here";
                button16.Text = "Click here";
                button17.Text = "Click here";
                button18.Text = "Click here";
                button19.Text = "Click here";
                button20.Text = "Click here";
                button21.Text = "Click here";
                button22.Text = "Click here";
                button23.Text = "Click here";
                button24.Text = "Click here";
                button25.Text = "Click here";
                button26.Text = "Click here";
                button27.Text = "Click here";
                button28.Text = "Click here";
                button29.Text = "Click here";
                button30.Text = "Click here";
                button31.Text = "Click here";
                button32.Text = "Click here";
                button33.Text = "Click here";
                button34.Text = "Click here";
                button35.Text = "Click here";
                button36.Text = "Click here";
                button37.Text = "Click here";
                button38.Text = "Click here";
                button39.Text = "Click here";
                button40.Text = "Click here";
                button41.Text = "Copy to clipboard";
                button42.Text = "Use code";
            }
            if (comboBox1.SelectedIndex == 0)
            {
                if (checkBox1.Checked == true) { string s = "1"; textBox1.Text = t + "." + s + "." + "1" + "." + val + "." + colored; }
                if (checkBox1.Checked == false) { string s = "0"; textBox1.Text = t + "." + s + "." + "1" + "." + val + "." + colored; }
                label1.Text = "Proovikordi: " + t;
            }
            else if (comboBox1.SelectedIndex == 1)
            {

                if (checkBox1.Checked == true) { string s = "1"; textBox1.Text = t + "." + s + "." + "2" + "." + val + "." + colored; }
                if (checkBox1.Checked == false) { string s = "0"; textBox1.Text = t + "." + s + "." + "2" + "." + val + "." + colored; }
                label1.Text = "Attempts: " + t;
            }
            else if (comboBox1.SelectedIndex == 2)
            {

                if (checkBox1.Checked == true) { string s = "1"; textBox1.Text = t + "." + s + "." + "3" + "." + val + "." + colored; }
                if (checkBox1.Checked == false) { string s = "0"; textBox1.Text = t + "." + s + "." + "3" + "." + val + "." + colored; }
                label1.Text = "Attempts: " + t;
            }
        }

        private void Button41_Click(object sender, EventArgs e)
        {
            string s = null;
            string sc;
            if (comboBox1.SelectedIndex == 0)
            {

                if (checkBox1.Checked == true) { s = "1"; }
                if (checkBox1.Checked == false) { s = "0"; }
                sc = t + "." + s + "." + "1" + "." + val + "." + colored;
                Clipboard.SetText(sc);
            }
            else if (comboBox1.SelectedIndex == 1)
            {

                s = null;
                if (checkBox1.Checked == true) { s = "1"; }
                if (checkBox1.Checked == false) { s = "0"; }
                sc = t + "." + s + "." + "2" + "." + val + "." + colored;
                Clipboard.SetText(sc);
            }
            else if (comboBox1.SelectedIndex == 2)
            {

                s = null;
                if (checkBox1.Checked == true) { s = "1"; }
                if (checkBox1.Checked == false) { s = "0"; }
                sc = t + "." + s + "." + "3" + "." + val + "." + colored;
                Clipboard.SetText(sc);
            }
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Kopeerimine õnnestus", "Mängu kood", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Code copied to clipboard", "Game code", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button42_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {

                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    button5.Visible = false;
                    button6.Visible = false;
                    button7.Visible = false;
                    button8.Visible = false;
                    button9.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    button12.Visible = false;
                    button13.Visible = false;
                    button14.Visible = false;
                    button15.Visible = false;
                    button16.Visible = false;
                    button17.Visible = false;
                    button18.Visible = false;
                    button19.Visible = false;
                    button20.Visible = false;
                    button21.Visible = false;
                    button22.Visible = false;
                    button23.Visible = false;
                    button24.Visible = false;
                    button25.Visible = false;
                    button26.Visible = false;
                    button27.Visible = false;
                    button28.Visible = false;
                    button29.Visible = false;
                    button30.Visible = false;
                    button31.Visible = false;
                    button32.Visible = false;
                    button33.Visible = false;
                    button34.Visible = false;
                    button35.Visible = false;
                    button36.Visible = false;
                    button37.Visible = false;
                    button38.Visible = false;
                    button39.Visible = false;
                    button40.Visible = false;
                    this.BackgroundImage = null;
                    listBox1.Items.Clear();
                    string s = textBox1.Text;
                    string[] words = s.Split('.');
                    foreach (string word in words)
                    {
                        listBox1.Items.Add(word);
                    }
                    if (listBox1.Items.Count == 2)
                    {
                        if (checkBox2.CheckState == CheckState.Checked)
                        {
                            checkBox2.CheckState = CheckState.Unchecked;
                            button42.PerformClick();
                            return;
                        }
                        textBox1.Text = "0.1.1.1.0";
                        button42.PerformClick();
                        return;
                    }
                    listBox1.SelectedIndex = 0;
                    long.TryParse(listBox1.SelectedItem.ToString(), out t);
                    listBox1.SelectedIndex = 1;
                    int.TryParse(listBox1.SelectedItem.ToString(), out int g);
                    if (g == 1) { checkBox1.Checked = true; }
                    if (g == 0) { checkBox1.Checked = false; }
                    listBox1.SelectedIndex = 2;
                    int.TryParse(listBox1.SelectedItem.ToString(), out int b);
                    if (b == 1) { comboBox1.SelectedIndex = 0; }
                    if (b == 2) { comboBox1.SelectedIndex = 1; }
                    if (b == 3) { comboBox1.SelectedIndex = 2; }
                    if (comboBox1.SelectedIndex == 0)
                    {
                        label1.Text = "Proovikordi: " + t;
                    }
                    else
                    {
                        label1.Text = "Attempts: " + t;
                    }
                    listBox1.SelectedIndex = 3;
                    int.TryParse(listBox1.SelectedItem.ToString(), out val);
                    if (val == 1) { button1.Visible = true; }
                    if (val == 2) { button2.Visible = true; }
                    if (val == 3) { button3.Visible = true; }
                    if (val == 4) { button4.Visible = true; }
                    if (val == 5) { button5.Visible = true; }
                    if (val == 6) { button6.Visible = true; }
                    if (val == 7) { button7.Visible = true; }
                    if (val == 8) { button8.Visible = true; }
                    if (val == 9) { button9.Visible = true; }
                    if (val == 10) { button10.Visible = true; }
                    if (val == 11) { button11.Visible = true; }
                    if (val == 12) { button12.Visible = true; }
                    if (val == 13) { button13.Visible = true; }
                    if (val == 14) { button14.Visible = true; }
                    if (val == 15) { button15.Visible = true; }
                    if (val == 16) { button16.Visible = true; }
                    if (val == 17) { button17.Visible = true; }
                    if (val == 18) { button18.Visible = true; }
                    if (val == 19) { button19.Visible = true; }
                    if (val == 20) { button20.Visible = true; }
                    if (val == 21) { button21.Visible = true; }
                    if (val == 22) { button22.Visible = true; }
                    if (val == 23) { button23.Visible = true; }
                    if (val == 24) { button24.Visible = true; }
                    if (val == 25) { button25.Visible = true; }
                    if (val == 26) { button26.Visible = true; }
                    if (val == 27) { button27.Visible = true; }
                    if (val == 28) { button28.Visible = true; }
                    if (val == 29) { button29.Visible = true; }
                    if (val == 30) { button30.Visible = true; }
                    if (val == 31) { button31.Visible = true; }
                    if (val == 32) { button32.Visible = true; }
                    if (val == 33) { button33.Visible = true; }
                    if (val == 34) { button34.Visible = true; }
                    if (val == 35) { button35.Visible = true; }
                    if (val == 36) { button36.Visible = true; }
                    if (val == 37) { button37.Visible = true; }
                    if (val == 38) { button38.Visible = true; }
                    if (val == 39) { button39.Visible = true; }
                    if (val == 40) { button40.Visible = true; }
                    if (checkBox1.Checked == false) { comboBox1.BackColor = BackColor; BackColor = Color.WhiteSmoke; textBox1.BackColor = Color.WhiteSmoke; goto endof; }
                    listBox1.SelectedIndex = 4;
                    int.TryParse(listBox1.SelectedItem.ToString(), out colored);
                    if (colored == 1) { BackColor = Color.AliceBlue; }
                    if (colored == 2) { BackColor = Color.AntiqueWhite; }
                    if (colored == 3) { BackColor = Color.Aqua; }
                    if (colored == 4) { BackColor = Color.Aquamarine; }
                    if (colored == 5) { BackColor = Color.Azure; }
                    if (colored == 6) { BackColor = Color.Beige; }
                    if (colored == 7) { BackColor = Color.Bisque; }
                    if (colored == 8) { BackColor = Color.BlanchedAlmond; }
                    if (colored == 9) { BackColor = Color.Blue; }
                    if (colored == 10) { BackColor = Color.BlueViolet; }
                    if (colored == 11) { BackColor = Color.Brown; }
                    if (colored == 12) { BackColor = Color.BurlyWood; }
                    if (colored == 13) { BackColor = Color.CadetBlue; }
                    if (colored == 14) { BackColor = Color.Chartreuse; }
                    if (colored == 15) { BackColor = Color.Chocolate; }
                    if (colored == 16) { BackColor = Color.Coral; }
                    if (colored == 17) { BackColor = Color.CornflowerBlue; }
                    if (colored == 18) { BackColor = Color.Cornsilk; }
                    if (colored == 19) { BackColor = Color.Crimson; }
                    if (colored == 20) { BackColor = Color.Cyan; }
                    if (colored == 21) { BackColor = Color.DeepPink; }
                    if (colored == 22) { BackColor = Color.DeepSkyBlue; }
                    if (colored == 23) { BackColor = Color.DodgerBlue; }
                    if (colored == 24) { BackColor = Color.Firebrick; }
                    if (colored == 25) { BackColor = Color.FloralWhite; }
                    if (colored == 26) { BackColor = Color.ForestGreen; }
                    if (colored == 27) { BackColor = Color.Fuchsia; }
                    if (colored == 28) { BackColor = Color.Gainsboro; }
                    if (colored == 29) { BackColor = Color.GhostWhite; }
                    if (colored == 30) { BackColor = Color.Gold; }
                    if (colored == 31) { BackColor = Color.Goldenrod; }
                    if (colored == 32) { BackColor = Color.Green; }
                    if (colored == 33) { BackColor = Color.GreenYellow; }
                    if (colored == 34) { BackColor = Color.Honeydew; }
                    if (colored == 35) { BackColor = Color.HotPink; }
                    if (colored == 36) { BackColor = Color.IndianRed; }
                    if (colored == 37) { BackColor = Color.Indigo; }
                    if (colored == 38) { BackColor = Color.Ivory; }
                    if (colored == 39) { BackColor = Color.Khaki; }
                    if (colored == 40) { BackColor = Color.Lavender; }
                    if (colored == 41) { BackColor = Color.LavenderBlush; }
                    if (colored == 42) { BackColor = Color.LawnGreen; }
                    if (colored == 43) { BackColor = Color.LemonChiffon; }
                    if (colored == 44) { BackColor = Color.LightBlue; }
                    if (colored == 45) { BackColor = Color.LightCoral; }
                    if (colored == 46) { BackColor = Color.LightCyan; }
                    if (colored == 47) { BackColor = Color.LightGoldenrodYellow; }
                    if (colored == 48) { BackColor = Color.LightGray; }
                    if (colored == 49) { BackColor = Color.LightGreen; }
                    if (colored == 50) { BackColor = Color.LightPink; }
                    if (colored == 51) { BackColor = Color.LightSalmon; }
                    if (colored == 52) { BackColor = Color.LightSeaGreen; }
                    if (colored == 53) { BackColor = Color.LightSkyBlue; }
                    if (colored == 54) { BackColor = Color.LightSlateGray; }
                    if (colored == 55) { BackColor = Color.LightSteelBlue; }
                    if (colored == 56) { BackColor = Color.LightYellow; }
                    if (colored == 57) { BackColor = Color.Lime; }
                    if (colored == 58) { BackColor = Color.LimeGreen; }
                    if (colored == 59) { BackColor = Color.Linen; }
                    if (colored == 60) { BackColor = Color.Magenta; }
                    if (colored == 61) { BackColor = Color.Maroon; }
                    if (colored == 62) { BackColor = Color.MediumAquamarine; }
                    if (colored == 63) { BackColor = Color.MediumBlue; }
                    if (colored == 64) { BackColor = Color.MediumOrchid; }
                    if (colored == 65) { BackColor = Color.MediumPurple; }
                    if (colored == 66) { BackColor = Color.MediumSeaGreen; }
                    if (colored == 67) { BackColor = Color.MediumSlateBlue; }
                    if (colored == 68) { BackColor = Color.MediumSpringGreen; }
                    if (colored == 69) { BackColor = Color.MediumTurquoise; }
                    if (colored == 70) { BackColor = Color.MediumVioletRed; }
                    if (colored == 71) { BackColor = Color.MidnightBlue; }
                    if (colored == 72) { BackColor = Color.MintCream; }
                    if (colored == 73) { BackColor = Color.MistyRose; }
                    if (colored == 74) { BackColor = Color.Moccasin; }
                    if (colored == 75) { BackColor = Color.NavajoWhite; }
                    if (colored == 76) { BackColor = Color.Navy; }
                    if (colored == 77) { BackColor = Color.OldLace; }
                    if (colored == 78) { BackColor = Color.Olive; }
                    if (colored == 79) { BackColor = Color.OliveDrab; }
                    if (colored == 80) { BackColor = Color.Orange; }
                    if (colored == 81) { BackColor = Color.OrangeRed; }
                    if (colored == 82) { BackColor = Color.Orchid; }
                    if (colored == 83) { BackColor = Color.PaleGoldenrod; }
                    if (colored == 84) { BackColor = Color.PaleGreen; }
                    if (colored == 85) { BackColor = Color.PaleTurquoise; }
                    if (colored == 86) { BackColor = Color.PaleVioletRed; }
                    if (colored == 87) { BackColor = Color.PapayaWhip; }
                    if (colored == 88) { BackColor = Color.PeachPuff; }
                    if (colored == 89) { BackColor = Color.Peru; }
                    if (colored == 90) { BackColor = Color.Pink; }
                    if (colored == 91) { BackColor = Color.Plum; }
                    if (colored == 92) { BackColor = Color.PowderBlue; }
                    if (colored == 93) { BackColor = Color.Purple; }
                    if (colored == 94) { BackColor = Color.Red; }
                    if (colored == 95) { BackColor = Color.RosyBrown; }
                    if (colored == 96) { BackColor = Color.RoyalBlue; }
                    if (colored == 97) { BackColor = Color.SaddleBrown; }
                    if (colored == 98) { BackColor = Color.Salmon; }
                    if (colored == 99) { BackColor = Color.SandyBrown; }
                    if (colored == 100) { BackColor = Color.SeaGreen; }
                    if (colored == 101) { BackColor = Color.SeaShell; }
                    if (colored == 102) { BackColor = Color.Sienna; }
                    if (colored == 103) { BackColor = Color.Silver; }
                    if (colored == 104) { BackColor = Color.SkyBlue; }
                    if (colored == 105) { BackColor = Color.SlateBlue; }
                    if (colored == 106) { BackColor = Color.SlateGray; }
                    if (colored == 107) { BackColor = Color.Snow; }
                    if (colored == 108) { BackColor = Color.SpringGreen; }
                    if (colored == 109) { BackColor = Color.SteelBlue; }
                    if (colored == 110) { BackColor = Color.Tan; }
                    if (colored == 111) { BackColor = Color.Teal; }
                    if (colored == 112) { BackColor = Color.Thistle; }
                    if (colored == 113) { BackColor = Color.Tomato; }
                    if (colored == 114) { BackColor = Color.Turquoise; }
                    if (colored == 115) { BackColor = Color.Violet; }
                    if (colored == 116) { BackColor = Color.Wheat; }
                    if (colored == 117) { BackColor = Color.White; }
                    if (colored == 118) { BackColor = Color.WhiteSmoke; }
                    if (colored == 119) { BackColor = Color.Yellow; }
                    if (colored == 120) { BackColor = Color.YellowGreen; }
                    comboBox1.ForeColor = Color.FromArgb(255 - BackColor.R, 255 - BackColor.G, 255 - BackColor.B);
                    textBox1.ForeColor = Color.FromArgb(255 - BackColor.R, 255 - BackColor.G, 255 - BackColor.B);
                    ForeColor = Color.FromArgb(255 - BackColor.R, 255 - BackColor.G, 255 - BackColor.B);
                    if (colored == 13) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 15) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 16) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 17) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 22) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 23) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 35) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 36) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 45) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 52) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 54) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 58) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 64) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 66) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 67) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 78) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 79) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 80) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 81) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 82) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 86) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 89) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 91) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 95) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 96) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 98) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 100) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 105) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 106) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 109) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 111) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 113) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    if (colored == 115) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                    textBox1.BackColor = BackColor;
                    comboBox1.BackColor = BackColor;
                endof:;
                    /* listBox1.SelectedIndex = 5;
                     Int32.TryParse(listBox1.SelectedItem.ToString(), out seed);
                     rndgen(); */
                }
                else
                {
                    textBox1.Paste();
                    button42.PerformClick();
                }
            }
            catch (Exception a) when (!Debugger.IsAttached)
            {
                if (comboBox1.SelectedIndex == 0) { MessageBox.Show("Olge kindlad, et kirjutasite koodi õigesti\n" + a.Message + "\n" + a.InnerException, "Kood ei sobi", MessageBoxButtons.OK, MessageBoxIcon.Error); textBox1.Text = "0.1.1.1.0"; }
                if (comboBox1.SelectedIndex == 1) { MessageBox.Show("Make sure you typed the code correctly\n" + a.Message + "\n" + a.InnerException, "Code is not compatible", MessageBoxButtons.OK, MessageBoxIcon.Error); textBox1.Text = "0.1.2.1.0"; }
                if (comboBox1.SelectedIndex == 2) { MessageBox.Show("Make sure you typed the code correctly\n" + a.Message + "\n" + a.InnerException, "Code is not compatible", MessageBoxButtons.OK, MessageBoxIcon.Error); textBox1.Text = "0.1.3.1.0"; }
                button42.PerformClick();
            }
        }
        private void Button38_MouseMove_1(object sender, MouseEventArgs e)
        {

            if (dm == false)
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                button15.Visible = false;
                button16.Visible = false;
                button17.Visible = false;
                button18.Visible = false;
                button19.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button22.Visible = false;
                button23.Visible = false;
                button24.Visible = false;
                button25.Visible = false;
                button26.Visible = false;
                button27.Visible = false;
                button28.Visible = false;
                button29.Visible = false;
                button30.Visible = false;
                button31.Visible = false;
                button32.Visible = false;
                button33.Visible = false;
                button34.Visible = false;
                button35.Visible = false;
                button36.Visible = false;
                button37.Visible = false;
                button38.Visible = false;
                button39.Visible = false;
                button40.Visible = false;
                Rndgen();
            }
            if (t == 2809)
            {
                this.BackgroundImage = Properties.Resources.MarkusTegelane_element_brandpic;
            }
            t++;
            if (t < 0)
            {
                dm = true;
                t = 0;
            }
        }

        private void TextBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Clear();

            textBox1.Paste();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                dm = true;
                progressBar1.Value = progressBar1.Minimum;
            }
            else
            {
                dm = false;
                progressBar1.Increment(1);
            }
        }

        private void Label1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.CheckState == CheckState.Checked)
                {
                    checkBox2.CheckState = CheckState.Unchecked;
                    button42.PerformClick();
                    return;
                }
            }
            catch
            {

            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Random rnd = new Random();
                colored = rnd.Next(1, 121);
                if (DateTime.Today.Month == 12)
                {
                    if (DateTime.Today.Day == 24)
                    {
                        colored = 94;
                    }
                    else if (DateTime.Today.Day == 25)
                    {
                        colored = 94;
                    }
                    else if (DateTime.Today.Day == 26)
                    {
                        colored = 94;
                    }
                }
                if (colored == 1) { BackColor = Color.AliceBlue; }
                if (colored == 2) { BackColor = Color.AntiqueWhite; }
                if (colored == 3) { BackColor = Color.Aqua; }
                if (colored == 4) { BackColor = Color.Aquamarine; }
                if (colored == 5) { BackColor = Color.Azure; }
                if (colored == 6) { BackColor = Color.Beige; }
                if (colored == 7) { BackColor = Color.Bisque; }
                if (colored == 8) { BackColor = Color.BlanchedAlmond; }
                if (colored == 9) { BackColor = Color.Blue; }
                if (colored == 10) { BackColor = Color.BlueViolet; }
                if (colored == 11) { BackColor = Color.Brown; }
                if (colored == 12) { BackColor = Color.BurlyWood; }
                if (colored == 13) { BackColor = Color.CadetBlue; }
                if (colored == 14) { BackColor = Color.Chartreuse; }
                if (colored == 15) { BackColor = Color.Chocolate; }
                if (colored == 16) { BackColor = Color.Coral; }
                if (colored == 17) { BackColor = Color.CornflowerBlue; }
                if (colored == 18) { BackColor = Color.Cornsilk; }
                if (colored == 19) { BackColor = Color.Crimson; }
                if (colored == 20) { BackColor = Color.Cyan; }
                if (colored == 21) { BackColor = Color.DeepPink; }
                if (colored == 22) { BackColor = Color.DeepSkyBlue; }
                if (colored == 23) { BackColor = Color.DodgerBlue; }
                if (colored == 24) { BackColor = Color.Firebrick; }
                if (colored == 25) { BackColor = Color.FloralWhite; }
                if (colored == 26) { BackColor = Color.ForestGreen; }
                if (colored == 27) { BackColor = Color.Fuchsia; }
                if (colored == 28) { BackColor = Color.Gainsboro; }
                if (colored == 29) { BackColor = Color.GhostWhite; }
                if (colored == 30) { BackColor = Color.Gold; }
                if (colored == 31) { BackColor = Color.Goldenrod; }
                if (colored == 32) { BackColor = Color.Green; }
                if (colored == 33) { BackColor = Color.GreenYellow; }
                if (colored == 34) { BackColor = Color.Honeydew; }
                if (colored == 35) { BackColor = Color.HotPink; }
                if (colored == 36) { BackColor = Color.IndianRed; }
                if (colored == 37) { BackColor = Color.Indigo; }
                if (colored == 38) { BackColor = Color.Ivory; }
                if (colored == 39) { BackColor = Color.Khaki; }
                if (colored == 40) { BackColor = Color.Lavender; }
                if (colored == 41) { BackColor = Color.LavenderBlush; }
                if (colored == 42) { BackColor = Color.LawnGreen; }
                if (colored == 43) { BackColor = Color.LemonChiffon; }
                if (colored == 44) { BackColor = Color.LightBlue; }
                if (colored == 45) { BackColor = Color.LightCoral; }
                if (colored == 46) { BackColor = Color.LightCyan; }
                if (colored == 47) { BackColor = Color.LightGoldenrodYellow; }
                if (colored == 48) { BackColor = Color.LightGray; }
                if (colored == 49) { BackColor = Color.LightGreen; }
                if (colored == 50) { BackColor = Color.LightPink; }
                if (colored == 51) { BackColor = Color.LightSalmon; }
                if (colored == 52) { BackColor = Color.LightSeaGreen; }
                if (colored == 53) { BackColor = Color.LightSkyBlue; }
                if (colored == 54) { BackColor = Color.LightSlateGray; }
                if (colored == 55) { BackColor = Color.LightSteelBlue; }
                if (colored == 56) { BackColor = Color.LightYellow; }
                if (colored == 57) { BackColor = Color.Lime; }
                if (colored == 58) { BackColor = Color.LimeGreen; }
                if (colored == 59) { BackColor = Color.Linen; }
                if (colored == 60) { BackColor = Color.Magenta; }
                if (colored == 61) { BackColor = Color.Maroon; }
                if (colored == 62) { BackColor = Color.MediumAquamarine; }
                if (colored == 63) { BackColor = Color.MediumBlue; }
                if (colored == 64) { BackColor = Color.MediumOrchid; }
                if (colored == 65) { BackColor = Color.MediumPurple; }
                if (colored == 66) { BackColor = Color.MediumSeaGreen; }
                if (colored == 67) { BackColor = Color.MediumSlateBlue; }
                if (colored == 68) { BackColor = Color.MediumSpringGreen; }
                if (colored == 69) { BackColor = Color.MediumTurquoise; }
                if (colored == 70) { BackColor = Color.MediumVioletRed; }
                if (colored == 71) { BackColor = Color.MidnightBlue; }
                if (colored == 72) { BackColor = Color.MintCream; }
                if (colored == 73) { BackColor = Color.MistyRose; }
                if (colored == 74) { BackColor = Color.Moccasin; }
                if (colored == 75) { BackColor = Color.NavajoWhite; }
                if (colored == 76) { BackColor = Color.Navy; }
                if (colored == 77) { BackColor = Color.OldLace; }
                if (colored == 78) { BackColor = Color.Olive; }
                if (colored == 79) { BackColor = Color.OliveDrab; }
                if (colored == 80) { BackColor = Color.Orange; }
                if (colored == 81) { BackColor = Color.OrangeRed; }
                if (colored == 82) { BackColor = Color.Orchid; }
                if (colored == 83) { BackColor = Color.PaleGoldenrod; }
                if (colored == 84) { BackColor = Color.PaleGreen; }
                if (colored == 85) { BackColor = Color.PaleTurquoise; }
                if (colored == 86) { BackColor = Color.PaleVioletRed; }
                if (colored == 87) { BackColor = Color.PapayaWhip; }
                if (colored == 88) { BackColor = Color.PeachPuff; }
                if (colored == 89) { BackColor = Color.Peru; }
                if (colored == 90) { BackColor = Color.Pink; }
                if (colored == 91) { BackColor = Color.Plum; }
                if (colored == 92) { BackColor = Color.PowderBlue; }
                if (colored == 93) { BackColor = Color.Purple; }
                if (colored == 94) { BackColor = Color.Red; }
                if (colored == 95) { BackColor = Color.RosyBrown; }
                if (colored == 96) { BackColor = Color.RoyalBlue; }
                if (colored == 97) { BackColor = Color.SaddleBrown; }
                if (colored == 98) { BackColor = Color.Salmon; }
                if (colored == 99) { BackColor = Color.SandyBrown; }
                if (colored == 100) { BackColor = Color.SeaGreen; }
                if (colored == 101) { BackColor = Color.SeaShell; }
                if (colored == 102) { BackColor = Color.Sienna; }
                if (colored == 103) { BackColor = Color.Silver; }
                if (colored == 104) { BackColor = Color.SkyBlue; }
                if (colored == 105) { BackColor = Color.SlateBlue; }
                if (colored == 106) { BackColor = Color.SlateGray; }
                if (colored == 107) { BackColor = Color.Snow; }
                if (colored == 108) { BackColor = Color.SpringGreen; }
                if (colored == 109) { BackColor = Color.SteelBlue; }
                if (colored == 110) { BackColor = Color.Tan; }
                if (colored == 111) { BackColor = Color.Teal; }
                if (colored == 112) { BackColor = Color.Thistle; }
                if (colored == 113) { BackColor = Color.Tomato; }
                if (colored == 114) { BackColor = Color.Turquoise; }
                if (colored == 115) { BackColor = Color.Violet; }
                if (colored == 116) { BackColor = Color.Wheat; }
                if (colored == 117) { BackColor = Color.White; }
                if (colored == 118) { BackColor = Color.WhiteSmoke; }
                if (colored == 119) { BackColor = Color.Yellow; }
                if (colored == 120) { BackColor = Color.YellowGreen; }
                ForeColor = Color.FromArgb(255 - BackColor.R, 255 - BackColor.G, 255 - BackColor.B);
                comboBox1.ForeColor = Color.FromArgb(255 - BackColor.R, 255 - BackColor.G, 255 - BackColor.B);
                textBox1.ForeColor = Color.FromArgb(255 - BackColor.R, 255 - BackColor.G, 255 - BackColor.B);
                if (colored == 13) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 15) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 16) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 17) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 22) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 23) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 35) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 36) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 45) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 52) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 54) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 58) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 64) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 65) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 66) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 67) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 78) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 79) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 80) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 81) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 82) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 86) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 89) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 91) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 95) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 96) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 98) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 100) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 105) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 106) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 109) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 111) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 113) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                if (colored == 115) { ForeColor = Color.White; comboBox1.ForeColor = Color.White; textBox1.ForeColor = Color.White; }
                textBox1.BackColor = BackColor;
                comboBox1.BackColor = BackColor;
            }
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Kliki seda\n\nÕpetus:\nMängu eesmärkiks on klikkida nupule, kuigi see pole väga lihtne. Üleval vasakus osas on teie proovikorrad. All vasakul on praegune mängu kood, mida saate kopeerida ja hiljem kasutada (või jagada teistega). All paremal näete keelevalikut ja värvi muutmise valikut. \n\nTeave:\nKliki seda 2.01i ja 1.02i\nLoodud Visual C# keeles\nJärk 280819");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                MessageBox.Show("Click it\n\nTutorial:\nThe goal of the game is to click on a button, which is not easy at all. On the top left you have your attempts. On the bottom left is current game code, which you can copy and use later (or share with others). On the bottom right, you see options for language and colors. \n\nAbout:\nClick it 2.01i and 1.01i\nWritten in Visual C# language\nBuild 280819");

            }
            else if (comboBox1.SelectedIndex == 2)
            {
                MessageBox.Show("Click it\n\nTutorial:\nThe goal of the game is to click on a button, which is not easy at all. On the top left you have your attempts. On the bottom left is current game code, which you can copy and use later (or share with others). On the bottom right, you see options for language and colours. \n\nAbout:\nClick it 2.01i and 1.01i\nWritten in Visual C# language\nBuild 280819");

            }
        }

        private void ComboBox1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (comboBox1.SelectedIndex == 0) { helpLabel1.Text = "Selle nupuga saate muuta mängu keelt"; }
            if (comboBox1.SelectedIndex == 1) { helpLabel1.Text = "You can change the language of the game using this button"; }
            if (comboBox1.SelectedIndex == 2) { helpLabel1.Text = "You can change the language of the game using this button"; }
        }

        private void CheckBox1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (comboBox1.SelectedIndex == 0) { helpLabel1.Text = "Selle märkeruudu abil saate lubada värvide muutumise iga proovikorra järel"; }
            if (comboBox1.SelectedIndex == 1) { helpLabel1.Text = "With this checkbox, you can enable the changing colors after every attempt"; }
            if (comboBox1.SelectedIndex == 2) { helpLabel1.Text = "With this checkbox, you can enable the changing colours after every attempt"; }
        }

        private void Button41_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (comboBox1.SelectedIndex == 0) { helpLabel1.Text = "See nupp võimaldab teil kopeerida mängu koodi \"lõikelauale\", tänu millele saate seda kuhugi mujale kleepida "; }
            if (comboBox1.SelectedIndex == 1) { helpLabel1.Text = "This buttons allows you to copy the game code to your \"clipboard\", which allows you to paste it somewere else"; }
            if (comboBox1.SelectedIndex == 2) { helpLabel1.Text = "This buttons allows you to copy the game code to your \"clipboard\", which allows you to paste it somewere else"; }

        }

        private void Button42_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

            if (comboBox1.SelectedIndex == 0) { helpLabel1.Text = "Võimaldab teil kasutada kleebitud koodi"; }
            if (comboBox1.SelectedIndex == 1) { helpLabel1.Text = "Allows you to use the code you pasted"; }
            if (comboBox1.SelectedIndex == 2) { helpLabel1.Text = "Allows you to use the code you pasted"; }

        }

        private void TextBox1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

            if (comboBox1.SelectedIndex == 0) { helpLabel1.Text = "Siia saate kleepida koodi, mis teile saadeti"; }
            if (comboBox1.SelectedIndex == 1) { helpLabel1.Text = "Here you can paste the code"; }
            if (comboBox1.SelectedIndex == 2) { helpLabel1.Text = "Here you can paste the code"; }

        }

        private void Button38_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

            if (comboBox1.SelectedIndex == 0) { helpLabel1.Text = "Seda nuppu peate te peate klikkima"; }
            if (comboBox1.SelectedIndex == 1) { helpLabel1.Text = "This is the button you have to click"; }
            if (comboBox1.SelectedIndex == 2) { helpLabel1.Text = "This is the button you have to click"; }

        }

        private void Label1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (comboBox1.SelectedIndex == 0) { helpLabel1.Text = "Siin näete enda proovikordi nupule vajutamiseks"; }
            if (comboBox1.SelectedIndex == 1) { helpLabel1.Text = "Here you can see the attempts you have made to press the button"; }
            if (comboBox1.SelectedIndex == 2) { helpLabel1.Text = "Here you can see the attempts you have made to press the button"; }

        }

        private void HelpLabel1_MouseMove(object sender, MouseEventArgs e)
        {
            helpLabel1.Text = "";
        }

        private void Label2_MouseMove(object sender, MouseEventArgs e)
        {

            helpLabel1.Text = "";
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            helpLabel1.Text = "";
            if (t == 666) { t = 667; }
            if (comboBox1.SelectedIndex == 0)
            {
                if (checkBox1.Checked == true) { string s = "1"; textBox1.Text = t + "." + s + "." + "1" + "." + val + "." + colored; }
                if (checkBox1.Checked == false) { string s = "0"; textBox1.Text = t + "." + s + "." + "1" + "." + val + "." + colored; }
                label1.Text = "Proovikordi: " + t;
            }
            else if (comboBox1.SelectedIndex == 1)
            {

                if (checkBox1.Checked == true) { string s = "1"; textBox1.Text = t + "." + s + "." + "2" + "." + val + "." + colored; }
                if (checkBox1.Checked == false) { string s = "0"; textBox1.Text = t + "." + s + "." + "2" + "." + val + "." + colored; }
                label1.Text = "Attempts: " + t;
            }
            else if (comboBox1.SelectedIndex == 2)
            {

                if (checkBox1.Checked == true) { string s = "1"; textBox1.Text = t + "." + s + "." + "3" + "." + val + "." + colored; }
                if (checkBox1.Checked == false) { string s = "0"; textBox1.Text = t + "." + s + "." + "3" + "." + val + "." + colored; }
                label1.Text = "Attempts: " + t;
            }
        }


        private void Form1_Click(object sender, EventArgs e)
        {
            if (t > 2808)
            {
                if (this.BackgroundImage != null)
                {
                    this.BackgroundImage = null;
                }
                else
                {
                    this.BackgroundImage = Properties.Resources.MarkusTegelane_element_brandpic;
                }
            }
        }

        private void ClickIt2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}
