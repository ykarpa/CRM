using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBinit
{
	public class DbInitTask
	{
		public static void CreateTables(DataBase db)
		{
			string usersQuery = SQLQueryBuilder.CreateTable("users", "id serial primary key,\r\n    first_name varchar(50) not null,\r\n    last_name  varchar(50) not null,\r\n    birth_date date        not null,\r\n    role       varchar(15) not null,\r\n    email      varchar(50) not null unique,\r\n    balance    int         not null,\r\n    created_at date");
			string ordersQuery = SQLQueryBuilder.CreateTable("orders", "    id            serial PRIMARY KEY,\r\n    receiver_id   INT            not null,\r\n    order_price   Decimal(10, 2) not null,\r\n    order_drop    Decimal(10, 2) not null,\r\n    payment_type  varchar(10)    not null,\r\n    delivery_type varchar(10)    not null,\r\n    status        varchar(10)    not null,\r\n    created_at    date,\r\n    FOREIGN KEY (receiver_id) REFERENCES users (id)");
			string itemsQuery = SQLQueryBuilder.CreateTable("items", "  id              serial PRIMARY KEY,\r\n    vendor_id       INT            not null,\r\n    title           varchar(50)    not null,\r\n    description     varchar(500)   not null,\r\n    model           varchar(50)    not null,\r\n    price           Decimal(10, 2) not null,\r\n    items_available INT            not null,\r\n    created_at      date,\r\n    FOREIGN KEY (vendor_id) REFERENCES users (id)");
			string orderItemsQuery = SQLQueryBuilder.CreateTable("order_item", "order_id INT not null,\r\n  item_id INT not null,\r\n  item_count INT not null,\r\n  FOREIGN KEY (order_id) REFERENCES orders (id),\r\n  FOREIGN KEY (item_id) REFERENCES items (id)");
			string subscriptionsQuery = SQLQueryBuilder.CreateTable("subscriptions", "  id              serial PRIMARY KEY,\r\n    vendor_id       INT            not null,\r\n    title           varchar(50)    not null,\r\n    description     varchar(500)   not null,\r\n    model           varchar(50)    not null,\r\n    price           Decimal(10, 2) not null,\r\n    items_available INT            not null,\r\n    created_at      date,\r\n    FOREIGN KEY (vendor_id) REFERENCES users (id)");
			string usersSubscriptionsQuery = SQLQueryBuilder.CreateTable("users_subscriptions", "    user_id      INT         not null,\r\n    sub_id       INT         not null,\r\n    status       varchar(10) not null,\r\n    payment_date date,\r\n    FOREIGN KEY (user_id) REFERENCES users (id),\r\n    FOREIGN KEY (sub_id) REFERENCES subscriptions (id)");
			string payments = SQLQueryBuilder.CreateTable("payments", "    user_id      INT         not null,\r\n    sub_id       INT         not null,\r\n    status       varchar(10) not null,\r\n    payment_date date,\r\n    FOREIGN KEY (user_id) REFERENCES users (id),\r\n    FOREIGN KEY (sub_id) REFERENCES subscriptions (id)");
			string[] queries = new string[] { usersQuery, ordersQuery, itemsQuery, orderItemsQuery, subscriptionsQuery, usersSubscriptionsQuery, payments };
			foreach (string query in queries)
			{
				db.ExecuteNonQuery(query);
		}
	}

		public static void FillUsersTable()
		{

		}

		public static void FillOrdersTable()
		{

		}

		public static void FillItemsTable()
		{

		}

		public static void FillOrderItemsTable()
		{

		}

		public static void FillSubscriptionsTable()
		{

		}

		public static void FillUsersSubscriptionsTable()
		{

		}

		public static void FillPaymentsTable()
		{

		}

	}
}
