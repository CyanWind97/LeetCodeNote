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
            int[] nums = {9,8,7,6,5,4,3,2,1};
            int k = 3;
            var result = Solution239.MaxSlidingWindow_1(nums, k);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
