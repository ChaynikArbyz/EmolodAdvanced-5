using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;
using OnlineFoodDelivery.OrderItems;

namespace OnlineFoodDelivery
{
    internal class OrdersService
    {   
        private List<Order> orders = new List<Order>();
        private Order currentOrder = null;
        public void AddOrder(Order order)
        {
            orders.Add(order);
        }
        public void RemoveOrder(Order order)
        {
            orders.Remove(order);
        }
        public List<Order> GetOrders()
        {
            return orders;
        }
        
        public void MakeOrder()
        {
            MakeOrder(false);
        }

        public void MakeOrder(bool invalidInput)
        {
            if (currentOrder == null)
                currentOrder = new Order();


            Order order = currentOrder;
            Console.Clear();
            if (invalidInput)
            {
                ColorText.WriteColorLine("Не існуючий варіант, спробуйте ще раз!\n", ConsoleColor.Red);
            }
            ColorText.WriteColorLine("Створення нового замовлення...", ConsoleColor.Yellow);
            ColorText.WriteColorLine("Меню:", ConsoleColor.DarkYellow);
            Console.WriteLine("Виберіть пункт меню:");
            Console.WriteLine("1. Піца");
            Console.WriteLine("2. Напій");
            Console.WriteLine("3. Десерт");
            Console.WriteLine("4. Оплатити замовлення");
            Console.WriteLine("esc. Вийти\n");
            if (order.GetItems().Count() > 0)
            {
                ColorText.WriteColorLine("Ваше замовлення на даниий момент:", ConsoleColor.Cyan);
                for (int i = 0; i < order.GetItems().Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. {order.GetItems()[i].GetName()} - {order.GetItems()[i].GetPrice()} грн");
                }
                ColorText.WriteColorLine($"Загальна сума: {order.GetItems().Sum(item => item.GetPrice())} грн", ConsoleColor.DarkYellow);
            }

            switch (Console.ReadKey(true).Key)
            {
            case ConsoleKey.D1:
                    Pizza realPizza = AddPizza(false);
                    if (realPizza != null) { order.AddItem(realPizza); }
                    ColorText.WriteColorLine("\nНатисніть будь-яку клавішу для повернення", ConsoleColor.DarkGray);
                    Console.ReadKey(true);
                    MakeOrder(true);
                    break;
            case ConsoleKey.D2:
                    Drink realDrink = AddDrink(false);
                    if (realDrink != null) { order.AddItem(realDrink); }
                    ColorText.WriteColorLine("\nНатисніть будь-яку клавішу для повернення", ConsoleColor.DarkGray);
                    Console.ReadKey(true);
                    MakeOrder(true);
                    break;
            case ConsoleKey.D3:
                    Dessert realDessert = AddDessert(false);
                    if (realDessert != null) { order.AddItem(realDessert); }
                    ColorText.WriteColorLine("\nНатисніть будь-яку клавішу для повернення", ConsoleColor.DarkGray);
                    Console.ReadKey(true);
                    MakeOrder(true);
                    break;
            case ConsoleKey.D4:
                    if (order.GetItems().Count > 0)
                    {
                        ColorText.WriteColorLine($"Ваше замовлення успішно оформлено!", ConsoleColor.Green);
                        AddOrder(order);
                        Timer timer = new Timer((e) =>
                        {
                            order.Start();
                        }, null, 10000, Timeout.Infinite);
                        currentOrder = null;
                    }
                    else
                    {
                        ColorText.WriteColorLine("Ваше замовлення порожнє, ви не можете оплатити нічого", ConsoleColor.Red);
                    }
                    break;
                case ConsoleKey.Escape:
                    currentOrder = null;
                    break;
            default:
                    MakeOrder(true);
                    break;
            }
        }
        public void ShowOrders()
        {
            Console.Clear();
            if (orders.Count == 0)
            {
                ColorText.WriteColorLine("Немає жодного замовлення.", ConsoleColor.Red);
                ColorText.WriteColorLine("\nНатисніть будь-яку клавішу для повернення до меню.", ConsoleColor.DarkGray);
                Console.ReadKey(true);
                return;
            }
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                ColorText.WriteColorLine("Список замовлень:", ConsoleColor.Yellow);
                for (int i = 0; i < orders.Count; i++)
                {
                    Order order = orders[i];
                    ColorText.WriteColorLine($"\n----------------------", ConsoleColor.Green);
                    ColorText.WriteColorLine($"Замовлення #{order.GetId()} - Статус: {order.GetStatus()}", ConsoleColor.Cyan);
                    for (int j = 0; j < order.GetItems().Count; j++)
                    {
                        Console.WriteLine($"{j + 1}. {order.GetItems()[j].GetName()} - {order.GetItems()[j].GetPrice()} грн");
                    }
                    ColorText.WriteColorLine($"Загальна сума: {order.GetItems().Sum(item => item.GetPrice())} грн\n", ConsoleColor.DarkYellow);
                    ColorText.WriteColorLine($"----------------------", ConsoleColor.Green);
                }
                ColorText.WriteColorLine("\nНатисніть будь-яку клавішу для повернення до меню.", ConsoleColor.DarkGray);
                Thread.Sleep(11000);
            }
            Console.ReadKey(true);
        }
        private Pizza AddPizza(bool invalidInput)
        {
            Pizza pizza = null;
            Console.Clear();
            if (invalidInput)
            {
                ColorText.WriteColorLine("Не існуючий варіант, спробуйте ще раз!\n", ConsoleColor.Red);
            }
            ColorText.WriteColorLine("Додавання піци до замовлення...\n", ConsoleColor.Yellow);
            Console.WriteLine("Виберіть розмір піцци:");
            for (int i = 0; i < Pizza.sizes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Pizza.sizes[i]}, ціна: {100 + (i + 1) * 25}");
            }
            Console.WriteLine("esc. Вийти\n");
            switch (Console.ReadKey(true).Key)
                {
                case ConsoleKey.D1:
                    pizza = new Pizza(0);
                    break;
                case ConsoleKey.D2:
                    pizza = new Pizza(1);
                    break;
                case ConsoleKey.D3:
                    pizza = new Pizza(2);
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    AddPizza(true);
                    break;
            }
            if (pizza == null)
            {
                return null;
            }
            ColorText.WriteColorLine($"Ви вибрали піцу розміром {pizza.GetSize()}.\n", ConsoleColor.Green);
            return pizza;
        }
        private Drink AddDrink(bool invalidInput)
        {
            Drink drink = null;
            Console.Clear();
            if (invalidInput)
            {
                ColorText.WriteColorLine("Не існуючий варіант, спробуйте ще раз!\n", ConsoleColor.Red);
            }
            ColorText.WriteColorLine("Додавання напою до замовлення...\n", ConsoleColor.Yellow);
            Console.WriteLine("Виберіть напій:");
            ColorText.WriteColorLine("Ціна холодного напою: 40 грн", ConsoleColor.Cyan);
            ColorText.WriteColorLine("Ціна гарячого напою: 30 грн", ConsoleColor.Red);
            for (int i = 0; i < Drink.types.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Drink.types[i]}");
            }
            Console.WriteLine("esc. Вийти\n");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    drink = new Drink(0);
                    break;
                case ConsoleKey.D2:
                    drink = new Drink(1);
                    break;
                case ConsoleKey.D3:
                    drink = new Drink(2);
                    break;
                case ConsoleKey.D4:
                    drink = new Drink(3);
                    break;
                case ConsoleKey.D5:
                    drink = new Drink(4);
                    break;
                case ConsoleKey.D6:
                    drink = new Drink(5);
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    AddDrink(true);
                    break;
            }
            if (drink == null)
            {
                return null;
            }
            ColorText.WriteColorLine($"Ви вибрали {drink.GetName()}.\n", ConsoleColor.Green);
            return drink;
        }

        private Dessert AddDessert(bool invalidInput)
        {
            Dessert dessert = null;
            Console.Clear();
            if (invalidInput)
            {
                ColorText.WriteColorLine("Не існуючий варіант, спробуйте ще раз!\n", ConsoleColor.Red);
            }
            ColorText.WriteColorLine("Додавання десерту до замовлення...\n", ConsoleColor.Yellow);
            Console.WriteLine("Виберіть десерт:");
            ColorText.WriteColorLine("Ціна десерту: 50 грн", ConsoleColor.Cyan);
            for (int i = 0; i < Dessert.types.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Dessert.types[i]}");
            }
            Console.WriteLine("esc. Вийти\n");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    dessert = new Dessert(0);
                    break;
                case ConsoleKey.D2:
                    dessert = new Dessert(1);
                    break;
                case ConsoleKey.D3:
                    dessert = new Dessert(2);
                    break;
                case ConsoleKey.D4:
                    dessert = new Dessert(3);
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    AddDessert(true);
                    break;
            }
            if (dessert == null)
            {
                return null;
            }
            ColorText.WriteColorLine($"Ви вибрали {dessert.GetName()}.\n", ConsoleColor.Green);
            return dessert;
        }
    }
}
