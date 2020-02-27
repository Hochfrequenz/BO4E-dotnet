using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.BO
{

    // The key order is actually relevant for the online validation. WTF!
    // Todo: Fix the (at the moment still random) order.
    /// <summary>
    /// Mit diesem Geschäftsobjekt wird die Information zu einem Zähler abgebildet.
    /// </summary>
    public class Zaehler : BusinessObject
    {
        /// <summary>Nummerierung des Zählers, vergeben durch den Messstellenbetreiber</summary>
        [BoKey]
        [JsonProperty(Required = Required.Always)]
        public string zaehlernummer;

        /// <summary>Strom oder Gas. <seealso cref="Sparte" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Sparte sparte;

        /// <summary>Spezifikation die Richtung des Zählers betreffend.
        /// <seealso cref="Zaehlerauspraegung" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Zaehlerauspraegung zaehlerauspraegung;

        /// <summary>Typisierung des Zählers
        /// <seealso cref="Zaehlertyp" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Zaehlertyp zaehlertyp;

        /// <summary> Spezifikation bezüglich unterstützter Tarifarten.
        /// <seealso cref="Tarifart" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Tarifart tarifart;

        /// <summary>Zählerkonstante auf dem Zähler.</summary>
        [JsonProperty(Required = Required.Default)]
        public Decimal zaehlerkonstante;

        /// <summary>Bis zu diesem Datum ist der Zähler geeicht.</summary>
        [JsonProperty(Required = Required.Default)]
        public string eichungBis; // ToDO implement date

        /// <summary>Zu diesem Datum fand die letzte Eichprüfung des Zählers statt.</summary>
        [JsonProperty(Required = Required.Default)]
        public string letzteEichung; // ToDo: implement date

        /// <summary> Die Zählwerke des Zählers.
        /// <seealso cref="Zaehlwerk" /></summary>
        [JsonProperty(Required = Required.Always)]
        [MinLength(1)]
        public List<Zaehlwerk> zaehlwerke;

        /// <summary>Der Hersteller des Zählers. Details <see cref="Geschaeftspartner" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Geschaeftspartner zaehlerhersteller;

        /// <summary>
        /// Referenz auf das Smartmeter-Gateway
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string gateway;

        /// <summary>
        /// Fernschaltung
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public Fernschaltung fernschaltung;

        /// <summary>
        /// Messwerterfassung am Zählpunkt
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public Messwerterfassung messwerterfassung;
    }
}
