using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    /// EDIFACT values of <see cref="Verbrauchsart"/>
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum VerbrauchsartEdi
    {
        /// <summary>
        /// Kraft/Licht
        /// </summary>
        /// Hierunter ist Strom zu verstehen, der ausschließlich zum Betrieb von
        /// Endverbrauchsgeräten (z.B. Radio, Fernseher, Kühlschrank, Beleuchtung...)
        /// genutzt wird.
        [Mapping(Verbrauchsart.KL)]
        Z64,
        /// <summary>Wärme</summary>
        /// Hierunter ist Strom zu verstehen, der zur Wärmebedarfsdeckung (z.B. 
        /// Standspeicherheizung, Fußbodenspeicherheizungen, Wärmepumpe....) eingesetzt
        /// wird. Bei Nutzung dieses Qualifiers dient die OBIS ausschließlich diesem Zweck. 
        /// Hierunter fallen Marktlokationen, bei den die Wärme in aller Regel mit einer 
        /// separaten Messung erfasst werden
        [Mapping(Verbrauchsart.W)]
        Z65,
        /// <summary>
        /// Kraft/Licht/Wärme
        /// </summary>
        /// Bei gemeinsam gemessenen Marktlokationen wird Strom sowohl für Endverbrauchsgeräte
        /// als auch zur Wärmebedarfsdeckung eingesetzt. Bei diesem kombinierten Verbrauchsverhalten
        /// ist dieser Qualifier zu nutzen.
        [Mapping(Verbrauchsart.KLW)]
        Z66
    }
}
