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
	}
}
