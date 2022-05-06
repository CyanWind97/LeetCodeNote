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
            // TestLeetCode();
            TestCodeTop();
        }

        public static void TestLeetCode()
        {
            int[] nums = { 10, 5, 2, 6};
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

            var s = "<DIV>This is the first line <![CDATA[<div>]]></DIV>";

            var words = "!g 3 !sy ";
            var result = Solution713.NumSubarrayProductLessThanK(nums, 100);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }

        public static void TestCodeTop()
        {
            var s = "[[1,0]]";
            var k = 2;

            var arr = JsonSerializer.Deserialize<int[][]>(s);
            
            // var nodes = arr.Select(x => x.HasValue ? new CodeTop.CodeTop236.TreeNode(x.Value) : null).ToArray();

            // for(int i = 0; i < arr.Length; i++){
            //     if(2 * i + 1 < arr.Length)
            //         nodes[i].left = nodes[2 * i + 1];
                
            //     if(2 * i + 2 < arr.Length)
            //         nodes[i].right = nodes[2 * i + 2];
            // }

            var result = CodeTop.CodeTop4.FindMedianSortedArrays_1(new int[]{1, 2}, new int[]{3, 4});
        }
    }
}
