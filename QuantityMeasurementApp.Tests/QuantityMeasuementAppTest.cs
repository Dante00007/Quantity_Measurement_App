﻿namespace QuantityMeasurementApp.Tests;


using QuantityMeasurementApp;

[TestClass]
public sealed class QuantityMeasuementAppTest
{
   
    [TestMethod]
    public void TestEquality_SameValue()
    {
        
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        var feet2 = new QuantityMeasurementApplication.Feet(1.0);

        Assert.IsTrue(feet1.Equals(feet2));
    }

    [TestMethod]
    public void TestEquality_DifferentValue()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        var feet2 = new QuantityMeasurementApplication.Feet(2.0);

        Assert.IsFalse(feet1.Equals(feet2));
    }

    [TestMethod]
    public void TestEquality_NullComparison()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        var feet2 = null as QuantityMeasurementApplication.Feet;

        Assert.IsFalse(feet1.Equals(null));
    }

    [TestMethod]
    public void TestEquality_NonNumericInput()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        Assert.IsFalse(feet1.Equals("abc"));
    }

    [TestMethod]
    public void TestEquality_SameReference()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        
        Assert.IsTrue(feet1.Equals(feet1));
    }
}