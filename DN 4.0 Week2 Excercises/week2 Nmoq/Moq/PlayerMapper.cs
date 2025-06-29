using System;
using System.Data;
using System.Data.SqlClient;

namespace PlayersManagerLib
{
    public interface IPlayerMapper
    {
        bool IsPlayerNameExistsInDb(string name);
        void AddNewPlayerIntoDb(string name);
    }

    public class PlayerMapper : IPlayerMapper
    {
        private readonly string _connectionString =
            "Data Source=(local);Initial Catalog=GameDB;Integrated Security=True";

        public bool IsPlayerNameExistsInDb(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT count(*) FROM Player WHERE [Name] = @name";
                    command.Parameters.AddWithValue("@name", name);

                    var existingPlayersCount = (int)command.ExecuteScalar();
                    return existingPlayersCount > 0;
                }
            }
        }

        public void AddNewPlayerIntoDb(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Player ([Name]) VALUES (@name)";
                    command.Parameters.AddWithValue("@name", name);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}