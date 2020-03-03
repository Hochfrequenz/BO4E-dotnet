using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BO4E;
using BO4E.BO;
using BO4E.meta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4E
{
    [TestClass]
    public class TestBOCOMDesign
    {
        [TestMethod]
        public void TestNoPropertiesBo()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t => t.BaseType == typeof(BusinessObject)))
            {
                var properties = type.GetProperties();
                // properties are not allowed in BusinessObjects because a lot of features rely on fields!
                Assert.AreEqual(0, properties.Count(), $"Type {type} must not contain properties but has: {String.Join(", ", properties.ToList())}");
            }
        }

        [TestMethod]
        public void TestBoAllPublic()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t => t.BaseType == typeof(BusinessObject)))
            {
                Assert.IsTrue(type.IsPublic, $"Type {type} is derived from {nameof(BusinessObject)} but is not public.");
            }
        }

        [TestMethod]
        public void TestNoPropertiesCOM()
        {
            foreach (var type in typeof(BO4E.COM.COM).Assembly.GetTypes().Where(t => t.BaseType == typeof(BO4E.COM.COM)))
            {
                var properties = type.GetProperties();
                // properties are not allowed in COM Objects because a lot of features rely on fields!
                Assert.AreEqual(0, properties.Count(), $"Type {type} must not contain properties but has: {String.Join(", ", properties.ToList())}");
            }
        }

        [TestMethod]
        public void TestCOMAllPublic()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t => t.BaseType == typeof(BO4E.COM.COM)))
            {
                Assert.IsTrue(type.IsPublic, $"Type {type} is derived from {nameof(BO4E.COM.COM)} but is not public.");
            }
        }

        [TestMethod]
        public void TestBoInheritance()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t => t.IsClass && t.IsPublic && t.Namespace == "BO4E.BO"))
            {
                Assert.IsTrue(type.IsSubclassOf(typeof(BusinessObject)) || type.Equals(typeof(BusinessObject)), $"Type {type} does not inherit from {nameof(BusinessObject)}.");
            }
        }

        [TestMethod]
        public void TestCOMInheritance()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t => t.IsClass && t.IsPublic && t.Namespace == "BO4E.COM"))
            {
                Assert.IsTrue(type.IsSubclassOf(typeof(BO4E.COM.COM)) || type.Equals(typeof(BO4E.COM.COM)), $"Type {type} does not inherit from {nameof(BO4E.COM.COM)}.");
            }
        }

        [TestMethod]
        public void TestEnumNamespace()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t => t.IsPublic && t.Namespace == "BO4E.ENUM"))
            {
                Assert.IsTrue(type.IsEnum, $"Type {type} is in namespace BO4E.ENUM but no enum! Consinder moving the definition to another namespace or adding an internal / private modifier.");
            }
        }

        private static readonly HashSet<Type> NO_KEYS_WHITELIST = new HashSet<Type>() {
            {
                typeof(Kosten)
            } };

        [TestMethod]
        public void TestBoKeys()
        {
            foreach (var type in typeof(BusinessObject).Assembly.GetTypes().Where(t => t.BaseType == typeof(BusinessObject) && !t.IsAbstract && !NO_KEYS_WHITELIST.Contains(t)))
            {
                var keyFields = BoMapper.GetAnnotatedFields(type, typeof(BoKey));
                Assert.IsTrue(keyFields.Count() > 0, $"Type {type} is derived from {nameof(BusinessObject)} but has no [{nameof(BoKey)}] attribute.");
            }
        }

        /// <summary>
        /// There must be no fields in BusinessObjects or COMponents where you cannot distinguish no value (null) and initial value (e.g. ENUM default values or integer 0)
        /// </summary>
        [TestMethod]
        public void NullableDefaultEnums()
        {
            foreach (var boType in typeof(BusinessObject).Assembly.GetTypes().Where(t => t.BaseType == typeof(BusinessObject) && !t.IsAbstract))
            {
                foreach (var obligDefaultField in boType.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                    .Where(field => field.GetCustomAttributes(typeof(JsonPropertyAttribute), true)
                        .Cast<JsonPropertyAttribute>()
                        .Any(jpa => jpa.Required == Required.Default)))
                {
                    if (Nullable.GetUnderlyingType(obligDefaultField.FieldType) != null)
                    {
                        continue;
                    }
                    if (obligDefaultField.FieldType == typeof(string))
                    {
                        continue;
                    }
                    if (!obligDefaultField.FieldType.IsPrimitive && !obligDefaultField.FieldType.IsEnum)
                    {
                        continue;
                    }
                    Assert.IsTrue(false, $"The type {obligDefaultField.FieldType} of {boType.FullName}.{obligDefaultField.Name} is not nullable but not marked as obligatory.");
                    // this is a problem because e.g. for integers you can't distinguish between no value (null) or initial value (0). Same is true for Enum values
                }
            }
        }
    }
}
