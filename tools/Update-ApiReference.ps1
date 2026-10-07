param(
    [string] $RepositoryRoot = (Split-Path $PSScriptRoot -Parent)
)

$ErrorActionPreference = 'Stop'
$resolvedRoot = (Resolve-Path -LiteralPath $RepositoryRoot).Path
$temporarySource = Join-Path ([IO.Path]::GetTempPath()) ('windows-api-reference-' + [Guid]::NewGuid().ToString('N') + '.cs')

# Run outside the repository so its central package and product analyzer settings
# do not become dependencies of the standalone documentation tool.
Copy-Item -LiteralPath (Join-Path $resolvedRoot 'tools/generate-api-reference.cs') -Destination $temporarySource
try {
    & dotnet run $temporarySource -- $resolvedRoot
    if ($LASTEXITCODE -ne 0) {
        throw 'API inventory or example compilation failed; README was not replaced.'
    }

    $readmePath = Join-Path $resolvedRoot 'README.md'
    $referencePath = Join-Path $resolvedRoot 'docs/api-reference-generated.md'
    $beginMarker = '<!-- BEGIN GENERATED API REFERENCE -->'
    $endMarker = '<!-- END GENERATED API REFERENCE -->'
    $readme = [IO.File]::ReadAllText($readmePath)
    $reference = [IO.File]::ReadAllText($referencePath).TrimEnd().Replace('(api/', '(docs/api/')
    $beginIndex = $readme.IndexOf($beginMarker, [StringComparison]::Ordinal)
    $endIndex = $readme.IndexOf($endMarker, [StringComparison]::Ordinal)
    $replacement = $beginMarker + "`n" + $reference + "`n" + $endMarker
    if ($beginIndex -lt 0 -and $endIndex -lt 0) {
        $readme = $readme.TrimEnd() + "`n`n" + $replacement + "`n"
    }
    elseif ($beginIndex -ge 0 -and $endIndex -gt $beginIndex) {
        $readme = $readme.Substring(0, $beginIndex) + $replacement + $readme.Substring($endIndex + $endMarker.Length)
    }
    else {
        throw 'README API-reference markers are incomplete or out of order.'
    }

    [IO.File]::WriteAllText($readmePath, $readme, [Text.UTF8Encoding]::new($false))
    Write-Output 'README API reference updated; all generated examples compiled successfully.'
}
finally {
    Remove-Item -LiteralPath $temporarySource
}
