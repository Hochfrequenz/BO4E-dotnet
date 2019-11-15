using System;
using BO4E.ENUM;

namespace BO4E.COM
{
    /// <summary>
    /// Kombination aus einem Wert und einer Einheit (see <see cref="Mengeneinheit"/>).
    /// </summary>
    public class PhysikalischerWert : COM
    {
        /// <summary>
        /// numerischer Wert
        /// </summary>
        public readonly decimal wert;

        /// <summary>
        /// Einheit von <see cref="wert"/>
        /// </summary>
        public readonly Mengeneinheit einheit;

        /// <summary>
        /// initialise with wert and einheit
        /// </summary>
        /// <param name="wert">numerischer Wert</param>
        /// <param name="einheit">zugehörige Mengeneinheit</param>
        public PhysikalischerWert(decimal wert, Mengeneinheit einheit)
        {
            this.wert = wert;
            this.einheit = einheit;
        }

        /// <summary>
        /// initialise with wert and string for einheit
        /// </summary>
        /// <param name="wert">numerischer wert</param>
        /// <param name="einheitString">zugehörige Einheit als string (case insensitive)</param>
        public PhysikalischerWert(decimal wert, string einheitString)
        {
            this.wert = wert;
            if(!Enum.TryParse<Mengeneinheit>(einheitString, true, out this.einheit))
            {
                throw new ArgumentException($"'{einheitString}' is not a valid Mengeneinheit");
            }
        }
    }
}
