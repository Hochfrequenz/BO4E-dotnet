using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.Extensions.COM;
using BO4E.Extensions.ENUM;
using BO4E.Reporting;
using Itenso.TimePeriod;
using Newtonsoft.Json.Linq;
using StackExchange.Profiling;
using static BO4E.Extensions.COM.VerbrauchExtension;


namespace BO4E.Extensions.BusinessObjects.Energiemenge
{
    /// <summary>Do calculations on top of an Energiemenge BO4E.</summary>
    public static partial class EnergiemengeExtension
    {
        private static readonly decimal QUASI_ZERO = 0.00000000001M;

        /// <summary>
        /// Get Zeitraum covered by Energiemenge.
        /// </summary>
        /// <param name="menge">Energiemenge</param>
        /// <returns>Zeitraum ranging from the earliest <see cref="Verbrauch.startdatum"/> to the latest <see cref="Verbrauch.enddatum"/></returns>
        public static Zeitraum GetZeitraum(this BO4E.BO.Energiemenge menge)
        {
            using (MiniProfiler.Current.Step(nameof(GetZeitraum)))
            {
                Zeitraum zeitraum = new Zeitraum
                {
                    startdatum = GetMinDate(menge),
                    enddatum = GetMaxDate(menge)
                };
                return zeitraum;
            }
        }

        /// <summary>
        /// Get TimeRange covery by Energiemenge
        /// </summary>
        /// <param name="menge">Energiemenge</param>
        /// <returns>TimeRange ranging from the earliest <see cref="Verbrauch.startdatum"/> to the latest <see cref="Verbrauch.enddatum"/></returns>
        /// <returns></returns>
        public static TimeRange GetTimeRange(this BO4E.BO.Energiemenge menge)
        {
            using (MiniProfiler.Current.Step(nameof(GetTimeRange)))
            {
                return new TimeRange(menge.GetMinDate(), menge.GetMaxDate());
            }
        }


        /* 
         * If GetMinDate() or GetMaxDate() throws an InvalidOperationException you shouldn't catch 
         * it here but allow the programmer to handle it higher up in the stack trace.
         * This usually happens if one tries to use the auto-configuration feature but the 
         * Energieverbrauch array is empty. The result is simply undefined. Returning null
         * would require all dependent methods to properly handle the null value. Since this 
         * would propably lead to unspecific NullReferenceExceptions we'd better let the invalid
         * operation exception bubble up from here as far as it's required.
         */
        private static DateTime GetMinDate(this BO4E.BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step(nameof(GetMinDate)))
            {
                return em.energieverbrauch.Min(ev => ev.startdatum); // don't catch!
            }
        }

