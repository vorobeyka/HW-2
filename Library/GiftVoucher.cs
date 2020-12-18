using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class GiftVoucher : PaymentMethodBase, ISupportDeposit
    {
        private bool IsAvailable { get; set; }

        public GiftVoucher()
        {
            Name = "GiftVoucher";
            TransactionLimit = -1;
            IsAvailable = true;
        }

        public void StartDeposit(decimal amount, string currency)
        {
            if (!IsAvailable)
            {
                throw new InsufficientFundsException();
            }
            string giftVouch = "";
            string giftCard;
            int giftCardNumber;
            if (amount != 100 && amount != 500 && amount != 1000)
            {
                do
                {
                    Console.Write("Invalid gift vouch. It must be 100, 500 or 1000\nEnter gift vouch -> ");
                } while ((giftVouch = Console.ReadLine()) != "100" && giftVouch != "500" && giftVouch != "1000");
            }
            Console.WriteLine("Enter gift card number (only digits, 10-digit number)\n-> ");
            while ((giftCard = Console.ReadLine()).Length != 10 && int.TryParse(giftCard, out giftCardNumber) && giftCardNumber > 0)
            {
                Console.Write("Invalid gift card number. Try again\n-> ");
            }
            IsAvailable = false;
        }
    }
}
