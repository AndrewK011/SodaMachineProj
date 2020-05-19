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
            sodaMachine.StartingInventory(10,10,10);
            sodaMachine.StartingRegister(20,10,20,50);
            customer = new Customer();

        }
    }
}
