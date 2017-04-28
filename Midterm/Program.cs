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

                //loop
                do
                {
                    VisibleMinefield.PrintHiddenArray(userMinefield.VisMinefield);

                    //Getting user input for box selection
                    Console.WriteLine("Do you wish to flag a spot or check it? Enter F or C: ");
                    string choice = Console.ReadLine();

                    Console.WriteLine("Please enter your x coordinate: ");
                    Console.Write("xGuess:");
                    int xGuess = Validation.GetNumberInRange(0, rows);

                    Console.WriteLine("Please enter your y coordinate: ");
                    Console.Write("yGuess:");
                    int yGuess = Validation.GetNumberInRange(0, columns);

                    //if (gameMinefield.Minefield[xGuess, yGuess] != "B ")
                    //    HiddenMinefield.BombCount(xGuess, yGuess, 
                    //        gameMinefield.Minefield, userMinefield.VisMinefield);

                    
                    
                    if (choice.ToLower() == "f")
                    {
                        
                        userMinefield.VisMinefield[xGuess, yGuess] = "F ";

                    } 


                        //Check/update arrays
                        //end loop
                    } while (true);
                
                //Initiate game (Print, get choice, check & update array, repeat)



            } while(Validation.Continue());
        }
    }
}
