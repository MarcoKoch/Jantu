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
        private Game _game;
       
       
      
        public int Width { get { return _Width; }}
        public int Height { get { return _Height; } }

        public InfoBar(Game game, int width, int height)
        {

            _Width = width;
            _Height = height;
            _PosY = 0;
            _PosX = 0;
            _Border = '│';
            _Border2 = '─';
            _Border3 = '┌';
            _Border4 = '┐';
            _Border5 = '└';
            _Border6 = '┘';
            _game = game;
           

        }



         public void Draw()
        {

            Console.SetCursorPosition(_PosX,_PosY);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(_Border3);
            for (uint i = 0; _Width  > i; i++)
                Console.Write(_Border2);
            Console.Write(_Border4);



            Console.SetCursorPosition(_PosX, _Height-1);
            for (uint i = 0; _Width > i; i++)
                Console.Write(_Border2);

         Console.SetCursorPosition(_PosX,_Height-1);
            Console.Write(_Border5);
           for (uint i = 0; _Width > i; i++)
               Console.Write(_Border2);
            Console.Write(_Border6);

            for (uint y = 0; _Height > y; y++)
            {
                Console.SetCursorPosition(_Width+1,1);
                Console.Write(_Border);

                Console.SetCursorPosition(0 , 1);
                Console.Write(_Border);
            }

            
                
                    Console.SetCursorPosition(1,1);
                    for (int x = 1; x < _Width+1; x++)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(" ");
                    }
                    Console.BackgroundColor = ConsoleColor.DarkGreen;


                    
                    Console.SetCursorPosition(44,1);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;             
                    Console.Write("Cash:"+_game.Cash);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                   
             
                    Console.SetCursorPosition(33, 1);
                   Console.ForegroundColor = ConsoleColor.Black;
                  Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write("Day:" + _game.Day);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;

             Console.SetCursorPosition(17, 1);
            Console.ForegroundColor = ConsoleColor.Black;
              Console.BackgroundColor = ConsoleColor.Gray;
              Console.Write("Visitors:" + _game.Visitors);
             Console.BackgroundColor = ConsoleColor.DarkGreen;

             Console.SetCursorPosition(2, 1);
              Console.ForegroundColor = ConsoleColor.Black;
               Console.BackgroundColor = ConsoleColor.Gray;
              Console.Write("Animals:" + _game.Animals);
             Console.BackgroundColor = ConsoleColor.DarkGreen;


            
       
             


        }
            }
              }
    


    





          





       


