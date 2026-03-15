using QuantityMeasurementAppModelLayer.Core;

namespace QuantityMeasurementAppBusinessLayer.Services
{
    public interface IMeasurementService
    {
        Quantity<U> PerformConversion<U>(Quantity<U> q,U toUnit) where U : Enum;
        Quantity<U> PerformAddition<U>(Quantity<U> q1, Quantity<U> q2, U targetUnit) where U : Enum;
        Quantity<U> PerformSubtraction<U>(Quantity<U> q1, Quantity<U> q2, U targetUnit) where U : Enum;
        bool CheckEquality<U>(double val1, U unit1, double val2, U unit2) where U : Enum;
    }
}