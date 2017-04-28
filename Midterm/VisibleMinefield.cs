using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class VisibleMinefield : Minefield
    {
        
        private string[,] visMinefield;

        //property
        public string[,] VisMinefield
        {
            get
            {
                return visMinefield;
            }

            set
            {
                visMinefield = value;
            }
        }

        //Constructor
        public VisibleMinefield(int rows, int columns)
        {

            visMinefield = new string[rows, columns];
            //sets all values to #
            for (int i = 0; i < visMinefield.GetLength(0); i++)
            {
                for (int j = 0; j < visMinefield.GetLength(1); j++)
                {
                    visMinefield[i, j] = "# ";
                }
            }
        }

        public static void PrintHiddenArray(string[,] visMinefield)
        {
            Console.Clear();                      
            for (int i = 0; i < visMinefield.GetLength(0); i++)
            {
                for (int j = 0; j < visMinefield.GetLength(1); j++)
                {   
                    Console.Write(visMinefield[i, j] + " ");    //# >> check cell contents of HiddenArray
                }
                Console.WriteLine($"| {i}");  //prints row#
                Console.WriteLine();
            }
            for (int j = 0; j < visMinefield.GetLength(1); j++)
            {
                Console.Write($"{j}  ");    //prints column#
            }
            Console.WriteLine();
        }

    }
}

