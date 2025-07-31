using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodDelivery.OrderItems
{
    internal class Dessert : OrderItem
    {
        public static string[] types = { "Кусочок торту", "Морозиво", "Печиво", "Пудинг",};
        public Dessert(int DessertType)
        {
            price = 50;
            name = types[DessertType];
        }
        public override void Prepare()
        {
            Console.WriteLine($"Готуємо ваш {name}...");
        }
    }
}
