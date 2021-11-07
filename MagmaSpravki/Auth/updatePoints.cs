using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MagmaSpravki.Auth
{
    class updatePoints
    {
        public static void add(string username,int points)
        {
            MySqlCommand updatePoint = new MySqlCommand("UPDATE staffmembers SET current_points = current_points + " + points, Database.DefaultBase.connection);
            try
            {
                if(points < 1)
                {
                    Console.WriteLine("Числото не може да бъде по-малко от 1");
                    System.Threading.Thread.Sleep(2000);
                    Program.Main();
                }
                if(points == 1)
                {
                    Console.WriteLine($"Успешно добавихте {points} точка на {username}");
                    updatePoint.ExecuteScalar();
                    System.Threading.Thread.Sleep(3000);
                    Program.Main();
                }
                if(points > 1)
                {
                    Console.WriteLine($"Успешно добавихте {points} точки на {username}");
                    updatePoint.ExecuteScalar();
                    System.Threading.Thread.Sleep(3000);
                    Program.Main();
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
        public static void remove(string username, int points)
        {
            MySqlCommand updatePoint = new MySqlCommand("UPDATE staffmembers SET current_points = current_points - " + points, Database.DefaultBase.connection);
            try
            {
                if (points < 1)
                {
                    Console.WriteLine("Числото не може да бъде по-малко от 1");
                    System.Threading.Thread.Sleep(2000);
                    Program.Main();
                }
                if (points == 1)
                {
                    Console.WriteLine($"Успешно премахнахте {points} точка на {username}");
                    updatePoint.ExecuteScalar();
                    System.Threading.Thread.Sleep(3000);
                    Program.Main();
                }
                if (points > 1)
                {
                    Console.WriteLine($"Успешно премахнате {points} точки на {username}");
                    updatePoint.ExecuteScalar();
                    System.Threading.Thread.Sleep(3000);
                    Program.Main();
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
