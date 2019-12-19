using System;
using System.Collections.Generic;
using System.IO;
using BO4E;
using BO4E.BO;
using JsonDiffPatchDotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestBO4E
{
    [TestClass]
    public class TestBoEdiMapper
    {
        private Dictionary<string, Dictionary<string, string>> expectedResults = new Dictionary<string, Dictionary<string, string>>();
        public TestBoEdiMapper()
        {
            // all in all very similar to EdiBoMapper...
            expectedResults.Add("Netzebene", new Dictionary<string, string>() {
                {"NSP", "E06"}, // BO4E -> EDI (power)
                {"E05", "E05"}, // EDI preserving
                {"MD", "Y02" }, // EDI -> BO4E (gas)
            });
            expectedResults.Add("Zaehlerauspraegung", new Dictionary<string, string>() {
                {"EINRICHTUNGSZAEHLER", "ERZ"},
                {"ZWEIRICHTUNGSZAEHLER", "ZRZ"}
            });
            expectedResults.Add("Rollencodetyp", new Dictionary<string, string>() {
                {"BDEW", "293"},
                {"DVGW", "332"}
            });
            expectedResults.Add("Landescode", new Dictionary<string, string>() {
                {"DE", "DE"},
                {"AT", "AT"}
            });
            expectedResults.Add("Wertermittlungsverfahren", new Dictionary<string, string>() {
                {"MESSUNG", "220"}
            });
        }
        [TestMethod]
        public void TestSimpleEnums()
        {
            foreach (string objectName in expectedResults.Keys)
            {
                Dictionary<string, string> map = expectedResults[objectName];
                foreach (string teststring in map.Keys)
                {
                    string expectedResult = map[teststring];
                    //BO4E.StaticLogger.Logger = new Microsoft.Extensions.Logging.Debug.DebugLogger("Testlogger", (log, level) => { return true; });
                    string result = BoEdiMapper.ToEdi(objectName, teststring);
                    Assert.AreEqual(expectedResult, result);
                }
            }
        }

        [TestMethod]
        public void TestNullStuff()
        {
            string result = BoEdiMapper.ToEdi("Landescode", null);
            Assert.IsNull(result);

            result = BoEdiMapper.ToEdi("Rollencodetyp", "0");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestBoEdiReplacement()
        {
            string[] files = Directory.GetFiles($"BoEdiMapper/", "*.json");
            foreach (string file in files)
            {
                JObject json;
                using (StreamReader r = new StreamReader(file))
                {
                    string jsonString = r.ReadToEnd();
                    json = JsonConvert.DeserializeObject<JObject>(jsonString);
                }
                Assert.IsNotNull(json["input"], $"You have to specify an 'input' in test file {file}");
                Assert.IsNotNull(json["expectedResult"], $"You have to specify an 'expectedOutput' in test file {file}");
                BusinessObject bo;
                try
                {
                    bo = JsonConvert.DeserializeObject<BusinessObject>(json["input"].ToString());
                }
                catch (ArgumentException)
                {
                    bo = BoMapper.MapObject(json["input"]["boTyp"].ToString(), (JObject)json["input"]);
                }
                JObject result = BoEdiMapper.ReplaceWithEdiValues(bo);
                //JObject result = JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(, new StringEnumConverter()));
                var jdp = new JsonDiffPatch();
                JToken left, right;
                left = JsonHelper.RemoveEmptyChildren(json["expectedResult"]);
                right = JsonHelper.RemoveEmptyChildren(result);
                var patch = jdp.Diff(left, right);
                string additionalMessage = string.Empty;
                if (patch != null)
                {
                    additionalMessage = $";\r\n Diff: { patch.ToString()}";
                }
                Assert.IsNull(patch, additionalMessage);
            }
        }
    }
}
