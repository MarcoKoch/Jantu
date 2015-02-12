using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
    class Window
    {
        private ConsoleColor _bgColor;
        public ConsoleColor BackgroundColor
        {
            get { return _bgColor; }
            set
            {
                _bgColor = value;
                RedrawBackground();
            }
        }

        private ConsoleColor _borderColor;
        public ConsoleColor BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                RedrawBorder();
            }
        }

        public ConsoleColor TextColor;

        private Vector2 _Position;
        private int _Height;
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

            RedrawBorder();
        }

        public  void Draw()
        {
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = TextColor;
            OnDraw();
        }

        protected virtual void OnDraw()
        {
            return;
        }

        private void RedrawBorder()
        {
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = BorderColor;

            // Obere Horizontale

            Console.SetCursorPosition(_Position.X, _Position.Y);
            Console.BackgroundColor = BorderColor;
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

            for (int y = 1;Height - 1 > y; y++)
            {
                Console.SetCursorPosition(_Position.X, _Position.Y + y);
                Console.Write(_Border);

                Console.SetCursorPosition(_Position.X - 1 + _Width, _Position.Y + y);
                Console.Write(_Border);
            }
        }

        private void RedrawBackground()
        {
            Console.BackgroundColor = BackgroundColor;
            for (int y = _Position.Y + 1; _Position.Y + Height - 1 > y; ++y)
            {
                Console.SetCursorPosition(_Position.X + 1, y);
                for (int i = 0; (Width - 2) > i; ++i)
                    Console.Write(" ");
            }
        }
    }
}
