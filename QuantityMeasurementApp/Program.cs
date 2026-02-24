using QuantityMeasurementApp;
using QuantityMeasurementApp.models;

try 
{
    var sum1 = QuantityLength.Add(new QuantityLength(1.0, LengthUnit.FEET), new QuantityLength(2.0, LengthUnit.FEET));
    Console.WriteLine($"Add 1.0 Feet + 2.0 Feet: {sum1.Value} {sum1.Unit}");

    
    var sum2 = QuantityLength.Add(new QuantityLength(1.0, LengthUnit.FEET), new QuantityLength(12.0, LengthUnit.INCH));
    Console.WriteLine($"Add 1.0 Feet + 12.0 Inches: {sum2.Value} {sum2.Unit}");


    var sum3 = QuantityLength.Add(new QuantityLength(12.0, LengthUnit.INCH), new QuantityLength(1.0, LengthUnit.FEET));
    Console.WriteLine($"Add 12.0 Inches + 1.0 Feet: {sum3.Value} {sum3.Unit}");

   
    var sum4 = QuantityLength.Add(new QuantityLength(1.0, LengthUnit.YARD), new QuantityLength(3.0, LengthUnit.FEET));
    Console.WriteLine($"Add 1.0 Yards + 3.0 Feet: {sum4.Value} {sum4.Unit}");


    var sum5 = QuantityLength.Add(new QuantityLength(2.54, LengthUnit.CENTIMETER), new QuantityLength(1.0, LengthUnit.INCH));
    Console.WriteLine($"Add 2.54 Centimeters + 1.0 Inch: {sum5.Value} {sum5.Unit}");

 
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation Error: {ex.Message}");
}