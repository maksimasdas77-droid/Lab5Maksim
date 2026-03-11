using Lab5Maksim.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            CultureInfo.CurrentUICulture = new CultureInfo("ru-RU");
            //BankAccount Bank = NewBankAccount();
            BankAccount b1 = NewBankAccount();
            BankAccount b2 = NewBankAccount();
            bool runing = true;
            while (runing) 
            {
                Console.Clear();
                Console.WriteLine("=====Меню=====");
                Console.WriteLine("1. Просмотр счетов.");
                Console.WriteLine("2. Внести депозит на счет");
                Console.WriteLine("3. Снять деньги со счета");
                Console.WriteLine("4. Перевести деньги с одного счета на другой");
                Console.WriteLine("5. вроде пункт не нужен, но на всякий случай оставлю");
                int choice = ReadClass.ReadValueWithCondition<int>("Выберите пункт меню (0 - для выхода): ", int.TryParse, value => value >= 0 && value <= 5, "Не правильный пункт меню. Попробуйте снова: ");
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Выход из программы.");
                        runing = false;
                        Console.ReadLine();
                        break;

                    case 1:
                        //Write(Bank);
                        Write(b1);
                        Write(b2);
                        Console.ReadLine();
                        break;
                    case 2:
                        //TestDeposit(Bank);
                        Console.WriteLine("Выберите счет для пополнения: ");
                        Console.Write("1. ");
                        Write(b1);
                        Console.Write("2. ");
                        Write(b2);
                        int choice2 = ReadClass.ReadValueWithCondition<int>(int.TryParse, x => x >= 0 && x <= 2, "Нет такого счета. Попробуйте снова: ");
                        if(choice2 == 1)
                        {
                            TestDeposit(b1);
                        } else if(choice2 == 2)
                        {
                            TestDeposit(b2);

                        }
                        else
                        {
                            break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Выберите счет для снятия: ");
                        Console.Write("1. ");
                        Write(b1);
                        Console.Write("2. ");
                        Write(b2);
                        int choice3 = ReadClass.ReadValueWithCondition<int>(int.TryParse, x => x >= 0 && x <= 2, "Нет такого счета. Попробуйте снова: ");
                        if (choice3 == 1)
                        {
                            TestWithdraw(b1);
                        }
                        else if (choice3 == 2)
                        {
                            TestWithdraw(b2);
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case 4:
                        Console.Write("1. ");
                        Write(b1);
                        Console.Write("2. ");
                        Write(b2);
                        int choice4 = ReadClass.ReadValueWithCondition<int>("Введите номер счета на который вы хотите перевести деньги с другого: ", int.TryParse, x => x >= 0 && x <= 2, "Нет такого счета. Попробуйте снова: ");
                        int mount = ReadClass.ReadValue<int>("Введите сумму для переброски: ", int.TryParse);
                        if (choice4 == 1)
                        {
                            Console.WriteLine("До трансфера");
                            Console.WriteLine("{0} {1} {2}", b1.Type(), (b1.Number() + 1), b1.Balance());
                            Console.WriteLine("{0} {1} {2}", b2.Type(), (b2.Number() + 1), b2.Balance());
                            b1.TransferFrom(b2, mount);
                            Console.WriteLine("После трансфера");
                            Console.WriteLine("{0} {1} {2}", b1.Type(), (b1.Number() + 1), b1.Balance());
                            Console.WriteLine("{0} {1} {2}", b2.Type(), (b2.Number() + 1), b2.Balance());
                        }
                        else if (choice4 == 2)
                        {
                            Console.WriteLine("До трансфера");
                            Console.WriteLine("{0} {1} {2}", b1.Type(), (b1.Number() + 1), b1.Balance());
                            Console.WriteLine("{0} {1} {2}", b2.Type(), (b2.Number() + 1), b2.Balance());
                            b2.TransferFrom(b1, mount);
                            Console.WriteLine("После трансфера");
                            Console.WriteLine("{0} {1} {2}", b1.Type(), (b1.Number() + 1), b1.Balance());
                            Console.WriteLine("{0} {1} {2}", b2.Type(), (b2.Number() + 1), b2.Balance());
                        }
                        else
                        {
                            break;
                        }

                        Console.ReadLine();
                        break;
                }
            }
        }

        static BankAccount NewBankAccount()
        {
            BankAccount created = new BankAccount();

            //long number = ReadClass.ReadValue<long>("Введите номер банковского аккаунта: ", long.TryParse);

            decimal balance = ReadClass.ReadValue<decimal>("Введите сумму аккаунта: ", decimal.TryParse);

            created.Populate(balance);

            return created;
        }

        static void Write(BankAccount acc) 
        {
            Console.WriteLine("======================");
            Console.WriteLine($"Номер аккаунта {acc.Number() +1}");
            Console.WriteLine($"Баланc {acc.Balance()}");
            Console.WriteLine($"Тип аккаунта {acc.Type()}");

        }

        public static void TestDeposit(BankAccount acc)
        {
            decimal amount = ReadClass.ReadValue<decimal>("Введите сумму депозита: ", decimal.TryParse);
            acc.Deposit(amount);
        }

        public static void TestWithdraw(BankAccount acc)
        {
            decimal amount = ReadClass.ReadValue<decimal>("Введите сумму к снятию: ", decimal.TryParse);
            if (!acc.Withdraw(amount))
            {
                Console.WriteLine("Недостаточно средств.");
                Console.ReadLine();
            }
        }
    }
}
