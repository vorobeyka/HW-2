using System;
using Library;

namespace Task_4._1
{
    class Program
    {
        static void InsufficientHandle()
        {
            int a;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a == 0) throw new InsufficientFundsException("Insufficient Exception");
            }
            catch (InsufficientFundsException)
            {
                throw;
            }
        }

        static void LimitHandle()
        {
            try
            {
                InsufficientHandle();
            }
            catch (InsufficientFundsException ex)
            {
                throw new LimitExceededException(ex.Message + " + Limit Exception");
            }
        }

        static void PaymentHandle()
        {
            try
            {
                LimitHandle();
            }
            catch (LimitExceededException ex)
            {
                throw new PaymentServiceException(ex.Message + " + Payment Exception");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                string str = Console.ReadLine();
                if (str == "lol") throw new LimitExceededException("Limit Exception");
                PaymentHandle();
            }
            catch (PaymentServiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (LimitExceededException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
