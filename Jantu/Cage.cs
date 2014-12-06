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

                for (int i = 0; i <= _speciesList.Count; i++)
                {
                    Species animalX = _speciesList[i];
                    SpeciesManager Manager = new SpeciesManager();
                    attract = animalX.Attractivity;
                }

                return _type.MaxAttractivity - _balance.AttractivityScale * (_type.MaxAttractivity / (_balance.AttractivityScale + (PooCount * _balance.PooAttractivityPenalty) + attract));
            }
        }

        public int NumPeeps
        {
            get
            {
                return Attractivity / _type.MaxAttractivity * _type.SurroundingTiles.Count;

            }
        }
        public int PooCount;
        public int SpeciesCount;
        private CageType _type;
        private Balancing _balance;
        private List<Tile> _tiles;
        private bool _ispreview;
        private Game _game;

        List<PooEntity> _pooList = new List<PooEntity>();
        List<AnimalEntity> _animalList = new List<AnimalEntity>();
        List<Species> _speciesList = new List<Species>();
        List<CageWallEntity> _walls = new List<CageWallEntity>();

        private Cage(CageType type, Vector2 pos, Game game, Balancing balance, bool preview)
        {
            List<Vector2> wallpositions = Type.WallPosition;
            _type = type;
            _ispreview = preview;
            _game = game;
            _balance = balance;
            World world = game.World;

            for (int i = 0; i < wallpositions.Count; i++)
            {
                CageWallEntity wall = new CageWallEntity(this);
                Vector2 wallpos = pos + wallpositions[i];
                Tile tile = world[wallpos];
                tile.Entity = wall;
                _walls.Add(wall);
            }
        }

        private void addAnimal(AnimalEntity animal)
        {
            _animalList.Add(animal);

            for(int i = 0; i <= _speciesList.Count; i++)
            {
               Species animalX = _speciesList[i];

               if (animalX == animal.Species)
               {
                   continue;
               }
               else if (i == _speciesList.Count)
               {
                   _speciesList.Add(animalX);
               }
            }
        }

        private void removeAnimal(AnimalEntity animal)
        {
            Species animalX = animal.Species;
            for(int i = 0; i <= _animalList.Count; i++)
            {
                if (animal == _animalList[i])
                {
                    _animalList.RemoveAt(i);
                    break; 
                }
            }  
            for (int i = 0; i <= _animalList.Count; i++)
            {
                if (animalX == _speciesList[i])
                {
                    continue;
                }
                else if (i == _animalList.Count)
                {
                    _speciesList.Remove(animalX);
                    break;
                }
           }
        }
        public void AddPoo(PooEntity poo)
        {
            PooCount++;
            _pooList.Add(poo);
        }

        public void Clean ()
        {
            for (int i = 0; i < _pooList.Count; i++)
            {
                PooEntity poo = _pooList[i];
                poo.Tile.Entity = null;
            }

            _pooList.Clear();
        }
   }
}
