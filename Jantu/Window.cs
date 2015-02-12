using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
    class Window
    {
        private ConsoleColor _bgColor = Console.BackgroundColor;
        public ConsoleColor BackgroundColor
        {
            get { return _bgColor; }
            set
            {
                _bgColor = value;
                _needClear = true;
            }
        }

        private ConsoleColor _fgColor = Console.ForegroundColor;

        public ConsoleColor ForegroundColor
        {
            get { return _fgColor; }
            set
            {
                _fgColor = value;
                _needClear = true;
            }
        }

        private ConsoleColor _borderBgColor = Console.BackgroundColor;
        public ConsoleColor BorderBgColor
        {
            get { return _borderBgColor; }
            set
            {
                _borderBgColor = value;
                _needBorderRedraw = true;
            }
        }

        private ConsoleColor _borderFgColor = Console.ForegroundColor;
        public ConsoleColor BorderFgColor
        {
            get { return _borderFgColor; }
            set
            {
                _borderFgColor = value;
                _needBorderRedraw = true;
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

        private bool _needBorderRedraw = true;
        private bool _needClear = true;

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

        public  void Draw()
        {
            if (_needBorderRedraw)
                RedrawBorder();
            if (_needClear)
                Clear();

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
            Console.BackgroundColor = BorderBgColor;
            Console.ForegroundColor = BorderFgColor;

            // Obere Horizontale

            Console.SetCursorPosition(_Position.X, _Position.Y);
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

            _needBorderRedraw = false;
        }

        private void Clear()
        {
            Console.BackgroundColor = BackgroundColor;
            for (int y = _Position.Y + 1; _Position.Y + Height - 1 > y; ++y)
            {
                Console.SetCursorPosition(_Position.X + 1, y);
                for (int i = 0; (Width - 2) > i; ++i)
                    Console.Write(" ");
            }

            _needClear = false;
        }
    }
}
