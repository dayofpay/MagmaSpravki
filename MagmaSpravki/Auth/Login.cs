using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MagmaSpravki.Auth
{
    class Login
    {
        public static void checkUser(string username,string password)
        {
            MySqlCommand loginUser = new MySqlCommand("SELECT user FROM staffmembers WHERE user = '" + username + "'" + "AND password='"+password+"'" , Database.DefaultBase.connection);
            try
            {
                using (MySqlDataReader readUser = loginUser.ExecuteReader())
                {
                    if (readUser.HasRows)
                    {
                        Console.WriteLine($"[>] Успешен вход, {username} !");
                        Auth.Status.logged = true;
                    }
                    else
                    {
                        Auth.Status.logged = false;
                        Console.WriteLine("[>] Неправилна парола или username !");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        Program.Main();
                    }
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
