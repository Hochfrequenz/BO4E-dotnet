using BO4E.COM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E;

[TestClass]
public class TestNotizDeserialization
{
    [TestMethod]
    public void TestMinusRemovalNewtonsoft()
    {
        var n = JsonConvert.DeserializeObject<Notiz>(
            "{\"klaerfallnummer\":\"468982\",\"autor\":\"Max Mustermann\",\"zeitpunkt\":\"2019-05-24T14:05:00Z\",\"inhalt\":\"hallo. das ist eine notiz mit einem lustigen emoji 🥝\n------------------------------------------------------------------------\",\"tdid\":\"0002\",\"tdname\":\"0000468982\",\"tdobject\":\"EMMA_CASE\"}");
        Assert.AreEqual("hallo. das ist eine notiz mit einem lustigen emoji 🥝", n.Inhalt);
    }

    [TestMethod]
    public void TestMinusRemoval()
    {
        var n = JsonSerializer.Deserialize<Notiz>(
            "{\"klaerfallnummer\":\"468982\",\"autor\":\"Max Mustermann\",\"zeitpunkt\":\"2019-05-24T14:05:00Z\",\"inhalt\":\"hallo. das ist eine notiz mit einem lustigen emoji 🥝\\n------------------------------------------------------------------------\",\"tdid\":\"0002\",\"tdname\":\"0000468982\",\"tdobject\":\"EMMA_CASE\"}");
        Assert.IsNotNull(n);
        Assert.AreEqual("hallo. das ist eine notiz mit einem lustigen emoji 🥝", n.Inhalt);
    }
}
