using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace LeetCodeNote
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {3,2,6,5,0,3};
            int k = 4;
          
            var result = Solution123.MaxProfit(nums);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
