using BO4E.COM;
using BO4E.ENUM;
using BO4E.Extensions.ENUM;

namespace BO4E.Extensions.COM
{
    /// <summary>
    /// extensions for <see cref="PhysikalischerWert"/>
    /// </summary>
    public static class PhysikalischerWertExtension
    {
        /// <summary>
        /// Converts a PhysikalischerWert to another unit, e.g. from kWh to MWh. This changes the <see cref="PhysikalischerWert.einheit"/> and the <see cref="PhysikalischerWert.wert"/> accordingly
        /// </summary>
        /// <param name="pw">physikalischer Wert</param>
        /// <param name="newEinheit">new unit of measurement</param>
        /// <returns>a new instance of PhysikalischerWert having the unit <paramref name="newEinheit"/></returns>
        public static PhysikalischerWert ConvertToUnit(this PhysikalischerWert pw, Mengeneinheit newEinheit)
        {
            decimal factor = pw.einheit.GetConversionFactor(newEinheit); // throws all the exceptions.
            return new PhysikalischerWert(factor * pw.wert, newEinheit);
        }
    }
}
