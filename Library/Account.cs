using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Account
    {
        private static List<int> _uniqueIds = new List<int>(1);

        public int Id { get; }
        public string Currency { get; }
        private decimal Amount { get; set; } = 0;
        private decimal _transUSD { get; } = 1;
        private decimal _transEUR { get; } = 1;
        private decimal _transUAH { get; } = 1;

        public Account(string currency)
        {
            switch (currency)
            {
                case "UAH":
                    _transUSD = 28.36M;
                    _transEUR = 33.63M;
                    break;
                case "USD":
                    _transUAH = 1M / 28.36M;
                    _transEUR = 1.19M;
                    break;
                case "EUR":
                    _transUSD = 1 / 1.19M;
                    _transUAH = 1 / 33.63M;
                    break;
                default: throw new NotSupportedException(nameof(currency));
            }
            Currency = currency;
            // if (_uniqueIds.Capacity == 1)
            // {
                // _uniqueIds.Add(999999);
            // }
            // int countIds = _uniqueIds.Count;
            // _uniqueIds.Add(_uniqueIds[countIds - 1] + 1);
            // Id = _uniqueIds[countIds];
            if (_uniqueIds.Capacity == 1)
            {
                _uniqueIds.Add(100000000);
            }
            int countIds = _uniqueIds.Count;
            if (_uniqueIds[countIds - 1] == 100000)
            {
                throw new Exception("Can't create Id. Platform have maximum accounts");
            }
            _uniqueIds.Add(_uniqueIds[countIds - 1] - 1);
            Id = _uniqueIds[countIds];
        }

        public void Deposit(decimal amount, string currency)
        {
            if (amount <= 0) throw new InvalidOperationException(nameof(amount));
            Amount += amount * GetTransferCoefficient(currency);
        }

        public void Withdraw(decimal amount, string currency)
        {
            decimal transferCoefficient = GetTransferCoefficient(currency);
            if (Amount - amount * transferCoefficient < 0)
            {
                throw new InvalidOperationException(nameof(amount));
            }
            Amount -= amount * transferCoefficient;
        }

        public decimal GetBalance(string currency)
        {
            decimal transferCoefficient = GetTransferCoefficient(currency);
            return Math.Round(Amount / transferCoefficient, 2);
        }

        private decimal GetTransferCoefficient(string currency)
        {
            switch (currency)
            {
                case "UAH": return _transUAH;
                case "EUR": return _transEUR;
                case "USD": return _transUSD;
                default: throw new NotSupportedException(nameof(currency));
            }
        }
    }
}
