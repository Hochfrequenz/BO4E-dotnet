#!/usr/bin/env bash
# ----------------------------------------------------------------------------
# generate-json-schemas.sh
# Runs the .NET console application for schema generation.
# Generates both JSON and OpenAPI schemas for all business objects.
#
# Usage:
#   ./generate-json-schemas.sh [jsonOutputDirectory] [openApiOutputDirectory]
#
# Arguments:
#   jsonOutputDirectory (optional)    - Directory to output JSON schema files. Defaults to ../json-schema-files.
#   openApiOutputDirectory (optional) - Directory to output OpenAPI schema files. Defaults to ../open-api-schemas.
#
# Example:
#   ./generate-json-schemas.sh ../json-schema ../openapi-schema
#
# This script is also used by the "generate_schemas_and_ts_models" GitHub workflow,
# so it must not require any interactive input.
# ----------------------------------------------------------------------------
set -euo pipefail

script_directory="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
project_path="$script_directory/SchemaGenerator.csproj"

usage() {
  echo "Usage: $0 [jsonOutputDirectory] [openApiOutputDirectory]"
  echo "  jsonOutputDirectory       Directory to output JSON schema files. Default: <repo root>/json-schema-files"
  echo "  openApiOutputDirectory    Directory to output OpenAPI schema files. Default: <repo root>/open-api-schemas"
  echo ""
  echo "Example:"
  echo "  $0 ../json-schema ../openapi-schema"
}

if [ $# -gt 2 ]; then
  echo "Error: Too many arguments."
  usage
  exit 1
fi

json_output_directory=${1:-"$script_directory/../json-schema-files"}
openapi_output_directory=${2:-"$script_directory/../open-api-schemas"}

if [ ! -f "$project_path" ]; then
  echo "Error: Project file not found at '$project_path'."
  exit 1
fi

mkdir -p "$json_output_directory" "$openapi_output_directory"

# The free license of Newtonsoft.Json.Schema only allows a limited number of JSON schemas to be
# generated per process. That's why the schemas are generated in batches: one process per batch,
# each with an increasing offset into the list of business objects.
# The batch size must not exceed the MaxSchemasPerHour constant in Program.cs.
batch_size=10

# Ask the generator how many business objects there are instead of hardcoding the offsets here.
# Hardcoded offsets used to silently skip business objects whenever new ones were added.
business_object_count=$(
  dotnet run --project "$project_path" -- --count | sed -n 's/^BUSINESS_OBJECT_COUNT=//p'
)
if [ -z "$business_object_count" ]; then
  echo "Error: Could not determine the number of business objects."
  exit 1
fi
echo "Generating schemas for $business_object_count business objects in batches of $batch_size."

offset=0
while [ "$offset" -lt "$business_object_count" ]; do
  echo "Running schema generation with offset: $offset"
  echo "JSON output directory: $json_output_directory"
  echo "OpenAPI output directory: $openapi_output_directory"
  dotnet run --project "$project_path" -- "$offset" "$json_output_directory" "$openapi_output_directory"
  offset=$((offset + batch_size))
done

# Format the generated files so that re-generating unchanged schemas creates no diff.
# The checked in schemas are formatted with prettier 3.
# The .prettierignore in the repository root excludes the generated schemas (so that nobody
# reformats them by accident), hence formatting has to be run with an ignore file that does not
# exist. Without it, prettier would silently skip every file - depending on the current directory.
prettier_ignore_override="prettier-ignore-file-that-intentionally-does-not-exist"
if command -v prettier &>/dev/null; then
  prettier_command=(prettier)
elif command -v npx &>/dev/null; then
  prettier_command=(npx --yes prettier@3)
else
  prettier_command=()
fi

if [ ${#prettier_command[@]} -gt 0 ]; then
  echo "Formatting output files with ${prettier_command[*]}..."
  "${prettier_command[@]}" --ignore-path "$prettier_ignore_override" -w \
    "$json_output_directory/*.json" "$openapi_output_directory/*.json"
  echo "Formatting complete."
else
  echo "Warning: Neither prettier nor npx is available. Skipping formatting."
  echo "The generated files will differ from the checked in (prettier formatted) ones."
fi
