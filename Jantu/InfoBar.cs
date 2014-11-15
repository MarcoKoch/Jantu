using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
   

    class InfoBar
    { 
        private int _PosX;
        private int _PosY;
        private char _Border;
        private int  _Width;
        private int _Height;
        private char _Border2;
        private char _Border3;
        private char _Border4;
        private char _Border5;
        private char _Border6;
       
      
        public int Width { get { return _Width; }}
        public int Height { get { return _Height; } }

        public InfoBar()
        {

            _Width = 15;
            _Height = 1;
            _PosY = 0;
            _PosX = 0;
            _Border = '│';
            _Border2 = '─';
            _Border3 = '┌';
            _Border4 = '┐';
            _Border5 = '└';
            _Border6 = '┘';
           

        }



         public void Draw()
        {

            Console.SetCursorPosition(0,0);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(0,0);
            Console.Write(_Border3);
            Console.BackgroundColor = ConsoleColor.DarkYellow;




           //if  (_PosX<=_Width && _Height==0)
           //{ Console.Write(_Border2);
           //Console.BackgroundColor = ConsoleColor.DarkYellow;
           //             Console.Write(" ");
           //}


            //Console.SetCursorPosition(Console.WindowWidth - (int)_Width + 1, Console.WindowHeight / 2);
            //for (uint i = 0; _Width - 2 > i; i++)
            //    Console.Write(_Border2);

            //Console.SetCursorPosition(Console.WindowWidth - (int)_Width, Console.WindowHeight - 1);
            //Console.Write(_Border5);
            //for (uint i = 0; _Width - 2 > i; i++)
            //    Console.Write(_Border2);
            //Console.Write(_Border6);

            //for (uint y = 1; Console.WindowHeight - 1 > y; y++)
            //{
            //    Console.SetCursorPosition(Console.WindowWidth - (int)_Width, (int)y);
            //    Console.Write(_Border);

            //    Console.SetCursorPosition(Console.WindowWidth - 1, (int)y);
            //    Console.Write(_Border);
            //}
          

            }
        }
    }




          





       


