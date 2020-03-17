using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Diese Komponente liefert die Geokoordinaten für einen Ort.</summary>
    [ProtoContract]
    public class Geokoordinaten : COM
    {
        /// <summary>Gibt den Breitengrad eines entsprechenden Ortes an.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public decimal breitengrad;
        /// <summary>Gibt den Längengrad eines entsprechenden Ortes an.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public decimal laengengrad;
    }
}