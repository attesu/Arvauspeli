using System;
using System.Collections.Generic;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tulostaulukko
            List<(string PlayerName, int Guesses)> scoreboard = new List<(string, int)>();

            while (true)
            {
                Random random = new Random();
                int arvottuNumero = random.Next(0, 101); // Arpoo numeron väliltä 0-100.
                int arvaustenLukumaara = 0;

                Console.WriteLine("\nTervetuloa numeron arvauspeliin!");
                Console.Write("Anna pelaajan nimi: ");
                string pelaajanNimi = Console.ReadLine();

                Console.WriteLine("Arvaa numero väliltä 0-100.");

                while (true)
                {
                    Console.Write("Anna arvauksesi: ");
                    if (int.TryParse(Console.ReadLine(), out int arvaus))
                    {
                        arvaustenLukumaara++;

                        if (arvaus > arvottuNumero)
                        {
                            Console.WriteLine("Liian suuri.");
                        }
                        else if (arvaus < arvottuNumero)
                        {
                            Console.WriteLine("Liian pieni. Yritä uudelleen.");
                        }
                        else
                        {
                            Console.WriteLine($"Oikein! Arvasit numeron {arvaustenLukumaara} yrityksellä.");
                            scoreboard.Add((pelaajanNimi, arvaustenLukumaara));
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Virheellinen syöte. Anna kokonaisluku!");
                    }
                }

                // Tulosta scoreboard
                Console.WriteLine("\nTulostaulukko:");
                Console.WriteLine("Pelaaja        Yritykset");
                Console.WriteLine("------------------------");
                foreach (var entry in scoreboard)
                {
                    Console.WriteLine($"{entry.PlayerName.PadRight(14)} {entry.Guesses}");
                }

                Console.Write("\nHaluatko pelata uudelleen? (k/e): ");
                string uudelleen = Console.ReadLine();
                if (uudelleen.ToLower() != "k")
                {
                    break;
                }
            }

            Console.WriteLine("\nKiitos pelaamisesta! Nähdään pian uudelleen.");
        }
    }
}