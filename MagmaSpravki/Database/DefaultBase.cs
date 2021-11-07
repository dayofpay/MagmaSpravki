using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MagmaSpravki.Database
{
    class DefaultBase
    {
        public static MySqlConnection connection { get; set; }
        public static string server { get; set; }
        public static string database { get; set; }
        public static string user { get; set; }
        public static string password { get; set; }
        public static string port { get; set; }
        public static string connectionString { get; set; }
        public static string sslM { get; set; }
        public static string conString { get; set; }
        public static void Connect()
        {
            try
            {
                server = "45.144.155.126";
                database = "s673_panel";
                user = "u673_3U39cgtcTy";
                password = "ZUGCYDk.YHPoKAxAsglM=q9W";
                port = "3306";
                sslM = "none";
                connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);
                conString = connectionString;
                connection = new MySqlConnection(conString);
                connection.Open();
            }
            catch(MySqlException error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ФАТАЛНА ГРЕШКА] {error.Message}");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Program.Main();
            }
        }
    }
}
