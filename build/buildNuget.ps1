param(
    [string]$Version = "1.0.0-alpha.11"
)

$year = [System.DateTime]::Now.ToString("yyyy")
$copyright = "Copyright Dev2Be © 2018 - $year"
$configuration = "Release"
$releaseNotes = "Ajout : Lecture des informations d'une assembly."

function New-Nuget {
    param (
        [string]$NuSpecPath,
        [string]$Version
    )

    $NuSpecPath = Resolve-Path $NuSpecPath
    nuget pack "$NuSpecPath" -version "$Version" -Properties "Configuration=$configuration;Copyright=$copyright;ReleaseNotes=$releaseNotes"
}

Push-Location "$(Join-Path $PSScriptRoot "..")"

New-Nuget .\.nuget\Dev2Be.Toolkit.nuspec $Version

Pop-Location

