using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
    public class Cage
    {
        public int Attractivity;
        public int PooCount;
        public int SpeciesCount;

        List<AnimalEntity> AnimalList = new List<AnimalEntity>();
        List<string> SpeciesList = new List<string>();

        private void addanimal(AnimalEntity animal)
        {
            AnimalList.Add(animal);
            for(int i = 0; i <= SpeciesList.Count; i++)
            {
               string AnimalX = SpeciesList[i];

               if (AnimalX.Equals(animal.Species + ""))
               {
                   continue;
               }
               else if (i == SpeciesList.Count)
               {
                   SpeciesList.Add(AnimalX);
               }
            }
        }

        private void removeanimal(AnimalEntity animal)
        {
            string AnimalX = (animal.Species + "");
            for(int i = 0; i <= AnimalList.Count; i++)
            {
                if (animal == AnimalList[i])
                {
                    AnimalList.RemoveAt(i);
                    continue;
                }
            
            for (i = 0; i <= AnimalList.Count; i++)
            {
                if (AnimalX.Equals(AnimalList[i].Species + ""))
                {
                    continue;
                }
                else if (i == AnimalList.Count)
                {
                    SpeciesList.Remove(AnimalX);
                }
            }
           }
        }
        public void AddPoo()
        {
            PooCount++;
        }
        public void CalculateAttractivity(int amax, int ppoo, int k)
        {
            int attract;
            for (int i = 0; i <= SpeciesList.Count; i++)
            {
                string AnimalX = SpeciesList[i];
                SpeciesManager Manager = new SpeciesManager();
                Species P = Manager.GetByName(AnimalX);
                attract = P.Attractivity();
            }
            Attractivity = amax - k * (amax / (k + (PooCount * ppoo) + attract));
        }
   }
}
