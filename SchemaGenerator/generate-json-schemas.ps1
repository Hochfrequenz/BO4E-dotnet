# ----------------------------------------------------------------------------
# generate-schemas.ps1
# Cross-platform script to run the .NET console application for schema generation.
# Generates both JSON and OpenAPI schemas for business objects with specified offsets.
#
# Usage:
#   powershell.exe -ExecutionPolicy Bypass -File ".\generate-json-schemas.ps1" [jsonOutputDirectory] [openApiOutputDirectory]
#
# Arguments:
#   jsonOutputDirectory (optional)   - Directory to output JSON schema files. Defaults to ../json-schema-files.
#   openApiOutputDirectory (optional) - Directory to output OpenAPI schema files. Defaults to ../open-api-schemas.
#
# Example:
#   .\generate-schemas.ps1 ../json-schema ../openapi-schema
#
# ----------------------------------------------------------------------------

# Define the offsets
$offsets = @(10, 20, 30, 40, 50)

# Define the default output directories
$default_json_output_directory = "../json-schema-files" # json-schema-files in repo root
$default_openapi_output_directory = "../open-api-schemas" # open-api-schemas in repo root

# Display usage information if no arguments are provided or if there's an error in the arguments
function usage {
    Write-Host "Usage: .\generate-schemas.ps1 [jsonOutputDirectory] [openApiOutputDirectory]"
    Write-Host "  jsonOutputDirectory       Directory to output JSON schema files. Default: $default_json_output_directory"
    Write-Host "  openApiOutputDirectory    Directory to output OpenAPI schema files. Default: $default_openapi_output_directory"
    Write-Host ""
    Write-Host "Example:"
    Write-Host "  .\generate-schemas.ps1 ../json-schema ../openapi-schema"
}

# Check if output directory arguments are provided and set directories
if ($args.Count -gt 2) {
    Write-Host "Error: Too many arguments."
    usage
    exit 1
}

$json_output_directory = if ($args.Count -ge 1) { $args[0] } else { $default_json_output_directory }
$openapi_output_directory = if ($args.Count -ge 2) { $args[1] } else { $default_openapi_output_directory }

# Ensure that output directories are valid and accessible
if (-not (Test-Path $json_output_directory -PathType Container)) {
    Write-Host "Error: JSON output directory '$json_output_directory' does not exist or is not accessible."
    usage
    exit 1
}

if (-not (Test-Path $openapi_output_directory -PathType Container)) {
    Write-Host "Error: OpenAPI output directory '$openapi_output_directory' does not exist or is not accessible."
    usage
    exit 1
}

# Define the project path
$project_path = "C:/github/BO4E-dotnet/SchemaGenerator/SchemaGenerator.csproj"

# Check if the project path exists
if (-not (Test-Path $project_path)) {
    Write-Host "Error: Project file not found at '$project_path'. Ensure the project path is correct."
    exit 1
}

# Loop through the offsets and call the .NET application
foreach ($offset in $offsets) {
    Write-Host "Running schema generation with offset: $offset"
    Write-Host "JSON output directory: $json_output_directory"
    Write-Host "OpenAPI output directory: $openapi_output_directory"
    # Run the .NET application with the project path
    dotnet run --project "$project_path" -- $offset $json_output_directory $openapi_output_directory
}

# Check if Prettier is installed and format the output files
if (Get-Command prettier -ErrorAction SilentlyContinue) {
    Write-Host "Prettier is installed. Formatting output files..."
    prettier -w "$json_output_directory/*.json"
    prettier -w "$openapi_output_directory/*.json"
    Write-Host "Formatting complete."
} else {
    Write-Host "Prettier is not installed. Skipping formatting."
}

# Keep the window open
Read-Host "Press any key to exit..."
