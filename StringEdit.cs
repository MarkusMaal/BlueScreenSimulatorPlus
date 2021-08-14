using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class StringEdit : Form
    {
        internal BlueScreen me;
        private string editable = "";
        private string type = "String";
        private bool theme_bg = false;
        private bool theme_hl = false;
        public StringEdit()
        {
            InitializeComponent();
        }

        public void ReRe()
        {
            Program.bluescreens.Clear();
            Program.bluescreens.Add(new BlueScreen("Windows 3.1x"));
            Program.bluescreens.Add(new BlueScreen("Windows 9x/Me"));
            Program.bluescreens.Add(new BlueScreen("Windows CE"));
            Program.bluescreens.Add(new BlueScreen("Windows NT 3.x/4.0"));
            Program.bluescreens.Add(new BlueScreen("Windows 2000"));
            Program.bluescreens.Add(new BlueScreen("Windows XP"));
            Program.bluescreens.Add(new BlueScreen("Windows Vista/7"));
            Program.bluescreens.Add(new BlueScreen("Windows 8/8.1"));
            Program.bluescreens.Add(new BlueScreen("Windows 10"));
            Program.bluescreens.Add(new BlueScreen("Windows 11"));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ReRe();
        }

        private void StringEdit_Load(object sender, EventArgs e)
        {
            HideAllProps();
            MessageView.Clear();
            UpdateMessageView();
        }

        private void winVers_ItemActivate(object sender, EventArgs e)
        {

        }
        
        private ListViewItem GetColorListViewItem(string title, Color color)
        {
            ListViewItem li = new ListViewItem();
            li.ImageIndex = 6;
            li.Text = title;
            li.SubItems.Add("RGB(" + color.R + ", " + color.G + ", " + color.B + ")");
            return li;
        }

        private void winVers_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideAllProps();
            MessageView.Clear();
            UpdateMessageView();
        }

        private void UpdateMessageView()
        {
            MessageView.Columns.Add("Property");
            MessageView.Columns.Add("Value");
            MessageView.Columns[0].Width = 120;
            MessageView.Columns[1].Width = 150;
            IDictionary<string, string> titles = me.GetTitles();
            IDictionary<string, string> texts = me.GetTexts();
            if ((me.GetString("os") == "Windows 8/8.1") || me.GetBool("winxplus"))
            {
                ListViewItem li = new ListViewItem();
                li.Text = "String: Emoticon";
                li.SubItems.Add(me.GetString("emoticon"));
                li.ImageIndex = 4;
                MessageView.Items.Add(li);
            }
            foreach (KeyValuePair<string, string> entry in titles)
            {
                ListViewItem li = new ListViewItem();
                li.Text = "Title: " + entry.Key;
                li.SubItems.Add(entry.Value);
                li.ImageIndex = 4;
                MessageView.Items.Add(li);
            }
            foreach (KeyValuePair<string, string> entry in texts)
            {
                ListViewItem li = new ListViewItem();
                li.Text = "Text: " + entry.Key;
                li.SubItems.Add(entry.Value);
                li.ImageIndex = 4;
                MessageView.Items.Add(li);
            }
            if (me.GetBool("font_support"))
            {
                ListViewItem lsti = new ListViewItem();
                lsti.Text = "Font";
                lsti.SubItems.Add(me.GetFont().FontFamily.Name + " " + me.GetFont().Size.ToString() + "pt");
                lsti.ImageIndex = 5;
                MessageView.Items.Add(lsti);
            }
            if (me.GetString("os") == "Windows CE")
            {
                ListViewItem lsti = new ListViewItem();
                lsti.Text = "Set restart timer";
                lsti.SubItems.Add(me.GetInt("timer").ToString() + " sec");
                lsti.ImageIndex = 5;
                MessageView.Items.Add(lsti);
            }
            if (me.GetBool("blinkblink"))
            {
                ListViewItem lsti = new ListViewItem();
                lsti.Text = "Blink speed";
                lsti.SubItems.Add(me.GetInt("blink_speed").ToString() + "ms");
                lsti.ImageIndex = 5;
                MessageView.Items.Add(lsti);
            }
            if (me.GetBool("winxplus"))
            {
                ListViewItem lsti = new ListViewItem();
                lsti.Text = "QR code image";
                lsti.SubItems.Add(me.GetString("qr_file").Replace("local:0", "Default").Replace("local:1", "Transparent"));
                lsti.ImageIndex = 5;
                MessageView.Items.Add(lsti);

                lsti = new ListViewItem();
                lsti.Text = "QR code size";
                lsti.SubItems.Add(me.GetInt("qr_size").ToString());
                lsti.ImageIndex = 5;
                MessageView.Items.Add(lsti);
            }
            MessageView.Items.Add(GetColorListViewItem("Background color", me.GetTheme(true)));
            MessageView.Items.Add(GetColorListViewItem("Foreground color", me.GetTheme(false)));
            if ((me.GetString("os") == "Windows 3.1x") || (me.GetString("os") == "Windows 9x/Me"))
            {
                MessageView.Items.Add(GetColorListViewItem("Highlight background", me.GetTheme(true, true)));
                MessageView.Items.Add(GetColorListViewItem("Highlight foreground", me.GetTheme(false, true)));
            }
        }

        private void HideAllProps()
        {
            colorProps.Visible = false;
            stringProps.Visible = false;
            blinkProps.Visible = false;
            fontProps.Visible = false;
            timeoutProps.Visible = false;
            qrProps.Visible = false;
            specificProps.Text = "";
            previewLabel.Text = "Preview: ";
            blinkingDash.Text = "_";
            blinkywinky.Enabled = false;
        }

        private void MessageView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageView.SelectedIndices.Count > 0)
            {
                string selection = MessageView.SelectedItems[0].Text;
                if (selection.StartsWith("Title: "))
                {
                    this.type = "title";
                    this.editable = MessageView.SelectedItems[0].Text.Substring(7);
                    stringEditor.Text = MessageView.SelectedItems[0].SubItems[1].Text;
                    HideAllProps();
                    stringProps.Visible = true;
                    specificProps.Text = "String properties";
                }
                else if (selection.StartsWith("Text: "))
                {
                    this.type = "text";
                    this.editable = MessageView.SelectedItems[0].Text.Substring(6);
                    stringEditor.Text = MessageView.SelectedItems[0].SubItems[1].Text;
                    HideAllProps();
                    stringProps.Visible = true;
                    specificProps.Text = "String properties";
                }
                else if (selection.StartsWith("String: "))
                {
                    this.type = "string";
                    this.editable = MessageView.SelectedItems[0].Text.Substring(8).ToLower();
                    stringEditor.Text = MessageView.SelectedItems[0].SubItems[1].Text;
                    HideAllProps();
                    stringProps.Visible = true;
                    specificProps.Text = "String properties";
                }
                else if (selection == "Background color")
                {
                    this.theme_bg = true;
                    this.theme_hl = false;
                    colorPreview.BackColor = me.GetTheme(true);
                    HideAllProps();
                    colorProps.Visible = true;
                    specificProps.Text = "Color properties";
                }
                else if (selection == "Foreground color")
                {
                    this.theme_bg = false;
                    this.theme_hl = false;
                    colorPreview.BackColor = me.GetTheme(false);
                    HideAllProps();
                    colorProps.Visible = true;
                    specificProps.Text = "Color properties";
                }
                else if (selection == "Highlight background")
                {
                    this.theme_bg = true;
                    this.theme_hl = true;
                    colorPreview.BackColor = me.GetTheme(true, true);
                    HideAllProps();
                    colorProps.Visible = true;
                    specificProps.Text = "Color properties";
                }
                else if (selection == "Highlight foreground")
                {
                    this.theme_bg = false;
                    this.theme_hl = true;
                    colorPreview.BackColor = me.GetTheme(false, true);
                    HideAllProps();
                    colorProps.Visible = true;
                    specificProps.Text = "Color properties";
                }
                else if (selection == "Blink speed")
                {
                    speedTrackbar.Value = me.GetInt("blink_speed");
                    HideAllProps();
                    blinkywinky.Interval = me.GetInt("blink_speed");
                    blinkywinky.Enabled = true;
                    blinkProps.Visible = true;
                    specificProps.Text = "Blink speed properties";
                }
                else if (selection == "Font")
                {
                    HideAllProps();
                    fontPreview.Font = me.GetFont();
                    fontChooser.Font = me.GetFont();
                    fontProps.Visible = true;
                    specificProps.Text = "Font properties";
                }
                else if (selection == "Set restart timer")
                {
                    timeoutBox.Text = me.GetInt("timer").ToString();
                    HideAllProps();
                    timeoutProps.Visible = true;
                    specificProps.Text = "Timer properties";
                }
                else if (selection == "QR code size")
                {
                    HideAllProps();
                    previewLabel.Text = "Size: ";
                    blinkingDash.Text = me.GetInt("qr_size").ToString();
                    speedTrackbar.Value = me.GetInt("qr_size");
                    blinkProps.Visible = true;
                    specificProps.Text = "QR code size properties";
                }
                else if (selection == "QR code image")
                {
                    HideAllProps();
                    defaultRadioBtn.Checked = false;
                    transparentRadioBtn.Checked = false;
                    customRadioBtn.Checked = false;
                    if (me.GetString("qr_file") == "local:0")
                    {
                        defaultRadioBtn.Checked = true;
                    }
                    else if (me.GetString("qr_file") == "local:1")
                    {
                        transparentRadioBtn.Checked = true;
                    }
                    else
                    {
                        customRadioBtn.Checked = true;
                    }
                    filenameLabel.Text = "Filename: " + me.GetString("qr_file");
                    qrProps.Visible = true;
                    specificProps.Text = "QR code image properties";
                }
            } else
            {
                HideAllProps();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (stringProps.Visible)
            {
                if (this.type == "title")
                {
                    me.SetTitle(editable, stringEditor.Text);
                    MessageView.Clear();
                    UpdateMessageView();
                }
                else if (this.type == "text")
                {
                    me.SetText(editable, stringEditor.Text);
                    MessageView.Clear();
                    UpdateMessageView();
                }
                else if (this.type == "string")
                {
                    me.SetString(editable, stringEditor.Text);
                    MessageView.Clear();
                    UpdateMessageView();
                }
            }
        }

        private void StringEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            HideAllProps();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorChooser.ShowDialog() == DialogResult.OK)
            {
                colorPreview.BackColor = colorChooser.Color;
                Color bg = me.GetTheme(true);
                Color fg = me.GetTheme(false);
                Color hbg = me.GetTheme(true, true);
                Color hfg = me.GetTheme(false, true);
                if (theme_bg && theme_hl) { hbg = colorChooser.Color; }
                else if (theme_bg && !theme_hl) { bg = colorChooser.Color; }
                else if (!theme_bg && theme_hl) { hfg = colorChooser.Color; }
                else if (!theme_bg && !theme_hl) { fg = colorChooser.Color; }
                me.SetTheme(bg, fg);
                me.SetTheme(hbg, hfg, true);
                MessageView.Clear();
                UpdateMessageView();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (blinkingDash.Text == "_")
            {
                me.SetInt("blink_speed", speedTrackbar.Value);
                blinkywinky.Interval = speedTrackbar.Value;
            } else
            {
                me.SetInt("qr_size", speedTrackbar.Value);
                blinkingDash.Text = me.GetInt("qr_size").ToString();
            }
            MessageView.Clear();
            UpdateMessageView();
        }

        private void blinkywinky_Tick(object sender, EventArgs e)
        {
            blinkingDash.Visible = !blinkingDash.Visible;
        }

        private void blinkProps_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fontChangeButton_Click(object sender, EventArgs e)
        {
            if (fontChooser.ShowDialog() == DialogResult.OK)
            {
                me.SetFont(fontChooser.Font.FontFamily.Name, fontChooser.Font.Size, fontChooser.Font.Style);
                fontPreview.Font = me.GetFont();
                MessageView.Clear();
                UpdateMessageView();
            }
        }

        private void timeoutBox_TextChanged(object sender, EventArgs e)
        {
            if (timeoutProps.Visible)
            {
                try
                {
                    me.SetInt("timer", Convert.ToInt32(timeoutBox.Text));
                    MessageView.Clear();
                    UpdateMessageView();
                }
                catch
                {
                    System.Media.SystemSounds.Asterisk.Play();
                }
            }
        }

        private void customRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            browseButton.Enabled = customRadioBtn.Checked;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (customQRBrowser.ShowDialog() == DialogResult.OK)
            {
                me.SetString("qr_file", customQRBrowser.FileName);
                filenameLabel.Text = "Filename: " + customQRBrowser.FileName;
                MessageView.Clear();
                UpdateMessageView();
            }
        }

        private void transparentRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (qrProps.Visible && transparentRadioBtn.Checked)
            {
                me.SetString("qr_file", "local:1");
                filenameLabel.Text = "";
                MessageView.Clear();
                UpdateMessageView();
            }
        }

        private void defaultRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (qrProps.Visible && defaultRadioBtn.Checked)
            {
                me.SetString("qr_file", "local:0");
                filenameLabel.Text = "";
                MessageView.Clear();
                UpdateMessageView();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("They have been moved to a new location. The new location is Settings > Simulator settings > Save/Load configurations", "About the save and load button", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
