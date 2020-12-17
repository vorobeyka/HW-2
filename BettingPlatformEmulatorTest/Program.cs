using System;
using Library;

namespace BettingPlatformEmulatorTest
{
    class Program
    {
        static void smt(out int a, out string b)
        {
            a = 5;
            b = "syka";
        }
        static void Main(string[] args)
        {
            var betPlatform = new BettingPlatformEmulator();

            betPlatform.Start();
        }
    }
}
