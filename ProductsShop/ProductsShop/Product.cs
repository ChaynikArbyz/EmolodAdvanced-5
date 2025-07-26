using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorTextService;

namespace ProductsShop
{
    internal class Product
    {
        private string name;
        private int price;
        private int amount;
        public int id;
        private static int nextId = 1;
        public Product(string name, int price, int amount)
        {
            this.id = nextId;
            nextId++;
            this.name = name;
            this.price = price;
            this.amount = amount;
        }
        public void ShowProduct()
        {
            Console.Write(id + ".");
            ColorText.WriteColor(name, ConsoleColor.Green);
            Console.Write(" - ціна: ");
            ColorText.WriteColor(price.ToString(), ConsoleColor.Yellow);
            Console.Write(" грн, кількість: ");
            ColorText.WriteColor(amount.ToString(), ConsoleColor.Cyan);
            Console.WriteLine();
        }

        public string GetName()
        {
            return name;
        }
        public int GetPrice()
        {
            return price;
        }
        public int GetAmount()
        {
            return amount;
        }
        public void DecreaseAmount(int amount)
        {
            if (this.amount < amount)
            {
                this.amount = 0;
            }
            else
            {
                this.amount -= amount;
            }
        }

    }
}
