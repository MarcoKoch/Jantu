using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jantu
{
    [Serializable()]
    class SpeciesManager : ISerializable
    {
        public SpeciesManager()
        {
            _normalSpecies = new Dictionary<string, Species>();
            _specialSpecies = new Dictionary<string, Species>();
        }

        public SpeciesManager(SerializationInfo info, StreamingContext ctx)
        {
            List<Species> normalSpecies = (List<Species>)info.GetValue(
                "NormalSpeciesData", typeof(List<Species>));
            _normalSpecies = Enumerable.ToDictionary(normalSpecies, s => s.Name);

            List<Species> specialSpecies = (List<Species>)info.GetValue(
                "SpecialSpeciesData", typeof(List<Species>));
            _specialSpecies = Enumerable.ToDictionary(specialSpecies, s => s.Name);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            info.AddValue("NormalSpeciesData", Enumerable.ToList(_normalSpecies.Values));
            info.AddValue("SpecialSpeciesData", Enumerable.ToList(_specialSpecies.Values));
        }

        public void Add(Species species)
        {
            _normalSpecies.Add(species.Name, species);
        }

        public void AddSpecial(Species species)
        {
            _specialSpecies.Add(species.Name, species);
        }

        public Species GetByName(string name)
        {
            if (_normalSpecies.ContainsKey(name))
                return _normalSpecies[name];
            return _specialSpecies[name];
        }

        public Species GetRandomSpecialSpecies(Random rand)
        {
            List<Species> species = Enumerable.ToList(_specialSpecies.Values);
            return species[rand.Next(0, species.Count)];
        }

        Dictionary<string, Species> _normalSpecies;
        Dictionary<string, Species> _specialSpecies;
    }
}
