public class QuantityMeasurementApplication
{
    public class Feet
    {
        private readonly double _value;
        public Feet(double value)
        {
            this._value = value;
        }
        public double Value
        {
            get { return _value; }
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

        
            Feet other = (Feet)obj;
 
            return _value.CompareTo(other._value) == 0;
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }

    public class Inch
    {
        public readonly double _value;
        public Inch(double value)
        {
            this._value = value;
        }
        public double Value
        {
            get { return _value; }
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

        
            Inch other = (Inch)obj;
 
            return _value.CompareTo(other._value) == 0;
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
    public static void DemonstrateFeetEquality()
    {
        Feet feet1 = new Feet(10);
        Feet feet2 = new Feet(10);
        Console.WriteLine(feet1.Equals(feet2));
    }

    public static void DemonstrateInchEquality()
    {
        Inch inch1 = new Inch(10);
        Inch inch2 = new Inch(10);
        Console.WriteLine(inch1.Equals(inch2));
    }
    
}