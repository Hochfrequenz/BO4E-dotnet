using System;
using System.Collections.Generic;
using System.Linq;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.Extensions.ENUM;
using Itenso.TimePeriod;
using Newtonsoft.Json;

namespace BO4E.Extensions.COM
{
    public static class VerbrauchExtension
    {
        /// <summary>
        /// Merging two Verbrauch instances means adding their values whenever it's possible.
        /// But generally the result is going to contain multiple Verbrauchs.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static HashSet<Verbrauch> Merge(this Verbrauch v1, Verbrauch v2)
        {
            return v1.Merge(v2, false, false);
        }

        public static HashSet<Verbrauch> MergeRedundant(this Verbrauch v1, Verbrauch v2, Boolean biased)
        {
            return v1.Merge(v2, true, biased);
        }

        public static HashSet<Verbrauch> Merge(this Verbrauch v1, Verbrauch v2, bool redundant, Boolean biased)
        {
            HashSet<Verbrauch> result = new HashSet<Verbrauch>();
            if (v1.Obiskennzahl == v2.Obiskennzahl && v1.Wertermittlungsverfahren == v2.Wertermittlungsverfahren && v1.Einheit == v2.Einheit)
            {
                if (v1.OverlapsWith(v2))
                {
                    // don't wanna deal with time running backwards.
                    //Debug.Assert(v1.enddatum >= v1.startdatum);
                    //Debug.Assert(v2.enddatum >= v2.startdatum);
                    TimeRange tr1 = new TimeRange(v1.Startdatum, v1.Enddatum);
                    TimeRange tr2 = new TimeRange(v2.Startdatum, v2.Enddatum);
                    ITimeRange overlap = v1.GetIntersection(v2);
                    if (v1.Einheit.IsExtensive())
                    {
                        Verbrauch vmerge = new Verbrauch()
                        {
                            Obiskennzahl = v1.Obiskennzahl,
                            Einheit = v1.Einheit,
                            Wertermittlungsverfahren = v1.Wertermittlungsverfahren
                        };
                        if (redundant)
                        {
                            decimal exclusiveV1Wert = (decimal)(tr1.Duration.TotalSeconds - overlap.Duration.TotalSeconds) * v1.Wert / ((decimal)tr1.Duration.TotalSeconds);
                            decimal exclusiveV2Wert = (decimal)(tr2.Duration.TotalSeconds - overlap.Duration.TotalSeconds) * v2.Wert / ((decimal)tr2.Duration.TotalSeconds);
                            decimal overlapV1Wert = ((decimal)overlap.Duration.TotalSeconds * v1.Wert) / (decimal)(tr1.Duration.TotalSeconds);
                            decimal overlapV2Wert = ((decimal)overlap.Duration.TotalSeconds * v2.Wert) / (decimal)(tr2.Duration.TotalSeconds);
                            if (biased == true)
                            {
                                // biased ==> assume that v2 is contained in v1
                                vmerge.Startdatum = v1.Startdatum;
                                vmerge.Enddatum = v1.Enddatum;
                                if (exclusiveV1Wert == 0.0M && exclusiveV2Wert == 0.0M && overlapV1Wert == overlapV2Wert)
                                {
                                    vmerge.Wert = overlapV1Wert;
                                }
                                else
                                {
                                    vmerge.Wert = v1.Wert - overlapV2Wert; // overlapV1Wert;
                                }
                            }
                            else if (biased == false)
                            {
                                vmerge.Startdatum = v1.Startdatum;
                                vmerge.Enddatum = v2.Startdatum;
                                vmerge.Wert = v1.Wert - overlapV2Wert;
                            }
                            else // biased null
                            {
                                vmerge.Startdatum = v1.Startdatum < v2.Startdatum ? v1.Startdatum : v2.Startdatum;
                                vmerge.Enddatum = v1.Enddatum > v2.Enddatum ? v1.Enddatum : v2.Enddatum;
                                if (overlapV1Wert != overlapV2Wert)
                                {
                                    throw new ArgumentException("The inequality is unsolvable.");
                                }
                                vmerge.Wert = exclusiveV1Wert + overlapV1Wert + exclusiveV2Wert;
                            }
                        }
                        else
                        {
                            vmerge.Startdatum = v1.Startdatum < v2.Startdatum ? v1.Startdatum : v2.Startdatum;
                            vmerge.Enddatum = v1.Enddatum > v2.Enddatum ? v1.Enddatum : v2.Enddatum;
                            vmerge.Wert = v1.Wert + v2.Wert;
                        }
                        result.Add(vmerge);
                    }
                    else
                    {
                        Verbrauch vmerge1 = new Verbrauch()
                        {
                            Obiskennzahl = v1.Obiskennzahl,
                            Einheit = v1.Einheit,
                            Wertermittlungsverfahren = v1.Wertermittlungsverfahren,
                            Startdatum = v1.Startdatum < v2.Startdatum ? v1.Startdatum : v2.Startdatum,
                            Enddatum = overlap.Start,
                            Wert = v1.Startdatum < v2.Startdatum ? v1.Wert : v2.Wert
                        };
                        Verbrauch vmerge2 = new Verbrauch()
                        {
                            Obiskennzahl = v1.Obiskennzahl,
                            Einheit = v1.Einheit,
                            Wertermittlungsverfahren = v1.Wertermittlungsverfahren,
                            Startdatum = overlap.Start,
                            Enddatum = overlap.End
                        };
                        if (redundant)
                        {
                            if (v1.Wert != v2.Wert)
                            {
                                throw new ArgumentException($"Data cannot be redundant if values ({v1.Wert}{v1.Einheit} vs. {v2.Wert}{v2.Einheit}) don't match for interval [{vmerge2.Startdatum}, {vmerge2.Enddatum}).");
                            }
                            vmerge2.Wert = v1.Wert;
                        }
                        else
                        {
                            vmerge2.Wert = v1.Wert + v2.Wert;
                        }
                        Verbrauch vmerge3 = new Verbrauch()
                        {
                            Obiskennzahl = v1.Obiskennzahl,
                            Einheit = v1.Einheit,
                            Wertermittlungsverfahren = v1.Wertermittlungsverfahren,
                            Startdatum = overlap.End,
                            Enddatum = v1.Enddatum > v2.Enddatum ? v1.Enddatum : v2.Enddatum,
                            Wert = v1.Enddatum > v2.Enddatum ? v1.Wert : v2.Wert
                        };
                        result.Add(vmerge1);
                        result.Add(vmerge2);
                        result.Add(vmerge3);
                    }
                }
                else if (v1.Startdatum == v2.Enddatum || v2.Startdatum == v1.Enddatum)
                {
                    DateTime start = v1.Startdatum < v2.Startdatum ? v1.Startdatum : v2.Startdatum;
                    DateTime stop = v1.Enddatum > v2.Enddatum ? v1.Enddatum : v2.Enddatum;
                    Verbrauch vmerge = new Verbrauch()
                    {
                        Obiskennzahl = v1.Obiskennzahl,
                        Einheit = v1.Einheit,
                        Wertermittlungsverfahren = v1.Wertermittlungsverfahren,
                        Startdatum = start,
                        Enddatum = stop
                    };
                    if (v1.Einheit.IsExtensive())
                    {
                        vmerge.Wert = v1.Wert + v2.Wert;
                        result.Add(vmerge);
                    }
                    else if (v1.Wert == v2.Wert) // implicitly intensive
                    {
                        vmerge.Wert = v1.Wert;
                        result.Add(vmerge);
                    }
                    else
                    {
                        // merging intensive verbrauch with different values is not possible.
                        result.Add(v1);
                        result.Add(v2);
                    }
                }
                else
                {
                    // laaaangweilig ;)
                    result.Add(v1);
                    result.Add(v2);
                }
            }
            else
            {
                // laaaangweilig ;)
                result.Add(v1);
                result.Add(v2);
            }
            result.RemoveWhere(v => v.Einheit.IsIntensive() && new TimeRange(v.Startdatum, v.Enddatum).Duration.TotalMilliseconds == 0);
            return result;
        }

