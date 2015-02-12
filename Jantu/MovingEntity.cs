using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        private Vector2[] _moves = new Vector2[8];
        private List<Vector2> _possibleMoves = new List<Vector2>();

        private bool _started = false;

        // 1 - Oben rechts
        // 2 - Rechts
        // 3 - Unten Rechts
        // 4 - Unten
        // 5 - Unten Links
        // 6 - Links
        // 7 - Oben Links
        // 8 - Oben

        // Endposition muss ggf überschrieben werden,
        // wenn das Animal ein bestimmtes Ziel hat



        Random r = new Random();

        public MovingEntity()
        {

        }




        public override void Update(double dt)
        {
            World _world = Tile.World;

            if (_started)
            {
                _moves[0] = new Vector2(Tile.X + 1, Tile.Y - 1);
                _moves[1] = new Vector2(Tile.X + 1, Tile.Y);
                _moves[2] = new Vector2(Tile.X + 1, Tile.Y + 1);
                _moves[3] = new Vector2(Tile.X, Tile.Y + 1);
                _moves[4] = new Vector2(Tile.X - 1, Tile.Y + 1);
                _moves[5] = new Vector2(Tile.X - 1, Tile.Y);
                _moves[6] = new Vector2(Tile.X - 1, Tile.Y - 1);
                _moves[7] = new Vector2(Tile.X, Tile.Y - 1);


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
                        _dy = -1;
                    }
                    else if (EndPosition.Y < Tile.Y)
                    {
                        _dy = 1;
                    }
                    else
                    {
                        _dy = 0;
                    }

                    if (_dx == 0 && _dy == 0)
                    {
                        LookForEndPosition();
                    }

                    if (_dx != 0)
                    {
                        if (_dy != 0)
                        {
                            if (_dx == 1 && _dy == 1)
                            {
                                _possibleMoves.Add(_moves[0]);
                                _possibleMoves.Add(_moves[1]);
                                _possibleMoves.Add(_moves[7]);
                                _possibleMoves.Add(_moves[2]);
                                _possibleMoves.Add(_moves[6]);
                                _possibleMoves.Add(_moves[3]);
                                _possibleMoves.Add(_moves[5]);
                                _possibleMoves.Add(_moves[4]);
                            }

                            if (_dx == 1 && _dy == -1)
                            {
                                _possibleMoves.Add(_moves[2]);
                                _possibleMoves.Add(_moves[3]);
                                _possibleMoves.Add(_moves[1]);
                                _possibleMoves.Add(_moves[4]);
                                _possibleMoves.Add(_moves[0]);
                                _possibleMoves.Add(_moves[5]);
                                _possibleMoves.Add(_moves[7]);
                                _possibleMoves.Add(_moves[6]);


                            }

                            if (_dx == -1 && _dy == 1)
                            {
                                _possibleMoves.Add(_moves[6]);
                                _possibleMoves.Add(_moves[5]);
                                _possibleMoves.Add(_moves[7]);
                                _possibleMoves.Add(_moves[4]);
                                _possibleMoves.Add(_moves[0]);
                                _possibleMoves.Add(_moves[3]);
                                _possibleMoves.Add(_moves[1]);
                                _possibleMoves.Add(_moves[2]);
                            }

                            if (_dx == -1 && _dy == -1)
                            {
                                _possibleMoves.Add(_moves[4]);
                                _possibleMoves.Add(_moves[5]);
                                _possibleMoves.Add(_moves[3]);
                                _possibleMoves.Add(_moves[6]);
                                _possibleMoves.Add(_moves[2]);
                                _possibleMoves.Add(_moves[7]);
                                _possibleMoves.Add(_moves[1]);
                                _possibleMoves.Add(_moves[0]);

                            }
                        }
                        else
                        {
                            if (_dx == 1)
                            {
                                _possibleMoves.Add(_moves[1]);
                                _possibleMoves.Add(_moves[2]);
                                _possibleMoves.Add(_moves[0]);
                                _possibleMoves.Add(_moves[3]);
                                _possibleMoves.Add(_moves[7]);
                                _possibleMoves.Add(_moves[4]);
                                _possibleMoves.Add(_moves[6]);
                                _possibleMoves.Add(_moves[5]);

                            }
                            if (_dx == -1)
                            {
                                _possibleMoves.Add(_moves[5]);
                                _possibleMoves.Add(_moves[4]);
                                _possibleMoves.Add(_moves[6]);
                                _possibleMoves.Add(_moves[3]);
                                _possibleMoves.Add(_moves[7]);
                                _possibleMoves.Add(_moves[2]);
                                _possibleMoves.Add(_moves[0]);
                                _possibleMoves.Add(_moves[1]);
                            }
                        }
                    }
                    else
                    {
                        if (_dy == 1)
                        {
                            _possibleMoves.Add(_moves[7]);
                            _possibleMoves.Add(_moves[6]);
                            _possibleMoves.Add(_moves[0]);
                            _possibleMoves.Add(_moves[5]);
                            _possibleMoves.Add(_moves[1]);
                            _possibleMoves.Add(_moves[4]);
                            _possibleMoves.Add(_moves[2]);
                            _possibleMoves.Add(_moves[3]);
                        }
                        if (_dy == -1)
                        {
                            _possibleMoves.Add(_moves[3]);
                            _possibleMoves.Add(_moves[4]);
                            _possibleMoves.Add(_moves[2]);
                            _possibleMoves.Add(_moves[5]);
                            _possibleMoves.Add(_moves[1]);
                            _possibleMoves.Add(_moves[6]);
                            _possibleMoves.Add(_moves[0]);
                            _possibleMoves.Add(_moves[7]);
                        }
                    }

                    for (int i = 0; i < _possibleMoves.Count; i++)
                    {
                        if (_world[_possibleMoves[i]].Blocked)
                        {
                            CollideWith(_world[_possibleMoves[i]].Entity);
                        }

                        if (!_world[_possibleMoves[i]].Blocked)
                        {
                            _world[_possibleMoves[i]].Entity = this;
                            _possibleMoves.Clear();
                            break;
                        }
                    }




                    //Tile.Blocked.Left
                    //Tile.Blocked.Right
                    //Tile.Blocked.Above
                    //Tile.Blocked.Below
                    //Tile.Left.Cage.
                    //Tile.Left.Cage.AddPoo();                           // Poo hinzufügen
                    //Tile.Left.Entity = this;                           // Variante 1
                    //_world[Tile.X - 1, Tile.Y].Entity = this;          // Variante 2


                }
            }
            else
            {
                LookForEndPosition();
                _started = true;
            }
        }

        public void LookForEndPosition() 
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
        }
    }
}
