using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UltimateBlueScreenSimulator;
using System.Drawing;
using System.Management;
using System.Threading;
using System.Text.Json.Serialization;
using System.Text.Json;

//
// This namespace contains classes that are shared between forms that specify
// using SimulatorDatabase;
// at the top
//
namespace SimulatorDatabase
{

    public class DrawRoutines
    {
        private bool BlinkState { get; set; }
        private bool ForceWatermark { get; set; }

        public DrawRoutines()
        {
            this.BlinkState = false;
            this.ForceWatermark = false;
        }

        /// <summary>
        /// Called when upscaling crash screens to fullscreen or when mirroring them to secondary displays
        /// </summary>
        /// <param name="ws">WindowScreen form</param>
        /// <param name="watermark">Adds a watermark overlay on top of the processed image</param>
        public void Draw(WindowScreen ws, bool watermark)
        {
            ForceWatermark = watermark;
            Draw(ws);
        }

        /// <summary>
        /// Called when upscaling crash screens to fullscreen or when mirroring them to secondary displays
        /// </summary>
        /// <param name="ws">WindowScreen form</param>
        /// <param name="blinkcolor">If passed, a blinking caret will be displayed at the top left</param>
        public void Draw(WindowScreen ws, Color? blinkcolor = null)
        {
            // for upscaling and multidisplay support
            if (ws.primary || Program.gs.DisplayMode == "mirror")
            {
                var frm = Program.verificate ? Form.ActiveForm : null;
                if (frm is null)
                {
                    return;
                }
                using (Bitmap bmp = new Bitmap(frm.Width, frm.Height))
                {
                    frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    if (blinkcolor != null)
                    {
                        if (this.BlinkState)
                        {
                            using (Graphics b = Graphics.FromImage(bmp))
                            {
                                b.FillRectangle(new SolidBrush(blinkcolor ?? Color.White), new Rectangle(0, 6, 8, 2));
                            }
                        }
                        this.BlinkState = !this.BlinkState;
                    }
                    if (ForceWatermark)
                    {
                        using (Graphics b = Graphics.FromImage(bmp))
                        {
                            b.DrawString("blue screen simulator plus", new Font("Segoe UI", 7, FontStyle.Regular), new SolidBrush(Color.FromArgb(128, Color.Blue)), new Point(2,0));
                        }
                    }
                    Bitmap newImage = new Bitmap(ws.Width, ws.Height);
                    using (Graphics g = Graphics.FromImage(newImage))
                    {
                        g.InterpolationMode = Program.gs.GetInterpolationMode();
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
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
    public class BlueScreen
    {
        /* this stuff is required to serialize various parts of the class correctly */
        public IDictionary<string, int> Background {
            get { return I_color_builder(background); }
            set { background = I_decode_color(value); }
        }

        public IDictionary<string, int> Foreground {
            get { return I_color_builder(foreground); }
            set { foreground = I_decode_color(value); }
        }

        public IDictionary<string, int> Highlight_BG {
            get { return I_color_builder(highlight_bg); }
            set { highlight_bg = I_decode_color(value); }
        }

        public IDictionary<string, int> Highlight_FG {
            get { return I_color_builder(highlight_fg); }
            set { highlight_fg = I_decode_color(value); }
        }

        
        public IDictionary<string, dynamic> Font {
            get {
                return new Dictionary<string, dynamic>() {
                    { "FontFamily", font.FontFamily.Name },
                    { "Bold", font.Bold },
                    { "Italic", font.Italic },
                    { "Strikeout", font.Strikeout },
                    { "Underline", font.Underline },
                    { "Size", font.Size },
                };
            }
            set {
                font = new Font(new FontFamily(((JsonElement)value["FontFamily"]).ToString()), ((JsonElement)value["Size"]).Deserialize<float>(), FontStyle.Regular);
                if (((JsonElement)value["Bold"]).Deserialize<bool>())
                {
                    font = new Font(font, font.Style ^ FontStyle.Bold);
                }
                if (((JsonElement)value["Italic"]).Deserialize<bool>())
                {
                    font = new Font(font, font.Style ^ FontStyle.Italic);
                }
                if (((JsonElement)value["Underline"]).Deserialize<bool>())
                {
                    font = new Font(font, font.Style ^ FontStyle.Underline);
                }
                if (((JsonElement)value["Strikeout"]).Deserialize<bool>())
                {
                    font = new Font(font, font.Style ^ FontStyle.Strikeout);
                }
            }
        }

        private IDictionary<string, int> I_color_builder(Color color)
        {
            return new Dictionary<string, int>()
            {
                {"R", color.R },
                {"G", color.G },
                {"B", color.B },
            };
        }

        private Color I_decode_color(IDictionary<string, int> data)
        {
            return Color.FromArgb(
                data["R"],
                data["G"],
                data["B"]
                );
        }

        private Color background { get; set; }
        private Color foreground { get; set; }
        private Color highlight_bg { get; set; }
        private Color highlight_fg { get; set; }
        private Font font { get; set; }
        public string[] ecodes { get; set; }

        public string os { get; set; }

        // possible values:
        // 2D flag
        // 3D flag
        // 2D window
        // 3D window
        public string icon { get; set; }

        public IDictionary<string, string> titles { get; set; }
        public IDictionary<string, string> texts { get; set; }
        public List<KeyValuePair<string, string[]>> codefiles { get; set; }

        public IDictionary<string, bool> bools { get; set; }
        public IDictionary<string, int> ints { get; set; }
        public IDictionary<string, string> strings { get; set; }
        public IDictionary<int, int> progression { get; set; }

        [JsonIgnore]
        private readonly Random r;

        // constructor
        ///<summary>
        ///Blue screen template class. Requires base_os to be set to one of the preset OS templates. If desired, autosetup can be disabled, which makes it so that the template will not set default settings.
        ///</summary>
        public BlueScreen(string base_os, bool autosetup = true)
        {
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
            this.codefiles = new List<KeyValuePair<string, string[]>>();
            this.bools = new Dictionary<string, bool>();
            this.ints = new Dictionary<string, int>();
            this.strings = new Dictionary<string, string>();
            this.progression = new Dictionary<int, int>();
            this.font = new Font("Lucida Console", 10.4f, FontStyle.Regular);
            if (autosetup && Program.verificate) { SetOSSpecificDefaults(); }
        }

        [JsonConstructor]
        public BlueScreen()
        {
            this.r = new Random();
            this.background = new Color();
            this.foreground = new Color();
            this.highlight_bg = new Color();
            this.highlight_fg = new Color();
            this.titles = new Dictionary<string, string>();
            this.texts = new Dictionary<string, string>();
            this.codefiles = new List<KeyValuePair<string, string[]>>();
            this.bools = new Dictionary<string, bool>();
            this.ints = new Dictionary<string, int>();
            this.strings = new Dictionary<string, string>();
            this.progression = new Dictionary<int, int>();
        }

        ///<summary>
        ///Returns boolean dictionary
        ///</summary>
        public IDictionary<string, bool> AllBools() { return this.bools; }


        ///<summary>
        ///Returns integers dictionary
        ///</summary>
        public IDictionary<string, int> AllInts() { return this.ints; }

        ///<summary>
        ///Returns dictionary of strings
        ///</summary>
        public IDictionary<string, string> AllStrings() { return this.strings; }

        ///<summary>
        ///Returns dictionary of progress tuner preferences
        ///</summary>
        public IDictionary<int, int> AllProgress() { return this.progression; }


        ///<summary>
        ///Logs an event
        ///</summary>
        ///<param name="e">Desired event type</param>
        ///<param name="message">Description of the event</param>
        public void Log(string e, string message)
        {
            Program.gs.Log(e, message, this.strings.Keys.Contains("friendlyname") ? this.strings["friendlyname"] : "");
        }

        // blue screen properties
        ///<summary>
        ///Gets a single boolean value. If no matching value is found, a default value of false will be returned.
        ///</summary>
        ///<param name="name">Key in the dictionary</param>
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


        ///<summary>
        ///Sets a single boolean value. If no existing value with the name specified is found, a new entry in the dictionary will be created.
        ///</summary>
        ///<param name="name">Dictionary key or variable name</param>
        ///<param name="value">The value which you set the boolean to</param>
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

        ///<summary>
        ///Gets a single string value. If no matching value is found, a default value of "" will be returned.
        ///</summary>
        ///<returns>A string from the specified dictionary key with certain exceptions (os and icon return the corresponding variables, ecode1, ecode2, ecode3, ecode4 return value from ecodes array of specified index.</returns>
        ///<param name="name">Key in the dictionary (except for special cases)</param>
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

        ///<summary>
        ///Sets a single string value. If no existing value with the name specified is found, a new entry in the dictionary will be created.
        ///<para><strong>Special case for "os" and "icon"</strong></para><para>These strings modify the corresponding variables directly instead of modifying dictionary entries</para>
        ///</summary>
        ///<param name="name">Dictionary key or variable name (see special case for "os" and "icon")</param>
        ///<param name="value">The value which you set the string to</param>
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

        ///<summary>
        ///Erases all texts and titles, which the user can access in additional options
        ///</summary>
        public void ClearAllTitleTexts()
        {
            Log("Info", $"Clearing all titles and texts");
            this.titles.Clear();
            this.texts.Clear();
        }

        ///<summary>
        ///Erases all timing data for progress tuner
        ///</summary>
        public void ClearProgress()
        {
            Log("Info", $"Clearing progress tuning data");
            this.progression.Clear();
        }

        ///<summary>
        ///Modifies a value in the titles dictionary, which is like strings, but which can be accessed by the user under additional options (difference between titles and texts is semantic)
        ///</summary>
        ///<param name="name">Dictionary key or variable name</param>
        ///<param name="value">The value which you set the string to</param>
        public void SetTitle(string name, string value)
        {
            Log("Info", $"Setting title {name} to {value}");
            this.titles[name] = value;
        }

        ///<summary>
        ///Adds a value to the titles dictionary, which is like strings, but which can be accessed by the user under additional options (difference between titles and texts is semantic)
        ///</summary>
        ///<param name="name">Dictionary key or variable name</param>
        ///<param name="value">The value which you set the string to</param>
        public void PushTitle(string name, string value)
        {
            Log("Info", $"Pushing title {name} with value {value}");
            this.titles.Add(name, value);
        }


        ///<summary>
        ///Modifies a value in the texts dictionary, which is like strings, but which can be accessed by the user under additional options (difference between titles and texts is semantic)
        ///</summary>
        ///<param name="name">Dictionary key or variable name</param>
        ///<param name="value">The value which you set the string to</param>
        public void SetText(string name, string value)
        {
            Log("Info", $"Setting text {name} to {value}");
            this.texts[name] = value;
        }

        ///<summary>
        ///Adds a value to the texts dictionary, which is like strings, but which can be accessed by the user under additional options (difference between titles and texts is semantic)
        ///</summary>
        ///<param name="name">Dictionary key or variable name</param>
        ///<param name="value">The value which you set the string to</param>
        public void PushText(string name, string value)
        {
            Log("Info", $"Pushing text {name} with value {value}");
            this.texts.Add(name, value);
        }

        // theming
        ///<summary>
        ///Allows you to access a specific color used by the configuration
        ///</summary>
        ///<param name="bg">Determines whether to get a background color or not</param>
        ///<param name="highlight">Determines whether or not to get a highlight color</param>
        public Color GetTheme(bool bg, bool highlight = false)
        {
            Log("Info", $"Getting " + (highlight ? "highlight " : "") + (bg ? "background" : "foreground") + " color" );
            if (highlight && Program.verificate)
            {
                if (bg) { return this.highlight_bg; } else { return this.highlight_fg; }
            }
            if (bg) { return this.background; } else { return this.foreground; }
        }

        ///<summary>
        ///Allows you to set colors used by the configuration
        ///</summary>
        ///<param name="bg">Background color</param>
        ///<param name="fg">Foreground color</param>
        ///<param name="highlight">Determines if these colors are applied to highlights or normal text</param>
        public void SetTheme(Color bg, Color fg, bool highlight = false)
        {
            Log("Info", $"Setting " + (highlight ? "highlight" : "base")  + $" colors to ({bg.R}, {bg.G}, {bg.B}), ({fg.R}, {fg.G}, {fg.B})");
            if (highlight && Program.verificate)
            {
                this.highlight_bg = bg;
                this.highlight_fg = fg;
                return;
            }
            this.background = bg;
            this.foreground = fg;
        }

        // error codes
        ///<summary>
        ///Gets an array of error codes used by the configuration
        ///</summary>
        public string[] GetCodes()
        {
            Log("Info", $"Getting error codes");
            return this.ecodes;
        }

        ///<summary>
        ///Allows you to set error codes used by the configuration
        ///</summary>
        ///<param name="code1">First block</param>
        ///<param name="code2">Second block</param>
        ///<param name="code3">Third block</param>
        ///<param name="code4">Fourth block</param>
        public void SetCodes(string code1, string code2, string code3, string code4)
        {
            Log("Info", $"Setting error codes to {code1}, {code2}, {code3}, {code4}");
            string[] code_temp = { code1, code2, code3, code4 };
            this.ecodes = code_temp;
        }

        ///<summary>
        ///Allows for converting r,g,b intensities to System.Drawing.Color
        ///</summary>
        ///<param name="r">Red intensity</param>
        ///<param name="g">Green intensity</param>
        ///<param name="b">Blue intensity</param>
        private Color RGB(int r, int g, int b)
        {
            Log("Info", $"Getting color from values {r}, {g}, {b}");
            return Color.FromArgb(r, g, b);
        }

        // integers
        ///<summary>
        ///Gets an integer value from the ints dictionary, which may be used to store settings like timeouts, blink speed, etc.
        ///</summary>
        ///<param name="name">Key of the dictionary</param>
        public int GetInt(string name)
        {
            Log("Info", $"Getting integer value of {name}");
            if (this.ints.ContainsKey(name) && Program.verificate)
            {
                return this.ints[name];
            }
            else
            {
                Log("Warning", "No data, returning 1");
                return 1;
            }
        }

        ///<summary>
        ///Sets an integer value for the ints dictionary, which may be used to store settings like timeouts, blink speed, etc. If the key does not exist, a new key value pair will be pushed to the ints dictionary.
        ///</summary>
        ///<param name="name">Key of the dictionary</param>
        ///<param name="value">Integer value</param>
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


        ///<summary>
        ///Sets the font, which is used by the selected configuration when displaying text.
        ///</summary>
        ///<param name="font_family">Family of the font, e.g. Arial, Segoe UI, Consolas, etc.</param>
        ///<param name="emsize">Size of the font in points (e.g. value of 12f is 12pt)</param>
        ///<param name="style">Special font style attributes, such as bold, italic, underline, strikethrough, etc.</param>
        public void SetFont(string font_family, float emsize, FontStyle style)
        {
            Log("Info", $"Setting font as {font_family}, {emsize}pt");
            this.font = new Font(font_family, emsize, style);
        }

        ///<summary>
        ///Gets the font, which is used by the selected configuration when displaying text.
        ///</summary>
        public Font GetFont()
        {
            Log("Info", $"Getting current font");
            return this.font;
        }

        ///<summary>
        ///Gets the icon, which is used by the selected configuration on the taskbar and window title bar.
        ///</summary>
        public Icon GetIcon()
        {
            Log("Info", $"Getting icon");
            switch (GetString("icon"))
            {
                case "3D flag":
                    return UltimateBlueScreenSimulator.Properties.Resources.Tatice_Operating_Systems_Windows;
                case "3D window":
                    return UltimateBlueScreenSimulator.Properties.Resources.Dakirby309_Windows_8_Metro_Folders_OS_Windows_8_Metro;
                case "2D window":
                    return UltimateBlueScreenSimulator.Properties.Resources.new_windows_logo__2_;
                case "2D flag":
                default:
                    return UltimateBlueScreenSimulator.Properties.Resources.artage_io_48148_1564916990;
            }
        }

        ///<summary>
        ///Returns all entries from the titles dictionary
        ///</summary>
        public IDictionary<string, string> GetTitles()
        {
            Log("Info", $"Getting all titles");
            return this.titles;
        }


        ///<summary>
        ///Returns all entries from the texts dictionary
        ///</summary>
        public IDictionary<string, string> GetTexts()
        {
            Log("Info", $"Getting all texts");
            return this.texts;
        }



        // progress keyframes
        ///<summary>
        ///Gets progress tuner value at a specified time index
        ///</summary>
        ///<param name="name">Time index (roughly 5ms)</param>
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

        ///<summary>
        ///Sets progress tuner value at a specified time index
        ///</summary>
        ///<param name="name">Time index (roughly 5ms)</param>
        ///<param name="value">Value increment (e.g. if increment is 5, then a value of 25 would change to 30 at this keyframe)</param>
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

        ///<summary>
        ///Bulk applies progression based on two integer arrays (keys and values)
        ///</summary>
        ///<param name="keys">List of keyframe indicies</param>
        ///<param name="values">List of value increments at specified keyframe indicies</param>
        public void SetAllProgression(int[] keys, int[] values)
        {
            Log("Info", $"Setting progress tuner data to predefined array");
            this.progression.Clear();
            for (int i = 0; i < keys.Length; i++)
            {
                this.progression[keys[i]] = values[i];
            }
        }

        ///<summary>
        ///Uses the GenHex function to generate multiple error address codes.
        ///</summary>
        ///<param name="count">Number of address codes to generate</param>
        ///<param name="places">Number of places for each code (e.g. 6 places with a template RRRRRRRR might generate 259AD1 for one block)</param>
        ///<param name="lower">Determines if the generated addresses should be in lowercase (such is the case with date codes, such as on NT4)</param>
        ///<returns>List of generated codes as a formatted string with comma separation and with 0x in front of each generated hex code</returns>
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

        ///<summary>
        ///Generates hexadecimal codes
        ///</summary>
        ///<param name="lettercount">Sets the length of the actual hex code</param>
        ///<param name="inspir">A string where each character represents if the value is fixed or random (e.g. 63RR25E0, which might return as 631725E0)</param>
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

        ///<summary>
        ///Adds a file to codefiles. These files are displayed on the NT4 bugcheck as well as on Windows XP/Vista/7 if additional information about culprit file is enabled.
        ///</summary>
        ///<param name="name">Name of file</param>
        ///<param name="codes">Array of error code templates (e.g. ["RRR00RRR", "RRRRRRRR"])</param>
        public void PushFile(string name, string[] codes)
        {
            Log("Info", $"Pushing culprit file {name} with error templates [{string.Join(", ", codes)}]");
            
            if (!KvpContainsKey(name, codefiles) && Program.verificate)
            {
                codefiles.Add(new KeyValuePair<string, string[]>(name, codes));
            }
        }

        /// <summary>
        /// Internal function for checking if KeyValuePair exists in a list
        /// </summary>
        /// <param name="key">Key to search for</param>
        /// <param name="list">List to search from</param>
        /// <returns>true if key is in list containing key value pairs</returns>
        private bool KvpContainsKey(string key, List<KeyValuePair<string, string[]>> list)
        {
            foreach (KeyValuePair<string, string[]> kvp in list)
            {
                if (kvp.Key == key)
                {
                    return true;
                }
            }
            return false;
        }

        ///<summary>
        ///Returns the list of code files, which are displayed on NT4 bugcheck
        ///</summary>
        public List<KeyValuePair<string, string[]>> GetFiles()
        {
            Log("Info", $"Getting culprit files");
            return codefiles;
        }

        ///<summary>
        ///Clears the list of code files, which are displayed on NT4 bugcheck
        ///</summary>
        public void ClearFiles()
        {
            Log("Info", $"Clearing culprit files");
            codefiles.Clear();
        }

        ///<summary>
        ///Renames a file in the codefiles list
        ///</summary>
        ///<param name="idx">Index of the file to be renamed</param>
        ///<param name="renamed">String value which is used to rename the file</param>
        public void RenameFile(int idx, string renamed)
        {
            Log("Info", $"Attempting to rename file with index {idx} to {renamed}");
            bool isRenamed = false;
            string[] codes;
            foreach (KeyValuePair<string, string[]> kvp in this.GetFiles())
            {
                if (GetFile(idx).Key == kvp.Key)
                {
                    codes = kvp.Value;
                    this.codefiles[idx] = new KeyValuePair<string, string[]>(renamed, codes);
                    isRenamed = true;
                    break;
                }
            }
            if (!isRenamed)
            {
                Log("Error", $"Couldn't rename {idx}!!! Reason: File does not exist in List!");
            }
        }

        /// <summary>
        /// Removes a file from the codefiles list
        /// </summary>
        /// <param name="idx">Index of the file</param>
        public void RemoveFile(int idx)
        {
            codefiles.RemoveAt(idx);
        }

        /// <summary>
        /// Returns a file at the specified index
        /// </summary>
        /// <param name="idx">Index of file</param>
        /// <returns>KeyValuePair consisting of a filename as the key and an array of error code templates as the value</returns>
        public KeyValuePair<string, string[]> GetFile(int idx)
        {
            return codefiles[idx];
        }

        ///<summary>
        ///Modifies an error code template in the codefiles dictionary
        ///</summary>
        ///<param name="idx">Index of the file to be renamed</param>
        ///<param name="subcode">Index of the error code template</param>
        ///<param name="code">New value for the specified error code template</param>
        public void SetFile(int idx, int subcode, string code)
        {
            Log("Info", $"Modifying file at index {idx}");
            bool isModified = false;
            foreach (KeyValuePair<string, string[]> kvp in this.GetFiles())
            {
                if ((GetFile(idx).Key == kvp.Key) && Program.verificate)
                {
                    string[] codearray = kvp.Value;
                    codearray[subcode] = code;
                    this.codefiles[idx] = new KeyValuePair<string, string[]>(GetFile(idx).Key, codearray);
                    isModified = true;
                    break;
                }
            }
            if (!isModified)
            {
                Log("Error", $"Couldn't modify file at index {idx}!!! Reason: File does not exist in List!");
            }
        }


        ///<summary>
        ///Generates a new file for use in Windows NT blue screen
        ///</summary>
        ///<param name="lower">Determines if the filename should be in lowercase</param>
        public string GenFile(bool lower = true)
        {
            Log("Info", "Generating a random file for NT blue screen" + (lower ? " in lowercase" : ""));
            string[] files;
            if (Program.templates != null) {
                files = Program.templates.CulpritFiles;
            }
            else
            {
                files = UltimateBlueScreenSimulator.Properties.Resources.CULPRIT_FILES.Replace("\r\n", "\n").Split('\n');
            }
            List<string> filenames = new List<string>();
            foreach (string line in files)
            {
                filenames.Add(line.Split(':')[0]);
            }
            if (filenames.Count > 0)
            {
                int temp = this.r.Next(filenames.Count - 1);
                // dupes are fine :)
                /*while (this.GetFiles().ContainsKey(filenames[temp]))
                {
                    temp = this.r.Next(filenames.Count - 1);
                }*/
                if (!lower)
                {
                    return filenames[temp];
                }
                else
                {
                    return filenames[temp].ToLower();
                }
            } else
            {
                return "null";
            }
        }

        ///<summary>
        ///Attempts to simulate a crash with this configuration
        ///</summary>
        public void Show()
        {
            Log("Info", "Simulation requested!");
            if (!Program.verificate) { return; }
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
                    SetupNT(new W2kbs());
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

        ///<summary>
        ///Prepares Windows 8 Beta bugcheck for simulation
        ///</summary>
        ///<param name="bs">Form for the simulator</param>
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

        ///<summary>
        ///Prepares Windows CE blue screen for simulation
        ///</summary>
        ///<param name="bs">Form for the simulator</param>
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

        ///<summary>
        ///Checks if a message needs to be displayed in case it hasn't already been displayed
        ///</summary>
        private void CheckMessageJustInCase()
        {
            Log("Info", "Called CheckMessageJustInCase method");
            if (!Program.gs.ShowCursor)
            {
                Cursor.Show();
            }
            if (Program.gs.PM_ShowMessage)
            {
                MessageBox.Show(Program.gs.PM_MsgText,
                                Program.gs.PM_MsgTitle,
                                Program.gs.PM_MsgType,
                                Program.gs.PM_MsgIcon);
                Program.gs.PM_ShowMessage = false;
            }
        }

        ///<summary>
        ///Prepares Windows NT blue screen for simulation
        ///</summary>
        ///<param name="bs">Form for the simulator</param>
        private void SetupNT(W2kbs bs)
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

        ///<summary>
        ///Prepares Windows 3.1x/9x/Me blue screen for simulation
        ///</summary>
        ///<param name="bs">Form for the simulator</param>
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


        ///<summary>
        ///Prepares Windows 1.x/2.x blue screen for simulation
        ///</summary>
        ///<param name="bs">Form for the simulator</param>
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

        ///<summary>
        ///Prepares Windows 2000 blue screen for simulation
        ///</summary>
        ///<param name="bs">Form for the simulator</param>
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

        ///<summary>
        ///Prepares Windows XP blue screen for simulation
        ///</summary>
        ///<param name="bs">Form for the simulator</param>
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

        ///<summary>
        ///Prepares Windows Vista blue screen for simulation
        ///</summary>
        ///<param name="bs">Form for the simulator</param>
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

        ///<summary>
        ///Prepares Windows 10+ blue screen for simulation
        ///</summary>
        ///<param name="bs">Form for the simulator</param>
        private void SetupWinXabove(WXBS bs, bool w11 = false)
        {
            Log("Info", "Setting up Windows 8.x/10/11 simulator in SetupWinXabove method");
            if (bs.emoticonLabel is null) { return; }
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

        ///<summary>
        ///Prepares Windows 8 blue screen for simulation
        ///</summary>
        ///<param name="bs">Form for the simulator</param>
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

        ///<summary>
        ///Displays a metacrash screen
        ///</summary>
        ///<param name="message">Error message</param>
        ///<param name="stacktrace">Error stack trace</param>
        ///<param name="type">Error type (such as OrangeScreen, GreenScreen etc.)</param>
        public void Crash(Exception ex, string type)
        {
            Log("Warning", $"Triggered metacrash with the following info: message={ex.Message}, stacktrace={ex.StackTrace}, type={type}");
            Metaerror me = new Metaerror
            {
                ex = ex,
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

        ///<summary>
        ///Loads default configuration values for specified OS template
        ///</summary>
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
                    SetBool("halfres", false);
                    SetString("qr_file", "local:1");
                    break;
                case "Windows 3.1x":
                    SetTheme(RGB(0, 0, 170), RGB(255, 255, 255));
                    SetTheme(RGB(170, 170, 170), RGB(0, 0, 170), true);
                    SetInt("blink_speed", 100);
                    PushTitle("Main", "Windows");
                    PushText("No unresponsive programs", "Altough you can use CTRL+ALT+DEL to quit an application that has\r\nstopped responding to the system, there is no application in this\r\nstate.\r\n\r\nTo quit an application, use the application's quit or exit command,\r\nor choose the Close command from the Control menu.\r\n\r\n* Press any key to return to Windows\r\n* Press CTRL + ALT + DEL again to restart your computer.You will\r\nlose any unsaved information in all applications.");
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
                    PushText("System error (Windows Me beta)", "An error has occurred.\r\n\r\nTo continue:\r\n\r\n*  Press any key to return to Windows, or\r\n\r\n*  Press CTRL+ALT+DEL to restart your computer.\r\n   If you do this, you will lose any unsaved information in all\r\n   open applications.\r\n\r\n\r\n                     Error: {0}");
                    PushText("Application error", "A fatal exception {2} has occurred at {0}:{1}. The current\r\napplication will be terminated.\r\n\r\n* Press any key to terminate current application\r\n* Press CTRL + ALT + DEL again to restart your computer. You will\r\n  lose any unsaved information in all applications.");
                    PushText("Application error (Windows 95 beta)", "A fatal exception {2} has occurred at {0}:{1}. The current\r\napplication will be terminated.");
                    PushText("Recoverable application error", "An exception {0} has occurred at {1}:{2} in VxD HSFLOP(03) +\r\n{3}.  This was called from {4}:{5} in VxD HSFLOP(03) +\r\n{6}.  It may be possible to continue normally.\r\n\r\n*  Press any key to attempt to continue.\r\n*  Press CTRL+ALT+DEL to restart your computer.  You will\r\n   lose any unsaved information in all applications. ");
                    PushText("Driver error", "A fatal exception {2} has occurred at {0}:{1} in VXD VMM(01) +\r\n{2}. The current application will be terminated.\r\n\r\n* Press any key to terminate current application\r\n* Press CTRL + ALT + DEL again to restart your computer. You will\r\n  lose any unsaved information in all applications.");
                    PushText("System is busy", "The system is busy waiting for the Close Program dialog box to be\r\ndisplayed. You can wait and see if it appears, or you can restart\r\nyour computer.\r\n\r\n* Press any key to return to Windows and wait.\r\n* Press CTRL + ALT + DEL again to restart your computer. You will\r\n  lose any unsaved information in programs that are running.");
                    PushText("System is unresponsive", "The system is either busy or has become unstable. You can wait and\r\nsee if it becomes available again, or you can restart your computer.\r\n\r\n* Press any key to return to Windows and wait.\r\n* Press CTRL + ALT + DEL again to restart your computer. You will\r\n  lose any unsaved information in programs that are running.");
                    PushText("Prompt", "Press any key to continue");
                    PushText("Unsafe eject", "The volume that was removed has open\r\nfiles on it. Next time please check first\r\nto see if the volume can really be removed.");
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
                case "Windows NT 3.1":
                    this.os = "Windows NT 3.x/4.0";
                    SetTheme(RGB(0, 0, 160), RGB(170, 170, 170));
                    SetBool("threepointone", true);
                    PushText("Bootscreen", "Microsoft (R) Windows NT (TM) Version 3.1 [32320 Kb Memory]");
                    PushText("Error code formatting", "*** STOP: {0} ({1})");
                    PushText("Stack trace heading", "Dll Base DateStmp - Name");
                    PushText("Stack trace table formatting", "{0} {1} - {2}");
                    PushText("Memory address dump heading", "Address  dword dump   Build [v1.528]                         - Name");
                    PushText("Memory address dump table", "{0} {1} {2} {3} {4} {5} {6} - {7}");
                    PushText("Troubleshooting text", "Restart your computer. If this message reappears, do not restart.\r\nContact your system administrator or technical support group, and/or\r\nperipheral device vendor.");
                    SetInt("blink_speed", 100);
                    SetString("friendlyname", "Windows NT 3.1 (Text mode, Standard)");
                    for (int n = 0; n < 10; n++)
                    {
                        string[] inspirn = { "RRRRRRRR", "RRRRRRRR" };
                        PushFile(GenFile(true), inspirn);
                    }
                    for (int n = 0; n < 30 - this.codefiles.Count / 2; n++)
                    {
                        string[] inspirn = { "RRRRRRRR", "RRRRRRRR", "RRRRRRRR", "RRRRRRRR", "RRRRRRRR", "RRRRRRRR", "RRRRRRRR" };
                        PushFile(GenFile(true), inspirn);
                    }
                    SetBool("font_support", false);
                    SetBool("blinkblink", true);
                    SetBool("blink", true);
                    SetBool("bootscreen", true);

                    SetString("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
                    SetBool("stack_trace", true);
                    break;
                case "Windows NT 3.x/4.0":
                    this.icon = "2D flag";
                    SetTheme(RGB(0, 0, 160), RGB(170, 170, 170));
                    PushText("Error code formatting", "*** STOP: {0} ({1})");
                    PushText("CPUID formatting", "CPUID: {0} 6.3.3 irql:lf SYSVER 0xf0000565");
                    PushText("Stack trace heading", "Dll Base DateStmp - Name");
                    PushText("Stack trace table formatting", "{0} {1} - {2}");
                    PushText("Memory address dump heading", "Address  dword dump   Build [1381]                           - Name");

                    PushText("Memory address dump table", "{0} {1} {2} {3} {4} {5}          - {6}");
                    PushText("Troubleshooting text", "Restart and set the recovery options in the system control panel\r\nor the /CRASHDEBUG system start option.");
                    SetInt("blink_speed", 100);
                    SetString("friendlyname", "Windows NT 4.0/3.5x (Text mode, Standard)");
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
                    SetInt("qr_size", 150);
                    SetString("qr_file", "local:0");
                    SetFont("Segoe UI Semilight", 18.4f, FontStyle.Regular);
                    SetTheme(RGB(22, 60, 141), RGB(255, 255, 255));
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

        ///<summary>
        ///Generates default progress tuner configuration
        ///</summary>
        public void SetDefaultProgression()
        {
            //Program.verificate = Program.verifile.RC();
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