        /// <summary>
        /// returns time range from <see cref="Verbrauch.Startdatum"/>, <see cref="Verbrauch.Enddatum"/>
        /// </summary>
        /// <param name="v">Verbrauch</param>
        /// <returns></returns>
        public static TimeRange GetTimeRange(this Verbrauch v)
        {
            return new TimeRange(v.Startdatum, v.Enddatum);
        }

        public static TimeSpan GetDuration(this Verbrauch v)
        {
            ITimeRange tr = v.GetTimeRange();
            return tr.Duration;
        }

        /// <summary>
        /// De-tangles a list of overlapping Verbrauch entries where entries can be subsets of other entries.
        /// </summary>
        /// <example>
        /// [---v1---)
        /// [-----v2------)
        /// [---------v3---------)
        /// is transformed into
        /// [--v1---)
        /// ........[-v2--)
        /// ..............[--v3--)
        /// </example>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<Verbrauch> Detangle(IEnumerable<Verbrauch> input)
        {
            //var filteredInput = KeepShortestSlices(input);
            HashSet<Verbrauch> resultSet = new HashSet<Verbrauch>();
            var groups = input.OrderBy(v => (v.Startdatum, v.Wertermittlungsverfahren, v.Obiskennzahl, v.Einheit)).GroupBy(v => new Tuple<Wertermittlungsverfahren, string, Mengeneinheit>
              (
                  v.Wertermittlungsverfahren,
                  v.Obiskennzahl,
                  v.Einheit
              ));
            foreach (var vGroup in groups)
            {
                HashSet<Verbrauch> subResult = new HashSet<Verbrauch>();

                // find pairs (x,y) where x.end == y.start:
                // |----x----|--------y--------|
                //var adjacentVerbrauchs = from x in vGroup join y in vGroup on x.enddatum equals y.startdatum select new { x, y };
                var adjacentVerbrauchs = from x in vGroup join y in vGroup on x.Enddatum equals y.Startdatum select new { x, y };
                foreach (var av in adjacentVerbrauchs)
                {
                    subResult.Add(av.x);
                    subResult.Add(av.y);
                }

                // |----x----|--------y--------|
                // |-------------z-------------|
                // ==> delete z from result where z.start == x.start and z.end == y.end
                //var fullyRedundantVerbrauchs = from av in adjacentVerbrauchs join z in vGroup on new { av.x.startdatum, av.y.enddatum } equals new { z.startdatum, z.enddatum } select new { av, z };
                var fullyRedundantVerbrauchs = from av in adjacentVerbrauchs join z in vGroup on new { av.x.Startdatum, av.y.Enddatum } equals new { z.Startdatum, z.Enddatum } select new { av, z };
                foreach (var frv in fullyRedundantVerbrauchs)
                {
                    if (frv.av.x.Wert + frv.av.y.Wert != frv.z.Wert)
                    {
                        throw new ArgumentException($"Inconsistent data detected: {JsonConvert.SerializeObject(frv.av.x)} + {JsonConvert.SerializeObject(frv.av.y)} ≠ {JsonConvert.SerializeObject(frv.z)}");
                    }
                    subResult.Remove(frv.z);
                }

                // |----------x----------|---y---|
                // |---------------z-------------|
                // or
                // |---y---|----------x----------|
                // |---------------z-------------|
                // or
                // |---x1--|-----y------|---x2---|
                // |--------------z--------------|
                // y and z are given. find x such that x.value == y.value+z.value
                //subResult.UnionWith(vGroup);
                subResult.UnionWith(vGroup);
                foreach (Verbrauch z in new HashSet<Verbrauch>(subResult))
                {
                    var ys = subResult.Where(y => z.Contains(y) && !z.Equals(y));
                    if (ys.Count() > 0)
                    {
                        TimePeriodSubtractor<TimeRange> tps = new TimePeriodSubtractor<TimeRange>();
                        TimePeriodCollection source = new TimePeriodCollection { z.GetTimeRange() };
                        TimePeriodCollection subtract = new TimePeriodCollection();
                        subtract.AddAll(ys.Select(y => y.GetTimeRange()));
                        ITimePeriodCollection subtractionResult = tps.SubtractPeriods(source, subtract);
                        var xs = new HashSet<Verbrauch>();
                        foreach (var tr in subtractionResult)
                        {
                            Verbrauch v = new Verbrauch()
                            {
                                Einheit = z.Einheit,
                                Wertermittlungsverfahren = z.Wertermittlungsverfahren,
                                Obiskennzahl = z.Obiskennzahl,
                                Startdatum = tr.Start,
                                Enddatum = tr.End
                            };
                            xs.Add(v);
                        }
                        var totalXWert = z.Wert - ys.Select(y => y.Wert).Sum();
                        var totalXDuration = xs.Select(x => x.GetDuration().TotalSeconds).Sum();
                        foreach (var x in xs)
                        {
                            x.Wert = (totalXWert * (decimal)x.GetDuration().TotalSeconds) / ((decimal)totalXDuration);
                        }
                        subResult.Remove(z);
                        subResult.UnionWith(xs);
                    }
                }
                resultSet.UnionWith(subResult);
            }
            List<Verbrauch> result = new List<Verbrauch>(resultSet);
            result.Sort(new VerbrauchDateTimeComparer());
            return result;
        }

