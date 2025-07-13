using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin2Framework;
using MaterialSkin2Framework.Controls;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class StringEdit : MaterialForm
    {
        internal BlueScreen me;
        private string editable = "";
        private string type = "String";
        private bool theme_bg = false;
        private bool theme_hl = false;
        private bool checkDone = true;
        public StringEdit()
        {
            MaterialSkinManager materialSkinManager = Program.F1.materialSkinManager;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
        }

        private void StringEdit_Load(object sender, EventArgs e)
        {
            HideAllProps();
            MessageView.Clear();
            UpdateMessageView();
            whereTheButtonsLink.LinkColor = (Program.gs.NightTheme ? Color.White : Color.Blue);
        }

        private ListViewItem GetColorListViewItem(string title, Color color)
        {
            ListViewItem li = new ListViewItem
            {
                ImageIndex = 6,
                Text = title
            };
            li.SubItems.Add(GenerateColorString(color));
            return li;
        }

        private string GenerateColorString(Color color)
        {
            return "RGB(" + color.R + ", " + color.G + ", " + color.B + ")";
        }

        private void UpdateMessageView()
        {
            if (me == null)
            {
                return;
            }
            if (MessageView.Items.Count == 0)
            {
                MessageView.Columns.Add("Property");
                MessageView.Columns.Add("Value");
                MessageView.Columns[0].Width = 250;
                MessageView.Columns[1].Width = 200;
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
                if (me.GetString("os") == "Windows 1.x/2.x")
                {
                    ListViewItem lsti = new ListViewItem
                    {
                        Text = "Tick rate"
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
            else
            {
                foreach (ListViewItem lvi in MessageView.Items)
                {
                    string key = "";
                    if (lvi.Text.Contains(":"))
                    {
                        key = string.Join(":", lvi.Text.Split(':').Skip(1).ToArray()).Substring(1);
                    }
                    if (lvi.Text.StartsWith("String: "))
                    {
                        lvi.SubItems[1].Text = me.GetString(key.ToLower());
                    }
                    else if (lvi.Text.StartsWith("Text: "))
                    {
                        lvi.SubItems[1].Text = me.GetTexts()[key];
                    }
                    else if (lvi.Text.StartsWith("Title: "))
                    {
                        lvi.SubItems[1].Text = me.GetTitles()[key];
                    } else if (lvi.Text == "Font")
                    {
                        lvi.SubItems[1].Text = me.GetFont().FontFamily.Name + " " + me.GetFont().Size.ToString() + "pt";
                    }
                    switch (lvi.Text)
                    {
                        case "Set restart timer":
                            lvi.SubItems[1].Text = me.GetInt("timer").ToString() + " sec";
                            break;
                        case "Blink speed":
                        case "Tick rate":
                            lvi.SubItems[1].Text = me.GetInt("blink_speed").ToString() + "ms";
                            break;
                        case "QR code image":
                            lvi.SubItems[1].Text = me.GetString("qr_file").Replace("local:0", "Default").Replace("local:1", "Transparent");
                            break;
                        case "QR code size":
                            lvi.SubItems[1].Text = me.GetInt("qr_size").ToString();
                            break;
                        case "Horizontal margin":
                            lvi.SubItems[1].Text = me.GetInt("margin-x").ToString() + "%";
                            break;
                        case "Vertical margin":
                            lvi.SubItems[1].Text = me.GetInt("margin-y").ToString() + "%";
                            break;
                        case "Background color":
                            lvi.SubItems[1].Text = GenerateColorString(me.GetTheme(true));
                            break;
                        case "Foreground color":
                            lvi.SubItems[1].Text = GenerateColorString(me.GetTheme(false));
                            break;
                        case "Highlight background":
                            lvi.SubItems[1].Text = GenerateColorString(me.GetTheme(true, true));
                            break;
                        case "Highlight foreground":
                            lvi.SubItems[1].Text = GenerateColorString(me.GetTheme(false, true));
                            break;
                    }
                }
                MessageView.Refresh();
            }
            if (checkDone && updatePreviewCheck.Checked)
            {
                checkDone = false;
                bugcheckPreview.Image = Properties.Resources.loadpic;
                new Thread(() => {
                    me.ShowSpecial(bugcheckPreview);
                    checkDone = true;
                }).Start();
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
                HideAllProps();
                if (selection == "Horizontal margin")
                {
                    type = "margin-x";
                    secondsLabel.Text = "%";
                    timeoutProps.Visible = true;
                    timeoutBox.Text = me.GetInt("margin-x").ToString();
                    specificProps.Text = "Margin properties";
                }
                else if (selection == "Vertical margin")
                {
                    type = "margin-y";
                    secondsLabel.Text = "%";
                    timeoutProps.Visible = true;
                    timeoutBox.Text = me.GetInt("margin-y").ToString();
                    specificProps.Text = "Margin properties";
                }
                else if (selection.StartsWith("Title: "))
                {
                    type = "title";
                    editable = MessageView.SelectedItems[0].Text.Substring(7);
                    stringEditor.Text = MessageView.SelectedItems[0].SubItems[1].Text;
                    HideAllProps();
                    stringProps.Visible = true;
                    specificProps.Text = "String properties";
                }
                else if (selection.StartsWith("Text: "))
                {
                    type = "text";
                    editable = MessageView.SelectedItems[0].Text.Substring(6);
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
                    } else
                    {
                        stringEditor.Enabled = true;
                        xpMsgChooser.Visible = false;
                    }
                }
                else if (selection.StartsWith("String: "))
                {
                    type = "string";
                    editable = MessageView.SelectedItems[0].Text.Substring(8).ToLower();
                    stringEditor.Text = MessageView.SelectedItems[0].SubItems[1].Text;
                    HideAllProps();
                    stringProps.Visible = true;
                    specificProps.Text = "String properties";
                }
                else if (selection == "Background color")
                {
                    theme_bg = true;
                    theme_hl = false;
                    colorPreview.BackColor = me.GetTheme(true);
                    HideAllProps();
                    colorProps.Visible = true;
                    specificProps.Text = "Color properties";
                }
                else if (selection == "Foreground color")
                {
                    theme_bg = false;
                    theme_hl = false;
                    colorPreview.BackColor = me.GetTheme(false);
                    HideAllProps();
                    colorProps.Visible = true;
                    specificProps.Text = "Color properties";
                }
                else if (selection == "Highlight background")
                {
                    theme_bg = true;
                    theme_hl = true;
                    colorPreview.BackColor = me.GetTheme(true, true);
                    HideAllProps();
                    colorProps.Visible = true;
                    specificProps.Text = "Color properties";
                }
                else if (selection == "Highlight foreground")
                {
                    theme_bg = false;
                    theme_hl = true;
                    colorPreview.BackColor = me.GetTheme(false, true);
                    HideAllProps();
                    colorProps.Visible = true;
                    specificProps.Text = "Color properties";
                }
                else if ((selection == "Blink speed") || (selection == "Tick rate"))
                {
                    speedTrackbar.Value = me.GetInt("blink_speed");
                    HideAllProps();
                    blinkywinky.Interval = me.GetInt("blink_speed");
                    blinkywinky.Enabled = true;
                    blinkProps.Visible = true;
                    specificProps.Text = $"{selection} properties";
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
            } else
            {
                HideAllProps();
            }
            UpdateMessageView();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // remove zero width space to avoid problems...
            stringEditor.Text = stringEditor.Text.Replace("​", "");
            if (stringProps.Visible)
            {
                if (type == "title")
                {
                    me.SetTitle(editable, stringEditor.Text);
                }
                else if (type == "text")
                {
                    me.SetText(editable, stringEditor.Text);
                }
                else if (type == "string")
                {
                    me.SetString(editable, stringEditor.Text);
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
                UpdateMessageView();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
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
                UpdateMessageView();
            }
        }

        private void TransparentRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (qrProps.Visible && transparentRadioBtn.Checked)
            {
                me.SetString("qr_file", "local:1");
                filenameLabel.Text = "";
                UpdateMessageView();
            }
        }

        private void DefaultRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (qrProps.Visible && defaultRadioBtn.Checked)
            {
                me.SetString("qr_file", "local:0");
                filenameLabel.Text = "";
                UpdateMessageView();
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("They have been moved to a new location. The new location is Settings > Simulator settings > Save/Load configurations", "About the save and load button", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AutoRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (autoRadio.Checked)
            {
                me.SetBool("auto", true);
                stringEditor.Enabled = false;
            }
        }

        private void ManualRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (manualRadio.Checked)
            {
                me.SetBool("auto", false);
                stringEditor.Enabled = true;
            }
        }

        private void SpeedTrackbar_onValueChanged(object sender, int newValue)
        {
            if (newValue == 0)
            {
                speedTrackbar.Value = 1;
            }
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
        }

        private void StringEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }

        private void BugcheckPreview_Paint(object sender, PaintEventArgs e)
        {
            BringToFront();
        }

        private void MaterialCheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (updatePreviewCheck.Checked)
            {
                checkDone = false;
                bugcheckPreview.Image = Properties.Resources.loadpic;
                new Thread(() => {
                    if (me == null)
                    {
                        return;
                    }

                    me.ShowSpecial(bugcheckPreview);
                    checkDone = true;
                }).Start();
            }
        }
    }
}
