using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jantu
{
    /// <summary>
    /// Manages all species descriptions in the game.
    /// </summary>
    [Serializable()]
    class SpeciesManager : ISerializable
    {
        Dictionary<string, Species> _normalSpecies;
        Dictionary<string, Species> _specialSpecies;

        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.SpeciesManager"/> class.
        /// </summary>
        public SpeciesManager()
        {
            _normalSpecies = new Dictionary<string, Species>();
            _specialSpecies = new Dictionary<string, Species>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.SpeciesManager"/> class
        /// from serialized data.
        /// </summary>
        /// <param name='info'>
        /// Info.
        /// </param>
        /// <param name='ctx'>
        /// Context.
        /// </param>
        public SpeciesManager(SerializationInfo info, StreamingContext ctx)
        {
            List<Species> normalSpecies = (List<Species>)info.GetValue(
                "NormalSpeciesData", typeof(List<Species>));
            _normalSpecies = Enumerable.ToDictionary(normalSpecies, s => s.Name);

            List<Species> specialSpecies = (List<Species>)info.GetValue(
                "SpecialSpeciesData", typeof(List<Species>));
            _specialSpecies = Enumerable.ToDictionary(specialSpecies, s => s.Name);
        }

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name='info'>
        /// Info.
        /// </param>
        /// <param name='ctx'>
        /// Context.
        /// </param>
        public void GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            info.AddValue("NormalSpeciesData", Enumerable.ToList(_normalSpecies.Values));
            info.AddValue("SpecialSpeciesData", Enumerable.ToList(_specialSpecies.Values));
        }

        /// <summary>
        /// Add the specified species as standard species.
        /// </summary>
        /// <param name='species'>
        /// Species.
        /// </param>
        public void Add(Species species)
        {
            _normalSpecies.Add(species.Name, species);
        }

        /// <summary>
        /// Adds the specified species as special species.
        /// </summary>
        /// <remarks>
        /// Special species can only result from mutation.
        /// </remarks>
        /// <param name='species'>
        /// Species.
        /// </param>
        public void AddSpecial(Species species)
        {
            _specialSpecies.Add(species.Name, species);
        }

        /// <summary>
        /// Finds a species (either normal or special) by its name.
        /// </summary>
        /// <returns>
        /// A species with the given name if found, or <c>null</c> otherwise.
        /// </returns>
        /// <param name='name'>
        /// Name of the species.
        /// </param>
        public Species GetByName(string name)
        {
            if (_normalSpecies.ContainsKey(name))
                return _normalSpecies[name];
            return _specialSpecies[name];
        }

        /// <summary>
        /// Gets a random special species.
        /// </summary>
        /// <returns>
        /// The random special species.
        /// </returns>
        /// <param name='rand'>
        /// Random number generator to be used.
        /// </param>
        public Species GetRandomSpecialSpecies(Random rand)
        {
            List<Species> species = Enumerable.ToList(_specialSpecies.Values);
            return species[rand.Next(0, species.Count)];
        }
    }
}
