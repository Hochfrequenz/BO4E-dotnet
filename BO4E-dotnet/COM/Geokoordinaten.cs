using Newtonsoft.Json;
namespace BO4E.COM
{
    /// <summary>Diese Komponente liefert die Geokoordinaten für einen Ort.</summary>
    public class Geokoordinaten : COM
    {
        /// <summary>Gibt den Breitengrad eines entsprechenden Ortes an.</summary>
        [JsonProperty(Required = Required.Always)]
        public decimal breitengrad;
        /// <summary>Gibt den Längengrad eines entsprechenden Ortes an.</summary>
        [JsonProperty(Required = Required.Always)]
        public decimal laengengrad;
    }
}