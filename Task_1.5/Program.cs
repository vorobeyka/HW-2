using System;
using Library;

namespace Task_1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            var john = new Player("John Doe", "Betman", "john777@gmail.com", "TheP@$$w0rd", "USD");
            var password = "TheP@$$w0rd";
            var invalidPassword = "password";
            Console.WriteLine($"Login with login {john.Email} and password {password} is {john.IsPasswordValid(password)}");
            Console.WriteLine($"Login with login {john.Email} and password {invalidPassword} is {john.IsPasswordValid(invalidPassword)}");
            john.Deposit(100, "USD");
            john.Withdraw(50, "EUR");
            try
            {
                john.Withdraw(1000, "USD");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                var polandPlayer = new Player("Semen", "Potapov", "test@gmail.com", "12345", "PLN");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
