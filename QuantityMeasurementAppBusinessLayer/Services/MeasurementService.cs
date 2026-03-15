using QuantityMeasurementAppModelLayer.Core;

namespace QuantityMeasurementAppBusinessLayer.Services
{
    public class MeasurementService : IMeasurementService
    {
        public Quantity<U> PerformConversion<U>(Quantity<U> q, U toUnit) where U : Enum
        {
            return q.ConvertTo(toUnit);
        }

        public Quantity<U> PerformAddition<U>(Quantity<U> q1, Quantity<U> q2, U targetUnit) where U : Enum
        {

            return q1.Add(q2, targetUnit);
        }

        public Quantity<U> PerformSubtraction<U>(Quantity<U> q1, Quantity<U> q2, U targetUnit) where U : Enum
        {
            return q1.Subtract(q2, targetUnit);
        }

        public bool CheckEquality<U>(double val1, U unit1, double val2, U unit2) where U : Enum
        {
            var q1 = new Quantity<U>(val1, unit1);
            var q2 = new Quantity<U>(val2, unit2);
            return q1.Equals(q2);
        }
    }
}