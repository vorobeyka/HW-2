using System;
using System.Threading;
using Library;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var bet = new BetService();
            float odd = 0;

            for (int i = 0; i < 10; i++)
            {
                odd = bet.GetOdds();
            }
            Console.WriteLine($"I've bet 100 USD with the odd {odd} and I've earned {bet.Bet(100)}");

            for (int i = 1; i <= 3; )
            {
                if ((odd = bet.GetOdds()) > 12)
                {
                    Console.WriteLine($"I've bet 100 USD with the odd {odd} and I've earned {bet.Bet(100)}");
                    i++;
                }
            }

            var allAmount = 10000m;
            while (allAmount > 0 && allAmount < 15000)
            {
                if (bet.GetOdds() < 1.5f)
                {
                    var amount = allAmount < 1000 ? allAmount : 1000;
                    allAmount -= amount;
                    allAmount += bet.Bet(amount);
                }
            }
            Console.WriteLine($"Game over. My balance is {allAmount}");
        }
    }
}
