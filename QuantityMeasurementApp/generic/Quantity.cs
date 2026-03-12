namespace QuantityMeasurementApp.generic;

public class Quantity<U> where U : Enum
{
    private readonly double _value;
    private readonly U _unit;

    public Quantity(double value, U unit)
    {
        // Added null check as per your requirements
        if (unit == null) throw new ArgumentException("Unit cannot be null.");
        if (!double.IsFinite(value)) throw new ArgumentException("Value must be a finite number.");
        
        _value = value;
        _unit = unit;
    }

    public double Value => _value;
    public U Unit => _unit;

    private double GetValueInBaseUnit()
    {
        if (_unit is WeightUnit weightUnit) return weightUnit.ConvertToBaseUnit(_value);
        if (_unit is LengthUnit lengthUnit) return lengthUnit.ConvertToBaseUnit(_value);
        if (_unit is VolumeUnit volumeUnit) return volumeUnit.ConvertToBaseUnit(_value); // Added Volume

        throw new ArgumentException("Invalid Unit");
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not Quantity<U> other) return false;

        return Math.Abs(this.GetValueInBaseUnit() - other.GetValueInBaseUnit()) < 0.001;
    }

    public override int GetHashCode()
    {
        return GetValueInBaseUnit().GetHashCode();
    }

    public static double Convert(double value, U sourceUnit, U targetUnit)
    {
        if (!double.IsFinite(value))
            throw new ArgumentException("Value must be a finite number.");

        double baseValue;
        if (sourceUnit is WeightUnit weightUnit) baseValue = weightUnit.ConvertToBaseUnit(value);
        else if (sourceUnit is LengthUnit lengthUnit) baseValue = lengthUnit.ConvertToBaseUnit(value);
        else if (sourceUnit is VolumeUnit volumeUnit) baseValue = volumeUnit.ConvertToBaseUnit(value); // Added Volume
        else throw new ArgumentException("Invalid Unit");

        double targetValue;
        if (targetUnit is WeightUnit weightUnit2) targetValue = weightUnit2.ConvertFromBaseUnit(baseValue);
        else if (targetUnit is LengthUnit lengthUnit2) targetValue = lengthUnit2.ConvertFromBaseUnit(baseValue);
        else if (targetUnit is VolumeUnit volumeUnit2) targetValue = volumeUnit2.ConvertFromBaseUnit(baseValue); // Added Volume
        else throw new ArgumentException("Invalid Unit");

        return Math.Round(targetValue, 6);
    }

    private static double AddInBaseUnit(Quantity<U> quantity1, Quantity<U> quantity2)
    {
        if (quantity1 == null || quantity2 == null)
            throw new ArgumentException("Quantities cannot be null.");

        return quantity1.GetValueInBaseUnit() + quantity2.GetValueInBaseUnit();
    }

    public static Quantity<U> Add(Quantity<U> quantity1, Quantity<U> quantity2)
    {
        double resultInBase = AddInBaseUnit(quantity1, quantity2);
        U targetUnit = quantity1.Unit;

        if (quantity1.Unit is WeightUnit weightUnit)
        {
            double newValue = Math.Round(weightUnit.ConvertFromBaseUnit(resultInBase), 4);
            return new Quantity<U>(newValue, targetUnit);
        }
        else if (quantity1.Unit is LengthUnit lengthUnit)
        {
            double newValue = Math.Round(lengthUnit.ConvertFromBaseUnit(resultInBase), 4);
            return new Quantity<U>(newValue, targetUnit);
        }
        else if (quantity1.Unit is VolumeUnit volumeUnit) // Added Volume
        {
            double newValue = Math.Round(volumeUnit.ConvertFromBaseUnit(resultInBase), 4);
            return new Quantity<U>(newValue, targetUnit);
        }
        else throw new ArgumentException("Invalid Unit");
    }

    public static Quantity<U> Add(Quantity<U> quantity1, Quantity<U> quantity2, U targetUnit)
    {
        double resultInBase = AddInBaseUnit(quantity1, quantity2);

        if (quantity1.Unit is WeightUnit)
        {
            double newValue = 0;
            if (targetUnit is WeightUnit weightUnit)
                newValue = Math.Round(weightUnit.ConvertFromBaseUnit(resultInBase), 4);
            return new Quantity<U>(newValue, targetUnit);
        }
        else if (quantity1.Unit is LengthUnit)
        {
            double newValue = 0;
            if (targetUnit is LengthUnit lengthUnit)
                newValue = Math.Round(lengthUnit.ConvertFromBaseUnit(resultInBase), 4);
            return new Quantity<U>(newValue, targetUnit);
        }
        else if (quantity1.Unit is VolumeUnit) // Added Volume
        {
            double newValue = 0;
            if (targetUnit is VolumeUnit volumeUnit)
                newValue = Math.Round(volumeUnit.ConvertFromBaseUnit(resultInBase), 4);
            return new Quantity<U>(newValue, targetUnit);
        }
        else throw new ArgumentException("Invalid Unit");
    }
}