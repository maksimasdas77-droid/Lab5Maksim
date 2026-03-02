using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Maksim.Classes
{
   public class BankAccount
    {
        private long AccNo;
        private decimal AccBalance;
        private Enums.AccountType AccountType;
        private static long nextAccNo;

        public void Populate(decimal balance)
        {
            AccNo = NextNumber();
            AccBalance = balance;
            AccountType = Enums.AccountType.Checking;

        }

        public long Number()
        {
            return AccNo;
        }

        public decimal Balance()
        {
            return AccBalance;
        }

        public string Type()
        {
            return AccountType.ToString();
        }

        public static long NextNumber()
        {
            return nextAccNo++;
        }

        public decimal Deposit(decimal amount) 
        {
            AccBalance += amount;
            return AccBalance;
        }

        public bool Withdraw(decimal amount)
        {
            bool sufficientFunds = AccBalance >= amount;
            if (sufficientFunds)
            { 
                AccBalance -= amount;
            }
            return sufficientFunds;
        }

        public void TransferFrom(BankAccount accFrom, decimal amount)
        {
            if (accFrom.Withdraw(amount))
            {
                this.Deposit(amount);
            }
            else 
            {
                Console.WriteLine("Не достаточно средств на счете-доноре");
            }
        }
    }

}
