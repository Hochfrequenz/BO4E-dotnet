using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Status des Statusbericht</summary>
    public enum BerichtStatus
    {
        /// <summary>
        /// Bericht war erfolgreich
        /// </summary>
        [ProtoEnum(Name = "BerichtStatus_ERFOLGREICH")]
        ERFOLGREICH,

        /// <summary>Fehler im Bericht</summary>
        [ProtoEnum(Name = "BerichtStatus_FEHLER")]
        FEHLER
    }
}