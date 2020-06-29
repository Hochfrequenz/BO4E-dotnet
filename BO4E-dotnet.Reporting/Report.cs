using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using BO4E.BO;

using Newtonsoft.Json.Linq;

using static BO4E.Reporting.CompletenessReport;

namespace BO4E.Reporting
{
    /// <summary>
    /// The base class of all reports.
    /// The idea behind this BusinessObject and all derived classes is that heavy calculations 
    /// of interesting metrics is separated from displaying the data. Report BO acts as a intermediate
    /// format between a BusinessObject extension methods and e.g. a Notification- or Plotting
    /// service that can easily rely on the pre calculated values stored in a Report Object.
    /// </summary>
    public abstract class Report : BusinessObject
    {
        // todo: add meta data like who created report and when...
        // signatures or similar stuff.
        /// <summary>
        /// 
        /// </summary>
        /// <returns>return report as CSV string</returns>

        public string ToCsv(char separator = ';', bool headerLine = true, string lineTerminator = "\\n", List<Dictionary<string, string>> reihenfolge = null)
        {
            var type = this.GetType();
            string returnStr = string.Empty;
            List<string> result = new List<string>();
            List<string> headerNames = new List<string>();
            Dictionary<List<string>, List<string>> reterned = new Dictionary<List<string>, List<string>>() { [headerNames] = result };
            reterned = Detect(type, separator, this, reterned);

            headerNames = reterned.Keys.First();
            headerNames.AddRange(new List<string>() { "gap.startDatum", "gap.endDatum" });
            result = reterned.Values.First();

            List<string> sortedResults = new List<string>();
            List<string> sortedHeaderNamesList = new List<string>();
            var parallelItems = headerNames.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => new { Element = y.Key, Counter = y.Count() })
                .ToList();

            if (parallelItems.Count() > 0)
            {
                for (int i = 0; i < parallelItems.First().Counter; i++)
                {
                    sortedResults.Clear();
                    if (reihenfolge != null)
                    {
                        reihenfolge = reihenfolge.Where(x => x != null).ToList();
                        foreach (var reihenItem in reihenfolge)
                        {
                            string rf_value = reihenItem.Values.First();
                            string rf_key = reihenItem.Keys.First();
                            if (!string.IsNullOrEmpty(rf_value) && !string.IsNullOrEmpty(rf_key))
                            {
                                int index = headerNames.IndexOf(rf_key);
                                if (index != -1)
                                {
                                    sortedHeaderNamesList.Add(rf_value);
                                    string CurFieldName = rf_key;
                                    if (parallelItems.Where(g => g.Element == CurFieldName).Count() > 0)
                                    {
                                        sortedResults.Add(result[index]);
                                        int indx = headerNames.IndexOf(CurFieldName);
                                        headerNames.RemoveAt(indx);
                                        result.RemoveAt(indx);
                                    }
                                    else
                                    {
                                        sortedResults.Add(result[index]);
                                    }
                                }
                                else
                                {
                                    switch (rf_key)
                                    {
                                        case "Messung":
                                            sortedHeaderNamesList.Add("Messung");
                                            string messung = "RLM";
                                            string obis = result[headerNames.IndexOf("obiskennzahl")];
                                            if (obis.Contains("-65:"))
                                            {
                                                messung = "IMS";
                                            }
                                            sortedResults.Add(messung);
                                            break;
                                        default:
                                            throw new ArgumentException("invalid values", nameof(reihenfolge));
                                    }

                                }
                            }
                            else
                            {
                                throw new ArgumentNullException("null value", nameof(reihenfolge));
                            }
                        }
                    }
                    else
                    {
                        int userPropertiesIndex = headerNames.IndexOf("UserProperties");
                        if (userPropertiesIndex >= 0)
                        {
                            headerNames.RemoveAt(userPropertiesIndex);
                            result.RemoveAt(userPropertiesIndex);
                        }
                        //Values organize
                        int index = headerNames.IndexOf(parallelItems.First().Element);
                        if (i == 0)
                        {
                            headerNames.RemoveRange(index + 3, 3 * (parallelItems.First().Counter - 1));
                            sortedHeaderNamesList.AddRange(headerNames);
                        }
                        int valueIndex = index + (i * 3);
                        var curValues = result.Skip(valueIndex).Take(3);
                        var startfix = result.Take(index);
                        int indexEndSection = index + (3 * parallelItems.First().Counter);
                        var endfix = result.Skip(indexEndSection).Take(result.Count - indexEndSection);
                        sortedResults.AddRange(startfix);
                        sortedResults.AddRange(curValues);
                        sortedResults.AddRange(endfix);
                    }
                    if (i == 0 && headerLine)
                    {
                        returnStr = string.Join(separator.ToString(), sortedHeaderNamesList) + lineTerminator;
                    }
                    returnStr += string.Join(separator.ToString(), sortedResults) + lineTerminator;
                }
            }
            else
            {
                if (reihenfolge != null)
                {
                    reihenfolge = reihenfolge.Where(x => x != null).ToList();
                    foreach (var reihenItem in reihenfolge)
                    {
                        if (!string.IsNullOrEmpty(reihenItem.Values.First()) && !string.IsNullOrEmpty(reihenItem.Keys.First()))
                        {
                            int index = headerNames.IndexOf(reihenItem.Keys.First());
                            if (index != -1)
                            {
                                sortedHeaderNamesList.Add(reihenItem.Values.First());
                                sortedResults.Add(result[index]);
                            }
                            else
                            {
                                throw new ArgumentException($"'{reihenItem.Keys.First()}' was not part of {nameof(headerNames)}=[{string.Join(", ", headerNames)}]", nameof(reihenfolge));
                            }
                        }
                        else
                        {
                            throw new ArgumentNullException("null value", nameof(reihenfolge));
                        }
                    }
                }
                else
                {
                    int userPropertiesIndex = headerNames.IndexOf("UserProperties");
                    if (userPropertiesIndex >= 0)
                    {
                        headerNames.RemoveAt(userPropertiesIndex);
                        result.RemoveAt(userPropertiesIndex);
                    }
                    sortedHeaderNamesList.AddRange(headerNames);
                    sortedResults.AddRange(result);
                }
                if (headerLine)
                    returnStr = string.Join(separator.ToString(), sortedHeaderNamesList) + lineTerminator;
                returnStr += string.Join(separator.ToString(), sortedResults);
            }


