using BO4E.BO;

using Newtonsoft.Json.Serialization;

using System;
using System.Collections.Generic;
using System.Linq;
using BO4E.COM;

namespace BO4E.meta
{
    /// <summary>
    /// implements a <see cref="ISerializationBinder"/> for known Business Objects
    /// </summary>
    public class BusinessObjectSerializationBinder : ISerializationBinder
    {
        // implementation is similar to the JSON.net example implementation in the docs: https://www.newtonsoft.com/json/help/html/SerializeSerializationBinder.htm
        /// <summary>
        /// list of all known BusinessObjects inheriting from <see cref="BO4E.BO.BusinessObject"/> and components inheriting from <see cref="Com"/>
        /// </summary>
        public static IList<Type> BusinessObjectAndComTypes { get; }

        static BusinessObjectSerializationBinder()
        {
            BusinessObjectAndComTypes = typeof(BusinessObject).Assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && (typeof(BusinessObject).IsAssignableFrom(t) || typeof(BO4E.COM.Com).IsAssignableFrom(t))).ToList();
        }

        /// <inheritdoc cref="ISerializationBinder.BindToType(string, string)"/>
        public Type BindToType(string assemblyName, string typeName)
        {
            return BusinessObjectAndComTypes.SingleOrDefault(t => t.Name == typeName);
        }

        /// <inheritdoc cref="ISerializationBinder.BindToName(Type, out string, out string)"/>
        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }
    }
}