        private static DateTime GetMaxDate(this BO4E.BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step(nameof(GetMinDate)))
            {
                return em.energieverbrauch.Max(ev => ev.enddatum); // don't catch!
            }
        }

        /// <summary>
        /// Same as <see cref="GetTotalConsumption(BO.Energiemenge, Wertermittlungsverfahren, string, Mengeneinheit)"/> but without autodetected parameters. 
        /// By default a the full length of the Energiemenge is taken into account.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>Tuple of consumption value and unit of measurement</returns>
        public static Tuple<decimal, Mengeneinheit> GetTotalConsumption(this BO4E.BO.Energiemenge em)
        {
            return GetConsumption(em, new TimeRange(em.GetMinDate(), em.GetMaxDate()));
        }

        /// <summary>
        /// Get total consumption for given parameters
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="wev">type of measurement</param>
        /// <param name="obiskennzahl">OBIS</param>
        /// <param name="me">unit of measurement</param>
        /// <returns>consumption value</returns>
        public static decimal GetTotalConsumption(this BO4E.BO.Energiemenge em,
            Wertermittlungsverfahren wev, string obiskennzahl, Mengeneinheit me)
        {
            return em.GetConsumption(em.GetTimeRange(), wev, obiskennzahl, me);
        }

        /// <summary>
        /// Get consumption in given time reference frame. Trying to automatically determine parameters and forward to <see cref="BO4E.BO.Energiemenge.GetConsumption(BO.Energiemenge, TimeRange, Wertermittlungsverfahren, string, Mengeneinheit)"/>.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">time reference frame</param>
        /// <returns>Tuple of consumption value and automatically determined unit of measurement</returns>
        public static Tuple<decimal, Mengeneinheit> GetConsumption(this BO4E.BO.Energiemenge em, ITimeRange reference)
        {
            using (MiniProfiler.Current.Step(nameof(GetConsumption)))
            {
                if (!IsPure(em))
                {
                    throw new ArgumentException("The Energiemenge is not pure.");
                }
                if (em.energieverbrauch.Count == 0)
                {
                    return Tuple.Create<decimal, Mengeneinheit>(0.0M, Mengeneinheit.ANZAHL);
                }
                ISet<Mengeneinheit> einheiten = new HashSet<Mengeneinheit>(em.energieverbrauch.Select(x => x.einheit));
                if (einheiten.Count > 1)
                {
                    // z.B. kWh und Wh oder Monat und Jahr... Die liefern IsPure==true.
                    throw new NotImplementedException("Converting different units of same type is not supported yet.");
                }
                Verbrauch v = em.energieverbrauch.First<Verbrauch>();
                decimal consumption = em.GetConsumption(reference, v.wertermittlungsverfahren, v.obiskennzahl, v.einheit);
                return Tuple.Create<decimal, Mengeneinheit>(consumption, v.einheit);
            }
        }

        /// <summary>
        /// Returns the consumption of a given kind of Mengeneinheit within the specified reference time range.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference time frame</param>
        /// <param name="wev">Wertermittlungsverfahren</param>
        /// <param name="obiskennzahl">OBIS number</param>
        /// <param name="me">an extensive unit (e.g. "kWh")</param>
        /// <returns>the consumption within the give time slice <paramref name="reference"/> in the unit passed as <paramref name="me"/></returns>
        public static decimal GetConsumption(this BO4E.BO.Energiemenge em, ITimeRange reference,
            Wertermittlungsverfahren wev, string obiskennzahl, Mengeneinheit me)
        {
            if (!me.IsExtensive())
            {
                throw new ArgumentException($"The Mengeneinheit {me} isn't extensive. Calculating a consumption doesn't make sense.");
            }
            return em.energieverbrauch
                .Where(v => v.wertermittlungsverfahren == wev && v.obiskennzahl == obiskennzahl && v.einheit == me)
                //.AsParallel<Verbrauch>()
                .Sum(v => GetOverlapFactor(new TimeRange(v.startdatum, v.enddatum), reference, false) * v.wert);
        }

        /// <summary>
        /// normalise energiemenge-&gt;energieverbrauch consumption values to a given <paramref name="target"/> value
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="target">normalising constant (1.0 by default)</param>
        /// <returns>new Energiemenge object with normalised consumption values</returns>
        public static BO4E.BO.Energiemenge Normalise(this BO4E.BO.Energiemenge em, decimal target = 1.0M)
        {
            using (MiniProfiler.Current.Step(nameof(Normalise)))
            {
                BO4E.BO.Energiemenge result;
                decimal scalingFactor;
                Tuple<decimal, Mengeneinheit> totalConsumption;
                using (MiniProfiler.Current.Step("Calculating total consumption and normalisation factor."))
                {
                    totalConsumption = em.GetTotalConsumption();
                    result = BusinessObjectExtensions.DeepClone<BO4E.BO.Energiemenge>(em);
                    if (totalConsumption.Item1 != 0.0M)
                    {
                        scalingFactor = target / totalConsumption.Item1;
                    }
                    else
                    {
                        scalingFactor = 0.0M;
                    }
                }
                using (MiniProfiler.Current.Step("Parallelised normalising of all values."))
                {
                    Parallel.ForEach<Verbrauch>(result.energieverbrauch.Where(v => v.einheit == totalConsumption.Item2), v =>
                    {
                        v.wert = scalingFactor * v.wert;
                    });
                }
                return result;
            }
        }

        /// <summary>
        /// Returns the load in an intensive unit for a given point in time.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="me">an intensive unit (e.g. "kW")</param>
        /// <param name="dt">point in time</param>
        /// <returns>load if Energiemenge BO contains value for specified date time<paramref name="dt"/>, null otherwise</returns>
        public static decimal? GetLoad(this BO4E.BO.Energiemenge em, Mengeneinheit me, DateTime dt)
        {
            if (!me.IsIntensive())
            {
                throw new ArgumentException($"The Mengeneinheit {me} isn't intensive. Calculating the value for a specific point in time doesn't make sense.");
            }
            decimal? result = null;
            foreach (Verbrauch v in em.energieverbrauch.Where(v => v.startdatum <= dt && dt < v.enddatum))
            {
                if (result.HasValue)
                {
                    result += v.wert;
                }
                else
                {
                    result = v.wert;
                }
            }
            return result;
        }

        /// <summary>
        /// Get Average (<see cref="GetAverage(BO.Energiemenge, TimeRange, Wertermittlungsverfahren, string, Mengeneinheit)"/>)
        /// for a pure Energiemenge with automatically found parameters.
        /// </summary>
        /// <seealso cref="IsPure(BO4E.BO.Energiemenge)"/>
        /// <param name="em">Energiemenge</param>
        /// <returns>Tuple of average value and unit of measurement</returns>
        public static Tuple<decimal?, Mengeneinheit> GetAverage(this BO4E.BO.Energiemenge em)
        {
            if (!IsPure(em))
            {
                throw new ArgumentException("Energiemenge is not pure.");
            }
            else if (em.energieverbrauch.Count == 0)
            {
                return Tuple.Create<decimal?, Mengeneinheit>(null, Mengeneinheit.KW);
            }
            else
            {
                Verbrauch v = em.energieverbrauch.First<Verbrauch>();
                return Tuple.Create<decimal?, Mengeneinheit>(em.GetAverage(v.wertermittlungsverfahren, v.obiskennzahl, v.einheit), v.einheit);
            }
        }

        /// <summary>
        /// Same as <see cref="GetAverage(Mengeneinheit, DateTime, DateTime)"/> but without specifying a time slice.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="wev">type of measurement</param>
        /// <param name="obiskennzahl">OBIS</param>
        /// <param name="me">an intensive or extensive unit</param>
        /// <returns>The average for the given Mengeneinheit for the Energiemenge object or null if there was no Verbrauch for the given Mengeneinheit.</returns>
        public static decimal? GetAverage(this BO4E.BO.Energiemenge em,
            Wertermittlungsverfahren wev, string obiskennzahl, Mengeneinheit me)
        {
            return em.GetAverage(em.GetTimeRange(), wev, obiskennzahl, me);
        }

        /// <summary>
        /// Get average of Mengeneinheit for given time interval
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference time frame</param>
        /// <param name="wev">Wertermittlungsverfahren</param>
        /// <param name="obiskennzahl">OBIS</param>
        /// <param name="me">an extensive or intensive unit</param>
        /// <returns>the average value or null if no Verbrauch overlapped with the specified time interval</returns>
        public static decimal? GetAverage(this BO4E.BO.Energiemenge em, TimeRange reference,
            Wertermittlungsverfahren wev, string obiskennzahl, Mengeneinheit me)
        {
            decimal? result = null;
            decimal overallDenominator = 0.0M;
            foreach (Verbrauch v in em.energieverbrauch.Where(v => v.einheit == me))
            {
                decimal overlapFactor = GetOverlapFactor(new TimeRange(v.startdatum, v.enddatum), reference, true);
                if (result.HasValue)
                {
                    result += overlapFactor * v.wert;
                }
                else
                {
                    result = v.wert;
                }
                overallDenominator += overlapFactor;
            }
            if (result.HasValue)
            {
                return result / overallDenominator;
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Get list of those time ranges within the energiemenge where there are gaps. 
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns></returns>
        public static IList<TimeRange> GetMissingTimeRanges(this BO4E.BO.Energiemenge em)
        {
            return em.GetMissingTimeRanges(em.GetTimeRange());
        }

        /// <summary>
        /// Get a list of those time ranges within a reference, where no energieverbrauch entries are defined.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference timeframe</param>
        /// <param name="wev">Wertermittlungsverfahren</param>
        /// <param name="obis">OBIS-Kennzahl</param>
        /// <param name="me">Mengeneinheit</param>
        /// <returns></returns>
        public static List<TimeRange> GetMissingTimeRanges(this BO4E.BO.Energiemenge em, ITimeRange reference, Wertermittlungsverfahren wev, string obis, Mengeneinheit me)
        {
            using (MiniProfiler.Current.Step(nameof(GetMissingTimeRanges)))
            {
                IDictionary<Tuple<DateTime, DateTime>, Verbrauch> filteredVerbrauch;
                using (MiniProfiler.Current.Step($"Filtering energieverbrauch on OBIS={obis}, WEV={wev}, Mengeneinheit={me}"))
                {
                    filteredVerbrauch = em.energieverbrauch
                        .Where<Verbrauch>(v => v.wertermittlungsverfahren == wev && v.obiskennzahl == obis && v.einheit == me)
                        .ToDictionary(v => new Tuple<DateTime, DateTime>(v.startdatum, v.enddatum), v => v);
                }
                if (filteredVerbrauch.Count < 2)
                {
                    throw new ArgumentException("Not enough entries in energieverbrauch to determine periodicity.");
                }
                if (!IsEvenlySpaced(em, reference, wev, obis, me, true))
                {
                    throw new ArgumentException("The provided Energiemenge is not evenly spaced although gaps are allowed.");
                }
                TimeSpan periodicity = GetTimeSpans(em, wev, obis, me).Min<TimeSpan>();
                if (Math.Abs((reference.Start - em.GetMinDate()).TotalMilliseconds % periodicity.TotalMilliseconds) != 0)
                {
                    throw new ArgumentException($"The absolute difference between reference.start ({reference.Start}) and the minimal date time in the Energiemenge ({em.GetMinDate()}) has to be an integer multiple of the periodicity {periodicity.TotalMilliseconds} but was {(reference.Start - em.GetMinDate()).TotalMilliseconds}.");
                }
                // since it's assured, that the energieverbrauch entries are evenly spaced it doesn't matter which entry we use to determine the duration.
                TimeSpan duration = filteredVerbrauch.Values.Min(v => v.enddatum) - filteredVerbrauch.Values.Min(v => v.startdatum);
                List<TimeRange> result = new List<TimeRange>();
                using (MiniProfiler.Current.Step("Populating list with time slices in UTC"))
                {
                    for (DateTime dt = reference.Start; dt < reference.End; dt += periodicity)
                    {
                        // use a strict '==' instead of overlap. This is justified because all the other cases are considered beforehand
                        switch (dt.Kind)
                        {
                            case DateTimeKind.Local:
                                throw new ArgumentException("Local DateTime not supported!");
                            case DateTimeKind.Unspecified:
                                dt = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
                                break;
                            case DateTimeKind.Utc:
                                break;
                        }
                        //using (MiniProfiler.Current.Step("linq where on filtered verbrauch"))
                        //{
                        if (!filteredVerbrauch.ContainsKey(new Tuple<DateTime, DateTime>(dt, dt + duration)))//   Where<Verbrauch>(v => v.startdatum == dt && v.enddatum == dt + duration).Any())
                        {
                            result.Add(new TimeRange(dt, dt + duration));
                        }
                        //}
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// <see cref="GetMissingTimeRanges(BO.Energiemenge, TimeRange, Wertermittlungsverfahren, string, Mengeneinheit)"/>
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference time frame</param>
        /// <returns></returns>
        public static List<TimeRange> GetMissingTimeRanges(this BO4E.BO.Energiemenge em, TimeRange reference)
        {
            if (!em.IsPure())
            {
                throw new ArgumentException("The Energiemenge you provided is not pure. Consider using the overloaded method.");
            }
            Verbrauch v = em.energieverbrauch.FirstOrDefault();
            return GetMissingTimeRanges(em, reference, v.wertermittlungsverfahren, v.obiskennzahl, v.einheit);
        }

        /// <summary>
        /// Test, if the single entries/intervals of the energieverbrauch array share the same duration and spacing in time.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference time frame</param>
        /// <param name="wev">Wertermittlungsverfahren</param>
        /// <param name="obis">OBIS-Kennzahl</param>
        /// <param name="me">Mengeneinheit</param>
        /// <param name="allowGaps">set true to allow gaps</param>
        /// <returns>True, if all energieverbrauch entries have the same length and their start and enddatum are evenly spaced.
        /// Also true, if there less than 2 entries in the energieverbrauch array.</returns>
        public static bool IsEvenlySpaced(this BO4E.BO.Energiemenge em, ITimeRange reference, Wertermittlungsverfahren wev, string obis, Mengeneinheit me, bool allowGaps = false)
        {
            HashSet<TimeSpan> startEndDatumPeriods;
            using (MiniProfiler.Current.Step("finding time spans"))
            {
                startEndDatumPeriods = GetTimeSpans(em, wev, obis, me);
            }
            if (startEndDatumPeriods.Count < 2)
            {
                return true;
            }
            if (allowGaps)
            {
                // each time difference must be a multiple of the smallest difference.
                using (MiniProfiler.Current.Step("Iterating over all time spans"))
                {
                    double minDiff = startEndDatumPeriods.Min<TimeSpan>().TotalSeconds;
                    foreach (TimeSpan ts in startEndDatumPeriods)
                    {
                        if (Math.Abs(ts.TotalSeconds % minDiff) != 0)
                        {
                            // use profiler as logger:
                            using (MiniProfiler.Current.Step($"Found TimeSpan {ts} with a duration of {ts.TotalSeconds}. This is no multiple of {minDiff} => not evenly spaced."))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                // there must be only 1 time difference between all the elements
                return startEndDatumPeriods.Count <= 1;
            }
        }

        /// <summary>
        /// <see cref="IsEvenlySpaced(BO.Energiemenge, TimeRange, Wertermittlungsverfahren, string, Mengeneinheit, bool)"/>
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="allowGaps"></param>
        /// <returns></returns>
        public static bool IsEvenlySpaced(this BO4E.BO.Energiemenge em, bool allowGaps = false)
        {
            if (!em.IsPure())
            {
                // Find all combinations of Wertermittlungsverfahren, obis and Mengeneinheit.
                // The Energiemenge is evenly spaced if each of the combinations is evenly spaced itself.
                using (MiniProfiler.Current.Step("Check all Werte/Einheit/OBIS combinations"))
                {
                    ISet<Tuple<Wertermittlungsverfahren, string, Mengeneinheit>> combinations = GetWevObisMeCombinations(em);
                    foreach (Tuple<Wertermittlungsverfahren, string, Mengeneinheit> combo in combinations)
                    {
                        if (!em.IsEvenlySpaced(em.GetTimeRange(), combo.Item1, combo.Item2, combo.Item3, allowGaps))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                Verbrauch v = em.energieverbrauch.FirstOrDefault();
                return em.IsEvenlySpaced(em.GetTimeRange(), v.wertermittlungsverfahren, v.obiskennzahl, v.einheit, allowGaps);
            }
        }



        private static HashSet<TimeSpan> GetTimeSpans(this BO4E.BO.Energiemenge em)
        {
            HashSet<TimeSpan> result = new HashSet<TimeSpan>();
            List<Verbrauch> vlist = new List<Verbrauch>(em.energieverbrauch);
            vlist.Sort(new VerbrauchDateTimeComparer());
            for (int i = 1; i < vlist.Count; i++)
            {
                result.Add(vlist[i].startdatum - vlist[i - 1].startdatum);
                result.Add(vlist[i].enddatum - vlist[i - 1].enddatum);
            }
            return result;
        }

        private static HashSet<TimeSpan> GetTimeSpans(this BO4E.BO.Energiemenge em, Wertermittlungsverfahren wev, string obis, Mengeneinheit me)
        {
            HashSet<TimeSpan> result = new HashSet<TimeSpan>();
            List<Verbrauch> vlist = new List<Verbrauch>(em.energieverbrauch);
            vlist.Sort(new VerbrauchDateTimeComparer());
            vlist = vlist.Where<Verbrauch>(v => v.wertermittlungsverfahren == wev && v.obiskennzahl == obis && v.einheit == me).ToList<Verbrauch>();
            for (int i = 1; i < vlist.Count; i++)
            {
                result.Add(vlist[i].startdatum - vlist[i - 1].startdatum);
                result.Add(vlist[i].enddatum - vlist[i - 1].enddatum);
            }
            return result;
        }

        /// <summary>
        /// get all (Wertermittlungsverfahren, OBIS, Mengeneinheit) tuples occurring in <paramref name="em"/>
        /// </summary>
        /// <param name="em">em</param>
        /// <returns>A Set of tuples of all (Wertermittlungsverfahren, OBIS, Mengeneinheit) combinations</returns>
        public static ISet<Tuple<Wertermittlungsverfahren, string, Mengeneinheit>> GetWevObisMeCombinations(this BO4E.BO.Energiemenge em)
        {
            return new HashSet<Tuple<Wertermittlungsverfahren, string, Mengeneinheit>>(
                em.energieverbrauch
                //.AsParallel<Verbrauch>()
                .Select(v => Tuple.Create<Wertermittlungsverfahren, string, Mengeneinheit>(v.wertermittlungsverfahren, v.obiskennzahl, v.einheit)));
        }

        /// <summary>
        /// Get percentage of time range covered by all Wertermittlungsverfahren/OBIS/Mengeneinheit
        /// combinations, that are present in the Energiemenge-&gt;energieverbrauch array.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference</param>
        /// <returns></returns>
        public static decimal GetJointCoverage(this BO4E.BO.Energiemenge em, TimeRange reference)
        {
            ISet<Tuple<Wertermittlungsverfahren, string, Mengeneinheit>> combinations = GetWevObisMeCombinations(em);
            decimal jointCoverage = em.energieverbrauch
                //.AsParallel<Verbrauch>()
                .Where<Verbrauch>(v => combinations.Contains(Tuple.Create<Wertermittlungsverfahren, string, Mengeneinheit>(v.wertermittlungsverfahren, v.obiskennzahl, v.einheit)))
                .Sum(v => GetOverlapFactor(new TimeRange(v.startdatum, v.enddatum), reference, true));
            return jointCoverage - (combinations.Count - 1);
        }

        /// <summary>
        /// Get percentage of time range covered by pure Energiemenge.
        /// </summary>
        /// <param name="em">pure Energiemenge</param>
        /// <param name="reference">time frame reference</param>
        /// <returns>value between 0 (only coverage for 1 point in time) and 1.0 (100% coverage)</returns>
        public static decimal GetCoverage(this BO4E.BO.Energiemenge em, ITimeRange reference)
        {
            using (MiniProfiler.Current.Step(nameof(GetCoverage)))
            {
                if (!IsPure(em))
                {
                    throw new ArgumentException("The Energiemenge is not pure. Cannot determine parameters.");
                }
                if (em.energieverbrauch.Count == 0)
                {
                    return 0.0M;
                }
                Verbrauch v = em.energieverbrauch.First<Verbrauch>();
                return em.GetCoverage(reference, v.wertermittlungsverfahren, v.obiskennzahl, v.einheit);
            }
        }

        /// <summary>
        /// Get percentage of full time range of energiemenge which is covered with values.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>value between 0 (only coverage for 1 point in time) and 1.0 (100% coverage)</returns>
        public static decimal GetCoverage(this BO4E.BO.Energiemenge em)
        {
            return em.GetCoverage(em.GetTimeRange());
        }

        /// <summary>
        /// Get ratio of overlap between given Energiemenge and a reference.
        /// Method is basically just another name for <see cref="GetOverlapFactor(TimeRange, TimeRange, bool)"/>
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference time range</param>
        /// <param name="obisKz">OBIS</param>
        /// <param name="mengeneinheit">unit of measurement</param>
        /// <param name="wev">type of measurement</param>
        /// <param name="decimalRounding">post decimals</param>
        /// <returns>value between 0 (no overlap) and 1.0 (100% overlap)</returns>
        public static decimal GetCoverage(this BO4E.BO.Energiemenge em, ITimeRange reference,
            Wertermittlungsverfahren wev, string obisKz, Mengeneinheit mengeneinheit, int decimalRounding = 10)
        {
            decimal exactResult;
            using (MiniProfiler.Current.Step($"calculating coverage for list with {em.energieverbrauch.Count} entries."))
            {
                exactResult = em.energieverbrauch
                    //.AsParallel<Verbrauch>()
                    .Where<Verbrauch>(v => v.einheit == mengeneinheit && v.obiskennzahl == obisKz && v.wertermittlungsverfahren == wev)
                    .Sum(v => GetOverlapFactor(new TimeRange(v.startdatum, v.enddatum), reference, true));
            }
            return Math.Round(exactResult, decimalRounding);
        }

        /// <summary>
        /// Test, if the Energiemenge is continuous within its own min/max range.
        /// <see cref="IsContinuous(BO.Energiemenge, TimeRange)"/>
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>true iff Energiemenge has defined value for every point in time t in
        /// min(energieverbrauch.startdatum) &lt;= t &lt; max(energieverbrauch.enddatum);
        /// false otherwise
        /// </returns>
        public static bool IsContinuous(this BO4E.BO.Energiemenge em)
        {
            return IsContinuous(em, new TimeRange(em.GetMinDate(), em.GetMaxDate()));
        }

        /// <summary>
        /// Test, if the Energiemenge does have a defined value for every point in time within the given time range.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">time range to check</param>
        /// <returns>true iff Energiemenge has defined value for every point in time range, false otherwise</returns>
        public static bool IsContinuous(this BO4E.BO.Energiemenge em, TimeRange reference)
        {
            return Math.Abs(em.energieverbrauch.Sum(v => GetOverlapFactor(new TimeRange(v.startdatum, v.enddatum), reference, true)) - 1.0M) < QUASI_ZERO;
        }

        private static decimal GetOverlapFactor(TimeRange period, ITimeRange reference, bool toReference)
        {
            TimePeriodCollection periods = new TimePeriodCollection
            {
                reference,
                period
            };
            TimePeriodIntersector<TimeRange> periodIntersector = new TimePeriodIntersector<TimeRange>();
            ITimePeriodCollection intersectedPeriods = periodIntersector.IntersectPeriods(periods);
            try
            {
                if (toReference)
                {
                    return (decimal)intersectedPeriods.TotalDuration.TotalSeconds / (decimal)reference.Duration.TotalSeconds;
                }
                else // to self
                {
                    return (decimal)intersectedPeriods.TotalDuration.TotalSeconds / (decimal)period.Duration.TotalSeconds;
                }
            }
            catch (DivideByZeroException)
            {
                return 0.0M;
            }
        }

        /// <summary>
        /// shortcut for <see cref="IsPureMengeneinheit(BO.Energiemenge)"/> &amp;&amp; <see cref="IsPureObisKennzahl(BO.Energiemenge)"/> &amp;&amp; <see cref="IsPureWertermittlungsverfahren(BO.Energiemenge)"/>
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="checkUserProperties">set true, to additionally check if user properties of all entries in energieverbrauch are equal.</param>
        /// <returns>true iff the Energiemenge is pure in all OBIS-Kennzahl, Wertermittlungsverfahren and Mengeneinheit</returns>
        public static bool IsPure(this BO.Energiemenge em, bool checkUserProperties = false)
        {
            bool basicPurity;
            using (MiniProfiler.Current.Step(nameof(IsPure)))
            {
                basicPurity = em.IsPureMengeneinheit() && em.IsPureObisKennzahl() && em.IsPureWertermittlungsverfahren();
            }
            if (basicPurity && checkUserProperties)
            {
                bool upPurity = em.IsPureUserProperties();
                return upPurity && basicPurity;
            }
            else
            {
                return basicPurity;
            }
        }

        /// <summary>
        /// test if Energiemenge has only one <see cref="Wertermittlungsverfahren"/>
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>true iff the Energiemenge-&gt;energieverbrauch list has at most one distinct Wertermittlungsverfahren</returns>
        public static bool IsPureWertermittlungsverfahren(this BO4E.BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step(nameof(IsPureWertermittlungsverfahren)))
            {
                ISet<Wertermittlungsverfahren> wefs = new HashSet<Wertermittlungsverfahren>();
                em.energieverbrauch.All<Verbrauch>(v => wefs.Add(v.wertermittlungsverfahren));
                return wefs.Count <= 1;
            }
        }

        /// <summary>
        /// test if Energiemenge has only one Obiskennzahl
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>true iff the Energiemenge-&gt;energieverbrauch list has at most one distinct Obiskennzahl</returns>
        public static bool IsPureObisKennzahl(this BO4E.BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step(nameof(IsPureObisKennzahl)))
            {
                ISet<string> obisKzs = new HashSet<string>();
                em.energieverbrauch.All<Verbrauch>(v => obisKzs.Add(v.obiskennzahl));
                return obisKzs.Count <= 1;
            }
        }

        /// <summary>
        /// test if all entries in <see cref="BO4E.BO.Energiemenge.energieverbrauch"/> do have same user properties.
        /// Only tests for those user properties present. Missing user properties do not lead to false.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns></returns>
        public static bool IsPureUserProperties(this BO4E.BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step(nameof(IsPureUserProperties)))
            {
                ISet<string> upKeys = new HashSet<string>(em.energieverbrauch.Where(v => v.userProperties != null).SelectMany(v => v.userProperties.Keys));
                var values = new Dictionary<string, JToken>();
                // ToDo: make it nice.
                foreach (var v in em.energieverbrauch.Where(v => v.userProperties != null))
                {
                    foreach (var key in upKeys)
                    {
                        if (v.userProperties.TryGetValue(key, out JToken rawValue))
                        {
                            if (values.TryGetValue(key, out JToken onlyValue))
                            {
                                if (!rawValue.Equals(onlyValue))
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                values.Add(key, rawValue);
                            }
                        }
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// test if Energiemenge has only one <see cref="Mengeneinheit"/>
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>true iff the Energiemenge-&gt;energieverbrauch list does only contain entries with mutually convertible units</returns>
        public static bool IsPureMengeneinheit(this BO4E.BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step(nameof(IsPureMengeneinheit)))
            {
                ISet<Mengeneinheit> einheiten = new HashSet<Mengeneinheit>();
                em.energieverbrauch.All<Verbrauch>(v => einheiten.Add(v.einheit));

                if (einheiten.Count <= 1)
                {
                    return true;
                }
                else
                {
                    Mengeneinheit me1 = einheiten.First<Mengeneinheit>();
                    foreach (Mengeneinheit me2 in einheiten)
                    {
                        if (!me1.IsConvertibleTo(me2))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }

        /// <summary>
        /// opposite of <see cref="IsExtensive(BO.Energiemenge)"/>
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>true iff all <paramref name="em"/>-&gt;energieverbrauch entries are intensive</returns>
        public static bool IsIntensive(this BO4E.BO.Energiemenge em)
        {
            return !em.IsExtensive();
        }

        /// <summary>
        /// Test if the energiemenge contains only extensive consumption units
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>true iff all <paramref name="em"/>-&gt;energieverbrauch entries are extensive</returns>
        public static bool IsExtensive(this BO4E.BO.Energiemenge em)
        {
            return em.IsPureMengeneinheit() && em.energieverbrauch.First<Verbrauch>().einheit.IsExtensive();
        }

        public static List<BO.Energiemenge> SplitInPureGroups(this BO.Energiemenge em)
        {
            if (em.energieverbrauch == null)
            {
                return new List<BO.Energiemenge>() { em };
            }
            else
            {
                var result = new List<BO.Energiemenge>();
                foreach (var group in em.energieverbrauch.GroupBy(PurityGrouper))
                {
                    BO.Energiemenge pureEm = em.DeepClone();
                    pureEm.energieverbrauch = group.ToList();
                    result.Add(pureEm);
                }
                return result;
            }
        }

        /// <summary>
        /// Our SAP CDS has a bug: When there's a change from non-DST to DST the <see cref="Verbrauch.enddatum"/> is set
        /// to the first second of the DST period. To 
        /// </summary>
        /// <param name="em"></param>
        public static void FixSapCDSBug(this BO4E.BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step("Fix SAP CDS Bug (Energiemenge)"))
            {
                if (em.energieverbrauch != null && !em.HasBeenSanitized())
                {
                    using (MiniProfiler.Current.Step($"for each Verbrauch entry: {nameof(FixSapCDSBug)}"))
                    {
                        foreach (var v in em.energieverbrauch)
                        {
                            v.FixSapCdsBug();
                        }
                        //em.energieverbrauch = em.energieverbrauch.Select(v => Verbrauch.FixSapCdsBug(v)).ToList();
                    }
                    using (MiniProfiler.Current.Step("for list as a whole"))
                    {
                        foreach (var relevantEnddatum in em.energieverbrauch.Where(v =>
                             {
                                 var localEnd = DateTime.SpecifyKind(v.enddatum, DateTimeKind.Unspecified);
                                 var localStart = DateTime.SpecifyKind(v.startdatum, DateTimeKind.Unspecified);
                                 return !Verbrauch.CENTRAL_EUROPE_STANDARD_TIME.IsDaylightSavingTime(localStart) && Verbrauch.CENTRAL_EUROPE_STANDARD_TIME.IsDaylightSavingTime(localEnd);
                                 //return !localStart.IsDaylightSavingTime() && localEnd.IsDaylightSavingTime();
                             }).Select(v => v.enddatum))
                        {
                            var intervalSize = em.energieverbrauch.Where(v => v.enddatum == relevantEnddatum).Select(v => (v.enddatum - v.startdatum).TotalSeconds).Min();
                            foreach (var v in em.energieverbrauch.Where(v => v.enddatum == relevantEnddatum))
                            {
                                v.enddatum = v.startdatum.AddSeconds(intervalSize);
                            }
                        }
                        if (em.energieverbrauch.Where(v => (v.enddatum - v.startdatum).TotalMinutes == -45).Count() > 1)
                        {
                            /*foreach (var dstAffected in em.energieverbrauch.Where(v => (v.enddatum - v.startdatum).TotalMinutes != -45))                          
                            {
                                Verbrauch anythingButEnddatum = dstAffected.DeepClone<Verbrauch>();
                                anythingButEnddatum.enddatum = DateTime.MinValue;
                                anythingButEnddatum.wert = 0;
                                foreach(var v in em.energieverbrauch.Where(v=>
                                {
                                    var comp = v.DeepClone<Verbrauch>();
                                    comp.enddatum = DateTime.MinValue;
                                    comp.wert = 0;
                                    return comp.Equals(anythingButEnddatum);
                                }))
                                {
                                    int a = 0;
                                }
                            }*/
                        }
                    }
                    if (em.userProperties == null)
                    {
                        em.userProperties = new Dictionary<string, JToken>();
                    }
                    em.userProperties[SAP_SANITIZED_USERPROPERTY_KEY] = true;
                }
            }
        }


        private const string SAP_SANITIZED_USERPROPERTY_KEY = "sapSanitized";
        /// <summary>
        /// tests if the method <see cref="Verbrauch.FixSapCdsBug"/> has been executed yet.
        /// </summary>
        /// <returns>true if Energiemenge has been sanitized</returns>
        private static bool HasBeenSanitized(this BO4E.BO.Energiemenge em)
        {
            bool sanitized;
            if (em.userProperties == null || !em.userProperties.TryGetValue(SAP_SANITIZED_USERPROPERTY_KEY, out JToken sapSanitizedToken))
            {
                sanitized = false;
            }
            else
            {
                sanitized = sapSanitizedToken.Value<bool>();
            }
            return sanitized;
        }

        public static void Detangle(this BO4E.BO.Energiemenge em)
        {
            if (em.energieverbrauch != null)
            {
                em.energieverbrauch = VerbrauchExtension.Detangle(em.energieverbrauch);
            }
        }

        protected class BasicVerbrauchDateTimeComparer : IComparer<CompletenessReport.BasicVerbrauch>
        {
            int IComparer<CompletenessReport.BasicVerbrauch>.Compare(CompletenessReport.BasicVerbrauch x, CompletenessReport.BasicVerbrauch y)
            {
                Verbrauch vx = new Verbrauch
                {
                    startdatum = x.startdatum,
                    enddatum = x.enddatum,
                };
                Verbrauch vy = new Verbrauch
                {
                    startdatum = y.startdatum,
                    enddatum = y.enddatum,
                };
                IComparer<Verbrauch> cv = new VerbrauchDateTimeComparer();
                return cv.Compare(vx, vy);
            }
        }

        private static readonly Func<Verbrauch, Tuple<Wertermittlungsverfahren, Mengeneinheit, string>> PurityGrouper = v => new Tuple<Wertermittlungsverfahren, Mengeneinheit, string>(v.wertermittlungsverfahren, v.einheit, v.obiskennzahl);

    }
}
