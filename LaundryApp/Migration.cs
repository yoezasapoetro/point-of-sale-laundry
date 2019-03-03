using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryApp.Migration
{
    public class Migration
    {
        string User { get { return "pos"; } }
        string Password { get { return "ini izip0s"; } }
        string DatabaseName { get { return "laundryapp"; } }

        MySqlConnection conn = null;

        public void ExecuteMigrationSqlCommand()
        {
            ExecuteSqlConnection(MigrationConnection, string.Join("", SqlStringMigration), "Preparing Migrations...", "End");
        }

        public void ExecuteDefaultSqlCommand()
        {
            ExecuteSqlConnection(DefaultConnection, string.Join("", SqlStringCreateUser), "Preparing Default Migrations...", "Order Migrations...");
        }

        private MySqlConnection MigrationConnection
        {
            get
            {
                string connStr = $"Server=localhost; UID={User}; Password={Password}; Database={DatabaseName}";
                conn = new MySqlConnection(connStr);
                conn.Open();
                return conn;
            }
        }

        private MySqlConnection DefaultConnection
        {
            get
            {
                string connStr = "Server=localhost; UID=root; Database=mysql";
                conn = new MySqlConnection(connStr);
                conn.Open();
                return conn;
            }
        }

        private void ExecuteSqlConnection(MySqlConnection conn, string sql, string segment = "", string doneSegment = "")
        {
            try
            {
                Console.WriteLine(segment);

                MySqlScript script = new MySqlScript(conn, sql);

                script.Error += new MySqlScriptErrorEventHandler(script_Error);
                script.ScriptCompleted += new EventHandler(script_ScriptCompleted);
                script.StatementExecuted += new MySqlStatementExecutedEventHandler(script_StatementExecuted);

                int count = script.Execute();

                Console.WriteLine("Executed " + count + " statement(s).");
                Console.WriteLine("Delimiter: " + script.Delimiter);
            }
            catch (Exception ex)
            {
                ExecuteSqlConnection(MigrationConnection, string.Join("", SqlStringDrop));
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine(doneSegment);
        }

        private void script_StatementExecuted(object sender, MySqlScriptEventArgs args)
        {
            Console.WriteLine("script_StatementExecuted");
        }

        private void script_ScriptCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("script_ScriptCompleted!");
        }

        private void script_Error(Object sender, MySqlScriptErrorEventArgs args)
        {
            Console.WriteLine("script_Error: " + args.Exception.ToString());
        }

        private string[] SqlStringDrop
        {
            get
            {
                return new string[]
                {
                    "ALTER TABLE `OrderItem` DROP FOREIGN KEY IF EXISTS `OrderItem_ForeignKey`;",
                    "ALTER TABLE `OrderItem` DROP INDEX IF EXISTS `OrderItem_ForeignKey`;",
                    "DROP TABLE IF EXISTS `OrderItem`;",
                    "DROP TABLE IF EXISTS `Order`;",
                    "DROP DATABASE IF EXISTS `laundryapp`"
                };
            }
        }

        private string[] SqlStringCreateUser
        {
            get
            {
                return new string[]
                {
                    $"CREATE USER IF NOT EXISTS '{User}'@'localhost' IDENTIFIED BY '{Password}';",
                    $"CREATE DATABASE IF NOT EXISTS {DatabaseName};",
                    $"GRANT ALL PRIVILEGES ON {DatabaseName}.* TO '{User}'@'localhost' WITH GRANT OPTION"
                };
            }
        }

        private string[] SqlStringMigration
        {
            get
            {
                return new string[]
                {
                    "SET FOREIGN_KEY_CHECKS = 0;",
                    "CREATE TABLE IF NOT EXISTS `Order` (" +
                        "`OrderId` int(4) NOT NULL PRIMARY KEY AUTO_INCREMENT," +
                        "`CustomerName` varchar(50) NOT NULL," +
                        "`Date` datetime NOT NULL," +
                        "`Weight` double NOT NULL," +
                        "`ServiceType` varchar(50) NOT NULL," +
                        "`Price` double NOT NULL," +
                        "`CurrentActivity` varchar(50) NOT NULL," +
                        "`IsPaid` tinyint(1) NOT NULL DEFAULT '0'," +
                        "`FinishAt` timestamp NULL DEFAULT NULL) ENGINE=InnoDB;",
                    "CREATE TABLE IF NOT EXISTS `OrderItem` (" +
                        "`OrderItemId` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY," +
                        "`OrderId` int(4) NOT NULL," +
                        "`ItemName` varchar(150) NOT NULL," +
                        "`ItemQty` int(11) NOT NULL," +
                        "`ItemPrice` double NOT NULL," +
                        "KEY `OrderId` (`OrderId`)," +
                        "CONSTRAINT `OrderItem_ForeignKey` FOREIGN KEY (`OrderId`) REFERENCES `Order` (`OrderId`)) ENGINE=InnoDB;",
                    "SET FOREIGN_KEY_CHECKS = 1;"
                };
            }
        }
    }
}
