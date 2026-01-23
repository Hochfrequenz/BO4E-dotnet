#nullable enable
using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Der ISO-Landescode.</summary>
public enum Landescode
{
    /// <summary>Ascension Island</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AC))]
    [EnumMember(Value = "AC")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AC")]
    AC,

    /// <summary>Andorra</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AD))]
    [EnumMember(Value = "AD")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AD")]
    AD,

    /// <summary>United Arab Emirates</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AE))]
    [EnumMember(Value = "AE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AE")]
    AE,

    /// <summary>Afghanistan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AF))]
    [EnumMember(Value = "AF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AF")]
    AF,

    /// <summary>Antigua and Barbuda</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AG))]
    [EnumMember(Value = "AG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AG")]
    AG,

    /// <summary>Anguilla</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AI))]
    [EnumMember(Value = "AI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AI")]
    AI,

    /// <summary>Albania</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AL))]
    [EnumMember(Value = "AL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AL")]
    AL,

    /// <summary>Armenia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AM))]
    [EnumMember(Value = "AM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AM")]
    AM,

    /// <summary>Netherlands Antilles</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AN))]
    [EnumMember(Value = "AN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AN")]
    AN,

    /// <summary>Angola</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AO))]
    [EnumMember(Value = "AO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AO")]
    AO,

    /// <summary>Antarctica</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AQ))]
    [EnumMember(Value = "AQ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AQ")]
    AQ,

    /// <summary>Argentina</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AR))]
    [EnumMember(Value = "AR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AR")]
    AR,

    /// <summary>American Samoa</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AS))]
    [EnumMember(Value = "AS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AS")]
    AS,

    /// <summary>Austria</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AT))]
    [EnumMember(Value = "AT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AT")]
    AT,

    /// <summary>Australia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AU))]
    [EnumMember(Value = "AU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AU")]
    AU,

    /// <summary>Aruba</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AW))]
    [EnumMember(Value = "AW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AW")]
    AW,

    /// <summary>Åland Islands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AX))]
    [EnumMember(Value = "AX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AX")]
    AX,

    /// <summary>Azerbaijan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(AZ))]
    [EnumMember(Value = "AZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AZ")]
    AZ,

    /// <summary>Bosnia and Herzegovina</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BA))]
    [EnumMember(Value = "BA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BA")]
    BA,

    /// <summary>Barbados</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BB))]
    [EnumMember(Value = "BB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BB")]
    BB,

    /// <summary>Bangladesh</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BD))]
    [EnumMember(Value = "BD")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BD")]
    BD,

    /// <summary>Belgium</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BE))]
    [EnumMember(Value = "BE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BE")]
    BE,

    /// <summary>Burkina Faso</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BF))]
    [EnumMember(Value = "BF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BF")]
    BF,

    /// <summary>Bulgaria</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BG))]
    [EnumMember(Value = "BG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BG")]
    BG,

    /// <summary>Bahrain</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BH))]
    [EnumMember(Value = "BH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BH")]
    BH,

    /// <summary>Burundi</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BI))]
    [EnumMember(Value = "BI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BI")]
    BI,

    /// <summary>Benin</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BJ))]
    [EnumMember(Value = "BJ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BJ")]
    BJ,

    /// <summary>Saint Barthélemy</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BL))]
    [EnumMember(Value = "BL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BL")]
    BL,

    /// <summary>Bermuda</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BM))]
    [EnumMember(Value = "BM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BM")]
    BM,

    /// <summary>Brunei Darussalam</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BN))]
    [EnumMember(Value = "BN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BN")]
    BN,

    /// <summary>Bolivia, Plurinational State of</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BO))]
    [EnumMember(Value = "BO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BO")]
    BO,

    /// <summary>Bonaire, Sint Eustatius and Saba</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BQ))]
    [EnumMember(Value = "BQ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BQ")]
    BQ,

    /// <summary>Brazil</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BR))]
    [EnumMember(Value = "BR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BR")]
    BR,

    /// <summary>Bahamas</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BS))]
    [EnumMember(Value = "BS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BS")]
    BS,

    /// <summary>Bhutan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BT))]
    [EnumMember(Value = "BT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BT")]
    BT,

    /// <summary>Burma</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BU))]
    [EnumMember(Value = "BU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BU")]
    BU,

    /// <summary>Bouvet Island</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BV))]
    [EnumMember(Value = "BV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BV")]
    BV,

    /// <summary>Botswana</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BW))]
    [EnumMember(Value = "BW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BW")]
    BW,

    /// <summary>Belarus</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BY))]
    [EnumMember(Value = "BY")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BY")]
    BY,

    /// <summary>Belize</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(BZ))]
    [EnumMember(Value = "BZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BZ")]
    BZ,

    /// <summary>Canada</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CA))]
    [EnumMember(Value = "CA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CA")]
    CA,

    /// <summary>Cocos (Keeling) Islands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CC))]
    [EnumMember(Value = "CC")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CC")]
    CC,

    /// <summary>Congo, the Democratic Republic of the</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CD))]
    [EnumMember(Value = "CD")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CD")]
    CD,

    /// <summary>Central African Republic</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CF))]
    [EnumMember(Value = "CF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CF")]
    CF,

    /// <summary>Congo</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CG))]
    [EnumMember(Value = "CG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CG")]
    CG,

    /// <summary>Switzerland</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CH))]
    [EnumMember(Value = "CH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CH")]
    CH,

    /// <summary>Côte d'Ivoire</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CI))]
    [EnumMember(Value = "CI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CI")]
    CI,

    /// <summary>Cook Islands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CK))]
    [EnumMember(Value = "CK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CK")]
    CK,

    /// <summary>Chile</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CL))]
    [EnumMember(Value = "CL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CL")]
    CL,

    /// <summary>Cameroon</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CM))]
    [EnumMember(Value = "CM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CM")]
    CM,

    /// <summary>China</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CN))]
    [EnumMember(Value = "CN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CN")]
    CN,

    /// <summary>Colombia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CO))]
    [EnumMember(Value = "CO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CO")]
    CO,

    /// <summary>Clipperton Island</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CP))]
    [EnumMember(Value = "CP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CP")]
    CP,

    /// <summary>Costa Rica</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CR))]
    [EnumMember(Value = "CR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CR")]
    CR,

    /// <summary>Serbia and Montenegro</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CS))]
    [EnumMember(Value = "CS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CS")]
    CS,

    /// <summary>Cuba</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CU))]
    [EnumMember(Value = "CU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CU")]
    CU,

    /// <summary>Cape Verde</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CV))]
    [EnumMember(Value = "CV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CV")]
    CV,

    /// <summary>Curaçao</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CW))]
    [EnumMember(Value = "CW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CW")]
    CW,

    /// <summary>Christmas Island</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CX))]
    [EnumMember(Value = "CX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CX")]
    CX,

    /// <summary>Cyprus</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CY))]
    [EnumMember(Value = "CY")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CY")]
    CY,

    /// <summary>Czech Republic</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(CZ))]
    [EnumMember(Value = "CZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CZ")]
    CZ,

    /// <summary>Germany</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(DE))]
    [EnumMember(Value = "DE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DE")]
    DE,

    /// <summary>Diego Garcia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(DG))]
    [EnumMember(Value = "DG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DG")]
    DG,

    /// <summary>Djibouti</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(DJ))]
    [EnumMember(Value = "DJ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DJ")]
    DJ,

    /// <summary>Denmark</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(DK))]
    [EnumMember(Value = "DK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DK")]
    DK,

    /// <summary>Dominica</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(DM))]
    [EnumMember(Value = "DM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DM")]
    DM,

    /// <summary>Dominican Republic</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(DO))]
    [EnumMember(Value = "DO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DO")]
    DO,

    /// <summary>Algeria</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(DZ))]
    [EnumMember(Value = "DZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DZ")]
    DZ,

    /// <summary>Ceuta, Melilla</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(EA))]
    [EnumMember(Value = "EA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EA")]
    EA,

    /// <summary>Ecuador</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(EC))]
    [EnumMember(Value = "EC")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EC")]
    EC,

    /// <summary>Estonia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(EE))]
    [EnumMember(Value = "EE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EE")]
    EE,

    /// <summary>Egypt</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(EG))]
    [EnumMember(Value = "EG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EG")]
    EG,

    /// <summary>Western Sahara</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(EH))]
    [EnumMember(Value = "EH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EH")]
    EH,

    /// <summary>Eritrea</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(ER))]
    [EnumMember(Value = "ER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ER")]
    ER,

    /// <summary>Spain</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(ES))]
    [EnumMember(Value = "ES")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ES")]
    ES,

    /// <summary>Ethiopia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(ET))]
    [EnumMember(Value = "ET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ET")]
    ET,

    /// <summary>European Union</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(EU))]
    [EnumMember(Value = "EU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EU")]
    EU,

    /// <summary>Finland</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(FI))]
    [EnumMember(Value = "FI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FI")]
    FI,

    /// <summary>Fiji</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(FJ))]
    [EnumMember(Value = "FJ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FJ")]
    FJ,

    /// <summary>Falkland Islands (Malvinas)</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(FK))]
    [EnumMember(Value = "FK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FK")]
    FK,

    /// <summary>Micronesia, Federated States of</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(FM))]
    [EnumMember(Value = "FM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FM")]
    FM,

    /// <summary>Faroe Islands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(FO))]
    [EnumMember(Value = "FO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FO")]
    FO,

    /// <summary>France</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(FR))]
    [EnumMember(Value = "FR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FR")]
    FR,

    /// <summary>France, Metropolitan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(FX))]
    [EnumMember(Value = "FX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FX")]
    FX,

    /// <summary>Gabon</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GA))]
    [EnumMember(Value = "GA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GA")]
    GA,

    /// <summary>United Kingdom</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GB))]
    [EnumMember(Value = "GB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GB")]
    GB,

    /// <summary>Grenada</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GD))]
    [EnumMember(Value = "GD")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GD")]
    GD,

    /// <summary>Georgia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GE))]
    [EnumMember(Value = "GE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GE")]
    GE,

    /// <summary>French Guiana</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GF))]
    [EnumMember(Value = "GF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GF")]
    GF,

    /// <summary>Guernsey</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GG))]
    [EnumMember(Value = "GG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GG")]
    GG,

    /// <summary>Ghana</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GH))]
    [EnumMember(Value = "GH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GH")]
    GH,

    /// <summary>Gibraltar</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GI))]
    [EnumMember(Value = "GI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GI")]
    GI,

    /// <summary>Greenland</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GL))]
    [EnumMember(Value = "GL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GL")]
    GL,

    /// <summary>Gambia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GM))]
    [EnumMember(Value = "GM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GM")]
    GM,

    /// <summary>Guinea</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GN))]
    [EnumMember(Value = "GN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GN")]
    GN,

    /// <summary>Guadeloupe</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GP))]
    [EnumMember(Value = "GP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GP")]
    GP,

    /// <summary>Equatorial Guinea</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GQ))]
    [EnumMember(Value = "GQ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GQ")]
    GQ,

    /// <summary>Greece</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GR))]
    [EnumMember(Value = "GR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GR")]
    GR,

    /// <summary>South Georgia and the South Sandwich Islands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GS))]
    [EnumMember(Value = "GS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GS")]
    GS,

    /// <summary>Guatemala</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GT))]
    [EnumMember(Value = "GT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GT")]
    GT,

    /// <summary>Guam</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GU))]
    [EnumMember(Value = "GU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GU")]
    GU,

    /// <summary>Guinea-Bissau</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GW))]
    [EnumMember(Value = "GW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GW")]
    GW,

    /// <summary>Guyana</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(GY))]
    [EnumMember(Value = "GY")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GY")]
    GY,

    /// <summary>Hong Kong</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(HK))]
    [EnumMember(Value = "HK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HK")]
    HK,

    /// <summary>Heard Island and McDonald Islands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(HM))]
    [EnumMember(Value = "HM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HM")]
    HM,

    /// <summary>Honduras</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(HN))]
    [EnumMember(Value = "HN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HN")]
    HN,

    /// <summary>Croatia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(HR))]
    [EnumMember(Value = "HR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HR")]
    HR,

    /// <summary>Haiti</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(HT))]
    [EnumMember(Value = "HT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HT")]
    HT,

    /// <summary>Hungary</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(HU))]
    [EnumMember(Value = "HU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HU")]
    HU,

    /// <summary>Canary Islands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(IC))]
    [EnumMember(Value = "IC")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IC")]
    IC,

    /// <summary>Indonesia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(ID))]
    [EnumMember(Value = "ID")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ID")]
    ID,

    /// <summary>Ireland</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(IE))]
    [EnumMember(Value = "IE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IE")]
    IE,

    /// <summary>Israel</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(IL))]
    [EnumMember(Value = "IL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IL")]
    IL,

    /// <summary>Isle of Man</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(IM))]
    [EnumMember(Value = "IM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IM")]
    IM,

    /// <summary>India</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(IN))]
    [EnumMember(Value = "IN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IN")]
    IN,

    /// <summary>British Indian Ocean Territory</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(IO))]
    [EnumMember(Value = "IO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IO")]
    IO,

    /// <summary>Iraq</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(IQ))]
    [EnumMember(Value = "IQ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IQ")]
    IQ,

    /// <summary>Iran, Islamic Republic of</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(IR))]
    [EnumMember(Value = "IR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IR")]
    IR,

    /// <summary>Iceland</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(IS))]
    [EnumMember(Value = "IS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IS")]
    IS,

    /// <summary>Italy</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(IT))]
    [EnumMember(Value = "IT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IT")]
    IT,

    /// <summary>Jersey</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(JE))]
    [EnumMember(Value = "JE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("JE")]
    JE,

    /// <summary>Jamaica</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(JM))]
    [EnumMember(Value = "JM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("JM")]
    JM,

    /// <summary>Jordan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(JO))]
    [EnumMember(Value = "JO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("JO")]
    JO,

    /// <summary>Japan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(JP))]
    [EnumMember(Value = "JP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("JP")]
    JP,

    /// <summary>Kenya</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(KE))]
    [EnumMember(Value = "KE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KE")]
    KE,

    /// <summary>Kyrgyzstan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(KG))]
    [EnumMember(Value = "KG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KG")]
    KG,

    /// <summary>Cambodia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(KH))]
    [EnumMember(Value = "KH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KH")]
    KH,

    /// <summary>Kiribati</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(KI))]
    [EnumMember(Value = "KI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KI")]
    KI,

    /// <summary>Comoros</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(KM))]
    [EnumMember(Value = "KM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KM")]
    KM,

    /// <summary>Saint Kitts and Nevis</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(KN))]
    [EnumMember(Value = "KN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KN")]
    KN,

    /// <summary>Korea, Democratic People's Republic of</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(KP))]
    [EnumMember(Value = "KP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KP")]
    KP,

    /// <summary>Korea, Republic of</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(KR))]
    [EnumMember(Value = "KR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KR")]
    KR,

    /// <summary>Kuwait</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(KW))]
    [EnumMember(Value = "KW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KW")]
    KW,

    /// <summary>Cayman Islands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(KY))]
    [EnumMember(Value = "KY")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KY")]
    KY,

    /// <summary>Kazakhstan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(KZ))]
    [EnumMember(Value = "KZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KZ")]
    KZ,

    /// <summary>Lao People's Democratic Republic</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(LA))]
    [EnumMember(Value = "LA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LA")]
    LA,

    /// <summary>Lebanon</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(LB))]
    [EnumMember(Value = "LB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LB")]
    LB,

    /// <summary>Saint Lucia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(LC))]
    [EnumMember(Value = "LC")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LC")]
    LC,

    /// <summary>Liechtenstein</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(LI))]
    [EnumMember(Value = "LI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LI")]
    LI,

    /// <summary>Sri Lanka</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(LK))]
    [EnumMember(Value = "LK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LK")]
    LK,

    /// <summary>Liberia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(LR))]
    [EnumMember(Value = "LR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LR")]
    LR,

    /// <summary>Lesotho</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(LS))]
    [EnumMember(Value = "LS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LS")]
    LS,

    /// <summary>Lithuania</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(LT))]
    [EnumMember(Value = "LT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LT")]
    LT,

    /// <summary>Luxembourg</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(LU))]
    [EnumMember(Value = "LU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LU")]
    LU,

    /// <summary>Latvia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(LV))]
    [EnumMember(Value = "LV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LV")]
    LV,

    /// <summary>Libya</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(LY))]
    [EnumMember(Value = "LY")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LY")]
    LY,

    /// <summary>Morocco</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MA))]
    [EnumMember(Value = "MA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MA")]
    MA,

    /// <summary>Monaco</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MC))]
    [EnumMember(Value = "MC")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MC")]
    MC,

    /// <summary>Moldova, Republic of</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MD))]
    [EnumMember(Value = "MD")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MD")]
    MD,

    /// <summary>Montenegro</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(ME))]
    [EnumMember(Value = "ME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ME")]
    ME,

    /// <summary>Saint Martin (French part)</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MF))]
    [EnumMember(Value = "MF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MF")]
    MF,

    /// <summary>Madagascar</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MG))]
    [EnumMember(Value = "MG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MG")]
    MG,

    /// <summary>Marshall Islands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MH))]
    [EnumMember(Value = "MH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MH")]
    MH,

    /// <summary>Macedonia, the former Yugoslav Republic of</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MK))]
    [EnumMember(Value = "MK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MK")]
    MK,

    /// <summary>Mali</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(ML))]
    [EnumMember(Value = "ML")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ML")]
    ML,

    /// <summary>Myanmar</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MM))]
    [EnumMember(Value = "MM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MM")]
    MM,

    /// <summary>Mongolia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MN))]
    [EnumMember(Value = "MN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MN")]
    MN,

    /// <summary>Macao</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MO))]
    [EnumMember(Value = "MO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MO")]
    MO,

    /// <summary>Northern Mariana Islands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MP))]
    [EnumMember(Value = "MP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MP")]
    MP,

    /// <summary>Martinique</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MQ))]
    [EnumMember(Value = "MQ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MQ")]
    MQ,

    /// <summary>Mauritania</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MR))]
    [EnumMember(Value = "MR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MR")]
    MR,

    /// <summary>Montserrat</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MS))]
    [EnumMember(Value = "MS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MS")]
    MS,

    /// <summary>Malta</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MT))]
    [EnumMember(Value = "MT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MT")]
    MT,

    /// <summary>Mauritius</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MU))]
    [EnumMember(Value = "MU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MU")]
    MU,

    /// <summary>Maldives</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MV))]
    [EnumMember(Value = "MV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MV")]
    MV,

    /// <summary>Malawi</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MW))]
    [EnumMember(Value = "MW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MW")]
    MW,

    /// <summary>Mexico</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MX))]
    [EnumMember(Value = "MX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MX")]
    MX,

    /// <summary>Malaysia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MY))]
    [EnumMember(Value = "MY")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MY")]
    MY,

    /// <summary>Mozambique</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(MZ))]
    [EnumMember(Value = "MZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MZ")]
    MZ,

    /// <summary>Namibia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(NA))]
    [EnumMember(Value = "NA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NA")]
    NA,

    /// <summary>New Caledonia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(NC))]
    [EnumMember(Value = "NC")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NC")]
    NC,

    /// <summary>Niger</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(NE))]
    [EnumMember(Value = "NE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NE")]
    NE,

    /// <summary>Norfolk Island</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(NF))]
    [EnumMember(Value = "NF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NF")]
    NF,

    /// <summary>Nigeria</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(NG))]
    [EnumMember(Value = "NG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NG")]
    NG,

    /// <summary>Nicaragua</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(NI))]
    [EnumMember(Value = "NI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NI")]
    NI,

    /// <summary>Netherlands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(NL))]
    [EnumMember(Value = "NL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NL")]
    NL,

    /// <summary>Norway</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(NO))]
    [EnumMember(Value = "NO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NO")]
    NO,

    /// <summary>Nepal</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(NP))]
    [EnumMember(Value = "NP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NP")]
    NP,

    /// <summary>Nauru</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(NR))]
    [EnumMember(Value = "NR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NR")]
    NR,

    /// <summary>Neutral Zone</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(NT))]
    [EnumMember(Value = "NT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NT")]
    NT,

    /// <summary>Niue</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(NU))]
    [EnumMember(Value = "NU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NU")]
    NU,

    /// <summary>New Zealand</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(NZ))]
    [EnumMember(Value = "NZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NZ")]
    NZ,

    /// <summary>Oman</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(OM))]
    [EnumMember(Value = "OM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("OM")]
    OM,

    /// <summary>Panama</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PA))]
    [EnumMember(Value = "PA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PA")]
    PA,

    /// <summary>Peru</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PE))]
    [EnumMember(Value = "PE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PE")]
    PE,

    /// <summary>French Polynesia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PF))]
    [EnumMember(Value = "PF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PF")]
    PF,

    /// <summary>Papua New Guinea</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PG))]
    [EnumMember(Value = "PG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PG")]
    PG,

    /// <summary>Philippines</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PH))]
    [EnumMember(Value = "PH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PH")]
    PH,

    /// <summary>Pakistan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PK))]
    [EnumMember(Value = "PK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PK")]
    PK,

    /// <summary>Poland</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PL))]
    [EnumMember(Value = "PL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PL")]
    PL,

    /// <summary>Saint Pierre and Miquelon</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PM))]
    [EnumMember(Value = "PM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PM")]
    PM,

    /// <summary>Pitcairn</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PN))]
    [EnumMember(Value = "PN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PN")]
    PN,

    /// <summary>Puerto Rico</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PR))]
    [EnumMember(Value = "PR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PR")]
    PR,

    /// <summary>Palestine, State of</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PS))]
    [EnumMember(Value = "PS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PS")]
    PS,

    /// <summary>Portugal</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PT))]
    [EnumMember(Value = "PT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PT")]
    PT,

    /// <summary>Palau</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PW))]
    [EnumMember(Value = "PW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PW")]
    PW,

    /// <summary>Paraguay</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(PY))]
    [EnumMember(Value = "PY")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PY")]
    PY,

    /// <summary>Qatar</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(QA))]
    [EnumMember(Value = "QA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("QA")]
    QA,

    /// <summary>Réunion</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(RE))]
    [EnumMember(Value = "RE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RE")]
    RE,

    /// <summary>Romania</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(RO))]
    [EnumMember(Value = "RO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RO")]
    RO,

    /// <summary>Serbia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(RS))]
    [EnumMember(Value = "RS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RS")]
    RS,

    /// <summary>Russian Federation</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(RU))]
    [EnumMember(Value = "RU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RU")]
    RU,

    /// <summary>Rwanda</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(RW))]
    [EnumMember(Value = "RW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RW")]
    RW,

    /// <summary>Saudi Arabia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SA))]
    [EnumMember(Value = "SA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SA")]
    SA,

    /// <summary>Solomon Islands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SB))]
    [EnumMember(Value = "SB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SB")]
    SB,

    /// <summary>Seychelles</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SC))]
    [EnumMember(Value = "SC")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SC")]
    SC,

    /// <summary>Sudan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SD))]
    [EnumMember(Value = "SD")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SD")]
    SD,

    /// <summary>Sweden</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SE))]
    [EnumMember(Value = "SE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SE")]
    SE,

    /// <summary>Finland</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SF))]
    [EnumMember(Value = "SF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SF")]
    SF,

    /// <summary>Singapore</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SG))]
    [EnumMember(Value = "SG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SG")]
    SG,

    /// <summary>Saint Helena, Ascension and Tristan da Cunha</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SH))]
    [EnumMember(Value = "SH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SH")]
    SH,

    /// <summary>Slovenia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SI))]
    [EnumMember(Value = "SI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SI")]
    SI,

    /// <summary>Svalbard and Jan Mayen</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SJ))]
    [EnumMember(Value = "SJ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SJ")]
    SJ,

    /// <summary>Slovakia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SK))]
    [EnumMember(Value = "SK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SK")]
    SK,

    /// <summary>Sierra Leone</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SL))]
    [EnumMember(Value = "SL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SL")]
    SL,

    /// <summary>San Marino</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SM))]
    [EnumMember(Value = "SM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SM")]
    SM,

    /// <summary>Senegal</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SN))]
    [EnumMember(Value = "SN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SN")]
    SN,

    /// <summary>Somalia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SO))]
    [EnumMember(Value = "SO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SO")]
    SO,

    /// <summary>Suriname</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SR))]
    [EnumMember(Value = "SR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SR")]
    SR,

    /// <summary>South Sudan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SS))]
    [EnumMember(Value = "SS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SS")]
    SS,

    /// <summary>Sao Tome and Principe</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(ST))]
    [EnumMember(Value = "ST")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ST")]
    ST,

    /// <summary>USSR</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SU))]
    [EnumMember(Value = "SU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SU")]
    SU,

    /// <summary>El Salvador</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SV))]
    [EnumMember(Value = "SV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SV")]
    SV,

    /// <summary>Sint Maarten (Dutch part)</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SX))]
    [EnumMember(Value = "SX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SX")]
    SX,

    /// <summary>Syrian Arab Republic</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SY))]
    [EnumMember(Value = "SY")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SY")]
    SY,

    /// <summary>Swaziland</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(SZ))]
    [EnumMember(Value = "SZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SZ")]
    SZ,

    /// <summary>Tristan da Cunha</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TA))]
    [EnumMember(Value = "TA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TA")]
    TA,

    /// <summary>Turks and Caicos Islands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TC))]
    [EnumMember(Value = "TC")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TC")]
    TC,

    /// <summary>Chad</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TD))]
    [EnumMember(Value = "TD")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TD")]
    TD,

    /// <summary>French Southern Territories</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TF))]
    [EnumMember(Value = "TF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TF")]
    TF,

    /// <summary>Togo</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TG))]
    [EnumMember(Value = "TG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TG")]
    TG,

    /// <summary>Tajikistan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TJ))]
    [EnumMember(Value = "TJ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TJ")]
    TJ,

    /// <summary>Tokelau</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TK))]
    [EnumMember(Value = "TK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TK")]
    TK,

    /// <summary>Timor-Leste</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TL))]
    [EnumMember(Value = "TL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TL")]
    TL,

    /// <summary>Turkmenistan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TM))]
    [EnumMember(Value = "TM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TM")]
    TM,

    /// <summary>Tunisia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TN))]
    [EnumMember(Value = "TN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TN")]
    TN,

    /// <summary>Tonga</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TO))]
    [EnumMember(Value = "TO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TO")]
    TO,

    /// <summary>East Timor</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TP))]
    [EnumMember(Value = "TP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TP")]
    TP,

    /// <summary>Turkey</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TR))]
    [EnumMember(Value = "TR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TR")]
    TR,

    /// <summary>Trinidad and Tobago</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TT))]
    [EnumMember(Value = "TT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TT")]
    TT,

    /// <summary>Tuvalu</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TV))]
    [EnumMember(Value = "TV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TV")]
    TV,

    /// <summary>Taiwan, Province of China</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TW))]
    [EnumMember(Value = "TW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TW")]
    TW,

    /// <summary>Tanzania, United Republic of</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(TZ))]
    [EnumMember(Value = "TZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TZ")]
    TZ,

    /// <summary>Ukraine</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(UA))]
    [EnumMember(Value = "UA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UA")]
    UA,

    /// <summary>Uganda</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(UG))]
    [EnumMember(Value = "UG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UG")]
    UG,

    /// <summary>United Kingdom</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(UK))]
    [EnumMember(Value = "UK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UK")]
    UK,

    /// <summary>United States Minor Outlying Islands</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(UM))]
    [EnumMember(Value = "UM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UM")]
    UM,

    /// <summary>United States</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(US))]
    [EnumMember(Value = "US")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("US")]
    US,

    /// <summary>Uruguay</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(UY))]
    [EnumMember(Value = "UY")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UY")]
    UY,

    /// <summary>Uzbekistan</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(UZ))]
    [EnumMember(Value = "UZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UZ")]
    UZ,

    /// <summary>Holy See (Vatican City State)</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(VA))]
    [EnumMember(Value = "VA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VA")]
    VA,

    /// <summary>Saint Vincent and the Grenadines</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(VC))]
    [EnumMember(Value = "VC")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VC")]
    VC,

    /// <summary>Venezuela, Bolivarian Republic of</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(VE))]
    [EnumMember(Value = "VE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VE")]
    VE,

    /// <summary>Virgin Islands, British</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(VG))]
    [EnumMember(Value = "VG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VG")]
    VG,

    /// <summary>Virgin Islands, U.S.</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(VI))]
    [EnumMember(Value = "VI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VI")]
    VI,

    /// <summary>Viet Nam</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(VN))]
    [EnumMember(Value = "VN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VN")]
    VN,

    /// <summary>Vanuatu</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(VU))]
    [EnumMember(Value = "VU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VU")]
    VU,

    /// <summary>Wallis and Futuna</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(WF))]
    [EnumMember(Value = "WF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WF")]
    WF,

    /// <summary>Samoa</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(WS))]
    [EnumMember(Value = "WS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WS")]
    WS,

    /// <summary>Kosovo, Republic of</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(XK))]
    [EnumMember(Value = "XK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("XK")]
    XK,

    /// <summary>Yemen</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(YE))]
    [EnumMember(Value = "YE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("YE")]
    YE,

    /// <summary>Mayotte</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(YT))]
    [EnumMember(Value = "YT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("YT")]
    YT,

    /// <summary>Yugoslavia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(YU))]
    [EnumMember(Value = "YU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("YU")]
    YU,

    /// <summary>South Africa</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(ZA))]
    [EnumMember(Value = "ZA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZA")]
    ZA,

    /// <summary>Zambia</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(ZM))]
    [EnumMember(Value = "ZM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZM")]
    ZM,

    /// <summary>Zaire</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(ZR))]
    [EnumMember(Value = "ZR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZR")]
    ZR,

    /// <summary>Zimbabwe</summary>
    [ProtoEnum(Name = nameof(Landescode) + "_" + nameof(ZW))]
    [EnumMember(Value = "ZW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZW")]
    ZW,
}
