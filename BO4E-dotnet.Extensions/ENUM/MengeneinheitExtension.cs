using System;
using System.Collections.Generic;
using BO4E.ENUM;

namespace BO4E.Extensions.ENUM
{
    /// <summary>
    /// Extension Methods for Mengeneinheit.
    /// </summary>
    public static class MengeneinheitExtenion
    {
        /// <summary>
        /// This set contains sets of Mengeneinheiten that share the same dimension (e.g. time, power, work, volume)
        /// Einheiten in the same subset are considered convertible amongst each other.
        /// </summary>
        public static readonly ISet<ISet<Mengeneinheit>> DIMENSION_SETS = new HashSet<ISet<Mengeneinheit>>
        {
           new HashSet<Mengeneinheit>{ Mengeneinheit.WH, Mengeneinheit.KWH, Mengeneinheit.MWH },
           new HashSet<Mengeneinheit>{ Mengeneinheit.KW, Mengeneinheit.MW },
           new HashSet<Mengeneinheit>{ Mengeneinheit.JAHR, Mengeneinheit.MONAT, Mengeneinheit.TAG, Mengeneinheit.STUNDE},
           new HashSet<Mengeneinheit>{ Mengeneinheit.ANZAHL },
           new HashSet<Mengeneinheit>{ Mengeneinheit.KUBIKMETER},
           new HashSet<Mengeneinheit>{ Mengeneinheit.VAR, Mengeneinheit.KVAR},
           new HashSet<Mengeneinheit>{ Mengeneinheit.VARH, Mengeneinheit.KVARH}
        };

        /// <summary>
        /// Tests if two Mengeneinheit are convertible into each other / do have the same kind.
        /// </summary>
        /// <param name="me1"></param>
        /// <param name="me2"></param>
        /// <returns>true iff convertible</returns>
        public static bool AreConvertible(Mengeneinheit me1, Mengeneinheit me2)
        {
            foreach (ISet<Mengeneinheit> einheitengroup in DIMENSION_SETS)
            {
                if (einheitengroup.Contains(me1) && einheitengroup.Contains(me2))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Similar to AreConvertible but as extension method for me1
        /// </summary>
        /// <param name="me1"></param>
        /// <param name="me2"></param>
        /// <returns></returns>
        public static bool IsConvertibleTo(this Mengeneinheit me1, Mengeneinheit me2)
        {
            return AreConvertible(me1, me2);
        }

        /// <summary>
        /// Is the Mengeneinheit intensive?
        /// </summary>
        /// <param name="me"></param>
        /// <returns>true iff not extensive</returns>
        public static bool IsIntensive(this Mengeneinheit me)
        {
            return !IsExtensive(me);
        }

        /// <summary>
        /// is the Mengeneinheit extensive?
        /// </summary>
        /// <param name="me"></param>
        /// <returns>true iff extensive</returns>
        public static bool IsExtensive(this Mengeneinheit me)
        {
            switch (me)
            {
                case Mengeneinheit.ANZAHL:
                    return true;
                case Mengeneinheit.JAHR:
                    return true;
                case Mengeneinheit.KUBIKMETER:
                    return true;
                case Mengeneinheit.KW:
                    return false;
                case Mengeneinheit.KWH:
                    return true;
                case Mengeneinheit.MONAT:
                    return true;
                case Mengeneinheit.MWH:
                    return true;
                case Mengeneinheit.STUNDE:
                    return true;
                case Mengeneinheit.TAG:
                    return true;
                case Mengeneinheit.WH:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// returns the factor that is needed to convert an amount in unit <paramref name="me1"/> to an equivalent amount in unit <paramref name="me2"/>.
        /// </summary>
        /// <param name="me1">source unit</param>
        /// <param name="me2">target unit</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">iff units do not have the same dimension</exception>
        public static decimal GetConversionFactor(this Mengeneinheit me1, Mengeneinheit me2)
        {
            if (me1 == me2)
            {
                return 1.0M;
            }
            if (!me1.IsConvertibleTo(me2))
            {
                throw new InvalidOperationException($"{me1} and {me2} are not convertible into each other because they don't share the same dimension.");
            }
            if ((int)me1 % (int)me2 == 0 || (int)me2 % (int)me2 == 0)
            {
                return (decimal)me1 / (decimal)me2;
            }
            else
            {
                throw new InvalidOperationException($"{me1} and {me2} are not (trivially) convertible into each other.");
            }
        }
    }
}

