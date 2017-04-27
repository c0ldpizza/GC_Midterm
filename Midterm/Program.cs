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

                //string[,] gameMinefield = new string[3, 3];
                //for (int i = 0; i < gameMinefield.Minefield.GetLength(0); i++)
                //{
                //    for (int j = 0; j < gameMinefield.Minefield.GetLength(1); j++)
                //    {
                //        gameMinefield.Minefield[i, j] = "0";
                //    }
                //}

                //for (int i = 0; i < 3; i++)
                //{
                //    for (int j = 0; j < 3; j++)
                //    {
                //        Console.Write(gameMinefield.Minefield[i, j]);
                //    }
                //    Console.WriteLine();
                //}

>>>>>>> d04e45280d5cfabc22c72504ef41a2a042784e1b

                HiddenMinefield.AddBombs(minefield1.Minefield, 10);

                Console.WriteLine(minefield1.Minefield);


                VisibleMinefield minefield2 = new VisibleMinefield(minefield1.Minefield);
                VisibleMinefield.PrintHiddenArray(minefield2.VisMinefield);
                //Initiate game (Print, get choice, check & update array, repeat)

                //Continue?
                //Console.WriteLine("{0}", (char)224);  printing ascii characters
                //VisibleMinefield.PrintHiddenArray();
<<<<<<< HEAD

            }while(Validation.Continue());
=======
            } while (Validation.Continue());
>>>>>>> d04e45280d5cfabc22c72504ef41a2a042784e1b
        }
    }
}
