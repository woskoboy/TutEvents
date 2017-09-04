using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем банковский счет
            Account account = new Account(200, 6);
            // Добавляем в делегат ссылку на метод Show_Message
            // а сам делегат передается в качестве параметра метода RegisterHandler
            account.RegisterHandler(new Account.AccountStateHandler(Show_Message));
            // Два раза подряд пытаемся снять деньги
            account.Withdraw(100);
            account.Withdraw(150);

            Console.ReadKey();
        }
        private static void Show_Message(String message)
        {
            Console.WriteLine(message);
        }
    }
}
