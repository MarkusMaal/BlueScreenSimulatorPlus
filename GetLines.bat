@echo off
setlocal EnableExtensions EnableDelayedExpansion
echo Analyzing your project...
dir /b *.cs>files.txt
set "files="
for /f "delims=" %%a in (files.txt) do (
	set o=%%a
	if "!o!"=="!o:.Designer.cs=!" (
		if not "!files!"=="" (
			set "files=!files!, %%a"
		) else (
			set "files=%%a"
		)
		type %%a>>yo.txt
	)
)
del files.txt
set /a IDX=0
set /a IDX2=0
set /a IDX3=0
set /a IDX4=0
for /f "delims=" %%a in (yo.txt) do (
	set o=%%a
	set o=!o:~0,7!
	set /a IDX3+=1
	if "!o!"=="!o://=!" (
		if "!o!"=="!o:/*=!" (
			if "!o!"=="!o: *=!" (
				if "!o!"=="!o:*/=!" (
					set /a IDX2+=1
				) else (
					set /a IDX4+=1
				)
			) else (
				set /a IDX4+=1
		 	)
		) else (
			set /a IDX4+=1
		)
	) else (
		set /a IDX4+=1
	)
)
del yo.txt
cls
echo.
echo This C# project contains...
echo.
echo !IDX3! lines of user written code
echo !IDX2! non-commented lines
echo !IDX4! commented lines
echo.
echo Scanned files:
echo !files!
pause