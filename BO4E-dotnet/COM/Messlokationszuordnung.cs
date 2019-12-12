using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente werden Messlokationen zu Marktlokationen zugeordnet. Dabei kann eine arithmetische Operation (Addition, Subtraktion) angegeben werden, mit der die Messlokation zum Verbrauch der Marklokation beiträgt.</summary>
    public class Messlokationszuordnung : COM
    {
        /// <summary>Die Messlokations-ID, früher die Zählpunktbezeichnung.</summary>
        [DataCategory(DataCategory.POD)]
        [JsonProperty(Required = Required.Always)]
        public string messlokationsId;
        /// <summary>Die Operation, mit der eine Messung an dieser Lokation für den Gesamtverbrauch der Marktlokation verrechnet wird. Beispielsweise bei einer Untermessung, wird der Verbauch der Untermessung subtrahiert. Details <see cref="ArithmetischeOperation" /></summary>
        [JsonProperty(Required = Required.Default)] // Default weil Hochfrequenz/energy-service-hub#35
        public ArithmetischeOperation arithmetik;
        /// <summary>Zeitpunkt, ab dem die Messlokation zur Marktlokation gehört</summary>
        [JsonProperty(Required = Required.Default)]
        public string gueltigSeit;
        /// <summary>Zeitpunkt, bis zu dem die Messlokation zur Marktlokation gehört</summary>
        [JsonProperty(Required = Required.Default)]
        public string gueltigBis;
    }
}