using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ContactBook_V2;

namespace NotesAndPasswordGenerator
{
    internal class Contacts
    {
        private List<Contact> contacts = new List<Contact>();

        public void AddContact(string name, string phoneNumber)
        {
            if (contacts.Any(c => c.Name == name))
            {
                ColorText.WriteColorLine("Контакт з таким ім'ям вже існує!", ConsoleColor.Red);
            }
            else
            {
                contacts.Add(new Contact(name, phoneNumber));
                ColorText.WriteColorLine("Контакт успішно додано!", ConsoleColor.Green);
            }
        }

        public void ShowContacts() 
        {
            if (contacts.Count < 1)
            {
                ColorText.WriteColorLine("Контакти відсутні!", ConsoleColor.Red);
            }
            else
            {
                 ColorText.WriteColorLine("Список контактів:", ConsoleColor.Yellow);
                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine((i + 1) + "." + contacts[i].Name + " - " + contacts[i].PhoneNumber);
                }
            }
        }
        public void ShowContact()
        {
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                index--;
                if (index >= 0 && index < contacts.Count)
                {
                    Console.WriteLine(contacts[index].Name + " - " + contacts[index].PhoneNumber);
                }
                else
                {
                    ColorText.WriteColorLine("Контакт з таким індексом не знайдено!", ConsoleColor.Red);
                }
            }
            else
            {
                ColorText.WriteColorLine("Ви ввели не число", ConsoleColor.Red);
            }
        }

        public void DeleteContact()
        {
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                index--;
                if (index >= 0 && index < contacts.Count)
                {
                    Console.WriteLine("Контакт: " + contacts[index].Name);
                    Console.WriteLine($"Ви впевнені, що хочете видалити контакт з індексом {index + 1}? (y/n)");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        contacts.RemoveAt(index);
                        ColorText.WriteColorLine("\nКонтакт успішно видалено!", ConsoleColor.Green);
                    }
                    else
                    {
                        ColorText.WriteColorLine("\nВидалення скасовано.", ConsoleColor.Yellow);
                    }
                }
                else
                {
                    ColorText.WriteColorLine("Контакт з таким індексом не знайдено!", ConsoleColor.Red);
                }
            }
            else
            {
                ColorText.WriteColorLine("Ви ввели не число", ConsoleColor.Red);
            }
            
        }

        public void ChangeContact()
        {
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                index--;
                if (index >= 0 && index < contacts.Count)
                {
                    {
                        ColorText.WriteColorLine("Введіть нове ім'я контакту:", ConsoleColor.Cyan);
                        contacts[index].Name = Console.ReadLine();
                        ColorText.WriteColorLine("Введіть новий номер телефону:", ConsoleColor.Magenta);
                        contacts[index].PhoneNumber = Console.ReadLine();
                        ColorText.WriteColorLine("Контакт успішно змінено!", ConsoleColor.Green);
                    }
                }
                else
                {
                    ColorText.WriteColorLine("Контакт з таким індексом не знайдено!", ConsoleColor.Red);
                }
            }
            else
            {
                ColorText.WriteColorLine("Ви ввели не число", ConsoleColor.Red);
            }
        }

    }
}
