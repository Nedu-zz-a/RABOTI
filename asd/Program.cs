using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;

namespace sd
{
    internal class Program
    {

        static int balance = 500;
        static int game_bet {  get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Желаете ли вы окунуться в озеро азарта и смачно обонкротиться в\n--------------------  B L A C K   J A C K  --------------------\n");
            Console.WriteLine("Нажмите любую клавишу для начала игры)\n");
            Console.ReadKey(intercept: true);
            Start();
        }

        static void Start()
        {
            Console.Clear();
            Console.WriteLine("--------------------B L A C K   J A C K--------------------");
            if (balance == 0)
            {
                Console.WriteLine("Да ты всё проебал, иди отдохни");
            }
            else
            {
                Console.Write($"Ваш баланс {balance}\nУкажите вашу ставку: ");
                game_bet = Convert.ToInt32(Console.ReadLine());
                while (game_bet < 1 || game_bet > balance)
                {
                    Console.WriteLine("Не борзей.\nУкажите вашу ставку: ");
                    game_bet = Convert.ToInt32(Console.ReadLine());
                }
                Console.Clear();
                int i = 0;
                while (i != 5)
                {
                    Console.Write("Ставки сделанны");
                    Thread.Sleep(200);
                    Console.Write(".");
                    Thread.Sleep(200);
                    Console.Write(".");
                    Thread.Sleep(200);
                    Console.Write(".");
                    Console.Clear();
                    i++;
                }
                Game();
            }
        }

        static void Game() { 
            Random rnd = new Random();

            string[] Player = new string[7];
            string[] Dealer = new string[7];
            string[,] Cards =
            {
                { "1","1" },
                //{ "2♥","2" },
                //{ "3♥", "3" },
                //{ "4♥", "4" },
                //{ "5♥", "5" },
                //{ "6♥", "6" },
                //{ "7♥", "7" },
                //{ "9♥", "9" },
                //{ "10♥", "10" },
                //{ "J♥", "10" },
                //{ "D♥", "10" },
                //{ "K♥", "10" },
                { "A♥", "11" },
                //{ "2♦","2" },
                //{ "3♦", "3" },
                //{ "4♦", "4" },
                //{ "5♦", "5" },
                //{ "6♦", "6" },
                //{ "7♦", "7" },
                //{ "9♦", "9" },
                //{ "10♦", "10" },
                //{ "J♦", "10" },
                //{ "D♦", "10" },
                //{ "K♦", "10" },
                { "A♦", "11" },
                //{ "2♣","2" },
                //{ "3♣", "3" },
                //{ "4♣", "4" },
                //{ "5♣", "5" },
                //{ "6♣", "6" },
                //{ "7♣", "7" },
                //{ "9♣", "9" },
                //{ "10♣", "10" },
                //{ "J♣", "10" },
                //{ "D♣", "10" },
                //{ "K♣", "10" },
                //{ "A♣", "11" },
                //{ "2♠","2" },
                //{ "3♠", "3" },
                //{ "4♠", "4" },
                //{ "5♠", "5" },
                //{ "6♠", "6" },
                //{ "7♠", "7" },
                { "9♠", "9" },
                { "10♠", "10" },
                { "J♠", "10" },
                //{ "D♠", "10" },
                //{ "K♠", "10" },
                { "A♠", "11" }
            };

            Array.Clear(Player, 0, Player.Length);
            Array.Clear(Dealer, 0, Player.Length);

            Dealer[0] = Cards[rnd.Next(1, Cards.GetLength(0)), 0];
            while (status == false)
            {
                Player[0] = Cards[rnd.Next(1, Cards.GetLength(0)), 0];
                proverka(Player, Dealer, 0);
            }
            status = false;
            while (status == false)
            {
                Player[1] = Cards[rnd.Next(1, Cards.GetLength(0)), 0];
                proverka(Player, Dealer, 1);
            }
            status = false;
            Console.WriteLine($"Карты диллера: {Dealer[0]}, *\nВаши карты: {Player[0]}, {Player[1]}\nВзять карту: +");

            string step = Console.ReadLine();
            while (step == "+")
            {
                for (int i = 2; i < Player.Length; i++)
                {
                    if (Player[i] == null)
                    {
                        while (status == false )
                        {
                            Player[i] = Cards[rnd.Next(1, Cards.GetLength(0)), 0];
                            proverka(Player, Dealer,i);
                        }
                        status = false;
                        summ = 0;
                        perebor(Player, Cards);
                        Console.Write($"Вам выпала карта... ");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{Player[i]}");
                        if (summ > 21)
                        {
                            Thread.Sleep(500);
                            Console.WriteLine("Перебор. Вы проебали)");
                            lose_or_win(0);
                            step = "LOOOSER";
                            summ = -1;
                            break;
                        }
                        step = Console.ReadLine();
                        break;
                    }
                }
            }
            Array.Clear(count_A, 0, count_A.Length );
            int Cards_Player = -1;

            if (summ != -1)
            {
                summ = 0;
                perebor(Player, Cards);
                Cards_Player = summ;
            }

            summ = 0;
            if (Cards_Player != -1)
            {
                while (summ < 17 && summ >= 0)
                {
                    for (int i = 1; i < Dealer.Length; i++)
                    {
                        if (Dealer[i] == null)
                        {
                            while (status == false)
                            {
                                Dealer[i] = Cards[rnd.Next(1, Cards.GetLength(0)), 0];
                                proverka(Dealer, Player, i);
                            }
                            status = false;
                            summ = 0;
                            perebor(Dealer, Cards);
                            Console.Write($"Диллер вытянул... ");
                            Thread.Sleep(1000);
                            Console.WriteLine($"{Dealer[i]}");
                            if (summ > 21)
                            {
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine("Диллер перебрал. Ты победил)");
                                    lose_or_win(1);
                                    summ = -1;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                Array.Clear(count_A, 0, count_A.Length);

                int Cards_Dealer = summ;
                if (Cards_Dealer != -1)
                {
                    Thread.Sleep(1000);
                    if (Cards_Dealer > Cards_Player)
                    {
                        Console.WriteLine("Ты проиграл(");
                        lose_or_win(0);
                    }
                    else if (Cards_Dealer < Cards_Player)
                    {
                        Console.WriteLine("Ты выйграл)");
                        lose_or_win(1);
                    }
                    else
                    {
                        Console.WriteLine("Да у вас ничья...");
                    }
                }
            }
            Console.ReadKey(intercept: true);
            Start();
        }

        static int summ = 0;

        static int[] count_A = new int[4];

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
                        while (summ > 21)
                        {
                            int schetchik = 0;
                            for (int e = 0; e < i; e++)
                            {
                                if (a[e] == "A♥" || a[e] == "A♦" || a[e] == "A♣" || a[e] == "A♠")
                                {
                                    a[e] = "1";
                                    Console.WriteLine(a[e]);
                                    summ -= 10;
                                    schetchik = 1;
                                    break;
                                }
                                else
                                {
                                    schetchik = 0;
                                }
                            }
                            if (schetchik == 0)
                            {
                                break;
                            }
                        }
                        kash = 0;
                        break;
                    }
                }
            }
        }

        public static bool status = false;

        static void proverka(string[] a, string[] b, int c)
        {
            bool kash = true;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0;j < c; j++)
                {
                    if (a[c] == a[j] || a[c] == b[i])
                    {
                        kash = false;
                        break;

                    }
                }
            }
            status = kash;
        }

        static void lose_or_win(int i)
        {
            if (i == 0)
            {
                balance -= game_bet;
            }
            else if (i == 1)
            {
                balance += game_bet;
            }
        }
    }
}