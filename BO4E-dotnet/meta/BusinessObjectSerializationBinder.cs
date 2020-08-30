using BO4E.BO;

using Newtonsoft.Json.Serialization;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BO4E.meta
{
    /// <summary>
    /// implements a <see cref="ISerializationBinder"/> for known Business Objects
    /// </summary>
    public class BusinessObjectSerializationBinder : ISerializationBinder
    {
        // implementation is similar to the JSON.net example implementation in the docs: https://www.newtonsoft.com/json/help/html/SerializeSerializationBinder.htm
        /// <summary>
        /// list of all known BusinessOjects inheriting from <see cref="BO4E.BO.BusinessObject"/> and components inheriting from <see cref="BO4E.COM.COM"/> 
        /// </summary>
        public static IList<Type> BusinessObjectAndCOMTypes { get; }

        static BusinessObjectSerializationBinder()
        {
            BusinessObjectAndCOMTypes = typeof(BusinessObject).Assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && (typeof(BO4E.BO.BusinessObject).IsAssignableFrom(t) || typeof(BO4E.COM.COM).IsAssignableFrom(t))).ToList();
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            return BusinessObjectAndCOMTypes.SingleOrDefault(t => t.Name == typeName);
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }
    }
}
