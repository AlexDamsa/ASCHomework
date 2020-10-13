using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            int processingPower;
            float time;
            string response;

            do
            {
                Console.WriteLine("Conform legii lui Gordon Moore, puterea de calcul a unui procesor se dubleaza la fiecare 18 luni");
                Console.WriteLine();

                Console.WriteLine("Introduceti puterea de procesare:");
                Console.WriteLine();
                Console.Write("-> ");

                while (!Int32.TryParse(Console.ReadLine(), out processingPower))
                {
                    Console.WriteLine("Te rog sa introduci un numar valid");
                    Console.Write("-> ");
                }

                time = (float)Math.Log(processingPower, 2) * 1.5f;

                Console.WriteLine();
                Console.WriteLine($"Timpul necesar pentru a ajunge la puterea de procesare de {processingPower} de ori mai mare decat cea actuala este de {time} ani");


                Console.WriteLine();
                Console.WriteLine("Doriti sa calculati timpul necesar pentru a ajunge la alta putere de procesare? (y/n)");
                Console.Write("->");
                do
                {
                    response = Console.ReadLine();
                } while (response != "y" && response != "n");

                Console.Clear();

            } while (response == "y");



            Console.WriteLine("──────▄▀▄─────▄▀▄");
            Console.WriteLine("─────▄█░░▀▀▀▀▀░░█▄");
            Console.WriteLine("─▄▄──█░░░░░░░░░░░█──▄▄");
            Console.WriteLine("█▄▄█─█░░▀░░┬░░▀░░█─█▄▄█");
            Console.WriteLine("Ok, Bye!");

        }
    }
}

