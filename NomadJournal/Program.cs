using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            string menu;

            var choice = new Choice();
            choice.DataInit();

            Console.WriteLine("\n\t\t Ж У Р Н А Л   N O M A D");
            while (true)
            {
                Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("\n\t\tГлавное меню:\n");
                Console.WriteLine("\t1 - Оформить подписку на журнал");
                Console.WriteLine("\t2 - Вход для клиентов");
                Console.WriteLine("\t3 - Вход для администратора");
                Console.WriteLine("\t0 - Выход\n");
                Console.Write("\tВаш выбор = ");
                menu = Console.ReadLine();

                if (menu == "0")
                {
                    break;
                }
                else if (menu == "1")   // оформление подписки
                {
                    choice.Subscription();
                }
                else if (menu == "2")   // 
                {
                    choice.InputClient();
                }
            }


        }
    }
}
