using Newtonsoft.Json.Serialization;

using System;
using System.Collections.Generic;

namespace BO4E
{
    /// <summary>
    /// The UserPropertiesContractResolver allows to put non-BO4E-standard/custom fields/properties into a "userProperties" object.
    /// </summary>
    public class UserPropertiesDataContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// easily accessible instance of this converter
        /// </summary>
        public static readonly UserPropertiesDataContractResolver Instance = new UserPropertiesDataContractResolver(new HashSet<string>());

        private readonly HashSet<string> whitelist;

        /// <summary>
        /// The UserPropertiesDataContractResolver is initialised with a white list of allowed properties. Everything else is discarded.
        /// </summary>
        /// <param name="userPropertiesWhiteList">white list of properties (actually a white"set")</param>
        public UserPropertiesDataContractResolver(HashSet<string> userPropertiesWhiteList)
        {
            whitelist = userPropertiesWhiteList;
        }

        /// <inheritdoc cref="DefaultContractResolver.ResolveContract(Type)"/>
        public override JsonContract ResolveContract(Type type)
        {
            JsonContract contract = base.ResolveContract(type);
            if (contract is JsonObjectContract objContract)
            {
                if (objContract.ExtensionDataSetter != null)
                {
                    ExtensionDataSetter oldSetter = objContract.ExtensionDataSetter;
                    objContract.ExtensionDataSetter = (o, key, value) =>
                    {
                        if (whitelist.Contains(key))
                        {
                            oldSetter(o, key, value);
                        }
                        else
                        {
                            int a = 0;
                            a++;
                        }
                    };
                }
            }
            return contract;
        }
    }
}