using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;
using OnlineFoodDelivery.OrderItems;

namespace OnlineFoodDelivery
{
    internal class Order
    {
        public static string[] statuses = { "Очікування", "Виконується", "Завершено" };
        private List<OrderItem> items;
        private string status;
        private int Id;

        public Order()
        {
            Random random = new Random();
            Id = random.Next(1, 1000);
            items = new List<OrderItem>();
            status = statuses[0];
        }


        public int GetId() => Id;
        public List<OrderItem> GetItems() => items;
        public string GetStatus() => status;
        public void AddItem(OrderItem item)
        {
            items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            items.Remove(item);
        }

        public void Start()
        {
            ColorText.WriteColorLine("\n\n-- СПОВІЩЕННЯ --", ConsoleColor.Red);
            Console.WriteLine($"Замовлення #{Id} розпочато.");
            foreach (var item in items)
            {
                item.Prepare();
            }
            status = statuses[1];

            Timer timer = new Timer((e) =>
            {
                status = statuses[2];
                ColorText.WriteColorLine("\n\n-- СПОВІЩЕННЯ --", ConsoleColor.Red);
                Console.WriteLine($"\nЗамовлення #{Id} завершено.");
            }, null, 25000, Timeout.Infinite);
        }
    }
}
