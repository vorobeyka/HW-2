using System;
using Library;

namespace Task_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var creditCard = new CreditCard();
            var privet48 = new Privet48();
            var stereobank = new Stereobank();
            var giftVoucher = new GiftVoucher();

            creditCard.StartDeposit(50, "USD");
            creditCard.StartWithdrawal(50, "USD");
            privet48.StartDeposit(50, "USD");
            stereobank.StartWithdrawal(50, "USD");
            giftVoucher.StartDeposit(50, "USD");
            giftVoucher.StartDeposit(500, "USD");
            giftVoucher.StartDeposit(50, "USD");
        }
    }
}
