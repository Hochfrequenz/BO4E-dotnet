using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    /// Ein Sperrauftrag ist das BO, das die Aufforderung des Lieferanten an den Netzbetreiber bzw. Netzstellenbetreiber beschreibt einen Zähler zu sperren.
    /// </summary>
    /// <remarks>
    /// Ein Sperrauftrag wird typischerweise in EDIFACT-Nachrichten des Typs 17115 oder 17116 kommuniziert.
    /// Die Entsperrung erfolgt in einem ähnlich aufgebauten <seealso cref="Entsperrauftrag"/>.
    /// </remarks>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public class Sperrauftrag : Auftrag
    {
        /// <summary>
        /// Handelt es sich um einen Auftrag zum <see cref="ENUM.Sperrauftragsart.SPERREN"/> oder <see cref="ENUM.Sperrauftragsart.ENTSPERREN"/>?
        /// </summary>
        [JsonProperty("sperrauftragsart", Required = Required.Always)]
        [JsonPropertyName("sperrauftragsart")]
        public Sperrauftragsart Sperrauftragsart => Sperrauftragsart.SPERREN;

        /// <summary>
        /// <see cref="ENUM.Sperrauftragsstatus"/>
        /// </summary>
        [JsonProperty("sperrauftragsstatus", Required = Required.Default)]
        [JsonPropertyName("sperrauftragsstatus")]
        public Sperrauftragsstatus? Sperrauftragsstatus { get; set; }

        /// <summary>
        /// Falls <see cref="Sperrauftragsstatus"/> = <see cref="ENUM.Sperrauftragsstatus.ABGELEHNT"/>
        /// </summary>
        [JsonProperty("sperrauftragsablehngrund", Required = Required.Default)]
        [JsonPropertyName("sperrauftragsablehngrund")]
        public Sperrauftragsablehngrund? Sperrauftragsablehnungsgrund { get; set; }

        /// <summary>
        /// Falls <see cref="Sperrauftragsstatus"/> = <see cref="ENUM.Sperrauftragsstatus.GESCHEITERT"/>
        /// </summary>
        [JsonProperty("sperrauftragsverhinderungsgrund", Required = Required.Default)]
        [JsonPropertyName("sperrauftragsverhinderungsgrund")]
        public Sperrauftragsverhinderungsgrund? Sperrauftragsverhinderungsgrund { get; set; }


        /*
        /// <summary>
        /// True, falls der Netzbetreiber die Ansicht des MSB teilt, dass sich gesperrt werden darf.
        /// </summary>
        public bool? NetzbetreiberTeiltClearingEntscheidungDesMsb { get; set; }
        */

        /// <summary>
        /// Die Nummer des zu sperrenden Zählers
        /// </summary>
        [JsonProperty("zaehlernummer", Required = Required.Default)]
        [JsonPropertyName("zaehlernummer")]
        public string Zaehlernummer { get; set; }

        /// <summary>
        /// True, falls die Sperrung vom Gerichtsvollzieher angeordnet ist.
        /// </summary>
        /// <remarks>
        /// Wenn true, dann ist das <see cref="Auftrag.Ausfuehrungsdatum"/> in DTM+469 zu übermitteln.
        /// Wenn false, dann ist das <see cref="Auftrag.Ausfuehrungsdatum"/> in DTM+203 zu übermitteln.
        /// </remarks>
        [JsonProperty("istVomGerichtsvollzieherAngeordnet", Required = Required.Always)]
        [JsonPropertyName("istVomGerichtsvollzieherAngeordnet")]
        public bool IstVomGerichtsvollzieherAngeordnet { get; set; }
    }
}