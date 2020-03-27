using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using BO4E.BO;
using BO4E.meta;

using JsonDiffPatchDotNet;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestBO4E
{
    [TestClass]
    public class TestBo4eURI
    {
        [TestMethod]
        public void TestUriConstructionAndKeyDeconstruction()
        {
            string[] files = Directory.GetFiles($"bo4eURITests/", "*.json");
            foreach (string file in files)
            {
                JObject json;
                using (StreamReader r = new StreamReader(file))
                {
                    string jsonString = r.ReadToEnd();
                    json = JsonConvert.DeserializeObject<JObject>(jsonString);
                }
                Assert.IsNotNull(json, $"The content of file {file} seems to be no valid JSON.");
                Assert.IsNotNull(json["input"], $"The file {file} does not contain the mandatory 'input' key.");
                Assert.IsNotNull(json["expectedUri"], $"The file {file} does not contain the mandatory 'expectedUri' key.");
                //string boType = (string)json["input"]["boTyp"];
                //Assert.IsNotNull(boType, $"The JSON content of file {file} is missing the obligatory 'boTyp' attribute.");
                BusinessObject bo = JsonConvert.DeserializeObject<BusinessObject>(json["input"].ToString());
                Assert.IsNotNull(bo, $"The business object in file {file} is not a valid BO4E.");

                Bo4eUri uri = Bo4eUri.GetUri(bo);
                string uriString = uri.AbsoluteUri;
                Assert.AreEqual(json["expectedUri"], uriString, "The URI doesn't match the expectations.");

                Assert.IsNotNull(json["expectedQueryObject"], $"Please specify the query object result in file {file}, key 'expectedQueryObject'.");
                JObject queryObject = uri.GetQueryObject();
                var jdp = new JsonDiffPatch();
                JToken left = json["expectedQueryObject"];
                JToken right = queryObject;
                var patch = jdp.Diff(left, right);
                if (patch != null)
                {
                    Assert.IsNull(patch, patch.ToString());
                }
                else
                {
                    Assert.IsNull(patch); // witzlos.
                }
            }
        }

        [TestMethod]
        public void TestEmptyUriQueryObject()
        {
            var uri = new Bo4eUri("bo4e://Energiemenge");
            bool exceptionThrown = false;
            string result = String.Empty;
            try
            {
                result = uri.GetQueryObject().ToString();
            }
            catch (Exception)
            {
                // must not happen!
                exceptionThrown = true;
            }
            Assert.IsFalse(exceptionThrown);
            Assert.IsTrue(result.Contains("ENERGIEMENGE"));
        }

        [TestMethod]
        public void TestWellformedKannmichmal()
        {
            var uri = new Bo4eUri("bo4e://messlokation/?filter=bilanzierungsmethode eq 'RLM'or bilanzierungsmethode eq 'IMS'");
            Assert.IsNotNull(uri);
        }

        private static readonly Dictionary<string, string> boNameResults = new Dictionary<string, string>()
        {
            {"bo4e://Marktlokation/987654321098", "Marktlokation" },
            {"bo4e://hurzelasdanoafi/123456", null},
            {"bo4e://Energiemenge/123456", "Energiemenge"},
            {"bo4e://Ansprechpartner/123467/adsadad/aafe4rq3rqr/", "Ansprechpartner"},
            {"bo4e://ansprechpartner/mitlowercase/", "Ansprechpartner"},
            {"bo4e://MaRkTLoKaTiOn/mitlowercase/", "Marktlokation"},
            {"bo4e://Marktlokation/?backendId=10000001308", "Marktlokation"}
        };

        [TestMethod]
        public void TestBoNamesAndTypes()
        {
            foreach (string testString in boNameResults.Keys)
            {
                try
                {
                    Bo4eUri uri = new Bo4eUri(testString);
                    Assert.AreEqual(boNameResults[testString], uri.GetBoName(), $"boName validation failed for {testString}.");
                    Assert.IsTrue(uri.GetBoType().ToString().EndsWith(boNameResults[testString]));
                }
                catch (ArgumentException)
                {
                    Assert.IsNull(boNameResults[testString]);
                }
            }
        }

        private static readonly Dictionary<Type, List<string>> boKeyNamesResults = new Dictionary<Type, List<string>>()
        {
            {typeof(Marktlokation), new List<string>{"marktlokationsId"}},
            {typeof(Messlokation), new List<string>{"messLokationsId"} } //<-- should be the json property name if annotated 
        };

        [TestMethod]
        public void TestBoKeyNames()
        {
            foreach (Type boType in boKeyNamesResults.Keys)
            {
                List<string> expectedList = boKeyNamesResults[boType];
                List<string> actualList = BusinessObject.GetBoKeyNames(boType);
                Assert.IsTrue(expectedList.SequenceEqual(actualList), $"{boType.ToString()}: expected: [{String.Join(",", expectedList)}] actual: [{String.Join(",", actualList)}] ");
            }
        }

        private static readonly Dictionary<string, bool> validationResults = new Dictionary<string, bool>()
        {
            {"bo4e://Marktlokation/987654321098", true },
           // {"   bo4e://Leerzeichen/987654321098", false },
            {"keinProtokoll/123456", false},
            {"falschesProtokoll://asdadadl/123456", false},
            {"bo4e://Marktlokation/123467/adsadad/aafe4rq3rqr/",true},
            {"bo4e://kf56@Marktlokation:100/adadsadad", true },
            {"bo4e://kf56:pw@Marktlokation:100/adadsadad?dasd=asd", true },
            {"bo4e://Marktlokation/123467/adsadad/aafe4rq3rqr?asdasda=3r343&adasdas=2334#341", true },
            {"bo4e://Marktteilnehmer/?backendId=1234", true },
        };

        [TestMethod]
        public void TestValidity()
        {
            foreach (string testString in validationResults.Keys)
            {
                Assert.AreEqual(validationResults[testString], Bo4eUri.IsValid(testString), $"URI validation failed for {testString} .");
            }
        }

        [TestMethod]
        public void TestUPInclusion()
        {
            string emString = @"{'versionStruktur':1,'boTyp':'ENERGIEMENGE','lokationsId':'DE0000000000000000000000010000400','lokationstyp':'MeLo','zw':'000000000030000301','anlagennummer':'4000000199','messlokationsId':'DE0000000000000000000000010000400','marktlokationsId':''}";
            Energiemenge em = JsonConvert.DeserializeObject<Energiemenge>(emString);
            Assert.IsNotNull(em.UserProperties);
            Assert.IsTrue(em.UserProperties.Keys.Count > 0);
            Bo4eUri uri = em.GetURI(true);
            Assert.IsTrue(uri.ToString().Contains("messlokationsId="));
            Assert.IsTrue(uri.ToString().Contains("anlagennummer=4000000199"));
        }

        [TestMethod]
        public void TestRoundTripUriFilterQueryObject()
        {
            JObject qo = JObject.Parse("{'marktlokationsId':'543212345', 'messlokationsId':'DE123', 'bilanzierungsmethode':'SLP'}");
            Bo4eUri uri = (new Bo4eUri("bo4e://marktlokation?search=something")).AddFilter(JsonConvert.DeserializeObject<IDictionary<string, object>>(qo.ToString()));
            Assert.IsNotNull(uri);
            Assert.AreEqual("bo4e://marktlokation/?search=something&filter=marktlokationsId+eq+%27543212345%27+and+bilanzierungsmethode+eq+%27SLP%27", uri.ToString());
            JObject qo2 = uri.GetQueryObject();
            Assert.IsTrue(qo2.ContainsKey("marktlokationsId"));
            Assert.IsTrue(qo2.ContainsKey("bilanzierungsmethode"));
            Assert.AreEqual("543212345", qo2.GetValue("marktlokationsId"));
            Assert.AreEqual("SLP", qo2.GetValue("bilanzierungsmethode"));
        }

        [TestMethod]
        public void TestRLMFilter()
        {
            Bo4eUri uri = new Bo4eUri("bo4e://marktlokation?filter=bilanzierungsmethode%20%3D%20%27RLM%27");
            JObject query = uri.GetQueryObject();
            Assert.IsTrue(query.ContainsKey("bilanzierungsmethode"));
        }

        [TestMethod]
        public void TestKlaerfallQueryObject()
        {
            /*
            Bo4eUri uri1 = new Bo4eUri("bo4e://benachrichtigung/?filter=kategorie eq%20'ZE01' and erstellungsZeitpunkt eq '20190501142511'");
            var queryObject1 = uri1.GetQueryObject();
            Assert.IsTrue(queryObject1.ContainsKey("erstellungsZeitpunkt"));
            Assert.IsTrue(queryObject1.ContainsKey("kategorie"));
            */
            /*
            Bo4eUri uri2 = new Bo4eUri("bo4e://benachrichtigung/?filter=kategorie eq 'ZE01' and erstellungsZeitpunkt lt '20190501142511'");
            var queryObject2 = uri2.GetQueryObject();
            Assert.IsTrue(queryObject2.ContainsKey("erstellungsZeitpunkt"));
            Assert.IsTrue(queryObject2.ContainsKey("kategorie"));
            */
        }

        [TestMethod]
        public void TestImplicitStringConversion()
        {
            Assert.IsTrue(ThisMethodOnlyAcceptsBo4eUri("bo4e://energiemenge?backendId=12345"));
        }

        private bool ThisMethodOnlyAcceptsBo4eUri(Bo4eUri uri)
        {
            return true;
        }
    }
}
