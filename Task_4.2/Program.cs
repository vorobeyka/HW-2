using System;
using Library;

namespace Task_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var ps = new PaymentService();
            try
            {
                ps.StartDeposit(3001, "UAH");
            }
            catch (LimitExceededException)
            {
                Console.WriteLine("Please, try to make a transaction with lower  amount or change the payment method");
            }
            catch (PaymentServiceException)
            {
                Console.WriteLine("Something went wrong. Try again later");
            }
            catch(InsufficientFundsException)
            {
                Console.WriteLine("Please, try to make a transaction with lower amount or change the payment mthod");
            }
            
        }
    }
}
