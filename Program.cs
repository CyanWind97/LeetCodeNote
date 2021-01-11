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
            string s = "pwqlmqm";
            List<IList<int>> pairs = new List<IList<int>>(){
                new int[]{5,3},
                new int[]{3,0},
                new int[]{5,1},
                new int[]{1,1},
                new int[]{1,5},
                new int[]{3,0},
                new int[]{0,2}
            };
          
            var result = Solution1202.SmallestStringWithSwaps_1(s, pairs);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
