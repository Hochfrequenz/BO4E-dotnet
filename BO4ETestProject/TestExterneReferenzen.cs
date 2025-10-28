using System;
using System.Collections.Generic;
using AwesomeAssertions;
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
        var marktlokation = new Marktlokation { MarktlokationsId = "54321012345" };
        Assert.IsFalse(marktlokation.TryGetExterneReferenz("foo", out var _));
        marktlokation.ExterneReferenzen = new List<ExterneReferenz>();
        Assert.IsFalse(marktlokation.TryGetExterneReferenz("foo", out var _));
        marktlokation.ExterneReferenzen.Add(
            new ExterneReferenz { ExRefName = "foo", ExRefWert = "bar" }
        );
        Assert.IsTrue(marktlokation.TryGetExterneReferenz("foo", out var actualBar));
        Assert.AreEqual("bar", actualBar);
        var settingInvalidValues = () =>
            marktlokation.SetExterneReferenz(
                new ExterneReferenz { ExRefName = null, ExRefWert = "nicht bar" }
            );
        settingInvalidValues.Should().Throw<ArgumentException>();
        var addingInvalidValues = () =>
            marktlokation.SetExterneReferenz(
                new ExterneReferenz { ExRefName = "foo", ExRefWert = null }
            );
        addingInvalidValues.Should().Throw<ArgumentException>();
        var addingNull = () => marktlokation.SetExterneReferenz(null);
        addingNull.Should().Throw<ArgumentNullException>();

        var settingConflictingDefaultValues = () =>
            marktlokation.SetExterneReferenz(
                new ExterneReferenz { ExRefName = "foo", ExRefWert = "nicht bar" }
            );
        settingConflictingDefaultValues.Should().Throw<InvalidOperationException>();

        marktlokation.SetExterneReferenz(
            new ExterneReferenz { ExRefName = "foo", ExRefWert = "nicht bar" },
            true
        );
        Assert.IsTrue(marktlokation.TryGetExterneReferenz("foo", out actualBar));
        Assert.AreNotEqual("bar", actualBar);

        marktlokation.ExterneReferenzen = null;
        marktlokation.SetExterneReferenz(
            new ExterneReferenz { ExRefName = "foo", ExRefWert = "bar" }
        ); // if null, list is automatically created
        marktlokation.SetExterneReferenz(
            new ExterneReferenz { ExRefName = "foo", ExRefWert = "bar" }
        ); // setting a non-conflicting value twice doesn't hurt
        Assert.IsTrue(marktlokation.TryGetExterneReferenz("foo", out actualBar));
        Assert.AreEqual("bar", actualBar);
    }
}
