using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorTextService;

namespace ProductsShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Product Shop";
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            ProductShopService productShop = new ProductShopService();

            bool isRunning = true;
            bool isFalseInput = false;

            while (isRunning)
            {
                Console.Clear();

                if (isFalseInput)
                {
                    ColorText.WriteColorLine("Невірний вибір, спробуйте ще раз\n", ConsoleColor.Red);
                    isFalseInput = false;
                }

                ColorText.WriteColorLine("-< Продуктовий магазин >-\n", ConsoleColor.Red);
                Console.WriteLine("Виберіть дію:");
                Console.WriteLine("1. Список товарів");
                Console.WriteLine("2. Купити товар");
                Console.WriteLine("esc. Вийти");

                switch (Console.ReadKey(true).Key)
                    {
                    case ConsoleKey.D1:
                        Console.Clear();
                        productShop.ShowProducts();
                        Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до головного меню...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        productShop.ShowProducts();
                        Console.WriteLine("\nВведіть номер товару для покупки:");
                        try
                        {
                            productShop.BuyProduct();
                        }
                        catch (ArgumentException ex)
                        {
                            ColorText.WriteColorLine(ex.Message, ConsoleColor.Red);
                        }
                        Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до головного меню...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.Escape:
                        isRunning = false;
                        return;
                    default:
                        isFalseInput = true;
                        break;
                }
            }
        }
    }
}
