using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Produktcode</summary>
public enum Produktcode
{
    /// <summary>9991000002082</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(BILANZKREIS))]
    [EnumMember(Value = "BILANZKREIS")]
    BILANZKREIS,

    /// <summary>9991000002090</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(TRANCHENGROESSE))]
    [EnumMember(Value = "TRANCHENGROESSE")]
    TRANCHENGROESSE,

    /// <summary>9991000003014</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(PROZENTUALE_AUFTEILUNG))]
    [EnumMember(Value = "PROZENTUALE_AUFTEILUNG")]
    PROZENTUALE_AUFTEILUNG,

    /// <summary>9991 00000 302 2 </summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(AUFTEILUNGSFAKTOR))]
    [EnumMember(Value = "AUFTEILUNGSFAKTOR")]
    AUFTEILUNGSFAKTOR,

    /// <summary>9991 00000 200 8</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(MESSTECHNISCHE_EINORDNUNG))]
    [EnumMember(Value = "MESSTECHNISCHE_EINORDNUNG")]
    MESSTECHNISCHE_EINORDNUNG,

    /// <summary>9991 00000 210 7</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(INTELLIGENTES_MESSSYSTEM))]
    [EnumMember(Value = "INTELLIGENTES_MESSSYSTEM")]
    INTELLIGENTES_MESSSYSTEM,

    /// <summary>9991 00000 211 5 </summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(KME_MME))]
    [EnumMember(Value = "KME_MME")]
    KME_MME,

    /// <summary>9991 00000 212 3 </summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(KEINE_MESSUNG))]
    [EnumMember(Value = "KEINE_MESSUNG")]
    KEINE_MESSUNG,

    /// <summary>9991 00000 272 7</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(VERBRAUCHSART))]
    [EnumMember(Value = "VERBRAUCHSART")]
    VERBRAUCHSART,

    /// <summary>9991 00000 278 5</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(KRAFT_LICHT))]
    [EnumMember(Value = "KRAFT_LICHT")]
    KRAFT_LICHT,

    /// <summary>9991 00000 279 3</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(WAERME_KAELTE))]
    [EnumMember(Value = "WAERME_KAELTE")]
    WAERME_KAELTE,

    /// <summary>9991 00000 280 0</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(EMOBILITAET))]
    [EnumMember(Value = "EMOBILITAET")]
    EMOBILITAET,

    /// <summary>9991 00000 281 8</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(STRASSENBELEUCHTUNG))]
    [EnumMember(Value = "STRASSENBELEUCHTUNG")]
    STRASSENBELEUCHTUNG,

    /// <summary>9991 00000 282 6</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(STEUERUNG_WAERMEABGABE))]
    [EnumMember(Value = "STEUERUNG_WAERMEABGABE")]
    STEUERUNG_WAERMEABGABE,

    /// <summary>9991 00000 273 5</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(WAERMENUTZUNG))]
    [EnumMember(Value = "WAERMENUTZUNG")]
    WAERMENUTZUNG,

    /// <summary>9991 00000 283 4</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(SPEICHERHEIZUNG))]
    [EnumMember(Value = "SPEICHERHEIZUNG")]
    SPEICHERHEIZUNG,

    /// <summary>9991 00000 284 2 </summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(WAERMEPUMPE))]
    [EnumMember(Value = "WAERMEPUMPE")]
    WAERMEPUMPE,

    /// <summary>9991 00000 285 0</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(DIREKTHEIZUNG))]
    [EnumMember(Value = "DIREKTHEIZUNG")]
    DIREKTHEIZUNG,

    /// <summary>9991 00000 286 8</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(WAERMEPUMPE_WAERME_KAELTE))]
    [EnumMember(Value = "WAERMEPUMPE_WAERME_KAELTE")]
    WAERMEPUMPE_WAERME_KAELTE,

    /// <summary>9991 00000 287 6</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(WAERMEPUMPE_KAELTE))]
    [EnumMember(Value = "WAERMEPUMPE_KAELTE")]
    WAERMEPUMPE_KAELTE,

    /// <summary>9991 00000 288 4</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(WAERMEPUMPE_WAERME))]
    [EnumMember(Value = "WAERMEPUMPE_WAERME")]
    WAERMEPUMPE_WAERME,

    /// <summary>9991 00000 274 3</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(ART_EMOBILITAET))]
    [EnumMember(Value = "ART_EMOBILITAET")]
    ART_EMOBILITAET,

