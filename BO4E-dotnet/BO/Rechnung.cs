using System;
using System.Collections.Generic;
using System.Globalization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BO4E.BO
{
    /// <summary>
    /// Modell für die Abbildung von Rechnungen im Kontext der Energiewirtschaft. Ausgehend von diesem Basismodell werden weitere spezifische Formen abgeleitet.
    /// https://www.bo4e.de/dokumentation/geschaeftsobjekte/bo-rechnung
    /// </summary>
    /// 	
    /// 

    public class Rechnung : BusinessObject
    {
        /// <summary>
        /// Bezeichnung für die vorliegende Rechnung.
        /// </summary>
        /// 
        [JsonProperty(Required = Required.Default)]
        [FieldName("billTitle", Language.EN)]
        public string rechnungstitel;

        /// <summary>
        /// Status der Rechnung zur Kennzeichnung des Bearbeitungsstandes. Details siehe ENUM Rechnungsstatus
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("billStatus", Language.EN)]
        public Rechnungsstatus rechnungsstatus;

        /// <summary>
        /// Kennzeichnung, ob es sich um eine Stornorechnung handelt. Im Falle "true" findet sich im Attribut "originalrechnungsnummer" die Nummer der Originalrechnung.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("isCancellation", Language.EN)]
        public bool storno;

        /// <summary>
        /// Eine im Verwendungskontext eindeutige Nummer für die Rechnung.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [BoKey]
        [FieldName("billNumber", Language.EN)]
        public string rechnungsnummer;

        /// <summary>
        /// Ausstellungsdatum der Rechnung.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("billDate", Language.EN)]
        public DateTime rechnungsdatum;

        /// <summary>
        /// Zu diesem Datum ist die Zahlung fällig.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("dueDate", Language.EN)]
        public DateTime faelligkeitsdatum;

        /// <summary>
        /// Ein kontextbezogender Rechnungstyp, z.B. Netznutzungsrechnung. Details siehe ENUM Rechnungstyp
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("billType", Language.EN)]
        public Rechnungstyp rechnungsstyp;

        /// <summary>
        /// Im Falle einer Stornorechnung (storno = true) steht hier die Rechnungsnummer der stornierten Rechnung.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string originalRechnungsnummer;

        /// <summary>
        /// Der Zeitraum der zugrunde liegenden Lieferung zur Rechnung. In der COM Zeitraum können diese angegeben werden.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("billPeriod", Language.EN)]
        public Zeitraum rechnungsperiode;

        /// <summary>
        /// Der Aussteller der Rechnung. Details <see cref="Geschaeftspartner"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("issuer", Language.EN)]
        public Geschaeftspartner rechnungsersteller;

        /// <summary>
        /// Der Empfänger der Rechnung. Details <see cref="Geschaeftspartner"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("recipient", Language.EN)]
        public Geschaeftspartner rechnungsempfaenger;

        /// <summary>
        /// Die Summe der Nettobeträge der Rechnungsteile. Details <see cref="Betrag"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("totalNet", Language.EN)]
        public Betrag gesamtnetto;

        /// <summary>
        /// Die Summe der Steuerbeträge der Rechnungsteile. Details <see cref="Betrag"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("totalTax", Language.EN)]
        public Betrag gesamtsteuer;

        /// <summary>
        /// Die Summe aus Netto- und Steuerbetrag. Details <see cref="Betrag"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("totalGross", Language.EN)]
        public Betrag gesamtbrutto;

        /// <summary>
        /// Die Summe evtl. vorausgezahlter Beträge, z.B. Abschläge. Angabe als Bruttowert. Details <see cref="Betrag"/>
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("prepaid", Language.EN)]
        public Betrag vorausgezahlt;

        /// <summary>
        /// Gesamtrabatt auf den Bruttobetrag. Details <see cref="Betrag"/>
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("discountGross", Language.EN)]
        public Betrag rabattBrutto;

        /// <summary>
        /// Der zu zahlende Betrag, der sich aus (<see cref="gesamtbrutto"/> - <see cref="vorausgezahlt"/> - <see cref="rabattBrutto"/>) ergibt. Details <see cref="Betrag"/>
        /// /// </summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("toPay", Language.EN)]
        public Betrag zuzahlen;

        /// <summary>
        /// Eine Liste mit Steuerbeträgen pro Steuerkennzeichen/Steuersatz. Die Summe dieser Beträge ergibt den Wert für gesamtsteuer. Details <see cref="Steuerbetrag"/>
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("taxList", Language.EN)]
        public List<Steuerbetrag> steuerbetraege;

        /// <summary>
        /// Die Rechnungspositionen. Details siehe <see cref="Rechnungsposition"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [FieldName("invoiceItemList", Language.EN)]
        public List<Rechnungsposition> rechnungspositionen;

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

            rechnungsnummer = (infoToken["opbel"] ?? infoToken["OPBEL"]).Value<string>();
            rechnungsdatum = TimeZoneInfo.ConvertTime((infoToken["bldat"] ?? infoToken["BLDAT"]).Value<DateTime>(), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME, TimeZoneInfo.Utc);
            rechnungsperiode = new Zeitraum()
            {
                startdatum = TimeZoneInfo.ConvertTime((tErdzToken[0]["ab"] ?? tErdzToken[0]["AB"]).Value<DateTime>(), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME, TimeZoneInfo.Utc),
                enddatum = TimeZoneInfo.ConvertTime((tErdzToken[0]["bis"] ?? tErdzToken[0]["BIS"]).Value<DateTime>(), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME, TimeZoneInfo.Utc)
            };
            faelligkeitsdatum = TimeZoneInfo.ConvertTime((infoToken["faedn"] ?? infoToken["FAEDN"]).Value<DateTime>(), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME, TimeZoneInfo.Utc);
            storno = false;

            decimal gNetto, gSteure, gBrutto, vGezahlt, rBrutto, zZahlen;
            gNetto = gSteure = gBrutto = vGezahlt = rBrutto = zZahlen = 0.00M;
            Waehrungscode waehrungscode = (Waehrungscode)Enum.Parse(typeof(Waehrungscode), (infoToken["totalWaer"] ?? infoToken["TOTAL_WAER"]).Value<string>());
            Waehrungseinheit waehrungseinheit = (Waehrungseinheit)Enum.Parse(typeof(Waehrungseinheit), (infoToken["totalWaer"] ?? infoToken["TOTAL_WAER"]).Value<string>());
            Mengeneinheit mengeneinheit = (Mengeneinheit)Enum.Parse(typeof(Mengeneinheit), (tErdzToken[0]["massbill"] ?? tErdzToken[0]["MASSBILL"]).Value<string>());

            List<Rechnungsposition> rpList = new List<Rechnungsposition>();
            List<Steuerbetrag> stList = new List<Steuerbetrag>();
            vorausgezahlt = new Betrag() { waehrung = waehrungscode, wert = 0 };
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
                        rp.positionstext = "ARBEITSPREIS";
                    }
                    else if (belzart == "000003")
                    {
                        rp.positionstext = "PAUSCHALE";
                        mengeneinheit = Mengeneinheit.JAHR;
                        zeitbezogeneMengeWert = (jrp["preisbtr"] ?? jrp["PREISBTR"]).Value<decimal>();
                        rp.zeitbezogeneMenge = new Menge() { einheit = Mengeneinheit.TAG, wert = zeitbezogeneMengeWert };

                        rp.einzelpreis = new Preis()
                        {
                            wert = decimal.Parse((jrp["zeitant"] ?? jrp["ZEITANT"]).ToString()),
                            einheit = waehrungseinheit,
                            bezugswert = mengeneinheit
                        };
                    }
                    else if (belzart == "000004")
                        rp.positionstext = "VERRECHNUNGSPREIS";
                    else if (belzart == "SUBT")
                        rp.positionstext = "zuzüglich Mehrwertsteuer 19,000%";
                    else if (belzart == "ZHFBP1" || belzart == "CITAX")
                        rp.positionstext = belzart;
                    else
                        rp.positionstext = "";

                    if ((jrp["massbill"] ?? jrp["MASSBILL"]) != null && !string.IsNullOrWhiteSpace((jrp["massbill"] ?? jrp["MASSBILL"]).Value<string>()))
                    {
                        mengeneinheit = (Mengeneinheit)Enum.Parse(typeof(Mengeneinheit), (jrp["massbill"] ?? jrp["MASSBILL"]).Value<string>());
                    }
                    else if ((jrp["timbasis"] ?? jrp["TIMBASIS"]) != null && !string.IsNullOrWhiteSpace((jrp["timbasis"] ?? jrp["TIMBASIS"]).Value<string>()))
                    {
                        if ((jrp["timbasis"] ?? jrp["TIMBASIS"]).Value<string>() == "365")
                        {
                            mengeneinheit = Mengeneinheit.JAHR;
                            rp.zeitbezogeneMenge = new Menge() { einheit = Mengeneinheit.TAG, wert = zeitbezogeneMengeWert };
                        }
                    }
                    else
                    {
                        mengeneinheit = Mengeneinheit.KWH;
                    }

                    if (rp.einzelpreis == null)
                    {
                        if ((jrp["preisbtr"] ?? jrp["PREISBTR"]) != null)
                        {
                            rp.einzelpreis = new Preis()
                            {
                                wert = decimal.Parse((jrp["preisbtr"] ?? jrp["PREISBTR"]).ToString()),
                                einheit = waehrungseinheit,
                                bezugswert = mengeneinheit
                            };
                        }
                        else
                            rp.einzelpreis = new Preis()
                            {
                                wert = 0,
                                einheit = waehrungseinheit,
                                bezugswert = mengeneinheit
                            };
                    }


                    rp.positionsnummer = (jrp["belzeile"] ?? jrp["BELZEILE"]).Value<int>();
                    if ((jrp["bis"] ?? jrp["BIS"]) != null && (jrp["bis"] ?? jrp["BIS"]).Value<string>() != "0000-00-00")
                    {
                        rp.lieferungBis = TimeZoneInfo.ConvertTime((jrp["bis"] ?? jrp["BIS"]).Value<DateTime>(), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME, TimeZoneInfo.Utc);
                    }
                    if ((jrp["ab"] ?? jrp["AB"]) != null && (jrp["ab"] ?? jrp["AB"]).Value<string>() != "0000-00-00")
                    {
                        rp.lieferungVon = TimeZoneInfo.ConvertTime((jrp["ab"] ?? jrp["AB"]).Value<DateTime>(), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME, TimeZoneInfo.Utc);
                    }
                    if ((jrp["vertrag"] ?? jrp["VERTRAG"]) != null)
                    {
                        rp.vertragskontoId = (jrp["vertrag"] ?? jrp["VERTRAG"]).Value<string>();
                    }

                    if ((jrp["iAbrmenge"] ?? jrp["I_ABRMENGE"]) != null)
                    {
                        rp.positionsMenge = new Menge()
                        {
                            wert = (jrp["iAbrmenge"] ?? jrp["I_ABRMENGE"]).Value<decimal>(),
                            einheit = mengeneinheit
                        };
                    }

                    if ((jrp["nettobtr"] ?? jrp["NETTOBTR"]) != null)
                    {
                        if (belzart != "SUBT" && belzart != "CITAX")
                        {
                            rp.teilsummeNetto = new Betrag()
                            {
                                wert = (jrp["nettobtr"] ?? jrp["NETTOBTR"]).Value<decimal>(),
                                waehrung = waehrungscode
                            };
                        }
                        else
                        {
                            rp.teilsummeNetto = new Betrag()
                            {
                                wert = (jrp["sbasw"] ?? jrp["SBASW"]).Value<decimal>(),
                                waehrung = waehrungscode
                            };
                            Steuerbetrag steuerbetrag = new Steuerbetrag()
                            {
                                basiswert = (jrp["sbasw"] ?? jrp["SBASW"]).Value<decimal>(),
                                steuerwert = (jrp["sbetw"] ?? jrp["SBETW"]).Value<decimal>(),
                                waehrung = (Waehrungscode)Enum.Parse(typeof(Waehrungscode), (jrp["twaers"] ?? jrp["TWAERS"]).Value<string>())
                            };
                            decimal steuerProzent;
                            if ((jrp["stprz"] ?? jrp["STPRZ"]) != null && !string.IsNullOrWhiteSpace((jrp["stprz"] ?? jrp["STPRZ"]).Value<string>()))
                            {
                                steuerProzent = decimal.Parse((jrp["stprz"] ?? jrp["STPRZ"]).Value<string>().Replace(",", ".").Trim(), CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                steuerProzent = steuerbetrag.steuerwert / steuerbetrag.basiswert * 100.0M;
                            }
                            if ((int)steuerProzent == 19)
                            {
                                steuerbetrag.steuerkennzeichen = Steuerkennzeichen.UST_19;
                            }
                            else if ((int)steuerProzent == 7)
                            {
                                steuerbetrag.steuerkennzeichen = Steuerkennzeichen.UST_7;
                            }
                            else
                            {
                                throw new NotImplementedException($"Taxrate Internal '{jrp["taxrateInternal"]}' is not mapped.");
                            }
                            rp.teilsummeSteuer = steuerbetrag;
                        }
                        if ((jrp["nettobtr"] ?? jrp["NETTOBTR"]).Value<decimal>() <= 0)
                        {
                            vorausgezahlt = new Betrag() { waehrung = waehrungscode, wert = (jrp["nettobtr"] ?? jrp["NETTOBTR"]).Value<decimal>() };
                        }
                    }

                    rp.zeiteinheit = mengeneinheit;
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
                                basiswert = (jrp["sbasw"] ?? jrp["SBASW"]).Value<decimal>(),
                                steuerwert = (jrp["sbetw"] ?? jrp["SBETW"]).Value<decimal>(),
                                waehrung = (Waehrungscode)Enum.Parse(typeof(Waehrungscode), (jrp["twaers"] ?? jrp["TWAERS"]).Value<string>())
                            };
                            decimal steuerProzent;
                            if ((jrp["stprz"] ?? jrp["STPRZ"]) != null && !string.IsNullOrWhiteSpace((jrp["stprz"] ?? jrp["STPRZ"]).Value<string>()))
                            {
                                steuerProzent = decimal.Parse((jrp["stprz"] ?? jrp["STPRZ"]).Value<string>().Replace(",", ".").Trim(), CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                steuerProzent = Math.Round(steuerbetrag.steuerwert / steuerbetrag.basiswert * 100.0M);
                            }
                            if (steuerProzent == 19.0M)
                            {
                                steuerbetrag.steuerkennzeichen = Steuerkennzeichen.UST_19;
                            }
                            else if (steuerProzent == 7.0M)
                            {
                                steuerbetrag.steuerkennzeichen = Steuerkennzeichen.UST_7;
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
            steuerbetraege = stList;
            rechnungspositionen = rpList;
            gBrutto = gNetto + gSteure;
            zZahlen = gBrutto - vGezahlt - rBrutto;
            gesamtnetto = new Betrag() { wert = gNetto, waehrung = waehrungscode };
            gesamtsteuer = new Betrag() { wert = gSteure, waehrung = waehrungscode };
            gesamtbrutto = new Betrag() { wert = gBrutto, waehrung = waehrungscode };
            zuzahlen = new Betrag() { wert = zZahlen, waehrung = waehrungscode };

            rechnungsersteller = new Geschaeftspartner()
            {
                geschaeftspartnerrolle = new List<Geschaeftspartnerrolle>() { Geschaeftspartnerrolle.LIEFERANT },
                gewerbekennzeichnung = true,
                anrede = Anrede.HERR,
                name1 = "Mein super Lieferant",
                partneradresse = new Adresse()
                {
                    strasse = "Max-Plank-Strasse",
                    hausnummer = "8",
                    postleitzahl = "90190",
                    landescode = Landescode.DE,
                    ort = "Walldorf"
                }
            };
            rechnungsempfaenger = new Geschaeftspartner()
            {
                geschaeftspartnerrolle = new List<Geschaeftspartnerrolle>() { Geschaeftspartnerrolle.KUNDE },
                gewerbekennzeichnung = false,
                anrede = Anrede.HERR,
                name1 = "Lustig",
                name2 = "Peter",
                partneradresse = new Adresse()
                {
                    strasse = "Magnusstraße",
                    hausnummer = "20",
                    postleitzahl = "50672",
                    landescode = Landescode.DE,
                    ort = "Köln"
                }
            };
        }
    }
}
