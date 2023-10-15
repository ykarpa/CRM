using Npgsql;
using System.Data.SqlClient;

namespace DBinit
{
	class Program
	{
		static void Main(string[] args)
		{
			string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=TradePulse;";
			DataBase db = new DataBase(connectionString);
			DbInitTask.CreateTables(db);
		}
	}
}