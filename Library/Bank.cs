using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public abstract class Bank : PaymentMethodBase, ISupportDeposit, ISupportWithdrawal
    {
        protected string[] AvailableCards { get; set; }

        protected decimal CardsLimit { get; set; }

        protected void ChangeCardsLImit(decimal amount, string currency)
        {
            if (CardsLimit < 0) throw new InsufficientFundsException();
            switch (currency)
            {
                case "USD": CardsLimit -= amount * 28.36m;
                    break;
                case "EUR": CardsLimit -= amount * 33.63m ;
                    break;
                default: CardsLimit -= amount;
                    break;
            }
        }

        public void StartDeposit(decimal amount, string currency)
        {
            uint cardIndex;
            if (IsOutOfTransactionLimit(amount, currency)) throw new LimitExceededException();
            ChangeCardsLImit(amount, currency);
            TransactionWithCard(out cardIndex);
            Console.WriteLine($"You've withdraw {amount} {currency} from your {AvailableCards[cardIndex]} card successfully");
        }

        public void StartWithdrawal(decimal amount, string currency)
        {
            uint cardIndex;
            if (IsOutOfTransactionLimit(amount, currency)) throw new LimitExceededException();
            ChangeCardsLImit(amount, currency);
            TransactionWithCard(out cardIndex);
            Console.WriteLine($"You've deposit {amount} {currency} from your {AvailableCards[cardIndex]} card successfully");
        }

        private void TransactionWithCard(out uint cardIndex)
        {
            string login;
            string password;
            Console.WriteLine($"Welcome, dear client, to the online bank {Name}!");
            Console.WriteLine("Please, enter your login");
            while ((login = Console.ReadLine()) == "")
                Console.WriteLine("Invalid login. Try again");
            Console.WriteLine("Please, enter your password");
            while ((password = Console.ReadLine()) == "")
                Console.WriteLine("Invalid password. Try again");
            Console.WriteLine($"Hello Mr {login}. Pick a card to proceed the transaction");
            for (int i = 0; i < AvailableCards?.Length; i++)
            {
                Console.WriteLine($"{i}. {AvailableCards[i]}");
            }
            while (!uint.TryParse(Console.ReadLine(), out cardIndex) || cardIndex >= AvailableCards?.Length)
            {
                Console.WriteLine("Invalid card. Try again.\n");
            }
        }
    }
}
