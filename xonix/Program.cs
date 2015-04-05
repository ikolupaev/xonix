using Xonix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Xonix
{
    class Program
    {
        static Field field;
        static List<Bot> bots;
        static Player player;

        static void Main(string[] args)
        {
            InitField();
            InitPlayer();
            InitBots();

            try
            {
                Run();
            }
            catch(GameOverException)
            {
                ShowGameOver();
            }
        }

        private static void InitField()
        {
            field = new Field(80, 40);
        }

        private static void Run()
        {
            while (true)
            {
                Thread.Sleep(50);
                ProcessBots();
                ProcessPlayer();
            }
        }

        private static void ShowGameOver()
        {
            var w = Console.WindowWidth / 2;
            var h = Console.WindowHeight / 2;

            Console.SetCursorPosition(w, h);
            Console.WriteLine("GAME OVER");

            h -= 3;
            w -= 5;
            for (var i = 0; i < 20; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(w, h);
                Console.Write("0");
                w++;
            }

            for (var i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(w, h);
                Console.Write("0");
                h++;
            }

            for (var i = 0; i < 23; i++)
            {
                Console.SetCursorPosition(w, h);
                Console.Write("0");
                w--;
            }

            for (var i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(w, h);
                Console.Write("0");
                h--;
            }
            h++;

            for (var i = 0; i < 3; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(w, h);
                Console.Write("0");
                w++;
            }

            Console.ReadKey();
        }

        private static void ProcessBots()
        {
            foreach (var bot in bots)
            {
                bot.Move(field);
            }
        }

        private static void InitBots()
        {
            bots = new List<Bot>();

            Random rnd = new Random();

            for (var i = 0; i < 3; i++)
            {
                var bot = new Bot(
                  rnd.Next(2, Console.WindowWidth - 10),
                  rnd.Next(2, Console.WindowHeight - 10),
                  rnd.Next(1) == 0 ? -1 : 1,
                  rnd.Next(1) == 0 ? -1 : 1);

                bots.Add(bot);

                field.SetChar(bot, Bot.Symbol);
            }
        }

        private static void InitPlayer()
        {
            player = new Player
            {
                X = 40,
                Y = 0
            };
        }

        private static void ProcessPlayer()
        {
            ProcessUserCommands();
            player.Move(field);
        }

        private static void ProcessUserCommands()
        {
            ConsoleKey? lastKey = null;
            while (Console.KeyAvailable)
            {
                lastKey = Console.ReadKey().Key;
            }

            if (lastKey != null)
            {
                player.ChangeDirection(lastKey.Value);
            }
        }
    }

}