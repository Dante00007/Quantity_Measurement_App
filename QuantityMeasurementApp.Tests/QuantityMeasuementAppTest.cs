﻿namespace QuantityMeasurementApp.Tests;


using QuantityMeasurementApp;
using QuantityMeasurementApp.models;

[TestClass]
public class QuantityLengthTests
{
   
    [TestMethod]
    public void TestEquality_FeetToFeet_SameValue()
    {
        var feet1 = new QuantityLength(1.0, LengthUnit.FEET);
        var feet2 = new QuantityLength(1.0, LengthUnit.FEET);
        Assert.IsTrue(feet1.Equals(feet2));
    }


    [TestMethod]
    public void TestEquality_InchToInch_SameValue()
    {
        var inch1 = new QuantityLength(1.0, LengthUnit.INCH);
        var inch2 = new QuantityLength(1.0, LengthUnit.INCH);
        Assert.IsTrue(inch1.Equals(inch2));
    }

    [TestMethod]
    public void TestEquality_FeetToInch_EquivalentValue()
    {
        var feet = new QuantityLength(1.0, LengthUnit.FEET);
        var inch = new QuantityLength(12.0, LengthUnit.INCH);
        Assert.IsTrue(feet.Equals(inch));
    }

 
    [TestMethod]
    public void TestEquality_InchToFeet_EquivalentValue()
    {
        var inch = new QuantityLength(12.0, LengthUnit.INCH);
        var feet = new QuantityLength(1.0, LengthUnit.FEET);
        Assert.IsTrue(inch.Equals(feet));
    }

    [TestMethod]
    public void TestEquality_FeetToFeet_DifferentValue()
    {
        var feet1 = new QuantityLength(1.0, LengthUnit.FEET);
        var feet2 = new QuantityLength(2.0, LengthUnit.FEET);
        Assert.IsFalse(feet1.Equals(feet2));
    }

   
    [TestMethod]
    public void TestEquality_InchToInch_DifferentValue()
    {
        var inch1 = new QuantityLength(1.0, LengthUnit.INCH);
        var inch2 = new QuantityLength(2.0, LengthUnit.INCH);
        Assert.IsFalse(inch1.Equals(inch2));
    }


    [TestMethod]
    public void TestEquality_SameReference()
    {
        var feet = new QuantityLength(1.0, LengthUnit.FEET);
        Assert.IsTrue(feet.Equals(feet));
    }


    [TestMethod]
    public void TestEquality_NullComparison()
    {
        var feet = new QuantityLength(1.0, LengthUnit.FEET);
        Assert.IsFalse(feet.Equals(null));
    }

    [TestMethod]
    public void TestEquality_InvalidType()
    {
        var feet = new QuantityLength(1.0, LengthUnit.FEET);
        string notAQuantity = "1.0 feet";
        Assert.IsFalse(feet.Equals(notAQuantity));
    }
}