using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
    class CageWallEntity : Entity
    {
        const char _drawChar = '#';

        public override void Draw()
        {
            Console.SetCursorPosition((int)Tile.ConsoleX, (int)Tile.ConsoleY);
            Console.Write(_drawChar);
        }
    }
}
