using System;
using System.Collections.Generic;
using BO4E.BO;
using BO4E.COM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E;

[TestClass]
public class TestExterneReferenzen
{
    [TestMethod]
    public void TestGettingAndSetting()
    {
        var marktlokation = new Marktlokation
        {
            MarktlokationsId = "54321012345"
        };
        Assert.IsFalse(marktlokation.TryGetExterneReferenz("foo", out var _));
        marktlokation.ExterneReferenzen = new List<ExterneReferenz>();
        Assert.IsFalse(marktlokation.TryGetExterneReferenz("foo", out var _));
        marktlokation.ExterneReferenzen.Add(new ExterneReferenz { ExRefName = "foo", ExRefWert = "bar" });
        Assert.IsTrue(marktlokation.TryGetExterneReferenz("foo", out var actualBar));
        Assert.AreEqual("bar", actualBar);

        Assert.ThrowsException<ArgumentException>(
            () => marktlokation.SetExterneReferenz(new ExterneReferenz { ExRefName = null, ExRefWert = "nicht bar" }),
            "must not add invalid values");
        Assert.ThrowsException<ArgumentException>(
            () => marktlokation.SetExterneReferenz(new ExterneReferenz { ExRefName = "foo", ExRefWert = null }),
            "must not add invalid values");
        Assert.ThrowsException<ArgumentNullException>(() => marktlokation.SetExterneReferenz(null),
            "must not add null");

        Assert.ThrowsException<InvalidOperationException>(
            () => marktlokation.SetExterneReferenz(new ExterneReferenz
            { ExRefName = "foo", ExRefWert = "nicht bar" }), "By default conflicting values are rejected");
        marktlokation.SetExterneReferenz(new ExterneReferenz { ExRefName = "foo", ExRefWert = "nicht bar" }, true);
        Assert.IsTrue(marktlokation.TryGetExterneReferenz("foo", out actualBar));
        Assert.AreNotEqual("bar", actualBar);

        marktlokation.ExterneReferenzen = null;
        marktlokation.SetExterneReferenz(new ExterneReferenz
        { ExRefName = "foo", ExRefWert = "bar" }); // if null, list is automatically created
        marktlokation.SetExterneReferenz(new ExterneReferenz
        { ExRefName = "foo", ExRefWert = "bar" }); // setting a non-conflicting value twice doesn't hurt
        Assert.IsTrue(marktlokation.TryGetExterneReferenz("foo", out actualBar));
        Assert.AreEqual("bar", actualBar);
    }
}