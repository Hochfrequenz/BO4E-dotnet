using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BO4E.BO;
using BO4E.COM;
using BO4E.meta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4E
{
    [TestClass]
    public class TestBOCOMDesign
    {
        private static readonly HashSet<Type> NO_KEYS_WHITELIST = new HashSet<Type>
        {
            typeof(Kosten)
        };

        [TestMethod]
        public void TestNoBOFields()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes()
                .Where(t => typeof(BusinessObject).IsAssignableFrom(t)))
            {
                var fields = type.GetFields().Where(f => f.IsPublic && !f.IsLiteral && !f.IsStatic);
                Assert.IsFalse(fields.Any(),
                    $"Type {type} must not contain fields but has: {string.Join(", ", fields.ToList())}");
            }
        }

        [TestMethod]
        public void TestBoAllPublic()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes()
                .Where(t => t.BaseType == typeof(BusinessObject)))
                Assert.IsTrue(type.IsPublic,
                    $"Type {type} is derived from {nameof(BusinessObject)} but is not public.");
        }

        [TestMethod]
        public void TestNoCOMFields()
        {
            foreach (var type in typeof(COM).Assembly.GetTypes().Where(t => typeof(COM).IsAssignableFrom(t)))
            {
                var fields = type.GetFields().Where(f => f.IsPublic && !f.IsStatic);
                Assert.IsFalse(fields.Any(),
                    $"Type {type} must not contain public fields but has: {string.Join(", ", fields.ToList())}");
            }
        }

        [TestMethod]
        public void TestCOMAllPublic()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t => t.BaseType == typeof(COM)))
                Assert.IsTrue(type.IsPublic, $"Type {type} is derived from {nameof(COM)} but is not public.");
        }

        [TestMethod]
        public void TestBoInheritance()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t =>
                t.IsClass && t.IsPublic && t.Namespace == "BO4E.BO" && !t.Name.EndsWith("Converter")))
                Assert.IsTrue(type.IsSubclassOf(typeof(BusinessObject)) || type == typeof(BusinessObject),
                    $"Type {type} does not inherit from {nameof(BusinessObject)}.");
        }

        [TestMethod]
        public void TestCOMInheritance()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t =>
                t.IsClass && t.IsPublic && t.Namespace == "BO4E.COM" && !t.Name.EndsWith("Converter")))
                Assert.IsTrue(type.IsSubclassOf(typeof(COM)) || type == typeof(COM),
                    $"Type {type} does not inherit from {nameof(COM)}.");
        }

        [TestMethod]
        public void TestEnumNamespace()
        {
            foreach (var type in
                typeof(BusinessObject).Assembly.GetTypes().Where(t => t.IsPublic && t.Namespace == "BO4E.ENUM"))
                Assert.IsTrue(type.IsEnum,
                    $"Type {type} is in namespace BO4E.ENUM but no enum! Consinder moving the definition to another namespace or adding an internal / private modifier.");
        }

        [TestMethod]
        public void TestBoKeys()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t =>
                t.BaseType == typeof(BusinessObject) && !t.IsAbstract && !NO_KEYS_WHITELIST.Contains(t)))
            {
                var keyProps = type.GetProperties()
                    .Where(p => p.GetCustomAttributes(typeof(BoKey), false).Length > 0)
                    .OrderBy(ap => ap.GetCustomAttribute<JsonPropertyAttribute>()?.Order)
                    .ToArray();
                Assert.IsTrue(keyProps.Any(),
                    $"Type {type} is derived from {nameof(BusinessObject)} but has no [{nameof(BoKey)}] attribute.");
            }
        }

        /// <summary>
        ///     There must be no fields in BusinessObjects or COMponents where you cannot distinguish no value (null) and initial
        ///     value (e.g. ENUM default values or integer 0)
        /// </summary>
        [TestMethod]
        public void NullableDefaultEnums()
        {
            foreach (var boType in typeof(BusinessObject).Assembly.GetTypes().Where(t =>
                (t.BaseType == typeof(BusinessObject) || t.BaseType == typeof(COM)) && !t.IsAbstract))
                foreach (var obligDefaultField in boType
                    .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                    .Where(field => field.GetCustomAttributes(typeof(JsonPropertyAttribute), true)
                        .Cast<JsonPropertyAttribute>()
                        .Any(jpa => jpa.Required == Required.Default)))
                {
                    if (Nullable.GetUnderlyingType(obligDefaultField.PropertyType) != null ||
                        obligDefaultField.PropertyType == typeof(string))
                        // it is already nullable. 
                        continue;
                    if (!obligDefaultField.PropertyType.IsPrimitive && !obligDefaultField.PropertyType.IsEnum) continue;
                    Assert.IsTrue(false,
                        $"The type {obligDefaultField.PropertyType} of {boType.FullName}.{obligDefaultField.Name} is not nullable but not marked as obligatory.");
                    // this is a problem because e.g. for integers you can't distinguish between no value (null) or initial value (0). Same is true for Enum values
                }
        }
    }
}