using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>
    /// Beschreibt den Grund aus dem eine Berechnungsformel abgelehnt werden kann.
    /// </summary>
    /// <remarks>Orientiert sich am Entscheidungsbaum E_0218 (Cluster Ablehnung)</remarks>
    public enum BerechnungsformelAblehngrund
    {
        /// <summary>Lieferrichtung der Marktlokation ist nicht korrekt</summary>
        /// <remarks>E_0218: A01</remarks>
        [EnumMember(Value = "FALSCHE_LIEFERRICHTUNG_DER_MARKTLOKATION")]
        FALSCHE_LIEFERRICHTUNG_DER_MARKTLOKATION,

        /// <summary>Gültig-Ab Datum der Berechnungsformel ist unplausibel</summary>
        /// <remarks>E_0218: A02</remarks>
        [EnumMember(Value = "START_DATUM_UNPLAUSIBEL")]
        START_DATUM_UNPLAUSIBEL,

        /// <summary>Es sind zu viele Messlokationen in der Berechnungformel vorhanden</summary>
        /// <remarks>E_0218: A04</remarks>
        [EnumMember(Value = "ZU_VIELE_MESSLOKATIONEN")]
        ZU_VIELE_MESSLOKATIONEN,

        /// <summary>Es fehlen Messlokationen in der Berechnungsformel</summary>
        /// <remarks>E_0218: A05</remarks>
        [EnumMember(Value = "FEHLENDE_MESSLOKATIONEN")]
        FEHLENDE_MESSLOKATIONEN,

        /// <summary>ID der Messlokationen stimmen nicht überein</summary>
        /// <remarks>E_0218: A06</remarks>
        [EnumMember(Value = "FALSCHE_MESSLOKATION")]
        FALSCHE_MESSLOKATION,

        /// <summary>Die Flussrichtung mindestens einer Messlokation ist nicht korrekt angegeben</summary>
        /// <remarks>E_0218: A07</remarks>
        [EnumMember(Value = "FALSCHE_FLUSSRICHTUNG_DER_MESSLOKATION")]
        FALSCHE_FLUSSRICHTUNG_DER_MESSLOKATION,

        /// <summary>Der Marktlokation ist nicht genau eine Messlokation zugeordnet</summary>
        /// <remarks>E_0218: A10</remarks>
        [EnumMember(Value = "MARKTLOKATION_IST_NICHT_GENAU_DER_MESSLOKATION_ZUGEORDNET")]
        MARKTLOKATION_IST_NICHT_GENAU_DER_MESSLOKATION_ZUGEORDNET
    }
}
