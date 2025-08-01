using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculateSalary.Workers;
using NotesAndPasswordGenerator;

namespace CalculateSalary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] names = new string[]
            {
                "Олександр","Максим","Андрій","Марк","Костянтин","Роман","Артем","Світлана","Олена","Анна","Вікторія","Катерина","Юлія","Анастасія",
            };
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            List<Worker> workers = new List<Worker>();
            for (int i = 0; i < 3; i++)
            {
                workers.Add(new Professor());
            }
            for (int i = 0; i < 10; i++)
            {
                workers.Add(new Student());
            }
            for (int i = 0; i < 3; i++)
            {
                workers.Add(new Staff());
            }

            for (int i = 0; i < 12; i++)
            {
                ColorText.WriteColorLine($"Місяць {i + 1}", ConsoleColor.Yellow);
                for (int j = 0; j < workers.Count; j++)
                {
                    int hours = 0;
                    for (int k = 0; k < 21; k++)
                    {
                        hours += 8 + random.Next(-1, 4);
                    }
                    workers[j].SetMoney(workers[j].CalculateSalary(hours));
                }
                foreach (Worker worker in workers)
                {
                    worker.ShowSalary();
                }
                Console.WriteLine();
            }
        }
    }
}
