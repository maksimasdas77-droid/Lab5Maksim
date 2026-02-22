using Lab5Maksim.Exercise;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Maksim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                menu.Show();
                int choice = readclas.ReadValue<int>("Выберите пункт меню: ", int.TryParse);
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Выход из программы...");
                        run = false;
                        break;
                    case 1:
                        Ex1 ex = new Ex1();
                        ex.Exercise1(args);
                        Console.ReadLine();
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    default:
                        Console.WriteLine("Нет такого пункта меню");
                        Console.ReadLine();
                        break;
                }
            }

        }
    }
}
