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
            Console.WriteLine("Please enter the size of your minefield: (x, y) ");
            Console.Write("Rows: ");
            int rows = Validation.GetNumberInRange(2, 20);

            Console.Write("Columns: ");
            int columns = Validation.GetNumberInRange(2, 20);

            Console.WriteLine("Please enter the number of bombs in your minefield: ");

            int bombs = Validation.GetValidInteger();


            do {

                HiddenMinefield minefield1 = new HiddenMinefield(rows, columns, bombs);

                HiddenMinefield.AddBombs(minefield1.Minefield, 10);

                Console.WriteLine(minefield1.Minefield);


                VisibleMinefield minefield2 = new VisibleMinefield(minefield1.Minefield);
                VisibleMinefield.PrintHiddenArray(minefield2.VisMinefield);
                //Initiate game (Print, get choice, check & update array, repeat)

                //Continue?
                //Console.WriteLine("{0}", (char)224);  printing ascii characters
                //VisibleMinefield.PrintHiddenArray();

            }while(Validation.Continue());
        }
    }
}
