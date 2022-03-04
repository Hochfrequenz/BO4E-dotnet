using System;
using System.Collections.Generic;
using System.Linq;
using BO4E.BO;
using Newtonsoft.Json.Serialization;

namespace BO4E.meta
{
    /// <summary>
    ///     implements a <see cref="ISerializationBinder" /> for known Business Objects
    /// </summary>
    public class BusinessObjectSerializationBinder : ISerializationBinder
    {
        static BusinessObjectSerializationBinder()
        {
            BusinessObjectAndCOMTypes = typeof(BusinessObject).Assembly.GetTypes().Where(t =>
                t.IsClass && !t.IsAbstract &&
                (typeof(BusinessObject).IsAssignableFrom(t) || typeof(COM.COM).IsAssignableFrom(t))).ToList();
        }

        // implementation is similar to the JSON.net example implementation in the docs: https://www.newtonsoft.com/json/help/html/SerializeSerializationBinder.htm
        /// <summary>
        ///     list of all known BusinessObjects inheriting from <see cref="BO4E.BO.BusinessObject" /> and components inheriting
        ///     from <see cref="BO4E.COM.COM" />
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static IList<Type> BusinessObjectAndCOMTypes { get; }

        /// <inheritdoc cref="ISerializationBinder.BindToType(string, string)" />
        public Type BindToType(string assemblyName, string typeName)
        {
            return BusinessObjectAndCOMTypes.SingleOrDefault(t => t.Name == typeName);
        }

        /// <inheritdoc cref="ISerializationBinder.BindToName(Type, out string, out string)" />
        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }
    }
}