namespace Jantu
{
    class Game
    {
        int _startCash = 1000000;

        private DataManager _data;
        private World _world;
        private int _cash;

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

        public Game(int worldWidth, int worldHeight)
        {
            _data = new DataManager();
            _world = new World(worldWidth, worldHeight);
            _cash = _startCash;
        }
    }
}
