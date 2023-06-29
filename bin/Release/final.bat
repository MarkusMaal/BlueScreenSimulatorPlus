@echo off
:del_loop
del BSOD.exe
del vercheck.txt
del hash.txt
del UltimateBlueScreenSimulator.exe
if exist BSOD.exe goto del_loop
if exist vercheck.txt goto del_loop
if exist hash.txt goto del_loop
del finish.bat&start "" "Blue screen simulator plus.exe" /doneupdate