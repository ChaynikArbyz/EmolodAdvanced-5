using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalculateSalary.Workers
{
    internal abstract class Worker
    {
        Random random = new Random();
        protected string[] names = new string[]
        {
            "Олександр","Максим","Андрій","Марк","Костянтин","Роман","Артем","Світлана","Олена","Анна","Вікторія","Катерина","Юлія","Анастасія",
        };
        protected int salaryPerHour = 30;
        protected string name;
        protected int hours = 160;
        protected int money = 0;
        protected double coefficient;
        public Worker()
        {
            Thread.Sleep(1);// без затримки рандом має однакове значення, так що я його додав
            this.name = names[random.Next(names.Length)];
        }

        public abstract int CalculateSalary(int hours);
        public abstract void ShowSalary();
        public string GetName() => name;
        public int GetHours() => hours;
        public int GetMoney() => money;
        public void SetMoney(int money)
        {
            if (money < 0)
            {
                throw new ArgumentException("Зарплата не може бути від'ємною!");
            }
            this.money = money;
        }

    }
}
