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

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (obj is not QuantityLength other)
            return false;

        double firstValueInInches = _value * _unit.GetFactor();
        double secondValueInInches = (other)._value * (other)._unit.GetFactor();

        return Math.Abs(firstValueInInches - secondValueInInches) < 0.001;
    }

    public override int GetHashCode()
    {
        return (_value * _unit.GetFactor()).GetHashCode();
    }
}