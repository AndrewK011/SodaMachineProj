using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Simulation
    {
        public SodaMachine sodaMachine;
        public Customer customer;
        public List<Coin> insertedCoins;

        public Simulation()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
            sodaMachine.StartingInventory(10,10,10);
            sodaMachine.StartingRegister(20,10,20,50);
            customer.wallet.StartingWallet(12,15,8,10);
            Menu();

        }

        public void Menu()
        {
            UserInterface.DisplayIntro();
            UserInterface.DisplayDrinkSelections(sodaMachine.inventory);

            if (UserInterface.ChoosePayment() == 1)
            {
                insertedCoins = customer.EnterPayment(customer.wallet.coins);
                double canPriceMinusInsertedCoins = sodaMachine.DrinkSelection(insertedCoins);
                if(canPriceMinusInsertedCoins < 0)
                {
                    UserInterface.NotEnoughMoney();
                    CustomerTakesChange(insertedCoins);
                    Menu();
                }

                else if (sodaMachine.MakeChange(canPriceMinusInsertedCoins, customer.wallet.coins, insertedCoins))
                {
                    sodaMachine.DispenseCan(canPriceMinusInsertedCoins, customer.backpack.cans, insertedCoins);
                    Menu();
                }
                else
                {
                    

                }
            }
            

            else if(UserInterface.ChoosePayment() == 2)
            {
                customer.EnterPayment(customer.wallet.card);
                //DrinkSelection();
            }

            else
            {
                Menu();
            }

        }

        public void CustomerTakesChange(double change, List<Can> cans, List<Coin> coins)
        {

        }

        public void CustomerTakesChange(List<Coin> insertedChange)
        {
            foreach(Coin coin in insertedChange)
            {
                customer.wallet.coins.Add(coin);
            }
        }

    }
}
