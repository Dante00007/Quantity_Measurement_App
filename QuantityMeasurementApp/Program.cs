using QuantityMeasurementApp.models;

try 
{
    var q1 = new QuantityLength(1.0, LengthUnit.FEET);
    double convertedInches = QuantityLength.Convert(q1.Value, q1.Unit, LengthUnit.INCH);
    Console.WriteLine($"Quantity(1.0, FEET) to INCHES: {convertedInches:F1} {LengthUnit.INCH}");

    var sum1 = QuantityLength.Add(new QuantityLength(1.0, LengthUnit.FEET), new QuantityLength(12.0, LengthUnit.INCH), LengthUnit.FEET);
    Console.WriteLine($"Add 1.0 Feet + 12.0 Inches: {sum1.Value:F1} {sum1.Unit}");

    var qInch = new QuantityLength(36.0, LengthUnit.INCH);
    var qYard = new QuantityLength(1.0, LengthUnit.YARD);
    Console.WriteLine($"36.0 INCHES equals 1.0 YARDS: {qInch.Equals(qYard)}");

    var sum2 = QuantityLength.Add(new QuantityLength(1.0, LengthUnit.YARD), new QuantityLength(3.0, LengthUnit.FEET), LengthUnit.YARD);
    Console.WriteLine($"Add 1.0 Yards + 3.0 Feet: {sum2.Value:F1} {sum2.Unit}");

    double cmToInch = QuantityLength.Convert(2.54, LengthUnit.CENTIMETER, LengthUnit.INCH);
    Console.WriteLine($"2.54 Centimeters to Inches: {cmToInch:F1} {LengthUnit.INCH}");

    var sum3 = QuantityLength.Add(new QuantityLength(5.0, LengthUnit.FEET), new QuantityLength(0.0, LengthUnit.INCH), LengthUnit.FEET);
    Console.WriteLine($"Add 5.0 Feet + 0.0 Inches: {sum3.Value:F1} {sum3.Unit}");

    double feetBase = LengthUnit.FEET.ConvertToBaseUnit(12.0);
    Console.WriteLine($"FEET 12.0 to Base: {feetBase:F1}");

    double inchBase = LengthUnit.INCH.ConvertToBaseUnit(12.0);
    Console.WriteLine($"INCHES 12.0 to Base: {inchBase:F1}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation Error: {ex.Message}");
}