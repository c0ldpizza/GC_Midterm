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
                Console.Write($"{i} ");  //prints row#
                for (int j = 0; j < visMinefield.GetLength(1); j++)
                {
                    PrintedColor(visMinefield, i, j);
                }
                Console.WriteLine();
            }
            for (int j = 0; j < visMinefield.GetLength(1); j++)
            {
                Console.Write($"  {j}");    //prints column#
            }
            Console.WriteLine();
        }

        public static void PrintedColor(string[,] visMinefield, int i, int j)
        {
            switch (visMinefield[i, j].Remove(1))
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    break;
            }
            Console.Write(visMinefield[i, j] + " ");
            Console.ResetColor();
        }

        public static void PrintFullArray(string[,] minefield, string[,] visMinefield)
        {
            for (int i = 0; i < visMinefield.GetLength(0); i++)
            {
                for (int j = 0; j < visMinefield.GetLength(1); j++)
                {
                    visMinefield[i, j] = minefield[i, j];
                }
            }
            PrintHiddenArray(visMinefield);
        }

    }
}

