using System;
using System.Collections.Generic;
using BO4E.BO;
using System.Linq;

namespace BO4E_dotnet.Extensions.BusinessObjects.SomeCustomer
{
    /// <summary>
    /// class derived from standard BO4E <see cref="Marktlokation"/> with some extensions, specifically for a customer
    /// </summary>
    public class MarktlokationTestExtension : BO4E.BO.Marktlokation
    {
        /// <summary>
        /// list of associated melos. Should have the same length as <see cref="Marktlokation.zugehoerigeMesslokationen"/>.
        /// </summary>
        public List<Messlokation> meloList;

        /// <summary>
        /// create a custom Marklokation busines object where associated melos are part of the malo object itself.
        /// </summary>
        /// <param name="malo">a Marktlokation with non-null associated Messlokationen</param>
        /// <param name="melos">unordered set of messlokations</param>
        public MarktlokationTestExtension(Marktlokation malo, IEnumerable<Messlokation> melos)
        {
            if (melos.Any(melo => !melo.IsValid()))
            {
                throw new ArgumentException("There are invalid Messlokations", nameof(melos));
            }
            if (malo.zugehoerigeMesslokationen == null)
            {
                throw new ArgumentException($"The list of associated melos must not be null {nameof(Marktlokation)}{nameof(Marktlokation.zugehoerigeMesslokationen)}", nameof(malo));
            }
            throw new NotImplementedException("ToDo: Fill the list based on malo->messlokationszuordnungen + list of melos");
        }
        public (Marktlokation, IEnumerable<Messlokation>) Resolve()
        {
            throw new NotImplementedException("has to be programmed");
        }
    }
}
