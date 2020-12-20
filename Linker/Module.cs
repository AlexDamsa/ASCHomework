using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linker
{
    public class Module
    {
        public int baseAddress;

        public List<Symbol> symbols;

        public Dictionary<Symbol, int> usingList;

        public List<int> words;

        public void WriteAllData()
        {
            Console.WriteLine($"base address = {baseAddress}");

            Console.WriteLine();

            Console.WriteLine($"Symbols = {symbols.Count}");
            foreach (Symbol x in symbols)
            {
                Console.WriteLine($"name = {x.Name}");
                Console.WriteLine($"relative address = {x.RelativeAdress}");
                Console.WriteLine($"absolute address = {x.absoluteAddress}");
                Console.WriteLine($"---------------------");
            }

            Console.WriteLine();

            Console.WriteLine($"Using list = {usingList.Count}");
            for (int i = 0; i < usingList.Count; i++)
            {
                Console.WriteLine($"key = {usingList.ElementAt(i).Key}");
                Console.WriteLine($"value = {usingList.ElementAt(i).Value}");
                Console.WriteLine($"---------------------");
            }

            Console.WriteLine();

            Console.WriteLine($"Words = {words.Count}");
            foreach (int x in words)
            {
                Console.WriteLine($"{x} ");
            }
            Console.WriteLine();
            Console.WriteLine($"================================");

        }
        public void WriteModule()
        {
            if (symbols.Count != null)
            {
                Console.Write(symbols.Count);
                if (symbols.Count != 0)
                {
                    foreach (Symbol x in symbols)
                    {
                        Console.Write($" {x.Name} {x.RelativeAdress}");
                    }
                }
            }
            else
            {
                Console.Write("Definition list");
            }

            Console.WriteLine();

            if (usingList != null)
            {
                Console.Write(usingList.Count);
                if (usingList.Count != 0)
                {
                    for (int i = 0; i < usingList.Count; i++)
                    {
                        Console.Write($" {usingList.ElementAt(i).Key.Name} {usingList.ElementAt(i).Value}");
                    }
                }
            }
            else
            {
                Console.Write("Using list");
            }

            Console.WriteLine();

            if (words != null)
            {
                Console.Write(words.Count);
                if (words.Count != 0)
                {
                    foreach (int x in words)
                    {
                        Console.Write($" {x}");
                    }
                }
            }
            else
            {
                Console.Write("Text");
            }

            Console.WriteLine();
        }


        public Module(int baseAddress, List<Symbol> symbols, List<int> words)
        {
            this.baseAddress = baseAddress;
            this.symbols = symbols;
            this.words = words;
        }

        public Module()
        {
            baseAddress = 0;
            symbols = new List<Symbol>();
            words = new List<int>();
            usingList = new Dictionary<Symbol, int>();
        }
    }
}
