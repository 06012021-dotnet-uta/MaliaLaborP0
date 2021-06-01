using System;

namespace myFirstHelloWorld
{
    class Program
    {
        public static int myNum1 = 5; //global variable
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //string myString = Console.ReadLine();
            //Console.WriteLine(myString.ToUpper());

            int myNum = 15;
            Console.Write("{0}\n", myNum);

            Console.WriteLine($"This is a string interpolation! the number is {myNum}");

            /*
            1. prompt user for their age
            2. prompt the user for their name
            3. print the users name and age using string interpolation
            */
            
            //ask for age
            Console.WriteLine("Enter your age:");
            //put age in int variable
            int userAge = Int32.Parse(Console.ReadLine());
            //ask for name
            Console.WriteLine("Enter your name:");
            //put name in variab;e
            string userName = Console.ReadLine();
            //output with interpolated string
            Console.WriteLine($"Your name is {userName}, and your age is {userAge}");
        }
    }
}
