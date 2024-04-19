# BlueScreenSimulatorPlus (experimental branch)
Open source code for BSSP. This is an enhanced blue screen simulator application for Windows. Use Visual Studio to recompile.<br/>
<br/>
Codename: *Waffles*, Version 2.13, {} markus' software // {} markuse tarkvara<br/>
<br/>
The following section contains quick documentation for each file in the project.<br/>
<br/>
[ROOT]<br/>
	* AboutBox1.cs                     - Help, about and settings<br/>
	* AddBluescreen.cs                 - Allows the user to create their own bluescreen configuration<br/>
	* BootMgr.cs                       - Windows Boot Manager startup error simulator (Beta)<br/>
	* bsodhacks.cs                     - Bluescreen hacks (old beta) [*Unused*]<br/>
	* cebsod.cs                        - Windows CE blue screen simulator<br/>
	* ChooseFile.cs                    - Culprit file chooser<br/>
	* ClickIt.cs                       - Classic Click it game easter egg (enable easter eggs in settings)<br/>
	* ClickIt2.cs                      - Click it 2.0 easter egg (trigger classic and click Play 2.0)<br/>
	* DictEdit.cs                      - [DEVTOOL] Dictionary Editor<br/>
	* Form1.cs                         - Main interface<br/>
	* Gen.cs                           - This form is displayed when generating a blue screen<br/>
	* IndexForm.cs                     - Code customization interface<br/>
	* NTBSOD.cs                        - Windows NT blue screen simulator<br/>
	* old_bluescreen.cs                - Windows 3.1x/9x/Me blue screen simulator<br/>
	* PrankMode.cs                     - Prank mode interface<br/>
	* SimulatorDatabase.cs             - A namespace with a blue screen class, which gets used by other parts of the program<br/>
	* Splash.cs                        - Splash screen interface<br/>
	* StringEdit.cs                    - Blue screen hacks (new)<br/>
	* SupportEditor.cs                 - Windows XP/Vista/7 blue screen support text modification interface (old beta)<br/>
	* UpdateInterface.cs               - Interface for update download and installation<br/>
	* w2kbs.cs                         - Windows 2000 blue screen simulator<br/>
	* win.cs                           - Windows 1.x/2.x blue screen simulator<br/>
	* WindowScreen.cs                  - This form is displayed when fullscreen flag is set on non-modern blue screens<br/>
	* WXBS.cs                          - Modern Windows blue screen simulator<br/>
	* Vistabs.cs                       - Windows Vista/7 blue screen simulator<br/>
	* xvsbs.cs                         - Windows XP blue screen simulator<br/>
	* *.Designer.cs                    - Form interface designs (generated using Visual Studio's designer)<br/>
	* *.resx                           - Resource identification (auto-generated)<br/>
	* app.config                       - Application configuration [*Unused*]<br/>
	* bsodgen_npJ_icon.ico             - Blue screen simulator plus icon<br/>
	* Program.cs                       - Program initialization code<br/>
	<br/>
bin\Release<br/>
	* default.bscfg                    - Default blue screen hack configuration file<br/>
	* final.bat                        - Update finalization script<br/>
	* UltimateBlueScreenSimulator.exe  - Compiled executable<br/>
	* UltimateBlueScreenSimulator.pdb  - Program debug database (contains essential things for debugging purposes, such as variable names, break points, etc)<br/>
	<br/>
 Resources<br/>
	 * bsodbanner.png                   - Banner for about dialog<br/>
	 * bsodqr.bmp                       - QR code for Widnows 10 blue screen<br/>
	 * bsodqr_transparent.png           - Transparent QR code for Windows 10 blue screen<br/>
	 * CULPRIT_FILES.txt                - Contains culprit files, which the user can choose to display on the error screen<br/>
	 * current.gif                      - Symbol for currently processing step in update interface<br/>
	 * current1.gif                     - Same as current.gif [*Unused*]<br/>
	 * doscii.png                       - Character set used by Windows 1.x/2.x blue screen simulator<br/>
	 * dummy.png                        - Dummy image for Windows 1.x/2.x blue screen simulator<br/>
	 * failure.gif                      - Symbol for failed step in update interface<br/>
	 * msoftware.png                    - Markus' software logo for about dialog<br/>
	 * NTERRORDATABASE.txt              - Contains all Windows NT error codes with their descriptions (code   description)<br/>
	 * pending.gif                      - Symbol for pending step in update interface<br/>
	 * rasterNT.bmp                     - Windows NT blue screen character set<br/>
	 * rasters.bmp                      - Old character set for old blue screens [*Unused*]<br/>
	 * rasters2.bmp                     - CGA character set for old blue screens<br/>
	 * round_corners.png                - Round corners that get displayed on the new splash screen<br/>
	 * success.bmp                      - Symbol for successfully complited step in update interface<br/>
	 * untitled.wav                     - Beep sound<br/>
	 * verifile.bmp                     - Verifile logo for about dialog<br/>
	 * win1splash.bmp                   - Windows 1.01 startup logo (B&W)<br/>
	 * win2splash.bmp                   - Windows 2.03 startup logo (B&W)<br/>
 <br/>
 Properties<br/>
	 * AssemblyInfo.cs                  - Assembly information for the application (e.g. title, company, version, etc) (auto-generated)<br/>
	 * Resources.resx                   - Resource identification (auto-generated)<br/>
	 * Settings.settings                - Settings [*Unused*] (auto-generated)<br/>
	 <br/>
System\Windows\Forms<br/>
	 * AliasedLabel.cs                  - A custom control that is used in Windows XP and CE blue screens<br/>
<br/>