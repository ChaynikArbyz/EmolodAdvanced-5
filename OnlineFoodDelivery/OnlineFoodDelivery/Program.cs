using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;
using OnlineFoodDelivery;

namespace ContactBook_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            OrdersService ordersService = new OrdersService();

            bool Running = true;
            bool invalidInput = false;

            while (Running)
            {
                Console.Clear();
                if (invalidInput)
                {
                    ColorText.WriteColorLine("Не існуючий варіант, спробуйте ще раз!\n", ConsoleColor.Red);
                    invalidInput = false;
                }
                ColorText.WriteColorLine("-< Сервіс замовлення їжі >-\n", ConsoleColor.Red);
                ColorText.WriteColorLine("Виберіть дію:", ConsoleColor.Yellow);

                Console.WriteLine("1. Зробити замовлення");
                Console.WriteLine("2. Переглянути замовлення");

                Console.WriteLine("esc. Вийти");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        ordersService.MakeOrder();
                        ColorText.WriteColorLine("\nНатисніть будь-яку клавішу для повернення до меню.", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D2:
                        ordersService.ShowOrders();
                        break;
                    case ConsoleKey.Escape:
                        Running = false;
                        break;
                    default:
                        invalidInput = true;
                        break;
                }
            }
        }
    }
}
