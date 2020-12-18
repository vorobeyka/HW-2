using System;
using Library;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var account1 = new Account("EUR");
            var account2 = new Account("USD");
            var account3 = new Account("UAH");
            account1.Deposit(10, "EUR");
            account1.Withdraw(3, "UAH");
            account3.Deposit(121, "USD");
            try
            {
                account2.Withdraw(5, "USD");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                var invalidAccount = new Account("PLN");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Account with currency {account1.Currency} has {account1.GetBalance("EUR")} balance");
            Console.WriteLine($"Account with currency {account2.Currency} has {account1.GetBalance("USD")} balance");
            Console.WriteLine($"Account with currency {account2.Currency} has {account1.GetBalance("UAH")} balance");
        }
    }
}
