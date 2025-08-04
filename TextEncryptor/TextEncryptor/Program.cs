using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace TextEncryptor
{
    internal class Program
    {
  
        static void Main(string[] args)
        {
            string alphabet = string.Empty;
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;


            bool isRunning = true;
            bool isFalseInput = false;

            while (isRunning)
            {
                Console.Clear();

                if (isFalseInput)
                {
                    ColorText.WriteColorLine("Невірний вибір, спробуйте ще раз\n", ConsoleColor.Red);
                    isFalseInput = false;
                }

                ColorText.WriteColorLine("-< Шифратор тексу >-\n", ConsoleColor.Cyan);
                Console.WriteLine("Виберіть дію:");
                Console.WriteLine("1. Шифрування Цезаря");
                Console.WriteLine("2. Шифрування Віженера");
                Console.WriteLine("esc. Вийти");
                try
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:

                            Console.Clear();
                            LanguageService.ShowLanguages();
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D1:
                                    alphabet = LanguageService.ChooseLanguage(1);
                                    break;
                                case ConsoleKey.D2:
                                    alphabet = LanguageService.ChooseLanguage(2);
                                    break;
                                case ConsoleKey.D3:
                                    alphabet = LanguageService.ChooseLanguage(3);
                                    break;
                                default:
                                    isFalseInput = true;
                                    continue;
                            }
                            Console.Clear();
                            ColorText.WriteColorLine("Введіть дію:", ConsoleColor.Yellow);
                            Console.WriteLine("1. Шифрування");
                            Console.WriteLine("2. Дешифрування");
                            Console.WriteLine("esc. Назад");
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    Console.WriteLine("Введіть текст для шифрування:");
                                    string text = Console.ReadLine();
                                    Console.WriteLine("Введіть зсув (число):");
                                    if (!int.TryParse(Console.ReadLine(), out int shift))
                                    {
                                        throw new ArgumentException("Зсув повинен бути числом");
                                    }
                                    Console.WriteLine("Результат шифрування:");
                                    ColorText.WriteColorLine(CezarEncryptor.Encrypt(text, shift, alphabet), ConsoleColor.Yellow);
                                    break;
                                case ConsoleKey.D2:
                                    Console.Clear();
                                    Console.WriteLine("Введіть текст для дешифрування:");
                                    string textToDecrypt = Console.ReadLine();
                                    Console.WriteLine("Введіть зсув (число):");
                                    if (!int.TryParse(Console.ReadLine(), out int decryptShift))
                                    {
                                        throw new ArgumentException("Зсув повинен бути числом");
                                    }
                                    Console.WriteLine("Результат дешифрування:");
                                    ColorText.WriteColorLine(CezarEncryptor.Decrypt(textToDecrypt, decryptShift, alphabet), ConsoleColor.Yellow);
                                    break;
                                case ConsoleKey.Escape:
                                    continue;
                                default:
                                    isFalseInput = true;
                                    continue;
                            }
                            Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до головного меню...");
                            Console.ReadKey(true);
                            break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        LanguageService.ShowLanguages();
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                                alphabet = LanguageService.ChooseLanguage(1);
                                break;
                            case ConsoleKey.D2:
                                alphabet = LanguageService.ChooseLanguage(2);
                                break;
                            case ConsoleKey.D3:
                                alphabet = LanguageService.ChooseLanguage(3);
                                break;
                            default:
                                isFalseInput = true;
                                continue;
                        }
                        Console.Clear();
                        ColorText.WriteColorLine("Введіть дію:", ConsoleColor.Yellow);
                        Console.WriteLine("1. Шифрування");
                        Console.WriteLine("2. Дешифрування");
                        Console.WriteLine("esc. Назад");
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    Console.WriteLine("Введіть текст для шифрування:");
                                    string text = Console.ReadLine();
                                    Console.WriteLine("Введіть ключ(текст(на тій же мові)):");
                                    string key = Console.ReadLine();
                                    Console.WriteLine("Результат шифрування:");
                                    ColorText.WriteColorLine(VijenerEncryptor.Encrypt(text, key, alphabet), ConsoleColor.Yellow);
                                    break;
                                case ConsoleKey.D2:
                                    Console.Clear();
                                    Console.WriteLine("Введіть текст для дешифрування:");
                                    string textToDecrypt = Console.ReadLine();
                                    Console.WriteLine("Введіть ключ(текст(на тій же мові)):");
                                    string keyToDecrypt = Console.ReadLine();
                                    Console.WriteLine("Результат дешифрування:");
                                    ColorText.WriteColorLine(VijenerEncryptor.Decrypt(textToDecrypt, keyToDecrypt, alphabet), ConsoleColor.Yellow);
                                    break;
                                case ConsoleKey.Escape:
                                    continue;
                                default:
                                    isFalseInput = true;
                                    continue;
                            }
                            Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до головного меню...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.Escape:
                        isRunning = false;
                        return;
                    default:
                        isFalseInput = true;
                        break;
                    }
                }
                catch (ArgumentException ex)
                {
                    ColorText.WriteColorLine($"Помилка: {ex.Message}", ConsoleColor.Red);
                    Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до головного меню...");
                    Console.ReadKey(true);
                }
            }
        }
    }
}
