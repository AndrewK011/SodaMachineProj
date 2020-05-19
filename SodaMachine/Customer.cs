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

        

        public void EnterPayment(Card card)
        {

        }

        public void EnterPayment(List<Coin> coins)
        {
            UserInterface.ChooseCoins(coins);
        }
        
    }
}
