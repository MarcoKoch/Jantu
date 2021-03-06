﻿using System;
using System.Collections.Generic;
using System.Data;
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
            BackgroundColor = ConsoleColor.Gray;
            ForegroundColor = ConsoleColor.Black;
            BorderFgColor = ConsoleColor.Gray;
            _game = game;
        }

         protected override void OnDraw()
         {
             Clear();

             Console.SetCursorPosition(Position.X + 1, Position.Y + 1);
             Console.Write("Konto: " + _game.Cash
                 + "\tTag: " + _game.Day
                 + "\tBesucher: " + _game.Visitors
                 + "\tTiere: " + _game.NumAnimals);
        }
    }
}
    


    





          





       


