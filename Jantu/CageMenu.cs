using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
    class CageMenu
    {
        public CageMenu(int originX, int originY, int width, int height, Game game/* ,UI ui */)
        {
            _originX = originX;
            _originY = originY;
            _width = width;
            _height = height;
            _game = game;
            //_ui = ui;


        }
            
    private int _originX;
    private int _originY;
    private int _width;
    private int _height;
    private Game _game;
   // private UI _ui;
    }

   

}
