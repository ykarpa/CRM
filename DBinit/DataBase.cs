	using Npgsql;
using System.Data.Common;

namespace DBinit
{
    public class DataBase
    {
        public NpgsqlConnection connection;

        public DataBase(string connectionString)
        {
            this.connection = new NpgsqlConnection(connectionString);
        }

        public void ExecuteNonQuery(string query)
        {
            try
            {
                connection.Open();
                NpgsqlCommand command = new(query, connection);
                command.ExecuteNonQuery();
            }
            catch (DbException ex)
            {
                Console.WriteLine("Database error occured: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void PrintTableData(string tableName)
        {
            try
            {
                connection.Open();
                var command = new NpgsqlCommand($"SELECT * FROM {tableName}", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; ++i)
                    {
                        Console.Write(reader.GetFieldValue<object>(i) + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine($"Database error occurred: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
