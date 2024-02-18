@echo off

set TargetDir=%1
set SolutionDir=%2
set ReferencePath=%3

set SrcModDir=%SolutionDir%\GameData\Reviva
set DstModDir=%ReferencePath%\GameData\Reviva
set DLL=Reviva.dll

echo.
echo - TargetDir: %TargetDir%
echo - SolutionDir: %SolutionDir%
echo - ReferencePath: %ReferencePath%
echo - DLL: %DLL%
echo - SrcModDir: %SrcModDir%
echo - DstModDir: %DstModDir%
echo.

echo Updating %DLL% in repository ...

set TargetDLL=%TargetDir%\%DLL%
set RepoDLL=%SrcModDir%\%DLL%

@echo on
copy /Y %TargetDLL% %RepoDLL%
@echo off

echo.
echo Updating Reviva in KSP game directory ...
echo.

if exist %DstModDir% (
   echo %DstModDir% exsts, removing...
   echo rd /S /Q %DstModDir%
   rd /S /Q %DstModDir%
   
)

@echo on
xcopy /F /S /Y /I %SrcModDir% %DstModDir%\
@echo off

echo.
