using System.Collections.Generic;

namespace Jantu
{
    class CageType
    {
        int _maxAttractivity = 100;

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
            get
            {
                // TODO
                return new List<Vector2>();
            }
        }

        /// <summary>
        /// Returns a list of vectors that represent the locations of all tiles surrounding the outer wall of the cage.
        /// </summary>
        public List<Vector2> SurroundingTilesPositions
        {
            get
            {
                // TODO
                return new List<Vector2>();
            }
        }
    }
}
