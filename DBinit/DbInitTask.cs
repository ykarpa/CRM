using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBinit
{
    public class DbInitTask
    {
        private static Random r = new Random();
        public static void CreateTables(DataBase db)
        {
            string usersQuery = SQLQueryBuilder.CreateTable("users", "id serial primary key,\r\n    first_name varchar(50) not null,\r\n    last_name  varchar(50) not null,\r\n    birth_date date        not null,\r\n    role       varchar(15) not null,\r\n    email      varchar(50) not null unique,\r\n    balance    int         not null,\r\n    created_at date");
            string ordersQuery = SQLQueryBuilder.CreateTable("orders", "    id            serial PRIMARY KEY,\r\n    receiver_id   INT            not null,\r\n    order_price   Decimal(10, 2) not null,\r\n    order_drop    Decimal(10, 2) not null,\r\n    payment_type  varchar(10)    not null,\r\n    delivery_type varchar(10)    not null,\r\n    status        varchar(10)    not null,\r\n    created_at    date,\r\n    FOREIGN KEY (receiver_id) REFERENCES users (id) ON DELETE SET NULL");
            string itemsQuery = SQLQueryBuilder.CreateTable("items", "  id              serial PRIMARY KEY,\r\n    vendor_id       INT            not null,\r\n    title           varchar(50)    not null,\r\n    description     varchar(500)   not null,\r\n    model           varchar(50)    not null,\r\n    price           Decimal(10, 2) not null,\r\n    items_available INT            not null,\r\n    created_at      date,\r\n    FOREIGN KEY (vendor_id) REFERENCES users (id) ON DELETE SET NULL");
            string orderItemsQuery = SQLQueryBuilder.CreateTable("order_item", "order_id INT not null,\r\n  item_id INT not null,\r\n  item_count INT not null,\r\n  FOREIGN KEY (order_id) REFERENCES orders (id),\r\n  FOREIGN KEY (item_id) REFERENCES items (id) ON DELETE SET NULL");
            string subscriptionsQuery = SQLQueryBuilder.CreateTable("subscriptions", "  id serial PRIMARY KEY,\r\n price Decimal(10,2) not null,\r\n description varchar(100) not null,\r\n type varchar(20) not null,\r\n allowed_items_count INT not null,\r\n term date not null");
            string usersSubscriptionsQuery = SQLQueryBuilder.CreateTable("users_subscriptions", "    user_id      INT         not null,\r\n    sub_id       INT         not null,\r\n    status       varchar(10) not null,\r\n    payment_date date,\r\n    FOREIGN KEY (user_id) REFERENCES users (id) ON DELETE SET NULL,\r\n    FOREIGN KEY (sub_id) REFERENCES subscriptions (id) ON DELETE SET NULL");
            string payments = SQLQueryBuilder.CreateTable("payments", "receiver_id INT not null,\r\n vendor_id INT not null,\r\n amount Decimal(10, 2) not null,\r\n purpose varchar(20) not null,\r\n    FOREIGN KEY (receiver_id) REFERENCES users (id) ON DELETE SET NULL,\r\n    FOREIGN KEY (vendor_id) REFERENCES users (id) ON DELETE SET NULL");
            string[] queries = new string[] { usersQuery, ordersQuery, itemsQuery, orderItemsQuery, subscriptionsQuery, usersSubscriptionsQuery, payments };
            foreach (string query in queries)
            {
                db.ExecuteNonQuery(query);
            }
        }

        public static void FillUsersTable(DataBase db)
        {
            string[] firstNames = { "Ivan", "Olena", "Andrii", "Kateryna", "Mykola", "Tetiana", "Oleksandr", "Nataliia" };
            int fNamesLength = firstNames.Length;
            string[] lastNames = { "Kovalenko", "Petrenko", "Tkachenko", "Shevchenko", "Melnik", "Moroz", "Sydorenko", "Ivanenko" };
            int lNamesLength = lastNames.Length;
            string[] roles = { "Vendor", "Buyer" };
            for (int i = 0; i < 50; ++i)
            {
                string fName = firstNames[r.Next(0, fNamesLength)];
                string lName = lastNames[r.Next(0, lNamesLength)];
                string role = roles[r.Next(0, 2)];
                string email = $"{fName.ToLower()}.{lName.ToLower()}@gmail.com";
                DateTime createdAt = DateTime.Now;
                DateTime birthDate = createdAt.GenerateRandomDate();
                int balance = r.Next(0, 1001);
                try
                {
                    string query = $"INSERT INTO users (first_name, last_name, birth_date, role, email, balance, created_at) values " +
                        $"('{fName}', '{lName}', '{birthDate.ToString("yyyy-MM-dd")}', '{role}', '{email}', {balance}, '{createdAt.ToString("yyyy-MM-dd")}');";
                    db.ExecuteNonQuery(query);

                }
                catch (DbException ex)
                {
                    Console.WriteLine("Error while inserting random data into users: " + ex.Message);
                }
            }
        }

        public static void FillOrdersTable(DataBase db)
        {
            //string[] payment_types = { "Full prepayment", "Upon receipt" };
            //string[] delivery_types = { "Self pickup", "Nova Poshta", "Ukrposhta" };
            //string[] statuses = { "Sent", "Delivered", "Awaiting payment", "Successfully", "Returned" };

            //for (int i = 0; i < 50; ++i)
            //{
            //    var receiver_id = db.ExecuteReaderQuery($"SELECT id FROM users;"); //?

            //    double order_price = r.NextDouble() * 1000;
            //    double order_drop = order_price * 0.95;
            //    string payment_type = payment_types[r.Next(2)];
            //    string delivery_type = delivery_types[r.Next(3)];
            //    string status = statuses[r.Next(5)];
            //    DateTime createdAt = DateTime.Now;

            //    try
            //    {
            //        db.ExecuteNonQuery($"INSERT INTO orders (receiver_id, order_price, order_drop, payment_type, delivery_type, status, created_at) VALUES " +
            //            $"('{receiver_id}', '{order_price}', '{order_drop}', '{payment_type}', '{delivery_type}', '{status}', '{createdAt.ToString("yyyy-MM-dd")}');");
            //    }
            //    catch (DbException ex)
            //    {
            //        Console.WriteLine("Error while inserting random data into users: " + ex.Message);
            //    }
            //}
        }



        public static void FillItemsTable(DataBase db)
        {
            //string[] titles = { "", "" };
            //string[] descriptions = { "", "" };
            //string[] models = { "", "" };

            //for (int i = 0; i < 50; ++i)
            //{
            //    //var vendor_id = db.ExecuteReaderQuery($"SELECT id FROM users;"); //?

            //    string title = titles[r.Next(2)];
            //    string description = descriptions[r.Next(3)];
            //    string model = models[r.Next(4)];
            //    double price = r.NextDouble() * 1000;
            //    int item_available = r.Next(0, 1000);
            //    DateTime createdAt = DateTime.Now;

            //    try
            //    {
            //        db.ExecuteNonQuery($"INSERT INTO items (vendor_id, title, description, model, price, item_available, created_at) VALUES " +
            //            $"('{vendor_id}', '{title}', '{description}', '{model}', '{price}', '{item_available}', '{createdAt.ToString("yyyy-MM-dd")}');");
            //    }
            //    catch (DbException ex)
            //    {
            //        Console.WriteLine("Error while inserting random data into users: " + ex.Message);
            //    }
            //}
        }

        public static void FillOrderItemsTable(DataBase db)
        {
            //for (int i = 0; i < 50; ++i)
            //{
            //    //var order_id = db.ExecuteReaderQuery($"SELECT id FROM order;"); //?
            //    //var item_id = db.ExecuteReaderQuery($"SELECT id FROM item;"); //?

            //    int item_count = r.Next(0, 100);

            //    try
            //    {
            //        db.ExecuteNonQuery($"INSERT INTO order_item (order_id, item_id, item_count) VALUES " +
            //            $"('{order_id}', '{item_id}', '{item_count}');");
            //    }
            //    catch (DbException ex)
            //    {
            //        Console.WriteLine("Error while inserting random data into users: " + ex.Message);
            //    }
            //}
        }

        public static void FillSubscriptionsTable(DataBase db)
        {
            //string[] descriptions = { "", "" };
            //string[] models = { "", "" };

            //for (int i = 0; i < 50; ++i)
            //{
            //    string description = descriptions[r.Next(3)];
            //    string model = models[r.Next(4)];
            //    double price = r.NextDouble() * 1000;
            //    int item_available = r.Next(0, 1000);

            //    try
            //    {
            //        db.ExecuteNonQuery($"INSERT INTO items (vendor_id, title, description, model, price, item_available, created_at) VALUES " +
            //            $"('{vendor_id}', '{title}', '{description}', '{model}', '{price}', '{item_available}', '{createdAt.ToString("yyyy-MM-dd")}');");
            //    }
            //    catch (DbException ex)
            //    {
            //        Console.WriteLine("Error while inserting random data into users: " + ex.Message);
            //    }
            //}
        }

        public static void FillUsersSubscriptionsTable(DataBase db)
        {

        }

        public static void FillPaymentsTable(DataBase db)
        {

        }

    }
}