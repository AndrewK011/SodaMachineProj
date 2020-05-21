using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    static class UserInterface
    {
        public static int ChoosePayment()
        {
            int userInput;
            Console.WriteLine("Enter method of payment: \n1) coins\n2) card");
            userInput = GetIntInput();

            switch (userInput)
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                default:
                    Console.WriteLine("Invalid Input.");
                    return ChoosePayment();  
            }        
        }

        public static void NotEnoughMoney()
        {
            Console.WriteLine("Not enough money entered.\n\n\n\n");
        }

        public static void AskForNextCoin(string currentCoin)
        {
            Console.WriteLine($"How many {currentCoin} would you like to insert?");
        }

            public static void DisplayCoinInserted(int counter, string currentCoin)
        {
            Console.WriteLine($"You insert {counter} {currentCoin}.");
        }

        public static void DisplayCoinWallet(List<Coin> coins)
        {
            int quarterCounter = 0;
            int dimeCounter = 0;
            int nickelCounter = 0;
            int pennyCounter = 0;


            for (int i = 0; i < coins.Count; i++)
            {
                switch (coins[i].name)
                {
                    case "quarter":
                        quarterCounter++;
                        break;
                    case "dime":
                        dimeCounter++;
                        break;
                    case "nickel":
                        nickelCounter++;
                        break;
                    case "penny":
                        pennyCounter++;
                        break;
                    default:
                        break;
                }
            }
            

            Console.WriteLine($"You have:\n{quarterCounter} quarters\n{dimeCounter} dimes\n{nickelCounter} nickels\n{pennyCounter} pennies");

        }

        public static int GetIntInput()
        {
            int userInput;
            if (int.TryParse(Console.ReadLine(), out userInput))
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Invalid input.");
                GetIntInput();
            }
                return 0;
        }

        public static void DisplayIntro()
        {
            Console.WriteLine("\nWelcome to the Soda Machine! Here are our current selections:");
        }

        public static void DisplayDrinkSelections(List<Can> cans)
        {
            string checkName;
            List<Can> selectionOfCans = new List<Can>();

            for (int i = 0; i < cans.Count - 1; i++)
            {
                checkName = cans[i].name;
                if (checkName != cans[i + 1].name)
                {
                    selectionOfCans.Add(cans[i]);
                }
                else if (i == cans.Count - 2)
                {
                    selectionOfCans.Add(cans[i]);
                }
            }

            
            for (int i = 0; i < selectionOfCans.Count; i++)
            {
                Console.WriteLine($"{selectionOfCans[i].name} ${selectionOfCans[i].Cost}");
            }

            Console.WriteLine("\n\n");

        }

        public static void InventoryShortage()
        {
            Console.WriteLine("We're sorry, we are currently out of that selection.");
        }

        public static Can SelectDrink(List<Can> cans)
        {
            string checkName;
            List<Can> selectionOfCans = new List<Can>();

            for (int i = 0; i < cans.Count - 1; i++)
            {
                checkName = cans[i].name;
                if (checkName != cans[i + 1].name)
                {
                    selectionOfCans.Add(cans[i]);
                }
                else if (i == cans.Count - 2)
                {
                    selectionOfCans.Add(cans[i]);
                }
            }        
            Console.WriteLine("Please select your drink:");
            for (int i = 0; i < selectionOfCans.Count; i++)
            {
                Console.WriteLine($"{i}) {selectionOfCans[i].name} ${selectionOfCans[i].Cost}");
            }

            return selectionOfCans[GetIntInput()];
        }
    }
}
