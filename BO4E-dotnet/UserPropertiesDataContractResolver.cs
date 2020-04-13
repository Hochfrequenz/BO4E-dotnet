using System;
using System.Collections.Generic;

using Newtonsoft.Json.Serialization;

namespace BO4E
{
    /// <summary>
    /// The UserPropertiesContractResolver allows to put non-BO4E-standard/custom fields/properties into a "userProperties" object.
    /// </summary>
    public class UserPropertiesDataContractResolver : DefaultContractResolver
    {
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
