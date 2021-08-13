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
        private BlueScreen me;
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
        }

        private void StringEdit_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                winVers.Clear();
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    ListViewItem li = new ListViewItem();
                    li.ImageIndex = 0;
                    switch (bs.GetString("icon"))
                    {
                        case "2D flag":
                            li.ImageIndex = 0;
                            break;
                        case "3D flag":
                            li.ImageIndex = 1;
                            break;
                        case "2D window":
                            li.ImageIndex = 3;
                            break;
                        case "3D window":
                            li.ImageIndex = 2;
                            break;
                    }
                    li.Text = bs.GetString("os");
                    winVers.Items.Add(li);
                }
            }
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
            if (winVers.SelectedItems.Count < 1)
            {
                MessageView.Clear();
            } else
            {
                MessageView.Clear();
                UpdateMessageView();
            }
        }

        private void UpdateMessageView()
        {
            MessageView.Columns.Add("Property");
            MessageView.Columns.Add("Value");
            MessageView.Columns[0].Width = 120;
            MessageView.Columns[1].Width = 150;
            me = Program.bluescreens[winVers.SelectedIndices[0]];
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

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (loadBsconfig.ShowDialog() == DialogResult.OK)
            {
                string filedata = File.ReadAllText(loadBsconfig.FileName);
                string version = filedata.Split('\n')[0];
                if (version.StartsWith("*** Blue screen simulator plus 1."))
                {
                    MessageBox.Show("This configuration file is not compatible with this development build of blue screen simulator plus 2.0.", "Cannot open configuration file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (version.StartsWith("*** Blue screen simulator plus 2."))
                {
                    string[] primary_section_tokens = filedata.Split('#');
                    Program.bluescreens.Clear();
                    foreach (string section in primary_section_tokens)
                    {
                        string[] subsection_tokens = section.Split('[');
                        if (section.StartsWith("*")) { continue; }
                        string os_name = subsection_tokens[0].Replace("\n", "");
                        if (os_name == "") { continue; }
                        BlueScreen bs = new BlueScreen(os_name);
                        bs.ClearAllTitleTexts();
                        foreach (string subsection in subsection_tokens)
                        {
                            string type = "";
                            if (subsection.StartsWith("string")) { type = "string"; }
                            else if (subsection.StartsWith("boolean")) { type = "boolean"; }
                            else if (subsection.StartsWith("integer")) { type = "integer"; }
                            else if (subsection.StartsWith("theme")) { type = "theme"; }
                            else if (subsection.StartsWith("title")) { type = "title"; }
                            else if (subsection.StartsWith("text")) { type = "text"; }
                            else if (subsection.StartsWith("format")) { type = "format"; }
                            string subsection_withoutheading = subsection.Substring(type.Length + 1);
                            string[] entries = subsection_withoutheading.Split(';');
                            Color theme_bg = Color.Black ;
                            Color theme_fg = Color.White ;
                            Color theme_hbg = Color.White ;
                            Color theme_hfg = Color.Black ;
                            string fontfamily = "";
                            float size = 1.0f;
                            FontStyle style = FontStyle.Regular;
                            foreach (string entry in entries)
                            {
                                if (entry.Replace("\n", "") != "")
                                {
                                    string key = entry.Split('=')[0].Replace("\n", "");
                                    string value = entry.Substring(entry.IndexOf("=") + 1);
                                    switch (type)
                                    {
                                        case "string":
                                            bs.SetString(key, value);
                                            break;
                                        case "integer":
                                            bs.SetInt(key, Convert.ToInt32(value));
                                            break;
                                        case "bool":
                                            bs.SetBool(key, Convert.ToBoolean(value));
                                            break;
                                        case "title":
                                            bs.PushTitle(key, value);
                                            break;
                                        case "text":
                                            bs.PushText(key, value);
                                            break;
                                        case "theme":
                                            switch (key)
                                            {
                                                case "bg":
                                                    theme_bg = StringToRGB(value);
                                                    bs.SetTheme(theme_bg, theme_fg);
                                                    break;
                                                case "fg":
                                                    theme_fg = StringToRGB(value);
                                                    bs.SetTheme(theme_bg, theme_fg);
                                                    break;
                                                case "hbg":
                                                    theme_hbg = StringToRGB(value);
                                                    bs.SetTheme(theme_hbg, theme_hfg, true);
                                                    break;
                                                case "hfg":
                                                    theme_hfg = StringToRGB(value);
                                                    bs.SetTheme(theme_hbg, theme_hfg, true);
                                                    break;
                                            }
                                            break;
                                        case "format":
                                            switch (key)
                                            {
                                                case "fontfamily":
                                                    fontfamily = value;
                                                    break;
                                                case "size":
                                                    size = (float)Convert.ToDouble(value);
                                                    break;
                                                case "style":
                                                    style = (FontStyle)Enum.Parse(typeof(FontStyle), value);
                                                    break;
                                            }
                                            break;
                                    }
                                }
                            }
                            bs.SetFont(fontfamily, size, style);
                        }
                        Program.bluescreens.Add(bs);
                    }
                }
            }
            HideAllProps();
            MessageView.Clear();
            winVers.Clear();
            foreach (BlueScreen bs in Program.bluescreens)
            {
                ListViewItem li = new ListViewItem();
                li.ImageIndex = 0;
                switch (bs.GetString("icon"))
                {
                    case "2D flag":
                        li.ImageIndex = 0;
                        break;
                    case "3D flag":
                        li.ImageIndex = 1;
                        break;
                    case "2D window":
                        li.ImageIndex = 3;
                        break;
                    case "3D window":
                        li.ImageIndex = 2;
                        break;
                }
                li.Text = bs.GetString("os");
                winVers.Items.Add(li);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveBsconfig.ShowDialog() == DialogResult.OK)
            {
                string filedata = "*** Blue screen simulator plus 2.0 ***";
                foreach (BlueScreen bs in Program.bluescreens)
                {
                    filedata += "\n\n\n#" + bs.GetString("os") + "\n\n";
                    filedata += "\n\n[string]";
                    filedata += "\nfriendlyname=" + bs.GetString("friendlyname") + ";";
                    filedata += "\ncode=" + bs.GetString("code") + ";";
                    filedata += "\necode1=" + bs.GetString("ecode1") + ";";
                    filedata += "\necode2=" + bs.GetString("ecode2") + ";";
                    filedata += "\necode3=" + bs.GetString("ecode3") + ";";
                    filedata += "\necode4=" + bs.GetString("ecode4") + ";";
                    filedata += "\nemoticon=" + bs.GetString("emoticon").Replace("#", ":h:") + ";";
                    filedata += "\nscreen_mode=" + bs.GetString("screen_mode") + ";";
                    filedata += "\nqr_file=" + bs.GetString("qr_file").Replace("#", ":h:") + ";";
                    filedata += "\nculprit=" + bs.GetString("culprit").Replace("#", ":h:") + ";";
                    filedata += "\nicon=" + bs.GetString("icon") + ";";

                    filedata += "\n\n[boolean]";
                    filedata += "\n" + "windowed=" + bs.GetBool("windowed").ToString() + ";";
                    filedata += "\n" + "autoclose=" + bs.GetBool("autoclose").ToString() + ";";
                    filedata += "\n" + "show_description=" + bs.GetBool("show_description").ToString() + ";";
                    filedata += "\n" + "show_file=" + bs.GetBool("show_file").ToString() + ";";
                    filedata += "\n" + "watermark=" + bs.GetBool("watermark").ToString() + ";";
                    filedata += "\n" + "server=" + bs.GetBool("server").ToString() + ";";
                    filedata += "\n" + "qr=" + bs.GetBool("qr").ToString() + ";";
                    filedata += "\n" + "insider=" + bs.GetBool("insider").ToString() + ";";
                    filedata += "\n" + "acpi=" + bs.GetBool("acpi").ToString() + ";";
                    filedata += "\n" + "amd=" + bs.GetBool("amd").ToString() + ";";
                    filedata += "\n" + "stack_trace=" + bs.GetBool("stack_trace").ToString() + ";";
                    filedata += "\n" + "blink=" + bs.GetBool("blink").ToString() + ";";
                    filedata += "\n" + "font_support=" + bs.GetBool("font_support").ToString() + ";";
                    filedata += "\n" + "blinkblink=" + bs.GetBool("blinkblink").ToString() + ";";
                    filedata += "\n" + "winxplus=" + bs.GetBool("winxplus").ToString() + ";";

                    filedata += "\n\n[integer]";
                    filedata += "\n" + "windowed=" + bs.GetInt("blink_speed") + ";";
                    filedata += "\n" + "timer=" + bs.GetInt("timer") + ";";
                    filedata += "\n" + "qr_size=" + bs.GetInt("qr_size") + ";";


                    filedata += "\n\n[theme]";
                    filedata += "\nbg=" + RGB_String(bs.GetTheme(true)) + ";";
                    filedata += "\nfg=" + RGB_String(bs.GetTheme(false)) + ";";
                    filedata += "\nhbg=" + RGB_String(bs.GetTheme(true, true)) + ";";
                    filedata += "\nhfg=" + RGB_String(bs.GetTheme(false, true)) + ";";

                    filedata += "\n\n[title]";
                    foreach (KeyValuePair<string, string> entry in bs.GetTitles())
                    {
                        filedata += "\n" + entry.Key + "=" + entry.Value.Replace("#", ":h:") + ";";
                    }

                    filedata += "\n\n[text]";
                    foreach (KeyValuePair<string, string> entry in bs.GetTexts())
                    {
                        filedata += "\n" + entry.Key + "=" + entry.Value.Replace("#", ":h:") + ";";
                    }

                    filedata += "\n\n[format]";
                    filedata += "\nfontfamily=" + bs.GetFont().FontFamily.Name + ";";
                    filedata += "\nsize=" + bs.GetFont().Size.ToString() + ";";
                    filedata += "\nstyle=" + bs.GetFont().Style.ToString() + ";";
                }
                File.WriteAllText(saveBsconfig.FileName, filedata);
                MessageBox.Show("Blue screen configuration saved successfully", "Blue screen simulator 2.x configuration file creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Color StringToRGB(string rgb)
        {
            string[] splitted_rgb = rgb.Split(',');
            return Color.FromArgb(Convert.ToInt32(splitted_rgb[0]), Convert.ToInt32(splitted_rgb[1]), Convert.ToInt32(splitted_rgb[2]));
        }

        private string RGB_String(Color rgb)
        {
            return rgb.R.ToString() + "," + rgb.G.ToString() + "," + rgb.B.ToString();
        }
    }
}
