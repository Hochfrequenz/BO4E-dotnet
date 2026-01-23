using System;
using System.Collections.Generic;
using System.Text.Json;
using BO4E.COM;
using JsonException = System.Text.Json.JsonException;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// Converts a stringified single <see cref="BO4E.ENUM.Verwendungszweck"/>
/// to a <see cref="BO4E.COM.Verwendungszweck"/> which has the single enum value as member in <see cref="Verwendungszweck.Zweck"/>
/// </summary>
/// <remarks><seealso cref="NewtonsoftVerwendungszweckEnumToComConverter"/></remarks>
public class SystemTextVerwendungszweckEnumToComConverter
    : System.Text.Json.Serialization.JsonConverter<Verwendungszweck?>
{
    /// <inheritdoc />
    public override Verwendungszweck? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }
        if (reader.TokenType == JsonTokenType.String)
        {
            var result = new Verwendungszweck
            {
                Marktrolle = ENUM.Marktrolle.LF,
                Zweck = new List<ENUM.Verwendungszweck>(),
            };
            string stringValue = reader.GetString()!;

            // Adjust the string as per the Newtonsoft version
            stringValue = stringValue.Replace(
                "MEHRMINDERMBENGENABRECHNUNG",
                "MEHRMINDERMENGENABRECHNUNG"
            );

            // Parse and add the enum value
            if (Enum.TryParse<ENUM.Verwendungszweck>(stringValue, out var enumValue))
            {
                result.Zweck.Add(enumValue);
            }
            else
            {
                throw new JsonException($"Invalid Verwendungszweck value: {stringValue}");
            }

            return result;
        }

        if (reader.TokenType == JsonTokenType.Number)
        {
            // DEV-84242
            var intValue = reader.GetInt32();
            var enumValue = (ENUM.Verwendungszweck)intValue;
            var result = new Verwendungszweck
            {
                Marktrolle = ENUM.Marktrolle.LF,
                Zweck = new List<ENUM.Verwendungszweck>() { enumValue },
            };
            return result;
        }
        // Delegate to the default deserialization behavior for Verwendungszweck
        return JsonSerializer.Deserialize<Verwendungszweck>(
            ref reader,
            CloneJsonSerializerOptionsExceptThis(options)
        );
    }

    private JsonSerializerOptions CloneJsonSerializerOptionsExceptThis(
        JsonSerializerOptions options
    )
    {
        var clonedOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = options.AllowTrailingCommas,
            DefaultBufferSize = options.DefaultBufferSize,
            DictionaryKeyPolicy = options.DictionaryKeyPolicy,
            DefaultIgnoreCondition = options.DefaultIgnoreCondition,
            IgnoreReadOnlyProperties = options.IgnoreReadOnlyProperties,
            MaxDepth = options.MaxDepth,
            PropertyNameCaseInsensitive = options.PropertyNameCaseInsensitive,
            PropertyNamingPolicy = options.PropertyNamingPolicy,
            ReadCommentHandling = options.ReadCommentHandling,
            WriteIndented = options.WriteIndented,
        };

        foreach (var converter in options.Converters)
        {
            if (converter.GetType() == GetType())
            {
                // prevents stackoverflowexception
                continue;
            }
            clonedOptions.Converters.Add(converter);
        }
        clonedOptions.Converters.Add(new SystemTextVerwendungszweckStringEnumConverter());
        return clonedOptions;
    }

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        Verwendungszweck? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value, CloneJsonSerializerOptionsExceptThis(options));
    }
}
