﻿namespace QuantityMeasurementApp.Tests;


using QuantityMeasurementApp;

[TestClass]
public sealed class QuantityMeasuementAppTest
{
   
    [TestMethod]
    public void TestFeetEquality_SameValue()
    {
        
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        var feet2 = new QuantityMeasurementApplication.Feet(1.0);

        Assert.IsTrue(feet1.Equals(feet2));
    }

    [TestMethod]
    public void TestFeetEquality_DifferentValue()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        var feet2 = new QuantityMeasurementApplication.Feet(2.0);

        Assert.IsFalse(feet1.Equals(feet2));
    }

    [TestMethod]
    public void TestFeetEquality_NullComparison()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        var feet2 = null as QuantityMeasurementApplication.Feet;

        Assert.IsFalse(feet1.Equals(null));
    }

    [TestMethod]
    public void TestFeetEquality_NonNumericInput()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        Assert.IsFalse(feet1.Equals("abc"));
    }

    [TestMethod]
    public void TestFeetEquality_SameReference()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        
        Assert.IsTrue(feet1.Equals(feet1));
    }

    [TestMethod]
    public void TestInchEquality_SameValue()
    {
        
        var feet1 = new QuantityMeasurementApplication.Inch(1.0);
        var feet2 = new QuantityMeasurementApplication.Inch(1.0);

        Assert.IsTrue(feet1.Equals(feet2));
    }

    [TestMethod]
    public void TestInchEquality_DifferentValue()
    {
        var feet1 = new QuantityMeasurementApplication.Inch(1.0);
        var feet2 = new QuantityMeasurementApplication.Inch(2.0);

        Assert.IsFalse(feet1.Equals(feet2));
    }

    [TestMethod]
    public void TestInchEquality_NullComparison()
    {
        var feet1 = new QuantityMeasurementApplication.Inch(1.0);
        var feet2 = null as QuantityMeasurementApplication.Inch;

        Assert.IsFalse(feet1.Equals(null));
    }

    [TestMethod]
    public void TestInchEquality_NonNumericInput()
    {
        var feet1 = new QuantityMeasurementApplication.Inch(1.0);
        Assert.IsFalse(feet1.Equals("abc"));
    }

    [TestMethod]
    public void TestInchEquality_SameReference()
    {
        var feet1 = new QuantityMeasurementApplication.Inch(1.0);
        
        Assert.IsTrue(feet1.Equals(feet1));
    }
}