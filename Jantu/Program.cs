﻿using System;
using System.Diagnostics;
using System.Threading;

namespace Jantu
{
    class Program
    {
        static double _fps = 60.0;

        static void Main(string[] args)
        {
            Showbar menu = new Showbar();
            Game game = new Game(Console.WindowWidth - menu.Width, Console.WindowHeight);
            Stopwatch watch = new Stopwatch();

            watch.Start();
            menu.Draw();
            while (true)
            {
                double dt = 0.001 * watch.ElapsedMilliseconds;

                game.World.Update(dt);
                game.World.Draw();

                if (1.0 / _fps * 0.001 > dt)
                    Thread.Sleep((int)((long)(1.0 / _fps * 1000.0) - watch.ElapsedMilliseconds));
                watch.Restart();
            }
        }
    }
}
