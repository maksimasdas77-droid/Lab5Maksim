//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Lab5Maksim.Classes;

//namespace Lab5Maksim
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            bool run = true;
//            while (run)
//            {
//                MainMenu.ShowMainMenu();
//                int choice = ReadClass.ReadValue<int>("Выберите пункт меню: ", int.TryParse);
//                switch (choice)
//                {
//                    case 0:
//                        Console.WriteLine("Выход из программы...");
//                        run = false;
//                        break;
//                    case 1:
//                        Console.WriteLine("Создание банковского аккаунта");
//                        long number = ReadClass.ReadValue<long>("Введите номер банковского аккаунта", long.TryParse);
//                        decimal balance = ReadClass.ReadValue<decimal>("Введите баланс банковского счета", decimal.TryParse);

//                        Classes.BankAccount.Populate(number, balance);
//                        break;
//                    case 2:

//                        break;
//                    case 3:
//                        Console.WriteLine("пока не готово");
//                        Console.ReadLine();
//                        break;
//                    case 4:
//                        Console.WriteLine("пока не готово");
//                        Console.ReadLine();
//                        break;
//                    default:
//                        Console.WriteLine("Нет такого пункта меню");
//                        Console.ReadLine();
//                        break;
//                }
//            }

//        }
//    }
//}
