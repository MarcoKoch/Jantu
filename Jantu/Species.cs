using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jantu
{
	[Serializable()]
    class Species : ISerializable
    {
        public string Name
        {
            get { return _name; }
        }

        public int MaxHealth
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
            _food = new List<FoodKind>();
            _preys = new List<Species>();
            _enemies = new List<Species>();
            _breedingPartners = new List<Species>();
        }
		
		public Species(SerializationInfo info, StreamingContext ctx)
		{
			_name = (string)info.GetValue("Name", typeof(string));
			_movingSpeed = (double)info.GetValue("MovingSpeed", typeof(double));
			_excrementRate = (double)info.GetValue("ExcrementRate", typeof(double));
			_foodRate = (double)info.GetValue("FoodRate", typeof(double));
			_mutationProbability = (double)info.GetValue("MutationProbability", typeof(double));
			_maxHealth = (int)info.GetValue("MaxHealth", typeof(int));
			_symbol = (char)info.GetValue("Symbol", typeof(char));

            // During serialization we stored name strings instead of references (references
            // change between program invokations and thus can't be serialized). The ctx
            // argument is expected to provide a pre-initialized data manager, which we can use
            // to restore the references.
            DataManager data = ctx.Context as DataManager;

            List<string> foodNames = (List<string>)info.GetValue("Food", typeof(List<string>));
            _food = new List<FoodKind>(foodNames.Count);
            foreach (string kindName in foodNames)
                _food.Add(data.FoodKinds.GetByName(kindName));

            List<string> preyNames = (List<string>)info.GetValue("Preys", typeof(List<string>));
            _preys = new List<Species>(preyNames.Count);
            foreach (string preyName in preyNames)
                _preys.Add(data.Species.GetByName(preyName));

            List<string> enemyNames = (List<string>)info.GetValue("Enemies", typeof(List<string>));
            _enemies = new List<Species>(enemyNames.Count);
            foreach (string enemyName in enemyNames)
                _enemies.Add(data.Species.GetByName(enemyName));

            List<string> breedingPartnerNames = (List<string>)info.GetValue("BreedingPartners", typeof(List<string>));
            _breedingPartners = new List<Species>(breedingPartnerNames.Count);
            foreach (string breedingPartnerName in breedingPartnerNames)
                _breedingPartners.Add(data.Species.GetByName(breedingPartnerName));
		}
		
		public void GetObjectData(SerializationInfo info, StreamingContext ctx)
		{
			info.AddValue("Name", _name);
			info.AddValue("MovingSpeed", _movingSpeed);
			info.AddValue("ExcrementRate", _excrementRate);
			info.AddValue("FoodRate", _foodRate);
			info.AddValue("MutationProbability", _mutationProbability);
			info.AddValue("MaxHealth", _maxHealth);
			info.AddValue("Symbol", _symbol);

            // We can't serialize references. Instead we write name strings and use these to
            // restore the references from the game data managers during deserialization.
			List<string> foodNames = new List<string>(_food.Count);
			foreach (FoodKind kind in _food)
				foodNames.Add(kind.Name);
			info.AddValue("Food", foodNames);
			
			List<string> preyNames = new List<string>(_preys.Count);
			foreach (Species prey in _preys)
				preyNames.Add(prey.Name);
			info.AddValue("Preys", preyNames);

            List<string> enemyNames = new List<string>(_enemies.Count);
            foreach (Species enemy in _enemies)
                enemyNames.Add(enemy.Name);
            info.AddValue("Enemies", enemyNames);

            List<string> breedingPartnerNames = new List<string>(_breedingPartners.Count);
            foreach (Species breedingPartner in _breedingPartners)
                breedingPartnerNames.Add(breedingPartner.Name);
            info.AddValue("BreedingPartners", breedingPartnerNames);
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

        public Species BreedWith(Species other, SpeciesManager allSpecies, Random rand)
        {
            // Comparision by object identity is intentional!
            if (other == this)
                return this;

            if (rand.NextDouble() <= _mutationProbability)
                return allSpecies.GetRandomSpecialSpecies(rand);

            // Create a new species that is a combination of the both breeding species
            Species newSpecies = new Species(Name + other.Name);
            newSpecies._food = Mutate(_food, other._food, rand);
            newSpecies._preys = Mutate(_preys, other._preys, rand);
            newSpecies._enemies = Mutate(_enemies, other._enemies, rand);
            newSpecies._breedingPartners = Mutate(_breedingPartners, other._breedingPartners, rand);

            allSpecies.Add(newSpecies);
            return newSpecies;
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
		
		string _name;
        double _movingSpeed;
        double _excrementRate;
        double _foodRate;
        double _mutationProbability;
        int _maxHealth;
        char _symbol;
        List<FoodKind> _food;
        List<Species> _preys;
        List<Species> _enemies;
        List<Species> _breedingPartners;
    }
}
