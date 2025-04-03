using System.Collections.Generic;
using System.Text.Json;
using BO4E.meta.LenientConverters;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E;

[TestClass]
public class LenientSystemTextJsonEnumListConverterTests
{
    [TestMethod]
    public void Test_Mehrmindermengenabrechnungslist()
    {
        var listConverter =
            new LenientSystemTextJsonEnumListConverter<
                List<BO4E.ENUM.Verwendungszweck>,
                BO4E.ENUM.Verwendungszweck
            >();
        var bareConverter = new SystemTextVerwendungszweckStringEnumConverter();
        var options = new JsonSerializerOptions { Converters = { listConverter, bareConverter } };
        var json = "[\"MEHRMINDERMENGENABRECHNUNG\",\"MEHRMINDERMBENGENABRECHNUNG\"]";
        var result = JsonSerializer.Deserialize<List<BO4E.ENUM.Verwendungszweck>>(json, options);
        result
            .Should()
            .NotBeNull()
            .And.ContainInOrder(
                BO4E.ENUM.Verwendungszweck.MEHRMINDERMENGENABRECHNUNG,
                BO4E.ENUM.Verwendungszweck.MEHRMINDERMENGENABRECHNUNG
            );
    }
}
