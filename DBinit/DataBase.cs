using Npgsql;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace DBinit
{
	public class DataBase
	{
		private NpgsqlConnection connection;

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

		public NpgsqlDataReader ExecuteReaderQuery(string query)
		{
			try
			{
				connection.Open();
				NpgsqlCommand command = new(query, connection);
				return command.ExecuteReader();
			}
			catch (DbException ex)
			{
				Console.WriteLine("Database error occured: " + ex.Message);
			}
			finally
			{
				connection.Close();
			}
			return null;
		}

		public void PrintReaderData(NpgsqlDataReader reader)
		{
			if(!reader.HasRows)
			{
				throw new Exception("No rows returned.");
			}
			while(reader.Read())
			{
				Console.WriteLine(reader.FieldCount);
			}
		}

	}
}
