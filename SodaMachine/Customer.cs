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

        public List<Coin> EnterPayment(List<Coin> coins)
        {
            List<Coin> coinPayment = UserInterface.ChooseCoins(coins);
            return coinPayment;
        }

        public void ChooseSelection(List<Coin> coinPayment)
        {

        }
        
    }
}
