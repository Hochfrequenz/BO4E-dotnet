using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace BO4E.BO;

///     Objekt zur Aufnahme der Informationen zu einem MabisZaehlpunkt.    
[ProtoContract]
public class MabisZaehlpunkt : BusinessObject
{
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    private static readonly Regex RegexValidate = new(@"[A-Z\d]{33}", RegexOptions.Compiled);

    /// <summary>
    ///     Die MABIS-Zaehlpunktbezeichnung,
    ///     z.B. DE 47108151234567
    /// </summary>
    [DefaultValue("|null|")]
    [JsonProperty(PropertyName = "Id", Required = Required.Always, Order = 10)]
    [JsonPropertyName("Id")]
    [JsonPropertyOrder(10)]
    [DataCategory(DataCategory.POD)]
    [BoKey]
    [ProtoMember(4)]
    public string Id { get; set; }


    /// <summary>
    ///     Test if a <paramref name="id" /> is a valid messlokations ID.
    /// </summary>
    /// <param name="id">id to test</param>
    /// <returns></returns>
    public static bool ValidateId(string id)
    {
        return !string.IsNullOrWhiteSpace(id) && RegexValidate.IsMatch(id);
    }

    /// <summary>
    ///     Test if the <see cref="MabisZaehlpunkt" /> is valid.
    /// </summary>
    /// <returns>if id matches the expected format</returns>
    public bool HasValidId()
    {
        return ValidateId(Id);
    }

    /// <summary>
    ///     same as <see cref="BusinessObject.IsValid()" /> if <paramref name="checkId" /> is false but by default additionally
    ///     checks if the <see cref="MabisZaehlpunkt" /> is valid using <see cref="HasValidId" />.
    /// </summary>
    /// <param name="checkId">validate the <see cref="MabisZaehlpunkt" />, too</param>
    /// <returns>true if the zaehlpunkt is valid</returns>
    public bool IsValid(bool checkId = true)
    {
        return base.IsValid() && (!checkId || HasValidId());
    }
}
