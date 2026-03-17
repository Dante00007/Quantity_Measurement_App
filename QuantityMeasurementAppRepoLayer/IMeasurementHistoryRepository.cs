using QuantityMeasurementAppModelLayer.Entity;
namespace QuantityMeasurementAppRepoLayer
{
    public interface IMeasurementHistoryRepository
    {
        public void SaveHistory(QuantityMeasurementHistoryEntity history);
    }
}