﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator.Forms.Legacy
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

        private void StringEdit_Load(object sender, EventArgs e)
        {
            HideAllProps();
            MessageView.Clear();
            UpdateMessageView();
            if (Program.f2.nightThemeToolStripMenuItem.Checked)
            {
                this.BackColor = Color.Black;
                this.ForeColor = Color.Gray;
                MessageView.BackColor = Color.Black;
                MessageView.ForeColor = Color.Gray;
                MessageView.GridLines = false;
                MessageView.BorderStyle = BorderStyle.None;
                qrProps.BackColor = Color.Black;
                qrProps.ForeColor = Color.Gray;
                timeoutProps.BackColor = Color.Black;
                timeoutProps.ForeColor = Color.Gray;
                timeoutBox.BackColor = Color.Black;
                timeoutBox.ForeColor = Color.Gray;
                timeoutBox.BorderStyle = BorderStyle.FixedSingle;
                radioFlowLayoutPanel.BackColor = Color.Black;
                radioFlowLayoutPanel.ForeColor = Color.Gray;
                fontProps.BackColor = Color.Black;
                fontProps.ForeColor = Color.Gray;
                blinkProps.BackColor = Color.Black;
                blinkProps.ForeColor = Color.Gray;
                stringEditor.BackColor = Color.Black;
                stringEditor.ForeColor = Color.Gray;
                stringEditor.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private ListViewItem GetColorListViewItem(string title, Color color)
        {
            ListViewItem li = new ListViewItem
            {
                ImageIndex = 6,
                Text = title
            };
            li.SubItems.Add("RGB(" + color.R + ", " + color.G + ", " + color.B + ")");
            return li;
        }

        private void WinVers_SelectedIndexChanged(object sender, EventArgs e)
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
                ListViewItem li = new ListViewItem
                {
                    Text = "String: Emoticon"
                };
                li.SubItems.Add(me.GetString("emoticon"));
                li.ImageIndex = 4;
                MessageView.Items.Add(li);
            }
            foreach (KeyValuePair<string, string> entry in titles)
            {
                ListViewItem li = new ListViewItem
                {
                    Text = "Title: " + entry.Key
                };
                li.SubItems.Add(entry.Value);
                li.ImageIndex = 4;
                MessageView.Items.Add(li);
            }
            foreach (KeyValuePair<string, string> entry in texts)
            {
                ListViewItem li = new ListViewItem
                {
                    Text = "Text: " + entry.Key
                };
                li.SubItems.Add(entry.Value);
                li.ImageIndex = 4;
                MessageView.Items.Add(li);
            }
            if (me.GetBool("font_support"))
            {
                ListViewItem lsti = new ListViewItem
                {
                    Text = "Font"
                };
                lsti.SubItems.Add(me.GetFont().FontFamily.Name + " " + me.GetFont().Size.ToString() + "pt");
                lsti.ImageIndex = 5;
                MessageView.Items.Add(lsti);
            }
            if (me.GetString("os") == "Windows CE")
            {
                ListViewItem lsti = new ListViewItem
                {
                    Text = "Set restart timer"
                };
                lsti.SubItems.Add(me.GetInt("timer").ToString() + " sec");
                lsti.ImageIndex = 5;
                MessageView.Items.Add(lsti);
            }
            if (me.GetBool("blinkblink"))
            {
                ListViewItem lsti = new ListViewItem
                {
                    Text = "Blink speed"
                };
                lsti.SubItems.Add(me.GetInt("blink_speed").ToString() + "ms");
                lsti.ImageIndex = 5;
                MessageView.Items.Add(lsti);
            }
            if (me.GetBool("winxplus"))
            {
                ListViewItem lsti = new ListViewItem
                {
                    Text = "QR code image"
                };
                lsti.SubItems.Add(me.GetString("qr_file").Replace("local:0", "Default").Replace("local:1", "Transparent"));
                lsti.ImageIndex = 5;
                MessageView.Items.Add(lsti);

                lsti = new ListViewItem
                {
                    Text = "QR code size"
                };
                lsti.SubItems.Add(me.GetInt("qr_size").ToString());
                lsti.ImageIndex = 5;
                MessageView.Items.Add(lsti);
            }

            if ((me.GetString("os") == "Windows 8/8.1") || me.GetBool("winxplus"))
            {
                ListViewItem li = new ListViewItem
                {
                    Text = "Horizontal margin"
                };
                li.SubItems.Add(me.GetInt("margin-x").ToString() + "%");
                li.ImageIndex = 5;
                MessageView.Items.Add(li);
                li = new ListViewItem
                {
                    Text = "Vertical margin"
                };
                li.SubItems.Add(me.GetInt("margin-y").ToString() + "%");
                li.ImageIndex = 5;
                MessageView.Items.Add(li);
            }
            MessageView.Items.Add(GetColorListViewItem("Background color", me.GetTheme(true)));
            MessageView.Items.Add(GetColorListViewItem("Foreground color", me.GetTheme(false)));
            if ((me.GetString("os") == "Windows 3.1x") || (me.GetString("os") == "Windows 9x/Me") || (me.GetString("os") == "BOOTMGR"))
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
            xpMsgChooser.Visible = false;
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
                if (selection == "Horizontal margin")
                {
                    this.type = "margin-x";
                    secondsLabel.Text = "%";
                    timeoutProps.Visible = true;
                    timeoutBox.Text = me.GetInt("margin-x").ToString();
                    specificProps.Text = "Margin properties";
                }
                else if (selection == "Vertical margin")
                {
                    this.type = "margin-y";
                    secondsLabel.Text = "%";
                    timeoutProps.Visible = true;
                    timeoutBox.Text = me.GetInt("margin-y").ToString();
                    specificProps.Text = "Margin properties";
                }
                else if (selection.StartsWith("Title: "))
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
                    if ((me.GetString("os") == "Windows XP") && (selection.Contains("Troubleshooting")))
                    {
                        stringEditor.Enabled = !me.GetBool("auto");
                        autoRadio.Checked = me.GetBool("auto");
                        manualRadio.Checked = !me.GetBool("auto");
                        xpMsgChooser.Visible = true;
                    }
                    else
                    {
                        stringEditor.Enabled = true;
                        xpMsgChooser.Visible = false;
                    }
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
                    type = "timer";
                    secondsLabel.Text = "seconds";
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
            }
            else
            {
                HideAllProps();
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
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

        private void ColorButton_Click(object sender, EventArgs e)
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

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            if (blinkingDash.Text == "_")
            {
                me.SetInt("blink_speed", speedTrackbar.Value);
                blinkywinky.Interval = speedTrackbar.Value;
            }
            else
            {
                me.SetInt("qr_size", speedTrackbar.Value);
                blinkingDash.Text = me.GetInt("qr_size").ToString();
            }
            MessageView.Clear();
            UpdateMessageView();
        }

        private void Blinkywinky_Tick(object sender, EventArgs e)
        {
            blinkingDash.Visible = !blinkingDash.Visible;
        }

        private void FontChangeButton_Click(object sender, EventArgs e)
        {
            if (fontChooser.ShowDialog() == DialogResult.OK)
            {
                me.SetFont(fontChooser.Font.FontFamily.Name, fontChooser.Font.Size, fontChooser.Font.Style);
                fontPreview.Font = me.GetFont();
                MessageView.Clear();
                UpdateMessageView();
            }
        }

        private void TimeoutBox_TextChanged(object sender, EventArgs e)
        {
            if (timeoutProps.Visible)
            {
                try
                {
                    me.SetInt(type, Convert.ToInt32(timeoutBox.Text));
                    MessageView.Clear();
                    UpdateMessageView();
                }
                catch
                {
                    System.Media.SystemSounds.Asterisk.Play();
                }
            }
        }

        private void CustomRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            browseButton.Enabled = customRadioBtn.Checked;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (customQRBrowser.ShowDialog() == DialogResult.OK)
            {
                me.SetString("qr_file", customQRBrowser.FileName);
                filenameLabel.Text = "Filename: " + customQRBrowser.FileName;
                MessageView.Clear();
                UpdateMessageView();
            }
        }

        private void TransparentRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (qrProps.Visible && transparentRadioBtn.Checked)
            {
                me.SetString("qr_file", "local:1");
                filenameLabel.Text = "";
                MessageView.Clear();
                UpdateMessageView();
            }
        }

        private void DefaultRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (qrProps.Visible && defaultRadioBtn.Checked)
            {
                me.SetString("qr_file", "local:0");
                filenameLabel.Text = "";
                MessageView.Clear();
                UpdateMessageView();
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("They have been moved to a new location. The new location is Settings > Simulator settings > Save/Load configurations", "About the save and load button", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void autoRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (autoRadio.Checked)
            {
                me.SetBool("auto", true);
                stringEditor.Enabled = false;
            }
        }

        private void manualRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (manualRadio.Checked)
            {
                me.SetBool("auto", false);
                stringEditor.Enabled = true;
            }
        }

        private void StringEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}
