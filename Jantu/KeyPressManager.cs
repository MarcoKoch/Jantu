using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
    class KeyPressManager
    {

        private int mode = 0;
        private CursorManager cursorman;
        private Game _game;



        /// <summary>
        /// w and h are set by the constructor which determines how large the world is and are necessary
        /// for the Cursormanager to work properly
        /// </summary>
        public KeyPressManager(int wi, int he, Game game)
        {
            cursorman = new CursorManager(wi, he);
            _game = game;
        }


        //All Keypresses are managed here:
        //if keypress X rufe methode pressX

        public void KeyInput()
        {
            ConsoleKeyInfo entry = Console.ReadKey();

            if (ConsoleKey.S.Equals(entry))
            {
                CageRemover();
            }

            else if (ConsoleKey.L.Equals(entry))
            {
                CageRemover();
            }

            else if (ConsoleKey.G.Equals(entry))
            {
                if (mode != _game.Data.Species.BasicSpecies.Count() + 1)
                {
                    BuildCage();
                }

                else if (mode == _game.Data.Species.BasicSpecies.Count() + 1)
                {
                    BuildCageNext();
                }
            }

            else if (ConsoleKey.T.Equals(entry))
            {
                if (mode == _game.Data.Species.BasicSpecies.Count)
                {
                    mode = 1;
                    BuyAnimal();
                }

                else if (mode > 0 && mode < _game.Data.Species.BasicSpecies.Count())
                {
                    mode++;
                    BuyAnimalNext();
                }

                else if (mode == 0 || mode >= _game.Data.Species.BasicSpecies.Count())
                {
                    mode = 1;
                    BuyAnimal();
                }
            }

            else if (ConsoleKey.L.Equals(entry))
            {
                if (mode <= 100 && mode >= _game.Data.FoodKinds.FoodKinds.Count + 100)
                {
                    mode = 100;
                    BuyFood();
                }

                else if (mode >= 100 && mode <= _game.Data.FoodKinds.FoodKinds.Count + 100)
                {
                    mode++;
                    BuyFoodNext();
                }
            }

            else if (ConsoleKey.LeftArrow.Equals(entry))
            {
                Left();
            }

            else if (ConsoleKey.RightArrow.Equals(entry))
            {
                Right();
            }

            else if (ConsoleKey.UpArrow.Equals(entry))
            {
                Up();
            }

            else if (ConsoleKey.DownArrow.Equals(entry))
            {
                Down();
            }

            //Keypress management end.
        }


        //keypress methods

        public void CageRemover()
        {
            //remove the active cage
        }

        public void BuyAnimal()
        {
            //offer first animal in list
        }

        public void BuyAnimalNext()
        {
            //offer animal at place modenumber place in list
        }

        public void BuildCage()
        {
            mode = _game.Data.Species.BasicSpecies.Count + 1;
            //Offer Cage Type 1
        }

        public void BuildCageNext()
        {
            mode = 0;
            //Offer Cage Type 2
        }

        public void BuyFood()
        {
            //offer first food
        }

        public void BuyFoodNext()
        {
            //offer number food
        }

        public void Left()
        {
            cursorman.MoveLeft();
        }
        public void Right()
        {
            cursorman.MoveRight();
        }
        public void Up()
        {
            cursorman.MoveUp();
        }
        public void Down()
        {
            cursorman.MoveDown();
        }


    }
}
