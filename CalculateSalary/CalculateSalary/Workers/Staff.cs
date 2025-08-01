using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace CalculateSalary.Workers
{
    internal class Staff : Worker
    {
        public Staff() : base()
        {
            coefficient = 1.2;
        }
        public override int CalculateSalary(int hours)
        {
            this.hours = hours;
            if (hours > 160)
            { coefficient = 2; }
            money = (int)(salaryPerHour * coefficient * hours);
            return money;
        }
        public override void ShowSalary()
        {
            if (money == 0)
            {
                ColorText.WriteColorLine("Зарплата ще не розрахована!", ConsoleColor.Red);
                return;
            }
            Console.Write("Персонал: ");
            ColorText.WriteColor(name, ConsoleColor.Cyan);
            Console.Write(", отримав зарплату в ");
            ColorText.WriteColor(money.ToString(), ConsoleColor.DarkYellow);
            Console.Write(" за цей місяць\n");
        }
    }

}
