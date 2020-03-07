param(
    [string]$Version
)

$year = [System.DateTime]::Now.ToString("yyyy")
$copyright = "Copyright Dev2Be © 2018 - $year"
$configuration = "Release"
$releaseNotes = "https://github.com/Dev2Be/Dev2Be.Toolkit/blob/master/src/Dev2Be.Toolkit/fr-FR/changelog.txt"

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

