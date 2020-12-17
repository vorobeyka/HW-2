using System;
using Library;

namespace Task_1._3
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

        private static int BinarySearchAccount(Account[] accounts, int id, out int tries)
        {
            tries = 1;
            var left = accounts.GetLowerBound(0);
            var right = accounts.GetUpperBound(0);
            if (left == right)
                return left;

            for (; ; tries++)
            {
                if (right - left == 1)
                {
                    if (accounts[left].Id.CompareTo(id) == 0)
                        return left;
                    if (accounts[right].Id.CompareTo(id) == 0)
                        return right;
                    return -1;
                }
                else
                {
                    var middle = left + (right - left) / 2;
                    var comparisonResult = accounts[middle].Id.CompareTo(id);
                    if (comparisonResult == 0)
                        return middle;
                    if (comparisonResult < 0)
                        left = middle;
                    if (comparisonResult > 0)
                        right = middle;
                }
            }
        }
        static void GetAccount(Account[] accounts, int id)
        {
            int tries;
            int index = BinarySearchAccount(accounts, id, out tries);
            if (index == -1)
            {
                Console.WriteLine("There is no account {0} in the list", id);
                return;
            }
            Console.WriteLine("{0} was found at index {1} by {2} tries", id, index, tries);
        }

        static void Main(string[] args)
        {
            Account[] accounts = new Account[1000000];

            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account("UAH");
            }

            Account[] sortedAccounts = GetSortedAccounts(accounts);

            GetAccount(sortedAccounts, 999999 + 46);
        }
    }
}
