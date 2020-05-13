using BO4E.COM;
using BO4E.ENUM;
using BO4E.Reporting;

using Itenso.TimePeriod;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using StackExchange.Profiling;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BO4E.Extensions.BusinessObjects.Energiemenge
{
    public static partial class EnergiemengeExtension
    {
        /// <summary>
        /// Generate a <see cref="CompletenessReport"/> for the given configuration. Same as <see cref="GetCompletenessReport(BO.Energiemenge, TimeRange, Wertermittlungsverfahren, string, Mengeneinheit)"/> but with all parameters in a configuration container instead of loose arguments.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="config">configuration container</param>
        /// <returns></returns>
        public static CompletenessReport GetCompletenessReport(this BO4E.BO.Energiemenge em, CompletenessReport.CompletenessReportConfiguration config)
        {
            return em.GetCompletenessReport(new TimeRange(config.ReferenceTimeFrame.Startdatum.Value.UtcDateTime, config.ReferenceTimeFrame.Enddatum.Value.UtcDateTime), config.Wertermittlungsverfahren, config.Obis, config.Einheit);
        }

        /// <summary>
        /// Generate a <see cref="CompletenessReport"/> for the given refenrence time frame <paramref name="reference"/>
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference time frame</param>
        /// <returns></returns>
        public static CompletenessReport GetCompletenessReport(this BO4E.BO.Energiemenge em, ITimeRange reference)
        {
            var combis = em.GetWevObisMeCombinations();
            if (combis.Count != 1)
            {
                string errorMessage;
                decimal? coverage;
                if (combis.Count == 0)
                {
                    errorMessage = $"Cannot use autoconfigured method because there are no values.";
                    coverage = 0;
                }
                else
                {
                    errorMessage = $"Cannot use autoconfigured method because there are {combis.Count}>1 distinct (wertermittlungsverfahren, obis, einheit) tuple present: {JsonConvert.SerializeObject(combis, new StringEnumConverter())}";
                    coverage = null;
                }
                return new CompletenessReport()
                {
                    LokationsId = em.LokationsId,
                    ReferenceTimeFrame = new Zeitraum()
                    {
                        Startdatum = new DateTimeOffset(reference.Start),
                        Enddatum = new DateTimeOffset(reference.End)
                    },
                    Coverage = coverage,
                    ErrorMessage = errorMessage
                };
            }
            var combi = combis.First();
            return em.GetCompletenessReport(reference, combi.Item1, combi.Item2, combi.Item3);
        }

        /// <summary>
        /// Generate a <see cref="CompletenessReport"/> for the given parameters.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="reference">reference time frame</param>
        /// <param name="wev">Wertermittlungsverfahren</param>
        /// <param name="obiskennzahl">OBIS Kennzahl</param>
        /// <param name="einheit">Mengeneinheit</param>
        /// <returns>the completeness report</returns>
        public static CompletenessReport GetCompletenessReport(this BO4E.BO.Energiemenge em, ITimeRange reference, Wertermittlungsverfahren wev, string obiskennzahl, Mengeneinheit einheit)
        {
            CompletenessReport result;
            using (MiniProfiler.Current.Step("create completeness report skeleton + find the coverage"))
            {
                result = new CompletenessReport
                {
                    LokationsId = em.LokationsId,
                    Einheit = einheit,
                    Coverage = GetCoverage(em, reference, wev, obiskennzahl, einheit),
                    wertermittlungsverfahren = wev,
                    Obiskennzahl = obiskennzahl,
                    ReferenceTimeFrame = new Zeitraum
                    {
                        Startdatum = new DateTimeOffset(DateTime.SpecifyKind(reference.Start, DateTimeKind.Utc)),
                        Enddatum = new DateTimeOffset(DateTime.SpecifyKind(reference.End, DateTimeKind.Utc))
                    },
                };
            }
            if (em.Energieverbrauch != null && em.Energieverbrauch.Count > 0)
            {
                /*using (MiniProfiler.Current.Step("populating time slices of/with missing/null values"))
                {
                    result.values = em.GetMissingTimeRanges(reference, wev, obis, einheit)
                        .Select(mtr => new CompletenessReport.BasicVerbrauch
                        {
                            startdatum = DateTime.SpecifyKind(mtr.Start, DateTimeKind.Utc),
                            enddatum = DateTime.SpecifyKind(mtr.End, DateTimeKind.Utc),
                            wert = null
                        }).ToList<CompletenessReport.BasicVerbrauch>();
                }
                using (MiniProfiler.Current.Step("populating time slices existing values"))
                {
                    result.values.AddRange(
                    em.energieverbrauch
                    //.AsParallel<Verbrauch>()
                    .Where(v => v.obiskennzahl == obis && v.einheit == einheit && v.wertermittlungsverfahren == wev)
                    .Select(v => new CompletenessReport.BasicVerbrauch
                    {
                        startdatum = DateTime.SpecifyKind(v.startdatum, DateTimeKind.Utc),
                        enddatum = DateTime.SpecifyKind(v.enddatum, DateTimeKind.Utc),
                        wert = v.wert
                    })
                    .ToList<CompletenessReport.BasicVerbrauch>());
                }*/
                using (MiniProfiler.Current.Step("Setting aggregated gaps"))
                {
                    var nonNullValues = new TimePeriodCollection(em.Energieverbrauch.Select(v => new TimeRange(v.Startdatum, v.Enddatum)));
                    ITimeRange limits;
                    if (result.ReferenceTimeFrame != null && result.ReferenceTimeFrame.Startdatum.HasValue && result.ReferenceTimeFrame.Enddatum.HasValue)
                    {
                        limits = new TimeRange(result.ReferenceTimeFrame.Startdatum.Value.UtcDateTime, result.ReferenceTimeFrame.Enddatum.Value.UtcDateTime);
                    }
                    else
                    {
                        limits = null;
                    }
                    var gaps = (new TimeGapCalculator<TimeRange>()).GetGaps(nonNullValues, limits: limits);
                    result.Gaps = gaps.Select(gap => new CompletenessReport.BasicVerbrauch()
                    {
                        Startdatum = gap.Start,
                        Enddatum = gap.End,
                        Wert = null
                    }).ToList();

                }
                /*using (MiniProfiler.Current.Step("sorting result"))
                {
                    result.values.Sort(new BasicVerbrauchDateTimeComparer());
                }*/
                if (em.IsPure(checkUserProperties: true))
                {
                    try
                    {
                        foreach (var kvp in em.Energieverbrauch.Where(v => v.UserProperties != null).SelectMany(v => v.UserProperties))
                        {
                            if (result.UserProperties == null)
                            {
                                result.UserProperties = new Dictionary<string, JToken>();
                            }
                            if (!result.UserProperties.ContainsKey(kvp.Key))
                            {
                                result.UserProperties.Add(kvp.Key, kvp.Value);
                            }
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        // ok, there's no Verbrauch with user properties.
                    }
                }
            }
            /*else
            {
                result.coverage = null;
                result._errorMessage = "energieverbrauch is empty";
            }*/
            return result;
        }

        /// <summary>
        /// <see cref="GetCompletenessReport(BO.Energiemenge, ITimeRange, Wertermittlungsverfahren, string, Mengeneinheit)"/>
        /// for pure Energiemengen within their own time range.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns><see cref="GetCompletenessReport(BO.Energiemenge, ITimeRange, Wertermittlungsverfahren, string, Mengeneinheit)"/></returns>
        public static CompletenessReport GetCompletenessReport(this BO4E.BO.Energiemenge em)
        {
            if (!em.IsPure())
            {
                throw new ArgumentException("The provided Energiemenge is not pure. Please use overloaded method GetCompletenessReport(... , wertermittlungsverfahren, obiskennzahl, mengeneinheit).");
            }
            Verbrauch v;
            try
            {
                v = em.Energieverbrauch.First<Verbrauch>();
            }
            catch (InvalidOperationException)
            {
                return new CompletenessReport()
                {
                    Coverage = null,
                    LokationsId = em.LokationsId,
                    ErrorMessage = "energieverbrauch is empty"
                };
            }
            return em.GetCompletenessReport(em.GetTimeRange(), v.Wertermittlungsverfahren, v.Obiskennzahl, v.Einheit);
        }

        /// <summary>
        /// creates a dictionary of completeness reports for a given list of reference time ranges.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="ranges">list of ranges for which the completeness reports are generated</param>
        /// <param name="useParallelExecution">set true to internally use parallel linq</param>
        /// <returns></returns>
        public static IDictionary<ITimeRange, CompletenessReport> GetSlicedCompletenessReports(this BO.Energiemenge em, IEnumerable<ITimeRange> ranges, bool useParallelExecution = false)
        {
            if (ranges == null)
            {
                throw new ArgumentNullException(nameof(ranges), "list of time ranges must not be null");
            }
            if (ranges.Count() > 0)
            {
                if (useParallelExecution)
                {
                    return ranges.AsParallel().ToDictionary(r => r, r => GetCompletenessReport(em, r));
                }
                else
                {
                    return ranges.ToDictionary(r => r, r => GetCompletenessReport(em, r));
                }
            }
            else
            {
                return new Dictionary<ITimeRange, CompletenessReport>();
            }
        }

        /// <summary>
        /// Get Daily Completeness Reports for <paramref name="overallTimeRange"/>. The magic is, that it takes DST into account!
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="overallTimeRange">overall time frame. Beginning and end must have same hour/minute/second</param>
        /// <param name="useParallelExecution">set true to internally use parallel linq</param>
        /// <returns></returns>
        public static IDictionary<ITimeRange, CompletenessReport> GetDailyCompletenessReports(this BO4E.BO.Energiemenge em, ITimeRange overallTimeRange, bool useParallelExecution = false)
        {
            var slices = GetLocalDailySlices(overallTimeRange);
            return em.GetSlicedCompletenessReports(slices, useParallelExecution);
        }

        /// <summary>
        /// Get Monthly Completeness Reports for <paramref name="overallTimeRange"/>. 
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="overallTimeRange"></param>
        /// <param name="useParallelExecution">set true to internally use parallel linq</param>
        /// <returns></returns>
        public static IDictionary<ITimeRange, CompletenessReport> GetMonthlyCompletenessReports(this BO4E.BO.Energiemenge em, ITimeRange overallTimeRange, bool useParallelExecution = false)
        {
            var slices = GetLocalMonthlySlices(overallTimeRange);
            return em.GetSlicedCompletenessReports(slices, useParallelExecution);
        }
    }
}
