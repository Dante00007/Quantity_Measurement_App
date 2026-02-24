using QuantityMeasurementApp;
using QuantityMeasurementApp.models;

try 
{
    double feetToInch = QuantityLength.Convert(1.0, LengthUnit.FEET, LengthUnit.INCH);
    Console.WriteLine($"1 Feet to Inch: {feetToInch}");

    double yardsToFeet = QuantityLength.Convert(3.0, LengthUnit.YARD, LengthUnit.FEET);
    Console.WriteLine($"1 Yard to Feet: {yardsToFeet}"); 

    
    double inchToYard = QuantityLength.Convert(36.0, LengthUnit.INCH, LengthUnit.YARD);
    Console.WriteLine($"36 Inches to Yard: {inchToYard}");


    double cmToInch = QuantityLength.Convert(1.0, LengthUnit.CENTIMETER, LengthUnit.INCH);
    Console.WriteLine($"1 Centimeter to Inches: {cmToInch}"); 

    double feetToInchTwo = QuantityLength.Convert(0.0, LengthUnit.FEET, LengthUnit.INCH);
    Console.WriteLine($"1 Feet to Inch: {feetToInchTwo}");

 
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation Error: {ex.Message}");
}