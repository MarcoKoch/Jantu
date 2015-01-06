namespace Jantu
{
    class Balancing
    {
        private int _attractivityScale = 1;
        private int _pooAttractivityPenalty = 50;
        private int _baseCleaningCost = 99;
        private int _defaultBreedingProbability = 99;
        private int _fightingTime = 99;
        private int _breedingTime = 99;
        private int _eatingTime = 99;
        private int _starveTime = 99;
        private int _actionPreparationTime = 99;
        private int _maxRandomStrength = 99;
        private int _foodPeriod = 99;
        private int _dayLength = 99;
        private int _baseIncome = 99;


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
        
        /// <summary>
        /// Gets the cost for removing a poo entity in the cage.
        /// </summary>
        /// <remarks>
        /// The higher the value, the more the player has to pay for removing poo.
        /// </remarks>
        public int BaseCleaningCost
        {
            get { return _baseCleaningCost; }
        }
        /// <summary>
        /// Gets the propability of how likely it is that two different species reproduce.
        /// </summary>
        /// <remarks>
        /// The higher the value, the higher is the possibility that different species reproduce.
        /// </remarks>
        public int DefaultBreedingProbability
        {
            get { return _defaultBreedingProbability; }
        }
        /// <summary>
        /// Gets the value of the battletime between two animals.
        /// </summary>
        public int FightingTime
        {
            get { return _fightingTime; }
        }
        /// <summary>
        /// Gets the value of the matingtime between two animals.
        /// </summary>
        public int BreedingTime
        {
            get { return _breedingTime; }
        }
        /// <summary>
        /// Gets the value of the eatingtime.
        /// </summary>
        public int EatingTime
        {
            get { return _eatingTime; }
        }
        /// <summary>
        /// Gets the value of the time a starved body will not despawn.
        /// </summary>
        /// <remarks>
        /// The higher the value, the longer the corpses lie around in the zoo.
        /// </remarks>
        public int StarveTime
        {
            get { return _starveTime; }
        }
        /// <summary>
        /// Gets the value of the time of how long it takes until another action hcan be done.
        /// </summary>
        /// <remarks>
        /// The lower the value, the faster actions happen in the zoo.
        /// </remarks>
        public int ActionPreparationTime
        {
            get { return _actionPreparationTime; }
        }
        /// <summary>
        /// Gets the scale of the highest random strength modifier.
        /// </summary>
        /// <remarks>
        /// The higher the value, the stronger the random mofier can be.
        /// </remarks>
        public int MaxRandomStrength
        {
            get { return _maxRandomStrength; }
        }
        /// <summary>
        /// Gets the time between eating and fully consuming food.
        /// </summary>
        /// <remarks>
        /// Higher Values stay longer on the field.
        /// </remarks>
        public int FoodPeriod
        {
            get { return _foodPeriod; }
        }
        /// <summary>
        /// The Realtime an ingame Name needs.
        /// </summary>
        /// <remarks>
        /// The higher the value, the slower the day progress in the game.
        /// </remarks>
        public int DayLength
        {
            get { return _dayLength; }
        }
        /// <summary>
        /// Gets base income value per attractivity point.
        /// </summary>
        public int BaseIncome
        {
            get { return _baseIncome; }
        }

    }
}
