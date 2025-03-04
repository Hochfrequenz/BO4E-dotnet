using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
///     Modell für die Abbildung von Rechnungen im Kontext der Energiewirtschaft. Ausgehend von diesem Basismodell werden
///     weitere spezifische Formen abgeleitet.
///     https://www.bo4e.de/dokumentation/geschaeftsobjekte/bo-rechnung
/// </summary>
[ProtoContract]
public class Rechnung : BusinessObject
{
    /// <summary>
    ///     empty constructor for deserilization
    /// </summary>
    public Rechnung() { }

    /// <summary>
    ///     this constructor creates a BO4E.Rechnung from a JSON serialized SAP print document ("Druckbeleg")
    /// </summary>
    /// <param name="sapPrintDocument">a JSON serialized SAP print document using lowerCamelCase naming convention</param>
    public Rechnung(JObject sapPrintDocument)
        : this()
    {
        // why is this method so bloated and always tries to access two different keys of the JSON document using the ?? operator?
        // Initially I exported the SAP print document "Druckbeleg") using the SAP library /ui2/cl_json which allows for pretty printing
        // the ALL_UPPER_CASE SAP internal keys to lowerCamelCase. Later on technical constraints in SAP forced me to use a different
        // serialization which is closer to SAPs internal structure and has no lower case keys at all. Furthermore in SAP there is
        // no difference between string.Empty and null; the latter doesn't even exist as a concept.
        var infoToken =
            sapPrintDocument.SelectToken("erdk") ?? sapPrintDocument.SelectToken("ERDK");
        var tErdzToken =
            sapPrintDocument.SelectToken("tErdz") ?? sapPrintDocument.SelectToken("T_ERDZ");
        if (tErdzToken == null)
        {
            throw new ArgumentException(
                "The SAP print document did not contain a 'tErdz' token. Did you serialize using the right naming convention?"
            );
        }

        Rechnungsnummer = (infoToken["opbel"] ?? infoToken["OPBEL"]).Value<string>();
        Rechnungsdatum = new DateTimeOffset(
            TimeZoneInfo.ConvertTime(
                (infoToken["bldat"] ?? infoToken["BLDAT"]).Value<DateTime>(),
                CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo,
                TimeZoneInfo.Utc
            )
        );
        Rechnungsperiode = new Zeitraum
        {
            Startdatum = new DateTimeOffset(
                TimeZoneInfo.ConvertTime(
                    (tErdzToken[0]["ab"] ?? tErdzToken[0]["AB"]).Value<DateTime>(),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo,
                    TimeZoneInfo.Utc
                )
            ),
            Enddatum = new DateTimeOffset(
                TimeZoneInfo.ConvertTime(
                    (tErdzToken[0]["bis"] ?? tErdzToken[0]["BIS"]).Value<DateTime>(),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo,
                    TimeZoneInfo.Utc
                )
            ),
        };
        Faelligkeitsdatum = new DateTimeOffset(
            TimeZoneInfo.ConvertTime(
                (infoToken["faedn"] ?? infoToken["FAEDN"]).Value<DateTime>(),
                CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo,
                TimeZoneInfo.Utc
            )
        );
        Storno = false;

        decimal gSteure,
            vGezahlt,
            rBrutto;
        var gNetto = gSteure = _ = vGezahlt = rBrutto = 0.00M;
        var waehrungscode = (Waehrungscode)
            Enum.Parse(
                typeof(Waehrungscode),
                (infoToken["totalWaer"] ?? infoToken["TOTAL_WAER"]).Value<string>()
            );
        var waehrungseinheit = (Waehrungseinheit)
            Enum.Parse(
                typeof(Waehrungseinheit),
                (infoToken["totalWaer"] ?? infoToken["TOTAL_WAER"]).Value<string>()
            );
        var mengeneinheit = (Mengeneinheit)
            Enum.Parse(
                typeof(Mengeneinheit),
                (tErdzToken[0]["massbill"] ?? tErdzToken[0]["MASSBILL"]).Value<string>()
            );

        var rpList = new List<Rechnungsposition>();
        var stList = new List<Steuerbetrag>();
        Vorausgezahlt = new Betrag { Waehrung = waehrungscode, Wert = 0 };
        foreach (var jrp in tErdzToken)
        {
            var belzart = (jrp["belzart"] ?? jrp["BELZART"]).ToString();
            if (belzart == "IQUANT" || belzart == "ROUND" || belzart == "ROUNDO")
            {
                continue;
            }

            var rp = new Rechnungsposition();
            decimal zeitbezogeneMengeWert = 0;
            switch (belzart)
            {
                case "000001":
                    rp.Positionstext = "ARBEITSPREIS";
                    break;
                case "000003":
                    rp.Positionstext = "PAUSCHALE";
                    mengeneinheit = Mengeneinheit.JAHR;
                    zeitbezogeneMengeWert = (jrp["preisbtr"] ?? jrp["PREISBTR"]).Value<decimal>();
                    rp.ZeitbezogeneMenge = new Menge
                    {
                        Einheit = Mengeneinheit.TAG,
                        Wert = zeitbezogeneMengeWert,
                    };

                    rp.Einzelpreis = new Preis
                    {
                        Wert = decimal.Parse((jrp["zeitant"] ?? jrp["ZEITANT"]).ToString()),
                        Einheit = waehrungseinheit,
                        Bezugswert = mengeneinheit,
                    };
                    break;
                case "000004":
                    rp.Positionstext = "VERRECHNUNGSPREIS";
                    break;
                case "SUBT":
                    rp.Positionstext = "zuzüglich Mehrwertsteuer 19,000%";
                    break;
                case "ZHFBP1":
                case "CITAX":
                    rp.Positionstext = belzart;
                    break;
                default:
                    rp.Positionstext = "";
                    break;
            }

            if (
                (jrp["massbill"] ?? jrp["MASSBILL"]) != null
                && !string.IsNullOrWhiteSpace((jrp["massbill"] ?? jrp["MASSBILL"]).Value<string>())
            )
            {
                mengeneinheit = (Mengeneinheit)
                    Enum.Parse(
                        typeof(Mengeneinheit),
                        (jrp["massbill"] ?? jrp["MASSBILL"]).Value<string>()
                    );
            }
            else if (
                (jrp["timbasis"] ?? jrp["TIMBASIS"]) != null
                && !string.IsNullOrWhiteSpace((jrp["timbasis"] ?? jrp["TIMBASIS"]).Value<string>())
            )
            {
                if ((jrp["timbasis"] ?? jrp["TIMBASIS"]).Value<string>() == "365")
                {
                    mengeneinheit = Mengeneinheit.JAHR;
                    rp.ZeitbezogeneMenge = new Menge
                    {
                        Einheit = Mengeneinheit.TAG,
                        Wert = zeitbezogeneMengeWert,
                    };
                }
            }
            else
            {
                mengeneinheit = Mengeneinheit.KWH;
            }

            if (rp.Einzelpreis == null)
            {
                if ((jrp["preisbtr"] ?? jrp["PREISBTR"]) != null)
                {
                    rp.Einzelpreis = new Preis
                    {
                        Wert = decimal.Parse((jrp["preisbtr"] ?? jrp["PREISBTR"]).ToString()),
                        Einheit = waehrungseinheit,
                        Bezugswert = mengeneinheit,
                    };
                }
                else
                {
                    rp.Einzelpreis = new Preis
                    {
                        Wert = 0,
                        Einheit = waehrungseinheit,
                        Bezugswert = mengeneinheit,
                    };
                }
            }

            rp.Positionsnummer = (jrp["belzeile"] ?? jrp["BELZEILE"]).Value<int>();
            if (
                (jrp["bis"] ?? jrp["BIS"]) != null
                && (jrp["bis"] ?? jrp["BIS"]).Value<string>() != "0000-00-00"
            )
            {
                rp.LieferungBis = new DateTimeOffset(
                    TimeZoneInfo.ConvertTime(
                        (jrp["bis"] ?? jrp["BIS"]).Value<DateTime>(),
                        CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo,
                        TimeZoneInfo.Utc
                    )
                );
            }

            if (
                (jrp["ab"] ?? jrp["AB"]) != null
                && (jrp["ab"] ?? jrp["AB"]).Value<string>() != "0000-00-00"
            )
            {
                rp.LieferungVon = new DateTimeOffset(
                    TimeZoneInfo.ConvertTime(
                        (jrp["ab"] ?? jrp["AB"]).Value<DateTime>(),
                        CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo,
                        TimeZoneInfo.Utc
                    )
                );
            }

            if ((jrp["vertrag"] ?? jrp["VERTRAG"]) != null)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                rp.VertragskontoId = (jrp["vertrag"] ?? jrp["VERTRAG"]).Value<string>();
#pragma warning restore CS0618 // Type or member is obsolete
            }

            if ((jrp["iAbrmenge"] ?? jrp["I_ABRMENGE"]) != null)
            {
                rp.PositionsMenge = new Menge
                {
                    Wert = (jrp["iAbrmenge"] ?? jrp["I_ABRMENGE"]).Value<decimal>(),
                    Einheit = mengeneinheit,
                };
            }

            if ((jrp["nettobtr"] ?? jrp["NETTOBTR"]) != null)
            {
                if (belzart != "SUBT" && belzart != "CITAX")
                {
                    rp.TeilsummeNetto = new Betrag
                    {
                        Wert = (jrp["nettobtr"] ?? jrp["NETTOBTR"]).Value<decimal>(),
                        Waehrung = waehrungscode,
                    };
                }
                else
                {
                    rp.TeilsummeNetto = new Betrag
                    {
                        Wert = (jrp["sbasw"] ?? jrp["SBASW"]).Value<decimal>(),
                        Waehrung = waehrungscode,
                    };
                    var steuerbetrag = new Steuerbetrag
                    {
                        Basiswert = (jrp["sbasw"] ?? jrp["SBASW"]).Value<decimal>(),
                        Steuerwert = (jrp["sbetw"] ?? jrp["SBETW"]).Value<decimal>(),
                        Waehrung = (Waehrungscode)
                            Enum.Parse(
                                typeof(Waehrungscode),
                                (jrp["twaers"] ?? jrp["TWAERS"]).Value<string>()
                            ),
                    };
                    decimal steuerProzent;
                    if (
                        (jrp["stprz"] ?? jrp["STPRZ"]) != null
                        && !string.IsNullOrWhiteSpace(
                            (jrp["stprz"] ?? jrp["STPRZ"]).Value<string>()
                        )
                    )
                    {
                        steuerProzent = decimal.Parse(
                            (jrp["stprz"] ?? jrp["STPRZ"]).Value<string>().Replace(",", ".").Trim(),
                            CultureInfo.InvariantCulture
                        );
                    }
                    else
                    {
                        steuerProzent = steuerbetrag.Steuerwert / steuerbetrag.Basiswert * 100.0M;
                    }

                    steuerbetrag.Steuerkennzeichen = (int)steuerProzent switch
                    {
                        19 => Steuerkennzeichen.UST_19,
                        7 => Steuerkennzeichen.UST_7,
                        _ => throw new NotImplementedException(
                            $"Taxrate Internal '{jrp["taxrateInternal"]}' is not mapped."
                        ),
                    };
                    rp.TeilsummeSteuer = steuerbetrag;
                }

                if ((jrp["nettobtr"] ?? jrp["NETTOBTR"]).Value<decimal>() <= 0)
                {
                    Vorausgezahlt = new Betrag
                    {
                        Waehrung = waehrungscode,
                        Wert = (jrp["nettobtr"] ?? jrp["NETTOBTR"]).Value<decimal>(),
                    };
                }
            }

            rp.Zeiteinheit = mengeneinheit;
            rpList.Add(rp);

            var be = jrp["nettobtr"] ?? jrp["NETTOBTR"];
            if (be != null)
            {
                if (belzart != "SUBT" && belzart != "CITAX") // this will lead to problems in the long run.
                {
                    gNetto += be.Value<decimal>();
                }
                else
                {
                    var steuerbetrag = new Steuerbetrag
                    {
                        Basiswert = (jrp["sbasw"] ?? jrp["SBASW"]).Value<decimal>(),
                        Steuerwert = (jrp["sbetw"] ?? jrp["SBETW"]).Value<decimal>(),
                        Waehrung = (Waehrungscode)
                            Enum.Parse(
                                typeof(Waehrungscode),
                                (jrp["twaers"] ?? jrp["TWAERS"]).Value<string>()
                            ),
                    };
                    decimal steuerProzent;
                    if (
                        (jrp["stprz"] ?? jrp["STPRZ"]) != null
                        && !string.IsNullOrWhiteSpace(
                            (jrp["stprz"] ?? jrp["STPRZ"]).Value<string>()
                        )
                    )
                    {
                        steuerProzent = decimal.Parse(
                            (jrp["stprz"] ?? jrp["STPRZ"]).Value<string>().Replace(",", ".").Trim(),
                            CultureInfo.InvariantCulture
                        );
                    }
                    else
                    {
                        steuerProzent = Math.Round(
                            steuerbetrag.Steuerwert / steuerbetrag.Basiswert * 100.0M
                        );
                    }

                    steuerbetrag.Steuerkennzeichen = steuerProzent switch
                    {
                        19.0M => Steuerkennzeichen.UST_19,
                        7.0M => Steuerkennzeichen.UST_7,
                        _ => throw new NotImplementedException(
                            $"Taxrate Internal '{jrp["taxrateInternal"] ?? jrp["TAXRATE_INTERNAL"]}' is not mapped."
                        ),
                    };
                    stList.Add(steuerbetrag);
                    gSteure += be.Value<decimal>();
                }
            }
        }

