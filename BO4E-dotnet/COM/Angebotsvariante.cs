using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Führt die verschiedenen Ausprägungen der Angebotsberechnung auf.</summary>
    public class Angebotsvariante : COM
    {
        /// <summary>Gibt den Status eines Angebotes an. <seealso cref="Angebotsstatus" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Angebotsstatus angebotsstatus;
        /// <summary>Umschreibung des Inhalts der Angebotsvariante.</summary>
        [JsonProperty(Required = Required.Default)]
        public string beschreibung;
        /// <summary>Datum der Erstellung der Angebotsvariante</summary>
        [JsonProperty(Required = Required.Default)]
        public DateTime erstelldatum; // Todo implement "date"
        /// <summary>Bis zu diesem Zeitpunkt (Tag/Uhrzeit) inklusive gilt die Angebotsvariante, z.B. 31.12.2017, 17:00 Uhr.</summary>
        [JsonProperty(Required = Required.Always)]
        public DateTime bindefrist;
        /// <summary>Aufsummierte Wirkarbeitsmenge aller Angebotsteile. <seealso cref="Menge" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Menge gesamtmenge;
        /// <summary>Aufsummierte Kosten aller Angebotsteile. <seealso cref="Betrag" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Betrag gesamtkosten;
        /// <summary>Angebotsteile werden im einfachsten Fall für eine Marktlokation oder Lieferstellenadresse erzeugt. Hier werden die Mengen und Gesamtkosten aller Angebotspositionen zusammengefasst. Eine Variante besteht mindestens aus einem Angebotsteil. Details <see cref="Angebotsteil" /></summary>
        [JsonProperty(Required = Required.Always)]
        [MinLength(1)]
        public List<Angebotsteil> teile;
    }
}