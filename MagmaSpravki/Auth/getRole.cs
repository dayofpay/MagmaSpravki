using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MagmaSpravki.Auth
{
    class getRole
    {
        public static string fetchUser
        {
            get;
            set;
        }
        public static void Check(string username)
        {
            MySqlCommand checkUser = new MySqlCommand("SELECT rank FROM staffmembers WHERE user = '" + username + "'", Database.DefaultBase.connection);
            try
            {
                using (MySqlDataReader readRole = checkUser.ExecuteReader())
                {
                    while (readRole.Read())
                    {
                        fetchUser = readRole.GetString(0);
                    }
                    readRole.Close();
                }
            }
            catch (MySqlException error)
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
