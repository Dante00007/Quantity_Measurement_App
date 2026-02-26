using QuantityMeasurementApp.models;

try 
{
    var kg1 = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
    var kg2 = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
    Console.WriteLine($"Quantity(1.0, KILOGRAM) equals Quantity(1.0, KILOGRAM): {kg1.Equals(kg2)}");

    var kg1_2 = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
    var g1000 = new QuantityWeight(1000.0, WeightUnit.GRAM);
    Console.WriteLine($"Quantity(1.0, KILOGRAM) equals Quantity(1000.0, GRAM): {kg1_2.Equals(g1000)}");

    var lb2_1 = new QuantityWeight(2.0, WeightUnit.POUND);
    var lb2_2 = new QuantityWeight(2.0, WeightUnit.POUND);
    Console.WriteLine($"Quantity(2.0, POUND) equals Quantity(2.0, POUND): {lb2_1.Equals(lb2_2)}");

    var kg1_3 = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
    var lbApprox = new QuantityWeight(2.20462, WeightUnit.POUND);
    Console.WriteLine($"Quantity(1.0, KILOGRAM) equals Quantity(~2.20462, POUND): {kg1_3.Equals(lbApprox)}");

    var g500 = new QuantityWeight(500.0, WeightUnit.GRAM);
    var kg05 = new QuantityWeight(0.5, WeightUnit.KILOGRAM);
    Console.WriteLine($"Quantity(500.0, GRAM) equals Quantity(0.5, KILOGRAM): {g500.Equals(kg05)}");

    var lb1 = new QuantityWeight(1.0, WeightUnit.POUND);
    var gApprox = new QuantityWeight(453.592, WeightUnit.GRAM);
    Console.WriteLine($"Quantity(1.0, POUND) equals Quantity(~453.592, GRAM): {lb1.Equals(gApprox)}");

    double kgToG = QuantityWeight.Convert(1.0, WeightUnit.KILOGRAM, WeightUnit.GRAM);
    Console.WriteLine($"Quantity(1.0, KILOGRAM) to GRAM: {kgToG:F1} {WeightUnit.GRAM}");

    double lbToKg = QuantityWeight.Convert(2.0, WeightUnit.POUND, WeightUnit.KILOGRAM);
    Console.WriteLine($"Quantity(2.0, POUND) to KILOGRAM: {lbToKg:F6} {WeightUnit.KILOGRAM}");

    double gToLb = QuantityWeight.Convert(500.0, WeightUnit.GRAM, WeightUnit.POUND);
    Console.WriteLine($"Quantity(500.0, GRAM) to POUND: {gToLb:F5} {WeightUnit.POUND}");

    double zeroKgToG = QuantityWeight.Convert(0.0, WeightUnit.KILOGRAM, WeightUnit.GRAM);
    Console.WriteLine($"Quantity(0.0, KILOGRAM) to GRAM: {zeroKgToG:F1} {WeightUnit.GRAM}");

    var sumW1 = QuantityWeight.Add(new QuantityWeight(1.0, WeightUnit.KILOGRAM), new QuantityWeight(2.0, WeightUnit.KILOGRAM));
    Console.WriteLine($"Add 1.0 KILOGRAM + 2.0 KILOGRAM: {sumW1.Value:F1} {sumW1.Unit}");

    var sumW2 = QuantityWeight.Add(new QuantityWeight(1.0, WeightUnit.KILOGRAM), new QuantityWeight(1000.0, WeightUnit.GRAM));
    Console.WriteLine($"Add 1.0 KILOGRAM + 1000.0 GRAM: {sumW2.Value:F1} {sumW2.Unit}");

    var sumW3 = QuantityWeight.Add(new QuantityWeight(500.0, WeightUnit.GRAM), new QuantityWeight(0.5, WeightUnit.KILOGRAM));
    Console.WriteLine($"Add 500.0 GRAM + 0.5 KILOGRAM: {sumW3.Value:F1} {sumW3.Unit}");

    var sumW4 = QuantityWeight.Add(new QuantityWeight(1.0, WeightUnit.KILOGRAM), new QuantityWeight(1000.0, WeightUnit.GRAM), WeightUnit.GRAM);
    Console.WriteLine($"Add 1.0 KILOGRAM + 1000.0 GRAM (to GRAM): {sumW4.Value:F1} {sumW4.Unit}");

    var sumW5 = QuantityWeight.Add(new QuantityWeight(1.0, WeightUnit.POUND), new QuantityWeight(453.592, WeightUnit.GRAM), WeightUnit.POUND);
    Console.WriteLine($"Add 1.0 POUND + 453.592 GRAM (to POUND): {sumW5.Value:F1} {sumW5.Unit}");

    var sumW6 = QuantityWeight.Add(new QuantityWeight(2.0, WeightUnit.KILOGRAM), new QuantityWeight(4.0, WeightUnit.POUND), WeightUnit.KILOGRAM);
    Console.WriteLine($"Add 2.0 KILOGRAM + 4.0 POUND (to KILOGRAM): {sumW6.Value:F2} {sumW6.Unit}");

    var kgObj = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
    var ftObj = new QuantityLength(1.0, LengthUnit.FEET);
    Console.WriteLine($"Quantity(1.0, KILOGRAM) equals Quantity(1.0, FOOT): {kgObj.Equals(ftObj)}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation Error: {ex.Message}");
}