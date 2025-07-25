using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace TheaterSeats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            SeatsManager seatsManager = new SeatsManager(40);

            bool isRunning = true;
            bool falseInput = false;
            while (isRunning)
            {
                Console.Clear();

                if (falseInput)
                {
                    ColorText.WriteColorLine("Невірний ввід. Спробуйте ще раз.\n", ConsoleColor.Red);
                    falseInput = false;
                }

                ColorText.WriteColorLine("-< Менеджер місць кінотеатру >-", ConsoleColor.Yellow);
                Console.WriteLine("\nВведіть номер дії: ");
                Console.WriteLine("1. Переглянути місця");
                Console.WriteLine("2. Зайняти місце");
                ColorText.WriteColorLine("esc. Вийти", ConsoleColor.Red);
                switch (Console.ReadKey(true).Key)
                    {
                    case ConsoleKey.D1:
                        seatsManager.ShowSeats();
                        Console.WriteLine("\nНатисніть будь-яку клавішу для повернення в меню...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D2:
                        seatsManager.TakeSeat();
                        break;
                    case ConsoleKey.Escape:
                        isRunning = false;
                        break;
                    default:
                        falseInput = true;
                        break;
                }

            }
        }
    }
}
