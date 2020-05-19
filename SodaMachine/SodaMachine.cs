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
    }
}
