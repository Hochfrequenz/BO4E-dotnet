using System.Text;
using Newtonsoft.Json.Schema;
using BO4E.BO;

Console.WriteLine("Starting schema generation process...");

int offset;
string outputDirectory;

// Validate arguments
if (args.Length < 2)
{
    Console.Error.WriteLine("Error: You must provide both an offset and an output directory.");
    Console.Error.WriteLine("Usage: dotnet run -- <offset> <outputDirectory>");
    Environment.Exit(1); // Exit with a specific error code for missing arguments
}

if (!int.TryParse(args[0], out offset))
{
    Console.Error.WriteLine($"Error: Invalid argument '{args[0]}'. Please provide a valid integer offset.");
    Environment.Exit(2); // Exit with a specific error code for invalid offset
}

// Get the output directory from the arguments
outputDirectory = args[1];

Console.WriteLine($"Offset provided: {offset}");
Console.WriteLine($"Output directory: {outputDirectory}");

// Generate schemas
try
{
    JsonSchemaGenerator.GenerateSchemas(offset, outputDirectory);
    Console.WriteLine("Schema generation completed successfully.");
}
catch (Exception ex)
{
    Console.Error.WriteLine($"An unexpected error occurred: {ex.Message}");
    Environment.Exit(4); // Exit with a specific error code for unexpected errors
}

Environment.Exit(0); // Success

/// <summary>
/// Generates plain JSON schemas from business object model classes.
/// </summary>
public class JsonSchemaGenerator
{
    private const int LastDataRowOffset = 50;
    private const int MaxSchemasPerHour = 10;

    public static void GenerateSchemas(int offset, string outputDirectory)
    {
        var relevantBusinessObjectTypes = typeof(BusinessObject).Assembly
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(BusinessObject)));

        if (relevantBusinessObjectTypes.Count() > LastDataRowOffset + MaxSchemasPerHour)
        {
            throw new InvalidOperationException("Too many BusinessObject types. Increase the LastDataRowOffset or adjust the MaxSchemasPerHour.");
        }

        try
        {
            // Ensure the output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            foreach (var type in relevantBusinessObjectTypes.Skip(offset).Take(MaxSchemasPerHour))
            {
                var schema = BusinessObject.GetJsonSchema(type);
                var path = Path.Combine(outputDirectory, $"{type.Name}.json");

                Console.WriteLine($"Generating schema for {type.Name} at {path}.");

                if (!File.Exists(path))
                {
                    using (File.Create(path))
                    {
                    }
                }

                var utf8WithoutByteOrderMark = new UTF8Encoding(false);
                File.WriteAllText(path, schema.ToString(SchemaVersion.Draft7), utf8WithoutByteOrderMark);
            }
        }
        catch (JSchemaException jse)
        {
            Console.Error.WriteLine($"Schema generation failed with error: {jse.Message}");
            Environment.Exit(3); // Exit with a specific error code for schema generation failure
        }
    }
}
