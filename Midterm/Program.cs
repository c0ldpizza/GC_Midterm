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
        //  public static int totalCells = rows * columns;
        static void Main(string[] args)
        {
            do
            {
                //bool gameOver = false;

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
                    Console.WriteLine("Do you wish to flag a spot or check it? Enter F or C: ");
                    string choice = Validation.GetValidLetter();

                    if (choice.ToLower() == "f") //if user chooses to place a flag on a spot, spot will be marked "F"
                    {
                        //  FlagCell(userMinefield.VisMinefield, totalCells);
                        FlagCell(userMinefield.VisMinefield);
                    }

                    else if (choice.ToLower() == "c") //user choosing to reveal a cell
                    {
                       loseGame = RevealCell(userMinefield.VisMinefield, gameMinefield.Minefield);
                        //RevealCell(userMinefield.VisMinefield, gameMinefield.Minefield, totalCells);
                        //if (totalCells + flagCount == 0)
                        //    Console.WriteLine("You Win!");
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
            Console.WriteLine(" 3 = Hard    (10x10 Field with 24 Bombs)");
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
                bombs = 24;
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
                Console.WriteLine("BOOM! You're Dead!");
                Console.ResetColor();

                return (true);
            }

            else if (hiddenArray[xGuess, yGuess] != -1) //if x,y coordinates are not a bomb, board will display empty spots and numbered spots
            {
                array[xGuess, yGuess] = hiddenArray[xGuess, yGuess];
                //  totalCells--;
            }
                return (false);
        }
           public static void winMethod(int[,] array, int bombs)
        {
            int unrevealedCells = 0;
            //(unrevealed + flags) = bombs
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
                Console.WriteLine("You win!");
                Console.ReadLine();
            }
        }
    }
}

