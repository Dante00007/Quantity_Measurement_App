using QuantityMeasurementApp.generic;

try
{
    Quantity<WeightUnit> quantity = new Quantity<WeightUnit>(100, WeightUnit.POUND);
    Quantity<WeightUnit> quantity2 = new Quantity<WeightUnit>(1000, WeightUnit.GRAM);

    Quantity<WeightUnit> result = Quantity<WeightUnit>.Add(quantity, quantity2, WeightUnit.KILOGRAM);

    Console.WriteLine($"Result: {result.Value} {result.Unit}");

    Quantity<LengthUnit> quantity3 = new Quantity<LengthUnit>(24, LengthUnit.INCH);
    Quantity<LengthUnit> quantity4 = new Quantity<LengthUnit>(1, LengthUnit.FEET);

    Quantity<LengthUnit> result2 = Quantity<LengthUnit>.Add(quantity3, quantity4, LengthUnit.FEET);

    Console.WriteLine($"Result: {result2.Value} {result2.Unit}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation Error: {ex.Message}");
}