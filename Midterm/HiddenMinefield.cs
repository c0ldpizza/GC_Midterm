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

        //Recursive method to reveal number of adjacent bombs
        public static void BombCount(int row, int col, string[,] minefield, string[,] visMinefield)
        {
            int adjBombs = 0;
            //starts if HiddenMinefield.minefield[x,y] != "B ";

            for (int i = -1; i < 1; i++)
            {
                for (int j = -1; j < 1; j++)
                {
                    if (row + i >= 0 && row + i <= minefield.GetLength(0)
                        && col + j >= 0 && col + j <= minefield.GetLength(1))
                    {
                        if (minefield[row + i, col + j] == "B ")
                        {
                            adjBombs++;
                        }
                    }
                }
            }
            if (adjBombs == 0)
            {
                for (int i = -1; i < 1; i++)
                {
                    for (int j = -1; j < 1; j++)
                    {
                        if (row + i >= 0 && row + i <= minefield.GetLength(0)
                            && col + j >= 0 && col + j <= minefield.GetLength(1))
                        {
                            if (visMinefield[row + i, col + j] == "# ")
                            {
                                visMinefield[row + i, col + j] = "  ";
                                BombCount(row + i, col + j, minefield, visMinefield);
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
    }
}
