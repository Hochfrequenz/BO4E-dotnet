using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using BO4E.BO;
using BO4E.COM;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace TestBO4E
{
    [TestClass]
    public class TestJsonOrder
    {
        [TestMethod]
        public void TestJsonOrderAttributesOfCOM()
        {
            TestOrderFromAbstract(typeof(COM));
        }

        [TestMethod]
        public void TestJsonOrderAttributesOfBO()
        {
            TestOrderFromAbstract(typeof(BusinessObject));
        }

        protected static void TestOrderFromAbstract(Type abstractBaseType)
        {
            if (!abstractBaseType.IsAbstract)
                throw new ArgumentException($"The type {abstractBaseType} is not abstract", nameof(abstractBaseType));
            var relevantTypes = typeof(BusinessObject).Assembly.GetTypes().Where(abstractBaseType.IsAssignableFrom);
            foreach (var relevantType in relevantTypes)
            {
                var properties = relevantType.GetProperties();
                var orders = new HashSet<int>();
                foreach (var dtProperty in properties)
                {
                    var systemTextIgnore = dtProperty.GetCustomAttributes<JsonIgnoreAttribute>().FirstOrDefault();
                    if (systemTextIgnore is not null)
                    {
                        continue;
                    }
                    var systemTextJsonOrderAttribute = dtProperty.GetCustomAttributes<JsonPropertyOrderAttribute>().FirstOrDefault();
                    systemTextJsonOrderAttribute.Should()
                        .NotBeNull(because: $"The property {dtProperty.Name} of {relevantType.Name} should have System.Text.JsonPropertyOrderAttribute");
                    var newtonSoftJsonPropertyAttribute = dtProperty.GetCustomAttributes<JsonPropertyAttribute>().FirstOrDefault();
                    newtonSoftJsonPropertyAttribute.Should().NotBeNull($"The property {dtProperty.Name} of {relevantType.Name} should have Newtonsoft.Json.JsonPropertyAttribute");
                    var systemTextOrder = systemTextJsonOrderAttribute.Order;
                    orders.Should().NotContain(systemTextOrder, because: $"The JsonPropertyOrderAttribute should be unique for {relevantType} but found multiple occurrences of {systemTextOrder}");
                    orders.Add(systemTextOrder);

                    var newtonsoftIgnore = dtProperty.GetCustomAttributes<Newtonsoft.Json.JsonIgnoreAttribute>().FirstOrDefault();
                    if (newtonsoftIgnore is not null)
                    {
                        continue;
                    }
                    var newtonsoftOrder = newtonSoftJsonPropertyAttribute.Order;
                    systemTextOrder.Should().Be(newtonsoftOrder, because: $"System.Text Order and Newtonsoft Order of {relevantType.Name}.{dtProperty.Name} should be the same.");
                }
            }
        }
    }
}
