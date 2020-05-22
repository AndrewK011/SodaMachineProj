using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        public List<Coin> register;
        public List<Can> inventory;
        public Can chosenCan;
        public bool enoughChangeInRegister = true;
        bool emptyQuarters = false;
        bool emptyDimes = false;
        bool emptyNickels = false;       

        public SodaMachine()
        {
            register = new List<Coin>();
            inventory = new List<Can>();
        }

        public void StartingRegister(int quarters, int dimes, int nickels, int pennies)
        {
            for (int i = 0; i < quarters; i++)
            {
                Quarter quarter = new Quarter();
                register.Add(quarter); ;
            }
            for (int i = 0; i < dimes; i++)
            {
                Dime dime = new Dime();
                register.Add(dime);
            }
            for (int i = 0; i < nickels; i++)
            {
                Nickel nickel = new Nickel();
                register.Add(nickel);
            }
            for (int i = 0; i < pennies; i++)
            {
                Penny penny = new Penny();
                register.Add(penny);
            }

        }

        public void StartingInventory(int rootBeers, int colas, int orangeSodas)
        {
            for (int i = 0; i < rootBeers; i++)
            {
                RootBeer rootBeer = new RootBeer();
                inventory.Add(rootBeer);
            }
            for (int i = 0; i < colas; i++)
            {
                Cola cola = new Cola();
                inventory.Add(cola);
            }
            for (int i = 0; i < orangeSodas; i++)
            {
                OrangeSoda orangeSoda = new OrangeSoda();
                inventory.Add(orangeSoda);
            }
        }

        public double DrinkSelection(List<Coin> insertedCoins)
        {
            chosenCan = UserInterface.SelectDrink(inventory);
            return CanPriceMinusCoinsInserted(chosenCan, insertedCoins);
        }

        public double DrinkSelection(Card card)
        {
            chosenCan = UserInterface.SelectDrink(inventory);
            return CanPriceMinusCardBalance(chosenCan, card);
        }

        public double CanPriceMinusCardBalance(Can chosenCan, Card card)
        {
            double result = card.AvailableFunds - chosenCan.Cost;
            return Math.Round(result, 2);
        }

        public double CanPriceMinusCoinsInserted(Can chosenCan, List<Coin> insertedCoins)
        {
            double coinTotal = 0.0;
            foreach (Coin coin in insertedCoins)
            {
                coinTotal += coin.Value;
            }
            double result = coinTotal - chosenCan.Cost;
            return Math.Round(result,2);
        }



        public void DispenseCan(List<Can> userBackpack)
        {

            if (inventory.Remove(chosenCan) == false)
            {
                UserInterface.InventoryShortage();
            }
            else
            {
                userBackpack.Add(chosenCan);
            }
        }

        public bool MakeChange(double coinsMinusCost, List<Coin> userWallet, List<Coin> insertedCoins)
        {
            List<Coin> coinsToGiveBack = new List<Coin>();
            List<Coin> copyOfRegister = new List<Coin>();
            

            foreach(Coin coin in register)
            {
                copyOfRegister.Add(coin);
            }
            

            foreach(Coin coin in insertedCoins)
            {
                register.Add(coin);
            }

            emptyQuarters = false;
            emptyDimes = false;
            emptyNickels = false;

            while (coinsMinusCost != 0 && enoughChangeInRegister == true)
            {
                if (coinsMinusCost >= 0.25 && emptyQuarters == false)
                {
                    coinsMinusCost = MakeQuarterChange(coinsToGiveBack, coinsMinusCost);
                }

                else if (coinsMinusCost >= 0.1 && emptyDimes == false)
                {
                    coinsMinusCost = MakeDimeChange(coinsToGiveBack, coinsMinusCost);
                }

                else if (coinsMinusCost >= 0.05 && emptyNickels == false)
                {
                    coinsMinusCost = MakeNickelChange(coinsToGiveBack, coinsMinusCost);
                }

                else
                {
                    coinsMinusCost = MakePennyChange(coinsToGiveBack, coinsMinusCost);
                }
 
                coinsMinusCost = Math.Round(coinsMinusCost,2);

            }

            if(enoughChangeInRegister)
            {
               foreach(Coin coin in coinsToGiveBack)
                {
                    userWallet.Add(coin);   
                    
                }
                return true;
            }

            else
            {
                foreach (Coin coin in register)
                {
                    userWallet.Add(coin);

                }
                register = copyOfRegister;
                return false;
            }
        }

        public double MakeQuarterChange(List<Coin> coinsToGiveBack, double coinsMinusCost)
        {
            int divisibleByQuarter = (int)(coinsMinusCost / 0.25);
            double changeRemaining = coinsMinusCost % 0.25;
            int counter = 0;

            for (int i = 0; i < register.Count; i++)
            {
                if (counter == divisibleByQuarter)
                {
                    break;
                }

                else if (register[i].name == "quarter")
                {
                    coinsToGiveBack.Add(register[i]);
                    register.RemoveAt(i);
                    counter++;
                    i--;
                }

            }

            if (divisibleByQuarter > counter)
            {
                emptyQuarters = true;
            }

            changeRemaining += (divisibleByQuarter - counter) * 0.25;
                
          
            return changeRemaining;
        }

        public double MakeDimeChange(List<Coin> coinsToGiveBack, double coinsMinusCost)
        {
            
            int divisibleByDime = (int)(coinsMinusCost / 0.1);
            

            double changeRemaining = (100*coinsMinusCost) % (100*0.1)/100;
            int counter = 0;

            for (int i = 0; i < register.Count; i++)
            {
                if (counter == divisibleByDime)
                {
                    break;
                }
                else if (register[i].name == "dime")
                {
                    coinsToGiveBack.Add(register[i]);
                    register.RemoveAt(i);
                    counter++;
                    i--;
                }


            }

            if (divisibleByDime > counter)
            {
                emptyDimes = true;
            }
                changeRemaining += (divisibleByDime - counter) * 0.1;
               
            
            return changeRemaining;
        }

        public double MakeNickelChange(List<Coin> coinsToGiveBack, double coinsMinusCost)
        {
            int divisibleByNickel = (int)(coinsMinusCost / 0.05);
            
            
            double changeRemaining = (100*coinsMinusCost) % (100*0.05)/100;
            int counter = 0;

            for (int i = 0; i < register.Count; i++)
            {
                if (counter == divisibleByNickel)
                {
                    break;
                }
                else if (register[i].name == "nickel")
                {
                    coinsToGiveBack.Add(register[i]);
                    register.RemoveAt(i);
                    counter++;
                    i--;
                }

            }
            if (divisibleByNickel > counter)
            {
                emptyNickels = true;
            }
                changeRemaining += (divisibleByNickel - counter) * 0.05;
               
            
            return changeRemaining;
        }

        public double MakePennyChange(List<Coin> coinsToGiveBack, double coinsMinusCost)
        {
            int divisibleByPenny = (int)(coinsMinusCost / 0.01);
            
            double changeRemaining = (100*coinsMinusCost) % (100*0.01)/100;
            int counter = 0;

            for (int i = 0; i < register.Count; i++)
            {
                if (counter == divisibleByPenny)
                {
                    break;
                }
                else if (register[i].name == "penny")
                {
                    coinsToGiveBack.Add(register[i]);
                    register.RemoveAt(i);
                    counter++;
                    i--;
                }

                else if(i == register.Count - 1)
                {
                    enoughChangeInRegister = false;
                    break;
                }
            }
            return changeRemaining;
        }


    }
}
