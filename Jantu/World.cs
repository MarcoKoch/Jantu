using System;

namespace Jantu
{
    class World
    {
        int _width;
        int _height;
        Tile[][] _tiles;

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public Tile this[int x, int y]
        {
            get
            {
                if (0 > x || _width <= x || 0 > y || _height <= y)
                    throw new ArgumentOutOfRangeException("Invalid Tile coordinates");
                return _tiles[x][y];
            }
        }

        public World(int width, int height)
        {
            if (0 >= width || 0 >= height)
                throw new ArgumentOutOfRangeException("World dimensions out of range");

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

        public void Update(double dt)
        {
            foreach (Tile[] row in _tiles)
                foreach (Tile tile in row)
                    tile.Update(dt);
        }

        public void Draw()
        {
            foreach (Tile[] row in _tiles)
                foreach (Tile tile in row)
                    tile.Draw();
        }
    }
}
