using System;

namespace Jantu
{
    /// <summary>
    /// Represents a Visitors in the Game.
    /// </summary>
    class VisitorEntity : Entity
    {
        const char _drawChar = '☺';

        /// <summary>
        /// Draws the entity.
        /// </summary>
        public override void Draw()
        {
            Console.SetCursorPosition(Tile.ConsoleX,Tile.ConsoleY);
            Console.Write(_drawChar);
        }
    }
}
