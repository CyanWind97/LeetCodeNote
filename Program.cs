using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace LeetCodeNote
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {-3,-6,-8,-4,-2,-8,-6,0,0,0,0};
            int[] l = {5,4,3,2,4,7,6,1,7};
            int[] r = {6,5,6,3,7,10,7,4,10};
            
            var result = Solution1630.CheckArithmeticSubarrays_1(nums, l, r);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
