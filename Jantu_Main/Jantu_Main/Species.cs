using System;

namespace Jantu
{
    class Species
    {
        string _name;
        double _movingSpeed;
        double _excrementRate;
        double _foodRate;
        double _mutationProbability;
        uint _maxHealth;
        char _symbol;
        FoodKind[] _food;
        Species[] _preys;
        Species[] _enemies;
        Species[] _breedingPartners;

        public string Name
        {
            get { return _name; }
        }

        public uint MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        public double MovingSpeed
        {
            get { return _movingSpeed; }
            set { _mutationProbability = value; }
        }

        public double ExcrementRate
        {
            get { return _excrementRate; }
            set { _excrementRate = value; }
        }

        public double FoodRate
        {
            get { return _foodRate; }
            set { _foodRate = value; }
        }

        public char Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        public Species(string name)
        {
            _name = name;
        }

        public bool Eats(FoodKind food)
        {
            return Array.Exists(_food, k => k.Equals(food));
        }

        public bool Eats(Species species)
        {
            return Array.Exists(_preys, s => s.Equals(species));
        }

        public bool Attacks(Species species)
        {
            return Array.Exists(_enemies, s => s.Equals(species));
        }

        public bool BreedsWith(Species species)
        {
            return Array.Exists(_breedingPartners, s => s.Equals(species));
        }

        public string Serialize()
        {
            throw new NotImplementedException();
        }

        public static Species Parse(string desc)
        {
            throw new NotImplementedException();
        }
    }
}
