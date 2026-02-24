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
    private double GetValueInBaseUnit()
    {
        return _unit.ConvertToBaseUnit(_value);
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (obj is not QuantityLength other)
            return false;

        double firstValueInBaseUnit = this.GetValueInBaseUnit();
        double secondValueInBaseUnit = (other).GetValueInBaseUnit();
        return Math.Abs(firstValueInBaseUnit - secondValueInBaseUnit) < 0.001;
    }

    public override int GetHashCode()
    {
        return GetValueInBaseUnit().GetHashCode();
    }

    public static double Convert(double value, LengthUnit sourceUnit, LengthUnit targetUnit)
    {
        if (!double.IsFinite(value))
            throw new ArgumentException("Value must be a finite number.");

        double baseValue = sourceUnit.ConvertToBaseUnit(value);

        double targetValue = targetUnit.ConvertFromBaseUnit(baseValue);

        return Math.Round(targetValue, 6);
    }

    private static double AddInBaseUnit(QuantityLength quantity1, QuantityLength quantity2)
    {
        if (quantity1 == null || quantity2 == null)
            throw new ArgumentException("Quantities cannot be null.");

        double value1 = quantity1._value;
        double value2 = quantity2._value;

        if (!double.IsFinite(value1) || !double.IsFinite(value2))
            throw new ArgumentException("Value must be a finite number.");

        double value1InBaseUnit = quantity1.GetValueInBaseUnit();
        double value2InBaseUnit = quantity2.GetValueInBaseUnit();

        double result = value1InBaseUnit + value2InBaseUnit;

        return result;

    }
    public static QuantityLength Add(QuantityLength quantity1, QuantityLength quantity2)
    {

        double result = AddInBaseUnit(quantity1, quantity2);

        LengthUnit targetUnit = quantity1._unit;

        double newValue = Math.Round(targetUnit.ConvertFromBaseUnit(result), 4);
        return new QuantityLength(newValue, targetUnit);
    }
    public static QuantityLength Add(QuantityLength quantity1, QuantityLength quantity2, LengthUnit targetUnit)
    {

        double result = AddInBaseUnit(quantity1, quantity2);

        double newValue = Math.Round(targetUnit.ConvertFromBaseUnit(result), 4);
        return new QuantityLength(newValue, targetUnit);
    }
}