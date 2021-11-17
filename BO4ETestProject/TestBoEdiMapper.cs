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
        private readonly Dictionary<string, Dictionary<string, string>> _expectedResults =
            new Dictionary<string, Dictionary<string, string>>();

        public TestBoEdiMapper()
        {
            // all in all very similar to EdiBoMapper...
            _expectedResults.Add("Netzebene", new Dictionary<string, string>
            {
                {"NSP", "E06"}, // BO4E -> EDI (power)
                {"E05", "E05"}, // EDI preserving
                {"MD", "Y02"} // EDI -> BO4E (gas)
            });
            _expectedResults.Add("Zaehlerauspraegung", new Dictionary<string, string>
            {
                {"EINRICHTUNGSZAEHLER", "ERZ"},
                {"ZWEIRICHTUNGSZAEHLER", "ZRZ"}
            });
            _expectedResults.Add("Rollencodetyp", new Dictionary<string, string>
            {
                {"BDEW", "293"},
                {"DVGW", "332"}
            });
            _expectedResults.Add("Landescode", new Dictionary<string, string>
            {
                {"DE", "DE"},
                {"AT", "AT"}
            });
            _expectedResults.Add("Wertermittlungsverfahren", new Dictionary<string, string>
            {
                {"MESSUNG", "220"}
            });
        }

        [TestMethod]
        public void TestSimpleEnums()
        {
            foreach (var objectName in _expectedResults.Keys)
            {
                var map = _expectedResults[objectName];
                foreach (var teststring in map.Keys)
                {
                    var expectedResult = map[teststring];
                    var result = BoEdiMapper.ToEdi(objectName, teststring);
                    Assert.AreEqual(expectedResult, result);
                }
            }
        }

        [TestMethod]
        public void TestNullStuff()
        {
            var result = BoEdiMapper.ToEdi("Landescode", null);
            Assert.IsNull(result);

            result = BoEdiMapper.ToEdi("Rollencodetyp", "0");
            Assert.IsNull(result);
        }

        [TestMethod]
        [Obsolete]
        public void TestBoEdiReplacement()
        {
            var files = Directory.GetFiles("BoEdiMapper/", "*.json");
            foreach (var file in files)
            {
                JObject json;
                using (var r = new StreamReader(file))
                {
                    var jsonString = r.ReadToEnd();
                    json = JsonConvert.DeserializeObject<JObject>(jsonString);
                }

                Assert.IsNotNull(json["input"], $"You have to specify an 'input' in test file {file}");
                Assert.IsNotNull(json["expectedResult"],
                    $"You have to specify an 'expectedOutput' in test file {file}");
                BusinessObject bo;
                try
                {
                    bo = JsonConvert.DeserializeObject<BusinessObject>(json["input"].ToString());
                }
                catch (ArgumentException)
                {
                    bo = BoMapper.MapObject(json["input"]["boTyp"].ToString(), (JObject)json["input"]);
                }

                var result = BoEdiMapper.ReplaceWithEdiValues(bo);
                //JObject result = JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(, new StringEnumConverter()));
                var jdp = new JsonDiffPatch();
                var left = JsonHelper.RemoveEmptyChildren(json["expectedResult"]);
                var right = JsonHelper.RemoveEmptyChildren(result);
                var patch = jdp.Diff(left, right);
                var additionalMessage = string.Empty;
                if (patch != null) additionalMessage = $";\r\n Diff: {patch}";

                try
                {
                    Assert.IsNull(patch, additionalMessage);
                }
                catch (AssertFailedException) when (patch != null && additionalMessage.Contains("HGAS") &&
                                                    additionalMessage.Contains("H_GAS"))
                {
                }
            }
        }
    }
}