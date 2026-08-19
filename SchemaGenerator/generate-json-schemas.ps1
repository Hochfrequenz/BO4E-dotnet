# ----------------------------------------------------------------------------
# generate-json-schemas.ps1
# Runs the .NET console application for schema generation.
# Generates both JSON and OpenAPI schemas for all business objects.
#
# Usage:
#   powershell.exe -ExecutionPolicy Bypass -File ".\generate-json-schemas.ps1" [jsonOutputDirectory] [openApiOutputDirectory]
#
# Arguments:
#   jsonOutputDirectory (optional)    - Directory to output JSON schema files. Defaults to ../json-schema-files.
#   openApiOutputDirectory (optional) - Directory to output OpenAPI schema files. Defaults to ../open-api-schemas.
#
# Example:
#   .\generate-json-schemas.ps1 ../json-schema ../openapi-schema
#
# This is the Windows counterpart of generate-json-schemas.sh; keep both in sync.
# ----------------------------------------------------------------------------
$ErrorActionPreference = "Stop"

$script_directory = $PSScriptRoot
$project_path = Join-Path $script_directory "SchemaGenerator.csproj"

function usage {
    Write-Host "Usage: .\generate-json-schemas.ps1 [jsonOutputDirectory] [openApiOutputDirectory]"
    Write-Host "  jsonOutputDirectory       Directory to output JSON schema files. Default: <repo root>/json-schema-files"
    Write-Host "  openApiOutputDirectory    Directory to output OpenAPI schema files. Default: <repo root>/open-api-schemas"
    Write-Host ""
    Write-Host "Example:"
    Write-Host "  .\generate-json-schemas.ps1 ../json-schema ../openapi-schema"
}

if ($args.Count -gt 2) {
    Write-Host "Error: Too many arguments."
    usage
    exit 1
}

$json_output_directory = if ($args.Count -ge 1) { $args[0] } else { Join-Path $script_directory "../json-schema-files" }
$openapi_output_directory = if ($args.Count -ge 2) { $args[1] } else { Join-Path $script_directory "../open-api-schemas" }

if (-not (Test-Path $project_path)) {
    Write-Host "Error: Project file not found at '$project_path'."
    exit 1
}

New-Item -ItemType Directory -Force -Path $json_output_directory | Out-Null
New-Item -ItemType Directory -Force -Path $openapi_output_directory | Out-Null

# The free license of Newtonsoft.Json.Schema only allows a limited number of JSON schemas to be
# generated per process. That's why the schemas are generated in batches: one process per batch,
# each with an increasing offset into the list of business objects.
# The batch size must not exceed the MaxSchemasPerHour constant in Program.cs.
$batch_size = 10

# Ask the generator how many business objects there are instead of hardcoding the offsets here.
# Hardcoded offsets used to silently skip business objects whenever new ones were added.
$count_output = dotnet run --project "$project_path" -- --count
$business_object_count = ($count_output | Select-String -Pattern '^BUSINESS_OBJECT_COUNT=(\d+)$').Matches.Groups[1].Value
if (-not $business_object_count) {
    Write-Host "Error: Could not determine the number of business objects."
    exit 1
}
Write-Host "Generating schemas for $business_object_count business objects in batches of $batch_size."

for ($offset = 0; $offset -lt [int]$business_object_count; $offset += $batch_size) {
    Write-Host "Running schema generation with offset: $offset"
    Write-Host "JSON output directory: $json_output_directory"
    Write-Host "OpenAPI output directory: $openapi_output_directory"
    dotnet run --project "$project_path" -- $offset $json_output_directory $openapi_output_directory
}

# Format the generated files so that re-generating unchanged schemas creates no diff.
# The checked in schemas are formatted with prettier 3.
# The .prettierignore in the repository root excludes the generated schemas (so that nobody
# reformats them by accident), hence formatting has to be run with an ignore file that does not
# exist. Without it, prettier would silently skip every file - depending on the current directory.
$prettier_ignore_override = "prettier-ignore-file-that-intentionally-does-not-exist"
$prettier_command = $null
if (Get-Command prettier -ErrorAction SilentlyContinue) {
    $prettier_command = @("prettier")
} elseif (Get-Command npx -ErrorAction SilentlyContinue) {
    $prettier_command = @("npx", "--yes", "prettier@3")
}

if ($prettier_command) {
    Write-Host "Formatting output files with $($prettier_command -join ' ')..."
    & $prettier_command[0] @($prettier_command[1..($prettier_command.Count - 1)]) --ignore-path $prettier_ignore_override -w "$json_output_directory/*.json" "$openapi_output_directory/*.json"
    Write-Host "Formatting complete."
} else {
    Write-Host "Warning: Neither prettier nor npx is available. Skipping formatting."
    Write-Host "The generated files will differ from the checked in (prettier formatted) ones."
}
