using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MagmaSpravki.Auth
{
    class getPunishments
    {
        public static int totalPunishments
        {
            get;
            set;
        }
        public static void checkPunishments(string username)
        {
            MySqlCommand checkPunish = new MySqlCommand("SELECT * FROM punishments WHERE punish_user = '" + username + "'", Database.DefaultBase.connection);
            using (MySqlDataReader readPunishments = checkPunish.ExecuteReader())
            {
                while (readPunishments.Read())
                {
                    Console.WriteLine($"Дата > {readPunishments.GetString(0)}");
                    Console.WriteLine($"Причина за наказание > {readPunishments.GetString(1)}");
                    Console.WriteLine($"Наказанието е от > {readPunishments.GetString(2)}");
                    Console.WriteLine($"Премахнати точки > {readPunishments.GetInt32(4)}");
                }
                readPunishments.Close();
                Console.WriteLine("Натиснете бутона X за да излезете");
                var button = Console.ReadKey();
                if(button.Key == ConsoleKey.X)
                {
                    Console.Clear();
                    Program.Main();
                }
            }
        }
    }
}
