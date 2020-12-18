using System;
using Library;

namespace BettingPlatformEmulatorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var betPlatform = new BettingPlatformEmulator();

            betPlatform.Start();
        }
    }
}
