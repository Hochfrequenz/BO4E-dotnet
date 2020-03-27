using System;
using System.Collections.Generic;
using System.Linq;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.Reporting;
using Itenso.TimePeriod;
using Newtonsoft.Json;
using StackExchange.Profiling;
using static BO4E.Extensions.ENUM.MengeneinheitExtenion;
using static BO4E.Reporting.PlausibilityReport;

namespace BO4E.Extensions.BusinessObjects.Energiemenge
{
    public static partial class EnergiemengeExtension
    {
        /// <summary>
        /// Returns a <see cref="PlausibilityReport"/> that compares <paramref name="emReference"/> with <paramref name="emOther"/>.
        /// within the interval defined in <paramref name="timeframe"/>.
        /// </summary>
        /// <param name="emReference">reference Energiemenge (reference = used for normalisation)</param>
        /// <param name="emOther">other Energiemenge</param>
        /// <param name="timeframe">time frame to be analysed. If null, the overlap of <paramref name="emReference"/> and <paramref name="emOther"/> is used.</param>
        /// <param name="ignoreLocation">By default (false) an ArgumentException is thrown if the <see cref="BO4E.BO.Energiemenge.LokationsId"/> do not match. Setting this flag suppresses the error.</param>
        /// <returns>a <see cref="PlausibilityReport"/></returns>
        public static PlausibilityReport GetPlausibilityReport(this BO4E.BO.Energiemenge emReference, BO4E.BO.Energiemenge emOther, ITimeRange timeframe = null, bool ignoreLocation = false)
        {
            using (MiniProfiler.Current.Step(nameof(GetPlausibilityReport)))
            {
                TimeRange trReference = emReference.GetTimeRange();
                TimeRange trOther = emOther.GetTimeRange();
                if (timeframe == null)
                {
                    ITimeRange overlap = trReference.GetIntersection(trOther);
                    if (!ignoreLocation)
                    {
                        if (!(emReference.LokationsId == emOther.LokationsId && emReference.LokationsTyp == emOther.LokationsTyp))
                        {
                            throw new ArgumentException($"locations do not match! '{emReference.LokationsId}' ({emReference.LokationsTyp}) != '{emOther.LokationsId}' ({emOther.LokationsTyp})");
                        }
                    }
                    timeframe = overlap;
                }
                Tuple<decimal, Mengeneinheit> consumptionReference;
                Tuple<decimal, Mengeneinheit> consumptionOtherRaw;
                using (MiniProfiler.Current.Step("Get Consumptions for overlap:"))
                {
                    consumptionReference = emReference.GetConsumption(timeframe);
                    consumptionOtherRaw = emOther.GetConsumption(timeframe);
                }

                Tuple<decimal, Mengeneinheit> consumptionOther;
                if (consumptionReference.Item2 != consumptionOtherRaw.Item2)
                {
                    // unit mismatch
                    if (consumptionReference.Item2.IsConvertibleTo(consumptionOtherRaw.Item2))
                    {
                        consumptionOther = new Tuple<decimal, Mengeneinheit>(consumptionOtherRaw.Item1 * consumptionOtherRaw.Item2.GetConversionFactor(consumptionReference.Item2), consumptionReference.Item2);
                    }
                    else
                    {
                        throw new ArgumentException($"The unit {consumptionOtherRaw.Item2} is not comparable to {consumptionReference.Item2}!");
                    }
                }
                else
                {
                    consumptionOther = consumptionOtherRaw;
                }

                decimal absoluteDeviation = consumptionOther.Item1 - consumptionReference.Item1;
                decimal? relativeDeviation;
                try
                {
                    relativeDeviation = absoluteDeviation / consumptionReference.Item1;
                }
                catch (DivideByZeroException)
                {
                    relativeDeviation = null;
                }

                Verbrauch vReference = emReference.Energieverbrauch.FirstOrDefault(); // copies obiskennzahl, wertermittlungsverfahren...
                vReference.Wert = consumptionReference.Item1;
                vReference.Einheit = consumptionReference.Item2;
                vReference.Startdatum = timeframe.Start;
                vReference.Enddatum = timeframe.End;

                Verbrauch vOther = emOther.Energieverbrauch.FirstOrDefault(); // copies obiskennzahl, wertermittlungsverfahren...
                vOther.Wert = consumptionOther.Item1;
                vOther.Einheit = consumptionOther.Item2;
                vOther.Startdatum = timeframe.Start;
                vOther.Enddatum = timeframe.End;

                var pr = new PlausibilityReport()
                {
                    lokationsId = emReference.LokationsId,
                    referenceTimeFrame = new BO4E.COM.Zeitraum() { Startdatum = timeframe.Start, Enddatum = timeframe.End },
                    verbrauchReference = vReference,
                    verbrauchOther = vOther,
                    absoluteDeviation = Math.Abs(absoluteDeviation),
                    absoluteDeviationEinheit = consumptionReference.Item2
                };
                if (relativeDeviation.HasValue)
                {
                    pr.relativeDeviation = Math.Round(relativeDeviation.Value, 4);
                }
                else
                {
                    pr.relativeDeviation = null;
                }
                return pr;
            }
        }

