using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using BO4E;
using BO4E.BO;
using BO4E.COM;
using BO4E.Encryption;
using BO4E.ENUM;
using BO4E.meta;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E.Encryption.ShowCaseTests
{
    [TestClass]
    public class AnonymizerShowCaseTests
    {
        protected static readonly Energiemenge em = new Energiemenge
        {
            LokationsId = "DE0123456789012345678901234567890",
            LokationsTyp = Lokationstyp.MeLo,
            Energieverbrauch = new List<Verbrauch>
            {
                new Verbrauch
                {
                    Einheit = Mengeneinheit.KWH,
                    Startdatum = new DateTimeOffset(2020, 3, 1, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                    Enddatum = new DateTimeOffset(2020, 3, 8, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                    Wert = 456.0M,
                    Obiskennzahl = "1-2-3-4",
                    Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG
                },
                new Verbrauch
                {
                    Einheit = Mengeneinheit.KWH,
                    Startdatum = new DateTimeOffset(2020, 3, 25, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                    Enddatum = new DateTimeOffset(2020, 4, 1, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                    Wert = 123.0M,
                    Obiskennzahl = "5-6-7-8",
                    Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG
                }
            }
        };

        [TestMethod]
        public void ShowCaseTest()
        {
            Assert.IsTrue(em.IsValid());
            StaticLogger.Logger = NullLogger.Instance;
            // Image there is a service provider to analyse the verbrauchs data but he shouldn't know about the location data.
            // Yet it should still be possible to map the results back to my original data. So hashing seems like a good approach.
            var config = new AnonymizerConfiguration();
            config.SetOption(DataCategory.POD, AnonymizerApproach.HASH);
            var salt = new byte[100];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(salt);
            config.HashingSalt = Convert.ToBase64String(salt); // Some random but not necessarily secret salt;
            Energiemenge anonymizedEm;
            using (var anon = new Anonymizer(config))
            {
                anonymizedEm = anon.ApplyOperations<Energiemenge>(em);
            }

            Debug.WriteLine($"No one knowing only {anonymizedEm.LokationsId} actually means {em.LokationsId}");
            Assert.AreNotEqual(em.LokationsId, anonymizedEm.LokationsId);
            Debug.WriteLine(
                "But it won't cause any problems in satellite systems because the data is still there (!=null) and the business object is still valid.");
            Assert.IsNotNull(anonymizedEm.LokationsId);
            Assert.IsTrue(anonymizedEm.IsValid());
        }
    }
}