﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jantu
{
    class CageMenu : Window
    {

        Game _Game; 
        public CageMenu (Vector2 position, int width, int height, Game game) : 
            base (position, width, height)
        {
            BackgroundColor = ConsoleColor.DarkCyan;
            ForegroundColor = ConsoleColor.Gray;
            _Game = game;
        }

        protected override void OnDraw()
        {
            Clear();

            Console.SetCursorPosition(Position.X + 1, Position.Y + 1);
            Console.Write("**** Gehege ****");
            if (_Game.Cages.SelectedCage != null)
            {
                Console.SetCursorPosition(Position.X + 1, Position.Y + 3);
                Console.Write("Besucher \t" + _Game.Cages.SelectedCage.NumPeeps);

                Console.SetCursorPosition(Position.X + 1, Position.Y + 4);
                Console.Write("Kothaufen \t" + _Game.Cages.SelectedCage.PooCount);

                Console.SetCursorPosition(Position.X + 1, Position.Y + 6);
                Console.Write("Tiere \t");


                int y = Position.Y + 7;

                foreach (Species species in _Game.Cages.SelectedCage.Species)
                {

                    Console.SetCursorPosition(Position.X + 3, y);
                    Console.Write("    " + species.Name + " \t " + CountAnimals(species));
                    y++;

                }

                y += 1;

                Console.SetCursorPosition(Position.X + 1, y++);
                Console.Write("Nahrung \t");

                foreach (FoodKind food in _Game.Cages.SelectedCage.FoodKinds)
                {

                    Console.SetCursorPosition(Position.X + 3, y);
                    Console.Write("    " + food.Name + " \t " + CountFood(food));
                    y++;

                }
            }
        }

        private int CountAnimals(Species species)
        {
            int num = 0;
            foreach (var animal in _Game.Cages.SelectedCage.Animals)
                if (animal.Species == species)
                    ++num;
            return num;
        }

        private int CountFood(FoodKind kind)
        {
            int num = 0;
            foreach (var food in _Game.Cages.SelectedCage.Food)
                if (food.Kind == kind)
                    ++num;
            return num;
        }
    }
}


