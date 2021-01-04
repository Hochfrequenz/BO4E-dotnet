using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BO4E.BO;
using BO4E.meta;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace BO4E
{
    /// <summary>
    /// This class performs the mapping of BO4E values to the corresponding EDIFACT values.
    /// </summary>
    /// It primarily relies on the mapping defined by the <see cref="MappingAttribute"/>.
    /// <seealso cref="EdiBoMapper"/>
    public class BoEdiMapper
    {
        /// <summary>
        /// project wide logger
        /// </summary>
        public static ILogger _logger = StaticLogger.Logger;
        private static readonly string namespacePrefix = "BO4E.ENUM";
        /// <summary>
        /// transform a BO4E value of known type to an EDIFACT value
        /// </summary>
        /// <seealso cref="EdiBoMapper.FromEdi(string, string)"/>
        /// <param name="objectName">name of the BO4E datatype<example>Netzebene</example></param>
        /// <param name="objectValue">BO4E value<example>HSP</example></param>
        /// <returns>
        /// <list type="bullet">
        /// <item><description><code>null</code> if the objectValue is null or no mapping is specified for the given type/value combination</description></item>
        /// <item><description>the corresponding EDIFACT value</description></item>
        /// <item><description>objectValue iff no mapping was defined but objectValue is already a valid EDIFACT value (e.g. for "Landescode"s)</description></item>
        /// </list>
        /// </returns>
        /// <example>
        /// <code>
        /// string ediValue = BoEdiMapper.toEdi("Netzebene", "NSP"); // returns "E06"
        /// </code>
        /// </example>
        public static string ToEdi(string objectName, string objectValue)
        {
            if (objectValue == null)
            {
                return null;
            }

            if (_logger == null)
            {
                // ToDo: inject it instead of ugly workaround.
                StaticLogger.Logger = Microsoft.Extensions.Logging.Abstractions.NullLogger.Instance; 
                _logger = StaticLogger.Logger;
            }
            //Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            var clazz = Assembly.GetExecutingAssembly().GetType(namespacePrefix + "." + objectName);
            var ediClazz = Assembly.GetExecutingAssembly().GetType($"{namespacePrefix}.EDI.{objectName}Edi");

            var prop = clazz.GetField(objectValue);
            if (prop == null)
            {
                _logger.LogWarning($"Class objectName has no field {objectValue}; Might already be the edi value...");
                var alternativField = EdiBoMapper.FromEdi(objectName, objectValue);
                if (alternativField != null && clazz.GetField(alternativField) != null)
                {
                    return objectValue;
                }
                else
                {
                    _logger.LogError($"Couldn't make any sense out of {objectName} / {objectValue}");
                    return null;
                }
            }
            if (ediClazz == null)
            {
                _logger.LogWarning($"No EdiClass defined for {objectName}. Too lazy? Returning original value {objectValue}"); // holds true for landescode.
                return objectValue;
            }
            // try to find annotation with EdiValue
            var annotatedEdiFields = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Name == ediClazz.Name)
                .SelectMany(t => t.GetFields())
                .Where(f => f.GetCustomAttributes(typeof(MappingAttribute), false).Length > 0).ToArray();
            if (annotatedEdiFields.Length == 0)
            {
                _logger.LogError($"No annotated EdiFields found for {objectName} / {objectValue}");
                return null;
            }
            foreach (var aef in annotatedEdiFields)
            {
                foreach (var ma in aef.GetCustomAttributes<MappingAttribute>())
                {
                    var matchCandidate = ma.Mapping.FirstOrDefault();
                    if (matchCandidate != null && matchCandidate.ToString() == objectValue)
                    {
                        if (aef.Name.StartsWith("_"))
                        {
                            if (clazz.GetField(EdiBoMapper.FromEdi(objectName, aef.Name.Substring(1))) != null)
                            {
                                return aef.Name.Substring(1);
                            }
                        }
                        return aef.Name;
                    }
                }
            }
            _logger.LogError($"No EDI match found for {objectName} /{objectValue}. Probably is already EDI");
            return objectValue;
        }

        /// <summary>
        /// Consumes a BusinessObject or BO4E COMponent and replaces all ENUM values with 
        /// corresponding EDIFACT values. The result is a JObject with a similar structure as the
        /// original BO/COM but contains EDIFACT compliant string values where the original BO had
        /// BO4E compliant enum values.
        /// </summary>
        /// This method is useful if you'd like to process the BO in/for an environment like
        /// the WiMPiM.
        /// <param name="o">Valid Business Object or BO4E COMponent</param>
        /// <returns>JObject with same structure as original object</returns>
        public static JObject ReplaceWithEdiValues(Object o)
        {
            var type = o.GetType();
            if (!type.IsSubclassOf(typeof(BusinessObject)) && !type.IsSubclassOf(typeof(BO4E.COM.COM)))
            {
                throw new ArgumentException($"Please pass a Business Object or BO4E COMpontent instead of {o.GetType()} with value '{o.ToString()}'.");
            }
            var boString = JsonConvert.SerializeObject(o, new StringEnumConverter());
            var result = (JObject)JsonConvert.DeserializeObject(boString);
            foreach (var oProp in o.GetType().GetProperties().Where(p=>p.GetValue(o)!=null))
            {
                var serializationName = oProp.GetCustomAttribute<JsonPropertyAttribute>().PropertyName ?? oProp.Name;
                var originalType = Nullable.GetUnderlyingType(oProp.PropertyType) ?? oProp.PropertyType;
                if (originalType.IsSubclassOf(typeof(BO4E.COM.COM)) || originalType.IsSubclassOf(typeof(BO4E.BO.BusinessObject)))
                {
                    object newValue = ReplaceWithEdiValues(oProp.GetValue(o));
                    result[serializationName] = (JToken)newValue;
                }
                else if (originalType.IsGenericType && (originalType.GetGenericTypeDefinition() == typeof(List<>)))
                {
                    var originalListItemType = originalType.GetGenericArguments()[0];
                    if (originalListItemType.ToString().StartsWith("BO4E.ENUM"))
                    {
                        var listItemEdiType = Assembly.GetExecutingAssembly().GetType($"{namespacePrefix}.EDI.{originalListItemType.Name}Edi");
                        if (listItemEdiType != null)
                        {
                            var listType = typeof(List<>).MakeGenericType(listItemEdiType);
                            var newList = Activator.CreateInstance(listType);
                            var miAdd = listType.GetMethod("Add");
                            foreach (var listItem in (IEnumerable)oProp.GetValue(o))
                            {
                                var newValue = ToEdi(originalListItemType.Name, listItem.ToString());
                                miAdd.Invoke(newList, new object[] { Enum.Parse(listItemEdiType, newValue) });
                            }
                            var js = new JsonSerializer();
                            js.Converters.Add(new StringEnumConverter());
                            result[serializationName] = JToken.FromObject(newList, js);
                        }
                        else
                        {
                            throw new NotImplementedException($"There is no BO4E<-->EDIFACT mapping defined for {originalListItemType.ToString()}.");
                        }
                    }
                    else
                    {
                        var listType = typeof(List<>).MakeGenericType(typeof(JObject));
                        var newList = Activator.CreateInstance(listType);
                        var miAdd = listType.GetMethod("Add");
                        foreach (var listItem in (IEnumerable)oProp.GetValue(o))
                        {
                            object newListItem = ReplaceWithEdiValues(listItem);
                            miAdd.Invoke(newList, new object[] { newListItem });
                        }
                        result[serializationName] = JToken.FromObject(newList);
                    }
                }
                var ediType = Assembly.GetExecutingAssembly().GetType($"{namespacePrefix}.EDI.{originalType.Name}Edi");
                if (ediType != null)
                {
                    var newValue = ToEdi(originalType.Name, oProp.GetValue(o).ToString());
                    result[serializationName] = newValue;
                }
            }
            return result;
        }
    }
}