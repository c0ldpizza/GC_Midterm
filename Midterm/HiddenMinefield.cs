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
        
        public static void AddBombs(string[,] minefield, int numBombs)
        {
            Random rnd = new Random();
            for (int i = 0; i < numBombs; i++)
            {
                minefield[rnd.Next(1, minefield.GetLength(0)), rnd.Next(1, minefield.GetLength(1))] = "B";
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
                    minefield[i, j] = "0";
                }
            }

            AddBombs(minefield, bombs);
            //AddNumberstoMinefield(){}
        }
    }
}
