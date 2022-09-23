﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program4
{
    internal class NavigationSystem
    {

        //  Member Variables
        private char[,] map;               // the grid of the "world"

        private int numRow;                // number of rows in the map/grid
        private int numCol;                // number of columns in the map/grid

        private int islandRow;             // coordinate for islands row
        private int islandCol;             // coordinate for islands column

        private int numGuess;

        private Random rnd = new Random(); // for generating random ints


        // Default Constructor
        public NavigationSystem()
        {
            numRow = 4;         //  number of rows in the map
            numCol = 4;         //  number of columns in the map

            numGuess = 0;

            //  initialize the size of the map
            map = new char[numRow, numCol];

            // set up this map to make everything water
            MakeMap();

            // make random coordinates for the secret island
            setIslandLocation();
        }

        public NavigationSystem(int r, int c)
        {
            numRow = r;         //  number of rows in the map
            numCol = c;         //  number of columns in the map

            numGuess = 0;       // the user hasn't guessed anything yet

            //  initialize the size of the map
            map = new char[numRow, numCol];

            // set up this map to make everything water
            MakeMap();

            // make random coordinates for the secret island
            setIslandLocation();              

        }

        //  Description: 
        //      Makes the map with the number of rows and columns that
        //      the user enters and initializes all elements to 
        //      '~' (water)
        private void MakeMap()
        {
            for(int i = 0; i < numRow; i++)
            {
                for(int j = 0; j < numCol; j++)
                {
                    map[i,j] = '~';
                }
            }
        }

        // Description:
        //      Prints out the current map in a formatted way
        public void PrintMap()
        {
            Console.Write("  ");                 // 2 spaces for the formatting
            for(int i = 0; i < numRow+1; i++)
            {
                Console.Write(i);
            }
            Console.Write('\n');
            for (int i = 0; i < numRow; i++)
            {
                Console.Write($"{i} ");
                for (int j = 0; j < numCol; j++)
                {
                    Console.Write(map[i,j]);
                }
                Console.Write("\n");
            }
        }

        //  Description:
        //      Sets random coordinates for the Secret Island
        private void setIslandLocation()
        {
            islandCol = rnd.Next(numCol + 1);  // gets a random col coordinate
            islandRow = rnd.Next(numRow + 1);  // gets a random row coordinate
        }

        //  Description:
        //      returns the value of what the private variable "numGuess" is
        public int Guess
        {
            get { return numGuess; }
        }

        //  Description:
        //      Evaluates the user's guess and tells them whether they were
        //      right or wrong
        public bool EvaluateGuess(int r, int c)
        {
            numGuess++;                        // increment the number of guesses

            bool correct = false;              // if the user was right or not

            char hint = directionHint(r, c);   // get the hint

            // checks if the user guessed right
            correct = (hint == 'I') ? true : false;

            map[r, c] = hint;                  // charts the hint

            return correct;
        }

        //  Description:
        //      Gives the user a hint to go if they were wrong by changing
        //      the map, and displays an "I" for the island.
        //      this function does all the thinking to see where the island is.
        private char directionHint(int r, int c)
        {
            char hint = ' ';

            // the user guessed right
            if(r == islandRow && c == islandCol)
            {
                return 'I';
            }
            // the user has the right column
            else if(c == islandCol)
            {
                return 'C';
            }
            // the user has the right row
            else if(r == islandRow)
            {
                return 'R';
            }
            // the user was completely wrong
            else
            {
                // the number of guesses is even (returns North or South)
                if(numGuess % 2 == 0)
                {
                    hint = (r > islandRow) ? 'N' : 'S';
                }
                // the number of guesses is odd (returns East or West)
                else {
                    hint = (c > islandRow) ? 'W' : 'E';
                }
            }

            return hint;
        }
    }


}
