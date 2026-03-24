using QuantityMeasurementAppModelLayer.Entity;
namespace QuantityMeasurementAppRepoLayer
{
    public interface IMeasurementHistoryRepository
    {
        public void SaveHistory(QuantityMeasurementHistoryEntity history);

        public bool SaveUser(UserEntity user);
        public UserEntity VerifyUser(string email);

    }

}