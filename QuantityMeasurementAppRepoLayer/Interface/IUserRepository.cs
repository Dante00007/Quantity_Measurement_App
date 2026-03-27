
using QuantityMeasurementAppModelLayer.Entity;

namespace QuantityMeasurementAppRepoLayer.Interface;

public interface IUserRepository 
{
    public Task<bool> SaveUser(UserEntity user); 
    public Task<UserEntity?> VerifyUser(string email); 
}