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

        private readonly HashSet<string> _whitelist;

        /// <summary>
        /// The UserPropertiesDataContractResolver is initialized with a white list of allowed properties. Everything else is discarded.
        /// </summary>
        /// <param name="userPropertiesWhiteList">white list of properties (actually a white"set")</param>
        public UserPropertiesDataContractResolver(HashSet<string> userPropertiesWhiteList)
        {
            _whitelist = userPropertiesWhiteList;
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
                        if (_whitelist.Contains(key))
                        {
                            oldSetter(o, key, value);
                        }
                    };
                }
            }
            return contract;
        }
    }
}