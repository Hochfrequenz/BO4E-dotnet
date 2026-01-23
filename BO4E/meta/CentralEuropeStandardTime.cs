#nullable enable
using System;

namespace BO4E.meta;

/// <summary>
///     Holds a <see cref="TimeZoneInfo" /> object with the german time zone
///     <see cref="CentralEuropeStandardTimezoneInfo" />
/// </summary>
public abstract class CentralEuropeStandardTime
{
    /// <summary>
    /// serialized with <see cref="TimeZoneInfo.ToSerializedString"/> on a system where the timezone is present.
    /// </summary>
    /// <remarks>
    /// Especially in systems like alpine linux or azure functions "Europe/Berlin" might not be available as timezone (or under a different name)
    /// So to avoid any issues, we just ship it with the package.
    /// </remarks>
    private const string SerializedTimezone =
        "Central Europe Standard Time;60;(UTC+01:00) Belgrad, Bratislava (Pressburg), Budapest, Ljubljana, Prag (Praha);Mitteleuropäische Zeit ;Mitteleuropäische Sommerzeit ;[01:01:0001;12:31:9999;60;[0;02:00:00;3;5;0;];[0;03:00:00;10;5;0;];];";

    /// <summary>
    ///     Central Europe Standard Time as hard coded default time. Public to be used elsewhere ;)
    /// </summary>
    public static TimeZoneInfo CentralEuropeStandardTimezoneInfo =>
        TimeZoneInfo.FromSerializedString(SerializedTimezone); // the string we read from is not malformed, hence we need no error handling. there are tests for this.

    /// <summary>
    ///     legacy time zone info object.
    /// </summary>
    [Obsolete("Use " + nameof(CentralEuropeStandardTimezoneInfo) + " instead.")]
    // ReSharper disable once InconsistentNaming
    public static TimeZoneInfo CENTRAL_EUROPE_STANDARD_TIME => CentralEuropeStandardTimezoneInfo;
}
