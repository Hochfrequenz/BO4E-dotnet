using System;
using System.Collections.Generic;
using System.IO;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtoBuf;

namespace TestBO4E
{
    [TestClass]
    public class TestProtobufSerialization
    {
        [TestMethod]
        public void TestProtobufRoundTripUnterschrift()
        {
            var unterschrift = new Unterschrift
            {
                Datum = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero),
                Name = "Hans Wurst",
                Ort = "Musterstadt"
            };
            Assert.IsTrue(unterschrift.IsValid(), "Must not serialize invalid COM");
            var unterschriftRoundTrip = SerializeAsBase64RoundTrip(unterschrift);
            Assert.AreEqual(unterschrift.Datum, unterschriftRoundTrip.Datum);
        }

        [TestMethod]
        public void TestProtobufRoundTripEnergiemenge()
        {
            //Guid emGuid = Guid.NewGuid();
            //Guid v1Guid = Guid.NewGuid();
            var em = new Energiemenge
            {
                LokationsId = "54321012345",
                LokationsTyp = Lokationstyp.MALO,
                //Guid = emGuid,
                Energieverbrauch = new List<Verbrauch>
                {
                    new Verbrauch
                    {
                        Einheit = Mengeneinheit.KWH,
                        Wert = 10.0M,
                        Startdatum = new DateTimeOffset(2019, 1, 1, 0, 0, 0 ,TimeSpan.Zero),
                        Enddatum = new DateTimeOffset(2019, 1, 2, 0, 0, 0, TimeSpan.Zero),
                        Obiskennzahl = "1-0:1.8.1"
                        //Guid = v1Guid
                    },
                    new Verbrauch
                    {
                        Einheit = Mengeneinheit.MWH,
                        Wert = 23.0M,
                        Startdatum = new DateTimeOffset(2019, 1, 2, 0, 0, 0, TimeSpan.Zero),
                        Enddatum = new DateTimeOffset(2019, 1, 3, 0, 0, 0, TimeSpan.Zero),
                        Obiskennzahl = "1-0:1.8.1"
                        //Guid = null
                    }
                }
            };
            Assert.IsTrue(em.IsValid(), "Must not serialize invalid Business Objects.");
            var emRoundTrip = SerializeAsBase64RoundTrip(em);
            Assert.IsNotNull(emRoundTrip.LokationsId);
            Assert.IsTrue(emRoundTrip.IsValid());
            /*
            Assert.IsTrue(emRoundTrip.Guid.HasValue);
            Assert.AreEqual(emGuid, em.Guid.Value);
            Assert.IsTrue(emRoundTrip.Energieverbrauch.First().Guid.HasValue);
            Assert.AreEqual(v1Guid, emRoundTrip.Energieverbrauch.First().Guid.Value);
            Assert.IsFalse(emRoundTrip.Energieverbrauch.Last().Guid.HasValue);
            */

            em.Should().BeEquivalentTo(emRoundTrip, opts => opts.ComparingByMembers<Energiemenge>());
        }

        /// <summary>
        /// Serializes <paramref name="protoObject"/> as base64 (protobuf) string and deserializes it again
        /// </summary>
        /// <param name="protoObject"></param>
        /// <typeparam name="TContract"></typeparam>
        /// <returns></returns>
        protected static TContract SerializeAsBase64RoundTrip<TContract>(TContract protoObject)
        {
            string base64String;
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, protoObject);
                using var reader = new BinaryReader(stream);
                base64String = Convert.ToBase64String(stream.ToArray());
            }

            Assert.IsFalse(string.IsNullOrWhiteSpace(base64String));

            // now use base64 string to get back the original
            TContract deserializedObject;
            using (var backStream = new MemoryStream(Convert.FromBase64String(base64String)))
            {
                backStream.Seek(0, SeekOrigin.Begin);
                deserializedObject = Serializer.Deserialize<TContract>(backStream);
            }

            return deserializedObject;
        }
    }
}
