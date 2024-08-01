# Cross-platform script to run the .NET console application with different offsets and an optional output directory
# Invoke it like this:  powershell.exe C:/github/BO4E-dotnet2/SchemaGenerator/generate-json-schemas.sh

# Define the offsets
offsets=(10 20 30 40 50)

# Define the default output directory
default_output_directory="../json-schema-files" # json-schema-files in repo root

# Check if an output directory argument is provided
if [ $# -eq 1 ]; then
  output_directory=$1
else
  output_directory=$default_output_directory
fi

# Loop through the offsets and call the .NET application
for offset in "${offsets[@]}"
do
  echo "Running schema generation with offset: $offset in directory: $output_directory"
  # Run the .NET application
  dotnet run -- $offset $output_directory
done
