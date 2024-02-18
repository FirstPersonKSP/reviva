@echo off

set TargetDir=%1
set SolutionDir=%2
set ModDir=%2\GameData\Reviva
set DLL=Reviva.dll

echo Updating %DLL% in repository
echo.
echo TargetDir: %TargetDir%
echo SolutionDir: %SolutionDir%
echo ModDir: %ModDir%
echo DLL: %DLL%
echo.

set TargetDLL=%TargetDir%\%DLL%
set ModDLL=%ModDir%\%DLL%

echo copy /Y %TargetDLL% %ModDLL%
copy /Y %TargetDLL% %ModDLL%
