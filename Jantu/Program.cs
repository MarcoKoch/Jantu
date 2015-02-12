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
            CageMenu menu = new CageMenu();
            Game game = new Game(Console.WindowWidth - 20, Console.WindowHeight-3,  new Vector2(0,3));
            InfoBar menu2 = new InfoBar(game,Console.WindowWidth-22,3);
            Stopwatch watch = new Stopwatch();

            // Test code

            var balance = new Balancing();
            var a = CageType.ReadFromFile("../../../data/cages/4x4.cage");
            var b = CageType.ReadFromFile("../../../data/cages/4x16.cage");

            var species = new Species("Cow");
            species.Symbol = 'c';
            species.PooPeriod = 1;

            var cage = new Cage(a, new Vector2(3,3), game, balance, false);

            var cow1 = new AnimalEntity(species);
            var cow2 = new AnimalEntity(species);

            cow1.Tile = cage.EnclosedTiles[0];
            cow2.Tile = cage.EnclosedTiles[2];

            // End of test code

            watch.Start();
            menu.Draw();
            //menu2.Draw(); // BUG: Die Menüleiste zeichnet über die Spielwelt
            while (true)
            {
                double dt = 0.001 * (double) watch.ElapsedMilliseconds;

                game.World.Update(dt);
                game.World.Draw();

                // This is to avoid an 'empty' line at the bottom of the screen
                Console.SetCursorPosition(0,0);

                if (1.0 / _fps * 0.001 > dt)
                    Thread.Sleep(Math.Max(0,(int)((long)(1.0 / _fps * 1000.0) - watch.ElapsedMilliseconds)));
                watch.Restart();
            }
        }
    }
}
