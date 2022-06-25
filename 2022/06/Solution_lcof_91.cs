using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 091
    /// title: 粉刷房子
    /// problems: https://leetcode.cn/problems/JEj789/
    /// date: 20220625
    /// type: 剑指Offer lcof
    /// </summary>
    public class Solution_lcof_91
    {
        public static int MinCost(int[][] costs) {
            int length = costs.Length;
            var dp = new int[length + 1, 3];
            
            for(int i = 0; i < length; i++){
                dp[i + 1, 0] = Math.Min(dp[i, 1], dp[i, 2]) + costs[i][0];
                dp[i + 1, 1] = Math.Min(dp[i, 0], dp[i, 2]) + costs[i][1];
                dp[i + 1, 2] = Math.Min(dp[i, 0], dp[i, 1]) + costs[i][2];
            }

            return Math.Min(Math.Min(dp[length, 0], dp[length, 1]), dp[length, 2]);
        }
    }
}