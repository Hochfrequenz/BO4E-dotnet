using System;
using AwesomeAssertions;
using BO4E.meta.LenientConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E;

[TestClass]
public class TestNullableDateTimeOffsetConverter
{
    public class ClassWithNullableDateTimeOffset
    {
        public DateTimeOffset? Foo { get; set; }
    }

    [TestMethod]
    public void Test_Nullable_DateTimeOffset_is_not_set_to_min_value()
    {
        const string jsonString = "{\"Foo\":null}";
        var lenientParsing = LenientParsing.SET_INITIAL_DATE_IF_NULL | LenientParsing.DATE_TIME;
        var obj = System.Text.Json.JsonSerializer.Deserialize<ClassWithNullableDateTimeOffset>(
            jsonString,
            lenientParsing.GetJsonSerializerOptions()
        );
        obj.Foo.Should().BeNull();
    }

    public class ClassWithNonNullableDateTimeOffset
    {
        public DateTimeOffset Foo { get; set; }
    }

    [TestMethod]
    public void Test_NonNullable_DateTimeOffset_is_set_to_min_value()
    {
        const string jsonString = "{\"Foo\":null}";
        var lenientParsing = LenientParsing.SET_INITIAL_DATE_IF_NULL | LenientParsing.DATE_TIME;
        var obj = System.Text.Json.JsonSerializer.Deserialize<ClassWithNonNullableDateTimeOffset>(
            jsonString,
            lenientParsing.GetJsonSerializerOptions()
        );
        obj.Foo.Should().Be(DateTimeOffset.MinValue);
    }

    public class ClassWithNullableDateTime
    {
        public DateTime? Foo { get; set; }
    }

    [TestMethod]
    public void Test_Nullable_DateTime_is_not_set_to_min_value()
    {
        const string jsonString = "{\"Foo\":null}";
        var lenientParsing = LenientParsing.SET_INITIAL_DATE_IF_NULL | LenientParsing.DATE_TIME;
        var obj = System.Text.Json.JsonSerializer.Deserialize<ClassWithNullableDateTime>(
            jsonString,
            lenientParsing.GetJsonSerializerOptions()
        );
        obj.Foo.Should().BeNull();
    }

    public class ClassWithNonNullableDateTime
    {
        public DateTime Foo { get; set; }
    }

    [TestMethod]
    public void Test_NonNullable_DateTime_is_set_to_min_value()
    {
        const string jsonString = "{\"Foo\":null}";
        var lenientParsing = LenientParsing.SET_INITIAL_DATE_IF_NULL | LenientParsing.DATE_TIME;
        var obj = System.Text.Json.JsonSerializer.Deserialize<ClassWithNonNullableDateTime>(
            jsonString,
            lenientParsing.GetJsonSerializerOptions()
        );
        obj.Foo.Should().Be(DateTime.MinValue);
    }
}
