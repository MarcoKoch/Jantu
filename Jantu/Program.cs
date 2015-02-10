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
            Game game = new Game(Console.WindowWidth - 20, Console.WindowHeight-3,  new Vector2(0,3));
            InfoBar menu2 = new InfoBar(game,Console.WindowWidth-22,3);
            Stopwatch watch = new Stopwatch();

            // Test code
            var balance = new Balancing();
            var a = CageType.ReadFromFile("../../../data/cages/4x4.cage");
            var b = CageType.ReadFromFile("../../../data/cages/4x16.cage");
            var c = CageType.ReadFromFile("../../../data/cages/6x4.cage");
            var d = CageType.ReadFromFile("../../../data/cages/12x4.cage");
            var e = CageType.ReadFromFile("../../../data/cages/4x12.cage");
            var f = CageType.ReadFromFile("../../../data/cages/7x7.cage");
            //var U = CageType.ReadFromFile("../../../data/cages/U_shape.cage");
            //var square = CageType.ReadFromFile("../../../data/cages/square.cage");

            var cage1 = new Cage(a, new Vector2(1, 1), game, balance, false);
            var cage2 = new Cage(a, new Vector2(5, 1), game, balance, false);
            var cage3 = new Cage(a, new Vector2(9, 1), game, balance, false);
            var cage4 = new Cage(a, new Vector2(9, 5), game, balance, false);
            var cage5 = new Cage(a, new Vector2(9, 9), game, balance, false);
            var cage6 = new Cage(a, new Vector2(9, 13), game, balance, false);
            var cage7 = new Cage(a, new Vector2(5, 13), game, balance, false);
            var cage8 = new Cage(a, new Vector2(1, 13), game, balance, false);
            var cage9 = new Cage(a, new Vector2(1, 9), game, balance, false);
            var cage10 = new Cage(b, new Vector2(15, 1), game, balance, false);
            var cage11 = new Cage(b, new Vector2(23, 1), game, balance, false);
            var cage12 = new Cage(c, new Vector2(18, 1), game, balance, false);
            var cage13 = new Cage(c, new Vector2(18, 8), game, balance, false);
            var cage14 = new Cage(e, new Vector2(38, 5), game, balance, false);
            var cage15 = new Cage(d, new Vector2(34, 1), game, balance, false);
            var cage16 = new Cage(e, new Vector2(47, 1), game, balance, false);
            var cage17 = new Cage(d, new Vector2(47, 13), game, balance, false);
            var cage18 = new Cage(e, new Vector2(55, 1), game, balance, false);
            var cage19 = new Cage(f, new Vector2(29, 7), game, balance, false);
            //var cage3 = new Cage(N, new Vector2(1, 1), game, balance, false);
            //var cage4 = new Cage(T, new Vector2(1, 1), game, balance, false);
            //var cage5 = new Cage(U, new Vector2(1, 1), game, balance, false);

            Species N = new Species("N");
            Species Cow = new Species("Cow");
            AnimalEntity cow1 = new AnimalEntity(Cow);
            AnimalEntity cow2 = new AnimalEntity(Cow);
            AnimalEntity n1 = new AnimalEntity(N);
            AnimalEntity n2 = new AnimalEntity(N);
            AnimalEntity n3 = new AnimalEntity(N);
            AnimalEntity n4 = new AnimalEntity(N);
            AnimalEntity n5 = new AnimalEntity(N);
            AnimalEntity n6 = new AnimalEntity(N);
            AnimalEntity n7 = new AnimalEntity(N);
            AnimalEntity n8 = new AnimalEntity(N);
            AnimalEntity n9 = new AnimalEntity(N);
            AnimalEntity n10 = new AnimalEntity(N);
            AnimalEntity n11 = new AnimalEntity(N);
            AnimalEntity n12 = new AnimalEntity(N);
            AnimalEntity n13= new AnimalEntity(N);
            AnimalEntity n14= new AnimalEntity(N);
            AnimalEntity n15= new AnimalEntity(N);
            AnimalEntity n16 = new AnimalEntity(N);

            N.Symbol = 'N';
            Cow.Symbol = 'c';
            game.World[10, 10].Entity = cow1;
            game.World[11, 11].Entity = cow2;
            game.World[30, 8].Entity = n1;
            game.World[30, 9].Entity = n2;
            game.World[30, 10].Entity = n3;
            game.World[30, 11].Entity = n4;
            game.World[31, 9].Entity = n5;
            game.World[31, 10].Entity = n6;
            game.World[31, 11].Entity = n7;
            game.World[31, 12].Entity = n8;
            game.World[32, 8].Entity = n9;
            game.World[32, 9].Entity = n10;
            game.World[32, 12].Entity = n11;
            game.World[33, 9].Entity = n12;
            game.World[33, 10].Entity = n13;
            game.World[33, 11].Entity = n14;
            game.World[34, 11].Entity = n15;
            game.World[34, 12].Entity = n16;

            // End of test code

            watch.Start();
            menu.Draw();
            //menu2.Draw(); // BUG: Die Menüleiste zeichnet über die Spielwelt
            while (true)
            {
                double dt = 0.001 * (double) watch.ElapsedMilliseconds;

                game.World.Update(dt);
                game.World.Draw();

                if (1.0 / _fps * 0.001 > dt)
                    Thread.Sleep(Math.Max(0,(int)((long)(1.0 / _fps * 1000.0) - watch.ElapsedMilliseconds)));
                watch.Restart();
            }
        }
    }
}
