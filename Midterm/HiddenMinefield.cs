using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class HiddenMinefield: Minefield
    {
        private string[,] minefield;

        public string[,] Minefield
        {
            get
            {
                return minefield;
            }

            set
            {
                minefield = value;
            }
        }

        public HiddenMinefield() { }

        public HiddenMinefield(int rows, int columns, int bombs)
        {
            string[,] minefield = new string[rows,columns];
            //AddBombs(int bombs){}
            //AddNumberstoMinefield(){}
        }
    }
}