        Steuerbetraege = stList;
        Rechnungspositionen = rpList;
        var gBrutto = gNetto + gSteure;
        var zZahlen = gBrutto - vGezahlt - rBrutto;
        Gesamtnetto = new Betrag { Wert = gNetto, Waehrung = waehrungscode };
        Gesamtsteuer = new Betrag { Wert = gSteure, Waehrung = waehrungscode };
        Gesamtbrutto = new Betrag { Wert = gBrutto, Waehrung = waehrungscode };
        Zuzahlen = new Betrag { Wert = zZahlen, Waehrung = waehrungscode };

        Rechnungsersteller = new Geschaeftspartner
        {
            Geschaeftspartnerrolle = new List<Geschaeftspartnerrolle>
            {
                Geschaeftspartnerrolle.LIEFERANT,
            },
            Gewerbekennzeichnung = true,
            Anrede = Anrede.HERR,
            Name1 = "Mein super Lieferant",
            Partneradresse = new Adresse
            {
                Strasse = "Max-Plank-Strasse",
                Hausnummer = "8",
                Postleitzahl = "90190",
                Landescode = Landescode.DE,
                Ort = "Walldorf",
            },
        };
        Rechnungsempfaenger = new Geschaeftspartner
        {
            Geschaeftspartnerrolle = new List<Geschaeftspartnerrolle>
            {
                Geschaeftspartnerrolle.KUNDE,
            },
            Gewerbekennzeichnung = false,
            Anrede = Anrede.HERR,
            Name1 = "Lustig",
            Name2 = "Peter",
            Partneradresse = new Adresse
            {
                Strasse = "Magnusstraße",
                Hausnummer = "20",
                Postleitzahl = "50672",
                Landescode = Landescode.DE,
                Ort = "Köln",
            },
        };
    }

    /// <summary>
    ///     Bezeichnung für die vorliegende Rechnung.
    /// </summary>
    [JsonProperty(Order = 6, PropertyName = "rechnungstitel")]
    [JsonPropertyName("rechnungstitel")]
    [FieldName("billTitle", Language.EN)]
    [ProtoMember(4)]
    [JsonPropertyOrder(6)]
    public string? Rechnungstitel { get; set; }

    /// <summary>
    ///     Status der Rechnung zur Kennzeichnung des Bearbeitungsstandes. Details siehe ENUM Rechnungsstatus
    /// </summary>
    [JsonProperty(Order = 7, PropertyName = "rechnungsstatus")]
    [JsonPropertyName("rechnungsstatus")]
    [FieldName("billStatus", Language.EN)]
    [ProtoMember(5)]
    [JsonPropertyOrder(7)]
    public Rechnungsstatus? Rechnungsstatus { get; set; }

    /// <summary>
    ///     Kennzeichnung, ob es sich um eine Stornorechnung handelt. Im Falle "true" findet sich im Attribut
    ///     "originalrechnungsnummer" die Nummer der Originalrechnung.
    /// </summary>
    [JsonProperty(Order = 8, PropertyName = "storno")]
    [JsonPropertyName("storno")]
    [FieldName("isCancellation", Language.EN)]
    [ProtoMember(6)]
    [JsonPropertyOrder(8)]
    public bool Storno { get; set; }

    /// <summary>
    ///     Eine im Verwendungskontext eindeutige Nummer für die Rechnung.
    /// </summary>
    [JsonProperty(Order = 9, PropertyName = "rechnungsnummer")]
    [JsonPropertyName("rechnungsnummer")]
    [ProtoMember(7)]
    [JsonPropertyOrder(9)]
    [BoKey]
    [FieldName("billNumber", Language.EN)]
    public string Rechnungsnummer { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(8, Name = nameof(Rechnungsdatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Rechnungsdatum
    {
        get => Rechnungsdatum.UtcDateTime;
        set => Rechnungsdatum = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    ///     Ausstellungsdatum der Rechnung.
    /// </summary>
    [JsonProperty(Order = 10, PropertyName = "rechnungsdatum")]
    [JsonPropertyName("rechnungsdatum")]
    [ProtoIgnore]
    [JsonPropertyOrder(10)]
    [FieldName("billDate", Language.EN)]
    public DateTimeOffset Rechnungsdatum { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(9, Name = nameof(Faelligkeitsdatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Faelligkeitsdatum
    {
        get => Faelligkeitsdatum.UtcDateTime;
        set => Faelligkeitsdatum = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    ///     Zu diesem Datum ist die Zahlung fällig.
    /// </summary>
    [JsonProperty(Order = 11, PropertyName = "faelligkeitsdatum")]
    [JsonPropertyName("faelligkeitsdatum")]
    [ProtoIgnore]
    [JsonPropertyOrder(11)]
    [FieldName("dueDate", Language.EN)]
    public DateTimeOffset Faelligkeitsdatum { get; set; }

    /// <summary>
    ///     Ein kontextbezogender Rechnungstyp, z.B. Netznutzungsrechnung. Details siehe ENUM Rechnungstyp
    /// </summary>
    [JsonProperty(Order = 12, PropertyName = "rechnungstyp")]
    [JsonPropertyName("rechnungstyp")]
    [ProtoMember(10)]
    [JsonPropertyOrder(12)]
    [FieldName("billType", Language.EN)]
    public Rechnungstyp Rechnungsstyp { get; set; }

    /// <summary>
    ///     Im Falle einer Stornorechnung (storno = true) steht hier die Rechnungsnummer der stornierten Rechnung.
    /// </summary>
    [JsonProperty(Order = 13, PropertyName = "originalRechnungsnummer")]
    [JsonPropertyName("originalRechnungsnummer")]
    [ProtoMember(11)]
    [JsonPropertyOrder(13)]
    public string? OriginalRechnungsnummer { get; set; }

    /// <summary>
    ///     Der Zeitraum der zugrunde liegenden Lieferung zur Rechnung. In der COM Zeitraum können diese angegeben werden.
    /// </summary>
    [JsonProperty(Order = 14, PropertyName = "rechnungsperiode")]
    [JsonPropertyName("rechnungsperiode")]
    [ProtoMember(12)]
    [JsonPropertyOrder(14)]
    [FieldName("billPeriod", Language.EN)]
    public Zeitraum Rechnungsperiode { get; set; }

    /// <summary>
    ///     Der Aussteller der Rechnung. Details <see cref="Geschaeftspartner" />
    /// </summary>
    [JsonProperty(Order = 15, PropertyName = "rechnungsersteller")]
    [JsonPropertyName("rechnungsersteller")]
    [ProtoMember(13)]
    [JsonPropertyOrder(15)]
    [FieldName("issuer", Language.EN)]
    public Geschaeftspartner Rechnungsersteller { get; set; }

    /// <summary>
    ///     Der Empfänger der Rechnung. Details <see cref="Geschaeftspartner" />
    /// </summary>
    [JsonProperty(Order = 16, PropertyName = "rechnungsempfaenger")]
    [JsonPropertyName("rechnungsempfaenger")]
    [ProtoMember(14)]
    [JsonPropertyOrder(16)]
    [FieldName("recipient", Language.EN)]
    public Geschaeftspartner Rechnungsempfaenger { get; set; }

    /// <summary>
    ///     Die Summe der Nettobeträge der Rechnungsteile. Details <see cref="Betrag" />
    /// </summary>
    [JsonProperty(Order = 17, PropertyName = "gesamtnetto")]
    [JsonPropertyName("gesamtnetto")]
    [ProtoMember(15)]
    [JsonPropertyOrder(17)]
    [FieldName("totalNet", Language.EN)]
    public Betrag Gesamtnetto { get; set; }

    /// <summary>
    ///     Die Summe der Steuerbeträge der Rechnungsteile. Details <see cref="Betrag" />
    /// </summary>
    [JsonProperty(Order = 18, PropertyName = "gesamtsteuer")]
    [JsonPropertyName("gesamtsteuer")]
    [ProtoMember(16)]
    [JsonPropertyOrder(18)]
    [FieldName("totalTax", Language.EN)]
    public Betrag Gesamtsteuer { get; set; }

    /// <summary>
    ///     Die Summe aus Netto- und Steuerbetrag. Details <see cref="Betrag" />
    /// </summary>
    [JsonProperty(Order = 19, PropertyName = "gesamtbrutto")]
    [JsonPropertyName("gesamtbrutto")]
    [ProtoMember(17)]
    [JsonPropertyOrder(19)]
    [FieldName("totalGross", Language.EN)]
    public Betrag Gesamtbrutto { get; set; }

    /// <summary>
    ///     Die Summe evtl. vorausgezahlter Beträge, z.B. Abschläge. Angabe als Bruttowert. Details <see cref="Betrag" />
    /// </summary>
    [JsonProperty(Order = 20, PropertyName = "vorausgezahlt")]
    [JsonPropertyName("vorausgezahlt")]
    [ProtoMember(18)]
    [JsonPropertyOrder(20)]
    [FieldName("prepaid", Language.EN)]
    public Betrag? Vorausgezahlt { get; set; }

    /// <summary>
    ///     Gesamtrabatt auf den Bruttobetrag. Details <see cref="Betrag" />
    /// </summary>
    [JsonProperty(Order = 21, PropertyName = "rabattBrutto")]
    [JsonPropertyName("rabattBrutto")]
    [ProtoMember(19)]
    [JsonPropertyOrder(21)]
    [FieldName("discountGross", Language.EN)]
    public Betrag? RabattBrutto { get; set; }

    /// <summary>
    ///     Der zu zahlende Betrag, der sich aus (<see cref="Gesamtbrutto" /> - <see cref="Vorausgezahlt" /> -
    ///     <see cref="RabattBrutto" />) ergibt. Details <see cref="Betrag" />
    ///     ///
    /// </summary>
    [JsonProperty(Order = 22, PropertyName = "zuzahlen")]
    [JsonPropertyName("zuzahlen")]
    [ProtoMember(20)]
    [JsonPropertyOrder(22)]
    [FieldName("toPay", Language.EN)]
    public Betrag Zuzahlen { get; set; }

    /// <summary>
    ///     Eine Liste mit Steuerbeträgen pro Steuerkennzeichen/Steuersatz. Die Summe dieser Beträge ergibt den Wert für
    ///     gesamtsteuer. Details <see cref="Steuerbetrag" />
    /// </summary>
    [JsonProperty(Order = 23, PropertyName = "steuerbetraege")]
    [JsonPropertyName("steuerbetraege")]
    [ProtoMember(21)]
    [JsonPropertyOrder(23)]
    [FieldName("taxList", Language.EN)]
    public List<Steuerbetrag>? Steuerbetraege { get; set; }

    /// <summary>
    ///     Die Rechnungspositionen. Details siehe <see cref="Rechnungsposition" />
    /// </summary>
    [ProtoMember(22)]
    [JsonProperty(Order = 24, PropertyName = "rechnungspositionen")]
    [JsonPropertyName("rechnungspositionen")]
    [FieldName("invoiceItemList", Language.EN)]
    [JsonPropertyOrder(24)]
    public List<Rechnungsposition> Rechnungspositionen { get; set; }

    /// <summary>
    ///     Kennzeichen, ob es sich um eine selbstausgestellte Rechnung handelt
    /// </summary>
    [ProtoMember(23)]
    [JsonProperty(Order = 25, PropertyName = "istSelbstausgestellt")]
    [JsonPropertyName("istSelbstausgestellt")]
    [JsonPropertyOrder(25)]
    public bool? IstSelbstausgestellt { get; set; }

    /// <summary>
    ///     Kennzeichen, ob bei der Rechnung das Reverse Charge verfahren angewendet wird
    /// </summary>
    [ProtoMember(24)]
    [JsonProperty(Order = 26, PropertyName = "istReverseCharge")]
    [JsonPropertyName("istReverseCharge")]
    [JsonPropertyOrder(26)]
    public bool? IstReverseCharge { get; set; }

    /// <summary>
    ///     evtl. vorausgezahlte Beträge, z.B. Abschläge. Angabe als Bruttowert. Details <see cref="Betrag" />
    /// </summary>
    [JsonProperty(Order = 27, PropertyName = "vorauszahlungen")]
    [JsonPropertyName("vorauszahlungen")]
    [ProtoMember(25)]
    [FieldName("prepaids", Language.EN)]
    [JsonPropertyOrder(27)]
    public List<Vorauszahlung>? Vorauszahlungen { get; set; }

    /// <summary>
    ///     Sonderrechnungsart
    /// </summary>
    [JsonProperty(Order = 28, PropertyName = "sonderrechnungsart")]
    [JsonPropertyName("sonderrechnungsart")]
    [ProtoMember(26)]
    [JsonPropertyOrder(28)]
    public Sonderrechnungsart? Sonderrechnungsart { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(27, Name = nameof(Buchungsdatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Buchungsdatum
    {
        get => Buchungsdatum?.UtcDateTime ?? DateTime.MinValue;
        set => Buchungsdatum = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    ///     Zu diesem Datum ist die Zahlung fällig.
    /// </summary>
    [JsonProperty(Order = 29, PropertyName = "buchungsdatum")]
    [JsonPropertyName("buchungsdatum")]
    [ProtoIgnore]
    [FieldName("bookingDate", Language.EN)]
    [JsonPropertyOrder(29)]
    public DateTimeOffset? Buchungsdatum { get; set; }
}