    /// <summary>9991 00000 289 2</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(WALLBOX))]
    [EnumMember(Value = "WALLBOX")]
    WALLBOX,

    /// <summary>9991 00000 290 9 </summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(LADESAEULE))]
    [EnumMember(Value = "LADESAEULE")]
    LADESAEULE,

    /// <summary>9991 00000 291 7</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(LADEPARK))]
    [EnumMember(Value = "LADEPARK")]
    LADEPARK,

    /// <summary>9991 00000 275 1</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(STEUERBARE_RESSOURCE))]
    [EnumMember(Value = "STEUERBARE_RESSOURCE")]
    STEUERBARE_RESSOURCE,

    /// <summary>9991 00000 292 5 </summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(STEUERBARE_RESSOURCE_VORHANDEN))]
    [EnumMember(Value = "STEUERBARE_RESSOURCE_VORHANDEN")]
    STEUERBARE_RESSOURCE_VORHANDEN,

    /// <summary>9991 00000 277 7</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(EIGENSCHAFT_MARKTLOKATION))]
    [EnumMember(Value = "EIGENSCHAFT_MARKTLOKATION")]
    EIGENSCHAFT_MARKTLOKATION,

    /// <summary>9991 00000 294 1</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(KUNDENANLAGE))]
    [EnumMember(Value = "KUNDENANLAGE")]
    KUNDENANLAGE,

    /// <summary>9991 00000 302 0</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(KEINE_KUNDENANLAGE))]
    [EnumMember(Value = "KEINE_KUNDENANLAGE")]
    KEINE_KUNDENANLAGE,

    /// <summary>9991 00000 201 6</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(NETZENTGELTE_NETZORIENTIERTE_STEUERUNG))]
    [EnumMember(Value = "NETZENTGELTE_NETZORIENTIERTE_STEUERUNG")]
    NETZENTGELTE_NETZORIENTIERTE_STEUERUNG,

    /// <summary>9991 00000 213 1</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(PAUSCHALE_REDUZIERUNG_MODUL_1))]
    [EnumMember(Value = "PAUSCHALE_REDUZIERUNG_MODUL_1")]
    PAUSCHALE_REDUZIERUNG_MODUL_1,

    /// <summary>9991 00000 214 9</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(PROZENTUALE_REDUZIERUNG_AP_MODUL_2))]
    [EnumMember(Value = "PROZENTUALE_REDUZIERUNG_AP_MODUL_2")]
    PROZENTUALE_REDUZIERUNG_AP_MODUL_2,

    /// <summary>9991 00000 215 7</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(ANZREIZMODUL_3))]
    [EnumMember(Value = "ANZREIZMODUL_3")]
    ANZREIZMODUL_3,

    /// <summary>9991 00000 202 4</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(NETZENTGELTE_PREISSYSTEM))]
    [EnumMember(Value = "NETZENTGELTE_PREISSYSTEM")]
    NETZENTGELTE_PREISSYSTEM,

    /// <summary>9991 00000 216 5</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(JAHRESLEISTUNG))]
    [EnumMember(Value = "JAHRESLEISTUNG")]
    JAHRESLEISTUNG,

    /// <summary>9991 00000 217 3</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(MONATSLEISTUNG))]
    [EnumMember(Value = "MONATSLEISTUNG")]
    MONATSLEISTUNG,

    /// <summary>9991 00000 218 1</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(GRUNDPREIS_ARBEITSPREIS))]
    [EnumMember(Value = "GRUNDPREIS_ARBEITSPREIS")]
    GRUNDPREIS_ARBEITSPREIS,

    /// <summary>9991 00000 219 9</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(TAGESLEISTUNG))]
    [EnumMember(Value = "TAGESLEISTUNG")]
    TAGESLEISTUNG,

    /// <summary>9991 00000 203 2</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(KONZESSIONSABGABE))]
    [EnumMember(Value = "KONZESSIONSABGABE")]
    KONZESSIONSABGABE,

    /// <summary>9991 00000 295 9</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(TARIFKUNDE))]
    [EnumMember(Value = "TARIFKUNDE")]
    TARIFKUNDE,

    /// <summary>9991 00000 296 7</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(SONDERVERTRAGSKUNDE))]
    [EnumMember(Value = "SONDERVERTRAGSKUNDE")]
    SONDERVERTRAGSKUNDE,

    /// <summary>9991 00000 220 6</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(SCHWACHLAST_KA))]
    [EnumMember(Value = "SCHWACHLAST_KA")]
    SCHWACHLAST_KA,

