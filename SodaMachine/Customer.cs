using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        public Wallet wallet;
        public Backpack backpack;

        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
        }

        



        public List<Coin> EnterPayment(List<Coin> coins)
        {
            List<Coin> coinPayment = ChooseCoins(coins);
            return coinPayment;
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

            UserInterface.DisplayCoinWallet(coins);
            UserInterface.AskForNextCoin(currentCoin);
            int coinsEntered;
            int counter = 0;
            switch (currentCoin)
            {

                case "quarters":
                    coinsEntered = UserInterface.GetIntInput();
                    for (int i = 0; i < coins.Count; i++)
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
                    UserInterface.DisplayCoinInserted(counter, currentCoin);
                    break;
                case "dimes":
                    coinsEntered = UserInterface.GetIntInput();
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
                    UserInterface.DisplayCoinInserted(counter, currentCoin);
                    break;
                case "nickels":
                    coinsEntered = UserInterface.GetIntInput();
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
                    UserInterface.DisplayCoinInserted(counter, currentCoin);
                    break;
                case "pennies":
                    coinsEntered = UserInterface.GetIntInput();
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
                    UserInterface.DisplayCoinInserted(counter, currentCoin);
                    break;
                default:
                    break;
            }

        }

    }
}
