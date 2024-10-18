using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Ordering_taxi
{
    internal class DbWorker
    {

        private const string ConnectionString = "server=localhost;port=3306;userid=root;password=root;" +
        "charset=utf8mb4;database=ordering_taxi;sslmode=none";

        public MySqlConnection Connect()
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(ConnectionString);
                connection.Open();
                Console.WriteLine("Подключение к БД успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при подключении к MySQL: {ex.Message}");
            }
            return connection;
        }
    }
}
