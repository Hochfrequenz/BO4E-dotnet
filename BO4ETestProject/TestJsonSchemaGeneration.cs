using System;
using System.Linq;
using AwesomeAssertions;
using BO4E.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Schema;

namespace TestBO4E;

[TestClass]
public class TestJsonSchemaGeneration
{
    [TestMethod]
    public void BasicTest()
    {
        var melo = new Messlokation();
        var result = melo.GetJsonScheme().ToString();

        var em = new Energiemenge();
        result = em.GetJsonScheme().ToString();

        var result2 = BusinessObject.GetJsonSchema(typeof(Energiemenge)).ToString();
        Assert.AreEqual(result, result2);
    }

    [TestMethod]
    public void NegativeTest()
    {
        var gettingJsonSchemaOfIllegalType = () => BusinessObject.GetJsonSchema(typeof(string));
        gettingJsonSchemaOfIllegalType
            .Should()
            .Throw<ArgumentException>("Illegal types must result in a ArgumentException.");
    }

    private const int LastDataRowOffset = 50;
    private const int MaxSchemasPerHour = 10;

    [TestMethod]
    [DataRow(0)]
    [DataRow(10)]
    [DataRow(20)]
    [DataRow(30)]
    [DataRow(40)]
    [DataRow(LastDataRowOffset)] // using these different data rows allows you to workaround the 10schema per hour limitation (MaxSchemasPerHour)
    public void TestJSchemaFileGenerationBo(int offset)
    {
        var relevantBusinessObjectTypes = typeof(BusinessObject)
            .Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(BusinessObject)));
        relevantBusinessObjectTypes
            .Count()
            .Should()
            .BeLessThan(LastDataRowOffset + MaxSchemasPerHour); // if this fails, add another data row to this test method
        try // generate plain json schemas
        {
            foreach (var type in relevantBusinessObjectTypes.Skip(offset).Take(MaxSchemasPerHour))
            {
                var schema = BusinessObject.GetJsonSchema(type);
                Assert.IsNotNull(schema);
                // writing the schemas has moved to the SchemaGenerator project/generate-json-schemas.sh
            }
        }
        catch (JSchemaException jse)
        {
            Console.Out.WriteLine(jse.Message);
            // thats life. pay for it if you'd like to :P
        }
    }
}
