
using QuantityMeasurementApp.generic;

try
{
    Console.WriteLine("--- Weight Operations ---");
    Quantity<WeightUnit> weight1 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM); // 1000g
    Quantity<WeightUnit> weight2 = new Quantity<WeightUnit>(500, WeightUnit.GRAM);

    var weightSub = weight1.Subtract(weight2);
    Console.WriteLine($"Subtraction (1kg - 500g): {weightSub.Value} {weightSub.Unit}");

    
    double weightDiv = weight1.Divide(weight2);
    Console.WriteLine($"Division (1kg / 500g): {weightDiv}");


    Console.WriteLine("\n--- Length Operations ---");
    Quantity<LengthUnit> length1 = new Quantity<LengthUnit>(1, LengthUnit.FEET); // 12 inches
    Quantity<LengthUnit> length2 = new Quantity<LengthUnit>(6, LengthUnit.INCH);

   
    var lengthSub = length1.Subtract(length2);
    Console.WriteLine($"Subtraction (1ft - 6in): {lengthSub.Value} {lengthSub.Unit}");

    double lengthDiv = length1.Divide(length2);
    Console.WriteLine($"Division (1ft / 6in): {lengthDiv}");


    Console.WriteLine("\n--- Volume Operations ---");
    Quantity<VolumeUnit> vol1 = new Quantity<VolumeUnit>(1, VolumeUnit.GALLON); // ~3.78541L
    Quantity<VolumeUnit> vol2 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);

   
    var volSub = vol1.Subtract(vol2, VolumeUnit.LITRE);
    Console.WriteLine($"Subtraction (1gal - 1L) in Litres: {volSub.Value} {volSub.Unit}");

    Quantity<VolumeUnit> vol3 = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRE);
    double volDiv = vol1.Divide(vol3);
    Console.WriteLine($"Division (1gal / 3.78541L): {volDiv:F2}");
 
    var converted = vol1.ConvertTo(VolumeUnit.MILLILITRE);
    Console.WriteLine($"\nConversion (1gal to mL): {converted.Value} {converted.Unit}");
}
catch (ArithmeticException ex)
{
    Console.WriteLine($"Math Error: {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation Error: {ex.Message}");
}