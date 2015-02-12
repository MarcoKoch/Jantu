using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
   

    class InfoBar : Window
    {
        private Game _game;

        public InfoBar(Game game, Vector2 pos, int width, int height) :
            base(pos, width, height)
        {
            BackgroundColor = ConsoleColor.DarkGray;
            BorderColor = ConsoleColor.Gray;
            TextColor = ConsoleColor.Gray;
            _game = game;
        }

         protected override void OnDraw()
         {
             Console.SetCursorPosition(Position.X + 1, Position.Y + 1);
             Console.Write("Cash: " + _game.Cash);

            Console.SetCursorPosition(Position.X + 1, Position.Y + 1);
            for (int x = 1; x < Width+1; x++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.SetCursorPosition(44,1);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;             
            Console.Write("Cash:"+_game.Cash);
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.SetCursorPosition(33, 1);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("Day:" + _game.Day);
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.SetCursorPosition(17, 1);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("Visitors:" + _game.Visitors);
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.SetCursorPosition(2, 1);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("Animals:" + _game.Animals);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
        }
    }
}
    


    





          





       