        /// <summary>
        /// same as <see cref="GetPlausibilityReport(BO.Energiemenge, BO.Energiemenge, ITimeRange, bool)"/> but with a strongly typed container as input.
        /// </summary>
        /// <param name="config">container containing the relevant data</param>
        /// <returns></returns>
        public static PlausibilityReport GetPlausibilityReport(this BO4E.BO.Energiemenge energiemenge, PlausibilityReport.PlausibilityReportConfiguration config)
        {
            return energiemenge.GetPlausibilityReport(config.other, new TimeRange(config.timeframe.Startdatum.Value, config.timeframe.Enddatum.Value), config.ignoreLocation);
        }

        /// <summary>
        /// creates a dictionary of completeness reports for a given list of reference time ranges.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="ranges">list of ranges for which the completeness reports are generated</param>
        /// <returns></returns>
        public static IDictionary<ITimeRange, PlausibilityReport> GetSlicedPlausibilityReports(this BO4E.BO.Energiemenge em, PlausibilityReportConfiguration config, IEnumerable<ITimeRange> ranges)
        {
            if (ranges == null)
            {
                throw new ArgumentNullException(nameof(ranges), "list of time ranges must not be null");
            }
            Dictionary<ITimeRange, PlausibilityReport> result = new Dictionary<ITimeRange, PlausibilityReport>();
            foreach (var range in ranges)
            {
                var localConfig = JsonConvert.DeserializeObject<PlausibilityReportConfiguration>(JsonConvert.SerializeObject(config));
                localConfig.timeframe = new Zeitraum()
                {
                    Startdatum = range.Start,
                    Enddatum = range.End
                };
                var subResult = GetPlausibilityReport(em, localConfig);
                result.Add(range, subResult);
            }
            return result;
        }

        /// <summary>
        /// Get Daily Completeness Reports for overall time range defined in <paramref name="config"/>.
        /// The magic is, that it takes DST into account!
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="config">configuration that contains the overall time range in <see cref="PlausibilityReportConfiguration.timeframe"/></param>
        /// <returns></returns>
        public static IDictionary<ITimeRange, PlausibilityReport> GetDailyPlausibilityReports(this BO.Energiemenge em, PlausibilityReportConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            if (config.timeframe == null)
            {
                throw new ArgumentNullException(nameof(config.timeframe));
            }
            var slices = GetLocalDailySlices(new TimeRange()
            {
                Start = config.timeframe.Startdatum.Value,
                End = config.timeframe.Enddatum.Value
            });
            return em.GetSlicedPlausibilityReports(config, slices);
        }

        /// <summary>
        /// Get Monthly Completeness Reports for overall time range defined in <paramref name="config"/>. 
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <param name="config">configuration that contains the overall time range in <see cref="PlausibilityReportConfiguration.timeframe"/></param>
        /// <returns></returns>
        public static IDictionary<ITimeRange, PlausibilityReport> GetMonthlyPlausibilityReports(this BO4E.BO.Energiemenge em, PlausibilityReportConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            if (config.timeframe == null)
            {
                throw new ArgumentNullException(nameof(config.timeframe));
            }
            var slices = GetLocalMonthlySlices(new TimeRange()
            {
                Start = config.timeframe.Startdatum.Value,
                End = config.timeframe.Enddatum.Value
            });
            return em.GetSlicedPlausibilityReports(config, slices);
        }

    }
}