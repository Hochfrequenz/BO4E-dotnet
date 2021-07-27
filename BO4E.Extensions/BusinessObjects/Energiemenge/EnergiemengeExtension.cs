using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.Extensions.COM;
using BO4E.Extensions.ENUM;
using BO4E.meta;
using BO4E.Reporting;
using Itenso.TimePeriod;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Profiling;
using static BO4E.Extensions.COM.VerbrauchExtension;


namespace BO4E.Extensions.BusinessObjects.Energiemenge
{
    /// <summary>Do calculations on top of an Energiemenge BO4E.</summary>
    public static partial class EnergiemengeExtension
    {
        private const decimal QUASI_ZERO = 0.00000000001M;


        private const string SAP_SANITIZED_USERPROPERTY_KEY = "sapSanitized";

        private static readonly Func<Verbrauch, Tuple<Wertermittlungsverfahren, Mengeneinheit, string>> PurityGrouper =
            v => new Tuple<Wertermittlungsverfahren, Mengeneinheit, string>(v.Wertermittlungsverfahren, v.Einheit,
                v.Obiskennzahl);

        /// <summary>
        ///     Get Zeitraum covered by Energiemenge.
        /// </summary>
        /// <param name="menge">Energiemenge</param>
        /// <returns>
        ///     Zeitraum ranging from the earliest <see cref="Verbrauch.Startdatum" /> to the latest
        ///     <see cref="Verbrauch.Enddatum" />
        /// </returns>
        public static Zeitraum GetZeitraum(this BO.Energiemenge menge)
        {
            using (MiniProfiler.Current.Step(nameof(GetZeitraum)))
            {
                var zeitraum = new Zeitraum
                {
                    Startdatum = GetMinDate(menge),
                    Enddatum = GetMaxDate(menge)
                };
                return zeitraum;
            }
        }

        /// <summary>
        ///     Get TimeRange covered by Energiemenge
        /// </summary>
        /// <param name="menge">Energiemenge</param>
        /// <returns>
        ///     TimeRange ranging from the earliest <see cref="Verbrauch.Startdatum" /> to the latest
        ///     <see cref="Verbrauch.Enddatum" />
        /// </returns>
        /// <returns></returns>
        public static TimeRange GetTimeRange(this BO.Energiemenge menge)
        {
            using (MiniProfiler.Current.Step(nameof(GetTimeRange)))
            {
                return new TimeRange(menge.GetMinDate().UtcDateTime, menge.GetMaxDate().UtcDateTime);
            }
        }


        /* 
         * If GetMinDate() or GetMaxDate() throws an InvalidOperationException you shouldn't catch 
         * it here but allow the programmer to handle it higher up in the stack trace.
         * This usually happens if one tries to use the auto-configuration feature but the 
         * Energieverbrauch array is empty. The result is simply undefined. Returning null
         * would require all dependent methods to properly handle the null value. Since this 
         * would probably lead to unspecific NullReferenceExceptions we'd better let the invalid
         * operation exception bubble up from here as far as it's required.
         */
        private static DateTimeOffset GetMinDate(this BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step(nameof(GetMinDate)))
            {
                return em.Energieverbrauch.Min(ev => ev.Startdatum); // don't catch!
            }
        }

