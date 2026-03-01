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
            BankAccount Berts = NewBankAccount();
            Write(Berts);
            TestDeposit(Berts);
            Write(Berts);
            TestWithdraw(Berts);
            Write(Berts);

            BankAccount Freds = NewBankAccount();
            Write(Freds);
            TestDeposit(Freds);
            Write(Freds);
            Console.ReadLine();
            TestWithdraw(Freds);
            Write(Freds);

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
            Console.WriteLine("Account number is {0}", acc.Number());
            Console.WriteLine("Account balance is {0}", acc.Balance());
            Console.WriteLine("Account type is {0}", acc.Type());
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
            }
        }
    }
}
