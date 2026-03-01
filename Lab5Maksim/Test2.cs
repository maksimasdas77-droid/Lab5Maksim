using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Maksim
{
    internal class Test2
    {
        public static void Main()
        {
            string message;
            Console.WriteLine("Введите сообщение для реверса:");
            message = Console.ReadLine();

            Utills.Reverse(ref message);

            Console.WriteLine(message);

        }
    }
}
