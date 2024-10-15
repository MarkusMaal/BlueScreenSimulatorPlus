# BlueScreenSimulatorPlus (master branch)
Open source code for BSSP. This is an enhanced blue screen simulator application for Windows. Use Visual Studio to recompile.

Codename: ModestIndigo

Version 3.02

\{ \} markus' software // \{ \} markuse tarkvara

## Downloading the simulator
To download the latest version of simulator, you can use two methods:
* Manual download  - go to the releases section of this repostiory (on the right side of this web page) and download the latest version.
* Automatic update - when launching BlueScreenSimulatorPlus, it should automatically check if new version is available and if it is, then notify the user to download it. The download will happen within the program and after the download is finished, the updated version will be launched automatically.

## End-user documentation
The online documentation for the latest stable release can be found at [markustegelane.eu/bssp/help.pdf](https://markustegelane.eu/bssp/help.pdf).

## Developer documentation
This documentation is contained within the readme and is meant for people who want to modify and further develop/contribute to this repository or just curious nerds.

### Table of contents
* [Global settings](#global-settings)
* [Logging events](#logging-events)
* [Blue screen class](#blue-screen-class)
* [Developer mode](#developer-mode)
* [Processing args](#processing-args)
* [Template registry](#template-registry)
* [Draw routines](#draw-routines)
* [File structure](#file-structure)
	* [Interfaces](#interfaces)
	* [Legacy interfaces](#legacy-interfaces)
	* [Load screens](#load-screens)
	* [Simulators](#simulators)
	* [Special classes](#special-classes)
	* [Miscellaneous](#miscellaneous)
	* [Runtime](#runtime)
	* [Assets](#assets)
	* [Properties](#properties)
	* [Custom controls](#custom-controls)
* [Verifile](#verifile)

### Global settings
Settings can be defined inside the GlobalSettings class. Each setting has a summary, which is displayed if IntelliSense is enabled for your code editor.

Defining a global setting:
```C#
	private bool my_setting = false;

	///<summary>
	///A short summary about what the setting is used for
	///</summary>
	public bool MySetting {
		get { return my_setting; }
		set { my_setting = value; }
	}
```

Enums can be defined like so:
```C#
	///<summary>
	///Type of user for something something
	///</summary>
	public Roles UserType = Roles.Admin;


	public enum Roles
	{
		Admin,
		Restricted,
		Developer
	}
```

### Logging events

You can log events through GlobalSettings class. To add an application-wide log, you may use the following code snippet.

```C#
	Program.gs.Log("Info", "This is a log event!");
```

Which may result in the following log line:
`[2024-06-19 00:00:00] Info - This is a log event!`

Optionally, you can pass the source, which will be appended to the end with an @ symbol, like so:
```C#
	Program.gs.Log("Info", "This is a log event!", "A source");
```

Which may result in the following log line:
`[2024-06-19 00:00:00] Info - This is a log event! @ A source`

Please note that a source should accurately describe where the event was triggered from. An accurate source may be a class name or name of a configuration (if called from SimulatorDatabase)

Logs can be dumped with the GetLog method. There's also an optional "reverse" argument, which if set to false will produce a log, where each event is sorted from oldest to newest, otherwise, for example:

```C#
	string log_dump = Program.gs.GetLog(false);
```

### Blue screen class

You can define a bluescreen using the SimulatorDatabase namespace. Here's an example

```C#
using SimulatorDatabase;
using System.Drawing;
	
namespace UltimateBlueScreenSimulator {
	static class Program {
		[STAThread]
		public static void Main(string[] args) {
			// initialize BlueScreen object
			BlueScreen me = new BlueScreen("Windows Vista");
			// change font
			me.SetFont("Comic Sans MS", 10.4f, FontStyle.Italic);
			// disable watermark
			me.SetBool("watermark", false);
			// change colors to Yellow on Red
			me.SetTheme(Color.Red, Color.Yellow);
			// display the crash screen
			me.Show();
		}
	}
}

```

Each **BlueScreen** object contains the following dictionaries:

* titles/texts  - Strings, which directly change text on the blue screen and which the user can modify under the additional options menu. The difference between titles and texts is semantic.
* strings       - Strings, which change various aspects of the blue screen, but which can't be directly changed through the additional options dialog.
* codefiles     - NT error codes with files
* bools         - Boolean values, which turn features on/off or change a condition. Generally, these options are changed on the main window by checking/unchecking a checkbox.
* ints          - Integer values, which can be made visible under the additional options menu.
* progression   - Progress tuner keyframes and increments

These dictionaries are available no matter, which OS template you use, however depending on the simulator, they might not be used. To see what kind of values each OS templates use, you may want to have a look at ***SetOSSpecificDefaults*** method and see which values are set under each OS template.

### Developer mode

Developer mode provides certain useful tests and devtools, which aren't normally available on the release version. Depending on the build you clone, the developer mode may already be enabled, however if it isn't, you can follow these steps:

1. Open AboutSettingsDialog.cs in a text editor or IDE
2. Find the DevBuild variable and make sure it's set to true
3. Build and run the application
4. Open the hamburger menu (if you're on new UI) and click on the settings button
5. Go to the simulator settings tab
6. You should now see a bunch of buttons at the top-right of the window with the prefix [DEV] or [TEST]

The following developer options may be available:

* [DEV] Restart application - aborts current session and forcibly reset the application
* [TEST] Gen                - allows you to test blue screen generation interface
* [DEV] New All             - resets all configurations
* [DEV] DictEdit            - allows you to edit dictionaries for the selected configuration during runtime
* [DEV] Splash Screen       - displays the splash screen, which you can close by pressing ESC

***Important***: Developer mode should only be enabled on beta builds. It should be disabled before releasing stable versions.

### Processing args

You can use CLIProcessor class to process args. You can initialize it like so:

```C#
namespace UltimateBlueScreenSimulator {
	static class Program {
		[STAThread]
		public static void Main (string[] args) {
			CLIProcessor clip = new CLIProcessor(args);
			clip.ProcessArgs();
		}
	}
}
```

After calling the ProcessArgs method, several other methods may also be executed, here's a list of them:

* ProcessFlag        - Goes through every arg with a slash in front, e.g. /? (private)
* ProcessValue       - This may be called if a flag has a value next to it (private)
* PostProcess        - This is called after every other arg is processed (private)
* ForceBool          - Forces a certain key in bools dictionary to specific value (private)
* ExitSplash         - Exits splash screen (internal)
* CheckNoSplash      - Checks if the /hidesplash or /finalize_update flags have been passed (public)
* CheckPreviewSplash - Checks if the /preview_splash flag has been passed (public)

### Template registry
List of configurations is globally managed by TemplateRegistry. It allows you to add/remove/modify configurations, save/load them as a file and more. By default, the global template registry is stored in program as a static variable `templates`, however you can initialize a new TemplateRegistry using the following code:

```C#
	TemplateRegistry tr = new TemplateRegistry();
```

#### Changing the default list of configurations
You can add or remove default configurations by modifying the `defaults` variable assignment in the TemplateRegistry constructor.

#### Manipulating templates
* Deleting all configurations can be done by calling the `Clear()` method directly on a template registry object.
* Defaults can be restored by calling the `Reset()` method (no need to call `Clear()`)
* Adding a template requires calling the `AddTemplate` method, which takes 1 or 3 arguments
	* baseOS is the name of the OS template is based on
	* friendlyname (optional) is the name of the configuration displayed to the user
	* template (optional) is the name of the OS which the default settings will be based on (usually template == baseOS)
* Getting the last BlueScreen object from the list can be done by calling the `GetLast()` method
* Getting all BlueScreen objects as an array can be done by calling the `GetAll()` method
* To get a specific BlueScreen object at a specific index, you can call the `GetAt` method with 1 argument, which is the index
* Resetting an entire template can be done by calling the `ResetTemplate` method with 1 argument, which is the index
* Resetting all settings under the additional options menu can be done by calling the `ResetHacks` method with 1 argument, which is the index
* Removing a specific configuration can be done by calling the `RemoveAt` method with 1 argument, which is the index
* Saving configurations to a file can be done by calling the `SaveData` method with 2 arguments
	* filename is the full path to the saved file (including extension)
	* filterIndex is the file format index (corresponding to the `filters` dictionary)
* Loading configurations from a file can be done by calling the `LoadData` with the file path as the argument
* The total number of configurations can be recieved by getting `Count` on the TemplateRegistry object, e.g.
	```C#
	tr.Count
	```
**Note** : To modify a configuration, you can just get the configuration and make all changes to it, since the object is still the same, because no copying is done, the changes will still get applied.

### Draw routines
Draw routines should be used within every simulator to allow for upscaling and displaying the simulator on multiple monitors. You can create a new DisplayRoutine or use the existing one found in Program.dr (however, you MUST call dispose method after use).

**Note**: To create DrawRoutines, you must import `SimulatorDatabase` namespace.

#### Initialization
You can initialize the global draw routine by doing the following:

```C#
	// ...
	Program.dr.Init(this);
```

If you don't want the form to be hidden and upscaled, please set the value of `native` parameter to true by instead doing the following:

```C#
	Program.dr.Init(this, true);
```


#### Disposal
After using draw routines, in order to avoid potential memory leaks, it is really important to free up used memory and dispose the object. To do this, use the following code:

```C#
   Program.dr.Dispose(); // note: dispose your *own* object if you made one
```


#### Drawing
To update contents of the upscaled window, you can use the Draw method.

```C#
    foreach (WindowScreen ws in Program.dr.wss)
    {
		Program.dr.Draw(ws);
	}
```

We are wrapping the draw routine call inside a foreach loop, because we want to draw every display in case the user more than one.

You may want to add a generic watermark on top of the upscaled image. To do so, you can use the watermark parameter:
```C#
	// displays the upscaled image with a watermark
	Program.dr.Draw(Program.dr.wss.First(), true); 
```

In some cases, the blinking cursor may not be displayed by default on top left. If you want to fix this, you can specify the blinkcolor parameter:

```C#
	// displays the upscaled image with a blinking cursor at the top left
	Program.dr.Draw(Program.dr.wss.First(), me.GetBool("blink") ? me.GetTheme(false) : false);
```

The blink state will invert each time you perform a draw, so you may want to call this inside a timer.

#### Simplified drawing
If you don't care about blinking cursor and overlay watermark, you may consider using the `DrawAll` method instead, since it doesn't require a foreach loop. Example:

```C#
	Program.dr.DrawAll();
```


### File structure

The following section contains quick documentation for each file in the project.

#### Interfaces
* AboutSettingsDialog.cs           - Help, about and settings
* AddBluescreen.cs                 - Allows the user to create their own bluescreen configuration
* ChooseFile.cs                    - Culprit file chooser
* IndexForm.cs                     - Code customization interface
* NewUI.cs                         - Main window interface with new UI
* NTdtor.cs                        - Windows NT file code editor
* metaerror.cs                     - BSSP crash screen
* PrankMode.cs                     - Prank mode interface
* ProgressTuner.cs                 - Progress tuner interface
* StringEdit.cs                    - Blue screen hacks a.k.a. additional options
* TextView.cs                      - Text document viewer
* UpdateInterface.cs               - Interface for update download and installation

#### Legacy interfaces
* Main.cs                          - Old layout
* SupportEditor.cs                 - Windows XP/Vista/7 blue screen support text modification interface (old beta)
* NTBSOD.cs                        - Legacy Windows NT blue screen simulator

#### Load screens
* Gen.cs                           - This form is displayed when generating a blue screen
* Splash.cs                        - Splash screen interface

#### Simulators
* BootMgr.cs                       - Windows Boot Manager startup error simulator
* cebsod.cs                        - Windows CE blue screen simulator
* JupiterBSOD.cs                   - Windows 8 Beta blue screen simulator
* old_bluescreen.cs                - Windows 3.1x/9x/Me blue screen simulator
* vistabs.cs                       - Windows 7 blue screen simulator
* w2kbs.cs                         - Windows NT and 2000 blue screen simulator
* win.cs                           - Windows 1.x/2.x blue screen simulator
* WXBS.cs                          - Modern Windows blue screen simulator
* xvsbs.cs                         - Windows XP/Vista blue screen simulator

#### Special classes
* CLIProcessor.cs                  - A class used for handling command line arguments
* SimulatorDatabase.cs             - A namespace with a blue screen class, which gets used by other parts of the program
* GlobalSettings.cs				   - A class used for storing/manipulating runtime and permanent settings
* Program.cs                       - Program initialization code
* TemplateRegistry.cs			   - Class used for storing/manipulating configuration templates
* Verifile.cs                      - Signature verification system

#### Miscellaneous
* DictEdit.cs                      - [DEVTOOL] Quick and Dirty Dictionary Editor
* WindowScreen.cs                  - This form is displayed when fullscreen flag is set on non-modern blue screens
* BTS.cs                           - Displays character sets used by the application
* ClickIt.cs                       - Classic Click it game easter egg (enable easter eggs in settings)
* ClickIt2.cs                      - Click it 2.0 easter egg (trigger classic and click Play 2.0)
* *.Designer.cs                    - Form interface designs (generated using Visual Studio's designer)
* *.resx                           - Resource identification (auto-generated)

#### Runtime
* default.bscfg                    - Default blue screen hack configuration file
* final.bat                        - Update finalization script

#### Assets
* artage-io-48148_1564916990.ico   - 2D flag icon
* bsodbanner3.png                  - Banner for about dialog
* bsodqr.bmp                       - QR code for Widnows 10 blue screen
* bsodqr_transparent.png           - Transparent QR code for Windows 10 blue screen
* bssp3_icon.ico                   - Blue screen simulator plus icon (version 3)
* CULPRIT_FILES.txt                - Contains culprit files, which the user can choose to display on the error screen
* current.gif                      - Symbol for currently processing step in update interface
* current1.gif                     - Same as current.gif [*Unused*]
* doscii.png                       - Character set used by Windows 1.x/2.x blue screen simulator
* dummy.png                        - Dummy image for Windows 1.x/2.x blue screen simulator
* failure.gif                      - Symbol for failed step in update interface
* legacy_template.txt			   - Legacy configuration file template
* msoftware.png                    - Markus' software logo for about dialog
* NTERRORDATABASE.txt              - Contains all Windows NT error codes with their descriptions (code   description)
* pending.gif                      - Symbol for pending step in update interface
* rasterNT.bmp                     - Windows NT blue screen character set
* rasters.bmp                      - Old character set for old blue screens [*Unused*]
* rasters2.bmp                     - CGA character set for old blue screens
* round_corners.png                - Round corners that get displayed on the new splash screen
* success.bmp                      - Symbol for successfully complited step in update interface
* untitled.wav                     - Beep sound
* verifile.bmp                     - Verifile logo for about dialog
* win1splash.bmp                   - Windows 1.01 startup logo (B&W)
* win2splash.bmp                   - Windows 2.03 startup logo (B&W)

#### Properties
* AssemblyInfo.cs                  - Assembly information for the application (e.g. title, company, version, etc) (auto-generated)
* Resources.resx                   - Resource identification (auto-generated)
* Settings.settings                - Settings [*Unused*] (auto-generated)

#### Custom controls
* AliasedLabel.cs                  - A custom control that is used in Windows XP and CE blue screens
* SizableMaterialButton.cs         - An experimental custom control which combines MaterialButton and MaterialLabel

### Verifile

Verifile 1.2 is a system to prevent the program from being used by malicious actors without user's consent. You can perform a verifile attestation by creating the verifile object and recieving value of Verify getter.

```C#
	Verifile vf = new Verifile();
	bool status = vf.Verify;
	if (status) {
		// Verified
	} else {
		// Failed
	}
```

**Warning**: Each Verifile attestation takes processing time. Please consider carefully whether or not you need to run the verification.

Global Verifile state is stored as Program.verificate, but note that this value can be easily tampered and as such isn't a secure method of verification.
