using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodDelivery.OrderItems
{
    internal class Drink : OrderItem
    {
        public static string[] types = {"Кола", "Фанта", "Спрайт", "Чорний Чай", "Зелений Чай", "Звичайний кофе",};
        private bool isCold;
        public Drink(int type)
        {
            name = types[type];
            if (type < 3)
            {
                price = 40;
            }
            else
            {
                price = 30;
            }
        }

        public override void Prepare()
        {
            Console.WriteLine($"Робимо ваш {name}...");
        }
    }
}
