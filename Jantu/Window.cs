using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
    class Window
    {

        Vector2 _Position;
        int _Height;
        private char _Border;
        private int  _Width;
        private char _Border2;
        private char _Border3;
        private char _Border4;
        private char _Border5;
        private char _Border6;

        public int Width { get { return _Width; } }
        public int Height { get { return _Height; } }
        public Vector2 Position { get { return _Position; } }
        public Window(Vector2 position, int width, int height)
        {

            _Position = position;
            
            _Width = width;
            _Height = height;
           
            _Border = '│';
            _Border2 = '─';
            _Border3 = '┌';
            _Border4 = '┐';
            _Border5 = '└';
            _Border6 = '┘';
         

        }

        public virtual void Draw()
        {

            // Obere Horizontale

            Console.SetCursorPosition(_Position.X, _Position.Y);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write(_Border3);
            for (int i = 0; _Width - 2 > i; i++)
                Console.Write(_Border2);
            Console.Write(_Border4);

            // Untere Horizontale

            Console.SetCursorPosition(_Position.X, _Position.Y + _Height - 1);
            Console.Write(_Border5);
            for (int i = 0; _Width - 2 > i; i++)
                Console.Write(_Border2);
            Console.Write(_Border6);

            for (int y = 1; Console.WindowHeight - 1 > y; y++)
            {
                Console.SetCursorPosition(_Position.X, _Position.Y + y);
                Console.Write(_Border);

                Console.SetCursorPosition(_Position.X - 1 + _Width, _Position.Y + y);
                Console.Write(_Border);
            }
        }
    }
}
