using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class GiftVoucher : PaymentMethodBase, ISupportDeposit
    {
        public GiftVoucher()
        {
            Name = "GiftVoucher";
        }

        public void StartDeposit(decimal amount, string currency)
        {
            string giftVouch = "";
            string giftCard;
            int giftCardNumber;
            if (amount != 100 || amount != 500 || amount != 1000)
            {
                do
                {
                    Console.WriteLine("Invalid gift vouch. It must be 100, 500 or 1000\nEnter gift vouch -> ");
                } while ((giftVouch = Console.ReadLine()) != "100" && giftVouch != "500" && giftVouch != "1000");
            }
            Console.WriteLine("Enter gift card number (only digits, 10-digit number) ->");
            while ((giftCard = Console.ReadLine())?.Length != 10 && int.TryParse(giftCard, out giftCardNumber) && giftCardNumber > 0)
            {
                Console.Write("Invalid gift card number. Try again\n-> ");
            }
            Console.WriteLine("Success!");
        }
    }
}
