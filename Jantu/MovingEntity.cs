using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Jantu
{
    class MovingEntity : Entity
    {
        public Vector2 EndPosition;
        public float MovingSpeed = 1f;      // Felder pro Sekunde
        private double _time;
        private int _dx;
        private int _dy;
        private bool _newEndPosition;


        Random r = new Random();

        public MovingEntity()               // Endpunkt
        {
            EndPosition = new Vector2(10, 10);
        }

        public override void Update(double dt)
        {
            World _world = Tile.World;
            _time += 0.05f;

            if (_time >= MovingSpeed)
            {
                _time = 0;

                if (EndPosition.X > Tile.X)
                {
                    _dx = 1;
                }
                else if (EndPosition.X < Tile.X)
                {
                    _dx = -1;
                }
                else
                {
                    _dx = 0;
                }

                if (EndPosition.Y > Tile.Y)
                {
                    _dy = 1;
                }
                else if (EndPosition.Y < Tile.Y)
                {
                    _dy = -1;
                }
                else
                {
                    _dy = 0;
                }

                if (_dx == 0 && _dy == 0)
                {
                    while (!_newEndPosition)
                    {
                        EndPosition = new Vector2(r.Next(0, Tile.World.Width - 1), r.Next(0, Tile.World.Height - 1));
                        for (int i = 0; i < Tile.Cage.EnclosedTiles.Count; i++)
                        {
                            if (EndPosition.X == Tile.Cage.EnclosedTiles[i].X &&
                                EndPosition.Y == Tile.Cage.EnclosedTiles[i].Y)
                            {
                                _newEndPosition = true;
                            }
                        }
                    }

                    _newEndPosition = false;
                    return;
                }

                if (_dx != 0)
                {
                    if (_dy != 0)
                    {
                        if (_dx == 1 && _dy == 1)
                        {
                            _world[Tile.X + 1, Tile.Y + 1].Entity = this;
                        }

                        if (_dx == 1 && _dy == -1)
                        {
                            _world[Tile.X + 1, Tile.Y - 1].Entity = this;
                        }

                        if (_dx == -1 && _dy == 1)
                        {
                            _world[Tile.X - 1, Tile.Y + 1].Entity = this;
                        }

                        if (_dx == -1 && _dy == -1)
                        {
                            _world[Tile.X - 1, Tile.Y - 1].Entity = this;
                        }
                    }
                    else
                    {
                        if (_dx == 1)
                        {
                            _world[Tile.X + 1, Tile.Y].Entity = this;
                        }
                        if (_dx == -1)
                        {
                            _world[Tile.X - 1, Tile.Y].Entity = this;
                        }
                    }
                }
                else
                {
                    if (_dy == 1)
                    {
                        _world[Tile.X, Tile.Y + 1].Entity = this;
                    }
                    if (_dy == -1)
                    {
                        _world[Tile.X, Tile.Y - 1].Entity = this;
                    }
                }
                
                //Tile.Left.Cage.
                //Tile.Left.Cage.AddPoo();                           // Poo hinzufügen
                //Tile.Left.Entity = this;                           // Variante 1
                //_world[Tile.X - 1, Tile.Y].Entity = this;          // Variante 2
            }
        }
    }
}
