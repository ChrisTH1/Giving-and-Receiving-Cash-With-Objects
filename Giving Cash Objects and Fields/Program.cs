﻿
using System.ComponentModel.Design;

namespace CashProject
{
    class Guy
    {
        public string Name;
        public int Cash;

        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " has " + Cash + " bucks ");
        }

        public int GiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't a valid amount ");
            }
            if (amount > Cash)
            {
                Console.WriteLine(Name + " says: " + " I don't have enough cash to give you " + amount);
                return 0;
            }
            Cash -= amount;
            return amount;
        }

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
            Guy joe = new Guy() { Name = "Joe", Cash = 50 };
            Guy bob = new Guy() { Name = "Bob", Cash = 100 };

            while (true)
            {
                joe.WriteMyInfo();
                bob.WriteMyInfo();

                Console.Write("Enter an amount: ");
                string howMuch = Console.ReadLine();
                if (howMuch == "") return;
                if (int.TryParse(howMuch, out int amount))
                {
                    Console.WriteLine("Who should give the cash: ");
                    string whichGuy = Console.ReadLine();
                    if (whichGuy == "Joe")
                    {
                        int cashGiven = joe.GiveCash(amount);
                        bob.ReceiveCash(cashGiven);
                    }
                    else if (whichGuy == "Bob")
                    {
                        int cashGiven = bob.GiveCash(amount);
                        joe.ReceiveCash(cashGiven);
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'Joe' or 'Bob'");
                    }
                   
                }
                else
                {
                    Console.WriteLine("Please enter an amount (or a blank line to exit).");
                }

              
            }


        }
    }
}