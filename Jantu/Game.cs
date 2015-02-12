using System;
using System.Collections.Generic;

namespace Jantu
{
    class Game
    {
        int _startCash = 1000000;
        //int _startDay = 0;
        //int _startAnimals = 0;
        //int _startVisitors = 0;

        private CageManager _cages;
        private DataManager _data;
        private Balancing _balance;
        private World _world;
        private int _cash;
        private int _day;
        private double _dayTime;

        /// <summary>
        /// A random number generator that can be used throughout the game.
        /// </summary>
        /// <remarks>
        /// This is provided in a central location, so we do not wast memory for thousands of Random objects
        /// throughout the game.
        /// </remarks>
        public readonly Random Random;

        public CageManager Cages
        {
            get { return _cages; }
        }

        public DataManager Data
        {
            get { return _data; }
        }

        public World World
        {
            get { return _world; }
        }

        public int Cash
        {
            get { return _cash; }
            set { _cash = value; }
        }

        public int Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public Cage ActiveCage;

        public int NumAnimals
        {
            get
            {
                int num = 0;
                foreach (var c in Cages.Cages)
                    num += c.Animals.Count;
                return num;
            }
        }

        public int Visitors
        {
            get
            {
                int num = 0;
                foreach (var c in Cages.Cages)
                    num += c.NumPeeps;
                return num;
            }
        }

        public Game(int worldWidth, int worldHeight, Vector2 worldOrigin, Balancing balance, DataManager data)
        {
            Random = new Random();
            _cages = new CageManager();
            _data = data;
            _balance = balance;
            _world = new World(this, worldWidth, worldHeight, worldOrigin);
            _cash = _startCash;
        }

        public void Update(double dt)
        {
            World.Update(dt);
            Cages.Update();

            _dayTime += dt;
            if (_dayTime >= _balance.DayLength)
            {
                ++_day;
                _dayTime = 0;
            }
        }
    }
}
