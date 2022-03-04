using System;

namespace Demo
{
    class Program
    {
        static void Main ( string[] args )
        {
            //DemoPrimitives();
            //DemoArithmetic();

            //Strings
            var payRate = 8.65;
            var payRateString = payRate.ToString(); //if you need a string, very easy to tack on at the end when using var
            payRateString = 5.ToString();
            payRateString = (4 + 5).ToString();

            //escape sequence - character sequence that represents something that is unprintable (also are one character in the string literal)
            //     \n - newline
            //     \t - horizontal tab
            //     \\ - single slash
            //     \" - double quote
            string literal = "Hello World\nBob";
            string filePath = "C:\\windows\\system32";
            string filePath2 = @"C:\windows\system32"; //verbatim string - no escape sequences allowed (prob wont use these outside of file/registry paths)
            string literal2 = "\"Goodbye\"";

            string nullString = null; //null means no value
            string emptyString = "";  //the empty string literal is technically less characters, but is less self explanatory
            string emptyStringToo = String.Empty;
            bool areNotEqual = nullString == emptyString;
            //nullString.ToString(); - causes a crash
            //nullString. + emptyString; - will not cause a crash
            bool isEmpty = (emptyString == null || emptyString == ""); //EXAMPLE OF CHECKING EMPTY STRINGS (also logical or) //ALSO ALSO dont do this!!
            isEmpty = String.IsNullOrEmpty(emptyString); //WAY cleaner, use your functions!!!! they're useful!!!
            isEmpty = emptyString.Length == 0; //if this is null, it will crash, so consider using || statement like the earlier statement

            //case sensitive
            string lowerName = "bob", upperName = "BOB";
            bool areStringsEqual = lowerName == upperName; //false
            areStringsEqual = lowerName.ToUpper() == upperName.ToUpper(); //normalized, so statement is now true (generally better to use ToUpper than ToLower)
                                                                          //also this is expensive in terms of processing power
            areStringsEqual = String.Compare(lowerName, upperName, true) == 0;  //StringComparison.IgnoreCase
            areStringsEqual = String.Equals(lowerName, upperName, StringComparison.CurrentCultureIgnoreCase);

            //useful string functions
            lowerName =" Bob ";
            lowerName = lowerName.Trim(); //"Bob" //TrimStart, TrimEnd (self explanatory)
            bool startsWithLetter = lowerName.StartsWith("B"); //EndsWith("B");

            //Add leading spaces
            lowerName.PadLeft(20); //PadRight (adds spacing to respective side, DOES NOT ADD 20 SPACES, ONLY PADS IF STRING IS LESS THAN *20* CHARS)

            //Joining Strings (THIS WILL BE GREAT FOR DISPLAYING CHARACTER INFO ON LAB 1) actually joins anything too
            string fullName = String.Join(" ", "Bob", "Williams"); //"Bob Williams"
            string number = String.Join(",", 1, 2, 3, 4); //"1, 2, 3, 4"

            //Split a string
            var tokens = "1 | 2 | 3 | 4".Split("|");
        }

        static void DemoArithmetic ()
        {
            //Arithmetic operators
            int x = 10, y = 20, z;

            z = x + y;
            z = x - y;
            z = x * y;
            z = x / y;
            z = x % y;

            //x++ prefix increment
            //temp = x;
            //x += 1;
            // temp;
            x = 10;
            x++;

            //++x postfix increment (more common as the value doesnt matter, thus faster)
            //x += 1;
            //x;
            ++x;

            //x-- prefix decrement
            //temp = x;
            //x -= 1;
            // temp;
            x = 10;
            x--;

            //++x postfix decrement
            //x -= 1;
            //x;
            --x;
            
            //essentially, prefix returns the original value(expression value) and the new one(variable "x" value, postfix only returns the new value
            //ALWAYS increase or decrease by 1
        }

        static void DemoPrimitives ()
        {
            //Primitives
            //Integrals
            //you can put underscores in large numbers in place of commas and the compiler will basically ignore them, helps readability
            sbyte sbyteValue = 10;
            short shortValue = 20;
            int intValue = 69_420;
            long longValue = 40L;

            //Floats
            //the M is for Monetary
            float floatValue = 45.6F;
            double doubleValue = 5678.115;
            decimal payRate = 17.50M;

            bool isSuccessful = true;
            bool isFailing = false;

            char letterGrade = 'A';
            string name = "Bob";

            int hoursWorked;
            //now that this variable has been declared, you can use it in a program (though it doesnt have an assigned value)
            //always name variables DESCRIPTIVE NOUNS and camelCase them
            hoursWorked = 10;
            intValue = hoursWorked;
        }

        //public int Area { get; set; } //property

        //public int Area2              //property
        //{
        //    get { return _length * _width; }
        //}

        //public bool Validate ()       //method

        //Employee [] GetEmployee()     //method
    }
}
