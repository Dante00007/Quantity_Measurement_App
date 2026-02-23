namespace QuantityMeasurementApp.models;

public enum LengthUnit
{
   FEET,
   INCH,
   YARD,
   CENTIMETER
}

public static class LengthUnitExtension
{
    public static double GetFactor(this LengthUnit lengthUnit)
    {
        return lengthUnit switch
        {
            LengthUnit.FEET => 12.0,
            LengthUnit.INCH => 1.0,
            LengthUnit.YARD => 36.0,
            LengthUnit.CENTIMETER => 0.393701,
            _ => 0.0
        };
    }
}