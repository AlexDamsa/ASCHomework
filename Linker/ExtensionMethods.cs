using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Linker
{
    public static class ExtensionMethods
    {
        public static void WriteAllData(this List<Module> list)
        {
            foreach (Module x in list)
            {
                x.WriteAllData();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Writes in console all modules in the list
        /// </summary>
        /// <param name="list"></param>
        public static void WriteModules(this List<Module> list)
        {
            foreach (Module x in list)
            {
                x.WriteModule();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Reads next non-empty line
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        public static string NextLine(this StreamReader sr)
        {
            string line;

            do
            {
                line = sr.ReadLine();
            } while (EmptyLine(line));

            return line;

            bool EmptyLine(string ln)
            {
                foreach (char x in ln)
                {
                    if (x != ' ')
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        public static string NextLine(this StreamReader sr, int numLine)
        {
            string line = null;

            for (int i = 0; i < numLine; i++)
            {
                do
                {
                    line = sr.ReadLine();
                } while (EmptyLine(line));
            }

            return line;

            bool EmptyLine(string ln)
            {
                foreach (char x in ln)
                {
                    if (x != ' ')
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// Returns a string array whit every word in the string
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string[] GetValues(this string line)
        {
            List<string> result = new List<string>();
            result.Add("");

            foreach (char x in line)
            {
                if (x == ' ' && (result[result.Count - 1] != ""))
                {
                    result.Add("");
                }
                else if (x != ' ')
                {
                    result[result.Count-1] += x;
                }
            }

            return result.ToArray();
        }
    }
}
