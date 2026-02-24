namespace QuantityMeasurementApp.models;

public class QuantityLength
{
    private readonly double _value;
    private readonly LengthUnit _unit;

    public QuantityLength(double value, LengthUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    private double GetValueInInches()
    {
        return _value * _unit.GetFactor();
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (obj is not QuantityLength other)
            return false;

        double firstValueInInches = this.GetValueInInches();
        double secondValueInInches = (other).GetValueInInches();
        return Math.Abs(firstValueInInches - secondValueInInches) < 0.001;
    }

    public override int GetHashCode()
    {
        return (_value * _unit.GetFactor()).GetHashCode();
    }

    public static double Convert(double value, LengthUnit sourceUnit,LengthUnit targetUnit)
    {
        if (!double.IsFinite(value))
                throw new ArgumentException("Value must be a finite number.");
        double valueInBaseUnit = value * sourceUnit.GetFactor();
        double targetValue = valueInBaseUnit / targetUnit.GetFactor();

        return Math.Round(targetValue, 6);
    }
}