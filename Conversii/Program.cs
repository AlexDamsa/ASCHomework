using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversii
{
    class Program
    {
        const int fromLeterToDigit = 55;

        static void Main(string[] args)
        {
            string givenNumber;
            int currentBase;
            int targetBase;


            #region Introduction
            Console.WriteLine(" __| |____________________________________________| |__");
            Console.WriteLine("(__   ____________________________________________   __)");
            Console.WriteLine("   | |                                            | |");
            Console.WriteLine("   | |               BASE CONVERTER               | |");
            Console.WriteLine(" __| |____________________________________________| |__");
            Console.WriteLine("(__   ____________________________________________   __)");
            Console.WriteLine("   | |                                            | |");
            #endregion


            // TODO check for valid input
            
            Console.Write("Current Bse: ");
            currentBase = int.Parse(Console.ReadLine());

            Console.Write("Number: ");
            givenNumber = Console.ReadLine();

            Console.Write("Target Bse: ");
            targetBase = int.Parse(Console.ReadLine());



            Console.WriteLine($"\n-> {ConvertBase(givenNumber, currentBase, targetBase)}\n");

            
            

            //Console.WriteLine($"{ConvertTo10("2a", 15)} correct");
            //Console.WriteLine(ConvertFrom10("40.74666667", 15));
        }


        static string ConvertBase(string number, int currentBase, int targetBase)
        {
            // if the current base == target base just return the given number
            if (currentBase == targetBase)
            {
                return number;
            }

            switch (currentBase)
            {
                case 10:
                    return ConvertFrom10(number, targetBase);
                default:
                    return ConvertFrom10(ConvertTo10(number, currentBase), targetBase);
            }
        }

        static string ConvertTo10(string number, int currentBase)
        {
            float result = 0f;

            int exponent = 0;

            number = number.ToUpper();

            // TODO sismplify the finding max exponent process
            // find the max exponent 
            for (int i = 1; i < number.Length; i++)
            {
                if (number[i].Equals('.'))
                {
                    break;
                }

                exponent++;
            }

            // build up the number in base 10
            for (int i = 0; i < number.Length; i++)
            {
                if (!number[i].Equals('.'))
                {
                    float toAdd;

                    toAdd = (float)Math.Pow(currentBase, exponent);


                    if ((int)number[i] >= 65)
                    {
                        toAdd *= (int)number[i] - fromLeterToDigit;
                    }
                    else
                    {
                        toAdd *= Int32.Parse(number[i].ToString());
                    }


                    result += toAdd;

                    toAdd = 0;

                    exponent--;
                }
            }

            return result.ToString();
        }

        // TODO detect repeating decimal numbers
        static string ConvertFrom10(string number, int targetBase)
        {
            int mostDecimals = 10;

            string result = "";

            string[] parts = number.Split('.');

            int leftPart = Int32.Parse(parts[0]);
            float rightPart = 0;
            if (parts.Length > 1)
            {
                rightPart = float.Parse("0." + parts[1]);
            }

            Stack<int> leftDigits = new Stack<int>();
            Queue<int> rightDigits = new Queue<int>();

            
            // get the digits of the left side of the number in target base
            while (leftPart != 0)
            {
                leftDigits.Push(leftPart % targetBase);

                leftPart /= targetBase;
            }

            int toAdd;

            // build up the iteger part of the number
            while (leftDigits.Count != 0)
            {
                toAdd = leftDigits.Pop();

                if (toAdd < 10)
                {
                    result += toAdd.ToString();
                }
                else
                {
                    toAdd += fromLeterToDigit;

                    result += Convert.ToChar(toAdd).ToString();
                }
            }

            // if the decimal part exists proceed to build it
            if (parts.Length > 1)
            {
                result += ".";

                // get the digits of the decimal side of the number in target base
                while ((int)rightPart != rightPart)
                {
                    if (mostDecimals == 0)
                    {
                        break;
                    }
                    mostDecimals--;

                    rightPart *= targetBase;
                    
                    rightDigits.Enqueue((int)rightPart);
                    
                    rightPart -= (int)rightPart;
                }

                // build up the decimal part of the number
                while (rightDigits.Count != 0)
                {
                    toAdd = rightDigits.Dequeue();

                    if (toAdd < 10)
                    {
                        result += toAdd.ToString();
                    }
                    else
                    {
                        toAdd += fromLeterToDigit;

                        result += Convert.ToChar(toAdd).ToString();
                    }
                }
            }


            return result;
        }
    }
}
