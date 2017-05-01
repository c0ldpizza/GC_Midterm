using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Validation: Program
    {
        //validate user input for array size(positive integers)
        //validate which cell the user chooses(in range, or already chosen)

        public static int GetValidInteger()
        {
            int input;


            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("The input is not an integer! Please enter an integer! ");
            }

            return input;
        }



        public static int GetNumberInRange(int min, int max)
        {
            int input = GetValidInteger();
            while (input < min || input > max)
            {
                Console.WriteLine("Please enter an integer between {0} and {1}.", min, max);
                input = GetValidInteger();
            }
            return input;


        }


        public static bool Continue()
        {
            Console.WriteLine("Play Again? (y/n)");

            string input = Console.ReadLine();

            if (input.ToLower() == "n")
            {

                return false;

            }
            else if (input.ToLower() == "y")
            {
                Console.Clear();
                return true;
            }
            else
            {
                Console.WriteLine("Invalid input");
                Continue();
                return true;
            }

        }
        public static string GetValidLetter()
        {
            do
            {
                string input = Console.ReadLine();

                if ((input.ToLower() == "f") || (input.ToLower() == "c") || (input.ToLower() == "d"))
                {
                    return input;
                }
                else
                    Console.WriteLine("Invalid input. Please Enter F or C or D: ");

            } while (true);
            
        }


    }
}
