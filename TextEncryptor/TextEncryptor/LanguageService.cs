using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace TextEncryptor
{
    internal static class LanguageService
    {
        private static string[] alphabets = 
            { 
            "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя",
            "абвгдеёжзийклмнопрстуфхцчшщъыьэюя",
            "abcdefghijklmnopqrstuvwxyz" 
            };

        public static void ShowLanguages()
        {
            ColorText.WriteColorLine("Виберіть мову:", ConsoleColor.Cyan);
            Console.WriteLine("1. Українська");
            Console.WriteLine("2. Російська");
            Console.WriteLine("3. Англійська");
        }
        public static string ChooseLanguage(int choise)
        {
            switch (choise)
            {
                case 1:
                    return alphabets[0];
                case 2:
                    return alphabets[1];
                case 3:
                    return alphabets[2];
                default:
                    throw new ArgumentException("Невірний вибір мови");
            }
        }
    }
}
