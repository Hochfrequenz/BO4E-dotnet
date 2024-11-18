using System;
using System.Collections.Generic;
using System.Linq;
using BO4E.Marktkommunikation;
using BO4E.Marktkommunikation.v2;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E;

[TestClass]
public class TestLinkExtensions
{
    [TestMethod]
    public void Test_Link_To_Zeitabhaengig()
    {
        var bc = new BOneyComb
        {
            Links = new Dictionary<string, List<string>>
            {
                {
                    "foo",
                    new List<string> { "bar", "baz" }
                },
                {
                    "x",
                    new List<string> { "y", "z" }
                },
            },
        };
        var actual = bc.Links.SelectMany(x => x.ToTimeDependentLink()).ToList();
        actual
            .Should()
            .BeEquivalentTo(
                new List<ZeitabhaengigeBeziehung>
                {
                    new()
                    {
                        ParentId = "foo",
                        ChildId = "bar",
                        GueltigVon = DateTimeOffset.MinValue,
                        GueltigBis = DateTimeOffset.MaxValue,
                    },
                    new()
                    {
                        ParentId = "foo",
                        ChildId = "baz",
                        GueltigVon = DateTimeOffset.MinValue,
                        GueltigBis = DateTimeOffset.MaxValue,
                    },
                    new()
                    {
                        ParentId = "x",
                        ChildId = "y",
                        GueltigVon = DateTimeOffset.MinValue,
                        GueltigBis = DateTimeOffset.MaxValue,
                    },
                    new()
                    {
                        ParentId = "x",
                        ChildId = "z",
                        GueltigVon = DateTimeOffset.MinValue,
                        GueltigBis = DateTimeOffset.MaxValue,
                    },
                }
            );
    }

    [TestMethod]
    public void Test_Zeitabhaengig_To_Link()
    {
        var actual = new ZeitabhaengigeBeziehung
        {
            ParentId = "foo",
            ChildId = "bar",
            GueltigVon = DateTimeOffset.MinValue,
            GueltigBis = DateTimeOffset.MaxValue,
        }.ToTimeIndependentLink();
        actual
            .Should()
            .BeEquivalentTo(
                new KeyValuePair<string, List<string>>("foo", new List<string> { "bar" })
            );
    }
}
