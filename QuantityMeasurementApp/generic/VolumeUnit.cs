namespace QuantityMeasurementApp.generic
{
    public enum VolumeUnit
    {
        LITRE,
        MILLILITRE,
        GALLON
    }

    public static class VolumeUnitExtensions
    {
        public static double GetFactor(this VolumeUnit unit)
        {
            return unit switch
            {
                VolumeUnit.LITRE => 1.0,           // Base Unit
                VolumeUnit.MILLILITRE => 0.001,    // 1 mL = 0.001 L
                VolumeUnit.GALLON => 3.78541,      // 1 gallon = 3.78541 L
                _ => throw new ArgumentException("Invalid Volume Unit")
            };
        }

        public static double ConvertToBaseUnit(this VolumeUnit unit, double value)
        {
            return value * unit.GetFactor();
        }

        public static double ConvertFromBaseUnit(this VolumeUnit unit, double baseValue)
        {
            return baseValue / unit.GetFactor();
        }

        public static string GetUnitName(this VolumeUnit unit)
        {
            return unit switch
            {
                VolumeUnit.LITRE => "Litre",
                VolumeUnit.MILLILITRE => "Millilitre",
                VolumeUnit.GALLON => "Gallon",
                _ => unit.ToString()
            };
        }
    }
}