#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using BO4E.COM;
using BO4E.EnergyIdentificationCodes;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

// https://github.com/Hochfrequenz/energy-service-hub/issues/11
//@JsonPropertyOrder({ "versionStruktur", "boTyp", "marktlokationsId", "sparte", "energierichtung",
//        "bilanzierungsmethode", "verbrauchsart", "unterbrechbar", "netzebene", "netzbetreiberCodeNr", "gebietTyp",
//        "netzgebietNr", "bilanzierungsgebiet", "grundversorgerCodeNr", "gasqualitaet", "endkunde", "lokationsadresse",
//        "geoadresse", "katasterinformation", "zugehoerigeMesslokationen" })
/// <summary>
///     Objekt zur Aufnahme der Informationen zu einer Marktlokation
/// </summary>
[ProtoContract]
public class Marktlokation : BusinessObject
{
    /// <summary>
    ///     Regular Expression used to validate 11 digit MarktlokationId
    /// </summary>
    //[Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    protected static readonly Regex RegexValidate = new(@"^[1-9][\d]{10}$", RegexOptions.Compiled);

    /// <summary>
    ///     Regular Expression to check if a string consists only of numbers (is numeric)
    /// </summary>
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    protected static readonly Regex RegexNumericString = new(@"^\d+$", RegexOptions.Compiled);

    /// <summary>
    ///     Identifikationsnummer einer Marktlokation, an der Energie entweder
    ///     verbraucht, oder erzeugt wird
    /// </summary>
    [DefaultValue("|null|")]
    [JsonProperty(Order = 10, PropertyName = "marktlokationsId")]
    [JsonPropertyName("marktlokationsId")]
    [JsonPropertyOrder(10)]
    [DataCategory(DataCategory.POD)]
    [BoKey]
    [ProtoMember(4)]
    public string? MarktlokationsId { get; set; }

    /// <summary>Sparte der Messlokation, z.B. Gas oder Strom.</summary>
    [JsonProperty(Order = 11, PropertyName = "sparte")]
    [JsonPropertyOrder(11)]
    [JsonPropertyName("sparte")]
    [ProtoMember(5)]
    public Sparte Sparte { get; set; }

    /// <summary>Kennzeichnung, ob Energie eingespeist oder entnommen (ausgespeist) wird.</summary>
    [JsonProperty(Order = 12, PropertyName = "energierichtung")]
    [JsonPropertyOrder(12)]
    [JsonPropertyName("energierichtung")]
    [ProtoMember(6)]
    public Energierichtung? Energierichtung { get; set; }

    /// <summary>Kennzeichnung, ob Energie eingespeist oder entnommen (ausgespeist) wird.</summary>
    [JsonProperty(Order = 13, PropertyName = "bilanzierungsmethode")]
    [JsonPropertyName("bilanzierungsmethode")]
    [JsonPropertyOrder(13)]
    [ProtoMember(7)]
    public Bilanzierungsmethode? Bilanzierungsmethode { get; set; }

    /// <summary>Verbrauchsart der Marktlokation</summary>
    [JsonProperty(Order = 14, PropertyName = "verbrauchsart")]
    [JsonPropertyOrder(14)]
    [JsonPropertyName("verbrauchsart")]
    [ProtoMember(8)]
    public Verbrauchsart? Verbrauchsart { get; set; }

    /// <summary>Gibt an, ob es sich um eine unterbrechbare Belieferung handelt.</summary>
    [JsonProperty(Order = 15, PropertyName = "unterbrechbar")]
    [JsonPropertyName("unterbrechbar")]
    [JsonPropertyOrder(15)]
    [ProtoMember(9)]
    public bool? Unterbrechbar { get; set; }

    /// <summary>
    ///     Netzebene, in der der Bezug der Energie erfolgt. Bei Strom Spannungsebene der
    ///     Lieferung, bei Gas Druckstufe. Beispiel Strom: Niederspannung Beispiel Gas:
    ///     Niederdruck.
    ///     <seealso cref="ENUM.Netzebene" />
    /// </summary>
    [JsonProperty(Order = 16, PropertyName = "netzebene")]
    [JsonPropertyName("netzebene")]
    [JsonPropertyOrder(16)]
    [ProtoMember(10)]
    public Netzebene? Netzebene { get; set; }

    /// <summary>
    ///     Codenummer des Netzbetreibers, an dessen Netz diese Marktlokation
    ///     angeschlossen ist.
    /// </summary>
    [JsonProperty(PropertyName = "netzbetreiberCodeNr", Order = 17)]
    [JsonPropertyOrder(17)]
    [JsonPropertyName("netzbetreiberCodeNr")]
    [ProtoMember(11)]
    public string? NetzbetreiberCodeNr { get; set; }

