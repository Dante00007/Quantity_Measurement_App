namespace QuantityMeasurementApp.models;

public enum LengthUnit
{
    INCH,
    FEET,
    YARD,
    CENTIMETER
}

public static class LengthUnitExtension
{
    public static double GetFactor(this LengthUnit lengthUnit)
    {
        return lengthUnit switch
        {
            LengthUnit.FEET => 1.0,
            LengthUnit.INCH => 1.0 / 12.0,
            LengthUnit.YARD => 3.0,
            LengthUnit.CENTIMETER => 1.0 / 30.48,
            _ => 0.0
        };
    }

    public static double ConvertToBaseUnit(this LengthUnit unit, double value)
    {
        return value * unit.GetFactor();
    }
    public static double ConvertFromBaseUnit(this LengthUnit unit, double baseValue)
    {
        return baseValue / unit.GetFactor();
    }
}