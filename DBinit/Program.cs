using System.Data.SqlClient;

namespace DBinit
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DataBase database = new DataBase("data source=.; database=PulseTrade; integrated security=SSPI");
			//database.CreateTable("USERS", "id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,\r\nfirst_name varchar(20) not null,\r\nlast_name varchar(20) not null,\r\nbirth_date date not null,\r\nrole varchar(10) not null, \r\nemail varchar(100) not null, \r\nbalance decimal(10, 2),\r\ncreated_at date");
		}
	}
}