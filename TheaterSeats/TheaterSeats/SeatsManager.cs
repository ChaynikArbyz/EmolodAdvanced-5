using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;
using TheaterSeats.Types;

namespace TheaterSeats
{
    internal class SeatsManager
    {
        private List<Seat> seats = new List<Seat>();

        public SeatsManager(int amount)
        {
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                Seat seat = new Seat();
                int maybeAvaible = random.Next(0, 2);
                if (maybeAvaible == 0)
                {
                    seat.setIsAvailable(true);
                }
                else
                {
                    seat.setIsAvailable(false);
                }
                seats.Add(seat);
            }
        }
        public void ShowSeats()
        {
            Console.Clear();
            ColorText.WriteColorLine("Список вільних місць:", ConsoleColor.Yellow);
            ColorText.WriteColorLine("Вільні місця - зеленого кольору", ConsoleColor.Green);
            ColorText.WriteColorLine("Зайняті місця - червоного кольору\n", ConsoleColor.Red);

            int c = 0;
            for (int i = 0; i < seats.Count; i++)
            {
                Console.Write("| ");
                if (seats[i].getIsAvailable())
                {
                    if (i < 9)
                        ColorText.WriteColor(" ", ConsoleColor.Green);
                    ColorText.WriteColor(seats[i].getNumber().ToString(), ConsoleColor.Green);
                }
                else
                {
                    if (i < 9)
                        ColorText.WriteColor(" ", ConsoleColor.Red);
                    ColorText.WriteColor(seats[i].getNumber().ToString(), ConsoleColor.Red);
                }
                Console.Write(" | ");
                c++;
                if (c % 5 == 0)
                {
                    Console.WriteLine();
                }
            }

            int vc = 0;
            int pc = 0;
            for (int i = 0; i < seats.Count; i++)
            {
                if (seats[i].type is VipSeat)
                {
                    vc++;
                }
                else if (seats[i].type is PremiumSeat)
                {
                    pc++;
                }
            }
            if (vc > 0) { ColorText.WriteColorLine($"\nКількість ваших VIP місць: {vc}", ConsoleColor.Yellow); }
            if (pc > 0) { ColorText.WriteColorLine($"Кількість ваших Premium місць: {pc}", ConsoleColor.DarkYellow); }
        }


        public void TakeSeat()
        {
            Console.Clear();
            ShowSeats();
            Console.WriteLine("\nВведіть вільне місце:");
            if (int.TryParse(Console.ReadLine(), out int choise))
            {
                if (choise < 1 || choise > seats.Count)
                {
                    ColorText.WriteColorLine("Місце не може бути меньше 1 або більше кількості місць!\nНатісніть будь яку клавішу щоб спробувати ще раз ще раз!", ConsoleColor.Red);
                    Console.ReadKey(true);
                    TakeSeat();
                }
                Seat seat = seats[choise - 1];
                if (!seat.getIsAvailable())
                {
                    ColorText.WriteColorLine("Місце вже зайняте!\nНатісніть будь яку клавішу щоб спробувати ще раз ще раз!", ConsoleColor.Red);
                    Console.ReadKey(true);
                    TakeSeat();
                }

                Console.WriteLine($"Місце: {choise}\nЦіна: {seat.type.getCost()}\nОпис: {seat.type.getDescription()}");
                Console.WriteLine("Ведіть кількість ваших грошей");

                if (int.TryParse(Console.ReadLine(), out int money))
                {
                    if (money < seat.type.getCost())
                    {
                        ColorText.WriteColorLine("Недостатньо коштів!\nНатісніть будь яку клавішу щоб спробувати ще раз ще раз!", ConsoleColor.Red);
                        Console.ReadKey(true);
                        TakeSeat();
                    }
                    seat.setIsAvailable(false);
                    ColorText.WriteColorLine($"Ви успішно зайняли місце {choise}!", ConsoleColor.Green);
                    AbstractSeat oldType = seat.type;
                    seat.type = new VipSeat();
                    Console.WriteLine($"Бажаєте покращити його до VIP статусу? y/n\n\nЦіна: {seat.type.getCost()}\nОпис: {seat.type.getDescription()}");

                    if (Console.ReadKey(true).Key == ConsoleKey.Y)
                    { 
                            if (money >= seat.type.getCost())
                            {
                                ColorText.WriteColorLine($"Ви успішно покращили місце {choise} до VIP статусу!", ConsoleColor.Green);
                                oldType = seat.type;
                                seat.type = new PremiumSeat();
                                Console.WriteLine($"Бажаєте покращити місце до Premium статусу? y/n\n\nЦіна: {seat.type.getCost()}\nОпис: {seat.type.getDescription()}");
                                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                                {
                                    if (money >= seat.type.getCost())
                                    {
                                        ColorText.WriteColorLine($"Ви успішно покращили місце {choise} до Premium статусу!", ConsoleColor.Green);
                                        ColorText.WriteColorLine("Чудового перегляду!\nНатісніть будь яку клавішу щоб вийти", ConsoleColor.Yellow);
                                        Console.ReadKey(true);
                                    }
                                    else
                                    {
                                        seat.type = oldType;
                                        ColorText.WriteColorLine("Недостатньо коштів для покращення місця", ConsoleColor.Red);
                                        ColorText.WriteColorLine("Чудового перегляду!\nНатісніть будь яку клавішу щоб вийти", ConsoleColor.Yellow);
                                        Console.ReadKey(true);
                                    }
                                }
                                else
                                {
                                    seat.type = oldType;
                                    ColorText.WriteColorLine("Чудового перегляду!\nНатісніть будь яку клавішу щоб вийти", ConsoleColor.Yellow);
                                    Console.ReadKey(true);
                                }

                        }
                            else
                            {
                                seat.type = oldType;
                                ColorText.WriteColorLine("Недостатньо коштів для покращення місця", ConsoleColor.Red);
                                ColorText.WriteColorLine("Чудового перегляду!\nНатісніть будь яку клавішу щоб вийти", ConsoleColor.Yellow);
                                Console.ReadKey(true);
                            }

                    }
                    else 
                    { 
                            seat.type = oldType;
                            ColorText.WriteColorLine("Чудового перегляду!\nНатісніть будь яку клавішу щоб вийти", ConsoleColor.Yellow);
                            Console.ReadKey(true);

                    }
                }
                else
                {
                    ColorText.WriteColorLine("Невірний ввід! Спробуйте ще раз.", ConsoleColor.Red);
                    Console.ReadKey(true);
                    TakeSeat();
                }
            }
            else
            {
                ColorText.WriteColorLine("Невірний ввід! Спробуйте ще раз.", ConsoleColor.Red);
                Console.ReadKey(true);
                TakeSeat();
            }
        }
    }
}
