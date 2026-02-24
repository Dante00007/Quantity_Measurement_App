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

    public double Value => _value;
    public LengthUnit Unit => _unit;
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

    public static double Convert(double value, LengthUnit sourceUnit, LengthUnit targetUnit)
    {
        if (!double.IsFinite(value))
            throw new ArgumentException("Value must be a finite number.");
        double valueInBaseUnit = value * sourceUnit.GetFactor();
        double targetValue = valueInBaseUnit / targetUnit.GetFactor();

        return Math.Round(targetValue, 6);
    }

    public static QuantityLength Add(QuantityLength quantity1, QuantityLength quantity2, LengthUnit targetUnit)
    {
        if (quantity1 == null || quantity2 == null)
            throw new ArgumentException("Quantities cannot be null.");

        double value1 = quantity1._value;
        double value2 = quantity2._value;

        if (!double.IsFinite(value1) || !double.IsFinite(value2))
            throw new ArgumentException("Value must be a finite number.");

        double value1Inches = Convert(value1, quantity1._unit, LengthUnit.INCH);
        double value2Inches = Convert(value2, quantity2._unit, LengthUnit.INCH);

        double result = value1Inches + value2Inches;

        double newValue = Math.Round((result / targetUnit.GetFactor()), 4);

        return new QuantityLength(newValue, targetUnit);
    }
}