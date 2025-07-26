using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace ContactBook_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Contacts contacts = new Contacts();

            bool Running = true;
            bool invalidInput = false;
            bool firstRun = true;

            while (Running)
            {
                Console.Clear();
                if (invalidInput)
                {
                    ColorText.WriteColorLine("Не існуючий варіант, спробуйте ще раз!\n", ConsoleColor.Red);
                    invalidInput = false;
                }
                ColorText.WriteColorLine("-< Книга контактів V2>-\n", ConsoleColor.Yellow);
                Console.WriteLine("Виберіть дію:");

                Console.WriteLine("1. Додати контакт");
                Console.WriteLine("2. Вивести всі контакти");
                Console.WriteLine("3. Видалити контакт");
                Console.Write("4. Змінити контакт");
                if (firstRun)
                {
                    Console.Write(" <- New");
                }

                Console.WriteLine("\nesc. Вийти");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        ColorText.WriteColorLine("Введіть ім'я контакту:", ConsoleColor.Cyan);
                        string name = Console.ReadLine();
                        ColorText.WriteColorLine("Введіть номер телефону:", ConsoleColor.Magenta);
                        string phoneNumber = Console.ReadLine();
                        contacts.AddContact(name, phoneNumber);
                        ColorText.WriteColorLine("\nНатисніть будь-яку клавішу для повернення до меню.", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        contacts.ShowContacts();
                        ColorText.WriteColorLine("\nНатисніть будь-яку клавішу для повернення до меню.", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        ColorText.WriteColorLine("Введіть ім'я контакту для видалення:", ConsoleColor.DarkGray);
                        string name2 = Console.ReadLine();
                        contacts.DeleteContact(name2);
                        ColorText.WriteColorLine("\nНатисніть будь-яку клавішу для повернення до меню.", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        ColorText.WriteColorLine("Введіть ім'я контакту для зміни:", ConsoleColor.DarkGray);
                        string oldName = Console.ReadLine();
                        ColorText.WriteColorLine("Введіть нове ім'я контакту:", ConsoleColor.Cyan);
                        string newName = Console.ReadLine();
                        ColorText.WriteColorLine("Введіть новий номер телефону:", ConsoleColor.Magenta);
                        string newPhoneNumber = Console.ReadLine();
                        contacts.ChangeContact(oldName, newName, newPhoneNumber);
                        ColorText.WriteColorLine("\nНатисніть будь-яку клавішу для повернення до меню.", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.Escape:
                        Running = false;
                        break;
                    default:
                        invalidInput = true;
                        break;
                }
                firstRun = false;
            }
        }
    }
}
