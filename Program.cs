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
            int[] nums = { 5, 0, 0, 0 };
            int n = 13;
            int m = 2;
            int[] group = { -1, -1, 1, 0, 0, 1, 0, -1 };
            int[][] edges = new int[][] { };
            string[] strs = { "tars", "tars", "rats", "arts", "star", "aba" };
            char[] chars = { 'a', 'a', 'b', 'b', 'c', 'c', 'c' };
            int[] arr = { 2, 3, 2, 3, 2, 3 };
            int[] A = { 0, 1, 0 };
            int[] row = { 5, 4, 2, 6, 3, 1, 0, 7 };
            int[] customers = { 1, 0, 1, 2, 1, 1, 7, 5 };
            int[] grumpy = { 0, 1, 0, 1, 0, 1, 0, 1 };
            int X = 3;
            string s = "ababbc";
            int k = 2;
            int[][] matrix ={
                new int[]{2,2,-1},
            };
            
            int[] stones = new int[] { 0, 1, 3, 5, 6, 8, 12, 17 };

            int[][] flights = new int[][]{
                new int[]{0,1,100},
                new int[]{1,2,100},
                new int[]{0,2,500},
            };

            var points = new int[][]{
                new int[]{1,1},
                new int[]{2,2},
                new int[]{3,3},
                new int[]{4,4},
                new int[]{1,2},
                new int[]{2,1},
            };

            var arr1 = new int[]{2, 1, 4};
            var arr2 = new int[]{1, 0, 3};

            var node1 = new Solution1305.TreeNode(2, new Solution1305.TreeNode(1), new Solution1305.TreeNode(4));
            var node2 = new Solution1305.TreeNode(1, new Solution1305.TreeNode(0), new Solution1305.TreeNode(3));

            var words = "!g 3 !sy ";
            var result = Solution1305.GetAllElements(node1, node2);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