    /// <summary>Typ des Netzgebietes,z.B.Verteilnetz.</summary>
    /// https://github.com/Hochfrequenz/energy-service-hub/issues/11
    [JsonProperty(PropertyName = "gebietTyp", Order = 18)]
    [JsonPropertyOrder(18)]
    [JsonPropertyName("gebietTyp")]
    [ProtoMember(12)]
    public Gebiettyp? GebietTyp { get; set; }

    /// <summary>Die Nummer des Netzgebietes in der ene't-Datenbank.</summary>
    [JsonProperty(PropertyName = "netzgebietNr", Order = 19)]
    [JsonPropertyOrder(19)]
    [JsonPropertyName("netzgebietNr")]
    [ProtoMember(13)]
    public string? NetzgebietNr { get; set; }

    /// <summary>Bilanzierungsgebiet, dem das Netzgebiet zugeordnet ist - im Falle eines Strom Netzes.</summary>
    [JsonProperty(Order = 20, PropertyName = "bilanzierungsgebiet")]
    [JsonPropertyOrder(20)]
    [JsonPropertyName("bilanzierungsgebiet")]
    [ProtoMember(14)]
    public string? Bilanzierungsgebiet { get; set; }

    /// <summary>CodeNummer des Grundversorgers, der für diese Marktlokation zuständig ist.</summary>
    [JsonProperty(PropertyName = "grundversorgerCodeNr", Order = 21)]
    [JsonPropertyOrder(21)]
    [JsonPropertyName("grundversorgerCodeNr")]
    [ProtoMember(15)]
    public string? GrundversorgerCodeNr { get; set; }

