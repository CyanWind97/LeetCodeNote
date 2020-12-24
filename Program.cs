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
            int[] arr = {1, 3, 2, };
            var result = Solution135.Candy(arr);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
