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
            Console.BackgroundColor = ConsoleColor.Cyan;
            Showbar menu = new Showbar();
            Game game = new Game(Console.WindowWidth - menu.Width, Console.WindowHeight, 0, 0);
            Stopwatch watch = new Stopwatch();

            Species cowSpecies = new Species("Cow");
            game.Data.Species.Add(cowSpecies);
            cowSpecies.Symbol = 'K';

            Species chickenSpecies = new Species("Chicken");
            game.Data.Species.Add(chickenSpecies);
            chickenSpecies.Symbol = 'C';

            AnimalEntity cow1 = new AnimalEntity(cowSpecies);
            AnimalEntity chicken1 = new AnimalEntity(chickenSpecies);
            World w = game.World;
            w[4, 7].Entity = cow1;
            w[8, 12].Entity = chicken1;


            watch.Start();
            menu.Draw();
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
