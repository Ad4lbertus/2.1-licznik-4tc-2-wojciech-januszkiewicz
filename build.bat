@echo off
chcp 65001 >nul
echo ========================================================
echo  Kompilacja aplikacji desktopowej: LicznikKlikniec.exe
echo  Klasa: 4TC-2 | Autor: Wojciech Januszkiewicz
echo ========================================================
echo.

set CSC=C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe

if not exist "%CSC%" (
    echo Blad: Nie znaleziono kompilatora csc.exe w sciezce %CSC%
    pause
    exit /b 1
)

echo Kompilowanie Program.cs -> LicznikKlikniec.exe...
"%CSC%" /target:winexe /out:LicznikKlikniec.exe Program.cs

if %ERRORLEVEL% EQU 0 (
    echo.
    echo [SUKCES] Aplikacja skompilowana pomyslnie!
    echo Mozesz ja uruchomic dwuklikiem na plik LicznikKlikniec.exe lub przez run.bat.
) else (
    echo.
    echo [BLAD] Wystapil problem podczas kompilacji.
)
echo.
pause
