using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
    public class Cage
    {
        public int Attractivity
        {
            get
            {
                int attract;

                for (int i = 0; i <= SpeciesList.Count; i++)
                {
                    Species AnimalX = SpeciesList[i];
                    SpeciesManager Manager = new SpeciesManager();
                    attract = AnimalX.Attractivity;
                }

                return Type.MaxAttractivity - Balance.AttractivityScale * (Type.MaxAttractivity / (Balance.AttractivityScale + (PooCount * Balance.PooAttractivityPenalty) + attract));
            }
        }

        public int PooCount;
        public int SpeciesCount;
        private CageType Type;
        private Balancing Balance;

        List<PooEntity> PooList = new List<PooEntity>();
        List<AnimalEntity> AnimalList = new List<AnimalEntity>();
        List<Species> SpeciesList = new List<Species>();

        private void addAnimal(AnimalEntity animal)
        {
            AnimalList.Add(animal);
            for(int i = 0; i <= SpeciesList.Count; i++)
            {
               Species AnimalX = SpeciesList[i];

               if (AnimalX == animal.Species)
               {
                   continue;
               }
               else if (i == SpeciesList.Count)
               {
                   SpeciesList.Add(AnimalX);
               }
            }
        }

        private void removeAnimal(AnimalEntity animal)
        {
            Species AnimalX = animal.Species;
            for(int i = 0; i <= AnimalList.Count; i++)
            {
                if (animal == AnimalList[i])
                {
                    AnimalList.RemoveAt(i);
                    break; 
                }
            }  
            for (int i = 0; i <= AnimalList.Count; i++)
            {
                if (AnimalX == SpeciesList[i])
                {
                    continue;
                }
                else if (i == AnimalList.Count)
                {
                    SpeciesList.Remove(AnimalX);
                    break;
                }
           }
        }
        public void AddPoo(PooEntity poo)
        {
            PooCount++;
            PooList.Add(poo);
        }

        public void Clean ()
        {
            for (int i = 0; i < PooList.Count; i++)
            {
                PooEntity poo = PooList[i];
                poo.Tile.Entity = null;
            }

            PooList.Clear();
        }
   }
}
