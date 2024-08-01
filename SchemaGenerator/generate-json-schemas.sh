# ----------------------------------------------------------------------------
# generate-schemas.sh
# Cross-platform script to run the .NET console application for schema generation.
# Generates both JSON and OpenAPI schemas for business objects with specified offsets.
#
# Usage:
#   powershell.exe C:/github/BO4E-dotnet2/SchemaGenerator/generate-json-schemas.sh [jsonOutputDirectory] [openApiOutputDirectory]
#
# Arguments:
#   jsonOutputDirectory (optional)   - Directory to output JSON schema files. Defaults to ../json-schema-files.
#   openApiOutputDirectory (optional) - Directory to output OpenAPI schema files. Defaults to ../open-api-schemas.
#
# Example:
#   powershell.exe C:/github/BO4E-dotnet2/SchemaGenerator/generate-json-schemas.sh ../json-schema ../openapi-schema
#
# ----------------------------------------------------------------------------

# Define the offsets
offsets=(10 20 30 40 50)

# Define the default output directories
default_json_output_directory="../json-schema-files" # json-schema-files in repo root
default_openapi_output_directory="../open-api-schemas" # open-api-schemas in repo root

# Display usage information if no arguments are provided or if there's an error in the arguments
usage() {
  echo "Usage: $0 [jsonOutputDirectory] [openApiOutputDirectory]"
  echo "  jsonOutputDirectory       Directory to output JSON schema files. Default: $default_json_output_directory"
  echo "  openApiOutputDirectory    Directory to output OpenAPI schema files. Default: $default_openapi_output_directory"
  echo ""
  echo "Example:"
  echo "  $0 ../json-schema ../openapi-schema"
}

# Check if output directory arguments are provided and set directories
if [ $# -gt 2 ]; then
  echo "Error: Too many arguments."
  usage
  exit 1
fi

json_output_directory=${1:-$default_json_output_directory}
openapi_output_directory=${2:-$default_openapi_output_directory}

# Ensure that output directories are valid and accessible
if [ ! -d "$json_output_directory" ]; then
  echo "Error: JSON output directory '$json_output_directory' does not exist or is not accessible."
  usage
  exit 1
fi

if [ ! -d "$openapi_output_directory" ]; then
  echo "Error: OpenAPI output directory '$openapi_output_directory' does not exist or is not accessible."
  usage
  exit 1
fi

# Define the project path
project_path="C:/github/BO4E-dotnet2/SchemaGenerator/SchemaGenerator.csproj"

# Check if the project path exists
if [ ! -f "$project_path" ]; then
  echo "Error: Project file not found at '$project_path'. Ensure the project path is correct."
  exit 1
fi

# Loop through the offsets and call the .NET application
for offset in "${offsets[@]}"
do
  echo "Running schema generation with offset: $offset"
  echo "JSON output directory: $json_output_directory"
  echo "OpenAPI output directory: $openapi_output_directory"
  # Run the .NET application with the project path
  dotnet run --project "$project_path" -- $offset $json_output_directory $openapi_output_directory
done

# Check if Prettier is installed and format the output files
if command -v prettier &> /dev/null
then
  echo "Prettier is installed. Formatting output files..."
  prettier -w "$json_output_directory/*.json"
  prettier -w "$openapi_output_directory/*.json"
  echo "Formatting complete."
else
  echo "Prettier is not installed. Skipping formatting."
fi

# Keep the window open
read -p "Press any key to exit..."
