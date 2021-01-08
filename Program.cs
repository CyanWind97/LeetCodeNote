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
            int[] nums = {1,2,3,4,5,6};
            int k = 4;
            Solution189.Rotate_1(nums, k);
            var result = 0;

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
