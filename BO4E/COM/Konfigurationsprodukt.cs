using System.Text.Json.Serialization;
using BO4E.BO;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>Produkt-daten ein BO wie Netzlokation, Marktlokation usw.</summary>
[ProtoContract]
public class Konfigurationsprodukt : COM
{
    /// <summary>
    /// Der Konfigurationsprodukt-Code für das Objekt
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 1, PropertyName = "produktcode")]
    [JsonPropertyOrder(1)]
    [JsonPropertyName("produktcode")]
    [ProtoMember(1)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public string? Produktcode { get; set; }

    /// <summary>
    /// Code der Zugeordnete Leistungskurvendefinition für das Objekt
    /// </summary>
    [JsonProperty(
        Required = Required.Default,
        Order = 2,
        PropertyName = "leistungskurvendefinition"
    )]
    [JsonPropertyOrder(2)]
    [JsonPropertyName("leistungskurvendefinition")]
    [ProtoMember(2)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public string? Leistungskurvendefinition { get; set; }

    /// <summary>
    /// Code der Zugeordnete Schaltzeitdefinition für das Objekt
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 3, PropertyName = "schaltzeitdefinition")]
    [JsonPropertyOrder(3)]
    [JsonPropertyName("schaltzeitdefinition")]
    [ProtoMember(3)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public string? Schaltzeitdefinition { get; set; }

    /// <summary>
    /// Auftraggebender Marktpartner
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 4, PropertyName = "auftraggebenderMarktpartner")]
    [JsonPropertyOrder(4)]
    [JsonPropertyName("auftraggebenderMarktpartner")]
    [ProtoMember(4)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public Marktteilnehmer? AuftraggebenderMarktpartner { get; set; }
    
    /// <summary>
    /// Marktrolle des Marktpartners für den die Produkt-Daten relevant sind.
    /// Dient zur Identifizierung der Marktrolle an der Marktlokation, an die die Daten des im PIA genannten
    /// Konfigurationsprodukts vom MSB der Marktlokation zu übermitteln sind.
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 5, PropertyName = "empfangendeMarktrolle")]
    [JsonPropertyOrder(5)]
    [JsonPropertyName("empfangendeMarktrolle")]
    [ProtoMember(5)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public ENUM.Marktrolle? EmpfangendeMarktrolle { get; set; }
}
