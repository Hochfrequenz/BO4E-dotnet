using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.BO;

/// <summary>
///     Die Variante des Preisblattmodells zur Abbildung der Preise für wahlfreie Dienstleistungen.
/// </summary>
//[ProtoContract]
public class PreisblattDienstleistung : Preisblatt
{
    /// <summary>
    ///     Hier kann der Preis noch auf bestimmte Dienstleistungsbereiche eingegrenzt werden. Z.B. Sperrung/Entsperrung.
    /// </summary>
    [JsonProperty(Order = 7, PropertyName = "dienstleistungsdetails")]
    [JsonPropertyName("dienstleistungsdetails")]
    //[ProtoMember(7)]
    public Dienstleistungstyp Dienstleistungsdetails { get; set; }

    /// <summary>
    ///     Hier kann der Preis auf bestimmte Geräte eingegrenzt werden. Z.B. auf die Zählergröße.
    /// </summary>
    [JsonProperty(Order = 8, PropertyName = "geraetedetails")]
    [JsonPropertyName("geraetedetails")]
    //[ProtoMember(8)]
    public Bilanzierungsmethode? Geraetedetails { get; set; }

    /// <summary>
    ///     Der Netzbetreiber oder Messstellenbetreiber, der die Preise veröffentlicht hat.
    /// </summary>
    [JsonProperty(Order = 9, PropertyName = "herausgeber")]
    [JsonPropertyName("herausgeber")]
    //[ProtoMember(9)]
    public Marktteilnehmer Herausgeber { get; set; }
}
