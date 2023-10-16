using Npgsql;
using System.Data.SqlClient;

namespace DBinit
{
	class Program
	{
		static void Main(string[] args)
		{
			string connectionString = "Host=surus.db.elephantsql.com;Username=ezzaidoo;Password=VvgDIad5Osco_z1erVN-xhbJ3xuqdBCZ;Database=ezzaidoo;";
			DataBase db = new DataBase(connectionString);
			//DbInitTask.CreateTables(db);
			DbInitTask.FillUsersTable(db);
		}
	}
}