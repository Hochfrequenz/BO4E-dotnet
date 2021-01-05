using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4E
{
    /// <summary>
    /// This class is just used to create a .resx file containing a serialized TimeZoneInfo object.
    /// Details: https://docs.microsoft.com/en-us/dotnet/standard/datetime/save-time-zones-to-an-embedded-resource
    /// </summary>
    [TestClass]
    public class CreateTimeZoneJson
    {
        public static readonly string resxName = "western_europe_standard_time.resx";

        [TestMethod]
        public void SerializeAsJson()
        {
            TimeZoneInfo tzi;
            try
            {
                tzi = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
            }
            catch (TimeZoneNotFoundException)
            {
                //Assert.IsTrue(false, "You cannot use this method on your machine."); // this occurs in github actions. it's ok.
                return;
            }
            Assert.IsTrue(tzi.SupportsDaylightSavingTime);
            var json = JsonConvert.SerializeObject(tzi);
            Console.WriteLine(json);
        }
    }
}