    /// <summary>9991 00000 297 5</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(BEFREIUNG))]
    [EnumMember(Value = "BEFREIUNG")]
    BEFREIUNG,

    /// <summary>9991 00000 204 0</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(NETZNUTZUNGSVERTRAG))]
    [EnumMember(Value = "NETZNUTZUNGSVERTRAG")]
    NETZNUTZUNGSVERTRAG,

    /// <summary>9991 00000 222 2</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(DIREKTER_VERTRAG))]
    [EnumMember(Value = "DIREKTER_VERTRAG")]
    DIREKTER_VERTRAG,

    /// <summary>9991 00000 223 0</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(VERTRAG_MIT_LIEFERANT))]
    [EnumMember(Value = "VERTRAG_MIT_LIEFERANT")]
    VERTRAG_MIT_LIEFERANT,

    /// <summary>9991 00000 205 8</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(ZAHLER_NETZNUTZUNG))]
    [EnumMember(Value = "ZAHLER_NETZNUTZUNG")]
    ZAHLER_NETZNUTZUNG,

    /// <summary>9991 00000 224 8</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(ZAHLER_KUNDE))]
    [EnumMember(Value = "ZAHLER_KUNDE")]
    ZAHLER_KUNDE,

    /// <summary>9991 00000 225 6</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(ZAHLER_LIEFERANT))]
    [EnumMember(Value = "ZAHLER_LIEFERANT")]
    ZAHLER_LIEFERANT,

    /// <summary>9991 00000 206 6</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(EMPFAENGER_VERGUETUNG))]
    [EnumMember(Value = "EMPFAENGER_VERGUETUNG")]
    EMPFAENGER_VERGUETUNG,

    /// <summary>9991 00000 226 4 </summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(EMPFAENGER_KUNDE))]
    [EnumMember(Value = "EMPFAENGER_KUNDE")]
    EMPFAENGER_KUNDE,

    /// <summary>9991 00000 227 2 </summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(EMPFAENGER_LIEFERANT))]
    [EnumMember(Value = "EMPFAENGER_LIEFERANT")]
    EMPFAENGER_LIEFERANT,

    /// <summary>9991 00000 207 4 </summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(PROGNOSEGRUNDLAGE))]
    [EnumMember(Value = "PROGNOSEGRUNDLAGE")]
    PROGNOSEGRUNDLAGE,

    /// <summary>9991 00000 228 0 </summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(PROFILE))]
    [EnumMember(Value = "PROFILE")]
    PROFILE,

    /// <summary>9991 00000 229 8</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(WERTE))]
    [EnumMember(Value = "WERTE")]
    WERTE,

    /// <summary>9991 00000 239 7</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(JAHRESVERBRAUCHSPROGNOSE))]
    [EnumMember(Value = "JAHRESVERBRAUCHSPROGNOSE")]
    JAHRESVERBRAUCHSPROGNOSE,

    /// <summary>9991 00000 240 4</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(VERAEUSSERUNGSFORM))]
    [EnumMember(Value = "VERAEUSSERUNGSFORM")]
    VERAEUSSERUNGSFORM,

    /// <summary>9991 00000 241 2</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(AUSFALLVERGUETUNG))]
    [EnumMember(Value = "AUSFALLVERGUETUNG")]
    AUSFALLVERGUETUNG,

    /// <summary>9991 00000 242 0</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(MARKTPRAEMIE))]
    [EnumMember(Value = "MARKTPRAEMIE")]
    MARKTPRAEMIE,

    /// <summary>9991 00000 243 8</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(KWKG))]
    [EnumMember(Value = "KWKG")]
    KWKG,

    /// <summary>9991 00000 244 6 </summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(SONSTIGE_DIREKTVERMARKTUNG))]
    [EnumMember(Value = "SONSTIGE_DIREKTVERMARKTUNG")]
    SONSTIGE_DIREKTVERMARKTUNG,

    /// <summary>9991 00000 276 9</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(RUHENDE_MARKTLOKATION))]
    [EnumMember(Value = "RUHENDE_MARKTLOKATION")]
    RUHENDE_MARKTLOKATION,

    /// <summary>9991 00000 293 3</summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(BILDUNG))]
    [EnumMember(Value = "BILDUNG")]
    BILDUNG,

    /// <summary>9991 00000 320 </summary>
    [ProtoEnum(Name = nameof(Produktcode) + "_" + nameof(INTEGRATION))]
    [EnumMember(Value = "INTEGRATION")]
    INTEGRATION,
}
