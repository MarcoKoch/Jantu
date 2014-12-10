namespace Jantu
{
    class Balancing
    {
        int _attractivityScale = 1;
        int _pooAttractivityPenalty = 50;

        /// <summary>
        /// Gets the scale factor of the attractivity curve for cages.
        /// </summary>
        /// <remarks>
        /// The higher the value, the slower the attractivity of cages rises.
        /// </remarks>
        public int AttractivityScale
        {
            get { return _attractivityScale; }
        }

        /// <summary>
        /// Gets amount by which the attractivity of a cage decreases per poo entity in the cage.
        /// </summary>
        public int PooAttractivityPenalty
        {
            get { return _pooAttractivityPenalty; }
        }
    }
}
