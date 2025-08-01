using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace CalculateSalary.Workers
{
    internal class Professor : Worker
    {
        public Professor() : base()
        {
            coefficient = 3;
        }

        public override int CalculateSalary(int hours)
        {
            this.hours = hours;
            if (hours > 160)
            { coefficient = 5; }
            money = (int)(salaryPerHour * coefficient * hours);
            money += 2000; 
            return money;
        }
        public override void ShowSalary()
        {
            if (money == 0)
            {
                ColorText.WriteColorLine("Зарплата ще не розрахована!", ConsoleColor.Red);
                return;
            }
            Console.Write("Професор: ");
            ColorText.WriteColor(name, ConsoleColor.Cyan);
            Console.Write(", отримав зарплату в ");
            ColorText.WriteColor(money.ToString(), ConsoleColor.DarkYellow);
            Console.Write(" за цей місяць\n");
        }
    }
}
