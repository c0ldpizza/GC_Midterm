﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class HiddenMinefield: Minefield
    {
        private int[,] minefield;
        
        public int[,] Minefield
        {
            get
            {
                return minefield;
            }

            set
            {
                minefield = value;
            }
        }

        //default constructor
        public HiddenMinefield() { }

        //Constructor
        public HiddenMinefield(int rows, int columns, int bombs)
        {
            minefield = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    minefield[i, j] = -3;
                }
            }
            AddBombs(minefield, bombs);           
        }

        //Add bombs to hidden array, makes sure two bombs aren't place on same space
        public static void AddBombs(int[,] minefield, int numBombs)
        {
            Random rnd = new Random();
            for (int i = 0; i < numBombs; i++)
            {
                int r = rnd.Next(1, minefield.GetLength(0));
                int c = rnd.Next(1, minefield.GetLength(1));

                if (minefield[r, c] == 0)
                {
                    minefield[r, c] = -1;
                }
                else if (minefield[r, c] == -1)
                {
                    i--;
                }
            }
        }

        //Method that checks a single space. Also not working
        public static void BombCountSimple(int row, int col, int[,] minefield, int[,] visMinefield)
        {
            int adjBombs = 0;

            for (int i = row - 1; i < row + 1; i++)
            {
                for (int j = col - 1; j < col + 1; j++)
                {
                    if (i >= 0 && i <= minefield.GetLength(0)
                        && j >= 0 && j <= minefield.GetLength(1))
                    {
                        if (i != row || j != col)
                        {
                            if (minefield[i, j] == -1)
                            {
                                adjBombs++;
                            }
                        }
                    }
                }
            }
            minefield[row, col] = adjBombs;
            visMinefield[row, col] = adjBombs;
            
        }

        //Recursive method to reveal number of adjacent bombs, NOT WORKING
        public static void BombCount(int row, int col, int[,] minefield, int[,] visMinefield)
        {
            int adjBombs = 0;

            for (int i = row - 1; i < row + 1; i++)
            {
                for (int j = col - 1; j < col + 1; j++)
                {
                    if (i >= 0 && i <= minefield.GetLength(0)
                        && j >= 0 && j <= minefield.GetLength(1))
                    {
                        if (minefield[i, j] == -1)
                        {
                            adjBombs++;
                        }
                    }
                }
            }
            if (adjBombs != 0)
            {
                visMinefield[row, col] = adjBombs;
            }
            else if (adjBombs == 0)
            {
                for (int i = row - 1; i < col + 1; i++)
                {
                    for (int j = col - 1; j < col + 1; j++)
                    {
                        if (i >= 0 && i < minefield.GetLength(0)
                            && j >= 0 && j < minefield.GetLength(1))
                        {
                            if (visMinefield[i, j] == 0)     //fix
                            {
                                visMinefield[i, j] = 0;
                                BombCount(i, j, minefield, visMinefield);
                            }
                        }
                    }
                }
            }
        }
    }
}
