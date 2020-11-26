using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat_de_vanzari
{
    class Engine
    {
        static int price;

        static List<State> states = new List<State>();
        static List<Currency> currencies = new List<Currency>();

        static void Main(string[] args)
        {
            SetPrice(20);

            //=====States=============================
            /*states.Add(new State(0));
            states.Add(new State(5));
            states.Add(new State(10));
            states.Add(new State(15));
            states.Add(new State(20));
            states.Add(new State(25));*/

            //=====Currency===========================
            currencies.Add(new Currency(5));
            currencies.Add(new Currency(10));
            currencies.Add(new Currency(25));
            //currencies.Add(new Currency(7));

            //========================================

            //BuildStates();//
            states.Add(new State(0));

            if (State.FindStateByAmount(states, 0) != null)
            {
                State.currenntState = State.FindStateByAmount(states, 0);
            }
            else
            {
                throw new Exception("State with amount 0 needed");
            }


            #region Engine
            Console.WriteLine($"PRICE: {price}\n");

            Console.WriteLine("Insert currency");
            ShowCurency();
            Console.WriteLine();

            while (true)
            {
                //ShowStates(states);
                
                GetCurency().NextState(states);
                
                Console.WriteLine($"status: {State.currenntState.amount}");

                Console.WriteLine();
            }
            #endregion
        }


        static void BuildStates()
        {
            int minCurrency = currencies[0].amount;
            int maxCurrency = currencies[0].amount;

            states.Add(new State(0));

            if (price != 0)
            {
                states.Add(new State(price));
            }

            foreach (Currency x in currencies)
            {
                if(x.amount < minCurrency)
                {
                    minCurrency = x.amount;
                }
                if (x.amount > maxCurrency)
                {
                    maxCurrency = x.amount;
                }

            }

            for (int i = minCurrency; i<= price - minCurrency + maxCurrency; i+=minCurrency)
            {
                states.Add(new State(i));
            }

            /*foreach (Currency x in currencies)
            {
                states.Add(new State(price - minCurrency + x.amount));
            }*/
        }

        static void ShowStates(List<State> states)
        {
            Console.WriteLine("STATES");

            foreach (State x in states)
            {
                Console.WriteLine($"State: {x.amount}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Gets an input currency
        /// </summary>
        /// <returns>One of the currencies in the list or null if the specified currency does not exist</returns>
        static Currency GetCurency()
        {
            int input;

            try
            {
                Console.Write("->");

                input = Int32.Parse(Console.ReadLine());

                foreach (Currency x in currencies)
                {
                    if (x.amount == input)
                    {
                        return x;
                    }
                }

                Console.WriteLine($"Currency {input} does not exist");

                ShowCurency();

                return GetCurency();
            }
            catch
            {
                Console.WriteLine("Invalid input");
                ShowCurency();

                return GetCurency();
            }
        }

        /// <summary>
        /// Writes all currencies on a single line;
        /// </summary>
        static void ShowCurency()
        {
            Console.Write("CURRENCIES:   ");

            foreach (Currency x in currencies)
            {
                Console.Write($"{x.amount}     ");
            }
            Console.WriteLine();
        }


        #region Setters & Getters
        public static void SetPrice(int newPrice)
        {
            price = newPrice;
        }
        public static int GetPrice()
        {
            return price;
        }

        public static void AddState(int amount)
        {
            states.Add(new State(amount));
        }
        public static List<State> GetStates()
        {
            return states;
        }

        public static void AddCurrency(int amount)
        {
            currencies.Add(new Currency(amount));
        }
        public static List<Currency> GetCurrencies()
        {
            return currencies;
        }
        #endregion
    }
}
