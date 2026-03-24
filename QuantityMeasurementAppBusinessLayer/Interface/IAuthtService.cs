
using QuantityMeasurementAppModelLayer.Entity;
using QuantityMeasurementAppModelLayer.DTO;

namespace QuantityMeasurementAppBusinessLayer.Interface
{
    public interface IAuthService
    {
        bool Register(RegisterDTO registerDTO);
        string Login(LoginDTO loginDTO);
    }
}