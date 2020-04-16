using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BO4E.meta.LenientConverters
{
    public static class LenientParsingExtensions
    {
        /// <summary>
        /// <inheritdoc cref="GetJsonSerializerSettings(LenientParsing, HashSet{string})/>
        /// </summary>
        /// <param name="lenient"></param>
        /// <returns></returns>
        public static JsonSerializerSettings GetJsonSerializerSettings(this LenientParsing lenient)
        {
            return GetJsonSerializerSettings(lenient, new HashSet<string>());
        }

        /// <summary>
        /// Generates JsonSerializerSettings for given lenient parsing setting
        /// </summary>
        /// <param name="lenient"></param>
        /// <param name="userPropertiesWhiteList"></param>
        /// <returns></returns>
        public static JsonSerializerSettings GetJsonSerializerSettings(this LenientParsing lenient, HashSet<string> userPropertiesWhiteList)
        {
            List<JsonConverter> converters = new List<JsonConverter>();
            foreach (LenientParsing lp in Enum.GetValues(typeof(LenientParsing)))
            {
                if (lenient.HasFlag(lp))
                {
                    switch (lp)
                    {
                        case LenientParsing.DateTime:
                            if (!lenient.HasFlag(LenientParsing.SetInitialDateIfNull))
                            {
                                converters.Add(new LenientDateTimeConverter());
                            }
                            else
                            {
                                converters.Add(new LenientDateTimeConverter(new DateTimeOffset()));
                            }
                            break;
                        case LenientParsing.EnumList:
                            converters.Add(new LenientEnumListConverter());
                            break;
                        case LenientParsing.Bo4eUri:
                            converters.Add(new LenientBo4eUriConverter());
                            break;
                        case LenientParsing.StringToInt:
                            converters.Add(new LenientStringToIntConverter());
                            break;
                            // case LenientParsing.EmptyLists:
                            // converters.Add(new LenientRequiredListConverter());
                            // break;

                            // no default case because NONE and MOST_LENIENT do not come up with more converters
                    }
                }
            }
            IContractResolver contractResolver;
            if (userPropertiesWhiteList.Count > 0)
            {
                contractResolver = new UserPropertiesDataContractResolver(userPropertiesWhiteList);
            }
            else
            {
                contractResolver = new DefaultContractResolver();
            }
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = converters,
                DateParseHandling = DateParseHandling.None,
                ContractResolver = contractResolver
            };
            return settings;
        }
    }
}
