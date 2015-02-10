namespace Jantu
{
    class Game
    {
        int _startCash = 1000000;
        int _startDay = 0;
        int _startAnimals = 0;
        int _startVisitors = 0;

        private DataManager _data;
        private World _world;
        private int _cash;
        private int _day;
        private int _animals;
        private int _visitors;

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

        public int Animals
        {
            get { return _animals; }
            set { _animals = value; }
        }

        public int Visitors
        {
            get { return _visitors; }
            set { _visitors = value; }
        }



        public Game(int worldWidth, int worldHeight, Vector2 worldOrigin)
        {
            _data = new DataManager();
            _world = new World(worldWidth, worldHeight, worldOrigin);
            _cash = _startCash;
        }

    }
}
