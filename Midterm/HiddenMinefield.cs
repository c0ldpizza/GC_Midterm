using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class HiddenMinefield: Minefield
    {
        private string[,] minefield;
        

        public string[,] Minefield
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

        //Recursive method to reveal number of adjacent bombs, NOT WORKING
        public static void BombCount(int row, int col, string[,] minefield, string[,] visMinefield)
        {
            int adjBombs = 0;

            for (int i = row - 1; i < row + 1; i++)
            {
                for (int j = col - 1; j < col + 1; j++)
                {
                    if (i >= 0 && i <= minefield.GetLength(0)
                        && j >= 0 && j <= minefield.GetLength(1))
                    {
                        if (minefield[i,j] == "B ")
                        {
                            adjBombs++;
                        }
                    }
                }
            }
            if (adjBombs != 0)
            {
                visMinefield[row, col] = adjBombs.ToString() + " ";
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
                            if (visMinefield[i,j] == "# ")
                            {
                                visMinefield[i,j] = "  ";
                                BombCount(i, j, minefield, visMinefield);
                            }
                        }
                    }
                }
            }
            
        }

        //Add bombs to hidden array
        public static void AddBombs(string[,] minefield, int numBombs)
        {
            Random rnd = new Random();
            for (int i = 0; i < numBombs; i++)
            {
                minefield[rnd.Next(1, minefield.GetLength(0)), rnd.Next(1, minefield.GetLength(1))] = "B ";
            }
        }

        public HiddenMinefield() { }

        //Constructor
        public HiddenMinefield(int rows, int columns, int bombs)
        {
            minefield = new string[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    minefield[i, j] = "0 ";
                }
            }
            AddBombs(minefield, bombs);           
        }

        //Method that checks a single space
        public static void BombCountSimple(int row, int col, string[,] minefield, string[,] visMinefield)
        {
            int adjBombs = 0;

            for (int i = row - 1; i < row + 1; i++)
            {
                for (int j = col - 1; j < col + 1; j++)
                {
                    if (i >= 0 && i <= minefield.GetLength(0)
                        && j >= 0 && j <= minefield.GetLength(1))
                    {
                        if (minefield[i, j] == "B ")
                        {
                            adjBombs++;
                        }
                    }
                }
            }
            minefield[row, col] = adjBombs.ToString() + " ";
            visMinefield[row, col] = adjBombs.ToString() + " ";
            
        }
    }
}
