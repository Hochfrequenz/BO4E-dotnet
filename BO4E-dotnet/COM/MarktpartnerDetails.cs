using BO4E.BO;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System;

namespace BO4E.COM
{
    [Obsolete("This class has been renamed to COM." + nameof(MarktpartnerDetails) + " to avoid further naming confusion.", true)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Marktrolle : MarktpartnerDetails { }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Marktrolle
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    [Obsolete("Please use BO4E.BO." + nameof(Marktteilnehmer) + " instead.")]
    public class MarktpartnerDetails : COM
    {
        /// <summary>
        /// rollencodenummer von Marktrolle
        /// </summary>
        [JsonProperty(PropertyName = "rollencodenummer", Required = Required.Default)]
        [ProtoMember(3)]
        [Obsolete("Use " + nameof(Marktteilnehmer) + "." + nameof(Marktteilnehmer.Rollencodenummer) + " instead")]
        public string Rollencodenummer { get; set; }

        /// <summary>
        /// code von Marktrolle
        /// </summary>
        [JsonProperty(PropertyName = "code", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [Obsolete("Use " + nameof(Marktteilnehmer) + "." + nameof(Marktteilnehmer.Rollencodetyp) + " instead")]
        [ProtoMember(4)]
        public string Code { get; set; }

        /// <summary>
        /// List of Marktrolle. Details siehe <see cref="ENUM.Marktrolle"/>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(5)]
        [Obsolete("Use " + nameof(Marktteilnehmer) + "." + nameof(Marktteilnehmer.Marktrolle) + " instead")]
#pragma warning disable IDE1006 // Naming Styles because Marktrolle is already the name of the enum
        public ENUM.Marktrolle marktrolle { get; set; }

#pragma warning restore IDE1006 // Naming Styles
    }
}