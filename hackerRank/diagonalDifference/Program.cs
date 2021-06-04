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

namespace diagonalDifference
{
    class Result
    {

        /*
         * Complete the 'diagonalDifference' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */

        public static int diagonalDifference(List<List<int>> arr)
        {
            //create variables for sums
            int sum1 = 0, sum2 = 0;

            //get first diagonal sum by adding 1 to index counters
            for (int x = 0; x < arr.Count; x++)
            {
                //y coordinate is same as x
                int y = x;
                sum1 += arr[x][y];
            }
            //get opposite diagonal sum by setting one dimmension to max and subtracting through iteration while increasing other dimmension from 0     
            for (int x = arr.Count-1, y = 0; x >=0 ; x--, y++)
            {
                sum2 += arr[x][y];
            }
            //return absolute value of difference between sums
            return Math.Abs(sum1 - sum2);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> arr = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            }

            int result = Result.diagonalDifference(arr);

            Console.WriteLine(result);
        }
    }
}
