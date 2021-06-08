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
namespace libraryFine
{
    class Result
    {

        /*
         * Complete the 'libraryFine' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER d1
         *  2. INTEGER m1
         *  3. INTEGER y1
         *  4. INTEGER d2
         *  5. INTEGER m2
         *  6. INTEGER y2
         */

        public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            //variables
            int fine = 0;
            //first set of ints is return date
            //second set is due date

            //if all equal, or returned before due date no fine
            if ((d1 == d2 && m1 == m2 && y1 == y2) || (y1 < y2 || (y1 == y2 && m1 < m2) || (y1 == y2 && m1 == m2 && d1 < d2)))
                fine = 0;
            //if month and year are equal but day is not fine = 15*day diff
            else if ((m1 == m2 && y1 == y2) && d1 > d2)
                fine = 15 * (d1 - d2);
            //if year is equal but month and day are not, 500*month diff
            else if (y1 == y2 && (d1 != d2 && m1 > m2))
                fine = 500 * (m1 - m2);
            //if return year is greater than due year
            else if (y1 > y2)
                fine = 10000;
            return fine;
        }

    }
    class Solution
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int d1 = Convert.ToInt32(firstMultipleInput[0]);

            int m1 = Convert.ToInt32(firstMultipleInput[1]);

            int y1 = Convert.ToInt32(firstMultipleInput[2]);

            string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int d2 = Convert.ToInt32(secondMultipleInput[0]);

            int m2 = Convert.ToInt32(secondMultipleInput[1]);

            int y2 = Convert.ToInt32(secondMultipleInput[2]);

            int result = Result.libraryFine(d1, m1, y1, d2, m2, y2);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
