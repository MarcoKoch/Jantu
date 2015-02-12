using System;

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

        protected override void OnTileChanged(Tile oldTile)
        {
            base.OnTileChanged(oldTile);
            if (oldTile != null && oldTile.Cage != null)
                oldTile.Cage.RemovePoo(this);
            if (Tile != null && Tile.Cage != null)
                Tile.Cage.AddPoo(this);
        }

        protected override bool OnBlockingQuery()
        {
            return true;
        }
    }
}
