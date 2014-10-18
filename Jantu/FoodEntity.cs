using System;

namespace Jantu
{
    class FoodEntity : Entity
    {
        public FoodKind Kind
        {
            get { return _kind; }
        }

        public FoodEntity(FoodKind kind)
        {
            _kind = kind;
        }

        public override void Draw()
        {
            Console.SetCursorPosition((int)Tile.X, (int)Tile.Y);
            Console.Write(_kind.Symbol);
        }

        FoodKind _kind;
    }
}
