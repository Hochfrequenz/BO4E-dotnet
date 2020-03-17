using System;
using System.Collections.Generic;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Führt die verschiedenen Ausprägungen der Angebotsberechnung auf.</summary>
    [ProtoContract]
    public class Angebotsvariante : COM
    {
        /// <summary>Gibt den Status eines Angebotes an. <seealso cref="Angebotsstatus" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public Angebotsstatus angebotsstatus;
        /// <summary>Umschreibung des Inhalts der Angebotsvariante.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(5)]
        public string beschreibung;
        /// <summary>Datum der Erstellung der Angebotsvariante</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(6)]
        public DateTime erstelldatum;
        /// <summary>Bis zu diesem Zeitpunkt (Tag/Uhrzeit) inklusive gilt die Angebotsvariante, z.B. 31.12.2017, 17:00 Uhr.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(7)]
        public DateTime bindefrist;
        /// <summary>Aufsummierte Wirkarbeitsmenge aller Angebotsteile. <seealso cref="Menge" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(8)]
        public Menge gesamtmenge;
        /// <summary>Aufsummierte Kosten aller Angebotsteile. <seealso cref="Betrag" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(9)]
        public Betrag gesamtkosten;
        /// <summary>Angebotsteile werden im einfachsten Fall für eine Marktlokation oder Lieferstellenadresse erzeugt. Hier werden die Mengen und Gesamtkosten aller Angebotspositionen zusammengefasst. Eine Variante besteht mindestens aus einem Angebotsteil. Details <see cref="Angebotsteil" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(10)]
        public List<Angebotsteil> teile;
    }
}