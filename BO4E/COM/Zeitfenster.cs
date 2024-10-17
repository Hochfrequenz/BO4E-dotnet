using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
/// Ein Zeitfenster mit Start- und Endzeiten mit <see cref="TimeOnly"/> als Typ.
/// </summary>
[ProtoContract]
public class Zeitfenster : COM
{
    /// <summary>inklusive Startzeit; z.B. 8 Uhr</summary>
    [JsonProperty(Order = 3, PropertyName = "startzeit")]
    [JsonPropertyName("startzeit")]
    [JsonPropertyOrder(3)]
    [ProtoMember(3)]
    public TimeOnly? Startzeit { get; set; }

    /// <summary>exklusive Endzeit (z.B. 17:00 Uhr)</summary>
    [JsonProperty(Order = 4, PropertyName = "endzeit")]
    [JsonPropertyName("endzeit")]
    [JsonPropertyOrder(4)]
    [ProtoMember(4)]
    public TimeOnly? Endzeit { get; set; }

    /// <summary>
    /// Erstellt eine neue Instanz von Zeitfenster mit spezifischen Start- und Endzeiten.
    /// </summary>
    /// <param name="startzeit">inklusive Startzeit</param>
    /// <param name="endzeit">exklusive Endzeit</param>
    public Zeitfenster(TimeOnly startzeit, TimeOnly endzeit)
    {
        Startzeit = startzeit;
        Endzeit = endzeit;
    }

    /// <summary>
    /// Parameterloser Konstruktor für Serialisierungszwecke
    /// </summary>
    public Zeitfenster() { }

    /// <summary>
    /// Erstellt eine neue Instanz von Zeitfenster basierend auf einem String im Format "HHMMHHMM".
    /// </summary>
    /// <param name="zeitfensterString">Ein String im Format "HHMMHHMM".</param>
    public Zeitfenster(string zeitfensterString)
    {
        if (zeitfensterString.Length != 8)
        {
            throw new ArgumentException("Der Zeitfenster-String muss genau 8 Zeichen lang sein.");
        }

        try
        {
            Startzeit = TimeOnly.ParseExact(zeitfensterString.Substring(0, 4), "HHmm");
            Endzeit = TimeOnly.ParseExact(zeitfensterString.Substring(4, 4), "HHmm");
        }
        catch (FormatException)
        {
            throw new ArgumentException(
                "Der Zeitfenster-String muss im Format HHMMHHMM vorliegen und gültige Zeitwerte enthalten."
            );
        }
    }
}
