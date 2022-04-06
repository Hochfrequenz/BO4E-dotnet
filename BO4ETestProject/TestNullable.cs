using System;
using System.Linq;
using System.Reflection;

using BO4E.BO;
using BO4E.COM;
using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace TestBO4E
{
    [TestClass]
    public class TestNullableAttributes
    {
        [TestMethod]
        public void TestNullableAttributesFromCOM()
        {
            TestNullableAttributesFromAbstract(typeof(COM));
        }


        [TestMethod]
        public void TestNullableAttributesFromBO()
        {
            TestNullableAttributesFromAbstract(typeof(BusinessObject));
        }

        private NullabilityInfoContext _nullabilityContext = new();


        protected void TestNullableAttributesFromAbstract(Type abstractBaseType)
        {
            if (!abstractBaseType.IsAbstract)
                throw new ArgumentException($"The type {abstractBaseType} is not abstract", nameof(abstractBaseType));
            var relevantTypes = typeof(BusinessObject).Assembly.GetTypes()
                .Where(t => abstractBaseType.IsAssignableFrom(t));
            foreach (var relevantType in relevantTypes)
            {
                var properties = relevantType.GetProperties();
                foreach (var dtProperty in properties)
                {

                    var jpA = dtProperty.GetCustomAttributes<JsonPropertyAttribute>().FirstOrDefault();
                    if (jpA is not null)
                    {
                        if (jpA.Required != Required.Always) // all not required fields have to be nullable
                        {
                            var nullabilityInfo = _nullabilityContext.Create(dtProperty);
                            nullabilityInfo.ReadState.Should().Be(NullabilityState.Nullable, $"The property {dtProperty.Name} of type {relevantType.Name} has to be nullable");
                        }
                    }
                }
            }
        }
    }
}
