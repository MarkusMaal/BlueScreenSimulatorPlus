using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class DictEdit : Form
    {
        internal BlueScreen me;
        private string key;
        private bool initialization = false;
        public DictEdit()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Visible = ((textBox2.Text == "os") && textBox2.Visible && (comboBox1.SelectedItem.ToString() == "strings"));
            Reload();
        }

        private void Reload()
        {
            listView1.Items.Clear();
            switch (comboBox1.SelectedItem.ToString())
            {
                case "ints":
                    foreach (KeyValuePair<string, int> kvp in me.AllInts())
                    {
                        ListViewItem li = new ListViewItem
                        {
                            Text = kvp.Key
                        };
                        li.SubItems.Add(kvp.Value.ToString());
                        listView1.Items.Add(li);
                    }
                    break;
                case "strings":
                    foreach (KeyValuePair<string, string> kvp in me.AllStrings())
                    {
                        ListViewItem li = new ListViewItem
                        {
                            Text = kvp.Key
                        };
                        li.SubItems.Add(kvp.Value);
                        listView1.Items.Add(li);
                    }
                    break;
                case "bools":
                    foreach (KeyValuePair<string, bool> kvp in me.AllBools())
                    {
                        ListViewItem li = new ListViewItem
                        {
                            Text = kvp.Key
                        };
                        li.SubItems.Add(kvp.Value.ToString());
                        listView1.Items.Add(li);
                    }
                    break;
                case "titles":
                    foreach (KeyValuePair<string, string> kvp in me.GetTitles())
                    {
                        ListViewItem li = new ListViewItem
                        {
                            Text = kvp.Key
                        };
                        li.SubItems.Add(kvp.Value);
                        listView1.Items.Add(li);
                    }
                    break;
                case "texts":
                    foreach (KeyValuePair<string, string> kvp in me.GetTexts())
                    {
                        ListViewItem li = new ListViewItem
                        {
                            Text = kvp.Key
                        };
                        li.SubItems.Add(kvp.Value);
                        listView1.Items.Add(li);
                    }
                    break;
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            initialization = true;
            if (listView1.SelectedIndices.Count > 0)
            
            {
                key = listView1.SelectedItems[0].Text;
                switch (comboBox1.SelectedItem)
                {
                    case "strings":
                        textBox1.Text = me.GetString(listView1.SelectedItems[0].Text);
                        break;
                    case "ints":
                        textBox1.Text = me.GetInt(listView1.SelectedItems[0].Text).ToString();
                        break;
                    case "bools":
                        textBox1.Text = me.GetBool(listView1.SelectedItems[0].Text).ToString();
                        break;
                    case "texts":
                        textBox1.Text = me.GetTexts()[listView1.SelectedItems[0].Text];
                        break;
                    case "titles":
                        textBox1.Text = me.GetTitles()[listView1.SelectedItems[0].Text];
                        break;
                }
            }
            initialization = false;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Focused)
            {
                switch (comboBox1.SelectedItem)
                {
                    case "strings":
                        me.SetString(key, textBox1.Text);
                        break;
                    case "texts":
                        me.SetText(key, textBox1.Text);
                        break;
                    case "titles":
                        me.SetTitle(key, textBox1.Text);
                        break;
                    case "ints":
                        try { me.SetInt(key, Convert.ToInt32(textBox1.Text)); } catch { }
                        break;
                    case "bools":
                        try
                        {
                            me.SetBool(key, Convert.ToBoolean(textBox1.Text));
                        } catch { }
                        break;
                }
                if (listView1.Visible)
                {
                    Reload();
                }
            }
            if (!initialization)
            {
                Program.templates.qaddeTrip = true;
            }
            CheckQADDE();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                listView1.Visible = false;
                textBox1.Text = "";
                listView1.Items.Clear();
                key = "";
                textBox2.Visible = true;
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox2.Visible = false;
                textBox1.Text = "";
                listView1.Visible = true;
                key = "";
                Reload();
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            key = textBox2.Text;
            label3.Visible = ((textBox2.Text == "os") && textBox2.Visible && (comboBox1.SelectedItem.ToString() == "strings"));
        }

        private void DictEdit_Load(object sender, EventArgs e)
        {
            initialization = true;
            comboBox1.SelectedIndex = 0;
            CheckQADDE();
            initialization = false;
        }

        private void CheckQADDE()
        {
            if (Program.templates.qaddeTrip)
            {
                qaddeTrip.Text = "QADDE tripped";
                qaddeTrip.ForeColor = Color.Red;
            }
        }

        private void TextBox2_VisibleChanged(object sender, EventArgs e)
        {
            label3.Visible = ((textBox2.Text == "os") && textBox2.Visible && (comboBox1.SelectedItem.ToString() == "strings"));
        }

        private void DictEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}
