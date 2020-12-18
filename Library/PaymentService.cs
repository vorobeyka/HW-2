using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class PaymentService
    {
        private PaymentMethodBase[] AvailablePaymentMethod { get; }

        public PaymentService()
        {
            AvailablePaymentMethod = new PaymentMethodBase[]{ new CreditCard(), new Privet48(),
                                                              new Stereobank(), new GiftVoucher() };
        }

        public void StartDeposit(decimal amount, string currency)
        {
            int i = 0;
            int method = 0;
            for (int j = 0; j < AvailablePaymentMethod.Length; j++)
            {
                if (AvailablePaymentMethod[j] is ISupportDeposit)
                {
                    Console.WriteLine($"{++i}. {AvailablePaymentMethod[j].Name}");
                }
            }
            Console.Write("Enter deposit method -> ");
            while (!int.TryParse(Console.ReadLine(), out method) || method < 1 || method > i)
            {
                Console.Write("Invalid deposit method. Try again -> ");
            }
            i = 0;
            foreach (ISupportDeposit payment in AvailablePaymentMethod)
            {
                if (method == ++i)
                {
                    payment.StartDeposit(amount, currency);
                    break;
                }
            }
        }

        public void StartWithdrawal(decimal amount, string currency)
        {
            int i = 0;
            int method = 0;
            for (int j = 0; j < AvailablePaymentMethod.Length; j++)
            {
                if (AvailablePaymentMethod[j] is ISupportWithdrawal)
                {
                    Console.WriteLine($"{++i}. {AvailablePaymentMethod[j].Name}");
                }
            }
            Console.Write("Enter withdrawal method -> ");
            while (!int.TryParse(Console.ReadLine(), out method) || method < 1 || method > i)
            {
                Console.Write("Invalid withdrawal method. Try again -> ");
            }
            i = 0;
            foreach (ISupportWithdrawal payment in AvailablePaymentMethod)
            {
                if (method == ++i)
                {
                    payment.StartWithdrawal(amount, currency);
                    break;
                }
            }
        }
    }
}
