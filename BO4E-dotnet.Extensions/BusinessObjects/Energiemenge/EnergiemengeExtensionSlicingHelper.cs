using System;
using System.Collections.Generic;
using System.Linq;
using BO4E.COM;
using Itenso.TimePeriod;


namespace BO4E.Extensions.BusinessObjects.Energiemenge
{
    /// <summary>Do calculations on top of an Energiemenge BO4E.</summary>
    public static partial class EnergiemengeExtension
    {
        internal static IList<ITimeRange> GetLocalDailySlices(ITimeRange overallTimeRange, TimeZoneInfo tz = null)
        {
            if (overallTimeRange == null)
            {
                throw new ArgumentNullException(nameof(overallTimeRange), "overall time range must not be null");
            }
            if (tz == null)
            {
                tz = Verbrauch.CENTRAL_EUROPE_STANDARD_TIME;
            }
            if (overallTimeRange.Start.Kind == DateTimeKind.Unspecified)
            {
                throw new ArgumentException($"TimeRange start must not have DateTimeKind.Unspecified", nameof(overallTimeRange));
            }
            if (overallTimeRange.End.Kind == DateTimeKind.Unspecified)
            {
                throw new ArgumentException($"TimeRange end must not have DateTimeKind.Unspecified", nameof(overallTimeRange));
            }

            IList<ITimeRange> result = new List<ITimeRange>();
            if (!overallTimeRange.IsMoment)
            {
                result.Add(new TimeRange()
                {
                    Start = overallTimeRange.Start,
                    End = overallTimeRange.Start.AddDaysDST(1)
                });
                while (result.Last().End < overallTimeRange.End)
                {
                    result.Add(new TimeRange()
                    {
                        Start = result.Last().Start.AddDaysDST(1),
                        End = result.Last().End.AddDaysDST(1)
                    });
                }
            }
            return result;
        }

        internal static IList<ITimeRange> GetLocalMonthlySlices(ITimeRange overallTimeRange, TimeZoneInfo tz = null)
        {
            if (overallTimeRange == null)
            {
                throw new ArgumentNullException(nameof(overallTimeRange), "overall time range must not be null");
            }
            DateTime localStart;
            DateTime localEnd;
            if (tz == null)
            {
                tz = Verbrauch.CENTRAL_EUROPE_STANDARD_TIME;

                if (overallTimeRange.Start.Kind != DateTimeKind.Utc)
                {
                    throw new ArgumentException($"TimeRange start must have DateTimeKind.Utc if no timezone is given in parameter {nameof(tz)}", nameof(overallTimeRange));
                }
                if (overallTimeRange.End.Kind != DateTimeKind.Utc)
                {
                    throw new ArgumentException($"TimeRange end must have DateTimeKind.Utc if no timezone is given in parameter {nameof(tz)}", nameof(overallTimeRange));
                }
                localStart = TimeZoneInfo.ConvertTimeFromUtc(overallTimeRange.Start, tz);
                localEnd = TimeZoneInfo.ConvertTimeFromUtc(overallTimeRange.End, tz);
            }
            else
            {
                switch (overallTimeRange.Start.Kind)
                {
                    case DateTimeKind.Local:
                        throw new ArgumentException($"{nameof(DateTimeKind.Local)} not allowed for Start", nameof(overallTimeRange));
                    case DateTimeKind.Unspecified:
                        localStart = overallTimeRange.Start;
                        break;
                    case DateTimeKind.Utc:
                        localStart = TimeZoneInfo.ConvertTimeFromUtc(overallTimeRange.Start, tz);
                        break;
                    default:
                        throw new NotImplementedException();
                }
                switch (overallTimeRange.End.Kind)
                {
                    case DateTimeKind.Local:
                        throw new ArgumentException($"{nameof(DateTimeKind.Local)} not allowed for End", nameof(overallTimeRange));
                    case DateTimeKind.Unspecified:
                        localEnd = overallTimeRange.End;
                        break;
                    case DateTimeKind.Utc:
                        localEnd = TimeZoneInfo.ConvertTimeFromUtc(overallTimeRange.End, tz);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
            localStart = DateTime.SpecifyKind(localStart, DateTimeKind.Unspecified);
            localEnd = DateTime.SpecifyKind(localEnd, DateTimeKind.Unspecified);
            IList<ITimeRange> result = new List<ITimeRange>();
            if (!overallTimeRange.IsMoment)
            {
                DateTime initialStart = new DateTime(localStart.Year, localStart.Month, 1, 0, 0, 0, DateTimeKind.Unspecified);
                DateTime initialEnd = initialStart.AddMonths(1);
                result.Add(new TimeRange()
                {
                    Start = initialStart,
                    End = initialEnd
                });
                while (result.Last().End < overallTimeRange.End)
                {
                    DateTime sliceStart = result.Last().Start.AddMonths(1);
                    result.Add(new TimeRange()
                    {
                        Start = sliceStart,
                        End = sliceStart.AddMonths(1)
                    });
                }
            }
            return result
                .Select(tr => (ITimeRange)new TimeRange()
                {
                    Start = TimeZoneInfo.ConvertTimeToUtc(tr.Start, tz),
                    End = TimeZoneInfo.ConvertTimeToUtc(tr.End, tz)
                })
                .Where(tr => tr.Start >= overallTimeRange.Start && tr.End <= overallTimeRange.End)
                .ToList();
        }

        /// <summary>
        /// adds <paramref name="value"/> days to <paramref name="dt"/>. Adding 1 day might actually add 25 or 23 hours if the transisition DST&lt;-&gt;non-DST happens.
        /// </summary>
        /// <param name="dt">datetime (kind unspecified or Utc)</param>
        /// <param name="value">number of days to add</param>
        /// <param name="tz">timezone <paramref name="dt"/> is meant to be iff dt.Kind == DateTimeKind.Unspecified, default (if null) is <see cref="Verbrauch.CENTRAL_EUROPE_STANDARD_TIME"/></param>
        /// <returns></returns>
        public static DateTime AddDaysDST(this DateTime dt, double value, TimeZoneInfo tz = null)
        {
            if (tz == null)
            {
                tz = Verbrauch.CENTRAL_EUROPE_STANDARD_TIME;
            }
            if (dt.Kind == DateTimeKind.Local)
            {
                throw new ArgumentException("DateTime Kind must not be local", nameof(dt));
            }
            else if (dt.Kind == DateTimeKind.Unspecified)
            {
                return dt.AddDays(value); // doesn't take dst into account. that's just what we want! A day can have 23,24 or 25 hours
            }
            else if (dt.Kind == DateTimeKind.Utc)
            {
                // an utc day does always have 24 hours. not what humans expect!
                DateTime dtLocal = DateTime.SpecifyKind(TimeZoneInfo.ConvertTimeFromUtc(dt, tz), DateTimeKind.Unspecified);
                DateTime preResult = DateTime.SpecifyKind(dtLocal.AddDays(value), DateTimeKind.Unspecified);
                DateTime result = TimeZoneInfo.ConvertTimeToUtc(preResult, tz);
                return result;
            }
            else
            {
                throw new NotImplementedException($"DateTimeKind {dt.Kind} is not implemented.");
            }
        }
    }
}
