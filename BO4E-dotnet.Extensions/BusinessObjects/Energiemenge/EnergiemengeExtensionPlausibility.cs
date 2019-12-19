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
        /// <param name="ignoreLocation">By default (false) an ArgumentException is thrown if the <see cref="BO4E.BO.Energiemenge.lokationsId"/> do not match. Setting this flag suppresses the error.</param>
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
                        if (!(emReference.lokationsId == emOther.lokationsId && emReference.lokationstyp == emOther.lokationstyp))
                        {
                            throw new ArgumentException($"locations do not match! '{emReference.lokationsId}' ({emReference.lokationstyp}) != '{emOther.lokationsId}' ({emOther.lokationstyp})");
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

                Verbrauch vReference = emReference.energieverbrauch.FirstOrDefault(); // copies obiskennzahl, wertermittlungsverfahren...
                vReference.wert = consumptionReference.Item1;
                vReference.einheit = consumptionReference.Item2;
                vReference.startdatum = timeframe.Start;
                vReference.enddatum = timeframe.End;

                Verbrauch vOther = emOther.energieverbrauch.FirstOrDefault(); // copies obiskennzahl, wertermittlungsverfahren...
                vOther.wert = consumptionOther.Item1;
                vOther.einheit = consumptionOther.Item2;
                vOther.startdatum = timeframe.Start;
                vOther.enddatum = timeframe.End;

                var pr = new PlausibilityReport()
                {
                    lokationsId = emReference.lokationsId,
                    referenceTimeFrame = new BO4E.COM.Zeitraum() { startdatum = timeframe.Start, enddatum = timeframe.End },
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
            return energiemenge.GetPlausibilityReport(config.other, new TimeRange(config.timeframe.startdatum.Value, config.timeframe.enddatum.Value), config.ignoreLocation);
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
                    startdatum = range.Start,
                    enddatum = range.End
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
                Start = config.timeframe.startdatum.Value,
                End = config.timeframe.enddatum.Value
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
                Start = config.timeframe.startdatum.Value,
                End = config.timeframe.enddatum.Value
            });
            return em.GetSlicedPlausibilityReports(config, slices);
        }

    }
}