        /// <summary>
        /// convert to another unit if possible
        /// </summary>
        /// <param name="v">Verbrauch</param>
        /// <param name="mengeneinheit">Mengeneinheit</param>
        /// <throws>ArgumentException if units are not convertible</throws>
        public static void ConvertToUnit(this Verbrauch v, Mengeneinheit mengeneinheit)
        {
            PhysikalischerWert oldWert = new PhysikalischerWert(v.Wert, v.Einheit);
            PhysikalischerWert newWert = oldWert.ConvertToUnit(mengeneinheit);
            v.Wert = newWert.Wert;
            v.Einheit = newWert.Einheit;
        }

        /// <summary>
        /// Test if the time ranges [startdatum, enddatum) overlap.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>true iff [<paramref name="v1"/>.startdatum, <paramref name="v1"/>.enddatum) and [<paramref name="v2"/>.startdatum, <paramref name="v2"/>.enddatum) overlap</returns>
        public static bool OverlapsWith(this Verbrauch v1, Verbrauch v2)
        {
            return v1.OverlapsWith(new TimeRange(v2.Startdatum, v2.Enddatum, true));
        }

        public static bool OverlapsWith(this Verbrauch v1, ITimeRange tr2)
        {
            return new TimeRange(v1.Startdatum, v1.Enddatum).OverlapsWith(tr2);
        }

