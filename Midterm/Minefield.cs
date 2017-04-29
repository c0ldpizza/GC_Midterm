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
        private int bombs;

        #region
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

        public int Bombs
        {
            get
            {
                return bombs;
            }

            set
            {
                bombs = value;
            }
        }

        #endregion

        //default constructor
        public Minefield()
        {
            x = 10;
            y = 10;
            bombs = 13;
        }

        //Custom constructor
        public Minefield(int x, int y, int bombs)
        {
            this.x = x;
            this.y = y;
            this.bombs = bombs;
        }

        //hold private 2Darray (x,y)

        //GenerateMethod(make array[x[y]], add bombs, fill in numbers)

        //public static ____ checkcontents()
        //return value of Minefield[x,y];
    }
}
