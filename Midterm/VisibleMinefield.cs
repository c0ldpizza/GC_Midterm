using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class VisibleMinefield : Minefield
    {
        
        private string[,] visMinefield;

        public string[,] VisMinefield
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

        //generate array[x[y]] of ascii characters

        //call UserInput.GetCoordinates();
        //update array method

        //print array to console(display output)

        public VisibleMinefield() { }
        public VisibleMinefield(string[,] visMinefieldInput)
        {
            visMinefield = visMinefieldInput;

        }
        
        public static void PrintHiddenArray()
        {
<<<<<<< HEAD
            //HiddenMinefield testx = new HiddenMinefield();
            //HiddenMinefield testy = new HiddenMinefield();
                       
            for (int i = 0; i < testx.X; i++)
=======
            for (int i = 0; i < 20; i++)
>>>>>>> 02aeac0c1292d37a8c233ed5145b25d6dc0f4ea0
            {
                for (int j = 0; j < testx.X; j++)
                {
                    Console.Write("# ");    //# >> check cell contents of HiddenArray
                }
                
                Console.WriteLine();
            }
        }


    }
}

