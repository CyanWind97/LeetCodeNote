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
            string[] words = {"ask","not","what","your","country","can","do","for","you","ask","what","you","can","do","for","your","country"};
            int[] stones = new int[] { 0, 1, 3, 5, 6, 8, 12, 17 };

            int[][] flights = new int[][]{
                new int[]{0,1,100},
                new int[]{1,2,100},
                new int[]{0,2,500},
            };

            
            var dic = new Solution211.WordDictionary();
            dic.AddWord("bad");
            dic.AddWord("dad");
            dic.AddWord("mad");

            bool flag = false;
            flag = dic.Search("pad");
            flag = dic.Search("bad");
            flag = dic.Search(".ad");
            flag = dic.Search("b..");

            var result = 0;

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
