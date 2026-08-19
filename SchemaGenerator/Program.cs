using System.Text;
using BO4E.BO;
using Newtonsoft.Json.Schema;
using NJsonSchema;
using NJsonSchema.Generation;
using JsonSchema = NJsonSchema.JsonSchema;

// The number of business objects determines how many batches a caller has to run
// (see the remarks on MaxSchemasPerHour below). Print the number in a machine readable way,
// so that calling scripts do not have to hardcode - and silently outdate - it.
if (args.Length == 1 && args[0] == "--count")
{
    Console.WriteLine(
        $"BUSINESS_OBJECT_COUNT={JsonSchemaGenerator.GetRelevantBusinessObjectTypes().Count()}"
    );
    // the batch size is defined here and must not be duplicated in the calling scripts
    Console.WriteLine($"BATCH_SIZE={JsonSchemaGenerator.MaxSchemasPerHour}");
    Environment.Exit(0);
}

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
    /// <summary>
    ///     The free license of Newtonsoft.Json.Schema only allows a limited number of schemas to be
    ///     generated per process. Callers therefore have to invoke this application repeatedly with
    ///     increasing offsets (a fresh process each time) to generate schemas for all business objects.
    ///     Use --count to read this value instead of duplicating it.
    /// </summary>
    public const int MaxSchemasPerHour = 10;

    /// <summary>
    ///     All types for which schemas are generated: everything derived from <see cref="BusinessObject" />.
    ///     The order is explicit, because the offsets of the separate generator processes only address
    ///     the same types if every process sees the same order (Assembly.GetTypes() does not guarantee one).
    /// </summary>
    public static IEnumerable<Type> GetRelevantBusinessObjectTypes()
    {
        return typeof(BusinessObject)
            .Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(BusinessObject)))
            .OrderBy(t => t.FullName, StringComparer.Ordinal);
    }

    public static void GenerateSchemas(int offset, string jsonOutputDirectory)
    {
        var relevantBusinessObjectTypes = GetRelevantBusinessObjectTypes();

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
        var relevantBusinessObjectTypes = GetRelevantBusinessObjectTypes();

        try
        {
            // Ensure the output directory exists
            if (!Directory.Exists(openApiOutputDirectory))
            {
                Directory.CreateDirectory(openApiOutputDirectory);
            }

            foreach (var type in relevantBusinessObjectTypes.Skip(offset).Take(MaxSchemasPerHour))
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
