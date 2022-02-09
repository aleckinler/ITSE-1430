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

            //escape sequence - character sequence that represents something that is unprintable
            //     \n - newline
            //     \t - horizontal tab
            //     \\ - single slash
            //     \" - double quote
            string literal = "Hello World\nBob";
            string filePath = "C:\\windows\\system32";
            string filePath2 = @"C:\windows\system32"; //verbatim string - no escape sequences allowed (prob wont use these outside of file/registry paths)
            string literal2 = "\"Goodbye\"";
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
    }
}
