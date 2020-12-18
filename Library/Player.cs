using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Player
    {
        private static List<int> _uniqueIds = new List<int>(1);
        private int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        private string Password { get; }
        private Account Account { get; }

        public Player(string firstName, string lastName, string email, string password, string currency)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Account = new Account(currency);
            Id = Account.Id;
            // if (_uniqueIds.Capacity == 1)
            // {
            //     _uniqueIds.Add(999999);
            // }
            // int countIds = _uniqueIds.Count;
            // _uniqueIds.Add(_uniqueIds[countIds - 1] + 1);
            // Id = _uniqueIds[countIds];
        }

        public bool IsPasswordValid(string password) => password == Password;

        public void Deposit(decimal amount, string Currency) => Account.Deposit(amount, Currency);

        public void Withdraw(decimal amount, string Currency) => Account.Withdraw(amount, Currency);
    }
}
