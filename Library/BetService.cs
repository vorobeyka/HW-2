using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class BetService
    {
        private Random rnd = new Random();
        private decimal Odd { get; set; }

        public BetService()
        {
            int randomInt = rnd.Next(1, 25);
            double randomDouble = rnd.Next(1, 101) / 100.0;
            Odd = Math.Round((decimal)(randomInt + randomDouble), 2);
        }

        public float GetOdds()
        {
            int randomInt = rnd.Next(1, 25);
            double randomDouble = rnd.Next(1, 101) / 100.0;
            Odd = Math.Round((decimal)(randomInt + randomDouble), 2);
            return (float)Odd;
        }

        private bool IsWon()
        {
            int chance = (int)(100 / Odd);
            int randomValue = rnd.Next(1, 101);
            return randomValue <= chance;
        }

        public decimal Bet(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(nameof(amount));
            }
            return IsWon() ? amount * Odd : 0;
        }
    }
}
