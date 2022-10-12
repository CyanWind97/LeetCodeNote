using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using LeetCodeNote.CodeTop;

namespace LeetCodeNote
{
    class Program
    {
        static void Main(string[] args)
        {
            TestLeetCode();
            // TestCodeTop();
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
            int[] A = { 0, 1, 0 };
            int[] row = { 5, 4, 2, 6, 3, 1, 0, 7 };
            int[] customers = { 1, 0, 1, 2, 1, 1, 7, 5 };
            int[] grumpy = { 0, 1, 0, 1, 0, 1, 0, 1 };
            int X = 3;
            int k = 2;
            int[][] matrix ={
                new int[]{1,2,3},
                new int[]{4,5,6},
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

            var s = "[\"write\",\"their\",\"read\",\"quiet\",\"against\",\"down\",\"process\",\"check\"]";

            // var nodeVals = new int[]{1};
            // var nodes = nodeVals.Select(x => new Solution_lcof_29.Node(x)).ToArray();
            // for(int i = 0; i < nodes.Length; i++){
            //     nodes[i].next = nodes[(i + 1) % nodes.Length];
            // }

            // var logs = new string[] {"0:start:0","1:start:2","1:end:5","0:end:6"};

            var arr = new int[]{1,0,2,3,4};

            var result = Solution769.MaxChunksToSorted(arr);
            Console.WriteLine(result);

            Console.WriteLine("Hello World!");
        }

        public static void TestCodeTop()
        {
            var s = @"[1,2,3,null,null,4,5,null, null,7, null, null, 6,8]";
            var k = 2;

            // var arr = JsonSerializer.Deserialize<int?[]>(s);
            
            // var nodes = arr.Select(x => x.HasValue ? new CodeTop.CodeTop297.TreeNode(x.Value) : null).ToArray();
            // int nullCount = 0;

            // for(int i = 0; i < arr.Length; i++){
            //     if(nodes[i] == null){
            //         nullCount++;
            //         continue;
            //     }

            //     if(2 * i + 1 - 2 * nullCount < arr.Length)
            //         nodes[i].left = nodes[2 * i + 1  - 2 * nullCount];
                
            //     if(2 * i + 2  - 2 * nullCount < arr.Length)
            //         nodes[i].right = nodes[2 * i + 2  - 2 * nullCount];
            // }

            var arr = new int[]{1,2,3,4,5};
            var head = new CodeTop.CodeTop143.ListNode();
            var cur = head;
            for(int i = 0; i < arr.Length; i++){
                cur.next = new CodeTop.CodeTop143.ListNode(arr[i]);
                cur = cur.next;
            }
            
            //var result = 
            CodeTop.CodeTop166.FractionToDecimal(4, 333);
        }
    }
}
