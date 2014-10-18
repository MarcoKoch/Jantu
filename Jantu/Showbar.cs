using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jantu
{
    class Showbar
    {
//        private uint _PosX;
//        private uint _PosY;
        private char _Border;
        private uint _Width;
        private char _Border2;
        private char _Border3;
        private char _Border4;
        private char _Border5;
        private char _Border6;
      


        public Showbar()
        {

            _Width = 20;
//            _PosX = (uint)Console.WindowWidth - _Width;
//            _PosY = 0;
            _Border = '│';
            _Border2 = '─';
            _Border3 = '┌';
            _Border4 = '┐';
            _Border5 = '└';
            _Border6 = '┘';
         

        }

        public void Draw()
        {

            Console.SetCursorPosition(Console.WindowWidth - (int)_Width, 0);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write(_Border3);
            for (uint i = 0; _Width - 2 > i; i++)
                Console.Write(_Border2);
            Console.Write(_Border4);

            Console.SetCursorPosition(Console.WindowWidth - (int)_Width + 1, Console.WindowHeight / 2);
            for (uint i = 0; _Width - 2 > i; i++)
                Console.Write(_Border2);

            Console.SetCursorPosition(Console.WindowWidth - (int)_Width, Console.WindowHeight - 1);
            Console.Write(_Border5);
            for (uint i = 0; _Width - 2 > i; i++)
                Console.Write(_Border2);
            Console.Write(_Border6);

            for (uint y = 1; Console.WindowHeight - 1 > y; y++)
            {
                Console.SetCursorPosition(Console.WindowWidth - (int)_Width, (int)y);
                Console.Write(_Border);

                Console.SetCursorPosition(Console.WindowWidth - 1, (int)y);
                Console.Write(_Border);
            }
            for (int l = 1 / 2; l < _Width - 2; l++)
            {
                for (int m = 1; m <= Console.WindowHeight / 2 - 1; m++)
                {
                    Console.SetCursorPosition(Console.WindowWidth - (int)_Width + 1 + l, (int)m);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(" ");



                }
                for (int m = Console.WindowHeight / 2 + 1; m < Console.WindowHeight - 1; m++)
                {
                    Console.SetCursorPosition(Console.WindowWidth - (int)_Width + 1 + l, (int)m);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(" ");



                }

            }
        }
    }
}


