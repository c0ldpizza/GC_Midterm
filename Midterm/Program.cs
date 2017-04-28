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

            do
            {
                Console.WriteLine("Please enter the size of your minefield: (x, y) ");
                Console.Write("Rows: ");
                int rows = Validation.GetNumberInRange(2, 20);

                Console.Write("Columns: ");
                int columns = Validation.GetNumberInRange(2, 20);

                Console.WriteLine("Please enter the number of bombs in your minefield: ");

                int bombs = Validation.GetValidInteger();

                HiddenMinefield gameMinefield = new HiddenMinefield(rows, columns, bombs);

                VisibleMinefield userMinefield = new VisibleMinefield(rows, columns);

                // Game loop
                do
                {
                    VisibleMinefield.PrintHiddenArray(userMinefield.VisMinefield); //minefield display



                    //Getting user input for box selection
                    Console.WriteLine("Do you wish to flag a spot or check it? Enter F or C: ");
                    string choice = Validation.GetValidLetter();

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
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

                        userMinefield.VisMinefield[xGuess, yGuess] = "F ";

                    }
                    else if (choice.ToLower() == "c") //user choosing to guess
                    {
                        if (gameMinefield.Minefield[xGuess, yGuess] == "B ") //if the x,y coordinates chosen by user are a hidden bomb in the hiddenarray, game over
                        {
                            Console.Clear();
                            Console.WriteLine("Boom! You're Dead!");
                            VisibleMinefield.PrintFullArray(gameMinefield.Minefield, userMinefield.VisMinefield);
                            break;
                        }

                        else if (gameMinefield.Minefield[xGuess, yGuess] != "B ") //if x,y coordinates are not a bomb, board will display empty spots and numbered spots
                        {
                            //HiddenMinefield.BombCount(xGuess, yGuess,
                            //      gameMinefield.Minefield, userMinefield.VisMinefield);
                            HiddenMinefield.BombCountSimple(xGuess, yGuess,
                                  gameMinefield.Minefield, userMinefield.VisMinefield);
                        }
                    }
                    
                    //end loop
                } while (true);

            } while(Validation.Continue());
        }
    }
}
