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
            int n = 8;
            int m = 2;
            int[] group = {-1,-1,1,0,0,1,0,-1};
            List<IList<int>> beforeItems = new List<IList<int>>(){
                new int[]{},
                new int[]{6},
                new int[]{5},
                new int[]{6},
                new int[]{3,6},
                new int[]{},
                new int[]{},
                new int[]{}
            };
          
            var result = Solution1203.SortItems(n, m, group, beforeItems);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
