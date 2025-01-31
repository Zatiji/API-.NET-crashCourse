using System;
using System.Runtime.InteropServices;

namespace OperatorConditionals_Loops_Methods {
    internal class Program {

        public static void operators() {
            int myInt = 5;
            int mySecondInt = 10;

            myInt++; // 5 + 1 = 6
            mySecondInt++; // 10 + 1 = 11
            myInt += 7; // 6 + 7 = 13
            myInt -= 8; // 6 - 8 = 5

            Console.WriteLine(myInt * mySecondInt); // 50
            Console.WriteLine(mySecondInt / myInt); // 2
            Console.WriteLine(myInt - mySecondInt); // -5 => goes in negatives cause int is a SIGNED VALUE
            Console.WriteLine(Math.Pow(5, 2)); //5^2 = 25
            Console.WriteLine(Math.Sqrt(25)); // 5


            // MATH OPERATORS ON STRINGS

            string myString = "test";

            myString += ". secondPart.";
            myString += " thirdPart";
            Console.WriteLine(myString); // it will show "test. secondPart. thirdPart"

            string[] myStringArr = myString.Split(". "); // ["test", "secondPart", "thirdPart"]
            Console.WriteLine(myStringArr[0]);
            Console.WriteLine(myStringArr[1]);
            Console.WriteLine(myStringArr[2]);

            // CONDITIONNALS OPERATOR

            // I got tired from writing code that I obviously know
            // ...

        
        }

        static void Main(string[] args) {
            operators();
        }
    }
}
