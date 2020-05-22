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
            UserInterface.DisplaySodaInBackpack(customer.backpack.cans);
        }

        public void Menu()
        {
            UserInterface.DisplayIntro();
            if (sodaMachine.inventory.Count == 0)
            {
                UserInterface.InventoryShortage();
                UserInterface.ExitMessage();
            }
            else
            {
                UserInterface.DisplayDrinkSelections(sodaMachine.inventory);
                int userInput = UserInterface.ChoosePayment();
                if (userInput == 1)
                {
                    insertedCoins = customer.EnterPayment(customer.wallet.coins);

                    double canPriceMinusInsertedCash = sodaMachine.DrinkSelection(insertedCoins);
                    if (canPriceMinusInsertedCash < 0)
                    {
                        UserInterface.NotEnoughMoney();
                        CustomerTakesChange(insertedCoins);
                        Menu();
                    }

                    else if (sodaMachine.MakeChange(canPriceMinusInsertedCash, customer.wallet.coins, insertedCoins))
                    {
                        sodaMachine.DispenseCan(customer.backpack.cans);
                        Menu();
                    }

                }


                else if (userInput == 2)
                {
                    
                    double canPriceMinusInsertedCash = sodaMachine.DrinkSelection(customer.wallet.card);
                    if (canPriceMinusInsertedCash < 0)
                    {
                        UserInterface.NotEnoughMoney();                      
                        Menu();
                    }

                    else
                    {
                        customer.wallet.card.AvailableFunds = canPriceMinusInsertedCash; 
                        sodaMachine.DispenseCan(customer.backpack.cans);
                        Menu();
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
