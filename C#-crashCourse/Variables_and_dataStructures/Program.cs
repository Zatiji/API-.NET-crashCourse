using System;
using System.Runtime.InteropServices;

namespace Variables_and_dataStructures {

    internal class Program {

        public static void variable() {
            //// 1 byte is made up of 8 bits 00000000 - these bits can be used to store a number as follows
            // //// Each bit can be worth 0 or 1 of the value it is placed in
            // ////// From the right we start with a value of 1 and double for each digit to the left
            // //// 00000000 = 0
            // //// 00000001 = 1
            // //// 00000010 = 2
            // //// 00000011 = 3
            // //// 00000100 = 4
            // //// 00000101 = 5
            // //// 00000110 = 6
            // //// 00000111 = 7
            // //// 00001000 = 8
 
            // 1 byte (8 bit) unsigned, where signed means it can be negative
            byte myByte = 255;
            byte mySecondByte = 0;
 
            // 1 byte (8 bit) signed, where signed means it can be negative
            sbyte mySbyte = 127;
            sbyte mySecondSbyte = -128;
 
 
            // 2 byte (16 bit) unsigned, where signed means it can be negative
            ushort myUshort = 65535;
 
            // 2 byte (16 bit) signed, where signed means it can be negative
            short myShort = -32768;
 
            // 4 byte (32 bit) signed, where signed means it can be negative
            int myInt = 2147483647;
            int mySecondInt = -2147483648;
 
            // 8 byte (64 bit) signed, where signed means it can be negative
            long myLong = -9223372036854775808;
 
 
            // 4 byte (32 bit) floating point number
            float myFloat = 0.751f;
            float mySecondFloat = 0.75f;
 
            // 8 byte (64 bit) floating point number
            double myDouble = 0.751;
            double mySecondDouble = 0.75d;
 
            // 16 byte (128 bit) floating point number
            decimal myDecimal = 0.751m;
            decimal mySecondDecimal = 0.75m;
 
            Console.WriteLine(myFloat - mySecondFloat);
            Console.WriteLine(myDouble - mySecondDouble);
            Console.WriteLine(myDecimal - mySecondDecimal);
 
 
 
            string myString = "Hello World";
            Console.WriteLine(myString);
            string myStringWithSymbols = "!@#$@^$%%^&(&%^*__)+%^@##$!@%123589071340698ughedfaoig137";
            Console.WriteLine(myStringWithSymbols);
 
            bool myBool = true;
            Console.WriteLine(myBool);
        }

        public static void dataStructures() {
            //Creating an array of size 2 ////////////////////////////////
            string[] myGroceryArray = new string[2];
            // putting object with index
            myGroceryArray[0] = "cheese";
            myGroceryArray[1] = "Milk";
            //myGroceryArray[2] = "Yogurt"; -- CANNOT DO THAT because the array is of size 2 -> index out of bounds

            // creating an array in a simple way 
            string[] myGroceryArray_2 = ["cheese", "milk"];


            // creating a list :
            List<string> myGroceryList = new List<string>();
            // add new elemnt in a list:
            myGroceryList.Add("ice cream"); // -- put in the front of the list
            myGroceryList.Add("Crackers");
            Console.WriteLine(myGroceryList[0]);
            Console.WriteLine(myGroceryList[1]);
            
            //creating a list in a simpler way:
            List<string> myGroceryList_2 = ["Ice Cream", "Cracker"];


            // creating a Enumerable (using an interface) and using it by referencing a list
            // an enumerable cant be indexed, we need to go trough all the element to find one
            IEnumerable<string> myGroceryEnumerable = myGroceryList;
            // to turn back an enumerable to a list:
            List<string> mySecondGroceryList = myGroceryEnumerable.ToList();


            // to create a multidiemensionnal array:  -- the arrays need to be the same sizes
            int[,] myMultiDimensionnalArray = {
                {1, 2}, // 0
                {3, 4}, // 1
                {5, 6}, // 2
            };
            // to get an element in that array
            Console.WriteLine(myMultiDimensionnalArray[0,0]);
            Console.WriteLine(myMultiDimensionnalArray[2,1]);


            // to create a dictionnary -> first :key, second: value
            Dictionary<string, int> groceryPrices = new Dictionary<string, int>();
            // to add a new entry
            groceryPrices["Cheese"] = 5;
            Console.WriteLine(groceryPrices["Cheese"]);
        }
 
        static void Main(string[] args) {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("/////////////////// VARIABLES OUTPUT /////////////////////");
            variable();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("////////////////// DATA STRUCTURE OUTPUT /////////////////");
            dataStructures();
            Console.WriteLine("");
        }
    }
}
