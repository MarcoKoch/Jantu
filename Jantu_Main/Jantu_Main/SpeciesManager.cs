using System;
using System.Collections.Generic;

namespace Jantu
{
    class SpeciesManager
    {
        List<Species> _normalSpecies;
        List<Species> _specialSpecies;

        public void Add(Species species)
        {
            if (!_normalSpecies.Exists(s => s == species))
                _normalSpecies.Add(species);
        }

        public void AddSpecial(Species species)
        {
            if (!_specialSpecies.Exists(s => s == species))
                _specialSpecies.Add(species);
        }

        public Species GetByName(string name)
        {
            Species species = _normalSpecies.Find(s => s.Name.Equals(name));
            if (null == species)
                species = _specialSpecies.Find(s => s.Name.Equals(name));

            return species;
        }

        public Species GetRandomSpecialSpecies(Random rand)
        {
            return _specialSpecies[rand.Next(0, _specialSpecies.Count)];
        }
    }
}
