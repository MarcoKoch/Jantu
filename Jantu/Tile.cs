using System;
using System.Collections.Generic;

namespace Jantu
{
    /// <summary>
    /// Represents a tile in the world.
    /// </summary>
    /// <remarks>
    /// A tile is displayed as a single character on the console. Each tile can
    /// hold either none or a single entity. If present, that entity is drawn at the
    /// location of the tile.
    /// </remarks>
    class Tile
    {
        private Vector2 _pos;
        Entity _entity;
        World _world;
        Cage _cage;
        bool _changed;

        /// <summary>
        /// Gets the x coordinate of the tile.
        /// </summary>
        public int X
        {
            get { return _pos.X; }
        }

        /// <summary>
        /// Gets the y coordinate of the tile.
        /// </summary>
        public int Y
        {
            get { return _pos.Y; }
        }

        /// <summary>
        /// Gets the world position of the tile.
        /// </summary>
        public Vector2 Position
        {
            get { return _pos;}
        }

        /// <summary>
        /// Gets the x coordinate of the tile in the console.
        /// </summary>
        public int ConsoleX
        {
            get { return _world.OriginX + _pos.X; }
        }

        /// <summary>
        /// Gets the y coordinate of the tile in the console.
        /// </summary>
        public int ConsoleY
        {
            get { return _world.OriginY + _pos.Y; }
        }

        /// <summary>
        /// Gets the coordinates of the tile in the console.
        /// </summary>
        public Vector2 ConsolePosition
        {
            get { return _pos + _world.Origin; }
        }

        /// <summary>
        /// Gets the world of which the tile is part.
        /// </summary>
        public World World
        {
            get { return _world; }
        }

        /// <summary>
        /// Gets or sets the entity that is placed on the tile.
        /// </summary>
        /// <remarks>
        /// Assigning <c>null</c> removes the current entity from
        /// the tile. Assigning an entity that is already on an other
        /// tile, will move that entity.
        /// </remarks>
        /// <value>
        /// The entity, if any. <c>null</c> otherwise.
        /// </value>
        public Entity Entity
        {
            get { return _entity; }
            set
            {
                if (null != _entity)
                    _entity.SetTile(null);

                _entity = value;
                _changed = true;

                if (null != value)
                {
                    if (null != value.Tile)
                    {
                        value.Tile._changed = true;
                        value.Tile._entity = null;
                    }
                    value.SetTile(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the cage to which the tile belongs.
        /// </summary>
        public Cage Cage
        {
            get { return _cage; }
            set { _cage = value; }
        }

        /// <summary>
        /// Returns whether the tile is blocked by a blocking entity.
        /// </summary>
        public bool Blocked
        {
            get { return Entity != null && Entity.Blocking; }
        }

        /// <summary>
        /// Gets the tile above <c>this</c>.
        /// </summary>
        /// <value>
        /// The tile above <c>this</c>, if any. <c>null</c> if <c>this</c>
        /// is in the top row of the world.
        /// </value>
        public Tile Above
        {
            get { return (0 < Y) ? _world[X, Y - 1] : null; }
        }

        /// <summary>
        /// Gets the tile below <c>this</c>.
        /// </summary>
        /// <value>
        /// The tile below <c>this</c>, if any. <c>null</c> if <c>this</c>
        /// is in the bottom row of the world.
        /// </value>
        public Tile Below
        {
            get { return ((_world.Height - 1) > Y) ? _world[X, Y + 1] : null; }
        }

        /// <summary>
        /// Gets the tile left of <c>this</c>.
        /// </summary>
        /// <value>
        /// The tile left of <c>this</c>, if any. <c>null</c> if <c>this</c>
        /// is in the leftmost column of the world.
        /// </value>
        public Tile Left
        {
            get { return (0 < X) ? _world[X - 1, Y] : null; }
        }

        /// <summary>
        /// Gets the tile right of <c>this</c>.
        /// </summary>
        /// <value>
        /// The tile right of <c>this</c>, if any. <c>null</c> if <c>this</c>
        /// is in the rightmost column of the world.
        /// </value>
        public Tile Right
        {
            get { return ((_world.Width - 1) < X) ? _world[X + 1, Y] : null; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.Tile"/> class.
        /// </summary>
        /// <param name='world'>
        /// World to which the tile belongs.
        /// </param>
        /// <param name='x'>
        /// X coordinate.
        /// </param>
        /// <param name='y'>
        /// Y coordinate.
        /// </param>
        public Tile(World world, int x, int y)
        {
            _world = world;
            _pos = new Vector2(x, y);
            _changed = true;
        }

        /// <summary>
        /// Finds a random empty neighbour tile.
        /// </summary>
        /// <returns>
        /// A random neighbour tile that os not occupied by an entity.
        /// <c>null</c> if no such tile is found.
        /// </returns>
        /// <param name='rand'>
        /// Random number generator to be used.
        /// </param>
        public Tile FindRandomEmptyNeighbour(Random rand)
        {
            List<Tile> freeTiles = new List<Tile>();

            for (int x = X - 1; X + 1 > x; ++x)
            {
                for (int y = Y - 1; Y + 1 > y; ++y)
                {
                    Tile t = _world[x, y];
                    if (null != t && null != t.Entity)
                        freeTiles.Add(t);
                }
            }

            return freeTiles[rand.Next(0, freeTiles.Count)];
        }

        /// <summary>
        /// Updates the tile and the entity on it, if any.
        /// </summary>
        /// <param name='dt'>
        /// Seconds passed since the last call to this function.
        /// </param>
        /// <remarks>
        /// This should be called once per frame.
        /// </remarks>
        public void Update(double dt)
        {
            if (null != _entity)
                _entity.Update(dt);
        }

        /// <summary>
        /// Draws the tile if it needs to be redrawn.
        /// </summary>
        /// <remarks>
        /// The tile is only redrawn if either a new entity was assigned or
        /// the <see cref="Jantu.Entity.NeedsRedraw"/> renturns <c>true</c> on
        /// the entity on the tile. To force a redraw, use <see cref="Jantu.Tile.ForceDraw"/>.
        /// </remarks>
        public void Draw()
        {
            if (_changed || (null != _entity && _entity.NeedsRedraw))
                ForceDraw();
        }

        /// <summary>
        /// Forces a redraw of the tile.
        /// </summary>
        /// <remarks>
        /// This forces the tile to redraw itself, regardless of whether this would
        /// be neccessary. Usually <see cref="Jantu.Tile.Draw"/> is the better alternative.
        /// </remarks>
        public void ForceDraw()
        {
            Console.BackgroundColor = _world.BackgroundColor;

            if (null != _entity)
            {
                _entity.Draw();
            }
            else
            {
                Console.SetCursorPosition(ConsoleX, ConsoleY);
                Console.Write(' ');
            }

            _changed = false;
        }
    }
}
