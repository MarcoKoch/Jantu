using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
    class CageWallEntity : Entity
    {
        const char _drawChar = '#';
        Cage _cage;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="cage">Cage to which the wall belongs</param>
        public CageWallEntity(Cage cage)
        {
            _cage = cage;
        }

        public override void Draw()
        {
            Console.SetCursorPosition((int)Tile.ConsoleX, (int)Tile.ConsoleY);
            Console.Write(_drawChar);
        }
    }
}