            List<string> gapdata = new List<string>();
            List<string> gapHeaderNames = new List<string>();
            Dictionary<List<string>, List<string>> gapReterned = new Dictionary<List<string>, List<string>>() { [gapHeaderNames] = gapdata };
            gapReterned = DetectGaps(type, separator, this, gapReterned);

            List<string> gapSortedResults = new List<string>();
            var gapParallelItems = gapHeaderNames.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => new { Element = y.Key, Counter = y.Count() })
                .ToList();
            if (gapParallelItems.Count() > 0)
            {
                for (int i = 0; i < gapParallelItems.First().Counter; i++)
                {
                    gapSortedResults.Clear();

                    int index = gapHeaderNames.IndexOf(gapParallelItems.First().Element);
                    int valueIndex = index + (i * 2);
                    var curValues = gapdata.Skip(valueIndex).Take(2);
                    gapSortedResults.AddRange(curValues);
                    returnStr += lineTerminator;
                    for (int z = 2; z < sortedHeaderNamesList.Count(); z++)
                        returnStr += separator.ToString();
                    returnStr += String.Join(separator.ToString(), gapSortedResults);
                }
            }
            else
            {
                gapSortedResults.AddRange(gapdata);
                returnStr += separator.ToString() + string.Join(separator.ToString(), gapSortedResults);
            }
            return returnStr;
        }

        private Dictionary<List<string>, List<string>> Detect(Type type, char separator, object value, Dictionary<List<string>, List<string>> returnData)
        {
            var props = type.GetProperties();
            var nonHiddenProps = props.Where(s => !s.Name.StartsWith("_")).ToList();
            List<string> d = returnData.Values.First();
            List<string> h = returnData.Keys.First();
            foreach (var field in nonHiddenProps)
            {
                if (field.PropertyType.IsSubclassOf(typeof(BO4E.COM.COM)))
                {
                    returnData = Detect(field.PropertyType, separator, field.GetValue(value), returnData);
                }
                else if ((field.PropertyType.IsGenericType && (field.PropertyType.GetGenericTypeDefinition() == typeof(List<>))))
                {
                    if (field.GetValue(value) != null && field.Name != "Gaps")
                    {
                        Type ItemType = field.GetValue(value).GetType().GetGenericArguments()[0];
                        var list = field.GetValue(value);
                        IList a = (IList)list;
                        foreach (var s in a)
                        {
                            returnData = Detect(s.GetType(), separator, s, returnData);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if ((field.Name == "UserProperties"))
                {
                    if (field.GetValue(value) != null)
                    {
                        Type ItemType = field.GetValue(value).GetType().GetGenericArguments()[0];
                        var userPropertiesDic = field.GetValue(value);
                        IDictionary<string, JToken> a = (IDictionary<string, JToken>)userPropertiesDic;
                        foreach (var pair in a)
                        {
                            h.Add(pair.Key);
                            d.Add((pair.Value.ToString().Contains(separator)) ? "\"" + pair.Value.ToString() + "\"" : pair.Value.ToString());
                            Console.WriteLine(pair.Key + " = " + pair.Value);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    var nestedValue = field.GetValue(value);
                    if (nestedValue != null)
                    {
                        string muterType = "";
                        if (field.DeclaringType.BaseType == typeof(BO4E.COM.COM))
                        {
                            muterType = field.DeclaringType.Name + ".";
                        }
                        string val = nestedValue.ToString();
                        if (field.PropertyType == typeof(DateTime?))
                        {
                            if (((DateTime?)nestedValue).HasValue)
                            {
                                val = ((DateTime?)nestedValue).Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
                            }
                        }
                        else if (field.PropertyType == typeof(DateTimeOffset?))
                        {
                            if (((DateTimeOffset?)nestedValue).HasValue)
                            {
                                val = ((DateTimeOffset?)nestedValue).Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
                            }
                        }
                        else if (field.PropertyType == typeof(DateTime))
                        {
                            val = ((DateTime)nestedValue).ToString("yyyy-MM-ddTHH:mm:ssZ");
                        }
                        else if (field.PropertyType == typeof(DateTimeOffset))
                        {
                            val = ((DateTimeOffset)nestedValue).ToString("yyyy-MM-ddTHH:mm:ssZ");
                        }
                        h.Add(muterType + field.Name);
                        d.Add((val.Contains(separator)) ? "\"" + val + "\"" : val);
                    }
                }
            }
            return returnData;
        }
        private Dictionary<List<string>, List<string>> DetectGaps(Type type, char separator, object value, Dictionary<List<string>, List<string>> returnData)
        {
            var fields = type.GetFields();
            List<string> d = returnData.Values.First();
            List<string> h = returnData.Keys.First();
            foreach (var field in fields)
            {
                if (field.FieldType.IsSubclassOf(typeof(BO4E.COM.COM)))
                {
                    continue;
                }
                else if ((field.FieldType.IsGenericType && (field.FieldType.GetGenericTypeDefinition() == typeof(List<>))))
                {
                    if (field.GetValue(value) != null && field.Name == "Gaps")
                    {
                        Type ItemType = field.GetValue(value).GetType().GetGenericArguments()[0];
                        var list = field.GetValue(value);
                        IList a = (IList)list;
                        foreach (var s in a)
                        {
                            returnData = DetectGaps(s.GetType(), separator, s, returnData);
                        }
                    }
                }
                else
                {
                    var nestedValue = field.GetValue(value);
                    if (nestedValue != null)
                    {
                        if (field.DeclaringType.BaseType == typeof(BO4E.COM.COM))
                        {
                            continue;
                        }
                        if (field.DeclaringType == typeof(BasicVerbrauch))
                        {
                            string muterType = "Gap.";
                            string val = nestedValue.ToString();
                            if (field.FieldType == typeof(DateTime?))
                            {
                                if (((DateTime?)nestedValue).HasValue)
                                {
                                    val = ((DateTime?)nestedValue).Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
                                }
                                h.Add(muterType + field.Name);
                                d.Add((val.Contains(separator)) ? "\"" + val + "\"" : val);
                            }
                            else if (field.FieldType == typeof(DateTime))
                            {
                                val = ((DateTime)nestedValue).ToString("yyyy-MM-ddTHH:mm:ssZ");
                                h.Add(muterType + field.Name);
                                d.Add((val.Contains(separator)) ? "\"" + val + "\"" : val);
                            }
                        }
                    }
                }
            }
            return returnData;
        }


        //public string ToCustomCsv(char separator = ';', bool headerLine = true, string lineTerminator = "\\n", List<Dictionary<string, string>> reihenfolge = null)
        //{

        //}
    }
}
