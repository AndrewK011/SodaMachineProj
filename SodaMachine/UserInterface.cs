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
                    ChoosePayment();
                    break;
                    
            }
            return 1;
        }

        public static void ChooseCoins(List<Coin> coins)
        {
            
            CoinPrompt("quarters", coins);
            CoinPrompt("dimes", coins);
            CoinPrompt("nickels", coins);
            CoinPrompt("pennies", coins);

        }

        public static void CoinPrompt(string currentCoin, List<Coin> coins)
        {
            List<Coin> insertedCoins = new List<Coin>();
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
                        if (coins[i].name == "quarter")
                        {
                            Quarter quarter = new Quarter();
                            insertedCoins.Add(quarter);
                            coins.RemoveAt(i);
                            counter++;
                            i = -1;
                        }

                        if (counter == (coinsEntered))
                        {
                            break;
                        }
                    }
                    Console.WriteLine($"You insert {counter} {currentCoin}.");
                    break;
                case "dimes":
                    coinsEntered = GetIntInput();
                    for (int i = 0; i < coins.Count; i++)
                    {
                        if (coins[i].name == "dime")
                        {
                            Dime dime = new Dime();
                            insertedCoins.Add(dime);
                            coins.RemoveAt(i);
                            counter++;
                            i = -1;
                        }

                        if (counter == coinsEntered)
                        {
                            break;
                        }
                    }
                    break;
                case "nickels":
                    coinsEntered = GetIntInput();
                    for (int i = 0; i < coins.Count; i++)
                    {
                        if (coins[i].name == "nickel")
                        {
                            Nickel nickel = new Nickel();
                            insertedCoins.Add(nickel);
                            coins.RemoveAt(i);
                            counter++;
                            i--;
                        }

                        if (counter == coinsEntered)
                        {
                            break;
                        }
                    }
                    Console.WriteLine($"You insert {counter} {currentCoin}.");
                    break;
                case "pennies":
                    coinsEntered = GetIntInput();
                    for (int i = 0; i < coins.Count; i++)
                    {
                        if (coins[i].name == "penny")
                        {
                            Penny penny = new Penny();
                            insertedCoins.Add(penny);
                            coins.RemoveAt(i);
                            counter++;
                            i--;
                        }

                        if (counter == coinsEntered)
                        {
                            break;
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
    }
}
