using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Die Komponente Ausschreibungsdetail wird verwendet um die Informationen zu einer Abnahmestelle innerhalb eines
///     Ausschreibungsloses abzubilden.
/// </summary>
[ProtoContract]
public class Ausschreibungsdetail : COM
{
    /// <summary>Identifikation einer ausgeschriebenen Marktlokation</summary>
    [JsonProperty(PropertyName = "lokationsId")]
    [JsonPropertyName("lokationsId")]
    [ProtoMember(3)]
    public string LokationsId { get; set; }

    /// <summary>Bezeichnung für die Lokation, z.B. Zentraler Einkauf, Hamburg</summary>
    [JsonProperty(PropertyName = "lokationsbezeichung")]
    [JsonPropertyName("lokationsbezeichung")]
    [ProtoMember(4)]
    public string? Lokationsbezeichung { get; set; }

    /// <summary>
    ///     In der angegebenen Netzebene wird die Marktlokation versorgt, z.B. MSP für Mittelspanung. Details
    ///     <see cref="Netzebene" />
    /// </summary>
    [JsonProperty(PropertyName = "netzebeneLieferung")]
    [JsonPropertyName("netzebeneLieferung")]
    [ProtoMember(5)]
    public Netzebene NetzebeneLieferung { get; set; }

    /// <summary>
    ///     In der angegebenen Netzebene wird die Lokation gemessen, z.B. NSP für Niederspanung. Details
    ///     <see cref="Netzebene" />
    /// </summary>
    [JsonProperty(PropertyName = "netzebeneMessung")]
    [JsonPropertyName("netzebeneMessung")]
    [ProtoMember(6)]
    public Netzebene NetzebeneMessung { get; set; }

    /// <summary>Bezeichnung des zuständigen Netzbetreibers, z.B. Stromnetz Hamburg GmbH.</summary>
    [JsonProperty(PropertyName = "netzbetreiber")]
    [JsonPropertyName("netzbetreiber")]
    [ProtoMember(7)]
    public string? Netzbetreiber { get; set; }

    /// <summary>Bezeichnung des Kunden, der die Marktlokation nutzt.</summary>
    [JsonProperty(PropertyName = "kunde")]
    [JsonPropertyName("kunde")]
    [ProtoMember(8)]
    public string? Kunde { get; set; }

    /// <summary>Die Bezeichnung des Zählers an der Marktlokation</summary>
    [JsonProperty(PropertyName = "zaehlernummer")]
    [JsonPropertyName("zaehlernummer")]
    [ProtoMember(9)]
    public string? Zaehlernummer { get; set; }

    /// <summary>
    ///     Spezifikation, um welche Zählertechnik es sich im vorliegenden Fall handelt, z.B. Leistungsmessung. Details
    ///     <see cref="Zaehlertyp" />
    /// </summary>
    [JsonProperty(PropertyName = "zaehlertechnik")]
    [JsonPropertyName("zaehlertechnik")]
    [ProtoMember(10)]
    public Zaehlertyp? Zaehlertechnik { get; set; }

    /// <summary>
    ///     Zeigt an, ob es zu der Marktlokation einen Lastgang gibt. Falls ja, kann dieser abgerufen werden und daraus
    ///     die Verbrauchswerte ermittelt werden.
    /// </summary>
    [JsonProperty(PropertyName = "lastgangVorhanden")]
    [JsonPropertyName("lastgangVorhanden")]
    [ProtoMember(11)]
    public bool? LastgangVorhanden { get; set; }

    /// <summary>Die Adresse an der die Marktlokation sich befindet. Struktur <seealso cref="Adresse" /></summary>
    [JsonProperty(PropertyName = "lokationsadresse")]
    [JsonPropertyName("lokationsadresse")]
    [ProtoMember(12)]
    public Adresse Lokationsadresse { get; set; }

    /// <summary>Die (evtl. abweichende) Rechnungsadresse. Struktur <seealso cref="Adresse" /></summary>
    [JsonProperty(PropertyName = "rechnungsadresse")]
    [JsonPropertyName("rechnungsadresse")]
    [ProtoMember(13)]
    public Adresse? Rechnungsadresse { get; set; }

    /// <summary>Prognosewert für die Jahresarbeit der ausgeschriebenen Lokation. Struktur <seealso cref="Menge" /></summary>
    [JsonProperty(PropertyName = "prognoseJahresarbeit")]
    [JsonPropertyName("prognoseJahresarbeit")]
    [ProtoMember(14)]
    public Menge? PrognoseJahresarbeit { get; set; }

    /// <summary>
    ///     Ein Prognosewert für die Arbeit innerhalb des angefragten Lieferzeitraums der ausgeschriebenen Lokation.
    ///     Struktur <seealso cref="Menge" />
    /// </summary>
    [JsonProperty(PropertyName = "prognoseArbeitLieferzeitraum")]
    [JsonPropertyName("prognoseArbeitLieferzeitraum")]
    [ProtoMember(15)]
    public Menge? PrognoseArbeitLieferzeitraum { get; set; }

    /// <summary>
    ///     Prognosewert für die abgenommene maximale Leistung der ausgeschriebenen Lokation. Struktur
    ///     <seealso cref="Menge" />
    /// </summary>
    [JsonProperty(PropertyName = "prognoseLeistung")]
    [JsonPropertyName("prognoseLeistung")]
    [ProtoMember(16)]
    public Menge? PrognoseLeistung { get; set; }

    /// <summary>Angefragter Zeitraum für die ausgeschriebene Belieferung. <seealso cref="Zeitraum" /></summary>
    [JsonProperty(PropertyName = "lieferzeitraum")]
    [JsonPropertyName("lieferzeitraum")]
    [ProtoMember(17)]
    public Zeitraum? Lieferzeitraum { get; set; }
}
