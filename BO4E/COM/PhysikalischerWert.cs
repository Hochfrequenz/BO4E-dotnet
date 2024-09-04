using System;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Kombination aus einem Wert und einer Einheit (see <see cref="Mengeneinheit" />).
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.UNSPECIFIED)]
public class PhysikalischerWert : COM
{
    /// <summary>
    ///     initialise with wert and einheit
    /// </summary>
    /// <param name="wert">numerischer Wert</param>
    /// <param name="einheit">zugehörige Mengeneinheit</param>
    public PhysikalischerWert(decimal wert, Mengeneinheit einheit) : this()
    {
        Wert = wert;
        Einheit = einheit;
    }

    /// <summary>
    ///     empty constructor for deserilization
    /// </summary>
    public PhysikalischerWert()
    {
    }

    /// <summary>
    ///     initialise with wert and string for einheit
    /// </summary>
    /// <param name="wert">numerischer wert</param>
    /// <param name="einheitString">zugehörige Einheit als string (case insensitive)</param>
    public PhysikalischerWert(decimal wert, string einheitString) : this()
    {
        Wert = wert;

        if (!Enum.TryParse<Mengeneinheit>(einheitString, true, out var einheit))
        {
            throw new ArgumentException($"'{einheitString}' is not a valid Mengeneinheit");
        }

        Einheit = einheit;
    }

    /// <summary>
    ///     numerischer Wert
    /// </summary>
    [ProtoMember(3)]
    [JsonProperty(Required = Required.Always, PropertyName = "wert")]
    [JsonPropertyName("wert")]
    public decimal Wert { get; set; }

    /// <summary>
    ///     Einheit von <see cref="Wert" />
    /// </summary>
    [ProtoMember(4)]
    [JsonProperty(Required = Required.Always, PropertyName = "einheit")]
    [JsonPropertyName("einheit")]
    public Mengeneinheit Einheit { get; set; }
}