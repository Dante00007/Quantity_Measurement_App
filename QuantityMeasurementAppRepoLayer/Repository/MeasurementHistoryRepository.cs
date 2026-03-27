using QuantityMeasurementAppModelLayer.Entity;
using Microsoft.Data.SqlClient;
using QuantityMeasurementAppModelLayer.Util;
using QuantityMeasurementAppRepoLayer.Exceptions;
using QuantityMeasurementAppRepoLayer.Interface;


namespace QuantityMeasurementAppRepoLayer.Repository;

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

    public bool SaveUser(UserEntity user)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Users (FullName, Password, Email, Phone) 
                             VALUES (@fullName, @password, @email, @phone)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@fullName", user.FullName);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@phone", user.Phone);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new DatabaseOperationException("Failed to save user to the database.");

                    return true;
                }
            }
        }
        catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
        {
            // 2627 and 2601 are SQL codes for Unique Constraint violations
            throw new UserAlreadyExistsException(user.Email);
        }
    }
    public UserEntity VerifyUser(string email)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"SELECT * FROM Users WHERE Email = @email";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@email", email);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        UserEntity user = new UserEntity();
                        user.Id = reader.GetInt32(0);
                        user.FullName = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Email = reader.GetString(3);
                        user.Phone = reader.GetString(4);

                        return user;
                    }
                }

            }
            throw new UserNotFoundException($"User Not Found {email}");
        }
    }
}