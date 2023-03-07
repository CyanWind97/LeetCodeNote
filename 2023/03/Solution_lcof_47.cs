using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1659
    /// title: 礼物的最大价值
    /// problems: https://leetcode.cn/problems/li-wu-de-zui-da-jie-zhi-lcof/
    /// date: 20230308
    /// type: 剑指Offer lcof
    /// </summary>
    public static class Solution1659
    {
        public static int MaxValue(int[][] grid) {
            int m = grid.Length;
            int n = grid[0].Length;
            var dp = new int[m + 1, n + 1];

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    dp[i + 1, j + 1] = Math.Max(dp[i, j + 1], dp[i + 1, j]) + grid[i][j];
                }
            }

            return dp[m, n];
        }
    }
}