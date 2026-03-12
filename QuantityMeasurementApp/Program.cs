using QuantityMeasurementApp.generic;

try
{
    Console.WriteLine("--- Weight Operations ---");
    Quantity<WeightUnit> weight1 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM); // 1000g
    Quantity<WeightUnit> weight2 = new Quantity<WeightUnit>(500, WeightUnit.GRAM);
    
    // Subtraction: 1kg - 500g = 0.5kg
    var weightSub = Quantity<WeightUnit>.Subtract(weight1, weight2);
    Console.WriteLine($"Subtraction (1kg - 500g): {weightSub.Value} {weightSub.Unit}");
    
    // Division: 1kg / 500g = 2.0
    double weightDiv = Quantity<WeightUnit>.Divide(weight1, weight2);
    Console.WriteLine($"Division (1kg / 500g): {weightDiv}");


    Console.WriteLine("\n--- Length Operations ---");
    Quantity<LengthUnit> length1 = new Quantity<LengthUnit>(1, LengthUnit.FEET); // 12 inches
    Quantity<LengthUnit> length2 = new Quantity<LengthUnit>(6, LengthUnit.INCH);
    
    // Subtraction: 1ft - 6in = 0.5ft
    var lengthSub = Quantity<LengthUnit>.Subtract(length1, length2);
    Console.WriteLine($"Subtraction (1ft - 6in): {lengthSub.Value} {lengthSub.Unit}");

    // Division: 1ft / 6in = 2.0
    double lengthDiv = Quantity<LengthUnit>.Divide(length1, length2);
    Console.WriteLine($"Division (1ft / 6in): {lengthDiv}");


    Console.WriteLine("\n--- Volume Operations ---");
    Quantity<VolumeUnit> vol1 = new Quantity<VolumeUnit>(1, VolumeUnit.GALLON); // ~3.78541L
    Quantity<VolumeUnit> vol2 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);

    // Subtraction: 1 Gallon - 1 Litre = ~2.7854 Gallons (explicit target unit)
    var volSub = Quantity<VolumeUnit>.Subtract(vol1, vol2, VolumeUnit.LITRE);
    Console.WriteLine($"Subtraction (1gal - 1L) in Litres: {volSub.Value} {volSub.Unit}");

    // Division: 1 Gallon / 3.78541 Litres = ~1.0
    Quantity<VolumeUnit> vol3 = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRE);
    double volDiv = Quantity<VolumeUnit>.Divide(vol1, vol3);
    Console.WriteLine($"Division (1gal / 3.78541L): {volDiv:F2}");

}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Math Error: {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation Error: {ex.Message}");
}