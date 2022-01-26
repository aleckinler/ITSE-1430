using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
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
