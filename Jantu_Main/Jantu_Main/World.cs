using System;

namespace Jantu
{
    class World
    {
        public uint Width
        {
            get { return _width; }
        }

        public uint Height
        {
            get { return _height; }
        }

        public Tile this[uint x, uint y]
        {
            get
            {
                if (_width <= x || _height <= y)
                    throw new ArgumentOutOfRangeException("Invalid Tile coordinates");
                return _tiles[x][y];
            }
        }

        public World(uint width, uint height)
        {
            _width = width;
            _height = height;
            _tiles = new Tile[width][];

            for (uint x = 0; width > x; ++x)
            {
                _tiles[x] = new Tile[height];
                for (uint y = 0; height > y; ++y)
                    _tiles[x][y] = new Tile(this, x, y);
            }
        }

        public void Update(double dt)
        {
            foreach (Tile[] row in _tiles)
                foreach (Tile tile in row)
                    tile.Update(dt);
        }

        public void Draw(double dt)
        {
            foreach (Tile[] row in _tiles)
                foreach (Tile tile in row)
                    tile.Draw();
        }

        uint _width;
        uint _height;
        Tile[][] _tiles;
    }
}
