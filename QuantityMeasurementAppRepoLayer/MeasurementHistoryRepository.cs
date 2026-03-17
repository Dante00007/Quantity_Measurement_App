using QuantityMeasurementAppModelLayer.Entity;
using Microsoft.Data.SqlClient;
using QuantityMeasurementAppModelLayer.Util;

namespace QuantityMeasurementAppRepoLayer;

public class MeasurementHistoryRepository : IMeasurementHistoryRepository
{
    private readonly string _connectionString;
    public MeasurementHistoryRepository()
    {
        _connectionString = AppConfig.ConnectionString;
    }

    public void SaveHistory(QuantityMeasurementHistoryEntity entry)
    {

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"INSERT INTO MeasurementHistory (InputValue1, InputUnit1,InputValue2, InputUnit2, 
                                TargetUnit, Operation, ResultValue,ResultUnit) 
                                VALUES (@val1, @unit1,@val2, @unit2, @tUnit,@operation,@result,@resUnit)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@val1", entry.InputValue1);
                cmd.Parameters.AddWithValue("@unit1", entry.InputUnit1);
                cmd.Parameters.AddWithValue("@val2", entry.InputValue2);
                cmd.Parameters.AddWithValue("@unit2", entry.InputUnit2);
                cmd.Parameters.AddWithValue("@tUnit", entry.TargetUnit);
                cmd.Parameters.AddWithValue("@operation", entry.Operation);
                cmd.Parameters.AddWithValue("@result", entry.ResultValue);
                cmd.Parameters.AddWithValue("@resUnit", entry.ResultUnit);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }


}