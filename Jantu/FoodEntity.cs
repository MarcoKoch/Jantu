using System;

namespace Jantu
{
    /// <summary>
    /// Represents a food object in the game world.
    /// </summary>
    class FoodEntity : Entity
    {
        FoodKind _kind;

        /// <summary>
        /// Gets the kind of food.
        /// </summary>
        /// <value>
        /// The kind of food.
        /// </value>
        public FoodKind Kind
        {
            get { return _kind; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.FoodEntity"/> class.
        /// </summary>
        /// <param name='kind'>
        /// Kind.
        /// </param>
        public FoodEntity(FoodKind kind)
        {
            _kind = kind;
        }

        /// <summary>
        /// Draws the entity.
        /// </summary>
        public override void Draw()
        {
            Console.SetCursorPosition((int)Tile.ConsoleX, (int)Tile.ConsoleY);
            Console.Write(_kind.Symbol);
        }
    }
}
