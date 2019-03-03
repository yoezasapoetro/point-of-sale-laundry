using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace LaundryApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void ChangeMySqlConnectionString()
        {
            string connectionString = "server=localhost;user id=root;database=laundryapp";
            string providerName = "MySql.Data.MySqlClient";

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.ConnectionStrings.ConnectionStrings["OrderEntities"].ConnectionString = connectionString;
            config.ConnectionStrings.ConnectionStrings["OrderEntities"].ProviderName = providerName;
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