        public static ITimeRange GetIntersection(this Verbrauch v1, ITimeRange tr2)
        {
            return (new TimeRange(v1.Startdatum, v1.Enddatum).GetIntersection(tr2));
        }

        public static ITimeRange GetIntersection(this Verbrauch v1, Verbrauch v2)
        {
            return v1.GetIntersection(new TimeRange(v2.Startdatum, v2.Enddatum));
        }

        public static bool Contains(this Verbrauch v1, Verbrauch v2)
        {
            return v1.OverlapsWith(v2) && v1.Startdatum <= v2.Startdatum && v1.Enddatum >= v2.Enddatum;
        }

        /// <summary>
        /// Allows to sort lists of <see cref="Verbrauch"/> by <see cref="Verbrauch.Startdatum"/>, <see cref="Verbrauch.Enddatum"/> ascending
        /// </summary>
        public class VerbrauchDateTimeComparer : IComparer<Verbrauch>
        {
            int IComparer<Verbrauch>.Compare(Verbrauch x, Verbrauch y)
            {
                if (x.Startdatum != y.Startdatum)
                {
                    return DateTime.Compare(x.Startdatum, y.Startdatum);
                }
                else if (x.Enddatum != y.Enddatum)
                {
                    return DateTime.Compare(x.Enddatum, y.Enddatum);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
