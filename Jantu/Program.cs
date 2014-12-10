using System;
using System.Diagnostics;
using System.Threading;

namespace Jantu
{
    class Program
    {
        static double _fps = 60.0;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Showbar menu = new Showbar();
            Game game = new Game(Console.WindowWidth - 20, Console.WindowHeight-3,  0, 3);
            InfoBar menu2 = new InfoBar(game,Console.WindowWidth-22,3);
            Stopwatch watch = new Stopwatch();

            // Test code
            var balance = new Balancing();
            var cageType = CageType.ReadFromFile("../../../data/cages/cross.cage");
            var cage = new Cage(cageType, new Vector2(1,1), game, balance, false);
            // End of test code

            watch.Start();
            menu.Draw();
            //menu2.Draw(); // BUG: Die Menüleiste zeichnet über die Spielwelt
            while (true)
            {
                double dt = 0.001 * watch.ElapsedMilliseconds;

                game.World.Update(dt);
                game.World.Draw();

                if (1.0 / _fps * 0.001 > dt)
                    Thread.Sleep(Math.Max(0,(int)((long)(1.0 / _fps * 1000.0) - watch.ElapsedMilliseconds)));
                watch.Restart();
            }
        }
    }
}
