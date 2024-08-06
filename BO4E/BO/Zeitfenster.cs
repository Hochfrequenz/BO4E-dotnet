using System;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Ein Zeitfenster mit Start- und Endzeiten mit <see cref="TimeOnly"/> als Typ.
    /// </summary>
    [ProtoContract]
    public class Zeitfenster : COM
    {
        /// <summary>Startzeit (Format: HHMM)</summary>
        [ProtoMember(1)]
        public TimeOnly Startzeit { get; set; }

        /// <summary>Endzeit (Format: HHMM)</summary>
        [ProtoMember(2)]
        public TimeOnly Endzeit { get; set; }

        /// <summary>
        /// Erstellt eine neue Instanz von Zeitfenster mit spezifischen Start- und Endzeiten.
        /// </summary>
        /// <param name="startzeit">Startzeit (Format: HHMM)</param>
        /// <param name="endzeit">Endzeit (Format: HHMM)</param>
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
                int startStunden = int.Parse(zeitfensterString.Substring(0, 2));
                int startMinuten = int.Parse(zeitfensterString.Substring(2, 2));
                int endStunden = int.Parse(zeitfensterString.Substring(4, 2));
                int endMinuten = int.Parse(zeitfensterString.Substring(6, 2));

                Startzeit = new TimeOnly(startStunden, startMinuten);
                Endzeit = new TimeOnly(endStunden, endMinuten);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Der Zeitfenster-String muss im Format HHMMHHMM vorliegen und nur Zahlen enthalten.");
            }
        }
    }
}
