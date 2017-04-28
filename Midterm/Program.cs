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

                VisibleMinefield minefield2 = new VisibleMinefield(rows, columns);
                VisibleMinefield.PrintHiddenArray(minefield2.VisMinefield);

                //Getting user input for box selection
                Console.WriteLine("Please enter your x coordinate: ");
                Console.WriteLine("xGuess");
                int xGuess = Validation.GetNumberInRange(0, rows);

                Console.WriteLine("Please enter your y coordinate: ");
                Console.WriteLine("yGuess");
                int yGuess = Validation.GetNumberInRange(0, columns);


                //Initiate game (Print, get choice, check & update array, repeat)

                //Continue?
                //Console.WriteLine("{0}", (char)224);  printing ascii characters
                //VisibleMinefield.PrintHiddenArray();


            } while(Validation.Continue());
        }
    }
}
