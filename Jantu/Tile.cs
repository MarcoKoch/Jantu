using System;

namespace Jantu
{
    class Tile
    {
        public uint X
        {
            get { return _posX; }
        }

        public uint Y
        {
            get { return _posY; }
        }

        public World World
        {
            get { return _world; }
        }

        public Entity Entity
        {
            get { return _entity; }
            set
            {
                if (null != _entity)
                    _entity.OnTileChanged(null);

                _entity = value;
                _changed = true;

                if (null != value)
                {
                    if (null != value.Tile)
                    {
                        value.Tile._changed = true;
                        value.Tile._entity = null;
                    }
                    value.OnTileChanged(this);
                }
            }
        }

        public Tile Above
        {
            get { return (0 < _posY) ? _world[_posX, _posY - 1] : null; }
        }

        public Tile Below
        {
            get { return ((_world.Height - 1) > _posY) ? _world[_posX, _posY + 1] : null; }
        }

        public Tile Left
        {
            get { return (0 < _posX) ? _world[_posX - 1, _posY] : null; }
        }

        public Tile Right
        {
            get { return ((_world.Width - 1) < _posX) ? _world[_posX + 1, _posY] : null; }
        }

        public Tile(World world, uint x, uint y)
        {
            _world = world;
            _posX = x;
            _posY = y;
            _changed = true;
        }

        public void Update(double dt)
        {
            if (null != _entity)
                _entity.Update(dt);
        }

        public void Draw()
        {
            if (_changed || (null != _entity && _entity.NeedsRedraw))
                ForceDraw();
        }

        public void ForceDraw()
        {
            if (null != _entity)
                _entity.Draw();
            else
            {
                Console.SetCursorPosition((int)_posX, (int)_posY);
                Console.Write(' ');
            }

            _changed = false;
        }

        uint _posX;
        uint _posY;
        Entity _entity;
        World _world;
        bool _changed;
    }
}
