using QuantityMeasurementAppModelLayer.Entity;

namespace QuantityMeasurementAppBusinessLayer.Services
{
    public interface IMeasurementService
    {
        QuantityDTO PerformConversion(QuantityDTO q,string toUnit);
        QuantityDTO PerformAddition(QuantityDTO q1, QuantityDTO q2, string targetUnit);
        QuantityDTO PerformSubtraction(QuantityDTO q1, QuantityDTO q2, string targetUnit);
        bool CheckEquality(QuantityDTO q1, QuantityDTO q2);
    }
}