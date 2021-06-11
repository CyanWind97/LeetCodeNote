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
            int[] nums = {5,0,0,0};
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
                new int[]{2,2,-1},
            };
            string[] words = {"i", "love", "leetcode", "i", "love", "coding"};
            int[] stones = new int[] {0,1,3,5,6,8,12,17};

            int[] candies = new int[]{5215,14414,67303,93431,44959,34974,22935,64205,28863,3436,45640,34940,38519,5705,14594,30510,4418,87954,8423,65872,79062,83736,47851,64523,15639,19173,88996,97578,1106,17767,63298,8620,67281,76666,50386,97303,26476,95239,21967,31606,3943,33752,29634,35981,42216,88584,2774,3839,81067,59193,225,8289,9295,9268,4762,2276,7641,3542,3415,1372,5538,878,5051,7631,1394,5372,2384,2050,6766,3616,7181,7605,3718,8498,7065,1369,1967,2781,7598,6562,7150,8132,1276,6656,1868,8584,9442,8762,6210,6963,4068,1605,2780,556,6825,4961,4041,4923,8660,4114};
            int[][] queries = new int[][]{
                new int[]{91,244597,840227137}
            };

            var result = Solution279.NumSquares(5);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
