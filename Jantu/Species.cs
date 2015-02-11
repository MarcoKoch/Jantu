using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jantu
{
    /// <summary>
    /// Describes a species of animals.
    /// </summary>
    /// <remarks>
    /// This is an abstract description only. Actual animals that can be
    /// seen on screen are described by <see cref="Jantu.AnimalEntity"/>.
    /// </remarks>
	[Serializable()]
    class Species // : ISerializable // Serialization disabled for now
    {
        string _name;
        double _movingSpeed         = 0.0;
        double _poo_period       = 0.1;
        double _foodRate            = 0.1;
        double _mutationProbability = 0.0;
        int _maxHealth              = 100;
        int _attractivity           = 100;
        char _symbol                = '?';
        List<FoodKind> _food;
        List<Species> _preys;
        List<Species> _enemies;
        List<Species> _breedingPartners;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets or sets the max health.
        /// </summary>
        /// <value>
        /// The max health.
        /// </value>
        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        /// <summary>
        /// Gets or sets the moving speed.
        /// </summary>
        /// <value>
        /// The moving speed.
        /// </value>
        public double MovingSpeed
        {
            get { return _movingSpeed; }
            set { _mutationProbability = value; }
        }

        /// <summary>
        /// Gets or sets the excrement rate.
        /// </summary>
        /// <value>
        /// The excrement rate.
        /// </value>
        public double PooPeriod
        {
            get { return _poo_period; }
            set { _poo_period = value; }
        }

        /// <summary>
        /// Gets or sets the food rate.
        /// </summary>
        /// <value>
        /// The food rate.
        /// </value>
        public double FoodRate
        {
            get { return _foodRate; }
            set { _foodRate = value; }
        }

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        public char Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        /// <summary>
        /// Gets the attractivity of animals of this species.
        /// </summary>
        public int Attractivity
        {
            get { return _attractivity; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.Species"/> class.
        /// </summary>
        /// <param name='name'>
        /// Name.
        /// </param>
        public Species(string name)
        {
            _name = name;
            _food = new List<FoodKind>();
            _preys = new List<Species>();
            _enemies = new List<Species>();
            _breedingPartners = new List<Species>();
        }
		
        /* // Serialization disabled for now
        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.Species"/> class
        /// from serialized data.
        /// </summary>
        /// <param name='info'>
        /// Info.
        /// </param>
        /// <param name='ctx'>
        /// Context.
        /// </param>
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
		
        /// <summary>
        /// Serielizes the object.
        /// </summary>
        /// <param name='info'>
        /// Info.
        /// </param>
        /// <param name='ctx'>
        /// Context.
        /// </param>
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
         */

        /// <summary>
        /// Returns whether animals of this species eat the given type of food.
        /// </summary>
        /// <param name='food'>
        /// Type of food.
        /// </param>
        public bool Eats(FoodKind food)
        {
            // The comparision by object identity is intentional!
            return _food.Exists(k => k == food);
        }

        /// <summary>
        /// Returns whether animasl of this species eat animals of the given
        /// other species.
        /// </summary>
        /// <param name='species'>
        /// An other species.
        /// </param>
        public bool Eats(Species species)
        {
            // The comparision by object identity is intentional!
            return _preys.Exists(s => s == species);
        }

        /// <summary>
        /// Returns whether animals of this species attack animals of the
        /// given other species.
        /// </summary>
        /// <param name='species'>
        /// An other species.
        /// </param>
        public bool Attacks(Species species)
        {
            // The comparision by object identity is intentional!
            return _enemies.Exists(s => Object.ReferenceEquals(s, species));
        }

        /// <summary>
        /// Returns whether animals of this species will breed with animals
        /// of the given other species.
        /// </summary>
        /// <param name='species'>
        /// An other species.
        /// </param>
        public bool BreedsWith(Species species)
        {
            // The comparision by object identity is intentional!
            return Object.ReferenceEquals(species, this) 
                || _breedingPartners.Exists(s => Object.ReferenceEquals(s, species));
        }

        /// <summary>
        /// Returns the species that results if an animal of this species breeds
        /// with an animal of the given other species.
        /// </summary>
        /// <remarks>
        /// This may create a new species. If this happens, the new species is added
        /// to <c>allSpecies</c>.
        /// </remarks>
        /// <returns>
        /// The resulting species.
        /// </returns>
        /// <param name='other'>
        /// An other species.
        /// </param>
        /// <param name='allSpecies'>
        /// All species.
        /// </param>
        /// <param name='rand'>
        /// Random number generator to be used.
        /// </param>
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
    }
}
