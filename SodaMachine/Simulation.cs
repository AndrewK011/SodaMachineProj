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
           // sodaMachine.StartingInventory(10,10,10);
            //sodaMachine.StartingRegister(20,10,20,50);
            customer.wallet.StartingWallet(12,15,8,10);
            Menu();
            foreach(Can can in customer.backpack.cans)
            {
                Console.WriteLine(can.name);
            }

            foreach(Coin coin in sodaMachine.register)
            {
                Console.WriteLine(coin.name);
            }

            foreach(Can can in sodaMachine.inventory)
            {
                Console.WriteLine(can.name);
            }

        }

        public void Menu()
        {
            UserInterface.DisplayIntro();
            if (sodaMachine.inventory.Count == 0)
            {
                UserInterface.ExitMessage();
            }
            else
            {
                UserInterface.DisplayDrinkSelections(sodaMachine.inventory);
                int userInput = UserInterface.ChoosePayment();
                if (userInput == 1)
                {
                    insertedCoins = customer.EnterPayment(customer.wallet.coins);


                    double canPriceMinusInsertedCoins = sodaMachine.DrinkSelection(insertedCoins);
                    if (canPriceMinusInsertedCoins < 0)
                    {
                        UserInterface.NotEnoughMoney();
                        CustomerTakesChange(insertedCoins);
                        Menu();
                    }

                    else if (sodaMachine.MakeChange(canPriceMinusInsertedCoins, customer.wallet.coins, insertedCoins))
                    {
                        sodaMachine.DispenseCan(customer.backpack.cans);
                        Menu();
                    }

                }


                else if (userInput == 2)
                {
                    customer.EnterPayment(customer.wallet.card);

                }

            }
        }         
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
