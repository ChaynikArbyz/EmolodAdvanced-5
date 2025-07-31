using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodDelivery.OrderItems
{
    internal class Pizza : OrderItem
    {
        public static string[] sizes = { "Мала", "Середня", "Велика" };
        private string size;
        public Pizza(int sizeIndex) 
        { 
            name = "Піца";
            switch (sizeIndex)
            {
                case 0:
                    price = 125;
                    size = sizes[0];
                    break;
                case 1:
                    price = 150;
                    size = sizes[1];
                    break;
                case 2:
                    price = 175;
                    size = sizes[2];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(size), "Невідомий розмір піци");
            }
        }

        public override void Prepare()
        {
            Console.WriteLine($"Приготування піцци розміру {size}...");
            // тут логіка
        }
        public string GetSize() => size;

    }
}
