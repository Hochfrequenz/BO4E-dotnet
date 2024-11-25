using System.Text;
using BO4E.BO;
using Newtonsoft.Json.Schema;
using NJsonSchema;
using NJsonSchema.Generation;
using JsonSchema = NJsonSchema.JsonSchema;

Console.WriteLine("Starting schema generation process...");

int offset;
string jsonOutputDirectory;
string openApiOutputDirectory;

// Validate arguments
if (args.Length < 3)
{
    Console.Error.WriteLine(
        "Error: You must provide an offset, a JSON output directory, and an OpenAPI output directory."
    );
    Console.Error.WriteLine(
        "Usage: dotnet run -- <offset> <jsonOutputDirectory> <openApiOutputDirectory>"
    );
    Environment.Exit(1); // Exit with a specific error code for missing arguments
}

if (!int.TryParse(args[0], out offset))
{
    Console.Error.WriteLine(
        $"Error: Invalid argument '{args[0]}'. Please provide a valid integer offset."
    );
    Environment.Exit(2); // Exit with a specific error code for invalid offset
}

// Get the output directories from the arguments
jsonOutputDirectory = args[1];
openApiOutputDirectory = args[2];

Console.WriteLine($"Offset provided: {offset}");
Console.WriteLine($"JSON Output directory: {jsonOutputDirectory}");
Console.WriteLine($"OpenAPI Output directory: {openApiOutputDirectory}");

// Generate schemas
try
{
    JsonSchemaGenerator.GenerateSchemas(offset, jsonOutputDirectory);
    JsonSchemaGenerator.GenerateOpenApiSchemas(offset, openApiOutputDirectory);
    Console.WriteLine("Schema generation completed successfully.");
}
catch (Exception ex)
{
    Console.Error.WriteLine($"An unexpected error occurred: {ex.Message}");
    Environment.Exit(4); // Exit with a specific error code for unexpected errors
}

Environment.Exit(0); // Success

/// <summary>
/// Generates plain JSON and OpenAPI schemas from business object model classes.
/// </summary>
public class JsonSchemaGenerator
{
    private const int LastDataRowOffset = 50;
    private const int MaxSchemasPerHour = 10;

    public static void GenerateSchemas(int offset, string jsonOutputDirectory)
    {
        var relevantBusinessObjectTypes = typeof(BusinessObject)
            .Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(BusinessObject)));

        if (relevantBusinessObjectTypes.Count() > LastDataRowOffset + MaxSchemasPerHour)
        {
            throw new InvalidOperationException(
                "Too many BusinessObject types. Increase the LastDataRowOffset or adjust the MaxSchemasPerHour."
            );
        }

        try
        {
            // Ensure the output directory exists
            if (!Directory.Exists(jsonOutputDirectory))
            {
                Directory.CreateDirectory(jsonOutputDirectory);
            }

            foreach (var type in relevantBusinessObjectTypes.Skip(offset).Take(MaxSchemasPerHour))
            {
                var schema = BusinessObject.GetJsonSchema(type);
                var path = Path.Combine(jsonOutputDirectory, $"{type.Name}.json");

                Console.WriteLine($"Generating JSON schema for {type.Name} at {path}.");

                if (!File.Exists(path))
                {
                    using (File.Create(path)) { }
                }

                var utf8WithoutByteOrderMark = new UTF8Encoding(false);
                File.WriteAllText(
                    path,
                    schema.ToString(SchemaVersion.Draft7),
                    utf8WithoutByteOrderMark
                );
            }
        }
        catch (JSchemaException jse)
        {
            Console.Error.WriteLine($"JSON schema generation failed with error: {jse.Message}");
            Environment.Exit(3); // Exit with a specific error code for schema generation failure
        }
    }

    public static void GenerateOpenApiSchemas(int offset, string openApiOutputDirectory)
    {
        var relevantBusinessObjectTypes = typeof(BusinessObject)
            .Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(BusinessObject)));

        try
        {
            // Ensure the output directory exists
            if (!Directory.Exists(openApiOutputDirectory))
            {
                Directory.CreateDirectory(openApiOutputDirectory);
            }

            foreach (var type in relevantBusinessObjectTypes.Skip(offset))
            {
                var schema = JsonSchema.FromType(
                    type,
                    new SystemTextJsonSchemaGeneratorSettings() { SchemaType = SchemaType.OpenApi3 }
                );
                var path = Path.Combine(openApiOutputDirectory, $"{type.Name}.json");

                Console.WriteLine($"Generating OpenAPI schema for {type.Name} at {path}.");

                if (!File.Exists(path))
                {
                    using (File.Create(path)) { }
                }

                var utf8WithoutByteOrderMark = new UTF8Encoding(false);
                File.WriteAllText(path, schema.ToJson(), utf8WithoutByteOrderMark);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"OpenAPI schema generation failed with error: {ex.Message}");
            Environment.Exit(3); // Exit with a specific error code for schema generation failure
        }
    }
}
