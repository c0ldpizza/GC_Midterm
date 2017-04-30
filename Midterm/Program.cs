using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {
            //get user input for minefield size and # of bombs(pass to Minefield constructor)
            Console.WriteLine("Welcome to the Minefield! \n");

                Console.WriteLine("Choose enter your level of difficulty! \n");
                Console.Write(" 1 = Easy    (3x3 Field with 4 Bombs) \n");
                Console.Write(" 2 = Medium  (8x8 Field with 28 Bombs) \n");
                Console.Write(" 3 = Hard    (10x10 Field with 44 Bombs) \n");
                Console.Write(" 4 = Custom  (Customize your own minefield)\n");

            do
            {
                Console.WriteLine("Please enter the size of your minefield: (x, y) ");
                Console.Write("Rows: ");
                int rows = Validation.GetNumberInRange(2, 10);

                Console.Write("Columns: ");
                int columns = Validation.GetNumberInRange(2, 10);

                Console.WriteLine("Please enter the number of bombs in your minefield: ");

                int bombs = Validation.GetNumberInRange(1, rows*columns/2);

                HiddenMinefield gameMinefield = new HiddenMinefield(rows, columns, bombs);

                VisibleMinefield userMinefield = new VisibleMinefield(rows, columns);

                // Game loop
                do
                {
                    VisibleMinefield.PrintHiddenArray(userMinefield.VisMinefield); //minefield display



                    //Getting user input for box selection
                    Console.WriteLine("Do you wish to flag a spot or check it? Enter F or C: ");
                    string choice = Validation.GetValidLetter();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Please enter your x coordinate: ");
                    Console.Write("xGuess:");
                    int xGuess = Validation.GetNumberInRange(0, rows);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Please enter your y coordinate: ");
                    Console.Write("yGuess:");
                    int yGuess = Validation.GetNumberInRange(0, columns);
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (choice.ToLower() == "f") //if user chooses to place a flag on a spot, spot will be marked "F"
                    {

                        if (userMinefield.VisMinefield[xGuess, yGuess] != -2)
                            userMinefield.VisMinefield[xGuess, yGuess] = -2;
                        else
                            userMinefield.VisMinefield[xGuess, yGuess] = -3;

                    }
                    else if (choice.ToLower() == "c") //user choosing to guess
                    {
                        if (gameMinefield.Minefield[xGuess, yGuess] == -1) //if the x,y coordinates chosen by user are a hidden bomb in the hiddenarray, game over
                        {
                            Console.Clear();
                            Console.WriteLine("Boom! You're Dead!");
                            VisibleMinefield.PrintFullArray(gameMinefield.Minefield, userMinefield.VisMinefield);
                            break;
                        }

                        else if (gameMinefield.Minefield[xGuess, yGuess] != -1) //if x,y coordinates are not a bomb, board will display empty spots and numbered spots
                        {
                            userMinefield.VisMinefield[xGuess, yGuess] = gameMinefield.Minefield[xGuess, yGuess];
                        }
                    }
                    
                    //end loop
                } while (true);

            } while(Validation.Continue());
        }
    }
}
