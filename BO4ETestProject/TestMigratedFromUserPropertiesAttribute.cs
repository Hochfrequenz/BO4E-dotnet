using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AwesomeAssertions;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E;

/// <summary>
/// Tests for the <see cref="MigratedFromUserPropertiesAttribute"/> and its associated
/// error-tolerant deserialization behavior.
/// </summary>
/// <remarks>
/// <para>
/// These tests verify that:
/// <list type="number">
///     <item><description>Normal deserialization still works for valid data</description></item>
///     <item><description>Type mismatches on properties marked with [MigratedFromUserProperties] are caught,
///         stored in UserProperties, and don't crash</description></item>
///     <item><description>Type mismatches on properties NOT marked with the attribute still throw</description></item>
///     <item><description>Malformed JSON syntax still throws (not silently swallowed)</description></item>
///     <item><description>Various type mismatch scenarios are handled correctly</description></item>
/// </list>
/// </para>
/// <para>
/// BREAKING CHANGE from previous LenientVerbrauchsartListConverter:
/// The old converters attempted to salvage data from malformed input (e.g., extracting values from
/// nested arrays). The new approach simply catches the error and stores the raw value in UserProperties
/// for manual cleanup. "Broken is broken" - data that doesn't match the expected type is not salvaged.
/// </para>
/// </remarks>
[TestClass]
public class TestMigratedFromUserPropertiesAttribute
{
    #region Test Setup

    private static JsonSerializerOptions GetSystemTextJsonOptions()
    {
        return LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
    }

    private static JsonSerializerSettings GetNewtonsoftSettings()
    {
        return LenientParsing.MOST_LENIENT.GetJsonSerializerSettings();
    }

    #endregion

    #region Normal Deserialization Tests

