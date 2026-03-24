using QuantityMeasurementAppModelLayer.Entity;

namespace QuantityMeasurementAppBusinessLayer.Interface
{
    public interface IJwtService
    {
        public string GenerateToken(UserEntity user);
    }
}