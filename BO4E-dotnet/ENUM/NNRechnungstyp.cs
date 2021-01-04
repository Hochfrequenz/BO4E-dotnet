using ProtoBuf;

namespace BO4E.ENUM
{

    /// <summary>Abbildung verschiedener in der INVOIC angegebenen Rechnungstypen.</summary>
    public enum NnRechnungstyp
    {
        /// <summary>Abschlagsrechnung</summary>
        [ProtoEnum(Name = nameof(NnRechnungstyp) + "_" + nameof(ABSCHLAGSRECHNUNG))]
        ABSCHLAGSRECHNUNG,
        /// <summary>Turnusrechnung</summary>
        [ProtoEnum(Name = nameof(NnRechnungstyp) + "_" + nameof(TURNUSRECHNUNG))]
        TURNUSRECHNUNG,
        /// <summary>Monatsrechnung</summary>
        [ProtoEnum(Name = nameof(NnRechnungstyp) + "_" + nameof(MONATSRECHNUNG))]
        MONATSRECHNUNG,
        /// <summary>Rechnung für WiM</summary>
        [ProtoEnum(Name = nameof(NnRechnungstyp) + "_" + nameof(WIMRECHNUNG))]
        WIMRECHNUNG,
        /// <summary>Zwischenrechnung</summary>
        [ProtoEnum(Name = nameof(NnRechnungstyp) + "_" + nameof(ZWISCHENRECHNUNG))]
        ZWISCHENRECHNUNG,
        /// <summary>Integrierte 13. Rechnung</summary>
        [ProtoEnum(Name = nameof(NnRechnungstyp) + "_" + nameof(INTEGRIERTE_13_TE_RECHNUNG))]
        INTEGRIERTE_13_TE_RECHNUNG,
        /// <summary>13. Rechnung</summary>
        [ProtoEnum(Name = nameof(NnRechnungstyp) + "_" + nameof(_13TE_RECHNUNG))]
        _13TE_RECHNUNG,
        /// <summary>Mehr/Mindermengenabrechnung</summary>
        [ProtoEnum(Name = nameof(NnRechnungstyp) + "_" + nameof(MEHRMINDERMENGENRECHNUNG))]
        MEHRMINDERMENGENRECHNUNG
    }
}
