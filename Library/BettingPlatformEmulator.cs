using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class BettingPlatformEmulator
    {
        private List<Player> Players { get; }
        private Player ActivePlayer { get; set; } = null;
        private Account Account { get; }
        private BetService BetService { get; }
        private PaymentService PaymentService { get; }

        public BettingPlatformEmulator()
        {
            Account = new Account("USD");
            Players = new List<Player>();
            BetService = new BetService();
            PaymentService = new PaymentService();
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    if (ActivePlayer == null)
                    {
                        Console.WriteLine("1. Register\n2. Login\n3. Stop");
                        Console.Write("Enter command (1-3) -> ");
                        int command;
                        int.TryParse(Console.ReadLine(), out command);
                        switch (command)
                        {
                            case 1:
                                Register();
                                break;
                            case 2:
                                Login();
                                break;
                            case 3:
                                Exit();
                                break;
                            default:
                                Console.WriteLine("Invald command. Try again");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("1. Deposit\n2. Withdraw\n3. GetOdds\n4. Bet\n5. Logout");
                        Console.Write("Enter command (1-3) -> ");
                        int command = 0;
                        int.TryParse(Console.ReadLine(), out command);
                        switch (command)
                        {
                            case 1:
                                Deposit();
                                break;
                            case 2:
                                Withdraw();
                                break;
                            case 3:
                                GetOdds();
                                break;
                            case 4:
                                Bet();
                                break;
                            case 5:
                                Logout();
                                break;
                            default:
                                Console.WriteLine("Invald command. Try again");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void GetOdds() => Console.WriteLine($"Odd is {BetService.GetOdds()}");

        public void Bet()
        {
            decimal amount;
            string currency;
            SetAmountAndCurrency(out amount, out currency);
            try
            {
                ActivePlayer.Withdraw(amount, currency);
                var price = BetService.Bet(amount);
                if (price == 0)
                {
                    throw new Exception("You lose.");
                }
                Console.WriteLine($"You won {price} {currency}");
                ActivePlayer.Deposit(price, currency);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("There is insufficient funds on your account.");
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("Invalid currency");
            }
        }

        private void Exit() => Environment.Exit(0);

        private void Register()
        {
            string name;
            string lastName;
            string email;
            string password;
            string currency;

            Console.Write("Enter your name, please -> ");
            while ((name = Console.ReadLine()) == "")
                Console.Write("Empty name. Try again -> ");

            Console.Write("Enter your Last name, please -> ");
            while ((lastName = Console.ReadLine()) == "")
                Console.Write("Emty Last name. Try again -> ");

            Console.Write("Enter your login, please -> ");
            while ((email = Console.ReadLine()) == "")
                Console.Write("Empty login. Try again -> ");

            Console.Write("Enter your password, please -> ");
            while ((password = Console.ReadLine()) == "")
                Console.Write("Empty password. Try again -> ");

            while (true) {
                try
                {
                    Console.Write("Enter currency of your account ('EUR', 'USD', 'UAH'), please -> ");
                    currency = Console.ReadLine();
                    Players.Add(new Player(name, lastName, email, password, currency));
                    ActivePlayer = Players[Players.Count - 1];
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid. Try again.");
                }
            }
            Console.WriteLine($"Welcome, {ActivePlayer.FirstName} {ActivePlayer.LastName}!");
        }

        private void Login()
        {
            if (Players?.Count == 0)
            {
                Console.WriteLine("There is no registered players in platform.");
                return;
            }
            while (true)
            {
                Console.Write("Enter your login -> ");
                string login = Console.ReadLine();
                foreach (var player in Players)
                {
                    if (player.Email == login)
                    {
                        ActivePlayer = player;
                        break;
                    }
                }
                if (ActivePlayer != null) break;
                Console.WriteLine($"There is no such player with login {login}");
            }
            Console.Write("Enter your password -> ");
            while (!ActivePlayer.IsPasswordValid(Console.ReadLine()))
                Console.Write("Invalid password. Try again -> ");

            Console.WriteLine($"Welcome, {ActivePlayer.FirstName} {ActivePlayer.LastName}!");
        }

        private void Logout() => ActivePlayer = null;

        private void Deposit()
        {
            decimal amount;
            string currency;
            SetAmountAndCurrency(out amount, out currency);
            try
            {
                if (currency != "USD" && currency != "EUR" && currency != "UAH")
                {
                    throw new NotSupportedException(nameof(currency));
                }
                PaymentService.StartDeposit(amount, currency);
                Account.Deposit(amount, currency);
                ActivePlayer.Deposit(amount, currency);
                Console.WriteLine("Success!");
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("Failed. Invalid currency.");
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException("Amount must be raither than 0.");
            }
        }

        private void Withdraw()
        {
            decimal amount;
            string currency;
            SetAmountAndCurrency(out amount, out currency);
            try
            {
                if (currency != "USD" && currency != "EUR" && currency != "UAH")
                {
                    throw new NotSupportedException(nameof(currency));
                }
                PaymentService.StartWithdrawal(amount, currency);
                ActivePlayer.Withdraw(amount, currency);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("There is insufficient funds on your account.");
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("Failed. Invalid currency.");
            }

            try
            {
                Account.Withdraw(amount, currency);
                Console.WriteLine("Success!");
            }
            catch (InvalidOperationException)
            {
                ActivePlayer.Deposit(amount, currency);
                throw new InvalidOperationException("There is some problem on the platform side. Please try it later.");
            }
        }

        private void SetAmountAndCurrency(out decimal amount, out string currency)
        {
            do
            {
                Console.Write("Enter amount -> ");
                if (decimal.TryParse(Console.ReadLine(), out amount)) break;
                Console.WriteLine("Invalid amount. Try again.");
            } while (true);
            Console.Write("Enter currency ('EUR', 'USD', 'UAH') -> ");
            currency = Console.ReadLine();
        }
    }
}
