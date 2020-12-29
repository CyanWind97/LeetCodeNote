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
            int[] nums = {};
            int n = 7;
            var result = Solution330.MinPatches(nums, n);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
