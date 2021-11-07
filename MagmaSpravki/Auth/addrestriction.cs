using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MagmaSpravki.Auth
{
    class addrestriction
    {
        public static void Add(string username,string reason,string issuer,int points)
        {
            MySqlCommand addRestrict = new MySqlCommand("INSERT INTO punishments(punish_date,punish_reason,punish_issuer,punish_user,punish_remove_points)VALUES('" + DateTime.Now.ToString() + "','" + reason + "','" + issuer + "','" + username + "','" +points + "')", Database.DefaultBase.connection);
            try
            {
                addRestrict.ExecuteScalar();
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
