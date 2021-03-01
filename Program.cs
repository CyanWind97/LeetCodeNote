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
            int[] nums = {1,1,0,1,1,1};
            int n = 13;
            int m = 2;
            int[] group = {-1,-1,1,0,0,1,0,-1};
            int[][] edges = new int[][]{};
            string[] strs = {"tars","tars","rats","arts","star","aba"};
            char[] chars = {'a','a','b','b','c','c','c'};
            int[] arr = {2,3,2,3,2,3};
            int[] A = {0,1,0};
            int[] row = {5,4,2,6,3,1,0,7};
            int[] customers = {1,0,1,2,1,1,7,5};
            int[] grumpy = {0,1,0,1,0,1,0,1};
            int X = 3;
            string s = "ababbc";
            int k = 2;
            int[][] matrix ={
                new int[]{3, 0, 1, 4, 2},
                new int[]{5, 6, 3, 2, 1},
                new int[]{1, 2, 0, 1, 5},
                new int[]{4, 1, 0, 1, 7},
                new int[]{1, 0, 3, 0, 5}
            };

            var test = new Solution304.NumMatrix(matrix);

            var result = test.SumRegion(1, 1, 2, 2 );

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
