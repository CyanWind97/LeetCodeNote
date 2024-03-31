using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 375
    /// title:  猜数字大小 II
    /// problems: https://leetcode-cn.com/problems/guess-number-higher-or-lower-ii/
    /// date: 20211112
    /// </summary>
    public static class Solution375
    {
        public static int GetMoneyAmount(int n) {
            int[,] f = new int[n + 1, n + 1];
            for (int i = n - 1; i >= 1; i--) {
                for (int j = i + 1; j <= n; j++) {
                    int minCost = int.MaxValue;
                    for (int k = i; k < j; k++) {
                        int cost = k + Math.Max(f[i, k - 1], f[k + 1, j]);
                        minCost = Math.Min(minCost, cost);
                    }
                    f[i, j] = minCost;
                }
            }
            return f[1, n];
        }
    }
}