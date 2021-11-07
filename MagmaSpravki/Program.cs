using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagmaSpravki
{
    class Program
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Database.DefaultBase.Connect();
            Console.Title = "MagmaSoftware | Софтуер за справки | Версия 1.0 Stable";
            Console.Write($"[>] Здравей, {Environment.UserName}, моля запиши своя ник в MagmaCraft: ");
            var username = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("[>] Парола: ");
            var password = Console.ReadLine();
            Console.WriteLine("");
            Auth.Login.checkUser(username, password);
            if (Auth.Status.logged == true)
            {
            ListOptions:
                Auth.getPoints.checkPoints(username);
                Auth.getRole.Check(username);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] Проверка на текущите ви точки");
                Console.WriteLine("[2] Проверка на наказанията ви");
                Console.WriteLine("[3] Проверка на оставащи точки до 30лв ваучер награда");
                Console.WriteLine("[4] Проверка на оставащи точки до ранк ъп");
                Console.WriteLine("[5] [ADMIN ONLY] Добави точки");
                Console.WriteLine("[6] [ADMIN ONLY] Премахни точки");
                Console.WriteLine("[7] Списък със всички членове на екипа");
                Console.WriteLine("[8] [ADMIN ONLY] Добави нов член на екипа");
                Console.WriteLine("[9] Смени паролата си");
                Console.WriteLine("");
                Console.Write("[>] ");
                var option = Console.ReadLine();
                if(option == "9")
                {
                    Console.WriteLine("В следващия ъпдейт ...");
                    System.Threading.Thread.Sleep(1000);
                    goto ListOptions;
                }
                if (option == "8")
                {
                    if (Auth.getRole.fetchUser == "Admin")
                    {
                        try
                        {
                            Console.Write("[>] Username: ");
                            var userA = Console.ReadLine();
                            Console.Write("[>] Rank: ");
                            var ranka = Console.ReadLine();
                            Console.Write("[>] Точки: ");
                            var points = int.Parse(Console.ReadLine());
                            Auth.addstaffmember.addMember(userA, ranka, points, username);
                        }
                        catch (Exception error)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[ФАТАЛНА ГРЕШКА] {error.Message}");
                            System.Threading.Thread.Sleep(3000);
                            goto ListOptions;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[Грешка] Изглежда, че има още какво да направиш за да стигнеш до това меню :P");
                        System.Threading.Thread.Sleep(3000);
                    }
                }
                if (option == "7")
                {
                    Auth.getAll.getSladuri();
                }
                if (option == "1")
                {
                    Auth.getPoints.checkPoints(username);
                    Console.WriteLine($"{username}, вие имате общо {Auth.getPoints.points} точки !");
                    System.Threading.Thread.Sleep(1000);
                    goto ListOptions;
                }
                if(option == "2")
                {
                    Auth.getPunishments.checkPunishments(username);
                }
                if(option == "3")
                {
                    Console.WriteLine($"Остават ви {25 - Auth.getPoints.points} точки до 30лв ваучер !");
                    System.Threading.Thread.Sleep(1000);
                    goto ListOptions;
                }
                if(option == "4")
                {
                    Console.WriteLine($"Остават ви {20 - Auth.getPoints.points} точки до Promote !");
                    System.Threading.Thread.Sleep(1000);
                    goto ListOptions;
                }
                if (option == "5")
                {
                    if (Auth.getRole.fetchUser == "Admin")
                    {
                        try
                        {
                            Console.Write("[>] Потребител: ");
                            var addUser = Console.ReadLine();
                            Console.Write("[>] Колко точки да добавим? : ");
                            var pointToAdd = int.Parse(Console.ReadLine());
                            Auth.updatePoints.add(addUser, pointToAdd);
                        }
                        catch (Exception error)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[ФАТАЛНА ГРЕШКА] {error.Message}");
                            System.Threading.Thread.Sleep(3000);
                            goto ListOptions;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[Грешка] Изглежда, че има още какво да направиш за да стигнеш до това меню :P");
                        System.Threading.Thread.Sleep(3000);
                        goto ListOptions;
                    }
                }
                if (option == "6")
                {
                    if (Auth.getRole.fetchUser == "Admin")
                    {
                        try
                        {
                            Console.Write("[>] Потребител: ");
                            var addUser = Console.ReadLine();
                            Console.Write("[>] Колко точки да премахнем? : ");
                            var pointToAdd = int.Parse(Console.ReadLine());
                            Console.Write("[>] Причина: ");
                            var reasonremove = Console.ReadLine();
                            Auth.addrestriction.Add(addUser, reasonremove, username, pointToAdd);
                            Auth.updatePoints.remove(addUser, pointToAdd);
                            Auth.getPoints.checkPoints(addUser);
                            if(Auth.getPoints.points < 1)
                            {
                                Console.WriteLine($"Излгежда, че току-що всички точки на {addUser} свършиха :( трябва да бъде Demote !");
                                System.Threading.Thread.Sleep(2000);
                                goto ListOptions;
                            }
                        }
                        catch (Exception error)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[ФАТАЛНА ГРЕШКА] {error.Message}");
                            System.Threading.Thread.Sleep(3000);
                            goto ListOptions;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[Грешка] Изглежда, че има още какво да направиш за да стигнеш до това меню :P");
                        System.Threading.Thread.Sleep(3000);
                    }
                }
            }
        }
    }
}
