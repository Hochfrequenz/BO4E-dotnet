using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Verbauchsmenge von Marktlokation</summary>
    public class Verbauchsmenge : Menge
    {
        /// <summary>type</summary>
        /// <example>arbeitleistungtagesparameterabhmalo | veranschlagtejahresmenge | TUMKundenwert</example>
        [JsonProperty(Required = Required.Default)]
        public string type;
    }
}
