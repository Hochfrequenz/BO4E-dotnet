using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E;

[TestClass]
public class TestEnums
{
    [TestMethod]
    public void No_Two_Enum_Members_Share_The_Same_Integer_Value()
    {
        var arbitraryEnumType = typeof(BO4E.ENUM.Abweichungsgrund);
        var enumAssembly = Assembly.GetAssembly(arbitraryEnumType);
        enumAssembly.Should().NotBeNull();
        var enumTypesWithDuplicateValues = enumAssembly!
            .GetTypes()
            .Where(t => t.IsEnum)
            .Where(t =>
            {
                var values = Enum.GetValues(t).Cast<int>();
                var valueGroups = values.GroupBy(v => v).Where(g => g.Count() > 1).ToList();
                return valueGroups.Any();
            })
            .ToList();
        enumTypesWithDuplicateValues.Should().BeEmpty("this may cause undefined behaviour");
        // https://github.com/dotnet/runtime/issues/107296#issuecomment-2327881647
    }
}
