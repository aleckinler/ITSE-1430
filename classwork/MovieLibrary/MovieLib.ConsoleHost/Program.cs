/* FILE HEADER EXAMPLE
 * Your Name
 * ITSE 1430
 * EXAMPLE LAB
 */
using System;

namespace MovieLib.ConsoleHost
{
    class Program
    {
        //Entry point
        static void Main ( string[] args )
        {
            //Block style declaration - all declared at the top of the function
            //On demand/inline declaration - cariables are declared as needed
            char input = DisplayMenu();

            //TODO: Handle input
            if (input == 'A')
                AddMovie();
        }

        private static void AddMovie ()
        {
            string title = ReadString("Enter a movie title: ", true);
            int duration = ReadInt32("Enter duration in minutes (>=0)", 0);
            int releaseYear = ReadInt32("Enter the release year", 1900);
            string rating = ReadString("Enter a rating (e.g. PG, PG-13)", true);
            string genre = ReadString("Enter a genre (optional)", false);
            bool isColor = ReadBoolean("In color? (Y/N)");
            string description = ReadString("Enter a description (optional)", false);

        }

        static bool ReadBoolean ( string message )
        {
            //TODO: fix prompt
            Console.Write(message);

            ConsoleKeyInfo key = Console.ReadKey();

            //TODO: Validate
            if (key.Key == ConsoleKey.Y)
                return true;
            else if (key.Key == ConsoleKey.N)
                return false;

            return false;
        }

        private static int ReadInt32 ( string message, int minimumValue )
        {
            Console.Write(message);

            string input = Console.ReadLine();

            //TODO: Validate
            //int result = Int32.Parse(input); - this does not validate input
           
            //heres an example of an output parameter, input validation is the most common use case for them
            //int result;
            //if (Int32.TryParse(input, out result))
            int result;
            if (Int32.TryParse(input, out int result)) //this is an inline variable declaration, and does the exact same thing as the code above (this is only allowed with output parameters)
            if (result >= minimumValue)
                return result;
            //the negative 1 is arbitrary
            return -1;
        }

        //Functions naming rules
        // Functions are always verbs
        //Functions are always pascal cased
        //Functions should do a single, logical thing

        private static string ReadString ( string message, bool required )
        {
            Console.WriteLine(message);

            string input = Console.ReadLine();

            //TODO: validate input, if its required

            return input;
        }

        static char DisplayMenu ()
        //NOT VOID since we want return to function
        {
            //the letter) determines input
            Console.WriteLine("A)dd Movie");
            Console.WriteLine("V)iew Movie");
            Console.WriteLine("E)dit Movie");
            Console.WriteLine("D)elete Movie");
            Console.WriteLine("Q)uit");

            //this is an example of inline declaration (less likely to need to assign the variable a dummy value early on)
            string input = Console.ReadLine();

            //INPUT VALIDATION
            //this is inefficient, use IF ELSE statement
            if (input == "A")
                return 'A';
            else if (input == "V")
                return 'V';
            else if (input == "E")
                return 'E';
            else if (input == "D")
                return 'D';
            else if (input == "Q")
                return 'Q';
            else
            {
                //using curlys since there is more than one statement tied to the else function
                Console.WriteLine("Invalid Input");
                return 'X';
            }; //this semicolon is just here for good practice, all statements in C# end with a semicolon
        }
    }
}
