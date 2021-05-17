using System;
using System.Collections.Generic;
using BO4E.BO;
using BO4E.meta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4E
{
    [TestClass]
    public class TestMultiLangJson
    {
        [TestMethod]
        public void TestContractResolverSerialization()
        {
            var mlb = new MultiLangBo
            {
                DatumDeutsch = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero),
                WertDeutsch = "Hallo Welt"
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

            var dEjson = JsonConvert.SerializeObject(mlb);
            Assert.IsFalse(dEjson.Contains("date_english"));
            Assert.IsFalse(dEjson.Contains("value_english"));
            Assert.IsTrue(dEjson.Contains(nameof(MultiLangBo.DatumDeutsch)));
            Assert.IsTrue(dEjson.Contains(nameof(MultiLangBo.WertDeutsch)));
        }

        [TestMethod]
        public void TestNestedContractResolverSerialization()
        {
            var mlb = new MultiLangBo
            {
                DatumDeutsch = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero),
                WertDeutsch = "Hallo Welt",
                Intern = new NestedObject
                {
                    BoolDeutsch = true,
                    InternDeutsch = "Hallo",
                    IntDeutsch = 33
                },
                InternList = new List<NestedObject>
                {
                    new NestedObject {BoolDeutsch = false, IntDeutsch = 10, InternDeutsch = "internalList1"},
                    new NestedObject {BoolDeutsch = false, IntDeutsch = 35, InternDeutsch = "internalList2"},
                    new NestedObject {BoolDeutsch = true, IntDeutsch = 1200, InternDeutsch = "internalList3"}
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

            var deJson = JsonConvert.SerializeObject(mlb);
            Assert.IsFalse(deJson.Contains("date_english"));
            Assert.IsFalse(deJson.Contains("value_english"));
            Assert.IsTrue(deJson.Contains(nameof(MultiLangBo.DatumDeutsch)));
            Assert.IsTrue(deJson.Contains(nameof(MultiLangBo.WertDeutsch)));
            Assert.IsTrue(deJson.Contains(nameof(MultiLangBo.InternList)));
            Assert.IsTrue(deJson.Contains(nameof(NestedObject.InternDeutsch)));
            Assert.IsFalse(deJson.Contains("internal_english"));

            var ml = JsonConvert.DeserializeObject<MultiLangBo>(deJson);
            Assert.AreNotEqual(DateTime.MinValue, ml.DatumDeutsch.UtcDateTime);
        }

        public class NestedObject
        {
            [FieldName("bool_english", Language.EN)]
            public bool BoolDeutsch;

            [FieldName("int_english", Language.EN)]
            public int IntDeutsch;

            [FieldName("internal_english", Language.EN)]
            public string InternDeutsch;
        }

        public class MultiLangBo : BusinessObject
        {
            [FieldName("date_english", Language.EN)]
            public DateTimeOffset DatumDeutsch;

            [FieldName("internal Object", Language.EN)]
            public NestedObject Intern;

            [FieldName("internal Object List", Language.EN)]
            public List<NestedObject> InternList;

            [FieldName("value_english", Language.EN)]
            public string WertDeutsch;
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