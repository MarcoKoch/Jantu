using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jantu
{
    class Game
    {
        private World _world;
        private int _cash;


        public World World
        {
            get { return _world; }
            set { _world = value; }
        }

        public int Cash
        {
            get { return _cash; }
            set { _cash = value; }
        }
    }
}
