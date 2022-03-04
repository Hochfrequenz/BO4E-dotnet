using System;
using System.Collections.Generic;
using System.IO;
using BO4E.BO;
using BO4E.Extensions.BusinessObjects.Energiemenge;
using BO4E.Reporting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestBO4E.Extensions
{
    [TestClass]
    public class TestEnergiemengeExtensionPlausibility
    {
        [TestMethod]
        public void TestPlausibilityReportGenerationSomeCustomer()
        {
            foreach (var boFile in Directory.GetFiles("Energiemenge/plausibility", "somecustomer*.json"))
            {
                JObject json;
                using (var r = new StreamReader(boFile))
                {
                    var jsonString = r.ReadToEnd();
                    json = JsonConvert.DeserializeObject<JObject>(jsonString);
                }

                foreach (var key in new HashSet<string> { "reference", "other", "expectedResult" })
                    if (!json.ContainsKey(key))
                        throw new ArgumentException($"Test file {boFile} has no key '{key}'.");
                var emReference = JsonConvert.DeserializeObject<Energiemenge>(json["reference"].ToString());
                var emOther = JsonConvert.DeserializeObject<Energiemenge>(json["other"].ToString());

                var prActual = emReference.GetPlausibilityReport(emOther);
                var prExpected = JsonConvert.DeserializeObject<PlausibilityReport>(json["expectedResult"].ToString());
                //Assert.AreEqual(prExpected, prActual);
            }
        }
    }
}