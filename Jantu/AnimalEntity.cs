using System;

namespace Jantu
{
    /// <summary>
    /// Represents an animal in the game world.
    /// </summary>
    class AnimalEntity : Entity
    {
        Species _species;
        uint    _hunger;
        uint    _health;

        /// <summary>
        /// Gets the species.
        /// </summary>
        /// <value>
        /// The species.
        /// </value>
        public Species Species
        {
            get { return _species;}
        }

        /// <summary>
        /// Gets or sets the hunger.
        /// </summary>
        /// <value>
        /// The hunger.
        /// </value>
        public uint Hunger
        {
            get { return _hunger; }
            set { _hunger = value; }
        }

        /// <summary>
        /// Gets or sets the health.
        /// </summary>
        /// <value>
        /// The health.
        /// </value>
        public uint Health
        {
            get { return _health; }
            set
            {
                _health = value;
                if (0 == _health)
                    Tile = null; // animal died
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.AnimalEntity"/> class.
        /// </summary>
        /// <param name='species'>
        /// Species.
        /// </param>
        public AnimalEntity(Species species)
        {
            _species = species;
        }

        /// <summary>
        /// Tries the breed with an other animal.
        /// </summary>
        /// <returns>
        /// The newly born animal, if successful. <c>null</c> if no new animal could
        /// be breeded.
        /// </returns>
        /// <param name='other'>
        /// The other animal.
        /// </param>
        /// <param name='allSpecies'>
        /// All species.
        /// </param>
        /// <param name='rand'>
        /// A random number generator to be used.
        /// </param>
        /// <remarks>
        /// Breeding may fail if no either the two species can't breed with each other or there is no
        /// free tile beside the animal. If breeding succeeds, a new animal is created and placed at a random
        /// neighbouring tile.
        /// </remarks>
        /// <returns>
        /// The newly created animal, if successful. <c>null</c> if breeding failed.
        /// </returns>
        public AnimalEntity TryBreedWith(AnimalEntity other, SpeciesManager allSpecies, Random rand)
        {
            if (!Species.BreedsWith(other.Species))
                return null;
            
            Tile newAnimalTile = Tile.FindRandomEmptyNeighbour(rand);
            if (null != newAnimalTile)
                return new AnimalEntity(Species.BreedWith(other.Species, allSpecies, rand));

            return null;
        }

        /// <summary>
        /// Eat the specified food.
        /// </summary>
        /// <param name='food'>
        /// Food.
        /// </param>
        public void Eat(FoodEntity food)
        {
            food.Tile = null;
            _hunger -= 1;
        }

        /// <summary>
        /// Eat the specified other animal.
        /// </summary>
        /// <param name='other'>
        /// Other.
        /// </param>
        public void Eat(AnimalEntity other)
        {
            other.Tile = null;
            _hunger -= 1;
        }

        /// <summary>
        /// Tries to poo.
        /// </summary>
        /// <returns>
        /// The resulting poo, if successful. <c>null</c> otherwise.
        /// </returns>
        /// <param name='rand'>
        /// Random number generator to be used.
        /// </param>
        /// <remarks>
        /// This highly complex process may file if there is no free
        /// tile beside the animal. If successful, the poo is placed on
        /// a random neighbouring tile.
        /// </remarks>
        public PooEntity TryPoo(Random rand)
        {
            Tile pooTile = Tile.FindRandomEmptyNeighbour(rand);
            if (null != pooTile)
            {
                pooTile.AddPooToCage();
                return new PooEntity();
            }

            return null;
        }

        /// <summary>
        /// Draws the animal.
        /// </summary>
        public override void Draw()
        {
            Console.SetCursorPosition((int)Tile.X, (int)Tile.Y);
            Console.Write(_species.Symbol);
        }
    }
}