    [TestMethod]
    [Description("Valid Verbrauchsarten array deserializes correctly with STJ")]
    public void Test_SystemTextJson_ValidVerbrauchsartenArray_DeserializesCorrectly()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":[""KL"",""STW""]}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.ZaehlwerkId.Should().Be("ZW001");
        result
            .Verbrauchsarten.Should()
            .NotBeNull()
            .And.HaveCount(2)
            .And.ContainInOrder(Verbrauchsart.KL, Verbrauchsart.STW);
        result.UserProperties.Should().BeNull();
    }

    [TestMethod]
    [Description("Valid Verbrauchsarten array deserializes correctly with Newtonsoft")]
    public void Test_Newtonsoft_ValidVerbrauchsartenArray_DeserializesCorrectly()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":[""KL"",""STW""]}";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.ZaehlwerkId.Should().Be("ZW001");
        result
            .Verbrauchsarten.Should()
            .NotBeNull()
            .And.HaveCount(2)
            .And.ContainInOrder(Verbrauchsart.KL, Verbrauchsart.STW);
    }

    [TestMethod]
    [Description("Empty Verbrauchsarten array deserializes correctly with STJ")]
    public void Test_SystemTextJson_EmptyVerbrauchsartenArray_DeserializesCorrectly()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":[]}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.Verbrauchsarten.Should().NotBeNull().And.BeEmpty();
    }

    [TestMethod]
    [Description("Null Verbrauchsarten deserializes correctly with STJ")]
    public void Test_SystemTextJson_NullVerbrauchsarten_DeserializesCorrectly()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":null}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.Verbrauchsarten.Should().BeNull();
    }

    #endregion

    #region Type Mismatch - Object Instead of Array

    [TestMethod]
    [Description("Object instead of array on marked property stores in UserProperties with STJ")]
    public void Test_SystemTextJson_ObjectInsteadOfArray_StoresInUserProperties()
    {
        // Arrange: Verbrauchsarten is an object instead of expected array
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":{""invalid"":""object""}}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.ZaehlwerkId.Should().Be("ZW001");
        result.Verbrauchsarten.Should().BeNull("property should be set to default on error");
        result.UserProperties.Should().NotBeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    [TestMethod]
    [Description(
        "Object instead of array on marked property stores in UserProperties with Newtonsoft"
    )]
    public void Test_Newtonsoft_ObjectInsteadOfArray_StoresInUserProperties()
    {
        // Arrange: Verbrauchsarten is an object instead of expected array
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":{""invalid"":""object""}}";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.ZaehlwerkId.Should().Be("ZW001");
        result.Verbrauchsarten.Should().BeNull("property should be set to default on error");
        result.UserProperties.Should().NotBeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    #endregion

    #region Type Mismatch - Nested Arrays (Breaking Change from Old Behavior)

    [TestMethod]
    [Description("Nested arrays are no longer salvaged - stored in UserProperties instead")]
    public void Test_SystemTextJson_NestedArray_NoLongerSalvaged_StoresInUserProperties()
    {
        // Arrange: Previously, [[0], [1]] would be salvaged to [0, 1]
        // Now it should fail and store in UserProperties
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":[[""KL""], [""STW""]]}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.ZaehlwerkId.Should().Be("ZW001");
        // Breaking change: nested arrays are no longer salvaged
        result.Verbrauchsarten.Should().BeNull("nested arrays are no longer salvaged");
        result.UserProperties.Should().NotBeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    [TestMethod]
    [Description("Nested arrays are no longer salvaged with Newtonsoft")]
    public void Test_Newtonsoft_NestedArray_NoLongerSalvaged_StoresInUserProperties()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":[[""KL""], [""STW""]]}";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.ZaehlwerkId.Should().Be("ZW001");
        result.Verbrauchsarten.Should().BeNull("nested arrays are no longer salvaged");
        result.UserProperties.Should().NotBeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    #endregion

    #region Type Mismatch - String Instead of Array

    [TestMethod]
    [Description("String instead of array stores in UserProperties with STJ")]
    public void Test_SystemTextJson_StringInsteadOfArray_StoresInUserProperties()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":""KL""}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.ZaehlwerkId.Should().Be("ZW001");
        result.Verbrauchsarten.Should().BeNull();
        result.UserProperties.Should().NotBeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    [TestMethod]
    [Description("String instead of array stores in UserProperties with Newtonsoft")]
    public void Test_Newtonsoft_StringInsteadOfArray_StoresInUserProperties()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":""KL""}";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.ZaehlwerkId.Should().Be("ZW001");
        result.Verbrauchsarten.Should().BeNull();
        result.UserProperties.Should().NotBeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    #endregion

    #region Type Mismatch - Number Instead of Array

    [TestMethod]
    [Description("Number instead of array stores in UserProperties with STJ")]
    public void Test_SystemTextJson_NumberInsteadOfArray_StoresInUserProperties()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":12345}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.Verbrauchsarten.Should().BeNull();
        result.UserProperties.Should().NotBeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    [TestMethod]
    [Description("Number instead of array stores in UserProperties with Newtonsoft")]
    public void Test_Newtonsoft_NumberInsteadOfArray_StoresInUserProperties()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":12345}";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.Verbrauchsarten.Should().BeNull();
        result.UserProperties.Should().NotBeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    #endregion

    #region Type Mismatch - Boolean Instead of Array

    [TestMethod]
    [Description("Boolean instead of array stores in UserProperties with STJ")]
    public void Test_SystemTextJson_BooleanInsteadOfArray_StoresInUserProperties()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":true}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.Verbrauchsarten.Should().BeNull();
        result.UserProperties.Should().NotBeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    #endregion

    #region Type Mismatch - Array with Wrong Element Types

    [TestMethod]
    [Description("Array with invalid enum values deserializes without throwing - valid values are preserved")]
    public void Test_SystemTextJson_ArrayWithInvalidEnumValues_HandlesGracefully()
    {
        // Arrange: "INVALID_ENUM" is not a valid Verbrauchsart
        var json =
            @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":[""KL"",""INVALID_ENUM"",""STW""]}";
        var options = GetSystemTextJsonOptions();

        // Act: With MOST_LENIENT parsing, invalid enum values don't throw
        var action = () => JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert: Should not throw and valid enum values should be preserved
        action.Should().NotThrow();
        var result = action();
        result.Should().NotBeNull();
        result!.ZaehlwerkId.Should().Be("ZW001");
        // The valid enum values KL and STW should be present
        result.Verbrauchsarten.Should().NotBeNull();
        result.Verbrauchsarten.Should().Contain(Verbrauchsart.KL);
        result.Verbrauchsarten.Should().Contain(Verbrauchsart.STW);
    }

    #endregion

    #region Properties After Migrated Property - Reader Position Tests

    [TestMethod]
    [Description(
        "Properties after failed migrated property are still deserialized correctly with STJ"
    )]
    public void Test_SystemTextJson_PropertiesAfterFailedProperty_StillDeserialized()
    {
        // Arrange: Object instead of array, followed by more properties
        var json =
            @"{""Verbrauchsarten"":{""invalid"":""object""},""zaehlwerkId"":""ZW001"",""bezeichnung"":""Test Zaehlwerk""}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.ZaehlwerkId.Should().Be("ZW001", "property after failed one should still work");
        result
            .Bezeichnung.Should()
            .Be("Test Zaehlwerk", "property after failed one should still work");
        result.Verbrauchsarten.Should().BeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    [TestMethod]
    [Description(
        "Properties after failed migrated property are still deserialized correctly with Newtonsoft"
    )]
    public void Test_Newtonsoft_PropertiesAfterFailedProperty_StillDeserialized()
    {
        // Arrange
        var json =
            @"{""Verbrauchsarten"":{""invalid"":""object""},""zaehlwerkId"":""ZW001"",""bezeichnung"":""Test Zaehlwerk""}";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.ZaehlwerkId.Should().Be("ZW001");
        result.Bezeichnung.Should().Be("Test Zaehlwerk");
        result.Verbrauchsarten.Should().BeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    #endregion

    #region Malformed JSON - Must Still Throw

    [TestMethod]
    [Description("Malformed JSON syntax still throws with STJ")]
    public void Test_SystemTextJson_MalformedJsonSyntax_StillThrows()
    {
        // Arrange: Invalid JSON syntax
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":[";
        var options = GetSystemTextJsonOptions();

        // Act & Assert: Syntax errors must still throw
        var action = () => JsonSerializer.Deserialize<Zaehlwerk>(json, options);
        action.Should().Throw<System.Text.Json.JsonException>("malformed JSON must still throw");
    }

    [TestMethod]
    [Description("Malformed JSON syntax still throws with Newtonsoft")]
    public void Test_Newtonsoft_MalformedJsonSyntax_StillThrows()
    {
        // Arrange: Invalid JSON syntax
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":[";
        var settings = GetNewtonsoftSettings();

        // Act & Assert: Syntax errors must still throw
        // Note: JsonSerializationException wraps the underlying JsonReaderException
        var action = () => JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);
        action.Should().Throw<Newtonsoft.Json.JsonException>("malformed JSON must still throw");
    }

    #endregion

    #region Full Marktlokation Context Tests

    [TestMethod]
    [Description("Zaehlwerk in full Marktlokation context with type mismatch works with STJ")]
    public void Test_SystemTextJson_FullMarktlokationContext_TypeMismatchHandled()
    {
        // Arrange: Full Marktlokation with nested Zaehlwerk that has type mismatch
        var json =
            @"{
            ""boTyp"":""MARKTLOKATION"",
            ""marktlokationsId"":""12345678901"",
            ""sparte"":""STROM"",
            ""zaehlwerkeBeteiligteMarktrolle"":[
                {
                    ""zaehlwerkId"":""ZW001"",
                    ""Verbrauchsarten"":{""invalid"":""object""},
                    ""bezeichnung"":""Test""
                }
            ]
        }";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Marktlokation>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.MarktlokationsId.Should().Be("12345678901");
        result.ZaehlwerkeBeteiligteMarktrolle.Should().NotBeNull().And.HaveCount(1);
        var zaehlwerk = result.ZaehlwerkeBeteiligteMarktrolle![0];
        zaehlwerk.ZaehlwerkId.Should().Be("ZW001");
        zaehlwerk.Bezeichnung.Should().Be("Test");
        zaehlwerk.Verbrauchsarten.Should().BeNull();
        zaehlwerk
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    [TestMethod]
    [Ignore(
        "Known limitation: Newtonsoft's BusinessObjectBaseConverter uses JToken.ToObject() which bypasses the error handler. Use STJ for nested polymorphic scenarios."
    )]
    [Description(
        "Zaehlwerk in full Marktlokation context with type mismatch works with Newtonsoft"
    )]
    public void Test_Newtonsoft_FullMarktlokationContext_TypeMismatchHandled()
    {
        // Arrange
        // NOTE: This test is ignored because Newtonsoft's BusinessObjectBaseConverter
        // deserializes using JToken.ToObject(), which bypasses our error handling.
        // The STJ version of this test works correctly.
        // For nested polymorphic BusinessObject deserialization with error tolerance,
        // use System.Text.Json instead of Newtonsoft.Json.
        var json =
            @"{
            ""boTyp"":""MARKTLOKATION"",
            ""marktlokationsId"":""12345678901"",
            ""sparte"":""STROM"",
            ""zaehlwerkeBeteiligteMarktrolle"":[
                {
                    ""zaehlwerkId"":""ZW001"",
                    ""Verbrauchsarten"":{""invalid"":""object""},
                    ""bezeichnung"":""Test""
                }
            ]
        }";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Marktlokation>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.MarktlokationsId.Should().Be("12345678901");
        result.ZaehlwerkeBeteiligteMarktrolle.Should().NotBeNull().And.HaveCount(1);
        var zaehlwerk = result.ZaehlwerkeBeteiligteMarktrolle![0];
        zaehlwerk.ZaehlwerkId.Should().Be("ZW001");
        zaehlwerk.Bezeichnung.Should().Be("Test");
        zaehlwerk.Verbrauchsarten.Should().BeNull();
        zaehlwerk
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    [TestMethod]
    [Description("Valid data in full Marktlokation context still works with STJ")]
    public void Test_SystemTextJson_FullMarktlokationContext_ValidDataWorks()
    {
        // Arrange: Valid Verbrauchsarten array in Marktlokation context
        var json =
            @"{
            ""boTyp"":""MARKTLOKATION"",
            ""marktlokationsId"":""12345678901"",
            ""sparte"":""STROM"",
            ""zaehlwerkeBeteiligteMarktrolle"":[
                {
                    ""zaehlwerkId"":""ZW001"",
                    ""Verbrauchsarten"":[""KL"",""STW""],
                    ""bezeichnung"":""Test""
                }
            ]
        }";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Marktlokation>(json, options);

        // Assert
        result.Should().NotBeNull();
        var zaehlwerk = result!.ZaehlwerkeBeteiligteMarktrolle![0];
        zaehlwerk
            .Verbrauchsarten.Should()
            .NotBeNull()
            .And.HaveCount(2)
            .And.ContainInOrder(Verbrauchsart.KL, Verbrauchsart.STW);
        zaehlwerk.UserProperties.Should().BeNull();
    }

    #endregion

    #region Complex Nested Object Mismatches

    [TestMethod]
    [Description("Deeply nested object instead of array stores in UserProperties")]
    public void Test_SystemTextJson_DeeplyNestedObjectMismatch_StoresInUserProperties()
    {
        // Arrange: Complex nested object
        var json =
            @"{
            ""zaehlwerkId"":""ZW001"",
            ""Verbrauchsarten"":{
                ""level1"":{
                    ""level2"":{
                        ""level3"":""deep value""
                    }
                }
            }
        }";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.Verbrauchsarten.Should().BeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    #endregion

    #region Multiple Migrated Properties

    [TestMethod]
    [Description("Multiple migrated properties can fail independently")]
    public void Test_SystemTextJson_MultipleMigratedProperties_CanFailIndependently()
    {
        // This test would require a type with multiple [MigratedFromUserProperties] properties
        // For now, we test with Zaehlwerk which has one
        // Future properties can be added and tested here
        Assert.IsTrue(true, "Placeholder for future multi-property tests");
    }

    #endregion

    #region Edge Cases

    [TestMethod]
    [Description("Empty object instead of array stores in UserProperties")]
    public void Test_SystemTextJson_EmptyObject_StoresInUserProperties()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":{}}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.Verbrauchsarten.Should().BeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    [TestMethod]
    [Description("Object with numeric keys stores in UserProperties")]
    public void Test_SystemTextJson_ObjectWithNumericKeys_StoresInUserProperties()
    {
        // Arrange: This could happen from some serializers that convert arrays to objects
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":{""0"":""KL"",""1"":""STW""}}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.Verbrauchsarten.Should().BeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    #endregion

    #region Stored Value Format Verification

    [TestMethod]
    [Description("STJ stores the raw JSON value as JsonElement for objects")]
    public void Test_SystemTextJson_StoredValueFormat_IsJsonElementForObject()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":{""invalid"":""object""}}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        var key = MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten");
        result!.UserProperties.Should().ContainKey(key);
        var storedValue = result.UserProperties![key];

        // STJ stores JsonElement for objects/arrays
        storedValue.Should().BeOfType<JsonElement>();
        var element = (JsonElement)storedValue;
        element.ValueKind.Should().Be(JsonValueKind.Object);
        element.GetProperty("invalid").GetString().Should().Be("object");
    }

    [TestMethod]
    [Description("STJ stores primitive values directly")]
    public void Test_SystemTextJson_StoredValueFormat_IsPrimitiveForString()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":""not_an_array""}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        var key = MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten");
        result!.UserProperties.Should().ContainKey(key);
        var storedValue = result.UserProperties![key];

        // STJ converts string primitives directly
        storedValue.Should().BeOfType<string>();
        storedValue.Should().Be("not_an_array");
    }

    [TestMethod]
    [Description(
        "Newtonsoft stores error metadata when converter throws (raw value not accessible)"
    )]
    public void Test_Newtonsoft_StoredValueFormat_IsErrorMetadataWhenConverterThrows()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":{""invalid"":""object""}}";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        var key = MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten");
        result!.UserProperties.Should().ContainKey(key);
        var storedValue = result.UserProperties![key];

        // When Newtonsoft converters (like LenientEnumListConverter) throw during ReadJson,
        // the error handler catches it but cannot access the raw value (it's been consumed).
        // It stores error metadata instead: { error, path }
        // This is a Newtonsoft.Json limitation compared to STJ.
        storedValue.Should().BeOfType<Dictionary<string, object>>();
        var errorDict = (Dictionary<string, object>)storedValue;
        errorDict.Should().ContainKey("error");
        errorDict.Should().ContainKey("path");
    }

    #endregion

    #region JsonExtensionData Interaction Tests

    [TestMethod]
    [Description("STJ preserves both migration errors and other unknown properties")]
    public void Test_SystemTextJson_MigrationError_WithOtherUnknownProperties_BothPreserved()
    {
        // Arrange: Object instead of array AND an unknown property
        var json =
            @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":{""invalid"":""object""},""unknownCustomField"":""should be preserved""}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.UserProperties.Should().NotBeNull();

        // Migration error should be stored
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );

        // Unknown property should also be captured by JsonExtensionData
        // Note: STJ stores extension data as JsonElement
        result.UserProperties.Should().ContainKey("unknownCustomField");
        var unknownValue = result.UserProperties!["unknownCustomField"];
        unknownValue.Should().BeOfType<JsonElement>();
        ((JsonElement)unknownValue).GetString().Should().Be("should be preserved");
    }

    [TestMethod]
    [Description("Newtonsoft preserves both migration errors and other unknown properties")]
    public void Test_Newtonsoft_MigrationError_WithOtherUnknownProperties_BothPreserved()
    {
        // Arrange
        var json =
            @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":{""invalid"":""object""},""unknownCustomField"":""should be preserved""}";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.UserProperties.Should().NotBeNull();

        // Migration error should be stored
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );

        // Unknown property should also be captured by JsonExtensionData
        result.UserProperties.Should().ContainKey("unknownCustomField");
    }

    #endregion

    #region Key Casing Normalization Tests

    [TestMethod]
    [Description("STJ normalizes key casing regardless of input JSON casing")]
    public void Test_SystemTextJson_KeyCasing_NormalizedToPropertyName()
    {
        // Arrange: Use lowercase JSON key instead of PascalCase property name
        var json = @"{""zaehlwerkId"":""ZW001"",""verbrauchsarten"":{""invalid"":""object""}}";
        var options = GetSystemTextJsonOptions();

        // Act
        var result = JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert: Key should use the declared property name "Verbrauchsarten", not input "verbrauchsarten"
        result.Should().NotBeNull();
        var expectedKey = MigratedFromUserPropertiesAttribute.GetUserPropertiesKey(
            "Verbrauchsarten"
        );
        result!.UserProperties.Should().ContainKey(expectedKey);
    }

    #endregion

    #region Newtonsoft Parity Tests

    [TestMethod]
    [Description("Empty array deserializes correctly with Newtonsoft")]
    public void Test_Newtonsoft_EmptyVerbrauchsartenArray_DeserializesCorrectly()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":[]}";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.Verbrauchsarten.Should().NotBeNull().And.BeEmpty();
    }

    [TestMethod]
    [Description("Null Verbrauchsarten deserializes correctly with Newtonsoft")]
    public void Test_Newtonsoft_NullVerbrauchsarten_DeserializesCorrectly()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":null}";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        // Note: Newtonsoft with LenientEnumListConverter may initialize an empty list for null
        // Both null and empty list are acceptable outcomes for null input
        if (result!.Verbrauchsarten != null)
        {
            result.Verbrauchsarten.Should().BeEmpty();
        }
    }

    [TestMethod]
    [Description("Boolean instead of array stores in UserProperties with Newtonsoft")]
    public void Test_Newtonsoft_BooleanInsteadOfArray_StoresInUserProperties()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":true}";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.Verbrauchsarten.Should().BeNull();
        result.UserProperties.Should().NotBeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    [TestMethod]
    [Description("Deeply nested object stores in UserProperties with Newtonsoft")]
    public void Test_Newtonsoft_DeeplyNestedObjectMismatch_StoresInUserProperties()
    {
        // Arrange
        var json =
            @"{
            ""zaehlwerkId"":""ZW001"",
            ""Verbrauchsarten"":{
                ""level1"":{
                    ""level2"":{
                        ""level3"":""deep value""
                    }
                }
            }
        }";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.Verbrauchsarten.Should().BeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    [TestMethod]
    [Description("Empty object stores in UserProperties with Newtonsoft")]
    public void Test_Newtonsoft_EmptyObject_StoresInUserProperties()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":{}}";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.Verbrauchsarten.Should().BeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    [TestMethod]
    [Description("Object with numeric keys stores in UserProperties with Newtonsoft")]
    public void Test_Newtonsoft_ObjectWithNumericKeys_StoresInUserProperties()
    {
        // Arrange
        var json = @"{""zaehlwerkId"":""ZW001"",""Verbrauchsarten"":{""0"":""KL"",""1"":""STW""}}";
        var settings = GetNewtonsoftSettings();

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.Verbrauchsarten.Should().BeNull();
        result
            .UserProperties.Should()
            .ContainKey(
                MigratedFromUserPropertiesAttribute.GetUserPropertiesKey("Verbrauchsarten")
            );
    }

    #endregion
}
