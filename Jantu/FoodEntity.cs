using System;

namespace Jantu
{
    class FoodEntity : Entity
    {
        FoodKind _kind;

        public FoodKind Kind
        {
            get { return _kind; }
        }

        public override void Draw()
        {
            Console.SetCursorPosition((int)Tile.X, (int)Tile.Y);
            Console.Write(_kind.Symbol);
        }
    }
}
