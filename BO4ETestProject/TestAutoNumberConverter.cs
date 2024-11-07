using System.IO;
using BO4E.BO;
using BO4E.meta.LenientConverters;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E;

[TestClass]
public class TestAutoNumberConverter
{
    [TestMethod]
    public void TestConverter()
    {
        string jsonString;
        using (var r = new StreamReader("testjsons/vertrag_numeric_versionstruktur.json"))
        {
            jsonString = r.ReadToEnd();
        }

        var options = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();

        var vertrag = JsonSerializer.Deserialize<Vertrag>(jsonString, options);
        Assert.IsNotNull(vertrag);
    }

    [TestMethod]
    [DataRow("{\"versionStruktur\": \"12\"}")]
    [DataRow("{\"versionStruktur\": 12}")]
    public void Test_Annotation_STJ(string jsonString)
    {
        var malo = System.Text.Json.JsonSerializer.Deserialize<Marktlokation>(jsonString);
        malo.Should().NotBeNull().And.Subject.As<Marktlokation>().VersionStruktur.Should().Be("12");
    }
}
