using QuantityMeasurementApp.generic;

try
{
    // --- Weight Demonstration ---
    Quantity<WeightUnit> quantity1 = new Quantity<WeightUnit>(100, WeightUnit.POUND);
    Quantity<WeightUnit> quantity2 = new Quantity<WeightUnit>(1000, WeightUnit.GRAM);

    Quantity<WeightUnit> weightResult = Quantity<WeightUnit>.Add(quantity1, quantity2, WeightUnit.KILOGRAM);
    Console.WriteLine($"Weight Result: {weightResult.Value} {weightResult.Unit}");

   
    Quantity<LengthUnit> quantity3 = new Quantity<LengthUnit>(24, LengthUnit.INCH);
    Quantity<LengthUnit> quantity4 = new Quantity<LengthUnit>(1, LengthUnit.FEET);

    Quantity<LengthUnit> lengthResult = Quantity<LengthUnit>.Add(quantity3, quantity4, LengthUnit.FEET);
    Console.WriteLine($"Length Result: {lengthResult.Value} {lengthResult.Unit}");

   
    Quantity<VolumeUnit> volume1 = new Quantity<VolumeUnit>(1, VolumeUnit.GALLON);
    Quantity<VolumeUnit> volume2 = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRE);

    Quantity<VolumeUnit> volumeResult = Quantity<VolumeUnit>.Add(volume1, volume2, VolumeUnit.LITRE);
    Console.WriteLine($"Volume Result: {volumeResult.Value} {volumeResult.Unit}");
    
   
    bool areEqual = volume1.Equals(volume2);
    Console.WriteLine($"1 Gallon equals 3.78541 Litres: {areEqual}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation Error: {ex.Message}");
}