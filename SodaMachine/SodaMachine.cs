using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        public List<Coin> register;
        public List<Can> inventory;

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

        public List<Coin> GiveChangeBack(List<Coin> coins)
        {
            return coins;
        }

        public List<Coin> MakeChange(List<Coin> coinsInRegister, double coinsMinusCost)
        {
            List<Coin> coinsToGiveBack = new List<Coin>();

            while (coinsMinusCost != 0)
            {
                if (coinsMinusCost / 0.25 != 0)
                {
                    coinsMinusCost = MakeQuarterChange(coinsToGiveBack, coinsMinusCost, coinsInRegister);
                }

                else if (coinsMinusCost / 0.1 != 0)
                {
                    coinsMinusCost = MakeDimeChange(coinsToGiveBack, coinsMinusCost, coinsInRegister);
                }

                else if (coinsMinusCost / 0.05 != 0)
                {
                    coinsMinusCost = MakeNickelChange(coinsToGiveBack, coinsMinusCost, coinsInRegister);
                }

                else
                {
                    coinsMinusCost = MakePennyChange(coinsToGiveBack, coinsMinusCost, coinsInRegister);
                }

            }
            


            return coinsToGiveBack;
        }

        public double MakeQuarterChange(List<Coin> coinsToGiveBack, double coinsMinusCost, List<Coin> coinsInRegister)
        {
            int divisibleByQuarter = (int)(coinsMinusCost / 0.25);
            double changeRemaining = coinsMinusCost % 0.25;
            int counter = 0;

            for (int i = 0; i < coinsInRegister.Count; i++)
            {
                if (coinsInRegister[i].name == "quarter")
                {
                    coinsToGiveBack.Add(coinsInRegister[i]);
                    coinsInRegister.RemoveAt(i);
                    counter++;
                }

                if (counter == divisibleByQuarter)
                {
                    break;
                }

            }
            return changeRemaining;
        }

        public double MakeDimeChange(List<Coin> coinsToGiveBack, double coinsMinusCost, List<Coin> coinsInRegister)
        {
            int divisibleByDime = (int)(coinsMinusCost / 0.1);
            double changeRemaining = coinsMinusCost % 0.1;
            int counter = 0;

            for (int i = 0; i < coinsInRegister.Count; i++)
            {
                if (coinsInRegister[i].name == "dime")
                {
                    coinsToGiveBack.Add(coinsInRegister[i]);
                    coinsInRegister.RemoveAt(i);
                    counter++;
                }

                if (counter == divisibleByDime)
                {
                    break;
                }

            }
            return changeRemaining;
        }

        public double MakeNickelChange(List<Coin> coinsToGiveBack, double coinsMinusCost, List<Coin> coinsInRegister)
        {
            int divisibleByNickel = (int)(coinsMinusCost / 0.05);
            double changeRemaining = coinsMinusCost % 0.05;
            int counter = 0;

            for (int i = 0; i < coinsInRegister.Count; i++)
            {
                if (coinsInRegister[i].name == "nickel")
                {
                    coinsToGiveBack.Add(coinsInRegister[i]);
                    coinsInRegister.RemoveAt(i);
                    counter++;
                }

                if (counter == divisibleByNickel)
                {
                    break;
                }

            }
            return changeRemaining;
        }

        public double MakePennyChange(List<Coin> coinsToGiveBack, double coinsMinusCost, List<Coin> coinsInRegister)
        {
            int divisibleByPenny = (int)(coinsMinusCost / 0.01);
            double changeRemaining = coinsMinusCost % 0.01;
            int counter = 0;

            for (int i = 0; i < coinsInRegister.Count; i++)
            {
                if (coinsInRegister[i].name == "penny")
                {
                    coinsToGiveBack.Add(coinsInRegister[i]);
                    coinsInRegister.RemoveAt(i);
                    counter++;
                }

                if (counter == divisibleByPenny)
                {
                    break;
                }

            }
            return changeRemaining;
        }


    }
}
