using System;

namespace Jantu
{
    /// <summary>
    /// Represents the game world.
    /// </summary>
    class World
    {
        int _width;
        int _height;
        Tile[][] _tiles;

        /// <summary>
        /// Gets the width of the world.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width
        {
            get { return _width; }
        }

        /// <summary>
        /// Gets the height of the world.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height
        {
            get { return _height; }
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
                return _tiles[x][y];
            }
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
        public World(int width, int height)
        {
            if (0 >= width || 0 >= height)
                throw new ArgumentOutOfRangeException("World dimensions");

            _width = width;
            _height = height;
            _tiles = new Tile[width][];

            for (int x = 0; width > x; ++x)
            {
                _tiles[x] = new Tile[height];
                for (int y = 0; height > y; ++y)
                    _tiles[x][y] = new Tile(this, x, y);
            }
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
            foreach (Tile[] row in _tiles)
                foreach (Tile tile in row)
                    tile.Update(dt);
        }

        /// <summary>
        /// Draws the world.
        /// </summary>
        public void Draw()
        {
            foreach (Tile[] row in _tiles)
                foreach (Tile tile in row)
                    tile.Draw();
        }
    }
}
