using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AwesomeAssertions;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta.LenientConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4E;

/// <summary>
/// Tests for handling historic Verbrauchsarten data that was stored incorrectly as nested lists.
///
/// Background: In version 0.31.0, the Verbrauchsarten property didn't exist in the Zaehlwerk class.
/// Client data containing "Verbrauchsarten" was stored in UserProperties as a fallback.
/// The stored data has the format {"Verbrauchsarten": [[]]} - a list containing an empty list.
///
/// Now in version 0.45.1 with the Verbrauchsarten property present, deserialization fails because
/// the inner [] cannot be converted to a Verbrauchsart enum value.
/// </summary>
[TestClass]
public class TestLenientVerbrauchsartListConverter
{
    #region Bug Fix Verification Tests

    /// <summary>
    /// This test verifies that the fix handles the problematic historic data format with System.Text.Json.
    /// The JSON has Verbrauchsarten: [[]] which previously could not be deserialized to List&lt;Verbrauchsart&gt;.
    /// With the LenientSystemTextVerbrauchsartListConverter annotated on the property, this now works.
    /// </summary>
    [TestMethod]
    public void Test_Fix_SystemTextJson_NestedEmptyList()
    {
        // Arrange: Simulate historic data stored in database
        var json =
            @"{
            ""boTyp"": ""MARKTLOKATION"",
            ""marktlokationsId"": ""12345678901"",
            ""sparte"": ""STROM"",
            ""zaehlwerkeBeteiligteMarktrolle"": [
                {
                    ""Verbrauchsarten"": [[]]
                }
            ]
        }";

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new JsonStringEnumConverter());

        // Act: With the converter annotation on the property, this should now succeed
        var action = () =>
            System.Text.Json.JsonSerializer.Deserialize<Marktlokation>(json, options);

        // Assert: No exception should be thrown and the result should have an empty Verbrauchsarten list
        action.Should().NotThrow();
        var result = action();
        result.Should().NotBeNull();
        result!.ZaehlwerkeBeteiligteMarktrolle.Should().NotBeNull().And.HaveCount(1);
        result
            .ZaehlwerkeBeteiligteMarktrolle![0]
            .Verbrauchsarten.Should()
            .NotBeNull()
            .And.BeEmpty();
    }

    /// <summary>
    /// This test verifies that the fix handles the problematic historic data format with Newtonsoft.Json.
    /// The JSON has Verbrauchsarten: [[]] which previously could not be deserialized to List&lt;Verbrauchsart&gt;.
    /// With the LenientNewtonsoftVerbrauchsartListConverter annotated on the property, this now works.
    /// </summary>
    [TestMethod]
    public void Test_Fix_Newtonsoft_NestedEmptyList()
    {
        // Arrange: Simulate historic data stored in database
        var json =
            @"{
            ""boTyp"": ""MARKTLOKATION"",
            ""marktlokationsId"": ""12345678901"",
            ""sparte"": ""STROM"",
            ""zaehlwerkeBeteiligteMarktrolle"": [
                {
                    ""Verbrauchsarten"": [[]]
                }
            ]
        }";

        var settings = new JsonSerializerSettings
        {
            Converters = { new Newtonsoft.Json.Converters.StringEnumConverter() },
        };

        // Act: With the converter annotation on the property, this should now succeed
        var action = () => JsonConvert.DeserializeObject<Marktlokation>(json, settings);

        // Assert: No exception should be thrown and the result should have an empty Verbrauchsarten list
        action.Should().NotThrow();
        var result = action();
        result.Should().NotBeNull();
        result!.ZaehlwerkeBeteiligteMarktrolle.Should().NotBeNull().And.HaveCount(1);
        result
            .ZaehlwerkeBeteiligteMarktrolle![0]
            .Verbrauchsarten.Should()
            .NotBeNull()
            .And.BeEmpty();
    }

    #endregion

    #region System.Text.Json Converter Tests - Fix Verification

    [TestMethod]
    [DataRow(@"[[]]", new Verbrauchsart[] { }, DisplayName = "Empty nested list")]
    [DataRow(@"[[0]]", new[] { Verbrauchsart.KL }, DisplayName = "Nested list with int value")]
    [DataRow(
        @"[[], 0]",
        new[] { Verbrauchsart.KL },
        DisplayName = "Mixed: empty nested list and int"
    )]
    [DataRow(@"[""KL""]", new[] { Verbrauchsart.KL }, DisplayName = "Normal string value")]
    [DataRow(
        @"[[""KL""]]",
        new[] { Verbrauchsart.KL },
        DisplayName = "Nested list with string value"
    )]
    [DataRow(@"[0]", new[] { Verbrauchsart.KL }, DisplayName = "Normal int value")]
    [DataRow(
        @"[0, 1]",
        new[] { Verbrauchsart.KL, Verbrauchsart.KLW },
        DisplayName = "Multiple int values"
    )]
    [DataRow(@"[""STW""]", new[] { Verbrauchsart.STW }, DisplayName = "String enum member")]
    [DataRow(
        @"[[""STW""]]",
        new[] { Verbrauchsart.STW },
        DisplayName = "Nested string enum member"
    )]
    [DataRow(
        @"[[], ""KL"", [""STW""], 1]",
        new[] { Verbrauchsart.KL, Verbrauchsart.STW, Verbrauchsart.KLW },
        DisplayName = "Complex mixed"
    )]
    [DataRow(
        @"[[[], ""KL""]]",
        new[] { Verbrauchsart.KL },
        DisplayName = "Deeply nested with valid value"
    )]
    public void Test_SystemTextJson_LenientConverter_HandlesEdgeCases(
        string jsonValue,
        Verbrauchsart[] expected
    )
    {
        // Arrange
        var json = $@"{{""Verbrauchsarten"": {jsonValue}}}";
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new LenientSystemTextVerbrauchsartListConverter());
        options.Converters.Add(new JsonStringEnumConverter());

        // Act
        var result = System.Text.Json.JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result!.Verbrauchsarten.Should().NotBeNull().And.ContainInOrder(expected);
    }

    [TestMethod]
    public void Test_SystemTextJson_LenientConverter_HandlesNull()
    {
        // Arrange
        var json = @"{""Verbrauchsarten"": null}";
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new LenientSystemTextVerbrauchsartListConverter());

        // Act
        var result = System.Text.Json.JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result!.Verbrauchsarten.Should().BeNull();
    }

    [TestMethod]
    public void Test_SystemTextJson_FullMarktlokation_WithLenientConverter()
    {
        // Arrange: Full Marktlokation with problematic historic data
        var json =
            @"{
            ""boTyp"": ""MARKTLOKATION"",
            ""marktlokationsId"": ""12345678901"",
            ""sparte"": ""STROM"",
            ""zaehlwerkeBeteiligteMarktrolle"": [
                {
                    ""zaehlwerkId"": ""ZW1"",
                    ""Verbrauchsarten"": [[]]
                },
                {
                    ""zaehlwerkId"": ""ZW2"",
                    ""Verbrauchsarten"": [[""KL""], ""STW""]
                }
            ]
        }";

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new LenientSystemTextVerbrauchsartListConverter());
        options.Converters.Add(new JsonStringEnumConverter());

        // Act
        var result = System.Text.Json.JsonSerializer.Deserialize<Marktlokation>(json, options);

        // Assert
        result.Should().NotBeNull();
        result!.ZaehlwerkeBeteiligteMarktrolle.Should().NotBeNull().And.HaveCount(2);
        result.ZaehlwerkeBeteiligteMarktrolle![0].ZaehlwerkId.Should().Be("ZW1");
        result.ZaehlwerkeBeteiligteMarktrolle[0].Verbrauchsarten.Should().NotBeNull().And.BeEmpty();
        result.ZaehlwerkeBeteiligteMarktrolle[1].ZaehlwerkId.Should().Be("ZW2");
        result
            .ZaehlwerkeBeteiligteMarktrolle[1]
            .Verbrauchsarten.Should()
            .NotBeNull()
            .And.ContainInOrder(Verbrauchsart.KL, Verbrauchsart.STW);
    }

    #endregion

    #region Newtonsoft.Json Converter Tests - Fix Verification

    [TestMethod]
    [DataRow(@"[[]]", new Verbrauchsart[] { }, DisplayName = "Empty nested list")]
    [DataRow(@"[[0]]", new[] { Verbrauchsart.KL }, DisplayName = "Nested list with int value")]
    [DataRow(
        @"[[], 0]",
        new[] { Verbrauchsart.KL },
        DisplayName = "Mixed: empty nested list and int"
    )]
    [DataRow(@"[""KL""]", new[] { Verbrauchsart.KL }, DisplayName = "Normal string value")]
    [DataRow(
        @"[[""KL""]]",
        new[] { Verbrauchsart.KL },
        DisplayName = "Nested list with string value"
    )]
    [DataRow(@"[0]", new[] { Verbrauchsart.KL }, DisplayName = "Normal int value")]
    [DataRow(
        @"[0, 1]",
        new[] { Verbrauchsart.KL, Verbrauchsart.KLW },
        DisplayName = "Multiple int values"
    )]
    [DataRow(@"[""STW""]", new[] { Verbrauchsart.STW }, DisplayName = "String enum member")]
    [DataRow(
        @"[[""STW""]]",
        new[] { Verbrauchsart.STW },
        DisplayName = "Nested string enum member"
    )]
    [DataRow(
        @"[[], ""KL"", [""STW""], 1]",
        new[] { Verbrauchsart.KL, Verbrauchsart.STW, Verbrauchsart.KLW },
        DisplayName = "Complex mixed"
    )]
    [DataRow(
        @"[[[], ""KL""]]",
        new[] { Verbrauchsart.KL },
        DisplayName = "Deeply nested with valid value"
    )]
    public void Test_Newtonsoft_LenientConverter_HandlesEdgeCases(
        string jsonValue,
        Verbrauchsart[] expected
    )
    {
        // Arrange
        var json = $@"{{""Verbrauchsarten"": {jsonValue}}}";
        var settings = new JsonSerializerSettings
        {
            Converters =
            {
                new LenientNewtonsoftVerbrauchsartListConverter(),
                new Newtonsoft.Json.Converters.StringEnumConverter(),
            },
        };

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result!.Verbrauchsarten.Should().NotBeNull().And.ContainInOrder(expected);
    }

    [TestMethod]
    public void Test_Newtonsoft_LenientConverter_HandlesNull()
    {
        // Arrange
        var json = @"{""Verbrauchsarten"": null}";
        var settings = new JsonSerializerSettings
        {
            Converters = { new LenientNewtonsoftVerbrauchsartListConverter() },
        };

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result!.Verbrauchsarten.Should().BeNull();
    }

    [TestMethod]
    public void Test_Newtonsoft_FullMarktlokation_WithLenientConverter()
    {
        // Arrange: Full Marktlokation with problematic historic data
        var json =
            @"{
            ""boTyp"": ""MARKTLOKATION"",
            ""marktlokationsId"": ""12345678901"",
            ""sparte"": ""STROM"",
            ""zaehlwerkeBeteiligteMarktrolle"": [
                {
                    ""zaehlwerkId"": ""ZW1"",
                    ""Verbrauchsarten"": [[]]
                },
                {
                    ""zaehlwerkId"": ""ZW2"",
                    ""Verbrauchsarten"": [[""KL""], ""STW""]
                }
            ]
        }";

        var settings = new JsonSerializerSettings
        {
            Converters =
            {
                new LenientNewtonsoftVerbrauchsartListConverter(),
                new Newtonsoft.Json.Converters.StringEnumConverter(),
            },
        };

        // Act
        var result = JsonConvert.DeserializeObject<Marktlokation>(json, settings);

        // Assert
        result.Should().NotBeNull();
        result!.ZaehlwerkeBeteiligteMarktrolle.Should().NotBeNull().And.HaveCount(2);
        result.ZaehlwerkeBeteiligteMarktrolle![0].ZaehlwerkId.Should().Be("ZW1");
        result.ZaehlwerkeBeteiligteMarktrolle[0].Verbrauchsarten.Should().NotBeNull().And.BeEmpty();
        result.ZaehlwerkeBeteiligteMarktrolle[1].ZaehlwerkId.Should().Be("ZW2");
        result
            .ZaehlwerkeBeteiligteMarktrolle[1]
            .Verbrauchsarten.Should()
            .NotBeNull()
            .And.ContainInOrder(Verbrauchsart.KL, Verbrauchsart.STW);
    }

    #endregion

    #region Serialization Round-Trip Tests

    [TestMethod]
    public void Test_SystemTextJson_Serialization_WritesCorrectFormat()
    {
        // Arrange
        var zaehlwerk = new Zaehlwerk
        {
            ZaehlwerkId = "ZW1",
            Verbrauchsarten = new List<Verbrauchsart> { Verbrauchsart.KL, Verbrauchsart.STW },
        };

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new LenientSystemTextVerbrauchsartListConverter());
        options.Converters.Add(new JsonStringEnumConverter());

        // Act
        var json = System.Text.Json.JsonSerializer.Serialize(zaehlwerk, options);
        var deserialized = System.Text.Json.JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        deserialized!
            .Verbrauchsarten.Should()
            .NotBeNull()
            .And.ContainInOrder(Verbrauchsart.KL, Verbrauchsart.STW);
    }

    [TestMethod]
    public void Test_Newtonsoft_Serialization_WritesCorrectFormat()
    {
        // Arrange
        var zaehlwerk = new Zaehlwerk
        {
            ZaehlwerkId = "ZW1",
            Verbrauchsarten = new List<Verbrauchsart> { Verbrauchsart.KL, Verbrauchsart.STW },
        };

        var settings = new JsonSerializerSettings
        {
            Converters =
            {
                new LenientNewtonsoftVerbrauchsartListConverter(),
                new Newtonsoft.Json.Converters.StringEnumConverter(),
            },
        };

        // Act
        var json = JsonConvert.SerializeObject(zaehlwerk, settings);
        var deserialized = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        deserialized!
            .Verbrauchsarten.Should()
            .NotBeNull()
            .And.ContainInOrder(Verbrauchsart.KL, Verbrauchsart.STW);
    }

    #endregion

    #region Additional Edge Cases

    [TestMethod]
    public void Test_SystemTextJson_InvalidEnumValue_IsSkipped()
    {
        // Arrange: Contains an invalid enum value that should be skipped
        var json = @"{""Verbrauchsarten"": [""INVALID_VALUE"", ""KL""]}";
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new LenientSystemTextVerbrauchsartListConverter());
        options.Converters.Add(new JsonStringEnumConverter());

        // Act
        var result = System.Text.Json.JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert: Only the valid value should be present
        result!.Verbrauchsarten.Should().NotBeNull().And.ContainInOrder(Verbrauchsart.KL);
    }

    [TestMethod]
    public void Test_Newtonsoft_InvalidEnumValue_IsSkipped()
    {
        // Arrange: Contains an invalid enum value that should be skipped
        var json = @"{""Verbrauchsarten"": [""INVALID_VALUE"", ""KL""]}";
        var settings = new JsonSerializerSettings
        {
            Converters =
            {
                new LenientNewtonsoftVerbrauchsartListConverter(),
                new Newtonsoft.Json.Converters.StringEnumConverter(),
            },
        };

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert: Only the valid value should be present
        result!.Verbrauchsarten.Should().NotBeNull().And.ContainInOrder(Verbrauchsart.KL);
    }

    [TestMethod]
    public void Test_SystemTextJson_EmptyArray_ReturnsEmptyList()
    {
        // Arrange
        var json = @"{""Verbrauchsarten"": []}";
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new LenientSystemTextVerbrauchsartListConverter());

        // Act
        var result = System.Text.Json.JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result!.Verbrauchsarten.Should().NotBeNull().And.BeEmpty();
    }

    [TestMethod]
    public void Test_Newtonsoft_EmptyArray_ReturnsEmptyList()
    {
        // Arrange
        var json = @"{""Verbrauchsarten"": []}";
        var settings = new JsonSerializerSettings
        {
            Converters = { new LenientNewtonsoftVerbrauchsartListConverter() },
        };

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result!.Verbrauchsarten.Should().NotBeNull().And.BeEmpty();
    }

    [TestMethod]
    public void Test_SystemTextJson_OutOfRangeIntValue_IsSkipped()
    {
        // Arrange: Contains an out-of-range integer value
        var json = @"{""Verbrauchsarten"": [999, 0]}";
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new LenientSystemTextVerbrauchsartListConverter());

        // Act
        var result = System.Text.Json.JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert: Only the valid value should be present
        result!.Verbrauchsarten.Should().NotBeNull().And.ContainInOrder(Verbrauchsart.KL);
    }

    [TestMethod]
    public void Test_Newtonsoft_OutOfRangeIntValue_IsSkipped()
    {
        // Arrange: Contains an out-of-range integer value
        var json = @"{""Verbrauchsarten"": [999, 0]}";
        var settings = new JsonSerializerSettings
        {
            Converters = { new LenientNewtonsoftVerbrauchsartListConverter() },
        };

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert: Only the valid value should be present
        result!.Verbrauchsarten.Should().NotBeNull().And.ContainInOrder(Verbrauchsart.KL);
    }

    #endregion

    #region Tests with Converter Annotations

    [TestMethod]
    public void Test_SystemTextJson_WithConverterAnnotation_NoExplicitConverter()
    {
        // Arrange: Test that the converter works when applied via attribute
        var json =
            @"{
            ""zaehlwerkId"": ""ZW1"",
            ""Verbrauchsarten"": [[""KL""], ""STW""]
        }";

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        // Note: Not adding LenientSystemTextVerbrauchsartListConverter explicitly
        // The converter should be picked up from the attribute on the property
        options.Converters.Add(new JsonStringEnumConverter());

        // Act
        var result = System.Text.Json.JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert
        result!
            .Verbrauchsarten.Should()
            .NotBeNull()
            .And.ContainInOrder(Verbrauchsart.KL, Verbrauchsart.STW);
    }

    [TestMethod]
    public void Test_Newtonsoft_WithConverterAnnotation_NoExplicitConverter()
    {
        // Arrange: Test that the converter works when applied via attribute
        var json =
            @"{
            ""zaehlwerkId"": ""ZW1"",
            ""Verbrauchsarten"": [[""KL""], ""STW""]
        }";

        var settings = new JsonSerializerSettings
        {
            // Note: Not adding LenientNewtonsoftVerbrauchsartListConverter explicitly
            // The converter should be picked up from the attribute on the property
            Converters = { new Newtonsoft.Json.Converters.StringEnumConverter() },
        };

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert
        result!
            .Verbrauchsarten.Should()
            .NotBeNull()
            .And.ContainInOrder(Verbrauchsart.KL, Verbrauchsart.STW);
    }

    [TestMethod]
    public void Test_SystemTextJson_WithConverterAnnotation_Serialization()
    {
        // Arrange: Test that serialization works correctly when using attribute-based converter
        var zaehlwerk = new Zaehlwerk
        {
            ZaehlwerkId = "ZW1",
            Verbrauchsarten = new List<Verbrauchsart> { Verbrauchsart.KL, Verbrauchsart.STW },
        };

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        // NOT adding LenientSystemTextVerbrauchsartListConverter - using attribute
        options.Converters.Add(new JsonStringEnumConverter());

        // Act
        var json = System.Text.Json.JsonSerializer.Serialize(zaehlwerk, options);
        var deserialized = System.Text.Json.JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert: Verify round-trip works
        deserialized!
            .Verbrauchsarten.Should()
            .NotBeNull()
            .And.ContainInOrder(Verbrauchsart.KL, Verbrauchsart.STW);
    }

    [TestMethod]
    public void Test_Newtonsoft_WithConverterAnnotation_Serialization()
    {
        // Arrange: Test that serialization works correctly when using attribute-based converter
        var zaehlwerk = new Zaehlwerk
        {
            ZaehlwerkId = "ZW1",
            Verbrauchsarten = new List<Verbrauchsart> { Verbrauchsart.KL, Verbrauchsart.STW },
        };

        var settings = new JsonSerializerSettings
        {
            // NOT adding LenientNewtonsoftVerbrauchsartListConverter - using attribute
            Converters = { new Newtonsoft.Json.Converters.StringEnumConverter() },
        };

        // Act
        var json = JsonConvert.SerializeObject(zaehlwerk, settings);
        var deserialized = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert: Verify round-trip works
        deserialized!
            .Verbrauchsarten.Should()
            .NotBeNull()
            .And.ContainInOrder(Verbrauchsart.KL, Verbrauchsart.STW);
    }

    #endregion

    #region Tests for Object Skipping

    [TestMethod]
    public void Test_SystemTextJson_ObjectsInArray_AreSkipped()
    {
        // Arrange: Contains objects that should be skipped
        var json = @"{""Verbrauchsarten"": [{""nested"": ""object""}, ""KL"", {""another"": 123}]}";
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new LenientSystemTextVerbrauchsartListConverter());

        // Act
        var result = System.Text.Json.JsonSerializer.Deserialize<Zaehlwerk>(json, options);

        // Assert: Only the valid enum value should be present
        result!.Verbrauchsarten.Should().NotBeNull().And.ContainInOrder(Verbrauchsart.KL);
    }

    [TestMethod]
    public void Test_Newtonsoft_ObjectsInArray_AreSkipped()
    {
        // Arrange: Contains objects that should be skipped
        var json = @"{""Verbrauchsarten"": [{""nested"": ""object""}, ""KL"", {""another"": 123}]}";
        var settings = new JsonSerializerSettings
        {
            Converters = { new LenientNewtonsoftVerbrauchsartListConverter() },
        };

        // Act
        var result = JsonConvert.DeserializeObject<Zaehlwerk>(json, settings);

        // Assert: Only the valid enum value should be present
        result!.Verbrauchsarten.Should().NotBeNull().And.ContainInOrder(Verbrauchsart.KL);
    }

    #endregion
}
