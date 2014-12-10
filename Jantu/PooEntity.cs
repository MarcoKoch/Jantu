﻿using System;

namespace Jantu
{
    /// <summary>
    /// Represents a pile of poo in the game world.
    /// </summary>
    class PooEntity : Entity
    {
        const char _drawChar = '♨';

        /// <summary>
        /// Draws the entity.
        /// </summary>
        public override void Draw()
        {
            Console.SetCursorPosition((int)Tile.ConsoleX, (int)Tile.ConsoleY);
            Console.Write(_drawChar);
        }
    }
}
