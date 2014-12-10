using System.Collections.Generic;
using System.IO;
using System;

namespace Jantu
{
    class ParseError : Exception
    {
        public ParseError(int line, string message) :
            base("Parse Error in line " + line + ": " + message)
        {
        }
    }

    class CageType
    {
        int _maxAttractivity = 100;
        List<Vector2> _wallPositions = new List<Vector2>();
        List<Vector2> _surroundingTilesPositions = new List<Vector2>();
        List<Vector2> _enclosedTilesPositions = new List<Vector2>();

        CageType() {}

        /// <summary>
        /// Returns the maximum attractivity of cages of this type.
        /// </summary>
        public int MaxAttractivity
        {
            get { return _maxAttractivity; }
        }

        /// <summary>
        /// Returns a list of vectors that represent the locations of each cage wall entity relative to the root location of the cage.
        /// </summary>
        public List<Vector2> WallPositions
        {
            get { return _wallPositions; }
        }

        /// <summary>
        /// Returns a list of vectors that represent the locations of all tiles surrounding the outer wall of the cage.
        /// </summary>
        public List<Vector2> SurroundingTilesPositions
        {
            get { return _surroundingTilesPositions; }
        }

        public List<Vector2> EnclosedTilesPositions
        {
            get { return _enclosedTilesPositions; }
        }

        public static CageType ReadFromFile(string path)
        {
            var file = new StreamReader(path);
            var cageType = new CageType();

            cageType._maxAttractivity = ReadInt(file);
            cageType.ReadLayout(file);

            return cageType;
        }

        static int ReadInt(StreamReader stream)
        {
            string line;
            do
            {
                line = stream.ReadLine();
            } while (string.IsNullOrWhiteSpace(line) || '#' == line[0]);

            return Convert.ToInt32(line);
        }

        void ReadLayout(StreamReader stream)
        {
            int layoutWidth = ReadInt(stream);
            int layoutHeight = ReadInt(stream);

            bool horizontalInCage = false;
            bool[] verticalInCage = new bool[layoutWidth];

            for (int x = 0; layoutWidth > x; ++x)
                verticalInCage[x] = false;

            string[] lines = new string[layoutHeight];
            for (int y = 0; layoutHeight > y; ++y)
                lines[y] = stream.ReadLine();

            for (int y = 0; layoutHeight > y; ++y)
            {
                for (int x = 0; layoutWidth > x; ++x)
                {
                    switch (lines[y][x])
                    {
                        case ' ':
                            if (horizontalInCage && verticalInCage[x])
                                _enclosedTilesPositions.Add(new Vector2(x, y));
                            break;

                        case '#':
                            _wallPositions.Add(new Vector2(x, y));

                            if (horizontalInCage && (((layoutWidth - 1) == x) || '#' == lines[y][x + 1]))
                                _surroundingTilesPositions.Add(new Vector2(x + 1, y));
                            else if (!horizontalInCage && (0 == x || '#' == lines[y][x-1]))
                                _surroundingTilesPositions.Add(new Vector2(x - 1, y));

                            if (verticalInCage[x] && ((layoutHeight - 1) == x || '#' == lines[y+1][x]))
                                _surroundingTilesPositions.Add(new Vector2(x, y+1));
                            else if (!verticalInCage[x] && (0 == x || '#' == lines[y-1][x]))
                                _surroundingTilesPositions.Add(new Vector2(x, y-1));

                            break;

                        default:
                            throw new ParseError(y, "Unexpected character '" + lines[y][x] + "'");
                    }
                }
            }
        }
    }
}
