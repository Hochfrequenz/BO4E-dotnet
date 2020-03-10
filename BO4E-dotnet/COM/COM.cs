using System;
using System.Collections.Generic;
using System.Reflection;
using BO4E.BO;
using BO4E.meta;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// The COM class is the abstract class from which all BO4E.COM classes are derived.
    /// </summary>
    // The COMs are modelled as classes instead of structs, because other than structs,
    // classes allow for manipulation of single fields (they're mutable).
    public abstract class COM : IEquatable<COM>
    {
        /// <summary>
        /// User properties (non bo4e standard)
        /// </summary>
        [JsonProperty(PropertyName = BusinessObject.userPropertiesName, Required = Required.Default, Order = 500)]
        [ProtoMember(100)]
        [JsonExtensionData]
        [DataCategory(DataCategory.USER_PROPERTIES)]
        public IDictionary<string, JToken> userProperties;

        /// <summary>
        /// BO4E components are considered equal iff all of their elements/fields are equal.
        /// </summary>
        /// <param name="b">another object</param>
        /// <returns><code>true</code> iff all elements of this COM and COM b are equal; <code>false</code> otherwise</returns>
        public override bool Equals(object b)
        {
            if (b == null || b.GetType() != this.GetType())
            {
                return false;
            }
            return this.Equals(b as COM);
        }

        /// <summary>
        /// BO4E components are considered equal iff all of their elements/fields are equal.
        /// </summary>
        /// <param name="b">another BO4E component</param>
        /// <returns><code>true</code> iff all elements of this COM and COM b are equal; <code>false</code> otherwise</returns>
        public bool Equals(COM b)
        {
            if (b == null || b.GetType() != this.GetType())
            {
                return false;
            }
            return JsonConvert.SerializeObject(this) == JsonConvert.SerializeObject(b);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int result = 31; // I read online that a medium sized prime was a good choice ;)
            unchecked
            {
                result *= this.GetType().GetHashCode();
                foreach (FieldInfo field in this.GetType().GetFields())
                {
                    if (field.GetValue(this) != null)
                    {
                        // Using +19 because the default hash code of uninitialised enums is zero.
                        // This would screw up the calculation such that all objects with at least one null value had the same hash code, namely 0.
                        result *= 19 + field.GetValue(this).GetHashCode();
                    }
                }
                return result;
            }
        }

        /// <inheritdoc cref="BO4E.BO.BusinessObject.IsValid"/>
        public bool IsValid()
        {
            try
            {
                JsonConvert.SerializeObject(this);
            }
            catch (JsonSerializationException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// allows adding a GUID to COM objects for tracking across systems
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string guid;
    }
}
