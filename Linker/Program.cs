﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Linker
{
    class Program
    {
        static StreamReader streamReader = File.OpenText("IO/input-1");
        static List<Module> modules = new List<Module>();

        static void Main(string[] args)
        {
            FirstStep();
            

            modules.WriteAllModules();
        }


        static void FirstStep()
        {
            int numberOfModules = int.Parse(streamReader.NextLine());

            for (int i = 0; i < numberOfModules; i++)
            {
                string[] definitionList = streamReader.NextLine().GetValues();
                string[] text = streamReader.NextLine(2).GetValues();

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
        }

    }
}
