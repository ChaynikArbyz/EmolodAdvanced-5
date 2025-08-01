using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace CalculateSalary.Workers
{
    internal class Student : Worker
    {
        Random random = new Random();
        public Student() : base()
        {
            coefficient = 0.5;
        }
        public override int CalculateSalary(int hours)
        {
            Thread.Sleep(1); // без затримки рандом має однакове значення, так що я його додав
            this.hours = hours;
            if (hours > 160)
            { coefficient = 1; }
            money = (int)(salaryPerHour * coefficient * hours) + random.Next(-700, 701);
            return money;
        }
        public override void ShowSalary()
        {
            if (money == 0)
            {
                ColorText.WriteColorLine("Зарплата ще не розрахована!", ConsoleColor.Red);
                return;
            }
            Console.Write("Студент: ");
            ColorText.WriteColor(name, ConsoleColor.Cyan);
            Console.Write(", отримав зарплату в ");
            ColorText.WriteColor(money.ToString(), ConsoleColor.DarkYellow);
            Console.Write(" за цей місяць\n");
        }
    }
}
