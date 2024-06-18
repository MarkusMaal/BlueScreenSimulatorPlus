using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UltimateBlueScreenSimulator;
using System.Drawing;
using System.Management;
using System.Threading;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

//
// This namespace contains classes that are shared between forms that specify
// using SimulatorDatabase;
// at the top
//
namespace SimulatorDatabase
{

    public class DrawRoutines
    {
        public void Draw(WindowScreen ws)
        {
            // for upscaling and multidisplay support
            if (ws.primary || Program.multidisplaymode == "mirror")
            {
                var frm = Form.ActiveForm;
                if (frm is null)
                {
                    return;
                }
                using (Bitmap bmp = new Bitmap(frm.Width, frm.Height))
                {
                    frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                    Bitmap newImage = new Bitmap(ws.Width, ws.Height);
                    using (Graphics g = Graphics.FromImage(newImage))
                    {
                        if (Program.f1.GMode == "HighQualityBicubic") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; }
                        if (Program.f1.GMode == "HighQualityBilinear") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear; }
                        if (Program.f1.GMode == "Bilinear") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear; }
                        if (Program.f1.GMode == "Bicubic") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic; }
                        if (Program.f1.GMode == "NearestNeighbour") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor; }
                        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                        g.DrawImage(bmp, new Rectangle(0, 0, ws.Width, ws.Height));
                    }
                    // dispose old images from memory to avoid memory leaks and potentially
                    // actual crashes
                    if (ws.screenDisplay.Image != null)
                    {
                        ws.screenDisplay.Image.Dispose();
                    }
                    ws.screenDisplay.Image = newImage;
                    bmp.Dispose();
                }
            }
        }
    }

    struct USBDeviceInfo
    {
        public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
        {
            this.DeviceID = deviceID;
            this.PnpDeviceID = pnpDeviceID;
            this.Description = description;
        }
        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }

        public static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }

            collection.Dispose();
            return devices;
        }
    }

    //
    // Blue screen template class
    //
    public class BlueScreen
    {
        // constructor
        private Color background;
        private Color foreground;
        private Color highlight_bg;
        private Color highlight_fg;

        private string[] ecodes;

        private string os;

        private Font font;

        // possible values:
        // 2D flag
        // 3D flag
        // 2D window
        // 3D window
        private string icon;

        readonly IDictionary<string, string> titles;
        readonly IDictionary<string, string> texts;
        readonly IDictionary<string, string[]> codefiles;

        readonly IDictionary<string, bool> bools;
        readonly IDictionary<string, int> ints;
        readonly IDictionary<string, string> strings;
        readonly IDictionary<int, int> progression;

        public List<string> log1;

        private readonly Random r;

        public BlueScreen(string base_os, bool autosetup = true)
        {
            this.log1 = new List<string>();
            this.r = new Random();
            this.background = Color.FromArgb(0, 0, 0);
            this.foreground = Color.FromArgb(255, 255, 255);
            this.os = base_os;
            string[] codes_temp = { "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR" };
            this.ecodes = codes_temp;
            this.highlight_bg = Color.FromArgb(255, 255, 255);
            this.highlight_fg = Color.FromArgb(0, 0, 0);
            this.icon = "2D flag";
            this.titles = new Dictionary<string, string>();
            this.texts = new Dictionary<string, string>();
            this.codefiles = new Dictionary<string, string[]>();
            this.bools = new Dictionary<string, bool>();
            this.ints = new Dictionary<string, int>();
            this.strings = new Dictionary<string, string>();
            this.progression = new Dictionary<int, int>();
            this.font = new Font("Lucida Console", 10.4f, FontStyle.Regular);
            if (autosetup) { SetOSSpecificDefaults(); }
        }

        public IDictionary<string, bool> AllBools() { return this.bools; }
        public IDictionary<string, int> AllInts() { return this.ints; }
        public IDictionary<string, string> AllStrings() { return this.strings; }
        public IDictionary<int, int> AllProgress() { return this.progression; }

        // blue screen properties
        public bool GetBool(string name)
        {
            Log("Info", $"Reading bool {name}");
            if (this.bools.ContainsKey(name))
            {
                return this.bools[name];
            }
            else
            {
                Log("Warning", "No data, returning false");
                return false;
            }
        }

        public void Log(string e, string message)
        {
            log1.Add("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " +e + " - "+message);
        }

        public string GetLog(bool reverse = true)
        {
            if (reverse) { log1.Reverse(); }
            string ret = string.Join("\n", log1.ToArray());
            if (reverse) { log1.Reverse(); }
            return ret;
        }

        public void SetBool(string name, bool value)
        {
            Log("Info", $"Setting bool {name} to {value}");
            if (this.bools.ContainsKey(name))
            {
                this.bools[name] = value;
            }
            else
            {
                this.bools.Add(name, value);
            }
        }

        public string GetString(string name)
        {
            Log("Info", $"Getting string {name}");
            switch (name)
            {
                case "os": return this.os;
                case "icon": return this.icon;
                case "ecode1": return this.ecodes[0];
                case "ecode2": return this.ecodes[1];
                case "ecode3": return this.ecodes[2];
                case "ecode4": return this.ecodes[3];
                default:
                    if (this.strings.ContainsKey(name))
                    {
                        return strings[name];
                    }
                    else if (this.titles.ContainsKey(name))
                    {
                        return titles[name];
                    }
                    else if (this.texts.ContainsKey(name))
                    {
                        return texts[name];
                    }
                    else
                    {
                        Log("Warning", "No data, returning empty string");
                        return "";
                    }
            }
        }

        public void ClearAllTitleTexts()
        {
            Log("Info", $"Clearing all titles and texts");
            this.titles.Clear();
            this.texts.Clear();
        }

        public void ClearProgress()
        {
            Log("Info", $"Clearing progress tuning data");
            this.progression.Clear();
        }

        public void SetString(string name, string value)
        {
            Log("Info", $"Setting string {name} to {value}");
            switch (name)
            {
                case "icon": this.icon = value; break;
                case "os": this.os = value; break;
                default:
                    if (this.strings.ContainsKey(name))
                    {
                        this.strings[name] = value;
                    }
                    else
                    {
                        this.strings.Add(name, value);
                    }
                    break;
            }
        }

        public void SetTitle(string name, string value)
        {
            Log("Info", $"Setting title {name} to {value}");
            this.titles[name] = value;
        }

        public void PushTitle(string name, string value)
        {
            Log("Info", $"Pushing title {name} with value {value}");
            this.titles.Add(name, value);
        }

        public void SetText(string name, string value)
        {
            Log("Info", $"Setting text {name} to {value}");
            this.texts[name] = value;
        }

        public void PushText(string name, string value)
        {
            Log("Info", $"Pushing text {name} with value {value}");
            this.texts.Add(name, value);
        }

        // theming
        public Color GetTheme(bool bg, bool highlight = false)
        {
            Log("Info", $"Getting " + (highlight ? "highlight " : "") + (bg ? "background" : "foreground") + " color" );
            if (highlight)
            {
                if (bg) { return this.highlight_bg; } else { return this.highlight_fg; }
            }
            if (bg) { return this.background; } else { return this.foreground; }
        }

        public void SetTheme(Color bg, Color fg, bool highlight = false)
        {
            Log("Info", $"Setting " + (highlight ? "highlight" : "base")  + $" colors to ({bg.R}, {bg.G}, {bg.B}), ({fg.R}, {fg.G}, {fg.B})");
            if (highlight)
            {
                this.highlight_bg = bg;
                this.highlight_fg = fg;
                return;
            }
            this.background = bg;
            this.foreground = fg;
        }

        // error codes
        public string[] GetCodes()
        {
            Log("Info", $"Getting error codes");
            return this.ecodes;
        }
        public void SetCodes(string code1, string code2, string code3, string code4)
        {
            Log("Info", $"Setting error codes to {code1}, {code2}, {code3}, {code4}");
            string[] code_temp = { code1, code2, code3, code4 };
            this.ecodes = code_temp;
        }

        private Color RGB(int r, int g, int b)
        {
            Log("Info", $"Getting color from values {r}, {g}, {b}");
            return Color.FromArgb(r, g, b);
        }

        // integers
        public int GetInt(string name)
        {
            Log("Info", $"Getting integer value of {name}");
            if (this.ints.ContainsKey(name))
            {
                return this.ints[name];
            }
            else
            {
                Log("Warning", "No data, returning 1");
                return 1;
            }
        }
        public void SetInt(string name, int value)
        {
            Log("Info", $"Getting integer value of {name} to {value}");
            if (this.ints.ContainsKey(name))
            {
                this.ints[name] = value;
            }
            else
            {
                this.ints.Add(name, value);
            }
        }

        public void SetFont(string font_family, float emsize, FontStyle style)
        {
            Log("Info", $"Setting font as {font_family}, {emsize}pt");
            this.font = new Font(font_family, emsize, style);
        }

        public Font GetFont()
        {
            Log("Info", $"Getting current font");
            return this.font;
        }

        public Icon GetIcon()
        {
            Log("Info", $"Getting icon");
            ImageList windowsIcons = new StringEdit().AllIcons;
            switch (GetString("icon"))
            {
                case "2D flag":
                    return Icon.FromHandle(((Bitmap)windowsIcons.Images[0]).GetHicon());
                case "3D flag":
                    return Icon.FromHandle(((Bitmap)windowsIcons.Images[1]).GetHicon());
                case "3D window":
                    return Icon.FromHandle(((Bitmap)windowsIcons.Images[2]).GetHicon());
                case "2D window":
                    return Icon.FromHandle(((Bitmap)windowsIcons.Images[3]).GetHicon());
                default:
                    return Icon.FromHandle(((Bitmap)windowsIcons.Images[0]).GetHicon());
            }
        }

        public IDictionary<string, string> GetTitles()
        {
            Log("Info", $"Getting all titles");
            return this.titles;
        }

        public IDictionary<string, string> GetTexts()
        {
            Log("Info", $"Getting all texts");
            return this.texts;
        }



        // progress keyframes
        public int GetProgression(int name)
        {
            Log("Info", $"Getting progress tuner data at {name}");
            if (this.progression.ContainsKey(name))
            {
                return this.progression[name];
            }
            else
            {
                Log("Warning", "No data, returning 0");
                return 0;
            }
        }
        public void SetProgression(int name, int value)
        {
            Log("Info", $"Setting progress tuner data at {name} to {value}");
            if (this.progression.ContainsKey(name))
            {
                this.progression[name] = value;
            }
            else
            {
                this.progression.Add(name, value);
            }
        }

        public void SetAllProgression(int[] keys, int[] values)
        {
            Log("Info", $"Setting progress tuner data to predefined array");
            this.progression.Clear();
            for (int i = 0; i < keys.Length; i++)
            {
                this.progression[keys[i]] = values[i];
            }
        }

        //GenAddress uses the last function to generate multiple error address codes
        public string GenAddress(int count, int places, bool lower)
        {
            Log("Info", $"Generating error {count} address code(s) with {places} place(s)" + (lower ? " in lowercase" : ""));
            string ot = "";
            string inspir = GetString("ecode1");
            for (int i = 0; i < count; i++)
            {
                if (i == 1) { inspir = GetString("ecode2"); }
                if (i == 2) { inspir = GetString("ecode3"); }
                if (i == 3) { inspir = GetString("ecode4"); }
                if (ot != "") { ot += ", "; }
                ot += "0x" + GenHex(places, inspir);
            }
            if (lower) { return ot.ToLower(); }
            return ot;
        }
        //generates hexadecimal codes
        //lettercount sets the length of the actual hex code
        //inspir is a string where each character represents if the value is fixed or random
        public string GenHex(int lettercount, string inspir)
        {
            //sleep command is used to make sure that randomization works properly
            //System.Threading.Thread.Sleep(20);
            Log("Info", $"Generating {lettercount} character hex code with template {inspir}");
            string output = "";
            for (int i = 0; i < lettercount; i++)
            {
                int temp = r.Next(15);
                char lette = ' ';
                if ((inspir + inspir).Substring(i, 1) == "R")
                {
                    if (temp < 10) { lette = Convert.ToChar(temp.ToString()); }
                    if (temp == 10) { lette = 'A'; }
                    if (temp == 11) { lette = 'B'; }
                    if (temp == 12) { lette = 'C'; }
                    if (temp == 13) { lette = 'D'; }
                    if (temp == 14) { lette = 'E'; }
                    if (temp == 15) { lette = 'F'; }
                }
                else
                {
                    lette = Convert.ToChar((inspir + inspir).Substring(i, 1));
                }
                output += lette.ToString();
            }
            return output;
        }

        public void PushFile(string name, string[] codes)
        {
            Log("Info", $"Pushing culprit file {name} with error templates [{string.Join(", ", codes)}]");
            if (!codefiles.ContainsKey(name))
            {
                codefiles.Add(name, codes);
            }
        }

        public IDictionary<string, string[]> GetFiles()
        {
            Log("Info", $"Getting culprit files");
            return codefiles;
        }

        public void ClearFiles()
        {
            Log("Info", $"Clearing culprit files");
            codefiles.Clear();
        }

        public void RenameFile(string key, string renamed)
        {
            Log("Info", $"Attempting to rename file {key} to {renamed}");
            bool isRenamed = false;
            string[] codes;
            foreach (KeyValuePair<string, string[]> kvp in this.GetFiles())
            {
                if (key == kvp.Key)
                {
                    codes = kvp.Value;
                    this.codefiles.Remove(key);
                    this.PushFile(renamed, codes);
                    isRenamed = true;
                    break;
                }
            }
            if (!isRenamed)
            {
                Log("Error", $"Couldn't rename {key}!!! Reason: File does not exist in dictionary!");
            }
        }

        public void SetFile(string key, int subcode, string code)
        {
            Log("Info", $"Modifying file {key}");
            bool isModified = false;
            foreach (KeyValuePair<string, string[]> kvp in this.GetFiles())
            {
                if (key == kvp.Key)
                {
                    string[] codearray = kvp.Value;
                    codearray[subcode] = code;
                    this.codefiles[key] = codearray;
                    isModified = true;
                    break;
                }
            }
            if (!isModified)
            {
                Log("Error", $"Couldn't modify {key}!!! Reason: File does not exist in dictionary!");
            }
        }


        //GenFile generates a new file for use in Windows NT blue screen
        public string GenFile(bool lower = true)
        {
            Log("Info", "Generating a random file for NT blue screen" + (lower ? " in lowercase" : ""));
            string[] files = UltimateBlueScreenSimulator.Properties.Resources.CULPRIT_FILES.Split('\n');
            List<string> filenames = new List<string>();
            foreach (string line in files)
            {
                filenames.Add(line.Split(':')[0]);
            }
            int temp = this.r.Next(filenames.Count - 1);
            while (this.GetFiles().ContainsKey(filenames[temp]))
            {
                temp = this.r.Next(filenames.Count - 1);
            }
            if (!lower)
            {
                return filenames[temp];
            }
            else
            {
                return filenames[temp].ToLower();
            }
        }

        public void Show()
        {
            Log("Info", "Simulation requested!");
            switch (this.os)
            {
                case "BOOTMGR":
                    BootMgr bm = new BootMgr
                    {
                        me = this
                    };
                    bm.ShowDialog();
                    Thread.CurrentThread.Abort();
                    break;
                case "Windows 11":
                    SetupWinXabove(new WXBS(), true);
                    break;
                case "Windows 10":
                    SetupWinXabove(new WXBS());
                    break;
                case "Windows 8/8.1":
                    SetupWin8(new WXBS());
                    break;
                case "Windows 8 Beta":
                    SetupWin8Beta(new JupiterBSOD());
                    break;
                case "Windows 7":
                    SetupVista(new Vistabs());
                    break;
                case "Windows Vista":
                    SetupVista(new Vistabs());
                    break;
                case "Windows XP":
                    SetupExperience(new Xvsbs());
                    break;
                case "Windows 2000":
                    Setup2k(new W2kbs());
                    break;
                case "Windows CE":
                    SetupCE(new Cebsod());
                    break;
                case "Windows NT 3.x/4.0":
                    SetupNT(new NTBSOD());
                    break;
                case "Windows 9x/Me":
                    Setup9x(new Old_bluescreen());
                    break;
                case "Windows 3.1x":
                    Setup9x(new Old_bluescreen());
                    break;
                case "Windows 1.x/2.x":
                    SetupWin(new Win());
                    break;
            }
        }

        private void SetupWin8Beta(JupiterBSOD bs)
        {
            try
            {
                Log("Info", "Setting up Windows 8 Beta simulator");
                bs.BackColor = this.GetTheme(true);
                bs.ForeColor = this.GetTheme(false);
                bs.Font = this.GetFont();
            }
            catch (Exception ex)
            {
                Log("Error", $"Error setting up Windows 8 Beta simulator. Reason: {ex.Message}");
                MessageBox.Show(ex.Message, "A non-critical error has occoured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bs.me = this;
            bs.ShowDialog();
            CheckMessageJustInCase();
            Thread.CurrentThread.Abort();
        }

        private void SetupCE(Cebsod bs)
        {
            try
            {
                Log("Info", "Setting up Windows CE simulator");
                bs.BackColor = this.GetTheme(true);
                bs.ForeColor = this.GetTheme(false);
                bs.Font = this.GetFont();
                bs.fullscreen = !GetBool("windowed");
                bs.waterMarkText.Visible = GetBool("watermark");
                bs.technicalCode.Text = "*** STOP: 0x" + GetString("code").Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString().Substring(4, 6) + " (" + GetString("code").Split(' ')[0].ToString().Replace("_", " ").ToLower() + ")";
            }
            catch (Exception ex)
            {
                Log("Error", $"Error setting up Windows CE simulator. Reason: {ex.Message}");
                MessageBox.Show(ex.Message, "A non-critical error has occoured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bs.me = this;
            bs.ShowDialog();
            CheckMessageJustInCase();
            Thread.CurrentThread.Abort();
        }

        private void CheckMessageJustInCase()
        {
            Log("Info", "Called CheckMessageJustInCase method");
            if (!Program.f1.showcursor)
            {
                Cursor.Show();
            }
            if (Program.f1.showmsg)
            {
                MessageBox.Show(Program.f1.MsgBoxMessage,
                                Program.f1.MsgBoxTitle,
                                Program.f1.MsgBoxType,
                                Program.f1.MsgBoxIcon);
                Program.f1.showmsg = false;
            }
        }

        private void SetupNT(NTBSOD bs)
        {
            try
            {
                Log("Info", "Setting up Windows NT simulator");
                bs.BackColor = this.GetTheme(true);
                bs.ForeColor = this.GetTheme(false);
                if (GetBool("show_file")) { bs.whatfail = GetString("culprit"); }
                bs.error = GetString("code").Substring(0, GetString("code").ToString().Length - 1);
                bs.fullscreen = !GetBool("windowed");
                if (GetBool("amd")) { bs.processortype = "AuthenticAMD"; }
                bs.stacktrace = GetBool("stack_trace");
                bs.blink = GetBool("blink");
                bs.waterMarkText.Visible = GetBool("watermark");
            }
            catch (Exception ex)
            {
                Log("Error", $"Error setting up Windows NT simulator. Reason: {ex.Message}");
                MessageBox.Show(ex.Message, "A non-critical error has occoured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bs.me = this;
            bs.ShowDialog();
            Thread.CurrentThread.Abort();
        }

        private void Setup9x(Old_bluescreen bs)
        {
            try
            {
                Log("Info", "Setting up Windows 3.1x/9x/Me simulator");
                bs.BackColor = this.GetTheme(true);
                bs.ForeColor = this.GetTheme(false);
                bs.window = this.GetBool("windowed");
                bs.screenmode = this.GetString("screen_mode");
                bs.errorCode = GenHex(2, GetString("ecode1")) + " : " + GenHex(4, GetString("ecode2")) + " : " + GenHex(6, GetString("ecode3"));
                bs.waterMarkText.Visible = this.GetBool("watermark");
            }
            catch (Exception ex)
            {
                Log("Error", $"Error setting up Windows 3.1x/9x/Me simulator. Reason: {ex.Message}");
                MessageBox.Show(ex.Message, "A non-critical error has occoured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bs.me = this;
            bs.ShowDialog();
            Thread.CurrentThread.Abort();
        }
        private void SetupWin(Win bs)
        {
            try
            {
                Log("Info", "Setting up Windows 1.x/2.x simulator");
                bs.BackColor = this.GetTheme(true);
                bs.ForeColor = this.GetTheme(false);
                bs.window = this.GetBool("windowed");
            }
            catch (Exception ex)
            {
                Log("Error", $"Error setting up Windows 1.x/2.x simulator. Reason: {ex.Message}");
                MessageBox.Show(ex.Message, "A non-critical error has occoured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bs.me = this;
            bs.ShowDialog();
            Thread.CurrentThread.Abort();
        }

        private void Setup2k(W2kbs bs)
        {
            try
            {
                Log("Info", "Setting up Windows 2000 simulator");
                bs.BackColor = this.GetTheme(true);
                bs.ForeColor = this.GetTheme(false);
                bs.fullscreen = !this.GetBool("windowed");
                bs.waterMarkText.Visible = this.GetBool("watermark");
                if (this.GetBool("show_file")) { bs.whatfail = this.GetString("culprit"); }
                bs.errorCode = string.Format(this.GetTexts()["Error code formatting"].Replace("{1}", "0x{1},0x{2},0x{3},0x{4}"), this.GetString("code").Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString(), GenHex(8, this.GetString("ecode1")), GenHex(8, this.GetString("ecode2")), GenHex(8, this.GetString("ecode3")), GenHex(8, this.GetString("ecode4")));
                bs.errorCode = bs.errorCode + "\n" + this.GetString("code").Split(' ')[0].ToString();
            }
            catch (Exception ex)
            {
                Log("Error", $"Error setting up Windows 2000 simulator. Reason: {ex.Message}");
                MessageBox.Show(ex.Message, "A non-critical error has occoured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bs.me = this;
            bs.ShowDialog();
            Thread.CurrentThread.Abort();
        }

        private void SetupExperience(Xvsbs bs)
        {
            try
            {
                Log("Info", "Setting up Windows XP simulator");
                bs.BackColor = this.GetTheme(true);
                bs.ForeColor = this.GetTheme(false);
                bs.fullscreen = !this.GetBool("windowed");
                bs.errorCode.Visible = this.GetBool("show_details");
                bs.waterMarkText.Visible = this.GetBool("watermark");
                if (this.GetBool("show_file")) { bs.whatfail = this.GetString("culprit"); }
                bs.errorCode.Text = this.GetString("code").Split(' ')[0].ToString();
                bs.technicalCode.Text = "*** STOP: " + this.GetString("code").Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString() + " (" + GenAddress(4, 8, false) + ")";
                bs.supportInfo.Text = this.GetTexts()["Technical support"] + "\n\n\nTechnical information:";
            }
            catch (Exception ex)
            {
                Log("Error", $"Error setting up Windows XP simulator. Reason: {ex.Message}");
                MessageBox.Show(ex.Message, "A non-critical error has occoured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bs.me = this;
            bs.ShowDialog();
            Thread.CurrentThread.Abort();
        }

        private void SetupVista(Vistabs bs)
        {
            try
            {
                Log("Info", "Setting up Windows Vista simulator");
                bs.BackColor = this.GetTheme(true);
                bs.ForeColor = this.GetTheme(false);
                bs.fullscreen = !this.GetBool("windowed");
                bs.errorCode.Visible = this.GetBool("show_details");
                bs.waterMarkText.Visible = this.GetBool("watermark");
                if (this.GetBool("show_file")) { bs.whatfail = this.GetString("culprit"); }
                if (this.GetBool("acpi"))
                {
                    //bs.errorCode.Visible = false;
                    bs.dumpText.Visible = false;
                }
                bs.errorCode.Text = this.GetString("code").Split(' ')[0].ToString();
                bs.technicalCode.Text = "*** STOP: " + this.GetString("code").Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString() + " (" + GenAddress(4, 16, false) + ")";
                bs.supportInfo.Text = this.GetTexts()["Technical support"] + "\n\n\nTechnical information:";
            }
            catch (Exception ex)
            {
                Log("Error", $"Error setting up Windows Vista simulator. Reason: {ex.Message}");
                MessageBox.Show(ex.Message, "A non-critical error has occoured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bs.me = this;
            bs.ShowDialog();
            Thread.CurrentThread.Abort();
        }

        private void SetupWinXabove(WXBS bs, bool w11 = false)
        {
            Log("Info", "Setting up Windows 8.x/10/11 simulator in SetupWinXabove method");
            bs.emoticonLabel.Text = this.GetString("emoticon");
            bs.BackColor = this.GetTheme(true);
            bs.ForeColor = this.GetTheme(false);
            bs.qr = GetBool("qr");
            bs.close = GetBool("autoclose");
            bs.green = GetBool("insider");
            bs.server = GetBool("server");
            bs.maxprogressmillis = GetInt("progressmillis");
            bs.w11 = w11;
            bs.memCodes.Text = "0x" + GenHex(16, GetString("ecode1")) + "\r\n0x" +
                                GenHex(16, GetString("ecode2")) + "\r\n0x" +
                                GenHex(16, GetString("ecode3")) + "\r\n0x" +
                                GenHex(16, GetString("ecode4"));
            bs.waterMarkText.Visible = GetBool("watermark");
            if (GetBool("show_file")) { bs.whatfail = GetString("culprit"); }
            if (GetBool("windowed")) { bs.WindowState = FormWindowState.Normal; bs.FormBorderStyle = FormBorderStyle.Sizable; }
            try
            {
                if (GetBool("show_description"))
                {
                    bs.code = GetString("code").Split(' ')[0].ToString();
                }
                else
                {
                    bs.code = GetString("code").Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString();
                }
            }
            catch (Exception ex)
            {
                Log("Error", $"Error setting up Windows 8.x/10/11 simulator in SetupWinXabove method. Reason: {ex.Message}");
                MessageBox.Show(ex.Message, "A non-critical error has occoured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bs.me = this;
            bs.ShowDialog();
            Thread.CurrentThread.Abort();
        }

        private void SetupWin8(WXBS bs)
        {
            Log("Info", "Setting up Windows 8.x/10/11 simulator in SetupWin8 method");
            bs.emoticonLabel.Text = this.GetString("emoticon");
            bs.BackColor = this.GetTheme(true);
            bs.ForeColor = this.GetTheme(false);
            bs.maxprogressmillis = GetInt("progressmillis");
            bs.qr = false;
            bs.w8 = true;
            bs.close = GetBool("autoclose");
            bs.green = false;
            bs.server = false;
            bs.memCodes.Text = "0x" + GenHex(16, GetString("ecode1")) + "\r\n0x" +
                                GenHex(16, GetString("ecode2")) + "\r\n0x" +
                                GenHex(16, GetString("ecode3")) + "\r\n0x" +
                                GenHex(16, GetString("ecode4"));
            bs.waterMarkText.Visible = GetBool("watermark");
            if (GetBool("show_file")) { bs.whatfail = GetString("culprit"); }
            if (GetBool("windowed")) { bs.WindowState = FormWindowState.Normal; bs.FormBorderStyle = FormBorderStyle.Sizable; }
            try
            {
                if (GetBool("show_description"))
                {
                    bs.code = GetString("code").Split(' ')[0].ToString();
                }
                else
                {
                    bs.code = GetString("code").Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString();
                }
            }
            catch (Exception ex)
            {
                Log("Error", $"Error setting up Windows 8.x/10/11 simulator in SetupWin8 method. Reason: {ex.Message}");
                MessageBox.Show(ex.Message, "A non-critical error has occoured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bs.me = this;
            bs.ShowDialog();
            Thread.CurrentThread.Abort();
        }

        public void Crash(string message, string stacktrace, string type)
        {
            Log("Warning", $"Triggered metacrash with the following info: message={message}, stacktrace={stacktrace}, type={type}");
            Metaerror me = new Metaerror
            {
                stack_trace = stacktrace,
                message = message,
                type = type
            };
            switch (me.ShowDialog())
            {
                case DialogResult.Ignore:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Abort:
                    Thread.CurrentThread.Abort();
                    break;
            }
        }

        // default hacks for specific OS
        public void SetOSSpecificDefaults()
        {
            Log("Info", $"Setting default settings with {this.os} template");
            SetBool("watermark", true);
            switch (this.os)
            {
                case "BOOTMGR":
                    SetTheme(RGB(0, 0, 0), RGB(192, 192, 192));
                    SetTheme(RGB(0, 0, 0), RGB(255, 255, 255), true);
                    SetFont("Consolas", 16.0f, FontStyle.Regular);
                    PushTitle("Main", "Windows Boot Manager");
                    PushText("Troubleshooting introduction", "Windows failed to start. A recent hardware or software change might be the\r\ncause.To fix the problem:");
                    PushText("Troubleshooting", "1. Insert your Windows installation disc and restart your computer.\r\n2. Choose your language settings, and then click \"Next.\"\r\n3. Click \"Repair your computer.\"");
                    PushText("Troubleshooting without disc", "If you do not have this disc, contact your system administrator or computer\r\nmanufacturer for assistance.");
                    PushText("Error description", "The boot selection failed because a required device is\r\ninaccessible.");
                    PushText("Info", "Info:");
                    PushText("Status", "Status:");
                    PushText("Continue", "ENTER=Continue");
                    PushText("Exit", "ESC=Exit");
                    SetString("code", "0x0000000e");
                    break;
                case "Windows 1.x/2.x":
                    SetTheme(RGB(0, 0, 170), RGB(255, 255, 255));
                    SetTheme(RGB(170, 170, 170), RGB(0, 0, 170), true);
                    SetInt("blink_speed", 100);
                    SetString("friendlyname", "Windows 1.x/2.x (Text mode, Standard)");
                    SetBool("playsound", true);
                    SetString("qr_file", "local:1");
                    SetBool("font_support", false);
                    SetBool("blinkblink", false);
                    SetString("qr_file", "local:1");
                    break;
                case "Windows 3.1x":
                    SetTheme(RGB(0, 0, 170), RGB(255, 255, 255));
                    SetTheme(RGB(170, 170, 170), RGB(0, 0, 170), true);
                    SetInt("blink_speed", 100);
                    PushTitle("Main", "Windows");
                    PushText("No unresponsive programs", "Altough you can use CTRL+ALT+DEL to quit an application that has\r\nstopped responding to the system, there is no application in this\r\nstate.\r\nTo quit an application, use the application's quit or exit command,\r\nor choose the Close command from the Control menu.\r\n* Press any key to return to Windows\r\n* Press CTRL + ALT + DEL again to restart your computer.You will\r\nlose any unsaved information in all applications.");
                    PushText("Prompt", "Press any key to continue");
                    SetString("friendlyname", "Windows 3.1 (Text mode, Standard)");
                    SetBool("font_support", false);
                    SetBool("blinkblink", true);
                    SetString("screen_mode", "No unresponsive programs");
                    break;
                case "Windows 9x/Me":
                    SetTheme(RGB(0, 0, 170), RGB(255, 255, 255));
                    SetTheme(RGB(170, 170, 170), RGB(0, 0, 170), true);
                    SetInt("blink_speed", 100);
                    SetCodes("0RRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR");
                    PushTitle("Main", "Windows");
                    PushTitle("System is busy", "System is busy. ");
                    PushTitle("Warning", "WARNING!");
                    PushText("System error", "An error has occurred. To continue:\r\n\r\nPress Enter to return to Windows, or\r\n\r\nPress CTRL + ALT + DEL to restart your computer. If you do this,\r\nyou will lose any unsaved information in all open applications.\r\n\r\nError: {0}");
                    PushText("Application error", "A fatal exception {2} has occurred at {0}:{1}. The current\r\napplication will be terminated.\r\n\r\n* Press any key to terminate current application\r\n* Press CTRL + ALT + DEL again to restart your computer. You will\r\n  lose any unsaved information in all applications.");
                    PushText("Driver error", "A fatal exception {2} has occurred at {0}:{1} in VXD VMM(01) +\r\n{2}. The current application will be terminated.\r\n\r\n* Press any key to terminate current application\r\n* Press CTRL + ALT + DEL again to restart your computer. You will\r\n  lose any unsaved information in all applications.");
                    PushText("System is busy", "The system is busy waiting for the Close Program dialog box to be\r\ndisplayed. You can wait and see if it appears, or you can restart\r\nyour computer.\r\n\r\n* Press any key to return to Windows and wait.\r\n* Press CTRL + ALT + DEL again to restart your computer. You will\r\n  lose any unsaved information in programs that are running.");
                    PushText("System is unresponsive", "The system is either busy or has become unstable. You can wait and\r\nsee if it becomes available again, or you can restart your computer.\r\n\r\n* Press any key to return to Windows and wait.\r\n* Press CTRL + ALT + DEL again to restart your computer. You will\r\n  lose any unsaved information in programs that are running.");
                    PushText("Prompt", "Press any key to continue");
                    SetString("friendlyname", "Windows 9x/Millennium Edition (Text mode, Standard)");
                    SetBool("font_support", false);
                    SetBool("blinkblink", true);
                    SetString("screen_mode", "System error");
                    break;
                case "Windows CE":
                    this.icon = "3D flag";
                    SetTheme(RGB(0, 0, 128), RGB(255, 255, 255));
                    PushText("A problem has occurred...", "A problem has occurred and Windows CE has been shut down to prevent damage to your\r\ncomputer.");
                    PushText("CTRL+ALT+DEL message", "If you will try to restart your computer, press Ctrl+Alt+Delete.");
                    PushText("Technical information", "Technical information:");
                    PushText("Technical information formatting", "*** STOP: {0} ({1})");
                    PushText("Restart message", "The computer will restart automatically\r\nafter {0} seconds.");
                    SetInt("timer", 30);
                    SetFont("Lucida Console", 10.4f, FontStyle.Regular);
                    SetString("friendlyname", "Windows CE 5.0 and later (750x400, Standard)");

                    SetString("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
                    break;
                case "Windows NT 3.x/4.0":
                    this.icon = "2D flag";
                    SetTheme(RGB(0, 0, 160), RGB(170, 170, 170));
                    PushText("Error code formatting", "*** STOP: {0} ({1})");
                    PushText("CPUID formatting", "CPUID: {0} 6.3.3 irql:lf SYSVER 0xf0000565");
                    PushText("Stack trace heading", "Dll Base DateStmp - Name");
                    PushText("Stack trace table formatting", "{0} {1} - {2}");
                    PushText("Memory address dump heading", "Address  dword dump   Build [1381]                            - Name");

                    PushText("Memory address dump table", "{0} {1} {2} {3} {4} {5}           - {6}");
                    PushText("Troubleshooting text", "Restart and set the recovery options in the system control panel\r\nor the /CRASHDEBUG system start option.");
                    SetInt("blink_speed", 100);
                    SetString("friendlyname", "Windows NT 4.0/3.x (Text mode, Standard)");
                    for (int n = 0; n < 40; n++)
                    {
                        string[] inspirn = { "RRRRRRRR", "RRRRRRRR" };
                        PushFile(GenFile(true), inspirn);
                    }
                    for (int n = 0; n < 4; n++)
                    {
                        string[] inspirn = { "RRRRRRRR", "RRRRRRRR", "RRRRRRRR", "RRRRRRRR", "RRRRRRRR", "RRRRRRRR" };
                        PushFile(GenFile(true), inspirn);
                    }
                    SetBool("font_support", false);
                    SetBool("blinkblink", true);

                    SetString("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
                    SetBool("stack_trace", true);
                    break;
                case "Windows 2000":
                    PushText("Error code formatting", "*** STOP: {0} ({1})");
                    PushText("Troubleshooting introduction", "If this is the first time you've seen this Stop error screen,\r\nrestart your computer. If this screen appears again, follow\r\nthese steps: ");
                    PushText("Troubleshooting text", "Check for viruses on your computer. Remove any newly installed\r\nhard drives or hard drive controllers. Check your hard drive\r\nto make sure it is properly configured and terminated.\r\nRun CHKDSK /F to check for hard drive corruption, and then\r\nrestart your computer.");
                    PushText("Additional troubleshooting information", "Refer to your Getting Started manual for more information on\r\ntroubleshooting Stop errors.");
                    PushText("File information", "*** Address {0} base at {1}, DateStamp {2} - {3}");
                    SetFont("Lucida Console", 8.0f, FontStyle.Bold);
                    SetString("friendlyname", "Windows 2000 Professional/Server Family (640x480, Standard)");
                    SetTheme(RGB(0, 0, 128), RGB(255, 255, 255));
                    string[] inspirw2k = { "RRRRRRRR", "RRRRRRRR", "RRRRRRRR" };
                    SetString("culprit", GenFile(true));
                    PushFile(GetString("culprit"), inspirw2k);
                    SetString("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
                    SetBool("show_description", true);
                    SetBool("font_support", false);
                    break;
                case "Windows XP":
                    this.icon = "3D flag";
                    PushText("A problem has been detected...", "A problem has been detected and Windows has been shut down to prevent damage\r\nto your computer.");
                    PushText("Troubleshooting introduction", "If this is the first time you've seen this Stop error screen,\r\nrestart your computer. If this screen appears again, follow\r\nthese steps:");
                    PushText("Troubleshooting", "Check to make sure any new hardware or software is properly installed.\r\nIf this is a new installation, ask your hardware or software manufacturer\r\nfor any Windows updates you might need.\r\n\r\nIf problems continue, disable or remove any newly installed hardware\r\nor software. Disable BIOS memory options such as caching or shadowing.\r\nIf you need to use Safe mode to remove or disable components, restart\r\nyour computer, press F8 to select Advanced Startup Options, and then\r\nselect Safe Mode.");
                    PushText("Technical information", "Technical information:");
                    PushText("Technical information formatting", "*** STOP: {0} ({1})");
                    PushText("Culprit file", "The problem seems to be caused by the following file: ");
                    PushText("Physical memory dump", "Beginning dump of physical memory\r\nPhysical memory dump complete.");
                    PushText("Technical support", "Contact your system administrator or technical support group for further\r\nassistance.");
                    SetBool("auto", true);
                    SetFont("Lucida Console", 9.7f, FontStyle.Regular);
                    SetString("friendlyname", "Windows XP (640x480, Standard)");
                    string[] inspirb = { "RRRRRRRR", "RRRRRRRR", "RRRRRRRR" };
                    SetString("culprit", GenFile(true));
                    PushFile(GetString("culprit"), inspirb);
                    SetTheme(RGB(0, 0, 128), RGB(255, 255, 255));

                    SetBool("autoclose", true);
                    SetString("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
                    SetBool("show_description", true);
                    SetBool("font_support", true);
                    break;
                case "Windows Vista":
                    this.icon = "3D flag";
                    PushText("A problem has been detected...", "A problem has been detected and Windows has been shut down to prevent damage\r\nto your computer.");
                    PushText("Troubleshooting introduction", "If this is the first time you've seen this Stop error screen,\r\nrestart your computer. If this screen appears again, follow\r\nthese steps:");
                    PushText("Troubleshooting", "Check to make sure any new hardware or software is properly installed.\r\nIf this is a new installation, ask your hardware or software manufacturer\r\nfor any Windows updates you might need.\r\n\r\nIf problems continue, disable or remove any newly installed hardware\r\nor software. Disable BIOS memory options such as caching or shadowing.\r\nIf you need to use Safe mode to remove or disable components, restart\r\nyour computer, press F8 to select Advanced Startup Options, and then\r\nselect Safe Mode.");
                    PushText("Technical information", "Technical information:");
                    PushText("Technical information formatting", "*** STOP: {0} ({1})");
                    PushText("Collecting data for crash dump", "Collecting data for crash dump ...");
                    PushText("Initializing crash dump", "Initializing disk for crash dump ...");
                    PushText("Begin dump", "Beginning dump of physical memory.");
                    PushText("End dump", "Physical memory dump complete.");
                    PushText("Physical memory dump", "Dumping physical memory to disk:{0}");
                    PushText("Culprit file", "The problem seems to be caused by the following file: ");
                    PushText("Culprit file memory address", "***  {0} - Address {1} base at {2}, DateStamp {3}");
                    PushText("Technical support", "Contact your system admin or technical support group for further assistance.");
                    SetFont("Lucida Console", 9.4f, FontStyle.Regular);
                    SetString("friendlyname", "Windows Vista (640x480, Standard)");
                    SetTheme(RGB(0, 0, 128), RGB(255, 255, 255));

                    SetBool("autoclose", true);
                    SetString("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
                    string[] inspir = { "RRRRRRRR", "RRRRRRRR", "RRRRRRRR" };
                    SetString("culprit", GenFile(true));
                    PushFile(GetString("culprit"), inspir);
                    SetBool("show_description", true);
                    SetBool("font_support", true);
                    break;
                case "Windows 7":
                    this.icon = "3D flag";
                    PushText("A problem has been detected...", "A problem has been detected and Windows has been shut down to prevent damage\r\nto your computer.");
                    PushText("Troubleshooting introduction", "If this is the first time you've seen this Stop error screen,\r\nrestart your computer. If this screen appears again, follow\r\nthese steps:");
                    PushText("Troubleshooting", "Check to make sure any new hardware or software is properly installed.\r\nIf this is a new installation, ask your hardware or software manufacturer\r\nfor any Windows updates you might need.\r\n\r\nIf problems continue, disable or remove any newly installed hardware\r\nor software. Disable BIOS memory options such as caching or shadowing.\r\nIf you need to use Safe mode to remove or disable components, restart\r\nyour computer, press F8 to select Advanced Startup Options, and then\r\nselect Safe Mode.");
                    PushText("Technical information", "Technical information:");
                    PushText("Technical information formatting", "*** STOP: {0} ({1})");
                    PushText("Collecting data for crash dump", "Collecting data for crash dump ...");
                    PushText("Initializing crash dump", "Initializing disk for crash dump ...");
                    PushText("Begin dump", "Beginning dump of physical memory.");
                    PushText("End dump", "Physical memory dump complete.");
                    PushText("Physical memory dump", "Dumping physical memory to disk:{0}");
                    PushText("Culprit file", "The problem seems to be caused by the following file: ");
                    PushText("Culprit file memory address", "***  {0} - Address {1} base at {2}, DateStamp {3}");
                    PushText("Technical support", "Contact your system admin or technical support group for further assistance.");
                    SetFont("Consolas", 9.4f, FontStyle.Regular);
                    SetString("friendlyname", "Windows 7 (640x480, ClearType)");
                    SetTheme(RGB(0, 0, 128), RGB(255, 255, 255));

                    SetBool("autoclose", true);
                    SetString("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
                    string[] inspirc = { "RRRRRRRR", "RRRRRRRR", "RRRRRRRR" };
                    SetString("culprit", GenFile(true));
                    PushFile(GetString("culprit"), inspirc);
                    SetBool("show_description", true);
                    SetBool("font_support", true);
                    break;
                case "Windows 8 Beta":
                    this.icon = "3D flag";
                    PushText("Your computer needs to restart", "Your computer needs to restart.");
                    PushText("Information text with dump", "It encountered a problem and will restart automatically.");
                    PushText("Error code", "Error: {0}");
                    PushText("Progress", "Collecting problem information:    {0} seconds remaining");
                    SetFont("Segoe UI", 26f, FontStyle.Regular);
                    SetTheme(RGB(0, 0, 0), RGB(255, 255, 255));
                    SetString("friendlyname", "Windows 8 Beta (Native, ClearType)");
                    SetInt("margin-x", 250);
                    SetInt("margin-y", 220);
                    SetInt("timer", 10);
                    SetBool("autoclose", true);
                    SetBool("countdown", true);
                    SetString("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
                    SetBool("font_support", true);
                    break;
                case "Windows 8/8.1":
                    this.icon = "3D window";
                    SetString("emoticon", ":(");
                    PushText("Information text with dump", "Your PC ran into a problem and needs to restart. We're just\r\ncollecting some error info, and then you can restart. ({0}%\r\ncomplete)");
                    PushText("Information text without dump", "Your PC ran into a problem that it couldn't\r\nhandle and now it needs to restart.");
                    PushText("Error code", "You can search for the error online: {0}");
                    SetFont("Segoe UI Semilight", 19.4f, FontStyle.Regular);
                    SetTheme(RGB(16, 113, 170), RGB(255, 255, 255));
                    SetString("friendlyname", "Windows 8/8.1 (Native, ClearType)");
                    SetInt("margin-x", 9);
                    SetInt("margin-y", 12);

                    SetBool("autoclose", true);
                    SetString("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
                    SetDefaultProgression();
                    SetBool("show_description", true);
                    SetBool("font_support", true);
                    break;
                case "Windows 10":
                    this.icon = "3D window";
                    SetString("emoticon", ":(");
                    PushText("Information text with dump", "Your PC ran into a problem and needs to restart. We're just\r\ncollecting some error info, and then we'll restart for you.");
                    PushText("Information text without dump", "Your PC ran into a problem and needs to restart. We're just\r\ncollecting some error info, and then you can restart.");
                    PushText("Additional information", "For more information about this issue and possible fixes, visit http://windows.com/stopcode");
                    PushText("Culprit file", "What failed: {0}");
                    PushText("Error code", "If you call a support person, give them this info:\r\n\r\nStop code: {0}");
                    PushText("Progress", "{0}% complete");
                    SetInt("qr_size", 110);
                    SetString("qr_file", "local:0");
                    SetFont("Segoe UI Semilight", 19.4f, FontStyle.Regular);
                    SetTheme(RGB(16, 113, 170), RGB(255, 255, 255));
                    SetString("friendlyname", "Windows 10 (Native, ClearType)");
                    SetInt("margin-x", 9);
                    SetInt("margin-y", 12);

                    SetBool("winxplus", true);
                    SetBool("autoclose", true);
                    SetBool("qr", true);
                    SetBool("device", true);
                    SetString("qr_file", "local:0");
                    SetString("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
                    SetBool("show_description", true);
                    SetBool("font_support", true);
                    SetDefaultProgression();
                    break;
                case "Windows 11":
                    this.icon = "2D window";
                    SetString("emoticon", ":(");
                    PushText("Information text with dump", "Your device ran into a problem and needs to restart. We're just\r\ncollecting some error info, and then we'll restart for you.");
                    PushText("Information text without dump", "Your device ran into a problem and needs to restart. We're just\r\ncollecting some error info, and then you can restart.");
                    PushText("Additional information", "For more information about this issue and possible fixes, visit http://windows.com/stopcode");
                    PushText("Culprit file", "What failed: {0}");
                    PushText("Error code", "If you call a support person, give them this info:\r\n\r\nStop code: {0}");
                    PushText("Progress", "{0}% complete");
                    SetInt("qr_size", 110);
                    SetString("qr_file", "local:0");
                    SetFont("Segoe UI Semilight", 19.4f, FontStyle.Regular);
                    SetTheme(RGB(0, 0, 128), RGB(255, 255, 255));
                    SetString("friendlyname", "Windows 11 (Native, ClearType)");
                    SetInt("margin-x", 9);
                    SetInt("margin-y", 12);

                    SetBool("winxplus", true);
                    SetBool("autoclose", true);
                    SetBool("blackscreen", false);
                    SetBool("qr", true);
                    SetString("qr_file", "local:0");
                    SetString("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
                    SetDefaultProgression();
                    SetBool("show_description", true);
                    SetBool("font_support", true);
                    break;
            }
        }

        public void SetDefaultProgression()
        {
            Log("Info", "Generating default progress tuner configuration");
            int totalmillis = 100;
            int percent = 0;
            while (percent < 100)
            {
                int val = r.Next(0, 9);
                if (val + percent > 100)
                {
                    val = 100 - percent;
                }
                if (val != 0)
                {
                    SetProgression(totalmillis, val);
                    percent += val;
                }
                totalmillis += 100;
            }
            SetInt("progressmillis", totalmillis);
        }
    }
}