using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Linker
{
    class Program
    {
        static string path = "IO/input-1";
        public static List<Module> modules = new List<Module>();
        

        static void Main(string[] args)
        {
            FirstStep();
            SecondStep();

            //modules.WriteModules();

            //modules.WriteAllData();

            //Console.WriteLine();

            Module.WriteSymbolTable();
            Console.WriteLine();
            Module.WriteMemoryMap();

        }


        private static void FirstStep()
        {
            StreamReader streamReader = File.OpenText(path);

            int numberOfModules = int.Parse(streamReader.NextLine());

            List<string> allUsingLists = new List<string>(); 

            for (int i = 0; i < numberOfModules; i++)
            {
                string[] definitionList = streamReader.NextLine().GetValues();
                string usings = streamReader.NextLine();
                string[] text = streamReader.NextLine().GetValues();

                allUsingLists.Add(usings);
                modules.Add(new Module());

                BuildDefinitionList();
                BuildText();


                void BuildDefinitionList()
                {
                    if (definitionList[0] != "0")
                    {
                        for (int j = 1; j < definitionList.Length; j += 2)
                        {
                            modules[i].symbols.Add(new Symbol(definitionList[j], i, int.Parse(definitionList[j + 1])));
                        }
                    }
                    else
                    {
                        modules[i].symbols.Clear();
                    }
                }
                void BuildText()
                {
                    for (int j = 1; j < text.Length; j++)
                    {
                        modules[i].words.Add(int.Parse(text[j]));
                    }
                }
            }

            BuildUsingList();

            #region Solve relative addresses for symbols and set bae addresses for modules
            
            modules[0].baseAddress = 0;
            foreach (Symbol x in modules[0].symbols)
            {
                x.absoluteAddress = x.RelativeAdress;
            }
            for (int i = 1; i < modules.Count; i++)
            {
                modules[i].baseAddress = modules[i - 1].baseAddress + modules[i - 1].words.Count;

                foreach (Symbol x in modules[i].symbols)
                {
                    x.absoluteAddress = x.RelativeAdress + modules[i].baseAddress;
                }
            }
            
            #endregion


            void BuildUsingList()
            {
                string[] usingList;
                for (int i = 0; i < allUsingLists.Count; i++)
                {
                    usingList = allUsingLists[i].GetValues();

                    if (usingList[0] != "0")
                    {
                        for (int j = 1; j < usingList.Length; j += 2)
                        {
                            modules[i].usingList.Add(modules.FindSymbolByName(usingList[j]), int.Parse(usingList[j + 1]));
                        }
                    }
                }
            }


            streamReader.Close();
        }

        private static void SecondStep()
        {
            /*foreach (Module x in modules)
            {
                for (int i = 0; i < x.words.Count; i++)
                {
                    Module.MemoriMap.Add(x.baseAddress + i, x.words[i]);
                }
            }*/

            int word;
            foreach (Module x in modules)
            {
                for (int i = 0; i < x.words.Count; i++)
                {
                    word = x.words[i];

                    switch (word % 10)
                    {
                        case 1:
                            Push(x.baseAddress + i, word / 10);
                            break;

                        case 2:
                            Push(x.baseAddress + i, word / 10);
                            break;

                        case 3:
                            Chase3Behaviour();
                            break;

                        case 4:
                            Chase4Behaviour();
                            break;
                    }


                    void Chase3Behaviour()
                    {
                        word /= 10;

                        int carry = word % 1000;

                        word = word / 1000 * 1000;
                        word += (x.baseAddress + carry);

                        Push(x.baseAddress + i, word);
                    }
                    void Chase4Behaviour()
                    {
                        //Symbol symbol = x.CompareUses(word, i);
                        Symbol symbol = x.CompareUses(i);

                        //Console.WriteLine(symbol.Name);

                        if (symbol != null)
                        {
                            int result = word / 10000 * 1000;

                            result += symbol.absoluteAddress;

                            Push(x.baseAddress + i, result);
                        }
                    }
                }
            }


            void Push(int address, int reference)
            {
                Module.MemoriMap.Add(address, reference);
            }
        }
    }
}
