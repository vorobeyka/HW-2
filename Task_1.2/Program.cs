using System;
using Library;

namespace Task_1._2
{
    class Program
    {
        static Account[] GetSortedAccounts(Account[] accounts)
        {
            Account[] sortedAccounts = new Account[accounts.Length];
            Array.Copy(accounts, sortedAccounts, accounts.Length);

            for (int i = 0; i < sortedAccounts.Length - 1; i++)
            {
                for (int j = i + 1; j < sortedAccounts.Length; j++)
                {
                    if (sortedAccounts[j].Id < sortedAccounts[i].Id)
                    {
                        var tmp = sortedAccounts[i];
                        sortedAccounts[i] = sortedAccounts[j];
                        sortedAccounts[j] = tmp;
                    }
                }
            }
            return sortedAccounts;
        }

        static void Main(string[] args)
        {
            Account[] accounts = new Account[1000000];

            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account("UAH");
            }

            Account[] sortedAccounts = GetSortedAccounts(accounts);

            Console.WriteLine("First ten accounts are:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(sortedAccounts[i].Id);
            }
            Console.WriteLine("\nLast ten accounts are:");
            for (int i = sortedAccounts.Length - 10; i < sortedAccounts.Length; i++)
            {
                Console.WriteLine(sortedAccounts[i].Id);
            }
        }
    }
}
