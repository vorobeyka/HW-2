using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class CreditCard : PaymentMethodBase, ISupportDeposit, ISupportWithdrawal
    {
        public CreditCard()
        {
            Name = "CreditCard";
        }

        private bool IsOutOfTransactionLimit(decimal amount, string currency)
        {
            switch (currency)
            {
                case "USD": return amount * 28.36m > 3000;
                case "EUR": return amount * 33.63m > 3000;
                default: return amount > 3000;
            }
        }

        public void StartDeposit(decimal amount, string currency)
        {
            if (IsOutOfTransactionLimit(amount, currency))
            {
                throw new LimitExceededException("Transaction amount out of limit (3000 UAH)");
            }
            string cardNumber;
            string expiryDate;
            string cvvCode;

            Console.WriteLine("Deposite with CreditCard:");
            while (true)
            {
                Console.Write("Enter card number (16-digit numbers) -> ");
                cardNumber = Console.ReadLine();
                if (IsValidCardNumber(cardNumber)) break;
                Console.WriteLine("Invalid card number. Try again.");
            }
            while (true)
            {
                Console.Write("Enter expiry date (01/22). Must be raither than current date. -> ");
                expiryDate = Console.ReadLine();
                if (IsValidExpiryDate(expiryDate)) break;
                Console.WriteLine("Invalid expiry date. Try again.");
            }
            while (true)
            {
                Console.Write("Enter CVV (3-digit number) -> ");
                cvvCode = Console.ReadLine();
                if (IsValidCVV(cvvCode)) break;
                Console.WriteLine("Invalid CVV code. Try again.");
            }
            Console.WriteLine("Success!");
        }

        public void StartWithdrawal(decimal amount, string currency)
        {
            string cardNumber;
            Console.WriteLine("Withdrawal with CreditCard:");
            while (true)
            {
                Console.Write("Enter card number (16-digit numbers) -> ");
                cardNumber = Console.ReadLine();
                if (IsValidCardNumber(cardNumber)) break;
                Console.WriteLine("Invalid card number. Try again.");
            }
            Console.WriteLine("Success!");
        }

        private bool IsValidCardNumber(string value)
        {
            ulong tmp;
            return value.Length == 16 && (value[0] == '5' || value[0] == '4') && ulong.TryParse(value, out tmp);
        }

        private bool IsValidExpiryDate(string value)
        {
            uint month = 0;
            uint year = 0;
            uint currentYear = uint.Parse(DateTime.Now.Year.ToString().Substring(2, 2));
            uint currentMonth = uint.Parse(DateTime.Now.Month.ToString());
            bool result = value.Length == 5 && value?[2] == '/'
                            && uint.TryParse(value.Substring(0, 2), out month)
                            && uint.TryParse(value.Substring(3, 2), out year);
            if (year < currentYear) result = false;
            if (month < currentMonth && year == currentYear) result = false;
            return result;
        }

        private bool IsValidCVV(string value)
        {
            uint tmp;
            return value.Length == 3 && uint.TryParse(value, out tmp);
        }
    }
}
