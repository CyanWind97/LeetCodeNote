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
            int[] nums = {5,2,2,7,3,7,9,0,2,3};
            int n = 13;
            int m = 2;
            int[] group = {-1,-1,1,0,0,1,0,-1};
            int[][] edges = new int[][]{};
            string[] strs = {"tars","tars","rats","arts","star","aba"};
            char[] chars = {'a','a','b','b','c','c','c'};
            int[] arr = {2,3,2,3,2,3};
            int[] A = {1,2,1,2,1};
            int k = 2;

            var result = Solution992.SubarraysWithKDistinct(A, k);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
