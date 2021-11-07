using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MagmaSpravki.Auth
{
    class getPoints
    {
        public static int points
        {
            get;
            set;
        }
        public static void checkPoints(string username)
        {
            MySqlCommand gPoints = new MySqlCommand("SELECT current_points FROM staffmembers WHERE user = '" + username + "'", Database.DefaultBase.connection);
            try
            {
                using (MySqlDataReader readPoints = gPoints.ExecuteReader())
                {
                    while (readPoints.Read())
                    {
                        points = readPoints.GetInt32(0);
                    }
                    readPoints.Close();
                }
            }catch(MySqlException error)
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
