using System;
using BO4E.COM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E;

[TestClass]
public class TestZeitfenster
{
    /// <summary>
    /// Valid HHMMHHMM string
    /// </summary>
    [TestMethod]
    public void TestZeitfensterCreationFromValidString()
    {
        var zeitfenster = new Zeitfenster("09001700");
        Assert.AreEqual(new TimeOnly(9, 0), zeitfenster.Startzeit);
        Assert.AreEqual(new TimeOnly(17, 0), zeitfenster.Endzeit);
    }

    /// <summary>
    /// Invalid string length
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestZeitfensterCreationFromInvalidString_Length()
    {
        var zeitfenster = new Zeitfenster("090017");
    }

    /// <summary>
    /// Invalid format (non-numeric)
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestZeitfensterCreationFromInvalidString_Format()
    {
        var zeitfenster = new Zeitfenster("09XX1700");
    }

    /// <summary>
    /// Invalid time (hours >= 24 or minutes >= 60)
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestZeitfensterCreationFromInvalidString_InvalidTime()
    {
        var zeitfenster = new Zeitfenster("24611700");
    }

    /// <summary>
    /// Directly using the constructor with TimeOnly objects
    /// </summary>
    [TestMethod]
    public void TestZeitfensterCreationUsingConstructor()
    {
        var startTime = new TimeOnly(9, 0);
        var endTime = new TimeOnly(17, 0);
        var zeitfenster = new Zeitfenster(startTime, endTime);
        Assert.AreEqual(startTime, zeitfenster.Startzeit);
        Assert.AreEqual(endTime, zeitfenster.Endzeit);
    }
}
