using System;
using System.Threading;

namespace sd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            string[] Player = new string[7];
            string[] Dealer = new string[7];
            string[,] Cards =
            {
                { "2","2" },
                { "3", "3" },
                { "4", "4" },
                { "5", "5" },
                { "6", "6" },
                { "7", "7" },
                { "9", "9" },
                { "10", "10" },
                { "J", "10" },
                { "D", "10" },
                { "K", "10" },
                { "A", "11" }
            };

            Dealer[0] = Cards[rnd.Next(0, Cards.GetLength(0)), 0];
            Player[0] = Cards[rnd.Next(0, Cards.GetLength(0)), 0];
            Player[1] = Cards[rnd.Next(0, Cards.GetLength(0)), 0];
            Console.WriteLine($"Карты диллера: {Dealer[0]}, *\nВаши карты: {Player[0]}, {Player[1]}\nВзять карту: +\nСтоп: -");

            string step = Console.ReadLine();
            while (step == "+")
            {
                for (int i = 2; i < Player.Length; i++)
                {
                    if (Player[i] == null)
                    {
                        Player[i] = Cards[rnd.Next(0, Cards.GetLength(0)), 0];
                        summ = 0;
                        perebor(Player, Cards);
                        Console.Write($"Вам выпала карта... ");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{Player[i]}, выш счёт - {summ}");
                        if (summ > 21)
                        {
                            Thread.Sleep(500);
                            Console.WriteLine("Перебор. Вы проебали хату)");
                            step = "LOOOSER";
                            summ = -1;
                            break;
                        }
                        step = Console.ReadLine();
                        break;
                    }
                }
            }

            int Cards_Player = summ;

            summ = 0;
            if (Cards_Player != -1)
            {
                while (summ < 17 && summ >= 0)
                {
                    for (int i = 1; i < Dealer.Length; i++)
                    {
                        if (Dealer[i] == null)
                        {
                            Dealer[i] = Cards[rnd.Next(0, Cards.GetLength(0)), 0];
                            summ = 0;
                            perebor(Dealer, Cards);
                            Console.Write($"Диллер вытянул... ");
                            Thread.Sleep(1000);
                            Console.Write($"{Dealer[i]}, его счёт - {summ}\n");
                            if (summ > 21)
                            {
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine("Диллер перебрал. Ты победил)");
                                    summ = -1;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                int Cards_Dealer = summ;
                if (Cards_Dealer != -1)
                {
                    Thread.Sleep(1000);
                    if (Cards_Dealer > Cards_Player)
                    {
                        Console.WriteLine("Ты проиграл(");
                    }
                    else if (Cards_Dealer < Cards_Player)
                    {
                        Console.WriteLine("Ты выйграл)");
                    }
                    else
                    {
                        Console.WriteLine("Да у вас ничья...");
                    }
                }
                Console.ReadKey();
            }
        }

        public static int summ = 0;

        static void perebor(string[] a, string[,] b)
        {

            int kash = 0;

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.GetLength(0); j++)
                {
                    if (a[i] != b[j, 0])
                    {
                        kash++;
                    }
                    else
                    {
                        summ += Convert.ToInt16(b[kash, 1]);
                        kash = 0;
                        break;
                    }
                }
            }
        }
    }
}