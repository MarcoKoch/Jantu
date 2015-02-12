using System;

namespace Jantu
{
    /// <summary>
    /// Represents an animal in the game world.
    /// </summary>
    class AnimalEntity : MovingEntity
    {
        Species _species;
        int     _hunger;
        int     _health;
        double _timeSinceLastPoo;

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
        public int Hunger
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
        public int Health
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
        /// <remarks>
        /// Breeding may fail if no either the two species can't breed with each other or there is no
        /// free tile beside the animal. If breeding succeeds, a new animal is created and placed at a random
        /// neighbouring tile.
        /// </remarks>
        /// <returns>
        /// The newly created animal, if successful. <c>null</c> if breeding failed.
        /// </returns>
        public AnimalEntity TryBreedWith(AnimalEntity other)
        {
            if (!Species.BreedsWith(other.Species))
                return null;
            
            Tile newAnimalTile = Tile.FindRandomEmptyNeighbour();
            if (null != newAnimalTile)
            {
                var child = new AnimalEntity(Species.BreedWith(other.Species, Tile.World.Game.Data.Species, Tile.World.Game.Random));
                child.Tile = newAnimalTile;
                return child;
            }

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
        public PooEntity TryPoo()
        {
            Tile pooTile = Tile.FindRandomEmptyNeighbour();
            if (null != pooTile)
            {
                var poo = new PooEntity();
                poo.Tile = pooTile;
                return poo;
            }

            return null;
        }

        public override void Update(double dt)
        {
            base.Update(dt);

            // Is there some internal pressure?
            _timeSinceLastPoo += dt;
            if (_timeSinceLastPoo >= Species.PooPeriod)
            {
                if (TryPoo() != null)
                    _timeSinceLastPoo = 0;
            }
        }

        public override void Draw()
        {
            Console.SetCursorPosition((int)Tile.ConsoleX, (int)Tile.ConsoleY);
            Console.Write(_species.Symbol);
        }

        protected override bool OnBlockingQuery()
        {
            return true;
        }

        protected override bool OnCollision(Entity other)
        {
            // Can we breed with it?
            var otherAnimal = other as AnimalEntity;
            if (otherAnimal != null)
            {
                var child = TryBreedWith(otherAnimal);

                // If we can't breed with it, let's eat it xD
                if (child == null)
                    Eat(otherAnimal);

                return true;
            }

            // Is it edible?
            var food = other as FoodEntity;
            if (food != null)
            {
                Eat(food);
                return true;
            }

            return false;
        }

        protected override void OnTileChanged(Tile oldTile)
        {
            base.OnTileChanged(oldTile);

            if (oldTile != null && oldTile.Cage != null)
                oldTile.Cage.RemoveAnimal(this);
            if (Tile != null && Tile.Cage != null)
                Tile.Cage.AddAnimal(this);
        }
    }
}
