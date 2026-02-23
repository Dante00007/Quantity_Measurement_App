using QuantityMeasurementApp;
using QuantityMeasurementApp.models;


Console.WriteLine(QuantityMeasurementApplication.DemonstrateLengthEquality(
    new QuantityLength(1.0, LengthUnit.YARD), 
    new QuantityLength(3.0, LengthUnit.FEET)));


Console.WriteLine(QuantityMeasurementApplication.DemonstrateLengthEquality(
    new QuantityLength(1.0, LengthUnit.YARD), 
    new QuantityLength(36.0, LengthUnit.INCH)));


Console.WriteLine(QuantityMeasurementApplication.DemonstrateLengthEquality(
    new QuantityLength(2.0, LengthUnit.YARD), 
    new QuantityLength(2.0, LengthUnit.YARD)));

Console.WriteLine(QuantityMeasurementApplication.DemonstrateLengthEquality(
    new QuantityLength(2.0, LengthUnit.CENTIMETER), 
    new QuantityLength(2.0, LengthUnit.CENTIMETER)));
    
Console.WriteLine(QuantityMeasurementApplication.DemonstrateLengthEquality(
    new QuantityLength(1.0, LengthUnit.CENTIMETER), 
    new QuantityLength(0.393701, LengthUnit.INCH)));