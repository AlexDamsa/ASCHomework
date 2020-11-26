using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat_de_vanzari
{
    class State
    {
        public static State currenntState;

        public int amount;

        
        public void StateStatus(List<State> states)
        {
            Console.WriteLine();

            if (amount < Engine.GetPrice())
            {
                Console.WriteLine("Not enough money to buy the product");
            }
            else if (amount == Engine.GetPrice())
            {
                Console.WriteLine("Merchandise dispensed");
             
                currenntState = FindStateByAmount(Engine.GetStates(), 0);
            }
            else
            {
                Console.WriteLine($"Merchandise dispensed and {currenntState.amount - Engine.GetPrice()} was returned in change");
                
                currenntState = FindStateByAmount(Engine.GetStates(), 0);
            }
        }

        public static State FindStateByAmount(List<State> states, int amount)
        {
            foreach (State x in states)
            {
                if (x.amount == amount)
                {
                    return x;
                }
            }

            return null;
        }

        #region Constructors
        
        public State(int amount)
        {
            this.amount = amount;
        }
        #endregion
    }
}
