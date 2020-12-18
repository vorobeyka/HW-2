using System;
using Library;

namespace Task_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PaymentService();

            service.StartDeposit(100, "USD");
            service.StartWithdrawal(50, "USD");
            service.StartWithdrawal(50, "USD");
            service.StartDeposit(50, "USD");
            service.StartWithdrawal(50, "USD");
            service.StartDeposit(50, "USD");
            service.StartDeposit(500, "USD");
            service.StartDeposit(500, "USD");
        }
    }
}
