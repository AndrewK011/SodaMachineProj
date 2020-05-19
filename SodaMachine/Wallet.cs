using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        public List<Coin> coins;
        public Card card;

        public Wallet()
        {
            coins = new List<Coin>();
            card = new Card();
        }

        public void StartingWallet(int quarters, int dimes, int nickels, int pennies)
        {
            for (int i = 0; i < quarters; i++)
            {
                Quarter quarter = new Quarter();
                coins.Add(quarter); ;
            }
            for (int i = 0; i < dimes; i++)
            {
                Dime dime = new Dime();
                coins.Add(dime);
            }
            for (int i = 0; i < nickels; i++)
            {
                Nickel nickel = new Nickel();
                coins.Add(nickel);
            }
            for (int i = 0; i < pennies; i++)
            {
                Penny penny = new Penny();
                coins.Add(penny);
            }
        }
    }
}
