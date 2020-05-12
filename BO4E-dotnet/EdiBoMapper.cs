using BO4E.ENUM;
using BO4E.meta;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;

namespace BO4E
{
    /// <summary>
    /// This class performs the mapping of EDIFACT values to the corresponding BO4E values.
    /// </summary>
    /// It primarily relies on the mapping defined by the <see cref="MappingAttribute"/>.
    /// <seealso cref="BoEdiMapper"/>
    public class EdiBoMapper
    {
        /// <summary>
        /// project wide logger
        /// </summary>
        public static ILogger _logger = StaticLogger.Logger;
        private static readonly string namespacePrefix = "BO4E.ENUM";

        /// <summary>
        /// transform an EDIFACT value of known type to a BO4E value
        /// </summary>
        /// <seealso cref="BoEdiMapper.toEdi(string, string)"/>
        /// <param name="objectName">name of the BO4E datatype<example>Netzebene</example></param>
        /// <param name="objectValue">EDIFACT value<example>E06</example></param>
        /// <returns>
        /// <list type="bullet">
        /// <item><description><code>null</code> if the objectValue is null or no mapping is specified for the given type/value combination</description></item>
        /// <item><description>the corresponding BO4E value</description></item>
        /// <item><description>objectValue iff no mapping was defined but objectValue is already a valid BO4E value (e.g. for "Landescode"s)</description></item>
        /// </list>
        /// </returns>
        /// <example>
        /// <code>
        /// string bo4eValue = EdiBoMapper.fromEdi("Netzebene", "E06"); // returns "NSP"
        /// </code>
        /// </example>
        public static string fromEdi(string objectName, string objectValue)
        {
            if (objectValue == null)
            {
                return null;
            }

            if (_logger == null)
            {
                // ToDo: inject it instead of ugly workaround.
                BO4E.StaticLogger.Logger = Microsoft.Extensions.Logging.Abstractions.NullLogger.Instance; 
                _logger = StaticLogger.Logger;
            }
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            Type clazz = Assembly.GetExecutingAssembly().GetType(namespacePrefix + "." + objectName);
            Type ediClazz = Assembly.GetExecutingAssembly().GetType($"{namespacePrefix}.EDI.{objectName}Edi");

            bool useEdiClass = false;
            FieldInfo field = null;

            field = clazz.GetField(objectValue);
            if (field == null)
            {
                _logger.LogDebug("Class " + objectName + " has no field " + objectValue);
                if (ediClazz != null)
                {
                    field = ediClazz.GetField(objectValue);
                    useEdiClass = true;

                    if (field == null)
                    {
                        _logger.LogDebug("Even ediClass of " + objectName + " has no such field.");
                        // now try with leading underscore, used for enum values that would normally
                        // start with a number, e.g. _293 for Codelist "293"
                        field = ediClazz.GetField("_" + objectValue);
                        useEdiClass = true;
                        if (field == null)
                        {
                            _logger.LogError("No matching field " + objectValue + " for " + objectName + "! returning null");
                            return null;
                        }
                    }
                }
            }
            if (!useEdiClass)
            {
                try
                {
                    return field.GetValue(null).ToString();
                }
                catch (Exception e) // ToDo: Fix pokemon catcher
                {
                    _logger.LogError($"No such field: {e.Message}");
                    return null;
                }
            }
            var attribute = field.GetCustomAttribute<MappingAttribute>();
            if (attribute == null || attribute.Mapping.Count == 0)
            {
                _logger.LogError("Custom attribute not set, returning null");
                return null;
            }
            else
            {
                return attribute.Mapping.FirstOrDefault()?.ToString();
            }

        }
    }
}