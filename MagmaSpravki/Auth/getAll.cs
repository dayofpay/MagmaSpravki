using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MagmaSpravki.Auth
{
    class getAll
    {
        public static int totalStaff
        {
            get;
            set;
        }
        public static void getSladuri()
        {
            MySqlCommand getStaff = new MySqlCommand("SELECT user,rank,current_points FROM staffmembers", Database.DefaultBase.connection);
            try
            {
                using (MySqlDataReader readStaff = getStaff.ExecuteReader())
                {
                    while (readStaff.Read())
                    {
                        totalStaff++;
                        Console.WriteLine($"[{readStaff.GetString(0)}] | {readStaff.GetString(1)} | {readStaff.GetInt16(2)} Точки ");
                    }
                    readStaff.Close();
                    Console.WriteLine($"В екипа има общо {totalStaff} сладури :D");
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Натиснете бутона X за да излезете");
                    var button = Console.ReadKey();
                    if (button.Key == ConsoleKey.X)
                    {
                        Console.Clear();
                        Program.Main();
                    }
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
