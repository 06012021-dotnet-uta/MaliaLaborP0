using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace simpleArraySum
{
    class Program
    {
        public static int simpleArraySum(List<int> ar)
        {
            int sum = 0;
            foreach (int i in ar)
            {
                sum += i;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            //get array size and values from user
            //Console.WriteLine("Enter how many numbers in array:");
            //int arCount = Convert.ToInt32(Console.ReadLine().Trim());
            //Console.WriteLine("Enter array values, seperated by a space:";
            //List<int> ar =Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();
            //OR
            //use provided array to test, result should be 31
            List<int> ar = new List<int>{1,2,3,4,10,11};
            int result = Program.simpleArraySum(ar);
            Console.WriteLine(result);
        }
    }
}
