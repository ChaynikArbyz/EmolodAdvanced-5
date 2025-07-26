using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorTextService;

namespace ProductsShop
{
    internal class ProductShopService
    {
        private Product[] products = new Product[]
            {
                new Product("Помідор", 13, 34),
                new Product("Огірок", 24, 69),
                new Product("Яблуко", 75, 11),
                new Product("Кавун", 100, 777),
                new Product("Кавун XL", 1000000, 1),
                new Product("Груша", 15, 20),
                new Product("Банан", 17, 36),
            };

       public void ShowProducts()
        {
            ColorText.WriteColorLine("Список товарів:", ConsoleColor.Green);
            if (products.Length == 0)
            {
                ColorText.WriteColorLine("На данний момент товарів не має", ConsoleColor.Cyan);
                return;
            }
            foreach (Product product in products)
            {
                if (product.GetAmount() <= 0)
                {
                    ColorText.WriteColorLine($"{product.id}. {product.GetName()} - немає в наявності", ConsoleColor.Red);
                    continue;
                }
                product.ShowProduct();
            }
        }
        public void BuyProduct()
        {
            if (int.TryParse(Console.ReadLine(), out int choise))
            {
                if (choise < 1 || choise > products.Length)
                    throw new ArgumentException("Ви ввели не коректний номер товару!");
                if (products[choise - 1].GetAmount() <= 0)
                {
                    throw new ArgumentException("Товару не має в наявності!");
                }
                Console.WriteLine("Введіть кількість ваших грошей");

                if (int.TryParse(Console.ReadLine(), out int money))
                {
                    if (money < products[choise - 1].GetPrice())
                    {
                        throw new ArgumentException("У вас недостатньо коштів для покупки!");
                    }
                    else
                    {
                        int tempMoney = money;
                        int canbuyAmount = 0;
                        while (tempMoney> products[choise - 1].GetPrice())
                        { 
                        tempMoney -= products[choise - 1].GetPrice();
                            if (products[choise - 1].GetAmount() > canbuyAmount)
                                canbuyAmount++;
                            else { break; }

                            
                        }
                        Console.WriteLine("Введіть кількість товару який хочете купити, максимум: " + canbuyAmount);
                        if (int.TryParse(Console.ReadLine(), out int amount))
                        {
                            if (amount < 1 || amount > canbuyAmount)
                            {
                                throw new ArgumentException("Ви забагато хочете!");
                            }
                            else
                            {
                                products[choise - 1].DecreaseAmount(amount);
                                Console.WriteLine($"Ви купили {amount} {products[choise - 1].GetName()} на суму {products[choise - 1].GetPrice() * amount} грн.");
                                Console.WriteLine($"Залишок грошей: {money - products[choise - 1].GetPrice() * amount} грн.");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Ви ввели не коректну кількість товару!");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Ви ввели не коректну суму грошей!");
                }
            }
            else
                throw new ArgumentException("Ви ввели не коректний номер товару!");


        }
    }
}
