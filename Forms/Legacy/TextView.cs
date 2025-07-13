using System;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator.Forms.Legacy
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
            if (this.Text == "Sample Title")
            {
                return;
            }

            textBox1.Text = this.Text;
            this.Text = Title;
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 0;
            textBox1.DeselectAll();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 0;
            textBox1.DeselectAll();
        }

        private void TextView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}
