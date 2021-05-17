using System.Linq;
using System.Reflection;
using BO4E.meta;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace BO4E
{
    /// <summary>
    ///     This class performs the mapping of EDIFACT values to the corresponding BO4E values.
    /// </summary>
    /// It primarily relies on the mapping defined by the
    /// <see cref="MappingAttribute" />
    /// .
    /// <seealso cref="BoEdiMapper" />
    public class EdiBoMapper
    {
        private const string NamespacePrefix = "BO4E.ENUM";

        /// <summary>
        ///     project wide logger
        /// </summary>
        public static ILogger Logger = StaticLogger.Logger;

        /// <summary>
        ///     transform an EDIFACT value of known type to a BO4E value
        /// </summary>
        /// <seealso cref="BoEdiMapper.ToEdi(string, string)" />
        /// <param name="objectName">
        ///     name of the BO4E data type
        ///     <example>Netzebene</example>
        /// </param>
        /// <param name="objectValue">
        ///     EDIFACT value
        ///     <example>E06</example>
        /// </param>
        /// <returns>
        ///     <list type="bullet">
        ///         <item>
        ///             <description>
        ///                 <code>null</code> if the objectValue is null or no mapping is specified for the given
        ///                 type/value combination
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>the corresponding BO4E value</description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 objectValue iff no mapping was defined but objectValue is already a valid BO4E value (e.g. for
        ///                 "Landescode"s)
        ///             </description>
        ///         </item>
        ///     </list>
        /// </returns>
        /// <example>
        ///     <code>
        /// string bo4eValue = EdiBoMapper.fromEdi("Netzebene", "E06"); // returns "NSP"
        /// </code>
        /// </example>
        public static string FromEdi(string objectName, string objectValue)
        {
            if (objectValue == null) return null;

            if (Logger == null)
            {
                // ToDo: inject it instead of ugly workaround.
                StaticLogger.Logger = NullLogger.Instance;
                Logger = StaticLogger.Logger;
            }

            //Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            var clazz = Assembly.GetExecutingAssembly().GetType(NamespacePrefix + "." + objectName);
            var ediClazz = Assembly.GetExecutingAssembly().GetType($"{NamespacePrefix}.EDI.{objectName}Edi");

            var useEdiClass = false;
            var field = clazz.GetField(objectValue);
            if (field == null)
            {
                Logger.LogDebug("Class " + objectName + " has no field " + objectValue);
                if (ediClazz != null)
                {
                    field = ediClazz.GetField(objectValue);
                    useEdiClass = true;

                    if (field == null)
                    {
                        Logger.LogDebug("Even ediClass of " + objectName + " has no such field.");
                        // now try with leading underscore, used for enum values that would normally
                        // start with a number, e.g. _293 for code list "293"
                        field = ediClazz.GetField("_" + objectValue);
                        if (field == null)
                        {
                            Logger.LogError("No matching field " + objectValue + " for " + objectName +
                                            "! returning null");
                            return null;
                        }
                    }
                }
            }

            if (!useEdiClass)
            {
                if (field != null) return field.GetValue(null).ToString();
                Logger?.LogError($"No such field: '{objectValue}'");
                return null;
            }

            var attribute = field.GetCustomAttribute<MappingAttribute>();
            if (attribute == null || attribute.Mapping.Count == 0)
            {
                Logger.LogError("Custom attribute not set, returning null");
                return null;
            }

            return attribute.Mapping.FirstOrDefault()?.ToString();
        }
    }
}