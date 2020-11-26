using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat_de_vanzari
{
    class Currency
    {
        public int amount;



        /// <summary>
        /// Gets the next state based on the currency amount
        /// </summary>
        /// <param name="states">A list of State objects to chose from</param>
        /// <returns></returns>
        public State NextState(List<State> states)
        {
            foreach (State x in states)
            {
                if (State.currenntState.amount + amount == x.amount)
                {
                    State.currenntState = x;
                    State.currenntState.StateStatus(Engine.GetStates());

                    return x;
                }
            }

            Engine.GetStates().Add(new State(State.currenntState.amount + amount));
            return NextState(Engine.GetStates());
            //throw new Exception($"A state with amount {State.currenntState.amount + amount} is needed");
        }

        public Currency(int amount)
        {
            this.amount = amount;
        }
    }
}
