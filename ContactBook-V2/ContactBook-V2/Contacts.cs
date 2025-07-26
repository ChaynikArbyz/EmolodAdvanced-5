using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NotesAndPasswordGenerator
{
    internal class Contacts
    {
        private Dictionary<string, string> contacts = new Dictionary<string, string>();

        public void AddContact(string name, string phoneNumber)
        {
            if (contacts.ContainsKey(name))
            {
                ColorText.WriteColorLine("Контакт з таким ім'ям вже існує!", ConsoleColor.Red);
            }
            else
            {
                contacts.Add(name, phoneNumber);
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
                     foreach (KeyValuePair<string,string> kv in contacts)
                     {
                         Console.WriteLine(kv.Key + " - " + kv.Value);
                     }
            }
        }

        public void DeleteContact(string name)
        {
            if (contacts.ContainsKey(name))
            {
                Console.WriteLine($"Ви впевнені, що хочете видалити контакт {name}? (y/n)");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    contacts.Remove(name);
                    ColorText.WriteColorLine("\nКонтакт успішно видалено!", ConsoleColor.Green);
                }
                else
                {
                    ColorText.WriteColorLine("\nВидалення скасовано.", ConsoleColor.Yellow);
                }
            }
            else
            {
                ColorText.WriteColorLine("Контакт з таким ім'ям не знайдено!", ConsoleColor.Red);
            }
        }

        public void ChangeContact(string name, string newName, string newPhoneNumber)
        {
            if (contacts.ContainsKey(name))
            {
                contacts.Remove(name);
                contacts.Add(newName, newPhoneNumber);
                ColorText.WriteColorLine("Контакт успішно змінено!", ConsoleColor.Green);
            }
            else
            {
                ColorText.WriteColorLine("Контакт з таким ім'ям не знайдено!", ConsoleColor.Red);
            }
        }

    }
}
