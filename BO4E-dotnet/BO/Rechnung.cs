using System;
using System.Collections.Generic;
using System.Globalization;

using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Modell für die Abbildung von Rechnungen im Kontext der Energiewirtschaft. Ausgehend von diesem Basismodell werden weitere spezifische Formen abgeleitet.
    /// https://www.bo4e.de/dokumentation/geschaeftsobjekte/bo-rechnung
    /// </summary>
    [ProtoContract]
    public class Rechnung : BusinessObject
    {
        /// <summary>
        /// Bezeichnung für die vorliegende Rechnung.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 4, PropertyName ="rechnungstitel")]
        [FieldName("billTitle", Language.EN)]
        [ProtoMember(4)]
        public string Rechnungstitel { get;set; }

        /// <summary>
        /// Status der Rechnung zur Kennzeichnung des Bearbeitungsstandes. Details siehe ENUM Rechnungsstatus
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 5, PropertyName= "rechnungsstatus")]
        [FieldName("billStatus", Language.EN)]
        [ProtoMember(5)]
        public Rechnungsstatus? Rechnungsstatus { get;set; }

        /// <summary>
        /// Kennzeichnung, ob es sich um eine Stornorechnung handelt. Im Falle "true" findet sich im Attribut "originalrechnungsnummer" die Nummer der Originalrechnung.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 6, PropertyName= "storno")]
        [FieldName("isCancellation", Language.EN)]
        [ProtoMember(6)]
        public bool Storno { get;set; }

        /// <summary>
        /// Eine im Verwendungskontext eindeutige Nummer für die Rechnung.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 7, PropertyName= "rechnungsnummer")]
        [ProtoMember(7)]
        [BoKey]
        [FieldName("billNumber", Language.EN)]
        public string Rechnungsnummer { get;set; }

        /// <summary>
        /// Ausstellungsdatum der Rechnung.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 8, PropertyName= "rechnungsdatum")]
        [ProtoMember(8)]
        [FieldName("billDate", Language.EN)]
        public DateTime Rechnungsdatum { get;set; }

        /// <summary>
        /// Zu diesem Datum ist die Zahlung fällig.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 9, PropertyName= "faelligkeitsdatum")]
        [ProtoMember(9)]
        [FieldName("dueDate", Language.EN)]
        public DateTime Faelligkeitsdatum { get;set; }

        /// <summary>
        /// Ein kontextbezogender Rechnungstyp, z.B. Netznutzungsrechnung. Details siehe ENUM Rechnungstyp
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 10, PropertyName ="rechnungstyp")]
        [ProtoMember(10)]
        [FieldName("billType", Language.EN)]
        public Rechnungstyp Rechnungsstyp { get;set; }

        /// <summary>
        /// Im Falle einer Stornorechnung (storno = true) steht hier die Rechnungsnummer der stornierten Rechnung.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 11, PropertyName= "originalRechnungsnummer")]
        [ProtoMember(11)]
        public string OriginalRechnungsnummer { get;set; }

        /// <summary>
        /// Der Zeitraum der zugrunde liegenden Lieferung zur Rechnung. In der COM Zeitraum können diese angegeben werden.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 12,PropertyName= "rechnungsperiode")]
        [ProtoMember(12)]
        [FieldName("billPeriod", Language.EN)]
        public Zeitraum Rechnungsperiode { get;set; }

        /// <summary>
        /// Der Aussteller der Rechnung. Details <see cref="Geschaeftspartner"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 13, PropertyName= "rechnungsersteller")]
        [ProtoMember(13)]
        [FieldName("issuer", Language.EN)]
        public Geschaeftspartner Rechnungsersteller { get;set; }

        /// <summary>
        /// Der Empfänger der Rechnung. Details <see cref="Geschaeftspartner"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 14, PropertyName= "rechnungsempfaenger")]
        [ProtoMember(14)]
        [FieldName("recipient", Language.EN)]
        public Geschaeftspartner Rechnungsempfaenger { get;set; }

        /// <summary>
        /// Die Summe der Nettobeträge der Rechnungsteile. Details <see cref="Betrag"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 15, PropertyName= "gesamtnetto")]
        [ProtoMember(15)]
        [FieldName("totalNet", Language.EN)]
        public Betrag Gesamtnetto { get;set; }

        /// <summary>
        /// Die Summe der Steuerbeträge der Rechnungsteile. Details <see cref="Betrag"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 16, PropertyName="gesamtsteuer")]
        [ProtoMember(16)]
        [FieldName("totalTax", Language.EN)]
        public Betrag Gesamtsteuer { get;set; }

        /// <summary>
        /// Die Summe aus Netto- und Steuerbetrag. Details <see cref="Betrag"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 17, PropertyName= "gesamtbrutto")]
        [ProtoMember(17)]
        [FieldName("totalGross", Language.EN)]
        public Betrag Gesamtbrutto { get;set; }

        /// <summary>
        /// Die Summe evtl. vorausgezahlter Beträge, z.B. Abschläge. Angabe als Bruttowert. Details <see cref="Betrag"/>
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 18, PropertyName= "vorausgezahlt")]
        [ProtoMember(18)]
        [FieldName("prepaid", Language.EN)]
        public Betrag Vorausgezahlt { get;set; }

        /// <summary>
        /// Gesamtrabatt auf den Bruttobetrag. Details <see cref="Betrag"/>
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 19,PropertyName= "rabattBrutto")]
        [ProtoMember(19)]
        [FieldName("discountGross", Language.EN)]
        public Betrag rabattBrutto { get;set; }

        /// <summary>
        /// Der zu zahlende Betrag, der sich aus (<see cref="Gesamtbrutto"/> - <see cref="Vorausgezahlt"/> - <see cref="rabattBrutto"/>) ergibt. Details <see cref="Betrag"/>
        /// /// </summary>
        [JsonProperty(Required = Required.Always, Order = 20, PropertyName= "zuzahlen")]
        [ProtoMember(20)]
        [FieldName("toPay", Language.EN)]
        public Betrag Zuzahlen { get;set; }

        /// <summary>
        /// Eine Liste mit Steuerbeträgen pro Steuerkennzeichen/Steuersatz. Die Summe dieser Beträge ergibt den Wert für gesamtsteuer. Details <see cref="Steuerbetrag"/>
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 21, PropertyName= "steuerbetraege")]
        [ProtoMember(21)]
        [FieldName("taxList", Language.EN)]
        public List<Steuerbetrag> Steuerbetraege { get;set; }

        /// <summary>
        /// Die Rechnungspositionen. Details siehe <see cref="Rechnungsposition"/>
        /// </summary>
        [ProtoMember(22)]
        [JsonProperty(Required = Required.Always, Order = 22, PropertyName= "rechnungspositionen")]
        [FieldName("invoiceItemList", Language.EN)]
        public List<Rechnungsposition> Rechnungspositionen { get;set; }

        public Rechnung() { }

        /// <summary>
        /// this constructor creates a BO4E.Rechnung from a JSON serialized SAP print document ("Druckbeleg")
        /// </summary>
        /// <param name="sapPrintDocument">a JSON serialized SAP print document using lowerCamelCase naming convention</param>
        public Rechnung(JObject sapPrintDocument) : this()
        {
            // why is this method so bloated and always tries to access two different keys of the JSON document using the ?? operator?
            // Initially I exported the SAP print document "Druckbeleg") using the SAP library /ui2/cl_json which allows for pretty printing
            // the ALL_UPPER_CASE SAP internal keys to lowerCamelCase. Later on technical constraints in SAP forced me to use a different
            // serialization which is closer to SAPs internal structure and has no lower case keys at all. Furthermore in SAP there is
            // no difference between string.Empty and null; the latter doesn't even exist as a concept. 
            JToken infoToken = sapPrintDocument.SelectToken("erdk") ?? sapPrintDocument.SelectToken("ERDK");
            JToken tErdzToken = sapPrintDocument.SelectToken("tErdz") ?? sapPrintDocument.SelectToken("T_ERDZ");
            if (tErdzToken == null)
            {
                throw new ArgumentException("The SAP print document did not contain a 'tErdz' token. Did you serialize using the right naming convention?");
            }

            Rechnungsnummer = (infoToken["opbel"] ?? infoToken["OPBEL"]).Value<string>();
            Rechnungsdatum = TimeZoneInfo.ConvertTime((infoToken["bldat"] ?? infoToken["BLDAT"]).Value<DateTime>(), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME, TimeZoneInfo.Utc);
            Rechnungsperiode = new Zeitraum()
            {
                Startdatum = TimeZoneInfo.ConvertTime((tErdzToken[0]["ab"] ?? tErdzToken[0]["AB"]).Value<DateTime>(), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME, TimeZoneInfo.Utc),
                Enddatum = TimeZoneInfo.ConvertTime((tErdzToken[0]["bis"] ?? tErdzToken[0]["BIS"]).Value<DateTime>(), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME, TimeZoneInfo.Utc)
            };
            Faelligkeitsdatum = TimeZoneInfo.ConvertTime((infoToken["faedn"] ?? infoToken["FAEDN"]).Value<DateTime>(), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME, TimeZoneInfo.Utc);
            Storno = false;

            decimal gNetto, gSteure, gBrutto, vGezahlt, rBrutto, zZahlen;
            gNetto = gSteure = gBrutto = vGezahlt = rBrutto = zZahlen = 0.00M;
            Waehrungscode waehrungscode = (Waehrungscode)Enum.Parse(typeof(Waehrungscode), (infoToken["totalWaer"] ?? infoToken["TOTAL_WAER"]).Value<string>());
            Waehrungseinheit waehrungseinheit = (Waehrungseinheit)Enum.Parse(typeof(Waehrungseinheit), (infoToken["totalWaer"] ?? infoToken["TOTAL_WAER"]).Value<string>());
            Mengeneinheit mengeneinheit = (Mengeneinheit)Enum.Parse(typeof(Mengeneinheit), (tErdzToken[0]["massbill"] ?? tErdzToken[0]["MASSBILL"]).Value<string>());

            List<Rechnungsposition> rpList = new List<Rechnungsposition>();
            List<Steuerbetrag> stList = new List<Steuerbetrag>();
            Vorausgezahlt = new Betrag() { Waehrung = waehrungscode, Wert = 0 };
            foreach (JToken jrp in tErdzToken)
            {
                string belzart = (jrp["belzart"] ?? jrp["BELZART"]).ToString();
                if (belzart == "IQUANT" || belzart == "ROUND" || belzart == "ROUNDO")
                {
                    continue;
                }
                else
                {
                    Rechnungsposition rp = new Rechnungsposition();
                    decimal zeitbezogeneMengeWert = 0;
                    if (belzart == "000001")
                    {
                        rp.Positionstext = "ARBEITSPREIS";
                    }
                    else if (belzart == "000003")
                    {
                        rp.Positionstext = "PAUSCHALE";
                        mengeneinheit = Mengeneinheit.JAHR;
                        zeitbezogeneMengeWert = (jrp["preisbtr"] ?? jrp["PREISBTR"]).Value<decimal>();
                        rp.ZeitbezogeneMenge = new Menge() { Einheit = Mengeneinheit.TAG, Wert = zeitbezogeneMengeWert };

                        rp.Einzelpreis = new Preis()
                        {
                            Wert = decimal.Parse((jrp["zeitant"] ?? jrp["ZEITANT"]).ToString()),
                            Einheit = waehrungseinheit,
                            Bezugswert = mengeneinheit
                        };
                    }
                    else if (belzart == "000004")
                        rp.Positionstext = "VERRECHNUNGSPREIS";
                    else if (belzart == "SUBT")
                        rp.Positionstext = "zuzüglich Mehrwertsteuer 19,000%";
                    else if (belzart == "ZHFBP1" || belzart == "CITAX")
                        rp.Positionstext = belzart;
                    else
                        rp.Positionstext = "";

                    if ((jrp["massbill"] ?? jrp["MASSBILL"]) != null && !string.IsNullOrWhiteSpace((jrp["massbill"] ?? jrp["MASSBILL"]).Value<string>()))
                    {
                        mengeneinheit = (Mengeneinheit)Enum.Parse(typeof(Mengeneinheit), (jrp["massbill"] ?? jrp["MASSBILL"]).Value<string>());
                    }
                    else if ((jrp["timbasis"] ?? jrp["TIMBASIS"]) != null && !string.IsNullOrWhiteSpace((jrp["timbasis"] ?? jrp["TIMBASIS"]).Value<string>()))
                    {
                        if ((jrp["timbasis"] ?? jrp["TIMBASIS"]).Value<string>() == "365")
                        {
                            mengeneinheit = Mengeneinheit.JAHR;
                            rp.ZeitbezogeneMenge = new Menge() { Einheit = Mengeneinheit.TAG, Wert = zeitbezogeneMengeWert };
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
                            rp.Einzelpreis = new Preis()
                            {
                                Wert = decimal.Parse((jrp["preisbtr"] ?? jrp["PREISBTR"]).ToString()),
                                Einheit = waehrungseinheit,
                                Bezugswert = mengeneinheit
                            };
                        }
                        else
                            rp.Einzelpreis = new Preis()
                            {
                                Wert = 0,
                                Einheit = waehrungseinheit,
                                Bezugswert = mengeneinheit
                            };
                    }


                    rp.Positionsnummer = (jrp["belzeile"] ?? jrp["BELZEILE"]).Value<int>();
                    if ((jrp["bis"] ?? jrp["BIS"]) != null && (jrp["bis"] ?? jrp["BIS"]).Value<string>() != "0000-00-00")
                    {
                        rp.LieferungBis = TimeZoneInfo.ConvertTime((jrp["bis"] ?? jrp["BIS"]).Value<DateTime>(), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME, TimeZoneInfo.Utc);
                    }
                    if ((jrp["ab"] ?? jrp["AB"]) != null && (jrp["ab"] ?? jrp["AB"]).Value<string>() != "0000-00-00")
                    {
                        rp.LieferungVon = TimeZoneInfo.ConvertTime((jrp["ab"] ?? jrp["AB"]).Value<DateTime>(), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME, TimeZoneInfo.Utc);
                    }
                    if ((jrp["vertrag"] ?? jrp["VERTRAG"]) != null)
                    {
                        rp.VertragskontoId = (jrp["vertrag"] ?? jrp["VERTRAG"]).Value<string>();
                    }

                    if ((jrp["iAbrmenge"] ?? jrp["I_ABRMENGE"]) != null)
                    {
                        rp.PositionsMenge = new Menge()
                        {
                            Wert = (jrp["iAbrmenge"] ?? jrp["I_ABRMENGE"]).Value<decimal>(),
                            Einheit = mengeneinheit
                        };
                    }

                    if ((jrp["nettobtr"] ?? jrp["NETTOBTR"]) != null)
                    {
                        if (belzart != "SUBT" && belzart != "CITAX")
                        {
                            rp.TeilsummeNetto = new Betrag()
                            {
                                Wert = (jrp["nettobtr"] ?? jrp["NETTOBTR"]).Value<decimal>(),
                                Waehrung = waehrungscode
                            };
                        }
                        else
                        {
                            rp.TeilsummeNetto = new Betrag()
                            {
                                Wert = (jrp["sbasw"] ?? jrp["SBASW"]).Value<decimal>(),
                                Waehrung = waehrungscode
                            };
                            Steuerbetrag steuerbetrag = new Steuerbetrag()
                            {
                                Basiswert = (jrp["sbasw"] ?? jrp["SBASW"]).Value<decimal>(),
                                Steuerwert = (jrp["sbetw"] ?? jrp["SBETW"]).Value<decimal>(),
                                Waehrung = (Waehrungscode)Enum.Parse(typeof(Waehrungscode), (jrp["twaers"] ?? jrp["TWAERS"]).Value<string>())
                            };
                            decimal steuerProzent;
                            if ((jrp["stprz"] ?? jrp["STPRZ"]) != null && !string.IsNullOrWhiteSpace((jrp["stprz"] ?? jrp["STPRZ"]).Value<string>()))
                            {
                                steuerProzent = decimal.Parse((jrp["stprz"] ?? jrp["STPRZ"]).Value<string>().Replace(",", ".").Trim(), CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                steuerProzent = steuerbetrag.Steuerwert / steuerbetrag.Basiswert * 100.0M;
                            }
                            if ((int)steuerProzent == 19)
                            {
                                steuerbetrag.Steuerkennzeichen = Steuerkennzeichen.UST_19;
                            }
                            else if ((int)steuerProzent == 7)
                            {
                                steuerbetrag.Steuerkennzeichen = Steuerkennzeichen.UST_7;
                            }
                            else
                            {
                                throw new NotImplementedException($"Taxrate Internal '{jrp["taxrateInternal"]}' is not mapped.");
                            }
                            rp.TeilsummeSteuer = steuerbetrag;
                        }
                        if ((jrp["nettobtr"] ?? jrp["NETTOBTR"]).Value<decimal>() <= 0)
                        {
                            Vorausgezahlt = new Betrag() { Waehrung = waehrungscode, Wert = (jrp["nettobtr"] ?? jrp["NETTOBTR"]).Value<decimal>() };
                        }
                    }

                    rp.Zeiteinheit = mengeneinheit;
                    rpList.Add(rp);

                    var be = (jrp["nettobtr"] ?? jrp["NETTOBTR"]);
                    if (be != null)
                    {
                        if (belzart != "SUBT" && belzart != "CITAX") // this will lead to problems in the long run.
                        {
                            gNetto += be.Value<decimal>();
                        }
                        else
                        {
                            Steuerbetrag steuerbetrag = new Steuerbetrag()
                            {
                                Basiswert = (jrp["sbasw"] ?? jrp["SBASW"]).Value<decimal>(),
                                Steuerwert = (jrp["sbetw"] ?? jrp["SBETW"]).Value<decimal>(),
                                Waehrung = (Waehrungscode)Enum.Parse(typeof(Waehrungscode), (jrp["twaers"] ?? jrp["TWAERS"]).Value<string>())
                            };
                            decimal steuerProzent;
                            if ((jrp["stprz"] ?? jrp["STPRZ"]) != null && !string.IsNullOrWhiteSpace((jrp["stprz"] ?? jrp["STPRZ"]).Value<string>()))
                            {
                                steuerProzent = decimal.Parse((jrp["stprz"] ?? jrp["STPRZ"]).Value<string>().Replace(",", ".").Trim(), CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                steuerProzent = Math.Round(steuerbetrag.Steuerwert / steuerbetrag.Basiswert * 100.0M);
                            }
                            if (steuerProzent == 19.0M)
                            {
                                steuerbetrag.Steuerkennzeichen = Steuerkennzeichen.UST_19;
                            }
                            else if (steuerProzent == 7.0M)
                            {
                                steuerbetrag.Steuerkennzeichen = Steuerkennzeichen.UST_7;
                            }
                            else
                            {
                                throw new NotImplementedException($"Taxrate Internal '{jrp["taxrateInternal"] ?? jrp["TAXRATE_INTERNAL"]}' is not mapped.");
                            }
                            stList.Add(steuerbetrag);
                            gSteure += be.Value<decimal>();
                        }
                    }
                }
            }
            Steuerbetraege = stList;
            Rechnungspositionen = rpList;
            gBrutto = gNetto + gSteure;
            zZahlen = gBrutto - vGezahlt - rBrutto;
            Gesamtnetto = new Betrag() { Wert = gNetto, Waehrung = waehrungscode };
            Gesamtsteuer = new Betrag() { Wert = gSteure, Waehrung = waehrungscode };
            Gesamtbrutto = new Betrag() { Wert = gBrutto, Waehrung = waehrungscode };
            Zuzahlen = new Betrag() { Wert = zZahlen, Waehrung = waehrungscode };

            Rechnungsersteller = new Geschaeftspartner()
            {
                Geschaeftspartnerrolle = new List<Geschaeftspartnerrolle>() { Geschaeftspartnerrolle.LIEFERANT },
                Gewerbekennzeichnung = true,
                anrede = Anrede.HERR,
                Name1 = "Mein super Lieferant",
                Partneradresse = new Adresse()
                {
                    Strasse = "Max-Plank-Strasse",
                    Hausnummer = "8",
                    Postleitzahl = "90190",
                    Landescode = Landescode.DE,
                    Ort = "Walldorf"
                }
            };
            Rechnungsempfaenger = new Geschaeftspartner()
            {
                Geschaeftspartnerrolle = new List<Geschaeftspartnerrolle>() { Geschaeftspartnerrolle.KUNDE },
                Gewerbekennzeichnung = false,
                anrede = Anrede.HERR,
                Name1 = "Lustig",
                Name2 = "Peter",
                Partneradresse = new Adresse()
                {
                    Strasse = "Magnusstraße",
                    Hausnummer = "20",
                    Postleitzahl = "50672",
                    Landescode = Landescode.DE,
                    Ort = "Köln"
                }
            };
        }
    }
}
