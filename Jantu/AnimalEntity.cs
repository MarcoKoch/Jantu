using System;

namespace Jantu
{
    class AnimalEntity : Entity
    {
        Species _species;
        uint    _hunger;
        uint    _health;

        public Species Species
        {
            get { return _species;}
        }

        public uint Hunger
        {
            get { return _hunger; }
            set { _hunger = value; }
        }

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

        public AnimalEntity(Species species)
        {
            _species = species;
        }

        public AnimalEntity TryBreedWith(AnimalEntity other, SpeciesManager allSpecies, Random rand)
        {
            if (!Species.BreedsWith(other.Species))
                throw new InvalidOperationException("Trying to breed incompatible enemy types");
            
            Tile newAnimalTile = Tile.FindRandomEmptyNeighbour(rand);
            if (null != newAnimalTile)
                return new AnimalEntity(Species.BreedWith(other.Species, allSpecies, rand));

            return null;
        }

        public void Eat(FoodEntity food)
        {
            food.Tile = null;
            _hunger -= 1;
        }

        public void Eat(AnimalEntity other)
        {
            other.Tile = null;
            _hunger -= 1;
        }

        public PooEntity TryPoo(Random rand)
        {
            Tile pooTile = Tile.FindRandomEmptyNeighbour(rand);
            if (null != pooTile)
                return new PooEntity();

            return null;
        }

        public override void Draw()
        {
            Console.SetCursorPosition((int)Tile.X, (int)Tile.Y);
            Console.Write(_species.Symbol);
        }
    }
}
