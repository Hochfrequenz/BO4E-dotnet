using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using BO4E.BO;
using BO4E.BO.LogObject;
using BO4E.COM;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace TestBO4E
{
    [TestClass]
    public class TestJsonOrder
    {
        [TestMethod]
        public void TestJsonOrderAttributesOfCOM()
        {
            TestOrderFromAbstract(typeof(COM));
        }

        [TestMethod]
        public void TestJsonOrderAttributesOfBO()
        {
            TestOrderFromAbstract(typeof(BusinessObject));
        }

        /// <summary>
        /// contains those types where the order of the json elements/properties should _not_ be enforced for now
        /// </summary>
        static readonly HashSet<Type> IgnoreOrderTypes = new()
        {
            // todo: make this list smaller, step by step.
            // we could for example assign these as "Strafarbeiten" for commits on dev/main that broke the tests

            // DON'T ADD NEW ENTRIES TO THE LIST

            // BusinessObjects
            typeof(Auftrag),
            typeof(AuftragsStorno),
            typeof(Avis),
            typeof(Benachrichtigung),
            typeof(Berechnungsformel),
            typeof(Energiemenge),
            typeof(Entsperrauftrag),
            typeof(Marktteilnehmer),
            typeof(Handelsunstimmigkeit),
            typeof(Kosten),
            typeof(LogObject),
            typeof(PreisblattDienstleistung),
            typeof(PreisblattKonzessionsabgabe),
            typeof(PreisblattMessung),
            typeof(PreisblattNetznutzung),
            typeof(PreisblattUmlagen),
            typeof(Rechnung),
            typeof(Region),
            typeof(Sperrauftrag),
            typeof(SperrauftragsStorno),

            // COMponents
            typeof(Abweichung),
            typeof(Angebotsposition),
            typeof(AufAbschlag),
            typeof(Aufgabe),
            typeof(Ausschreibungsdetail),
            typeof(Ausschreibungslos),
            typeof(Avisposition),
            typeof(Betrag),
            typeof(COM),
            typeof(Dienstleistung),
            typeof(Energieherkunft),
            typeof(Energiemix),
            typeof(ExterneReferenz),
            typeof(Fehler),
            typeof(FehlerDetail),
            typeof(FehlerUrsache),
            typeof(GenericStringStringInfo),
            typeof(Geokoordinaten),
            typeof(Handelsunstimmigkeitsbegruendung),
            typeof(Hardware),
            typeof(Katasteradresse),
            typeof(Konzessionsabgabe),
            typeof(Kostenblock),
            typeof(Kostenposition),
            typeof(KriteriumsWert),
            typeof(Lastprofil),
            //#pragma warning disable CS0619
            //            typeof(BO4E.COM.Marktrolle),
            //#pragma warning disable CS0619
            typeof(MarktpartnerDetails),
            typeof(Messlokationszuordnung),
            typeof(Notiz),
            typeof(PhysikalischerWert),
            typeof(PositionsAufAbschlag),
            typeof(Preis),
            typeof(Preisgarantie),
            typeof(Preisstaffel),
            typeof(Rechenschritt),
            typeof(RechnungspositionFlat),
            typeof(RegionaleGueltigkeit),
            typeof(RegionalePreisgarantie),
            typeof(RegionalePreisstaffel),
            typeof(RegionalerAufAbschlag),
            typeof(RegionaleTarifpreisposition),
            typeof(Regionskriterium),
            typeof(Rufnummer),
            typeof(Sigmoidparameter),
            typeof(StatusZusatzInformation),
            typeof(Steuerbetrag),
            typeof(Tagesparameter),
            typeof(Tarifberechnungsparameter),
            typeof(Tarifeinschraenkung),
            typeof(Tarifpreisposition),
            typeof(Unterschrift),
            typeof(Verbrauch),
            typeof(Vertragskonditionen),
            typeof(Verwendungszweck),
            typeof(Vertragsteil),

            typeof(Zeitraum),
            typeof(Zustaendigkeit)
        };

        protected static void TestOrderFromAbstract(Type abstractBaseType)
        {
            if (!abstractBaseType.IsAbstract)
                throw new ArgumentException($"The type {abstractBaseType} is not abstract", nameof(abstractBaseType));
            var relevantTypes = typeof(BusinessObject).Assembly.GetTypes().Where(abstractBaseType.IsAssignableFrom);
            foreach (var relevantType in relevantTypes.Where(t => !IgnoreOrderTypes.Contains(t) && !t.Name.Contains("Marktrolle")))
            {
                var properties = relevantType.GetProperties();
                var orders = new HashSet<int>();
                foreach (var dtProperty in properties)
                {
                    var systemTextIgnore = dtProperty.GetCustomAttributes<JsonIgnoreAttribute>().FirstOrDefault();
                    if (systemTextIgnore is not null)
                    {
                        continue;
                    }

                    var systemTextJsonOrderAttribute = dtProperty.GetCustomAttributes<JsonPropertyOrderAttribute>().FirstOrDefault();
                    systemTextJsonOrderAttribute.Should()
                        .NotBeNull(because: $"The property {dtProperty.Name} of {relevantType.Name} should have System.Text.JsonPropertyOrderAttribute");
                    var newtonSoftJsonPropertyAttribute = dtProperty.GetCustomAttributes<JsonPropertyAttribute>().FirstOrDefault();
                    newtonSoftJsonPropertyAttribute.Should().NotBeNull($"The property {dtProperty.Name} of {relevantType.Name} should have Newtonsoft.Json.JsonPropertyAttribute");
                    var systemTextOrder = systemTextJsonOrderAttribute.Order;
                    orders.Should().NotContain(systemTextOrder,
                        because: $"The JsonPropertyOrderAttribute should be unique for {relevantType} but found multiple occurrences of {systemTextOrder}");
                    orders.Add(systemTextOrder);

                    var newtonsoftIgnore = dtProperty.GetCustomAttributes<Newtonsoft.Json.JsonIgnoreAttribute>().FirstOrDefault();
                    if (newtonsoftIgnore is not null)
                    {
                        continue;
                    }

                    var newtonsoftOrder = newtonSoftJsonPropertyAttribute.Order;
                    systemTextOrder.Should().Be(newtonsoftOrder, because: $"System.Text Order and Newtonsoft Order of {relevantType.Name}.{dtProperty.Name} should be the same.");
                }
            }
        }
    }
}
