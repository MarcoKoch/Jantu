using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
    class CursorManager
    {
        //X and Y coordinates for the cursorposition
        private int x = 0;
        private int y = 0;
        private int w = 0;
        private int h = 0;

        /// <summary>
        /// w and h are set by the constructor which determines how large the world is
        /// </summary>
        public CursorManager(int wi, int he)
        {
            w = wi;
            h = he;
        }

        /// <summary>
        /// Moves the cursor 1 position to the left if it is not at the edge of the plane
        /// </summary>
        public void MoveLeft()
        {
            if (x != 0)
            {
                x--;
            }
            Console.SetCursorPosition(x, y);
        }

        /// <summary>
        /// Moves the cursor 1 position to the right if it is not at the edge of the plane
        /// </summary>
        public void MoveRight()
        {
            if (x != w)
            {
                x++;
            }
            Console.SetCursorPosition(x, y);
        }

        /// <summary>
        /// Moves the cursor 1 position upwards if it is not at the edge of the plane
        /// </summary>
        public void MoveUp()
        {
            if (y != 0)
            {
                x--;
            }
            Console.SetCursorPosition(x, y);
        }

        /// <summary>
        /// Moves the cursor 1 position downwards if it is not at the edge of the plane
        /// </summary>
        public void MoveDown()
        {
            if (y != h)
            {
                x++;
            }
            Console.SetCursorPosition(x, y);
        }

        /// <summary>
        /// Returns the X-Coordinate.
        /// </summary>
        public int GetX()
        {
            return x;
        }

        /// <summary>
        /// Returns the Y-Coordinate.
        /// </summary>
        public int GetY()
        {
            return y;
        }


    }
}
