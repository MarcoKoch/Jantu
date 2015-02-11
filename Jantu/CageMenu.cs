using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jantu
{
    class CageMenu : Window
    {

        Game _Game; 
        public CageMenu (Vector2 position, int width, int height, Game game) : 
            base (position, width, height)
        {
            _Game = game;
        }

        public override void Draw()
        {
            base.Draw();

            Console.SetCursorPosition(Position.X + 1, Position.Y + 1);
            Console.Write("********** Gehege **********");

            Console.SetCursorPosition(Position.X + 1, Position.Y + 3);
            Console.Write("Besucher \t" + (string)_Game.Visitors);
        }
    }
}