        private static DateTimeOffset GetMaxDate(this BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step(nameof(GetMinDate)))
            {
                return em.Energieverbrauch.Max(ev => ev.Enddatum); // don't catch!
            }
        }

        /// <summary>
        ///     Same as
        ///     <see
        ///         cref="GetTotalConsumption(BO4E.BO.Energiemenge,BO4E.ENUM.Wertermittlungsverfahren,string,BO4E.ENUM.Mengeneinheit)" />
        ///     but without auto-detected parameters.
        ///     By default a the full length of the Energiemenge is taken into account.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>Tuple of consumption value and unit of measurement</returns>
        public static Tuple<decimal, Mengeneinheit> GetTotalConsumption(this BO.Energiemenge em)
        {
            return GetConsumption(em, new TimeRange(em.GetMinDate().UtcDateTime, em.GetMaxDate().UtcDateTime));
        }

        /// <summary>
        ///     Get total consumption for given parameters
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="wev">type of measurement</param>
        /// <param name="obiskennzahl">OBIS</param>
        /// <param name="me">unit of measurement</param>
        /// <returns>consumption value</returns>
        public static decimal GetTotalConsumption(this BO.Energiemenge em,
            Wertermittlungsverfahren wev, string obiskennzahl, Mengeneinheit me)
        {
            return em.GetConsumption(em.GetTimeRange(), wev, obiskennzahl, me);
        }

        /// <summary>
        ///     Get consumption in given time reference frame.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">time reference frame</param>
        /// <returns>Tuple of consumption value and automatically determined unit of measurement</returns>
        public static Tuple<decimal, Mengeneinheit> GetConsumption(this BO.Energiemenge em, ITimeRange reference)
        {
            using (MiniProfiler.Current.Step(nameof(GetConsumption)))
            {
                if (!IsPure(em)) throw new ArgumentException("The Energiemenge is not pure.");
                if (em.Energieverbrauch.Count == 0) return Tuple.Create(0.0M, Mengeneinheit.ANZAHL);
                ISet<Mengeneinheit> einheiten = new HashSet<Mengeneinheit>(em.Energieverbrauch.Select(x => x.Einheit));
                if (einheiten.Count > 1)
                    // z.B. kWh und Wh oder Monat und Jahr... Die liefern IsPure==true.
                    throw new NotImplementedException("Converting different units of same type is not supported yet.");
                var v = em.Energieverbrauch.First();
                var consumption = em.GetConsumption(reference, v.Wertermittlungsverfahren, v.Obiskennzahl, v.Einheit);
                return Tuple.Create(consumption, v.Einheit);
            }
        }

        /// <summary>
        ///     Returns the consumption of a given kind of Mengeneinheit within the specified reference time range.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference time frame</param>
        /// <param name="wev">Wertermittlungsverfahren</param>
        /// <param name="obiskennzahl">OBIS number</param>
        /// <param name="me">an extensive unit (e.g. "kWh")</param>
        /// <returns>
        ///     the consumption within the give time slice <paramref name="reference" /> in the unit passed as
        ///     <paramref name="me" />
        /// </returns>
        public static decimal GetConsumption(this BO.Energiemenge em, ITimeRange reference,
            Wertermittlungsverfahren wev, string obiskennzahl, Mengeneinheit me)
        {
            if (!me.IsExtensive())
                throw new ArgumentException(
                    $"The Mengeneinheit {me} isn't extensive. Calculating a consumption doesn't make sense.");
            return em.Energieverbrauch
                .Where(v => v.Wertermittlungsverfahren == wev && v.Obiskennzahl == obiskennzahl && v.Einheit == me)
                .Sum(v => GetOverlapFactor(new TimeRange(v.Startdatum, v.Enddatum), reference, false) * v.Wert);
        }

        /// <summary>
        ///     normalise energiemenge-&gt;energieverbrauch consumption values to a given <paramref name="target" /> value
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="target">normalising constant (1.0 by default)</param>
        /// <returns>new Energiemenge object with normalised consumption values</returns>
        public static BO.Energiemenge Normalise(this BO.Energiemenge em, decimal target = 1.0M)
        {
            using (MiniProfiler.Current.Step(nameof(Normalise)))
            {
                BO.Energiemenge result;
                decimal scalingFactor;
                Tuple<decimal, Mengeneinheit> totalConsumption;
                using (MiniProfiler.Current.Step("Calculating total consumption and normalisation factor."))
                {
                    totalConsumption = em.GetTotalConsumption();
                    result = em.DeepClone();
                    if (totalConsumption.Item1 != 0.0M)
                        scalingFactor = target / totalConsumption.Item1;
                    else
                        scalingFactor = 0.0M;
                }

                using (MiniProfiler.Current.Step("Parallelised normalising of all values."))
                {
                    Parallel.ForEach(result.Energieverbrauch.Where(v => v.Einheit == totalConsumption.Item2),
                        v => { v.Wert = scalingFactor * v.Wert; });
                }

                return result;
            }
        }

        /// <summary>
        ///     Returns the load in an intensive unit for a given point in time.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="me">an intensive unit (e.g. "kW")</param>
        /// <param name="dt">point in time</param>
        /// <returns>load if Energiemenge BO contains value for specified date time<paramref name="dt" />, null otherwise</returns>
        public static decimal? GetLoad(this BO.Energiemenge em, Mengeneinheit me, DateTime dt)
        {
            if (!me.IsIntensive())
                throw new ArgumentException(
                    $"The Mengeneinheit {me} isn't intensive. Calculating the value for a specific point in time doesn't make sense.");
            decimal? result = null;
            foreach (var v in em.Energieverbrauch.Where(v => v.Startdatum <= dt && dt < v.Enddatum))
                if (result.HasValue)
                    result += v.Wert;
                else
                    result = v.Wert;
            return result;
        }

        /// <summary>
        ///     Get Average (<see cref="GetAverage(BO.Energiemenge, TimeRange, Wertermittlungsverfahren, string, Mengeneinheit)" />
        ///     )
        ///     for a pure Energiemenge with automatically found parameters.
        /// </summary>
        /// <seealso cref="IsPure" />
        /// <param name="em">Energiemenge</param>
        /// <returns>Tuple of average value and unit of measurement</returns>
        public static Tuple<decimal?, Mengeneinheit> GetAverage(this BO.Energiemenge em)
        {
            if (!IsPure(em)) throw new ArgumentException("Energiemenge is not pure.");

            if (em.Energieverbrauch.Count == 0) return Tuple.Create<decimal?, Mengeneinheit>(null, Mengeneinheit.KW);
            var v = em.Energieverbrauch.First();
            return Tuple.Create(em.GetAverage(v.Wertermittlungsverfahren, v.Obiskennzahl, v.Einheit), v.Einheit);
        }

        /// <summary>
        ///     Same as <see cref="GetAverage(BO4E.BO.Energiemenge)" /> but without specifying a time slice.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="wev">type of measurement</param>
        /// <param name="obiskennzahl">OBIS</param>
        /// <param name="me">an intensive or extensive unit</param>
        /// <returns>
        ///     The average for the given Mengeneinheit for the Energiemenge object or null if there was no Verbrauch for the
        ///     given Mengeneinheit.
        /// </returns>
        public static decimal? GetAverage(this BO.Energiemenge em,
            Wertermittlungsverfahren wev, string obiskennzahl, Mengeneinheit me)
        {
            return em.GetAverage(em.GetTimeRange(), wev, obiskennzahl, me);
        }

        /// <summary>
        ///     Get average of Mengeneinheit for given time interval
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference time frame</param>
        /// <param name="wev">Wertermittlungsverfahren</param>
        /// <param name="obiskennzahl">OBIS</param>
        /// <param name="me">an extensive or intensive unit</param>
        /// <returns>the average value or null if no Verbrauch overlapped with the specified time interval</returns>
        public static decimal? GetAverage(this BO.Energiemenge em, TimeRange reference,
            Wertermittlungsverfahren wev, string obiskennzahl, Mengeneinheit me)
        {
            decimal? result = null;
            var overallDenominator = 0.0M;
            foreach (var v in em.Energieverbrauch.Where(v => v.Einheit == me))
            {
                var overlapFactor = GetOverlapFactor(new TimeRange(v.Startdatum, v.Enddatum), reference, true);
                if (result.HasValue)
                    result += overlapFactor * v.Wert;
                else
                    result = v.Wert;
                overallDenominator += overlapFactor;
            }

            if (result.HasValue) return result / overallDenominator;

            return null;
        }

        /// <summary>
        ///     Get list of those time ranges within the energiemenge where there are gaps.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns></returns>
        public static IList<TimeRange> GetMissingTimeRanges(this BO.Energiemenge em)
        {
            return em.GetMissingTimeRanges(em.GetTimeRange());
        }

        /// <summary>
        ///     Get a list of those time ranges within a reference, where no energieverbrauch entries are defined.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference time frame</param>
        /// <param name="wev">Wertermittlungsverfahren</param>
        /// <param name="obis">OBIS-Kennzahl</param>
        /// <param name="me">Mengeneinheit</param>
        /// <returns></returns>
        public static List<TimeRange> GetMissingTimeRanges(this BO.Energiemenge em, ITimeRange reference,
            Wertermittlungsverfahren wev, string obis, Mengeneinheit me)
        {
            using (MiniProfiler.Current.Step(nameof(GetMissingTimeRanges)))
            {
                IDictionary<Tuple<DateTime, DateTime>, Verbrauch> filteredVerbrauch;
                using (MiniProfiler.Current.Step(
                    $"Filtering energieverbrauch on OBIS={obis}, WEV={wev}, Mengeneinheit={me}"))
                {
                    filteredVerbrauch = em.Energieverbrauch
                        .Where(v => v.Wertermittlungsverfahren == wev && v.Obiskennzahl == obis && v.Einheit == me)
                        .ToDictionary(v => new Tuple<DateTime, DateTime>(v.Startdatum, v.Enddatum), v => v);
                }

                if (filteredVerbrauch.Count < 2)
                    throw new ArgumentException("Not enough entries in energieverbrauch to determine periodicity.");
                if (!IsEvenlySpaced(em, reference, wev, obis, me, true))
                    throw new ArgumentException(
                        "The provided Energiemenge is not evenly spaced although gaps are allowed.");
                var periodicity = GetTimeSpans(em, wev, obis, me).Min();
                if (
                    Math.Abs((reference.Start - em.GetMinDate()).TotalMilliseconds % periodicity.TotalMilliseconds) !=
                    0)
                    throw new ArgumentException(
                        $"The absolute difference between reference.start ({reference.Start}) and the minimal date time in the Energiemenge ({em.GetMinDate()}) has to be an integer multiple of the periodicity {periodicity.TotalMilliseconds} but was {(reference.Start - em.GetMinDate()).TotalMilliseconds}.");
                // since it's assured, that the energieverbrauch entries are evenly spaced it doesn't matter which entry we use to determine the duration.
                var duration = filteredVerbrauch.Values.Min(v => v.Enddatum) -
                               filteredVerbrauch.Values.Min(v => v.Startdatum);
                var result = new List<TimeRange>();
                using (MiniProfiler.Current.Step("Populating list with time slices in UTC"))
                {
                    for (var dt = reference.Start; dt < reference.End; dt += periodicity)
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
                        if (!filteredVerbrauch.ContainsKey(
                            new Tuple<DateTime, DateTime>(dt,
                                dt + duration))) //   Where<Verbrauch>(v => v.startdatum == dt && v.enddatum == dt + duration).Any())
                            result.Add(new TimeRange(dt, dt + duration));
                        //}
                    }
                }

                return result;
            }
        }

        /// <summary>
        ///     <see cref="GetMissingTimeRanges(BO4E.BO.Energiemenge)" />
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference time frame</param>
        /// <returns></returns>
        public static List<TimeRange> GetMissingTimeRanges(this BO.Energiemenge em, TimeRange reference)
        {
            if (!em.IsPure())
                throw new ArgumentException(
                    "The Energiemenge you provided is not pure. Consider using the overloaded method.");
            var v = em.Energieverbrauch.FirstOrDefault();
            return GetMissingTimeRanges(em, reference, v.Wertermittlungsverfahren, v.Obiskennzahl, v.Einheit);
        }

        /// <summary>
        ///     Test, if the single entries/intervals of the energieverbrauch array share the same duration and spacing in time.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference time frame</param>
        /// <param name="wev">Wertermittlungsverfahren</param>
        /// <param name="obis">OBIS-Kennzahl</param>
        /// <param name="me">Mengeneinheit</param>
        /// <param name="allowGaps">set true to allow gaps</param>
        /// <returns>
        ///     True, if all energieverbrauch entries have the same length and their start and enddatum are evenly spaced.
        ///     Also true, if there less than 2 entries in the energieverbrauch array.
        /// </returns>
        public static bool IsEvenlySpaced(this BO.Energiemenge em, ITimeRange reference, Wertermittlungsverfahren wev,
            string obis, Mengeneinheit me, bool allowGaps = false)
        {
            HashSet<TimeSpan> startEndDatumPeriods;
            using (MiniProfiler.Current.Step("finding time spans"))
            {
                startEndDatumPeriods = GetTimeSpans(em, wev, obis, me);
            }

            if (startEndDatumPeriods.Count < 2) return true;
            if (allowGaps)
            {
                // each time difference must be a multiple of the smallest difference.
                using (MiniProfiler.Current.Step("Iterating over all time spans"))
                {
                    var minDiff = startEndDatumPeriods.Min().TotalSeconds;
                    foreach (var ts in startEndDatumPeriods)
                        if (Math.Abs(ts.TotalSeconds % minDiff) != 0)
                            // use profiler as logger:
                            using (MiniProfiler.Current.Step(
                                $"Found TimeSpan {ts} with a duration of {ts.TotalSeconds}. This is no multiple of {minDiff} => not evenly spaced."))
                            {
                                return false;
                            }
                }

                return true;
            }

            // there must be only 1 time difference between all the elements
            return startEndDatumPeriods.Count <= 1;
        }

        /// <summary>
        ///     <see
        ///         cref="IsEvenlySpaced(BO4E.BO.Energiemenge,Itenso.TimePeriod.ITimeRange,BO4E.ENUM.Wertermittlungsverfahren,string,BO4E.ENUM.Mengeneinheit,bool)" />
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="allowGaps"></param>
        /// <returns></returns>
        public static bool IsEvenlySpaced(this BO.Energiemenge em, bool allowGaps = false)
        {
            if (!em.IsPure())
            {
                // Find all combinations of Wertermittlungsverfahren, obis and Mengeneinheit.
                // The Energiemenge is evenly spaced if each of the combinations is evenly spaced itself.
                using (MiniProfiler.Current.Step("Check all Werte/Einheit/OBIS combinations"))
                {
                    var combinations = GetWevObisMeCombinations(em);
                    foreach (var combo in combinations)
                        if (!em.IsEvenlySpaced(em.GetTimeRange(), combo.Item1, combo.Item2, combo.Item3, allowGaps))
                            return false;
                }

                return true;
            }

            var v = em.Energieverbrauch.FirstOrDefault();
            return em.IsEvenlySpaced(em.GetTimeRange(), v.Wertermittlungsverfahren, v.Obiskennzahl, v.Einheit,
                allowGaps);
        }


        private static HashSet<TimeSpan> GetTimeSpans(this BO.Energiemenge em)
        {
            var result = new HashSet<TimeSpan>();
            var vlist = new List<Verbrauch>(em.Energieverbrauch);
            vlist.Sort(new VerbrauchDateTimeComparer());
            for (var i = 1; i < vlist.Count; i++)
            {
                result.Add(vlist[i].Startdatum - vlist[i - 1].Startdatum);
                result.Add(vlist[i].Enddatum - vlist[i - 1].Enddatum);
            }

            return result;
        }

        private static HashSet<TimeSpan> GetTimeSpans(this BO.Energiemenge em, Wertermittlungsverfahren wev,
            string obis, Mengeneinheit me)
        {
            var result = new HashSet<TimeSpan>();
            var vlist = new List<Verbrauch>(em.Energieverbrauch);
            vlist.Sort(new VerbrauchDateTimeComparer());
            vlist = vlist.Where(v => v.Wertermittlungsverfahren == wev && v.Obiskennzahl == obis && v.Einheit == me)
                .ToList();
            for (var i = 1; i < vlist.Count; i++)
            {
                result.Add(vlist[i].Startdatum - vlist[i - 1].Startdatum);
                result.Add(vlist[i].Enddatum - vlist[i - 1].Enddatum);
            }

            return result;
        }

        /// <summary>
        ///     get all (Wertermittlungsverfahren, OBIS, Mengeneinheit) tuples occurring in <paramref name="em" />
        /// </summary>
        /// <param name="em">em</param>
        /// <returns>A Set of tuples of all (Wertermittlungsverfahren, OBIS, Mengeneinheit) combinations</returns>
        public static ISet<Tuple<Wertermittlungsverfahren, string, Mengeneinheit>> GetWevObisMeCombinations(
            this BO.Energiemenge em)
        {
            return new HashSet<Tuple<Wertermittlungsverfahren, string, Mengeneinheit>>(
                em.Energieverbrauch
                    .Select(v => Tuple.Create(v.Wertermittlungsverfahren, v.Obiskennzahl, v.Einheit)));
        }

        /// <summary>
        ///     Get percentage of time range covered by all Wertermittlungsverfahren/OBIS/Mengeneinheit
        ///     combinations, that are present in the Energiemenge-&gt;energieverbrauch array.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference</param>
        /// <returns></returns>
        public static decimal GetJointCoverage(this BO.Energiemenge em, TimeRange reference)
        {
            var combinations = GetWevObisMeCombinations(em);
            var jointCoverage = em.Energieverbrauch
                .Where(v => combinations.Contains(Tuple.Create(v.Wertermittlungsverfahren, v.Obiskennzahl, v.Einheit)))
                .Sum(v => GetOverlapFactor(new TimeRange(v.Startdatum, v.Enddatum), reference, true));
            return jointCoverage - (combinations.Count - 1);
        }

        /// <summary>
        ///     Get percentage of time range covered by pure Energiemenge.
        /// </summary>
        /// <param name="em">pure Energiemenge</param>
        /// <param name="reference">time frame reference</param>
        /// <returns>value between 0 (only coverage for 1 point in time) and 1.0 (100% coverage)</returns>
        public static decimal GetCoverage(this BO.Energiemenge em, ITimeRange reference)
        {
            using (MiniProfiler.Current.Step(nameof(GetCoverage)))
            {
                if (!IsPure(em))
                    throw new ArgumentException("The Energiemenge is not pure. Cannot determine parameters.");
                if (em.Energieverbrauch.Count == 0) return 0.0M;
                var v = em.Energieverbrauch.First();
                return em.GetCoverage(reference, v.Wertermittlungsverfahren, v.Obiskennzahl, v.Einheit);
            }
        }

        /// <summary>
        ///     Get percentage of full time range of energiemenge which is covered with values.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>value between 0 (only coverage for 1 point in time) and 1.0 (100% coverage)</returns>
        public static decimal GetCoverage(this BO.Energiemenge em)
        {
            return em.GetCoverage(em.GetTimeRange());
        }

        /// <summary>
        ///     Get ratio of overlap between given Energiemenge and a reference.
        ///     Method is basically just another name for <see cref="GetOverlapFactor" />
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference time range</param>
        /// <param name="obisKz">OBIS</param>
        /// <param name="mengeneinheit">unit of measurement</param>
        /// <param name="wev">type of measurement</param>
        /// <param name="decimalRounding">post decimals</param>
        /// <returns>value between 0 (no overlap) and 1.0 (100% overlap)</returns>
        public static decimal GetCoverage(this BO.Energiemenge em, ITimeRange reference,
            Wertermittlungsverfahren wev, string obisKz, Mengeneinheit mengeneinheit, int decimalRounding = 10)
        {
            decimal exactResult;
            using (MiniProfiler.Current.Step(
                $"calculating coverage for list with {em.Energieverbrauch.Count} entries."))
            {
                exactResult = em.Energieverbrauch
                    .Where(v => v.Einheit == mengeneinheit && v.Obiskennzahl == obisKz &&
                                v.Wertermittlungsverfahren == wev)
                    .Sum(v => GetOverlapFactor(new TimeRange(v.Startdatum, v.Enddatum), reference, true));
            }

            return Math.Round(exactResult, decimalRounding);
        }

        /// <summary>
        ///     Test, if the Energiemenge is continuous within its own min/max range.
        ///     <see cref="IsContinuous(BO4E.BO.Energiemenge,Itenso.TimePeriod.TimeRange)" />
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>
        ///     true iff Energiemenge has defined value for every point in time t in
        ///     min(energieverbrauch.startdatum) &lt;= t &lt; max(energieverbrauch.enddatum);
        ///     false otherwise
        /// </returns>
        public static bool IsContinuous(this BO.Energiemenge em)
        {
            return IsContinuous(em, new TimeRange(em.GetMinDate().UtcDateTime, em.GetMaxDate().UtcDateTime));
        }

        /// <summary>
        ///     Test, if the Energiemenge does have a defined value for every point in time within the given time range.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">time range to check</param>
        /// <returns>true iff Energiemenge has defined value for every point in time range, false otherwise</returns>
        public static bool IsContinuous(this BO.Energiemenge em, TimeRange reference)
        {
            return Math.Abs(em.Energieverbrauch.Sum(v =>
                GetOverlapFactor(new TimeRange(v.Startdatum, v.Enddatum), reference, true)) - 1.0M) < QUASI_ZERO;
        }

        private static decimal GetOverlapFactor(TimeRange period, ITimeRange reference, bool toReference)
        {
            var periods = new TimePeriodCollection
            {
                reference,
                period
            };
            var periodIntersector = new TimePeriodIntersector<TimeRange>();
            var intersectedPeriods = periodIntersector.IntersectPeriods(periods);
            try
            {
                if (toReference)
                    return (decimal) intersectedPeriods.TotalDuration.TotalSeconds /
                           (decimal) reference.Duration.TotalSeconds;

                return (decimal) intersectedPeriods.TotalDuration.TotalSeconds / (decimal) period.Duration.TotalSeconds;
            }
            catch (DivideByZeroException)
            {
                return 0.0M;
            }
        }

        /// <summary>
        ///     shortcut for <see cref="IsPureMengeneinheit" /> &amp;&amp; <see cref="IsPureObisKennzahl" /> &amp;&amp;
        ///     <see cref="IsPureWertermittlungsverfahren" />
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="checkUserProperties">
        ///     set true, to additionally check if user properties of all entries in energieverbrauch
        ///     are equal.
        /// </param>
        /// <returns>true iff the Energiemenge is pure in all OBIS-Kennzahl, Wertermittlungsverfahren and Mengeneinheit</returns>
        public static bool IsPure(this BO.Energiemenge em, bool checkUserProperties = false)
        {
            bool basicPurity;
            using (MiniProfiler.Current.Step(nameof(IsPure)))
            {
                basicPurity = em.IsPureMengeneinheit() && em.IsPureObisKennzahl() &&
                              em.IsPureWertermittlungsverfahren();
            }

            if (basicPurity && checkUserProperties)
            {
                var upPurity = em.IsPureUserProperties();
                return upPurity && basicPurity;
            }

            return basicPurity;
        }

        /// <summary>
        ///     test if Energiemenge has only one <see cref="Wertermittlungsverfahren" />
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>true iff the Energiemenge-&gt;energieverbrauch list has at most one distinct Wertermittlungsverfahren</returns>
        public static bool IsPureWertermittlungsverfahren(this BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step(nameof(IsPureWertermittlungsverfahren)))
            {
                return em.Energieverbrauch.Select(v => v.Wertermittlungsverfahren).Distinct().Count() <= 1;
            }
        }

        /// <summary>
        ///     test if Energiemenge has only one Obiskennzahl
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>true iff the Energiemenge-&gt;energieverbrauch list has at most one distinct Obiskennzahl</returns>
        public static bool IsPureObisKennzahl(this BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step(nameof(IsPureObisKennzahl)))
            {
                return em.Energieverbrauch.Select(v => v.Obiskennzahl).Distinct().Count() <= 1;
            }
        }

        /// <summary>
        ///     test if all entries in <see cref="BO4E.BO.Energiemenge.Energieverbrauch" /> do have same user properties.
        ///     Only tests for those user properties present. Missing user properties do not lead to false.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns></returns>
        public static bool IsPureUserProperties(this BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step(nameof(IsPureUserProperties)))
            {
                ISet<string> upKeys = new HashSet<string>(em.Energieverbrauch.Where(v => v.UserProperties != null)
                    .SelectMany(v => v.UserProperties.Keys));
                var values = new Dictionary<string, object>();
                // ToDo: make it nice.
                foreach (var v in em.Energieverbrauch.Where(v => v.UserProperties != null))
                foreach (var key in upKeys)
                    if (v.UserProperties.TryGetValue(key, out var rawValue))
                    {
                        if (values.TryGetValue(key, out var onlyValue))
                        {
                            if (rawValue == null && onlyValue != null)
                                return false;
                            if (rawValue != null && !rawValue.Equals(onlyValue)) return false;
                        }
                        else
                        {
                            values.Add(key, rawValue);
                        }
                    }

                return true;
            }
        }

        /// <summary>
        ///     test if Energiemenge has only one <see cref="Mengeneinheit" />
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>true iff the Energiemenge-&gt;energieverbrauch list does only contain entries with mutually convertible units</returns>
        public static bool IsPureMengeneinheit(this BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step(nameof(IsPureMengeneinheit)))
            {
                if (em.Energieverbrauch.Select(v => v.Einheit).Distinct().Count() <= 1) return true;

                var me1 = em.Energieverbrauch.Select(v => v.Einheit).First();
                return em.Energieverbrauch.Select(v => v.Einheit).All(me2 => me1.IsConvertibleTo(me2));
            }
        }

        /// <summary>
        ///     opposite of <see cref="IsExtensive" />
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>true iff all <paramref name="em" />-&gt;energieverbrauch entries are intensive</returns>
        public static bool IsIntensive(this BO.Energiemenge em)
        {
            return !em.IsExtensive();
        }

        /// <summary>
        ///     Test if the energiemenge contains only extensive consumption units
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>true iff all <paramref name="em" />-&gt;energieverbrauch entries are extensive</returns>
        public static bool IsExtensive(this BO.Energiemenge em)
        {
            return em.IsPureMengeneinheit() && em.Energieverbrauch.First().Einheit.IsExtensive();
        }

        /// <summary>
        ///     Splits the energy menge in groups that share the same:
        ///     * <see cref="Verbrauch.Wertermittlungsverfahren" />,
        ///     * <see cref="Verbrauch.Einheit" />,
        ///     * <see cref="Verbrauch.Obiskennzahl" />
        ///     and are considered "pure".
        /// </summary>
        /// <param name="em"></param>
        /// <returns>a list of pure energiemengen (<see cref="IsPure" />)</returns>
        public static List<BO.Energiemenge> SplitInPureGroups(this BO.Energiemenge em)
        {
            if (em.Energieverbrauch == null) return new List<BO.Energiemenge> {em};

            var result = new List<BO.Energiemenge>();
            foreach (var group in em.Energieverbrauch.GroupBy(PurityGrouper))
            {
                var pureEm = em.DeepClone();
                pureEm.Energieverbrauch = group.ToList();
                result.Add(pureEm);
            }

            return result;
        }

        /// <summary>
        ///     Our SAP CDS has a bug: When there's a change from non-DST to DST the <see cref="Verbrauch.Enddatum" /> is set
        ///     to the first second of the DST period. To
        /// </summary>
        /// <param name="em"></param>
        public static void FixSapCDSBug(this BO.Energiemenge em)
        {
            using (MiniProfiler.Current.Step("Fix SAP CDS Bug (Energiemenge)"))
            {
                if (em.Energieverbrauch != null && !em.HasBeenSanitized())
                {
                    using (MiniProfiler.Current.Step($"for each Verbrauch entry: {nameof(FixSapCDSBug)}"))
                    {
                        foreach (var v in em.Energieverbrauch) v.FixSapCdsBug();
                        //em.energieverbrauch = em.energieverbrauch.Select(v => Verbrauch.FixSapCdsBug(v)).ToList();
                    }

                    using (MiniProfiler.Current.Step("for list as a whole"))
                    {
                        foreach (var relevantEnddatum in em.Energieverbrauch.Where(v =>
                        {
                            var localEnd =
                                DateTime.SpecifyKind(v.Enddatum, DateTimeKind.Unspecified); // ToDo: Check .UtcDateTime
                            var localStart = DateTime.SpecifyKind(v.Startdatum, DateTimeKind.Unspecified);
                            return !CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo.IsDaylightSavingTime(
                                       localStart) &&
                                   CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo.IsDaylightSavingTime(
                                       localEnd);
                            //return !localStart.IsDaylightSavingTime() && localEnd.IsDaylightSavingTime();
                        }).Select(v => v.Enddatum))
                        {
                            var intervalSize = em.Energieverbrauch.Where(v => v.Enddatum == relevantEnddatum)
                                .Select(v => (v.Enddatum - v.Startdatum).TotalSeconds).Min();
                            foreach (var v in em.Energieverbrauch.Where(v => v.Enddatum == relevantEnddatum))
                                v.Enddatum = v.Startdatum.AddSeconds(intervalSize);
                        }

                        if (em.Energieverbrauch.Count(v => (v.Enddatum - v.Startdatum).TotalMinutes == -45) > 1)
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

                    if (em.UserProperties == null) em.UserProperties = new Dictionary<string, object>();
                    em.UserProperties[SAP_SANITIZED_USERPROPERTY_KEY] = true;
                }
            }
        }

        /// <summary>
        ///     tests if the method <see cref="Verbrauch.FixSapBugs" /> has been executed yet.
        /// </summary>
        /// <returns>true if Energiemenge has been sanitized</returns>
        private static bool HasBeenSanitized(this BO.Energiemenge em)
        {
            bool sanitized;
            if (em.UserProperties == null ||
                !em.UserProperties.TryGetValue(SAP_SANITIZED_USERPROPERTY_KEY, out var sapSanitizedToken))
                sanitized = false;
            else
                switch (sapSanitizedToken)
                {
                    case string value:
                        sanitized = JsonConvert.DeserializeObject<JToken>(value).Value<bool>();
                        break;
                    case bool token:
                        return token;
                    default:
                        sanitized = ((JsonElement) sapSanitizedToken).GetBoolean();
                        break;
                }

            return sanitized;
        }

        /// <summary>
        ///     Apply <see cref="VerbrauchExtension.Detangle" /> to the <see cref="BO4E.BO.Energiemenge.Energieverbrauch" />.
        /// </summary>
        /// <param name="em"></param>
        public static void Detangle(this BO.Energiemenge em)
        {
            if (em.Energieverbrauch != null) em.Energieverbrauch = VerbrauchExtension.Detangle(em.Energieverbrauch);
        }

        private class BasicVerbrauchDateTimeComparer : IComparer<CompletenessReport.BasicVerbrauch>
        {
            int IComparer<CompletenessReport.BasicVerbrauch>.Compare(CompletenessReport.BasicVerbrauch x,
                CompletenessReport.BasicVerbrauch y)
            {
                var vx = new Verbrauch
                {
                    Startdatum = x.Startdatum,
                    Enddatum = x.Enddatum
                };
                var vy = new Verbrauch
                {
                    Startdatum = y.Startdatum,
                    Enddatum = y.Enddatum
                };
                IComparer<Verbrauch> cv = new VerbrauchDateTimeComparer();
                return cv.Compare(vx, vy);
            }
        }
    }
}