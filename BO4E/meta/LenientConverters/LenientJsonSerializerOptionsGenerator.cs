using BO4E.BO;
using BO4E.COM;

using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BO4E.meta.LenientConverters
{
    /// <summary>
    ///     Extensions to simplify the usage of the Lenient parser using <see cref="System.Text.Json.JsonSerializer" /> (.NET5)
    /// </summary>
    /// <seealso cref="LenientParsingExtensionsNewtonsoft" />
    public static class LenientSystemTextJsonParsingExtensions
    {
        /// <summary>
        ///     <inheritdoc cref="GetJsonSerializerOptions(LenientParsing, HashSet{string})" />
        /// </summary>
        /// <param name="lenient"></param>
        /// <returns></returns>
        public static JsonSerializerOptions GetJsonSerializerOptions(this LenientParsing lenient)
        {
            return GetJsonSerializerOptions(lenient, new HashSet<string>());
        }

        /// <summary>
        ///     Generates JsonSerializerSettings (.NET5) for given lenient parsing setting
        /// </summary>
        /// <param name="lenient"></param>
        /// <param name="userPropertiesWhiteList"></param>
        /// <returns></returns>
        public static JsonSerializerOptions GetJsonSerializerOptions(this LenientParsing lenient,
            HashSet<string> userPropertiesWhiteList)
        {
            var settings = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            settings.Converters.Add(new AutoNumberToStringConverter());
            settings.Converters.Add(new VertragsConverter());
            settings.Converters.Add(new EnergiemengeConverter());
            settings.Converters.Add(new LenientSystemTextJsonStringToBoolConverter());
            settings.Converters.Add(new StringNullableEnumConverter());
            settings.Converters.Add(new JsonStringEnumConverter());

            foreach (LenientParsing lp in Enum.GetValues(typeof(LenientParsing)))
                if (lenient.HasFlag(lp))
                    // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
                    switch (lp)
                    {
                        case LenientParsing.DATE_TIME:
                            if (!lenient.HasFlag(LenientParsing.SET_INITIAL_DATE_IF_NULL))
                            {
                                settings.Converters.Add(new LenientSystemTextJsonDateTimeConverter());
                                settings.Converters.Add(new LenientSystemTextJsonDateTimeOffsetConverter());
                                settings.Converters.Add(new LenientSystemTextJsonNullableDateTimeConverter());
                                settings.Converters.Add(new LenientSystemTextJsonNullableDateTimeOffsetConverter());
                            }
                            else
                            {
                                settings.Converters.Add(
                                    new LenientSystemTextJsonDateTimeConverter(new DateTimeOffset()));
                                settings.Converters.Add(
                                    new LenientSystemTextJsonNullableDateTimeConverter(new DateTimeOffset()));
                                settings.Converters.Add(
                                    new LenientSystemTextJsonDateTimeOffsetConverter(new DateTimeOffset()));
                                settings.Converters.Add(
                                    new LenientSystemTextJsonNullableDateTimeOffsetConverter(new DateTimeOffset()));
                            }

                            break;

                        case LenientParsing.ENUM_LIST:
                            settings.Converters.Add(new LenientSystemTextJsonEnumListConverter());
                            break;

                        case LenientParsing.BO4_E_URI:
                            //converters.Add(new LenientBo4eUriConverter());
                            break;

                        case LenientParsing.STRING_TO_INT:
                            settings.Converters.Add(new LenientSystemTextJsonStringToIntConverter());
                            break;
                            // case LenientParsing.EmptyLists:
                            // converters.Add(new LenientRequiredListConverter());
                            // break;

                            // no default case because NONE and MOST_LENIENT do not come up with more converters
                    }
            //IContractResolver contractResolver;
            //if (userPropertiesWhiteList.Count > 0)
            //{
            //    contractResolver = new UserPropertiesDataContractResolver(userPropertiesWhiteList);
            //}
            //else
            //{
            //    contractResolver = new DefaultContractResolver();
            //}


            return settings;
        }
    }
}
