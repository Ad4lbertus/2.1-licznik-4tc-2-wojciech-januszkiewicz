@echo off
if not exist "%~dp0LicznikKlikniec.exe" (
    call "%~dp0build.bat"
)
start "" "%~dp0LicznikKlikniec.exe"
