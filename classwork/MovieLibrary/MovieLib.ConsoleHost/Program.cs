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
            do
            {

                char input = DisplayMenu();

                // if (input == 'A')
                //     AddMovie();
                // else if (input == 'V')
                //     ViewMovie();
                // else if (input == 'Q')
                //     if (ConfirmQuit())
                //         break; //this unconditionally exits the loop (the do while its inside)
                switch (input) //this can be any expression or any type, provided you can create constant expressions
                {
                    //this is an example of allowed fallthrough, both a inputs do the same function
                    case 'a':
                    case 'A': AddMovie(); break;

                    case 'v':
                    case 'V': ViewMovie(); break;

                    case 'q':
                    case 'Q':
                    {
                        if (ConfirmQuit())
                            break;
                        
                        break;
                    };
                    default: Console.WriteLine("Unknown option"); break;
                };
            } while (true);
        } //this is a glorified if else if lmao

        private static void ViewMovie ()
        {
            //TODO: does movie exist
            Console.WriteLine(title);

            //releaseYear (Run Length: duration mins) rating
            //formatting 1 -string concatenation
            //Console.WriteLine(releaseYear + " (" + duration + " mins) " + rating);

            //formatting 2 - string formatting
            //Console.WriteLine("{0} ({1} mins) {2}", releaseYear, duration, rating); THIS IS IDENTICAL TO THE ONE BELOW THIS
            //string temp = String.Format("{0} ({1} mins) {2}", releaseYear, duration, rating);
            //Console.WriteLine(temp);

            //Formatting 3 (the good one) - string interpolation (THE DOLLAH SIGN IS THE KEY BABY!!) also its idiot proof, will not compile if the expressions are not valid
            Console.WriteLine($"{releaseYear} ({duration} mins) {rating}");

            //genre (Color | Black White)
            //Console.WriteLine(genre + " (" + isColor + ")");
            //if (isColor)
            //    Console.WriteLine($"{genre} (Color)");
            //else
            //    Console.WriteLine($"{genre} (Black and White");
            //Conditional operator DA METHOD
            Console.WriteLine($"{genre} ({(isColor ? "Color" : "Black and White")})"); //extra parantheses fixes the compiler error for some reason IT DEFINES THE BEGINNING AND END OF THE CONDITIONAL OPERATOR

            //Console.WriteLine(duration);
            //Console>WriteLine(isColor);
            //Console.WriteLine(rating);
            //Console.WriteLine(genre);
            Console.WriteLine(description);
        }

        static bool ConfirmQuit ()
        {
            //the definitions of true /false is later where ReadBoolean is defined, so we dont need to notate here
            return ReadBoolean("Are you sure you want to quit? (y/n)");
        }
        private static void AddMovie ()
        {
            title = ReadString("Enter a movie title: ", true);
            duration = ReadInt32("Enter duration in minutes (>=0)", 0);
            releaseYear = ReadInt32("Enter the release year", 1900);
            rating = ReadString("Enter a rating (e.g. PG, PG-13)", true);
            genre = ReadString("Enter a genre (optional)", false);
            isColor = ReadBoolean("In color? (Y/N)");
            description = ReadString("Enter a description (optional)", false);
            //dont need to declare variables here anymore since they have been declared outside the function poggers
        }

        //Unit 1 ONLY!!! this is bad practice!!
       static string title;
       static int duration;
       static int releaseYear;
       static string rating;
       static string genre;
       static bool isColor;
       static string description;

        static bool ReadBoolean ( string message )
        {
            //fix prompt DONE! Thats what the extra console.WriteLine are for on the bottom *note the curly braces since there are now multiple actions in each if statment
            Console.Write(message);

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true); //YOU GET DOUBLE INPUT DISPLAYS IF YOU DONT PUT TRUE HERE

                if (key.Key == ConsoleKey.Y)
                {
                    Console.WriteLine('Y');
                    return true;
                } else if (key.Key == ConsoleKey.N)
                {
                    Console.WriteLine('N');
                    return false;
                };
            } while (true);
        }

        private static int ReadInt32 ( string message, int minimumValue )
        {
            Console.Write(message);

            while (true) //loops until the expression we gave this is false (it's technically infinite lmao)
            {

                //Type Inferencing
                //string input = Console.ReadLine();  -  the compiler infers type based upon usage (this does not impact runtime behavior) so you can put var instead of string
                var input = Console.ReadLine();


                //Validation method:
                //int result = Int32.Parse(input); - this does not validate input

                //heres an example of an output parameter, input validation is the most common use case for them
                //int result;
                //if (Int32.TryParse(input, out result))
                //if (Int32.TryParse(input, out int result)) //this is an inline variable declaration, and does the exact same thing as the code above (this is only allowed with output parameters)
                //    if (result >= minimumValue)
                if (Int32.TryParse(input, out int result) && result >= minimumValue) //logical operators clean this up, not neccesarily more efficient
                    return result;

                Console.WriteLine("Value must be >= " + minimumValue);
            };
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
