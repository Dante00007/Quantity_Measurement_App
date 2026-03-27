using QuantityMeasurementAppModelLayer.Entity;
using QuantityMeasurementAppModelLayer.DTO;

namespace QuantityMeasurementAppBusinessLayer.Interface
{
    public interface IMeasurementService
    {
        Task<QuantityDTO> PerformConversion(QuantityDTO q,string toUnit);
        Task<QuantityDTO> PerformAddition(QuantityDTO q1, QuantityDTO q2, string targetUnit);
        Task<QuantityDTO> PerformSubtraction(QuantityDTO q1, QuantityDTO q2, string targetUnit);
        // bool CheckEquality(QuantityDTO q1, QuantityDTO q2);
    }
}