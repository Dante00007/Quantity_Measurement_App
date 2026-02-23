namespace QuantityMeasurementApp.models;

public enum LengthUnit
{
   FEET,
   INCH
}

public static class LengthUnitExtension
{
    public static double GetFactor(this LengthUnit lengthUnit)
    {
        return lengthUnit switch
        {
            LengthUnit.FEET => 12.0,
            LengthUnit.INCH => 1.0,
            _ => 0.0
        };
    }
}