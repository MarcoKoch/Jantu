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

                for (int i = 0; i < _speciesList.Count; i++)
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
        private CageType _type;
        private Balancing _balance;
        private bool Preview;
        private List<Tile> _surroundingTiles = new List<Tile>();
        private List<Tile> _enclosedTiles = new List<Tile>();
        private World _world;
        private Game _game;
        private Random _random;

        public int SpeciesCount
        {
            get { return _speciesList.Count; }
        }

        public List<Species> Species
        {
            get { return _speciesList; }
        }

        public int PooCount
        {
            get { return _pooList.Count; }
        }

        public int FoodCount
        {
            get { return _foodList.Count; }
        }

        public List<AnimalEntity> Animals
        {
            get { return _animalList; }
        }

        public List<FoodEntity> Food
        {
            get { return _foodList; }
        }

        public List<FoodKind> FoodKinds
        {
            get
            {
                List<FoodKind> kinds = new List<FoodKind>();
                foreach (var food in Food)
                    if (!kinds.Contains(food.Kind))
                        kinds.Add(food.Kind);
                return kinds;
            }
        }

        public List<CageWallEntity> Walls
        {
            get
            {
                return _walls;
            }
        }

        public List<Tile> EnclosedTiles
        {
            get { return _enclosedTiles; }
        }

        public List<Tile> SurroundingTiles
        {
            get { return _surroundingTiles; }
        }

        List<PooEntity> _pooList;
        List<FoodEntity> _foodList;
        List<AnimalEntity> _animalList;
        List<Species> _speciesList;
        List<CageWallEntity> _walls;
        List<VisitorEntity> _visitorList;

        private int _numCurrentPeeps;

        public void Update()
        {
            if (_numCurrentPeeps < NumPeeps)
                CreateNewVisitor();
            else if (_numCurrentPeeps > NumPeeps)
                RemoveVisitor();
        }

        private void CreateNewVisitor()
        {
            VisitorEntity newVisitor = new VisitorEntity();
            _visitorList.Add(newVisitor);

            List<Tile> freeTiles = new List<Tile>();
            foreach (Tile t in SurroundingTiles)
            {
                if (t.Entity != null)
                {
                    freeTiles.Add(t);
                }
            }

            int index = _random.Next(freeTiles.Count);
            Tile targetTile = freeTiles[index];
            targetTile.Entity = newVisitor;
         }

        private void RemoveVisitor()
        {
            if (_visitorList.Count != 0)
            {

                int index = _random.Next(_visitorList.Count);
                VisitorEntity visitor = _visitorList[index];

                _visitorList.Remove(visitor);

                visitor.Tile = null;
            }
        }

        public Cage(CageType type, Vector2 pos, Game game, Balancing balance, bool preview)
        {
            List<Vector2> wallpositions = type.WallPositions;
            _type = type;
            Preview = preview;
            _game = game;
            _balance = balance;
            _world = game.World;

            _game.Cages.Add(this);
    
            _pooList = new List<PooEntity>();
            _foodList = new List<FoodEntity>();
            _animalList = new List<AnimalEntity>();
            _speciesList = new List<Species>();
            _walls = new List<CageWallEntity>();
            _visitorList = new List<VisitorEntity>();

            for (int i = 0; i < wallpositions.Count; i++)
            {
                CageWallEntity wall = new CageWallEntity(this);
                Vector2 wallpos = pos + wallpositions[i];
                Tile tile = _world[wallpos];
                tile.Entity = wall;
                _walls.Add(wall);
            }

            RecomputeEnclosedTiles(pos);
            RecomputeSurroundingTiles(pos);

            foreach (var tile in EnclosedTiles)
                tile.Cage = this;
        }

        ~Cage()
        {
            _game.Cages.Remove(this);
        }

        public void AddAnimal(AnimalEntity animal)
        {
            _animalList.Add(animal);

            for(int i = 0; i < _speciesList.Count; i++)
            {
               Species animalX = _speciesList[i];

               if (Object.ReferenceEquals(animalX, animal.Species))
               {
                   continue;
               }
               else if (i == _speciesList.Count)
               {
                   _speciesList.Add(animalX);
               }
            }
        }

        public void RemoveAnimal(AnimalEntity animal)
        {
            Species animalX = animal.Species;
            for(int i = 0; i < _animalList.Count; i++)
            {
                if (animal == _animalList[i])
                {
                    _animalList.RemoveAt(i);
                    break; 
                }
            }

            bool speciesOrphaned = false;
            for (int i = 0; i < _speciesList.Count; i++)
            {
                if (Object.ReferenceEquals(animalX, _speciesList[i]))
                {
                    speciesOrphaned = true;
                    break;
                }
           }
            if (speciesOrphaned)
                _speciesList.Remove(animalX);
        }

        public void AddPoo(PooEntity poo)
        {
            _pooList.Add(poo);
        }

        public void RemovePoo(PooEntity poo)
        {
            _pooList.Remove(poo);
        }

        public void AddFood(FoodEntity food)
        {
            _foodList.Add(food);
        }

        public void RemoveFood(FoodEntity food)
        {
            _foodList.Remove(food);
        }

        public void Clean ()
        {
            foreach (var poo in _pooList)
                poo.Tile = null; // This calls RemovePoo() implicitly
        }

        void RecomputeSurroundingTiles(Vector2 pos)
        {
            var _surroundingVectors = _type.SurroundingTilesPositions;
            _surroundingTiles.Clear();
            for (int i = 0; i < _surroundingVectors.Count; i++)
            {
                Vector2 surroundpos = pos + _surroundingVectors[i];
                _surroundingTiles.Add(_world[surroundpos]);
            }
        }
        void RecomputeEnclosedTiles(Vector2 pos)
        {
            var _enclosedVectors = _type.EnclosedTilesPositions;
            _enclosedTiles.Clear();
            for (int i = 0; i < _enclosedVectors.Count; i++)
            {
                Vector2 closepos = pos + _enclosedVectors[i];
                _enclosedTiles.Add(_world[closepos]);
            }
        }
   }
}
