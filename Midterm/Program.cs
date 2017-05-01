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

        static void Main(string[] args)
        {
            
            int maxFlags;
            int flagCount = 0;

            do
            {
                
                //get user input for minefield size and # of bombs(pass to Minefield constructor)
                Console.WriteLine("Welcome to the Minefield! \n");

                Console.WriteLine("Choose enter your level of difficulty!\n");
                Console.WriteLine(" 1 = Easy    (3x3 Field with 4 Bombs)");
                Console.WriteLine(" 2 = Medium  (8x8 Field with 28 Bombs)");
                Console.WriteLine(" 3 = Hard    (10x10 Field with 44 Bombs)");
                Console.WriteLine(" 4 = Custom  (Customize your own minefield)\n");

                Console.Write("Difficulty: ");
                int input = Validation.GetNumberInRange(1, 4);

                //sets board size and bombs based on input
                ChooseBoard(input);

                //Sets max flags and initializes minefields
                maxFlags = bombs;

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
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Please enter the x coordinate to flag: ");

                        int xFlag = Validation.GetNumberInRange(0, rows - 1);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Please enter the y coordinate to flag: ");

                        int yFlag = Validation.GetNumberInRange(0, columns - 1);

                        Console.ResetColor();
                        if (flagCount == maxFlags)
                        {
                            Console.WriteLine("You have the reached the maximum flag limit!\nPlease remove one and try again.");
                            Console.ReadLine();
                        }
                        else if (userMinefield.VisMinefield[xFlag, yFlag] == -3)
                        {
                            flagCount++;
                            userMinefield.VisMinefield[xFlag, yFlag] = -2;
                        }
                        else if (userMinefield.VisMinefield[xFlag, yFlag] == -2)
                        {
                            flagCount--;
                            userMinefield.VisMinefield[xFlag, yFlag] = -3;
                        }
                        else
                        {
                            Console.WriteLine("You cannot flag a revealed space!");
                            Console.ReadLine();
                        }
                    }

                    else if (choice.ToLower() == "c") //user choosing to reveal a cell
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Please enter the x coordinate to reveal: ");

                        int xGuess = Validation.GetNumberInRange(0, rows - 1);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Please enter the y coordinate to reveal: ");

                        int yGuess = Validation.GetNumberInRange(0, columns - 1);

                        Console.ResetColor();

                        if (gameMinefield.Minefield[xGuess, yGuess] == -1) //if the x,y coordinates chosen by user are a hidden bomb in the hiddenarray, game over
                        {
                            Console.Clear();
                            VisibleMinefield.PrintFullArray(gameMinefield.Minefield, userMinefield.VisMinefield);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("BOOM! You're Dead!");
                            Console.ResetColor();
                            break;
                        }

                        else if (gameMinefield.Minefield[xGuess, yGuess] != -1) //if x,y coordinates are not a bomb, board will display empty spots and numbered spots
                        {
                            userMinefield.VisMinefield[xGuess, yGuess] = gameMinefield.Minefield[xGuess, yGuess];
                        }
                    }

                    //end loop
                } while (true);

            } while (Validation.Continue());
        }
        public static void ChooseBoard(int input)
        {
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
    }
}
