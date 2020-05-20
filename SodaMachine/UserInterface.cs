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
            string userInput;
            Console.WriteLine("Enter method of payment: \n1) coins\n2) card");
            userInput = Console.ReadLine();

            switch (int.Parse(userInput))
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

        public static List<Coin> ChooseCoins(List<Coin> coins)
        {
            List<Coin> coinsInMachine = new List<Coin>();
            CoinPrompt("quarters", coins, coinsInMachine);
            CoinPrompt("dimes", coins, coinsInMachine);
            CoinPrompt("nickels", coins, coinsInMachine);
            CoinPrompt("pennies", coins, coinsInMachine);
            return coinsInMachine;
        }

        public static void CoinPrompt(string currentCoin, List<Coin> coins, List<Coin> insertedCoins)
        {
            
            DisplayCoinWallet(coins);
            Console.WriteLine($"How many {currentCoin} would you like to insert?");
            int coinsEntered;
            int counter = 0;
            switch (currentCoin)
            {
                
                case "quarters":               
                    coinsEntered = GetIntInput();
                    for(int i = 0; i < coins.Count; i++)
                    {
                        if (counter == (coinsEntered))
                        {
                            break;
                        }
                        if (coins[i].name == "quarter")
                        {
                            Quarter quarter = new Quarter();
                            insertedCoins.Add(quarter);
                            coins.RemoveAt(i);
                            counter++;
                            i--;
                        }

                    }
                    Console.WriteLine($"You insert {counter} {currentCoin}.");
                    break;
                case "dimes":
                    coinsEntered = GetIntInput();
                    for (int i = 0; i < coins.Count; i++)
                    {
                        if (counter == coinsEntered)
                        {
                            break;
                        }
                        if (coins[i].name == "dime")
                        {
                            Dime dime = new Dime();
                            insertedCoins.Add(dime);
                            coins.RemoveAt(i);
                            counter++;
                            i--;
                        }

                    }
                    Console.WriteLine($"You insert {counter} {currentCoin}.");
                    break;
                case "nickels":
                    coinsEntered = GetIntInput();
                    for (int i = 0; i < coins.Count; i++)
                    {
                        if (counter == coinsEntered)
                        {
                            break;
                        }
                        if (coins[i].name == "nickel")
                        {
                            Nickel nickel = new Nickel();
                            insertedCoins.Add(nickel);
                            coins.RemoveAt(i);
                            counter++;
                            i--;
                        }

                    }
                    Console.WriteLine($"You insert {counter} {currentCoin}.");
                    break;
                case "pennies":
                    coinsEntered = GetIntInput();
                    for (int i = 0; i < coins.Count; i++)
                    {
                        if (counter == coinsEntered)
                        {
                            break;
                        }
                        if (coins[i].name == "penny")
                        {
                            Penny penny = new Penny();
                            insertedCoins.Add(penny);
                            coins.RemoveAt(i);
                            counter++;
                            i--;
                        }

                    }
                    Console.WriteLine($"You insert {counter} {currentCoin}.");
                    break;
                default:
                    break;
            }
            
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
            Console.WriteLine("Welcome to the Soda Machine! Here are our current selections:");
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
