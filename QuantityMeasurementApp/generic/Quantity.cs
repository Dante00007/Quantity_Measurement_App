namespace QuantityMeasurementApp.generic;

public class Quantity<U> where U : Enum
{
    private readonly double _value;
    private readonly U _unit;

    public Quantity(double value, U unit)
    {
        if(!Double.IsFinite(value)) throw new ArgumentException("Value must be a finite number.");
        _value = value;
        _unit = unit;
    }

    public double Value => _value;
    public U Unit => _unit;

    private double GetValueInBaseUnit()
    {
        if(_unit is WeightUnit weightUnit) return weightUnit.ConvertToBaseUnit(_value);
        else if(_unit is LengthUnit lengthUnit) return lengthUnit.ConvertToBaseUnit(_value);
        // else if(_unit is VolumeUnit volumeUnit) return volumeUnit.ConvertToBaseUnit(_value);

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
        else throw new ArgumentException("Invalid Unit");
       
        
        double targetValue;
        if (targetUnit is WeightUnit weightUnit2) targetValue = weightUnit2.ConvertFromBaseUnit(baseValue);
        else if (targetUnit is LengthUnit lengthUnit2) targetValue = lengthUnit2.ConvertFromBaseUnit(baseValue);
        else throw new ArgumentException("Invalid Unit");

        return Math.Round(targetValue, 6);
    }

    private static double AddInBaseUnit(Quantity<U> quantity1, Quantity<U> quantity2)
    {
        if (quantity1 == null || quantity2 == null)
            throw new ArgumentException("Quantities cannot be null.");

        if (!double.IsFinite(quantity1._value) || !double.IsFinite(quantity2._value))
            throw new ArgumentException("Value must be a finite number.");
        // Console.WriteLine(quantity1.GetValueInBaseUnit());
        // Console.WriteLine(quantity2.GetValueInBaseUnit());
        return quantity1.GetValueInBaseUnit() + quantity2.GetValueInBaseUnit();
    }

    public static Quantity<U> Add(Quantity<U> quantity1, Quantity<U> quantity2) 
    {
        double resultInBase = AddInBaseUnit(quantity1, quantity2);
    
        U targetUnit = quantity1.Unit;

        if (quantity1.Unit is WeightUnit weightUnit){
            
            double newValue = Math.Round(weightUnit.ConvertFromBaseUnit(resultInBase), 4);
            Console.WriteLine(newValue);
            return new Quantity<U>(newValue, targetUnit);
        }
        else if (quantity1.Unit is LengthUnit lengthUnit){
            double newValue = Math.Round(lengthUnit.ConvertFromBaseUnit(resultInBase), 4);
            return new Quantity<U>(newValue, targetUnit);
        }
        else throw new ArgumentException("Invalid Unit");

    }

    public static Quantity<U> Add(Quantity<U> quantity1, Quantity<U> quantity2, U targetUnit)
    {
        double resultInBase = AddInBaseUnit(quantity1, quantity2);

        if (quantity1.Unit is WeightUnit){
            double newValue=0;
            if(targetUnit is WeightUnit weightUnit) 
                newValue = Math.Round(weightUnit.ConvertFromBaseUnit(resultInBase), 4);
            return new Quantity<U>(newValue, targetUnit);
        }
        else if (quantity1.Unit is LengthUnit){
            double newValue=0;
            if(targetUnit is LengthUnit lengthUnit) 
                newValue = Math.Round(lengthUnit.ConvertFromBaseUnit(resultInBase), 4);
            return new Quantity<U>(newValue, targetUnit);
        }
        else throw new ArgumentException("Invalid Unit");
        
      
    }
}