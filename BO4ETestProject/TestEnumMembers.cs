using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using BO4E.ENUM;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E
{
    [TestClass]
    public class TestEnumMembers
    {
        /// <summary>
        /// Tests that every enum member has an EnumMemberAttribute whose value matches the field name itself.
        /// </summary>
        /// <remarks>This is to make the enums compatible with https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/1162</remarks>
        [TestMethod]
        public void TestEnumMemberConsistency()
        {
            var enumTypes = typeof(AbgabeArt).Assembly.GetTypes()
                .Where(t => t.IsEnum && t.Namespace.StartsWith("BO4E.ENUM") &&
                            !t.Namespace.StartsWith("BO4E.ENUM.EDI"));
            foreach (var enumType in enumTypes)
            {
                var enumFields = enumType.GetFields()
                    .Where(f => f.IsPublic)
                    .Where(f => f.Name != "value__")
                    .ToList();
                var fieldsWithoutEnumMemberAttributes = enumFields
                    .Where(f => !f.GetCustomAttributes<EnumMemberAttribute>().Any())
                    .Select(f => new Tuple<Type, string>(enumType, f.Name));
                fieldsWithoutEnumMemberAttributes.Should().BeEmpty();
                var enumMemberAttributeDiffersFromEnumMemberName = enumFields
                    .Select(f => new Tuple<string, string>(f.GetCustomAttribute<EnumMemberAttribute>().Value, f.Name))
                    .Where(nameTuple => nameTuple.Item1 != nameTuple.Item2);
                enumMemberAttributeDiffersFromEnumMemberName.Should().BeEmpty();
            }
        }
    }
}
