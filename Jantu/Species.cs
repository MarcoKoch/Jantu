using System;
using System.Collections.Generic;

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
        List<FoodKind> _food;
        List<Species> _preys;
        List<Species> _enemies;
        List<Species> _breedingPartners;
        SpeciesManager _mgr;

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

        public Species(string name, SpeciesManager mgr)
        {
            _name = name;
            _mgr = mgr;
            _food = new List<FoodKind>();
            _preys = new List<Species>();
            _enemies = new List<Species>();
            _breedingPartners = new List<Species>();
        }

        public bool Eats(FoodKind food)
        {
            // The comparision by object identity is intentional!
            return _food.Exists(k => k == food);
        }

        public bool Eats(Species species)
        {
            // The comparision by object identity is intentional!
            return _preys.Exists(s => s == species);
        }

        public bool Attacks(Species species)
        {
            // The comparision by object identity is intentional!
            return _enemies.Exists(s => s == species);
        }

        public bool BreedsWith(Species species)
        {
            // The comparision by object identity is intentional!
            return _breedingPartners.Exists(s => s == species);
        }

        public Species BreedWith(Species other, Random rand)
        {
            // Comparision by object identity is intentional!
            if (other == this)
                return this;

            if (rand.NextDouble() <= _mutationProbability)
                return _mgr.GetRandomSpecialSpecies(rand);

            // Create a new species that is a combination of the both breeding species
            Species newSpecies = new Species(Name + other.Name, _mgr);
            newSpecies._food = Mutate(_food, other._food, rand);
            newSpecies._preys = Mutate(_preys, other._preys, rand);
            newSpecies._enemies = Mutate(_enemies, other._enemies, rand);
            newSpecies._breedingPartners = Mutate(_breedingPartners, other._breedingPartners, rand);

            _mgr.Add(newSpecies);
            return newSpecies;
        }

        public string Serialize()
        {
            throw new NotImplementedException();
        }

        public static Species Parse(string desc)
        {
            throw new NotImplementedException();
        }

        private List<T> Mutate<T>(List<T> genomeA, List<T> genomeB, Random rand)
        {
            List<T> retval = new List<T>();
            foreach (T v in genomeA)
                if (0.5 <= rand.NextDouble())
                    retval.Add(v);

            foreach (T v in genomeB)
                if (0.5 <= rand.NextDouble() && !retval.Exists(rv => Object.ReferenceEquals(rv, v)))
                    retval.Add(v);

            return retval;
        }
    }
}
