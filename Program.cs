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
            int n = 13;
            int m = 2;
            int[] group = {-1,-1,1,0,0,1,0,-1};
            int[][] edges = new int[][]{};
            string[] strs = {"tars","tars","rats","arts","star","aba"};

            var result = Solution424.CharacterReplacement("AABABBA", 1);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
