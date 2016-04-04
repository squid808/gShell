Import-Module ([System.IO.Path]::Combine("$env:USERPROFILE\Documents\gdata-client-library-bridge","DiscoveryDocGenerator.psm1"))

$ScriptPath = "$env:USERPROFILE\Documents\apis-client-generator\src\googleapis\codegen\generate_library.py"

$PythonPath = "$env:USERPROFILE\Documents\apis-client-generator\src"

$Language = "csharp"

$Variant = "gshell"

$Output = "$env:USERPROFILE\Documents\gShell\gShell\gShell\dotNet\GroupsSettings"

Run-PythonGenerator -PythonScriptPath $ScriptPath -PythonSourcePath $PythonPath `
    -OutputDirPath $Output -Language $Language -LanguageVariant $Variant `
    -ApiName groupssettings -ApiVersion v1

$Output = "$env:USERPROFILE\Documents\gShell\gShell\gShell\dotNet\Directory"

Run-PythonGenerator -PythonScriptPath $ScriptPath -PythonSourcePath $PythonPath `
    -OutputDirPath $Output -Language $Language -LanguageVariant $Variant `
    -ApiName admin -ApiVersion directory_v1

$Output = "$env:USERPROFILE\Documents\gShell\gShell\gShell\dotNet\Reports"

Run-PythonGenerator -PythonScriptPath $ScriptPath -PythonSourcePath $PythonPath `
    -OutputDirPath $Output -Language $Language -LanguageVariant $Variant `
    -ApiName admin -ApiVersion reports_v1

$Output = "$env:USERPROFILE\Documents\gShell\gShell\gShell\dotNet\DataTransfer"

Run-PythonGenerator -PythonScriptPath $ScriptPath -PythonSourcePath $PythonPath `
    -OutputDirPath $Output -Language $Language -LanguageVariant $Variant `
    -ApiName admin -ApiVersion datatransfer_v1

$Output = "$env:USERPROFILE\Documents\gShell\gShell\gShell\dotNet\GroupsMigration"

Run-PythonGenerator -PythonScriptPath $ScriptPath -PythonSourcePath $PythonPath `
    -OutputDirPath $Output -Language $Language -LanguageVariant $Variant `
    -ApiName groupsmigration -ApiVersion v1

$Output = "$env:USERPROFILE\Documents\gShell\gShell\gShell\dotNet\Drive"

Run-PythonGenerator -PythonScriptPath $ScriptPath -PythonSourcePath $PythonPath `
    -OutputDirPath $Output -Language $Language -LanguageVariant $Variant `
    -ApiName drive -ApiVersion v3

$Output = "$env:USERPROFILE\Documents\gShell\gShell\gShell\dotNet\Gmail"

Run-PythonGenerator -PythonScriptPath $ScriptPath -PythonSourcePath $PythonPath `
    -OutputDirPath $Output -Language $Language -LanguageVariant $Variant `
    -ApiName gmail -ApiVersion v1