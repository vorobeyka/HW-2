using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Stereobank : Bank
    {
        public Stereobank()
        {
            SumOfTransactions = 0;
            Name = "Stereobank";
            AvailableCards = new string[] { "Black", "White", "Iron" };
            TransactionsLimit = 7000;
        }
    }
}
