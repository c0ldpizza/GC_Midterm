using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Minefield
    {
        private int x;
        private int y;
        private string[][] minefield;

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
        //hold private 2Darray (x,y)

        //GenerateMethod(make array[x[y]], add bombs, fill in numbers)

        //public static ____ checkcontents()
        //return value of Minefield[x][y];
    }
}
