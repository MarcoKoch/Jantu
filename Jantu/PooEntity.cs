using System;

namespace Jantu
{
    class PooEntity : Entity
    {
        const char _drawChar = '~';

        public override void Draw()
        {
            Console.SetCursorPosition((int)Tile.X, (int)Tile.Y);
            Console.Write(_drawChar);
        }
    }
}
