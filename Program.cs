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
            int[][] stones = new int[][]{
                new int[]{0,0},
                new int[]{0,1},
                new int[]{1,0},
                new int[]{1,2},
                new int[]{2,1},
                new int[]{2,2},
            };

            int[][] grid = new int[][]{
                new int[]{1,0,0,0},
                new int[]{1,1,0,0}
            };
            int[][] hits = new int[][]{
                new int[]{1,1},
                new int[]{1,0}
            };
          
            var result = Solution803.HitBricks(grid, hits);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
