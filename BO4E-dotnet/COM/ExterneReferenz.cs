using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Viele Datenobjekte weisen in unterschiedlichen Systemen eine eindeutige ID (Kundennummer, GP-Nummer etc.) auf.
    /// Beim Austausch von Datenobjekten zwischen verschiedenen Systemen ist es daher hilfreich, sich die eindeutigen IDs der anzubindenden Systeme zu merken.
    /// Diese Komponente ermöglicht es, sich die SAP GP-Nummer zu merken, um diese bei SAP-Aufrufen als Parameter mitgeben zu können.
    /// </summary>
    [ProtoContract]
    public class ExterneReferenz : COM
    {
        /// <summary>
        /// Bezeichnung der externen Referenz (z.B. "hochfrequenz integration services")
        /// </summary>
        [JsonProperty(PropertyName = "exRefName", Required = Required.Always)]
        [ProtoMember(1)]
        public string ExRefName { get; set; }

        /// <summary>
        /// Wert der externen Referenz (z.B. "123456"; "4711")
        /// </summary>
        [JsonProperty(PropertyName = "exRefWert", Required = Required.Always)]
        [ProtoMember(2)]
        public string ExRefWert { get; set; }
    }
}