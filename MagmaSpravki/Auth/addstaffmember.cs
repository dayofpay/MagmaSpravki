using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MagmaSpravki.Auth
{
    class addstaffmember
    {
        public static int curPas { get; set; }
        public static void addMember(string username,string rank,int points,string add_by)
        {
            Random setPass = new Random();
            var getPass = setPass.Next(0001, 9999);
            curPas = getPass;
            MySqlCommand add = new MySqlCommand("INSERT INTO staffmembers(user,password,rank,current_points,added_by)VALUES('" + username + "','" + "magma" + getPass + "','" + rank + "','" + points + "','" + add_by + "')", Database.DefaultBase.connection);
            try
            {
                add.ExecuteScalar();
                Console.WriteLine($"[{rank}] {username} беше добавен в екипа, с парола magma{curPas} !");
                Console.WriteLine("Натиснете бутона X за да излезете");
                var button = Console.ReadKey();
                if (button.Key == ConsoleKey.X)
                {
                    Console.Clear();
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
