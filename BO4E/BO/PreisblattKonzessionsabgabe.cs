using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.BO;

/// <summary>
///     Die Variante des Preisblattmodells zur Abbildung von allgemeinen Abgaben
/// </summary>
//[ProtoContract]
public class PreisblattKonzessionsabgabe : Preisblatt
{
    /// <summary>
    ///     Kundegruppe anhand derer die Höhe der Konzessionsabgabe festgelegt ist.
    /// </summary>
    [JsonProperty(Order = 8, PropertyName = "kundengruppeKA")]
    [JsonPropertyName("kundengruppeKA")]
    //[ProtoMember(8)]
    public KundengruppeKA KundengruppeKA { get; set; }
}
