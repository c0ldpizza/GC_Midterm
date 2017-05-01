using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class VisibleMinefield
    {

        private int[,] visMinefield;

        //property
        public int[,] VisMinefield
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

            visMinefield = new int[rows, columns];

            for (int i = 0; i < visMinefield.GetLength(0); i++)
            {
                for (int j = 0; j < visMinefield.GetLength(1); j++)
                {
                    visMinefield[i, j] = -3;
                }
            }
        }

        //Prints array for user
        public static void PrintVisibleArray(int[,] visMinefield)
        {
            Console.Clear();
            for (int i = 0; i < visMinefield.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{i} ");  //prints row#
                Console.ResetColor();
                for (int j = 0; j < visMinefield.GetLength(1); j++)
                {
                    PrintedColor(visMinefield, i, j);
                }
                Console.WriteLine();
            }
            for (int j = 0; j < visMinefield.GetLength(1); j++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"  {j}");    //prints column#
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        //Sets print color and changes certain characters
        public static void PrintedColor(int[,] visMinefield, int i, int j)
        {
            switch (visMinefield[i, j])
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case -1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case -2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    break;
            }

            if (visMinefield[i, j] == -3)
            {
                Console.Write("#  ");
            }
            else if (visMinefield[i, j] == -1)
            {
                Console.Write("X  ");
            }
            else if (visMinefield[i, j] == -2)
            {
                Console.Write("F  ");
            }
            else
            {
                Console.Write(visMinefield[i, j] + "  ");
            }

            Console.ResetColor();
        }

        //Displays all bombs when user loses the game
        public static void PrintFullArray(int[,] minefield, int[,] visMinefield)
        {
            for (int i = 0; i < visMinefield.GetLength(0); i++)
            {
                for (int j = 0; j < visMinefield.GetLength(1); j++)
                {
                    visMinefield[i, j] = minefield[i, j];
                }
            }
            PrintVisibleArray(visMinefield);
        }

        public static void RevealZeroes(int[,] visArray, int[,] hiddenArray, int xGuess, int yGuess)
        {
            //runs if hiddenArray[x,y] == 0
            for (int i = xGuess - 1; i <= xGuess + 1; i++)
            {
                if (i >= 0 && i < visArray.GetLength(0))

                    for (int j = yGuess - 1; j <= yGuess + 1; j++)
                    {
                        if (j >= 0 && j < visArray.GetLength(1))
                        {
                            if (visArray[i, j] == -3 && hiddenArray[i,j] > 0)
                            {
                                visArray[i, j] = hiddenArray[i, j];
                            }
                            else if(visArray[i,j] == -3 && hiddenArray[i, j] == 0)
                            {
                                visArray[i, j] = hiddenArray[i, j];
                                RevealZeroes(visArray, hiddenArray, i, j);
                            }
                        }
                    }
            }
        }
    }
}

