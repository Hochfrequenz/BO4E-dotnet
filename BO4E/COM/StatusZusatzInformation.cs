using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
/// Enthält die Auflistung der STS Segmente Plausibilisierungshinweis, Ersatzwertbildungsverfahren,
/// Korrekturgrund, Gasqualität, Tarif, Grundlage der Energiemenge.
/// </summary>
/// <remarks>Immer daran denken diesen Kommentar zu pflegen, wenn dich <see cref="StatusArt"/> ändert.</remarks>
/// <seealso cref="StatusArt"/>
[ProtoContract]
[NonOfficial(NonOfficialCategory.UNSPECIFIED)]
public class StatusZusatzInformation : COM
{
    /// <summary>
    ///     Enthält die Zusatzinformation Art des angegebenen Wertes
    /// </summary>
    /// <seealso cref="StatusArt" />
    [JsonProperty(PropertyName = "art", Required = Required.Default, Order = 1)]
    [JsonPropertyName("art")]
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    [ProtoMember(1)]
    public StatusArt? Art { get; set; }

    /// <summary>
    ///     Enthält die Zusatzinformation Status des angegebenen Wertes
    /// </summary>
    /// <seealso cref="Status" />
    [JsonProperty(PropertyName = "status", Required = Required.Default, Order = 2)]
    [JsonPropertyName("status")]
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    [ProtoMember(2)]
    public Status? Status { get; set; }
}
