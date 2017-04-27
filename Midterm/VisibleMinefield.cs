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
            //HiddenMinefield testx = new HiddenMinefield();
            //HiddenMinefield testy = new HiddenMinefield();
                       
            for (int i = 0; i < testx.X; i++)
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

