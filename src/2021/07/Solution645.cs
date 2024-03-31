using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 645
    /// title: 错误的集合
    /// problems: https://leetcode-cn.com/problems/set-mismatch/
    /// date: 20210704
    /// </summary>
    public static class Solution645
    {
        public static int[] FindErrorNums(int[] nums) {
            int n = nums.Length;
            bool[] visited = new bool[n];
            int x = 0;
            int sum = 0;
            foreach (var num in nums) {
                sum += num;
                if(visited[num])
                    x = num;
                else
                    visited[num] = true;
            }

            return new int[]{x, x +  n * (n + 1) / 2 - sum };
        }
    }
}