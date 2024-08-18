using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BO4E.meta.LenientConverters
{
    /// <summary>
    ///     Extensions to simplify the usage of the Lenient parser for <see cref="Newtonsoft.Json.JsonSerializer" />
    ///     (newtonsoft)
    /// </summary>
    /// <seealso cref="BO4E.meta.LenientConverters.LenientSystemTextJsonParsingExtensions" />
    public static class LenientParsingExtensionsNewtonsoft
    {
        /// <summary>
        ///     <inheritdoc cref="GetJsonSerializerSettings(LenientParsing, HashSet{string})" />
        /// </summary>
        /// <param name="lenient"></param>
        /// <returns></returns>
        public static JsonSerializerSettings GetJsonSerializerSettings(this LenientParsing lenient)
        {
            return GetJsonSerializerSettings(lenient, new HashSet<string>());
        }

        /// <summary>
        ///     Generates <see cref="Newtonsoft.Json.JsonSerializerSettings" /> (Newtonsoft) for given lenient parsing setting
        /// </summary>
        /// <param name="lenient"></param>
        /// <param name="userPropertiesWhiteList"></param>
        /// <returns></returns>
        public static JsonSerializerSettings GetJsonSerializerSettings(this LenientParsing lenient,
            HashSet<string> userPropertiesWhiteList)
        {
            var converters = new List<JsonConverter>();
            foreach (LenientParsing lp in Enum.GetValues(typeof(LenientParsing)))
                if (lenient.HasFlag(lp))
                    // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
                {
                    switch (lp)
                    {
                        case LenientParsing.DATE_TIME:
                            converters.Add(!lenient.HasFlag(LenientParsing.SET_INITIAL_DATE_IF_NULL)
                                ? new LenientDateTimeConverter()
                                : new LenientDateTimeConverter(new DateTimeOffset()));
                            break;

                        case LenientParsing.ENUM_LIST:
                            converters.Add(new LenientEnumListConverter());
                            break;

                        case LenientParsing.BO4_E_URI:
                            converters.Add(new LenientBo4eUriConverter());
                            break;

                        case LenientParsing.STRING_TO_INT:
                            converters.Add(new LenientStringToIntConverter());
                            break;
                        // case LenientParsing.EmptyLists:
                        // converters.Add(new LenientRequiredListConverter());
                        // break;

                        // no default case because NONE and MOST_LENIENT do not come up with more converters
                    }
                }

            IContractResolver contractResolver = userPropertiesWhiteList.Count > 0
                ? new UserPropertiesDataContractResolver(userPropertiesWhiteList)
                : new DefaultContractResolver();
            var settings = new JsonSerializerSettings
            {
                Converters = converters,
                DateParseHandling = DateParseHandling.None,
                ContractResolver = contractResolver
            };
            return settings;
        }
    }
}