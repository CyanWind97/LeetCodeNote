using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1051
    /// title: 高度检查器
    /// problems: https://leetcode.cn/problems/height-checker/
    /// date: 20220613
    /// </summary>
    public static class Solution1051
    {
        public static int HeightChecker(int[] heights) {
            int length = heights.Length;
            var copy = new int[length];
            heights.CopyTo(copy, 0);

            Array.Sort(copy);

            return Enumerable.Range(0, length).Count(i => heights[i] != copy[i]);
        }
    }
}