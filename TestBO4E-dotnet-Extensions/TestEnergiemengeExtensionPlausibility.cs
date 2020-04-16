using System;
using System.Collections.Generic;
using System.IO;

using BO4E.BO;
using BO4E.Extensions.BusinessObjects.Energiemenge;
using BO4E.Reporting;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace TestBO4EExtensions
{
    [TestClass]
    public class TestEnergiemengeExtensionPlausibility
    {

        [TestMethod]
        public void TestPlausibilityReportGenerationSomeCustomer()
        {
            foreach (string boFile in Directory.GetFiles("Energiemenge/plausibility", "somecustomer*.json"))
            {
                JObject json;
                using (StreamReader r = new StreamReader(boFile))
                {
                    string jsonString = r.ReadToEnd();
                    json = JsonConvert.DeserializeObject<JObject>(jsonString);
                }
                foreach (var key in new HashSet<string> { "reference", "other", "expectedResult" })
                {
                    if (!json.ContainsKey(key))
                    {
                        throw new ArgumentException($"Test file {boFile} has no key '{key}'.");
                    }
                }
                Energiemenge emReference = JsonConvert.DeserializeObject<Energiemenge>(JsonConvert.SerializeObject(json["reference"], new IsoDateTimeConverter()));
                Energiemenge emOther = JsonConvert.DeserializeObject<Energiemenge>(JsonConvert.SerializeObject(json["other"], new IsoDateTimeConverter()));

                PlausibilityReport prActual = emReference.GetPlausibilityReport(emOther);
                PlausibilityReport prExpected = JsonConvert.DeserializeObject<PlausibilityReport>(JsonConvert.SerializeObject(json["expectedResult"], new IsoDateTimeConverter()));
                //Assert.AreEqual(prExpected, prActual);
            }
        }
    }
}