using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BO4E.meta.LenientConverters;

/// <summary>
///     The lenient DateTimeConverter allows for transforming strings into (nullable) DateTimeOffset(?) objects,
///     even if their formatting is somehow weird.
/// </summary>
public class LenientSystemTextJsonNullableDateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
{
    private readonly List<(string, bool)> _allowedDatetimeFormats = new List<(string, bool)>
    {
        ("yyyy-MM-ddTHH:mm:ss", false),
        ("yyyy-MM-ddTHH:mm:sszzzz", true),
        ("yyyyMMddHHmm", false),
        ("yyyyMMddHHmmss", false),
        (
            @"yyyyMMddHHmmss'--T::zzzz'",
            false
        ) // ToDo: remove again. this is just a buggy, nasty workaround
        ,
    };

    private readonly DateTimeOffset? _defaultDateTime;

    /// <summary>
    ///     initialize using a default date time
    /// </summary>
    /// <param name="defaultDateTime"></param>
    public LenientSystemTextJsonNullableDateTimeOffsetConverter(
        DateTimeOffset? defaultDateTime = null
    )
    {
        _defaultDateTime = defaultDateTime;
    }

    /// <summary>
    ///     initialize using no default datetime
    /// </summary>
    public LenientSystemTextJsonNullableDateTimeOffsetConverter()
        : this(null) { }

    /// <summary>
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public override DateTimeOffset? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TryGetDateTimeOffset(out var dto))
        {
            return dto;
        }

        var rawDate = reader.GetString();
        // First try to parse the date string as is (in case it is correctly formatted)
        if (typeToConvert == typeof(DateTimeOffset) || typeToConvert == typeof(DateTimeOffset?))
        {
            if (DateTimeOffset.TryParse(rawDate, out var dateTimeOffset))
            {
                return dateTimeOffset;
            }

            foreach (var (dtf, asUniversal) in _allowedDatetimeFormats)
                if (
                    DateTimeOffset.TryParseExact(
                        rawDate,
                        dtf,
                        CultureInfo.InvariantCulture,
                        asUniversal ? DateTimeStyles.AssumeUniversal : DateTimeStyles.None,
                        out dateTimeOffset
                    )
                )
                {
                    return dateTimeOffset;
                }
        }
        else if (typeToConvert == typeof(DateTime) || typeToConvert == typeof(DateTime?))
        {
            if (DateTime.TryParse(rawDate, out var dateTime))
            {
                return dateTime;
            }

            if (
                _allowedDatetimeFormats.Any(dtf =>
                    DateTime.TryParseExact(
                        rawDate,
                        (string)dtf.Item1,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out dateTime
                    )
                )
            )
            {
                return dateTime;
            }
        }

        if (_defaultDateTime.HasValue)
        {
            return _defaultDateTime.Value;
        }

        try
        {
            return JsonSerializer.Deserialize<DateTimeOffset>(ref reader);
        }
        catch (JsonException)
        {
            return null;
        }
        catch (FormatException fe)
            when (fe.Message
                == "The UTC representation of the date '0001-01-01T00:00:00' falls outside the year range 1-9999."
            )
        {
            if (typeToConvert == typeof(DateTime))
            {
                return DateTime.MinValue;
            }

            return DateTimeOffset.MinValue;
        }
        catch (ArgumentOutOfRangeException ae)
            when (ae.Message
                == "The UTC time represented when the offset is applied must be between year 0 and 10,000. (Parameter 'offset')"
            )
        {
            if (typeToConvert == typeof(DateTime))
            {
                return DateTime.MinValue;
            }

            return DateTimeOffset.MinValue;
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(
        Utf8JsonWriter writer,
        DateTimeOffset? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value);
    }
}
