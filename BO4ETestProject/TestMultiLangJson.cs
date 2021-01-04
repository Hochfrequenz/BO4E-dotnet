using System;
using System.Collections.Generic;
using System.IO;
using BO4E.BO;
using BO4E.meta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestBO4E
{
    [TestClass]
    public class TestMultiLangJson
    {
        public class NestedObject
        {
            [FieldName("internal_english", Language.EN)]
            public string intern_deutsch;
            [FieldName("int_english", Language.EN)]
            public int int_deutsch;
            [FieldName("bool_english", Language.EN)]
            public bool bool_deutsch;
        }
        public class MultiLangBo : BusinessObject
        {
            [FieldName("date_english", Language.EN)]
            public DateTimeOffset datum_deutsch;
            [FieldName("value_english", Language.EN)]
            public string wert_deutsch;
            [FieldName("internal Object", Language.EN)]
            public NestedObject intern;
            [FieldName("internal Object List", Language.EN)]
            public List<NestedObject> internList;

        }

        [TestMethod]
        public void TestContractResolverSerialization()
        {
            var mlb = new MultiLangBo()
            {
                datum_deutsch = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero),
                wert_deutsch = "Hallo Welt"
            };
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new MultiLangResolver(Language.EN),
                Formatting = Formatting.Indented
            };
            var json = JsonConvert.SerializeObject(mlb, settings);

            Assert.IsTrue(json.Contains("date_english"));
            Assert.IsTrue(json.Contains("value_english"));
            Assert.IsFalse(json.Contains("datum_deutsch"));
            Assert.IsFalse(json.Contains("wert_deutsch"));

            var DEjson = JsonConvert.SerializeObject(mlb);
            Assert.IsFalse(DEjson.Contains("date_english"));
            Assert.IsFalse(DEjson.Contains("value_english"));
            Assert.IsTrue(DEjson.Contains("datum_deutsch"));
            Assert.IsTrue(DEjson.Contains("wert_deutsch"));
        }

        [TestMethod]
        public void TestNestedContractResolverSerialization()
        {
            var mlb = new MultiLangBo()
            {
                datum_deutsch = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero),
                wert_deutsch = "Hallo Welt",
                intern = new NestedObject()
                {
                    bool_deutsch = true,
                    intern_deutsch = "Hallo",
                    int_deutsch = 33
                },
                internList = new List<NestedObject>()
                {
                    new NestedObject(){bool_deutsch=false,int_deutsch=10,intern_deutsch="internalList1"},
                    new NestedObject(){bool_deutsch=false,int_deutsch=35,intern_deutsch="internalList2"},
                    new NestedObject(){bool_deutsch=true,int_deutsch=1200,intern_deutsch="internalList3"},
                }
            };
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new MultiLangResolver(Language.EN),
                Formatting = Formatting.Indented
            };
            var json = JsonConvert.SerializeObject(mlb, settings);

            Assert.IsTrue(json.Contains("date_english"));
            Assert.IsTrue(json.Contains("value_english"));
            Assert.IsFalse(json.Contains("datum_deutsch"));
            Assert.IsFalse(json.Contains("wert_deutsch"));
            Assert.IsTrue(json.Contains("internal Object List"));
            Assert.IsTrue(json.Contains("internal_english"));
            Assert.IsFalse(json.Contains("intern_deutsch"));

            var DEjson = JsonConvert.SerializeObject(mlb);
            Assert.IsFalse(DEjson.Contains("date_english"));
            Assert.IsFalse(DEjson.Contains("value_english"));
            Assert.IsTrue(DEjson.Contains("datum_deutsch"));
            Assert.IsTrue(DEjson.Contains("wert_deutsch"));
            Assert.IsTrue(DEjson.Contains("internList"));
            Assert.IsTrue(DEjson.Contains("intern_deutsch"));
            Assert.IsFalse(DEjson.Contains("internal_english"));

            var ml = JsonConvert.DeserializeObject<MultiLangBo>(DEjson);
            Assert.AreNotEqual(DateTime.MinValue, ml.datum_deutsch.UtcDateTime);
        }

        //[TestMethod]
        //public void TestRechnungFromSapPrintDocument()
        //{
        //    string[] files = Directory.GetFiles("TariffMediationTests/sapPrintDocuments/", "*.json"); // there is not
        //    foreach (string file in files)
        //    {
        //        JObject sapPrintDocument;
        //        using (StreamReader r = new StreamReader(file))
        //        {
        //            string jsonString = r.ReadToEnd();
        //            sapPrintDocument = JObject.Parse(jsonString);
        //        }
        //        Rechnung rechnung = new Rechnung(sapPrintDocument);
        //        var settings = new JsonSerializerSettings
        //        {
        //            ContractResolver = new MultiLangResolver(Language.EN),
        //            Formatting = Formatting.Indented
        //        };
        //        var json = JsonConvert.SerializeObject(rechnung, settings);
        //    }
        //}

    }
}