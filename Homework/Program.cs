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
            uint processingPower;
            float time;
            string response;

            do // programul se repeta daca utilizatorul vrea sa faca asta
            {
                Console.WriteLine("Conform legii lui Gordon Moore, puterea de calcul a unui procesor se dubleaza la fiecare 18 luni");
                Console.WriteLine();

                Console.WriteLine("Introdu puterea de procesare:");
                Console.WriteLine();
                Console.Write("-> ");

                // verific daca input ul oferit de utilizator poate fi convertit in int
                while (!UInt32.TryParse(Console.ReadLine(), out processingPower))
                {
                    Console.WriteLine("Te rog sa introduci un numar valid");
                    Console.Write("-> ");
                }

                // calculul timpului necesar pentru a se ajunge la puterea de calcul aleasa
                time = (float)Math.Log(processingPower, 2) * 1.5f;

                Console.WriteLine();
                Console.WriteLine($"Timpul necesar pentru a ajunge la puterea de procesare de {processingPower} de ori mai mare decat cea actuala este de {time} ani");


                Console.WriteLine();
                Console.WriteLine("Vrei sa calculezi timpul necesar pentru a ajunge la alta putere de procesare? (y/n)");
                Console.Write("->");
                
                do // verificarea raspunsului utilizatorului 
                {
                    response = Console.ReadLine();
                } while (response != "y" && response != "n");

                Console.Clear();

            } while (response == "y");


            // cute message
            Console.WriteLine("Ok, Bye!");
            Console.WriteLine("──────▄▀▄─────▄▀▄");
            Console.WriteLine("─────▄█░░▀▀▀▀▀░░█▄");
            Console.WriteLine("─▄▄──█░░░░░░░░░░░█──▄▄");
            Console.WriteLine("█▄▄█─█░░▀░░┬░░▀░░█─█▄▄█");
            
        }
    }
}