    /// <summary>
    ///     Die Gasqualität in diesem Netzgebiet. H-Gas oder L-Gas. Im Falle eines Gas-Netzes.
    ///     <seealso cref="ENUM.Gasqualitaet" />
    /// </summary>
    /// */
    [JsonProperty(Order = 22, PropertyName = "gasqualitaet")]
    [JsonPropertyOrder(22)]
    [JsonPropertyName("gasqualitaet")]
    [ProtoMember(16)]
    [System.Text.Json.Serialization.JsonConverter(
        typeof(SystemTextNullableGasqualitaetStringEnumConverter)
    )]
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftGasqualitaetStringEnumConverter))]
    public Gasqualitaet? Gasqualitaet { get; set; }

    /// <summary>Link zum Geschäftspartner, dem diese Marktlokation gehört.</summary>
    [JsonProperty(
        Order = 23,
        NullValueHandling = NullValueHandling.Ignore,
        PropertyName = "endkunde"
    )]
    [JsonPropertyOrder(23)]
    [JsonPropertyName("endkunde")]
    [ProtoMember(17)]
    public Geschaeftspartner? Endkunde { get; set; }

    /// <summary>Die Adresse, an der die Energie-Lieferung oder -Einspeisung erfolgt. <seealso cref="Adresse" /></summary>
    /// */
    [DataCategory(DataCategory.ADDRESS)]
    [JsonProperty(Order = 24, PropertyName = "lokationsadresse")]
    [JsonPropertyOrder(24)]
    [JsonPropertyName("lokationsadresse")]
    [ProtoMember(18)]
    public Adresse? Lokationsadresse { get; set; }

    /// <summary>
    ///     Alternativ zu einer postalischen Adresse kann hier ein Ort mittels Geokoordinaten angegeben werden (z.B. zur
    ///     Identifikation von Sendemasten).<seealso cref="Geokoordinaten" />
    /// </summary>
    /// */
    [DataCategory(DataCategory.ADDRESS)]
    [JsonProperty(Order = 25, PropertyName = "geoadresse")]
    [JsonPropertyOrder(25)]
    [JsonPropertyName("geoadresse")]
    [ProtoMember(19)]
    public Geokoordinaten? Geoadresse { get; set; }

    /// <summary>
    ///     Alternativ zu einer postalischen Adresse und Geokoordinaten kann hier eine  Ortsangabe mittels Gemarkung und
    ///     Flurstück erfolgen.
    /// </summary>
    /// <remarks>
    /// Es handelt sich seit v0.20.0 um eine Liste, weil nur so die (listenartigen) Informationen aus der positiven Antwort auf
    /// eine MaLo-Ident Anfrage abgebildet werden können.
    /// https://github.com/Hochfrequenz/malo-ident-net-models/blob/d17bc7fd9732ec4d0d335425c33d5cf34c987bf7/MaLoIdentModels/MaLoIdentModels/v1/DataMarketLocation.cs#L48-L49
    /// </remarks>
    [DataCategory(DataCategory.ADDRESS)]
    [JsonProperty(Order = 26, PropertyName = "katasterinformation")]
    [JsonPropertyOrder(26)]
    [JsonPropertyName("katasterinformation")]
    [ProtoMember(20)]
    public List<Katasteradresse>? Katasterinformation { get; set; }

    /// <summary>
    ///     für EDIFACT mapping
    /// </summary>
    // ToDo: specify docstring / evaluate if necessary
    [JsonProperty(Order = 27, PropertyName = "marktrollen")]
    [JsonPropertyName("marktrollen")]
    [JsonPropertyOrder(27)]
    [ProtoMember(1021)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public List<MarktpartnerDetails>? Marktrollen { get; set; } // ToDo: evaluate this

    /// <summary>
    ///     für EDIFACT mapping
    /// </summary>
    // ToDo: specify docstring.
    [JsonProperty(Order = 28, PropertyName = "regelzone")]
    [JsonPropertyName("regelzone")]
    [JsonPropertyOrder(28)]
    [ProtoMember(1022)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public string? Regelzone { get; set; }

    /// <summary>
    ///     für EDIFACT mapping
    /// </summary>
    // ToDo: specify docstring.
    [JsonProperty(Order = 29, PropertyName = "marktgebiet")]
    [JsonPropertyName("marktgebiet")]
    [JsonPropertyOrder(29)]
    [ProtoMember(1023)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public string? Marktgebiet { get; set; }

    /// <summary>
    ///     für EDIFACT mapping
    /// </summary>
    // ToDo: specify docstring.
    [JsonProperty(Order = 30, PropertyName = "zeitreihentyp")]
    [JsonPropertyName("zeitreihentyp")]
    [JsonPropertyOrder(30)]
    [ProtoMember(1024)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public Zeitreihentyp? Zeitreihentyp { get; set; }

    /// <summary>
    ///     für EDIFACT mapping
    /// </summary>
    // ToDo: specify docstring.
    [JsonProperty(Order = 31, PropertyName = "zaehlwerke")]
    [JsonPropertyName("zaehlwerke")]
    [ProtoMember(1025)]
    [JsonPropertyOrder(31)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public List<Zaehlwerk>? Zaehlwerke { get; set; }

    /// <summary>
    ///     Liste der Zählwerke der beteiligten Martrolle
    /// </summary>
    [JsonProperty(Order = 32, PropertyName = "zaehlwerkeBeteiligteMarktrolle")]
    [JsonPropertyName("zaehlwerkeBeteiligteMarktrolle")]
    [ProtoMember(1026)]
    [JsonPropertyOrder(32)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public List<Zaehlwerk>? ZaehlwerkeBeteiligteMarktrolle { get; set; }

    /// <summary>
    ///     für EDIFACT mapping
    /// </summary>
    // ToDo: specify docstring / check if needed
    [JsonProperty(Order = 33, PropertyName = "verbrauchsmenge")]
    [JsonPropertyName("verbrauchsmenge")]
    [JsonPropertyOrder(33)]
    [ProtoMember(1027)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [Obsolete(
        "Consider if this is really the right place to store the information. I think Energiemenge->energieverbrauch is better suited."
    )]
    public List<Verbrauch>? Verbrauchsmenge { get; set; }

    /// <summary>
    ///     für EDIFACT mapping
    /// </summary>
    // ToDo: specify docstring.
    [JsonProperty(Order = 34, PropertyName = "messlokationen")]
    [JsonPropertyName("messlokationen")]
    [JsonPropertyOrder(34)]
    [ProtoMember(1028)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public List<Messlokation>? Messlokationen { get; set; }

    /// <summary>Aufzählung der Messlokationen, die zu dieser Marktlokation gehören.</summary>
    /// Es können 3 verschiedene Konstrukte auftreten:
    /// <ol>
    ///     <li>
    ///         Beziehung 1 : 0 : Hier handelt es sich um Pauschalanlagen ohne Messung.
    ///         D.h. die Verbrauchsdaten sind direkt über die Marktlokation abgreifbar.
    ///     </li>
    ///     <li>
    ///         Beziehung 1 : 1 : Das ist die Standard-Beziehung für die meisten Fälle.
    ///         In diesem Fall gibt es zu einer Marktlokation genau eine Messlokation.
    ///     </li>
    ///     <li>
    ///         Beziehung 1 : N : Hier liegt beispielsweise eine Untermessung vor. Der
    ///         Verbrauch einer Marklokation berechnet sich hier aus mehreren Messungen.
    ///     </li>
    /// </ol>
    /// Es gibt praktisch auch noch die Beziehung N : 1, beispielsweise bei einer
    /// Zweirichtungsmessung bei der durch eine Messeinrichtung die Messung sowohl
    /// für die Einspreiseseite als auch für die Aussspeiseseite erfolgt. Da
    /// Abrechnung und Bilanzierung jedoch für beide Marktlokationen getrennt
    /// erfolgt, werden nie beide Marktlokationen gemeinsam betrachtet. Daher lässt
    /// sich dieses Konstrukt auf zwei 1:1-Beziehung zurückführen, wobei die
    /// Messlokation in beiden Fällen die gleiche ist.
    ///
    /// In den Zuordnungen sind ist die arithmetische Operation mit der der Verbrauch
    /// einer Messlokation zum Verbrauch einer Marktlokation beitrögt mit aufgeführt.
    /// Der Standard ist hier die Addition.
    [DataCategory(DataCategory.POD)]
    [JsonProperty(Order = 35, PropertyName = "zugehoerigeMesslokationen")]
    [JsonPropertyName("zugehoerigeMesslokationen")]
    [JsonPropertyOrder(35)]
    [ProtoMember(28)]
    public List<Messlokationszuordnung>? ZugehoerigeMesslokationen { get; set; }

    /// <summary>
    ///     Messtechnische Einordnung aus der UTILMD (IMS, KME_MME, KEINE_MESSUNG)
    /// </summary>
    [JsonProperty(Order = 36, PropertyName = "messtechnischeEinordnung")]
    [JsonPropertyName("messtechnischeEinordnung")]
    [JsonPropertyOrder(36)]
    [ProtoMember(1029)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public MesstechnischeEinordnung? MesstechnischeEinordnung { get; set; }

    /// <summary>
    /// Daten für die Prüfung der Netznutzungsabrechnung
    /// </summary>
    [JsonProperty(Order = 37, PropertyName = "netznutzungsabrechnungsdaten")]
    [JsonPropertyName("netznutzungsabrechnungsdaten")]
    [JsonPropertyOrder(37)]
    [ProtoMember(37)]
    public List<Netznutzungsabrechnungsdaten>? Netznutzungsabrechnungsdaten { get; set; }

    /// <summary>
    /// Sperrstatus
    /// </summary>
    [JsonProperty(Order = 38, PropertyName = "sperrstatus")]
    [JsonPropertyName("sperrstatus")]
    [JsonPropertyOrder(38)]
    [ProtoMember(38)]
    public Sperrstatus? Sperrstatus { get; set; }

    /// <summary>
    ///   Zugeordnete Messprodukte
    /// </summary>
    [JsonProperty(Order = 39, PropertyName = "messprodukte")]
    [JsonPropertyName("messprodukte")]
    [ProtoMember(1039)]
    [JsonPropertyOrder(39)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public List<Messprodukt>? Messprodukte { get; set; }

    /// <summary>
    /// Produkt-Daten der Marktlokation
    /// </summary>
    [JsonProperty(Order = 40, PropertyName = "konfigurationsprodukte")]
    [JsonPropertyName("konfigurationsprodukte")]
    [ProtoMember(40)]
    [JsonPropertyOrder(40)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public List<Konfigurationsprodukt>? Konfigurationsprodukte { get; set; }

    // /// <summary>
    // /// Lokationszuordnung, um bspw. die zugehörigen Messlokationen anzugeben
    // /// </summary>
    // [JsonProperty(
    //
    //     Order = 41,
    //     PropertyName = "lokationszuordnungen"
    // )]
    // [JsonPropertyName("lokationszuordnungen")]
    // [ProtoMember(41)]
    // [JsonPropertyOrder(41)]
    // public List<Lokationszuordnung>? Lokationszuordnungen { get; set; }

    /// <summary>
    /// Lokationsbuendel Code, der die Funktion dieses BOs an der Lokationsbuendelstruktur beschreibt.
    /// </summary>
    [JsonProperty(Order = 42, PropertyName = "lokationsbuendelObjektcode")]
    [JsonPropertyName("lokationsbuendelObjektcode")]
    [ProtoMember(42)]
    [JsonPropertyOrder(42)]
    public string? LokationsbuendelObjektcode { get; set; }

    /// <summary>
    /// Enthält die ID der vorgelagerten Lokation. Kann IDs unterschiedlicher Lokationen enthalten, also zum Beispiel
    /// einer Messlokation oder Netzlokation
    /// </summary>
    [Obsolete("Abgelöst durch 'VorgelagerteLokationsIds'.")]
    [JsonProperty(Order = 43, PropertyName = "vorgelagerteLokationsId")]
    [JsonPropertyName("vorgelagerteLokationsId")]
    [ProtoMember(43)]
    [JsonPropertyOrder(43)]
    public string? VorgelagerteLokationsId { get; set; }

    /// <summary>
    /// Enthält die ID's der vorgelagerten Lokationen. Kann IDs unterschiedlicher Lokationen enthalten, also zum Beispiel
    /// einer Messlokation oder Netzlokation
    /// </summary>
    [JsonProperty(Order = 44, PropertyName = "vorgelagerteLokationsIds")]
    [JsonPropertyName("vorgelagerteLokationsIds")]
    [ProtoMember(44)]
    [JsonPropertyOrder(44)]
    public List<LokationsTypZuordnung>? VorgelagerteLokationsIds { get; set; }

    /// <summary>
    ///     Test if a <paramref name="id" /> is a valid Marktlokations ID.
    /// </summary>
    /// <param name="id">id to test</param>
    /// <returns></returns>
    public static bool ValidateId(string? id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return false;
        }

        if (!RegexValidate.IsMatch(id))
        {
            return false;
        }
        var expectedChecksum = GetChecksum(id!);
        var actualChecksum = id!.Substring(10, 1);
        return actualChecksum == expectedChecksum;
    }

    /// <summary>
    ///     Get the checksum of a marklokationsId:
    ///     a) Quersumme aller Ziffern in ungerader Position
    ///     b) Quersumme aller Ziffern
    ///     auf gerader Position multipliziert mit 2 c) Summe von a) und b) d) Differenz
    ///     von c) zum nächsten Vielfachen von 10 (ergibt sich hier 10, wird die
    ///     Prüfziffer 0 genommen)
    ///     https://bdew-codes.de/Content/Files/MaLo/2017-04-28-BDEW-Anwendungshilfe-MaLo-ID_Version1.0_FINAL.PDF
    /// </summary>
    /// <returns>expected checksum</returns>
    public static string GetChecksum(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException(
                $"Input '{nameof(input)}' must not be empty but was '{input}'"
            );
        }

        if (input.Length is < 10 or > 11)
        {
            throw new ArgumentException(
                $"Input '{nameof(input)}' must be a string with length 10 (to generate the checksum) or 11 (to validate the checksum)."
            );
        }

        if (!RegexNumericString.IsMatch(input))
        {
            throw new ArgumentException($"Input '{nameof(input)}' must be numeric was '{input}'");
        }

        var oddChecksum = 0;
        var evenChecksum = 0;

        // start counting at 1 to be consistent with the above description of "even" and  "odd" but stop at tenth digit.
        for (var i = 1; i < 11; i++)
        {
            var s = input.Substring(i - 1, 1);
            if (i % 2 == 0)
            {
                evenChecksum += 2 * int.Parse(s);
            }
            else
            {
                oddChecksum += int.Parse(s);
            }
        }

        var result = (10 - (evenChecksum + oddChecksum) % 10) % 10;
        return result.ToString();
    }

    /// <summary>
    ///     Test if the <see cref="MarktlokationsId" /> is valid.
    /// </summary>
    /// <returns>if <see cref="MarktlokationsId"/> matches the expected format</returns>
    public bool HasValidId()
    {
        return ValidateId(MarktlokationsId);
    }

    /// <summary>
    ///     same as <see cref="BusinessObject.IsValid()" /> if <paramref name="checkId" /> is false but by default additionally
    ///     checks if the <see cref="MarktlokationsId" /> is valid using <see cref="HasValidId" />.
    /// </summary>
    /// <param name="checkId">validate the <see cref="MarktlokationsId" />, too</param>
    /// <param name="checkRegelZone">check if the <see cref="Regelzone"/> is a German Regelzone if set</param>
    /// <param name="checkBilanzierungsgebiet">check if the <see cref="Bilanzierungsgebiet"/> is a valid German Bilanzierungsgebiet if set</param>
    /// <returns>true if the marktlokation is valid</returns>
    public bool IsValid(
        bool checkId = true,
        bool checkRegelZone = true,
        bool checkBilanzierungsgebiet = true
    )
    {
        return base.IsValid()
            && (!checkId || HasValidId())
            && (
                !checkRegelZone
                || (string.IsNullOrWhiteSpace(Regelzone) || Regelzone.IsGermanControlArea())
            )
            && (
                !checkBilanzierungsgebiet
                || (
                    string.IsNullOrWhiteSpace(Bilanzierungsgebiet)
                    || Bilanzierungsgebiet.IsValidBilanzierungsGebietId()
                )
            );
    }
}
