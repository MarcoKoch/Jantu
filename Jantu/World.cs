using System;

namespace Jantu
{
    /// <summary>
    /// Represents the game world.
    /// </summary>
    class World
    {
        Vector2 _origin;
        int _width;
        int _height;
        Tile[,] _tiles;
        ConsoleColor _bgColor = ConsoleColor.Black;
        bool _changed = false;
        Game _game;

        /// <summary>
        /// Gets the game to which the world belongs.
        /// </summary>
        public Game Game
        {
            get { return _game; }
        }

        /// <summary>
        /// Gets the width of the world.
        /// </summary>
        public int Width
        {
            get { return _width; }
        }

        /// <summary>
        /// Gets the height of the world.
        /// </summary>
        public int Height
        {
            get { return _height; }
        }

        /// <summary>
        /// Gets the x coordinate of the origin of the world in the console.
        /// </summary>
        public int OriginX
        {
            get { return _origin.X; }
        }

        /// <summary>
        /// Gets the y coordinate of the origin of the world in the console.
        /// </summary>
        public int OriginY
        {
            get { return _origin.Y; }
        }

        public Vector2 Origin
        {
            get { return _origin; }
        }

        public ConsoleColor BackgroundColor
        {
            get { return _bgColor; }
            set
            {
                _bgColor = value;
                _changed = true;
            }
        }

        /// <summary>
        /// Gets the tile with the specified coordinates.
        /// </summary>
        /// <param name='x'>
        /// X coordinate.
        /// </param>
        /// <param name='y'>
        /// Y coordinate.
        /// </param>
        /// <exception cref='ArgumentOutOfRangeException'>
        /// Is thrown if the specified coordinates would lie outside the bounds
        /// of the world.
        /// </exception>
        public Tile this[int x, int y]
        {
            get
            {
                if (0 > x || _width <= x || 0 > y || _height <= y)
                    throw new ArgumentOutOfRangeException("Tile coordinates");
                return _tiles[x,y];
            }
        }

        /// <summary>
        /// Gets the tile at the specified location.
        /// </summary>
        /// <param name="pos">Location of the tile relative to the root of the world (top left)</param>
        /// <exception cref='ArgumentOutOfRangeException'>
        /// Is thrown if the specified coordinates would lie outside the bounds
        /// of the world.
        /// </exception>
        public Tile this[Vector2 pos]
        {
            get { return this[pos.X, pos.Y]; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.World"/> class.
        /// </summary>
        /// <param name='width'>
        /// Width.
        /// </param>
        /// <param name='height'>
        /// Height.
        /// </param>
        /// <exception cref='ArgumentOutOfRangeException'>
        /// If the size of the world would be negative or zero.
        /// </exception>
        public World(Game game, int width, int height, Vector2 origin)
        {
            _game = game;

            if (0 >= width || 0 >= height)
                throw new ArgumentOutOfRangeException("World dimensions");

            if (0 > origin.X || (Console.WindowWidth - 1) < origin.X ||
                0 > origin.Y || (Console.WindowHeight - 1) < origin.Y)
                throw new ArgumentOutOfRangeException("World origin location");

            _origin = origin;
            _width = width;
            _height = height;
            _tiles = new Tile[width,height];

            for (int x = 0; width > x; ++x)
                for (int y = 0; height > y; ++y)
                    _tiles[x, y] = new Tile(this, x, y);
        }

        /// <summary>
        /// Updates the world.
        /// </summary>
        /// <param name='dt'>
        /// Seconds passed since the last call to this method.
        /// </param>
        /// <remarks>
        /// This should be called once per frame.
        /// </remarks>
        public void Update(double dt)
        {
            foreach (var tile in _tiles)
                tile.Update(dt);
        }

        /// <summary>
        /// Draws the world.
        /// </summary>
        public void Draw()
        {
            if (_changed)
                ForceDraw();
            else
            {
                foreach (var tile in _tiles)
                    tile.Draw();

                _changed = false;
            }
        }

        public void ForceDraw()
        {
            foreach (var tile in _tiles)
                tile.ForceDraw();

            _changed = false;
        }
    }
}
