namespace Jantu
{
    internal class MovingEntity : Entity
    {
        private Tile[] _movements;
        private World _squares = new World(15, 15, 0, 0);


        // gucken ob null zurückgegeben wird
        static private bool ValidCoordinates(int x, int y)
        {
            if (x < 0)
            {
                return false;
            }
            if (y < 0)
            {
                return false;
            }
            if (x > 14)
            {
                return false;
            }
            if (y > 14)
            {
                return false;
            }
            return true;
        }

        // Prüfen wenn die Entity Eigenschaft ungleich null ist
        enum SquareContent
        {
            Empty,
            Animal,
            Food,
            Wall
        };


        private void InitMovements(int movementCount)
        {
            _movements = new Tile[]
            {
                Tile.AboveLeft,
                Tile.Above,
                Tile.AboveRight,
                Tile.AboveLeft,
                Tile.AboveRight,
                Tile.BelowLeft,
                Tile.Below,
                Tile.BelowRight,
            };
        }

        void Pathfind()
        {
            // Find path from hero to monster. First, get coordinates of hero.
            Point startingPoint = FindCode(SquareContent.Hero);
            int heroX = startingPoint.X;
            int heroY = startingPoint.Y;
            if (heroX == -1 || heroY == -1)
            {
                return;
            }
            // Hero starts at distance of 0.
            _squares[heroX, heroY].DistanceSteps = 0;

            while (true)
            {
                bool madeProgress = false;

                // Look at each square on the board.
                foreach (Point mainPoint in Squares())
                {
                    int x = mainPoint.X;
                    int y = mainPoint.Y;

                    // If the square is open, look through valid moves given
                    // the coordinates of that square.
                    if (SquareOpen(x, y))
                    {
                        int passHere = _squares[x, y].DistanceSteps;

                        foreach (Point movePoint in ValidMoves(x, y))
                        {
                            int newX = movePoint.X;
                            int newY = movePoint.Y;
                            int newPass = passHere + 1;

                            if (_squares[newX, newY].DistanceSteps > newPass)
                            {
                                _squares[newX, newY].DistanceSteps = newPass;
                                madeProgress = true;
                            }
                        }
                    }
                }
                if (!madeProgress)
                {
                    break;
                }
            }
        }

    }
}