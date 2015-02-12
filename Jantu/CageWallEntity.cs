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
            switch (_cage.State)
            {
                case Cage.DisplayState.Selected:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Cage.DisplayState.Preview:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }

            Console.SetCursorPosition((int)Tile.ConsoleX, (int)Tile.ConsoleY);
            Console.Write(_drawChar);
        }

        protected override bool OnBlockingQuery()
        {
            return true;
        }
    }
}
