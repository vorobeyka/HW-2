using System;
using Library;

namespace Task_1._4
{
    class Program
    {
        private static void QuickSort(Account[] accounts, int first, int last)
        {
            int id = accounts[(last - first) / 2 + first].Id;
            int i = first, j = last;
            while (i <= j)
            {
                while (accounts[i].Id < id && i <= last) ++i;
                while (accounts[j].Id > id && j >= first) --j;
                if (i <= j)
                {
                    var temp = accounts[i];
                    accounts[i] = accounts[j];
                    accounts[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) QuickSort(accounts, first, j);
            if (i < last) QuickSort(accounts, i, last);
        }

        static Account[] GetSortedAccountsByQuickSort(Account[] accounts)
        {
            Account[] sortedAccounts = new Account[accounts.Length];
            Array.Copy(accounts, sortedAccounts, accounts.Length);
            QuickSort(sortedAccounts, sortedAccounts.GetLowerBound(0), sortedAccounts.GetUpperBound(0));
            return sortedAccounts;
        }

        static void Main(string[] args)
        {
            Account[] accounts = new Account[1000000];

            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account("UAH");
            }

            Account[] sortedAccounts = GetSortedAccountsByQuickSort(accounts);
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
