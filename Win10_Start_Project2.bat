@ECHO OFF
SET currentDirectory=%~dp0
SET backend=%currentDirectory%Backend
cd /d %backend%
START dotnet run
SET frontend=%currentDirectory%Frontend
cd /d %frontend%
START npm run setup
EXIT