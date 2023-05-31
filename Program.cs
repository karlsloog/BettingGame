using System.ComponentModel.Design;

namespace BettingGame
{
    internal class Guy
    {
        public string Name;
        public int Cash;

        /// <summary>
        /// writes my name and the amount of cash i have to the console
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " has " + Cash + " bucks. ");
        }

        /// <summary>
        /// gives cash, removing it from wallet
        /// printing a message if doesnt have enough cash
        /// </summary>
        /// <param name="amount">Amount of cast to give.</param>
        /// <returns>
        /// the amount of cash removed from wallet, or 0 if dont have enough cash
        /// or if the amount is invalid
        /// </returns>
        public int GiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't a valid amount");
            }
            if (amount > Cash)
            {
                Console.WriteLine(Name + " says: " + "I don't have enough cash to give you " + amount);
                return 0;
            }
            Cash -= amount;
            return amount;
        }

        /// <summary>
        /// receive cash, adding it to wallet
        /// or printing message to console if doesnt have enough cash
        /// </summary>
        /// <param name="amount">amount of cast to give</param>
        public void ReceiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't an amount I'll take");
            }
            else
            {
                Cash += amount;
            }
        }

        static void Main(string[] args)
        {
            double odds = .75;
            Random random = new Random();

            Guy player = new Guy() { Cash = 100, Name = "The Player" };

            Console.WriteLine("Welcome to the casino. The odds are " + odds);
            while (player.Cash > 0)
            {
                player.WriteMyInfo();
                Console.Write("How much do you want to bet: ");
                string howMuch = Console.ReadLine();
                if (int.TryParse(howMuch, out int amount))
                {
                    int pot = player.GiveCash(amount) * 2;
                    if(pot > 0)
                    {
                        if (random.NextDouble() > odds)
                        {
                            int winnings = pot;
                            Console.WriteLine("You win " + winnings);
                            player.ReceiveCash(winnings);
                        }
                        else
                        {
                            Console.WriteLine("Bad luck, try again");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter valid amount.");
                }
            }
            Console.WriteLine("The house always wins.");
        }
    }
}