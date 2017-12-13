Import-Module ([System.IO.Path]::Combine("$env:USERPROFILE\Documents\gdata-client-library-bridge","DiscoveryDocGenerator.psm1"))

$ScriptPath = "$env:USERPROFILE\Documents\apis-client-generator\src\googleapis\codegen\generate_library.py"

$PythonPath = "$env:USERPROFILE\Documents\apis-client-generator\src"

$Language = "csharp"

function Generate-GshellLibraries ($OutputName, $ApiName, $Version, $OutputPath = "Documents\gShell\gShell\gShell\dotNet", $Variant = "gshell", $JsonPath = "z") {

    $Output = [System.IO.Path]::Combine("$env:USERPROFILE", $OutputPath, $OutputName)

    if ($JsonPath -eq "") {
        $InputPath = "$env:USERPROFILE\Documents\gShell\gShell\gShell\GeneratorFiles\" + $ApiName + "_" + $Version + ".json"
    } else {
        $InputPath = $JsonPath
    }

    if (Test-Path $InputPath){

        Write-Host ("Found file " + $ApiName + "_" + $Version + ".json, processing") -ForegroundColor Green

        Run-PythonGenerator -PythonScriptPath $ScriptPath -PythonSourcePath $PythonPath `
            -OutputDirPath $Output -Language $Language -LanguageVariant $Variant `
            -InputFilePath $InputPath

    } else {

        Write-Host ("File not found, processing " + $ApiName + "_" + $Version + " from the Discovery API") -ForegroundColor Yellow

        Run-PythonGenerator -PythonScriptPath $ScriptPath -PythonSourcePath $PythonPath `
            -OutputDirPath $Output -Language $Language -LanguageVariant $Variant `
            -ApiName $ApiName -ApiVersion $Version
    
    }

}

Generate-GshellLibraries "Discovery" "discovery" "v1"

Generate-GshellLibraries "Discovery" "discovery" "v1" -Variant "posh" -OutputPath "Documents\gShell\gShell\gShell\Cmdlets"

Generate-GshellLibraries "GroupsSettings" "groupssettings" "v1"

Generate-GshellLibraries "GroupsSettings" "groupssettings" "v1" -Variant "posh" -OutputPath "Documents\gShell\gShell\gShell\Cmdlets"

Generate-GshellLibraries "Directory" "admin" "directory_v1"

Generate-GshellLibraries "Directory" "admin" "directory_v1"  -Variant "posh" -OutputPath "Documents\gShell\gShell\gShell\Cmdlets"

Generate-GshellLibraries "Reports" "admin" "reports_v1"

Generate-GshellLibraries "DataTransfer" "admin" "datatransfer_v1"

Generate-GshellLibraries "DataTransfer" "admin" "datatransfer_v1" -Variant "posh" -OutputPath "Documents\gShell\gShell\gShell\Cmdlets"

Generate-GshellLibraries "GroupsMigration" "groupsmigration" "v1"

Generate-GshellLibraries "GroupsMigration" "groupsmigration" "v1"  -Variant "posh" -OutputPath "Documents\gShell\gShell\gShell\Cmdlets"

Generate-GshellLibraries "Licensing" "licensing" "v1"

Generate-GshellLibraries "Licensing" "licensing" "v1" -Variant "posh" -OutputPath "Documents\gShell\gShell\gShell\Cmdlets"

Generate-GshellLibraries "Reseller" "reseller" "v1"

Generate-GshellLibraries "Reseller" "reseller" "v1" -Variant "posh" -OutputPath "Documents\gShell\gShell\gShell\Cmdlets"

Generate-GshellLibraries "Drive" "drive" "v3"

Generate-GshellLibraries "Drive" "drive" "v3" -Variant "posh" -OutputPath "Documents\gShell\gShell\gShell\Cmdlets"

Generate-GshellLibraries "Gmail" "gmail" "v1"

Generate-GshellLibraries "Gmail" "gmail" "v1" -Variant "posh" -OutputPath "Documents\gShell\gShell\gShell\Cmdlets"

Generate-GshellLibraries "Calendar" "calendar" "v3"

Generate-GshellLibraries "Calendar" "calendar" "v3" -Variant "posh" -OutputPath "Documents\gShell\gShell\gShell\Cmdlets"

Generate-GshellLibraries "Classroom" "classroom" "v1"

Generate-GshellLibraries "Classroom" "classroom" "v1" -Variant "posh" -OutputPath "Documents\gShell\gShell\gShell\Cmdlets"

Generate-GshellLibraries "Adminsettings" "admin" "adminsettings_v1" `
    -JsonPath "$env:USERPROFILE\Documents\gdata-client-library-bridge\AdminSettings\admin_adminsettings_v1.json"

Generate-GshellLibraries "Emailsettings" "admin" "emailsettings_v1" `
    -JsonPath "$env:USERPROFILE\Documents\gdata-client-library-bridge\EmailSettings\admin_emailsettings_v1.json"

Generate-GshellLibraries "SharedContacts" "admin" "sharedcontacts_v3" `
    -JsonPath "C:\Users\svarney\Documents\gdata-client-library-bridge\SharedContacts\admin_sharedcontacts_v3.json"