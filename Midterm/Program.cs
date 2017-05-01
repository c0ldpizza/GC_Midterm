using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Program
    {
        public static int rows = 0, columns = 0, bombs = 0;
        public static int maxFlags;
        public static int flagCount = 0;
        static void Main(string[] args)
        {
            do
            {
                //get user input for minefield size and # of bombs(pass to Minefield constructor)
                //sets board size and bombs based on input
                ChooseBoard();

                //Sets max flags and initializes minefields
                maxFlags = bombs;
                bool loseGame = false;

                HiddenMinefield gameMinefield = new HiddenMinefield(rows, columns, bombs);

                VisibleMinefield userMinefield = new VisibleMinefield(rows, columns);

                // Game loop
                do
                {
                    VisibleMinefield.PrintVisibleArray(userMinefield.VisMinefield); //minefield display

                    //Getting user input for box selection
                    Console.WriteLine("Do you wish to flag a cell, check a cell, or double click a cell? Enter F or C or D: ");
                    string choice = Validation.GetValidLetter();

                    if (choice.ToLower() == "f") //if user chooses to place a flag on a spot, spot will be marked "F"
                    {
                        FlagCell(userMinefield.VisMinefield);
                    }

                    else if (choice.ToLower() == "c") //user choosing to reveal a cell
                    {
                        loseGame = RevealCell(userMinefield.VisMinefield, gameMinefield.Minefield);

                    }
                    else if (choice.ToLower() == "d") //user choosing to reveal a cell
                    {
                        DoubleClickCell(userMinefield.VisMinefield, gameMinefield.Minefield);
                    }

                        winMethod(userMinefield.VisMinefield, bombs);


                    //end loop
                } while (!loseGame);

            } while (Validation.Continue());
        }

        public static void ChooseBoard()
        {
            Console.WriteLine("Choose enter your level of difficulty!\n");
            Console.WriteLine(" 1 = Easy    (3x3 Field with 2 Bombs)");
            Console.WriteLine(" 2 = Medium  (8x8 Field with 12 Bombs)");
            Console.WriteLine(" 3 = Hard    (10x10 Field with 20 Bombs)");
            Console.WriteLine(" 4 = Custom  (Customize your own minefield)\n");

            Console.Write("Difficulty: ");
            int input = Validation.GetNumberInRange(1, 4);

            if (input == 1) //Difficulty "Easy"
            {
                rows = 3;
                columns = 3;
                bombs = 2;
            }

            else if (input == 2) //Difficulty "Medium"
            {
                rows = 8;
                columns = 8;
                bombs = 12;
            }

            else if (input == 3) //Difficulty "Hard"
            {
                rows = 10;
                columns = 10;
                bombs = 20;
            }

            else if (input == 4) //Get input for custom minefield size
            {
                Console.WriteLine("Please enter the size of your minefield: (x, y) ");
                Console.Write("Rows: ");
                rows = Validation.GetNumberInRange(2, 10);

                Console.Write("Columns: ");
                columns = Validation.GetNumberInRange(2, 10);

                Console.WriteLine("Please enter the number of bombs in your minefield: ");

                bombs = Validation.GetNumberInRange(1, rows * columns / 2);
            }
        }
 
        public static void FlagCell(int[,] array)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please enter the x coordinate to flag: ");

            int xFlag = Validation.GetNumberInRange(0, rows - 1);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Please enter the y coordinate to flag: ");

            int yFlag = Validation.GetNumberInRange(0, columns - 1);

            Console.ResetColor();
            if (array[xFlag, yFlag] == -2)
            {
                flagCount--;
                array[xFlag, yFlag] = -3;
            }
            else if (flagCount == maxFlags)
            {
                Console.WriteLine("You have the reached the maximum flag limit!\nPlease remove one and try again.");
                Console.ReadLine();
            }
            else if (array[xFlag, yFlag] == -3)
            {
                flagCount++;
               
                array[xFlag, yFlag] = -2;
            }
            else
            {
                Console.WriteLine("You cannot flag a revealed space!");
                Console.ReadLine();
            }
        }

        public static bool RevealCell(int[,] array, int[,] hiddenArray)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please enter the x coordinate to reveal: ");

            int xGuess = Validation.GetNumberInRange(0, rows - 1);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Please enter the y coordinate to reveal: ");

            int yGuess = Validation.GetNumberInRange(0, columns - 1);

            Console.ResetColor();

            if (hiddenArray[xGuess, yGuess] == -1) //if the x,y coordinates chosen by user are a hidden bomb in the hiddenarray, game over
            {
                Console.Clear();
                VisibleMinefield.PrintFullArray(hiddenArray, array);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("BOOM!\nYOU\nBLEW\nUP\nEARTH!");
                Console.ResetColor();

                return (true);
            }

            else if (hiddenArray[xGuess, yGuess] != -1) //if x,y coordinates are not a bomb, board will display empty spots and numbered spots
            {
                if (hiddenArray[xGuess, yGuess] != 0)
                {
                    array[xGuess, yGuess] = hiddenArray[xGuess, yGuess];
                }
                else
                {
                    array[xGuess, yGuess] = hiddenArray[xGuess, yGuess];
                    VisibleMinefield.RevealZeroes(array, hiddenArray, xGuess, yGuess);
                }
   
            }
                return (false);
        }

        public static void DoubleClickCell(int[,] array, int[,] hiddenArray)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please enter the x coordinate to double click: ");

            int xGuess = Validation.GetNumberInRange(0, rows - 1);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Please enter the y coordinate to double click: ");

            int yGuess = Validation.GetNumberInRange(0, columns - 1);

            Console.ResetColor();

            int adjFlags = 0;

            for (int i = xGuess - 1; i <= xGuess + 1; i++)
            {
                if (i >= 0 && i < array.GetLength(0))

                    for (int j = yGuess - 1; j <= yGuess + 1; j++)
                    {
                        if (j >= 0 && j < array.GetLength(1))
                        {
                            if(array[i, j] == -2)
                            {
                                adjFlags++;
                            }
                        }
                    }
            }

            if (array[xGuess, yGuess] == adjFlags)
            {
                for (int i = xGuess - 1; i <= xGuess + 1; i++)
                {
                    if (i >= 0 && i < array.GetLength(0))

                        for (int j = yGuess - 1; j <= yGuess + 1; j++)
                        {
                            if (j >= 0 && j < array.GetLength(1))
                            {
                                if (array[i, j] == -3)
                                {
                                    array[i, j] = hiddenArray[i, j];
                                }
                            }
                        }
                }
            }
        }

        public static void winMethod(int[,] array, int bombs)
        {
            int unrevealedCells = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {

                    if (array[i, j] == -3)
                        unrevealedCells++;
                } 
            }
            if(unrevealedCells +flagCount == bombs)
            {
               
                WinGame.Run();
                
            }
        }
    }
}

