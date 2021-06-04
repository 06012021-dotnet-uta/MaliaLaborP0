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

namespace twoDimensionArray
{
    class Result
{

    /*
     * Complete the 'hourglassSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int hourglassSum(List<List<int>> arr)
    {
        int highest = 0;
        int sum = 0;
        for(int x = 0; x < arr.Count - 2; x++)
        {
            for(int y = 0; y <arr[x].Count - 2; y++)
            {
                //add up values in hour glass shape
                sum = arr[x][y] + arr[x][y+1] + arr[x][y+2]; //first line of hourglass
                sum += arr[x+1][y+1]; //middle
                sum += arr[x+2][y] + arr[x+2][y+1] + arr[x+2][y+2]; //bottom line

                //set highest to sum if first hourglass
                if (x == 0 && y == 0) 
                    highest = sum;
                //compare sums and set highest if sum is higher
                if(sum>highest)
                    highest = sum;
            }
        }
        return highest;
    }

}
    class Solution
{
    public static void Main(string[] args)
    {
        List<List<int>> arr = new List<List<int>>();
        for (int i = 0; i < 6; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.hourglassSum(arr);

        Console.WriteLine(result);
    }
}

}
