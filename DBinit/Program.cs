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

    

            //db.PrintTableData("items");
            //db.PrintTableData("order_item");
            //db.PrintTableData("orders");
            //db.PrintTableData("payments");
            //db.PrintTableData("subscription");
            //db.PrintTableData("users");
            //db.PrintTableData("users_subscriptions");
        
        }
	}
}