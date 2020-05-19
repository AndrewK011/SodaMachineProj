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
            if(UserInterface.ChoosePayment() == 1)
            {
                customer.EnterPayment(customer.wallet.coins);
            }

            else if(UserInterface.ChoosePayment() == 2)
            {
                customer.EnterPayment(customer.wallet.card);
            }

            else
            {
                Menu();
            }

        }
    }
}
