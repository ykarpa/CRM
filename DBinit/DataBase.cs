using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBinit
{
	public class DataBase
	{
		SqlConnection? connection;
		public DataBase(string connString)
		{
			try
			{
				this.connection = new SqlConnection(connString);
				InitDB();
			} 
			catch (SqlException ex)
			{
				string errors = "";
				for (int i = 0; i < ex.Errors.Count; i++)
				{
                    errors += "Message: " + ex.Errors[i].Message + '\n';
                }
				throw new Exception(errors);
			}
			catch(Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
		}
		private void InitDB()
		{
			using (connection)
			{
				if (connection == null)
				{
					throw new Exception("No connection to database");
				}
				connection.Open();
				CreateTable("USERS", "id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,\r\nfirst_name varchar(20) not null,\r\nlast_name varchar(20) not null,\r\nbirth_date date not null,\r\nrole varchar(10) not null, \r\nemail varchar(100) not null, \r\nbalance decimal(10, 2),\r\ncreated_at date");
				CreateTable("ORDERS", "id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,\r\n  receiver_id INT not null,\r\n  order_price Decimal(10,2) not null,\r\n  order_drop Decimal(10,2) not null,\r\n  payment_type varchar(10) not null,\r\n  delivey_type varchar(10) not null,\r\n  status varchar(10) not null,\r\n  created_at date,\r\n  FOREIGN KEY (receiver_id) REFERENCES USERS (id)");
				CreateTable("ITEMS", "id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,\r\n  vendor_id INT not null,\r\n  title varchar(50) not null,\r\n  description varchar(500) not null,\r\n  model varchar(50) not null,\r\n  price Decimal(10,2) not null, \r\n  items_available INT not null,\r\n  created_at date,\r\n  FOREIGN KEY (vendor_id) REFERENCES USERS (id)");
				CreateTable("ORDERS_ITEMS", "order_id INT not null,\r\n  item_id INT not null,\r\n  item_count INT not null,\r\n  FOREIGN KEY (order_id) REFERENCES ORDERS (id),\r\n  FOREIGN KEY (item_id) REFERENCES ITEMS (id)");
				CreateTable("SUBSCRIPTIONS", "id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,\r\n  price Decimal(10,2) not null,\r\n  description varchar(100) not null, \r\n  type varchar(20) not null,\r\n  allowed_items_count INT not null,\r\n  term date");
				CreateTable("USERS_SUBSCRIPTIONS", "user_id INT not null,\r\n  sub_id INT not null,\r\n  status varchar(10) not null,\r\n  payment_date date,\r\n  FOREIGN KEY (user_id) REFERENCES USERS (id),\r\n  FOREIGN KEY (sub_id) REFERENCES SUBSCRIPTIONS (id)");
				CreateTable("PAYMENTS", "receiver_id INT not null, \r\n  vendor_id INT not null, \r\n  amount Decimal(10, 2) not null,\r\n  purpose varchar(20) not null,\r\n  FOREIGN KEY (receiver_id) REFERENCES USERS (id),\r\n  FOREIGN KEY (vendor_id) REFERENCES USERS (id)");
			}
        }
		private void CreateTable(string tableName, string columns)
		{
			try
			{
				SqlCommand cm = new SqlCommand($"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='{tableName}' and xtype='U')\r\nCREATE TABLE {tableName}(\r\n{columns})\r\n", connection);
				cm.ExecuteNonQuery();
                Console.WriteLine($"Table {tableName} was succesfully created");
            }
			catch(Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
		}
	}
}
