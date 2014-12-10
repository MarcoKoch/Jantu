using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
    class Cage
    {
        public int Attractivity
        {
            get
            {
                int attract = 0;

                for (int i = 0; i <= _speciesList.Count; i++)
                {
                    Species animalX = _speciesList[i];
                    SpeciesManager Manager = new SpeciesManager();
                    attract += animalX.Attractivity;
                }

                return _type.MaxAttractivity - _balance.AttractivityScale * (_type.MaxAttractivity / (_balance.AttractivityScale + (PooCount * _balance.PooAttractivityPenalty) + attract));
            }
        }

        public int NumPeeps
        {
            get
            {
                return Attractivity / _type.MaxAttractivity * _type.SurroundingTilesPositions.Count;

            }
        }
        public int PooCount;
        public int SpeciesCount = 0;
        private CageType _type;
        private Balancing _balance;
        private bool Preview;
        private List<Tile> _SurroundingTiles;
        private List<Vector2> _SurroundingVectors;
        private List<Tile> _EnclosedTiles;
        private List<Vector2> _EnclosedVectors;
        private World world;
        public List<CageWallEntity> Walls
        {
            get
            {
                return _walls;
            }
        }

        private Game _game;

        List<PooEntity> _pooList = new List<PooEntity>();
        List<AnimalEntity> _animalList = new List<AnimalEntity>();
        List<Species> _speciesList = new List<Species>();
        List<CageWallEntity> _walls = new List<CageWallEntity>();

        public Cage(CageType type, Vector2 pos, Game game, Balancing balance, bool preview)
        {
            List<Vector2> wallpositions = type.WallPositions;
            _type = type;
            Preview = preview;
            _game = game;
            _balance = balance;
            world = game.World;

            for (int i = 0; i < wallpositions.Count; i++)
            {
                CageWallEntity wall = new CageWallEntity(this);
                Vector2 wallpos = pos + wallpositions[i];
                Tile tile = world[wallpos];
                tile.Entity = wall;
                _walls.Add(wall);
            }
        }

        public void addAnimal(AnimalEntity animal)
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

        public void removeAnimal(AnimalEntity animal)
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

        public void SurroundingTiles(Vector2 pos)
        {
            for (int i = 0; i < _SurroundingTiles.Count; i++)
            {
                Vector2 surroundpos = pos + _SurroundingVectors[i];
                _SurroundingTiles.Add(world[surroundpos]);
            }
        }
        public void EnclosedTiles(Vector2 pos)
        {
            for (int i = 0; i < _EnclosedTiles.Count; i++)
            {
                Vector2 closepos = pos + _EnclosedVectors[i];
                _EnclosedTiles.Add(world[closepos]);
            }
        }
   }
}
