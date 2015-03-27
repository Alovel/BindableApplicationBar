set PATH=%PATH%;C:\Windows\Microsoft.NET\Framework\v4.0.30319

if "%1"=="nobuild" (@GOTO CREATE_FOLDER_STRUCTURE)

set VisualStudioVersion=12.0
msbuild /verbosity:quiet /fl /t:Rebuild /p:Configuration=Release "..\BindableApplicationBar\BindableApplicationBar.csproj" || GOTO :REPORT_ERROR

:CREATE_FOLDER_STRUCTURE
@rem Base folder structure
rd /Q /S lib
rd /Q /S tools
rd /Q /S content

mkdir lib
mkdir tools
mkdir content
mkdir content\controllers

set NUGET_PLATFORM=wp8
@CALL :COPY_FILES || GOTO :REPORT_ERROR

@GOTO :PACK_FILES

:COPY_FILES
mkdir "lib\%NUGET_PLATFORM%\BindableApplicationBar"

copy "..\BindableApplicationBar\bin\Release\BindableApplicationBar.*" "lib\%NUGET_PLATFORM%" || GOTO :REPORT_ERROR
@GOTO :EOF

:PACK_FILES
@echo Packing NuGets
nuget pack "BindableApplicationBar.nuspec"
@GOTO :EOF

:REPORT_ERROR
@ECHO Error, see the last command executed.
pause