using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 583
    /// title: 两个字符串的删除操作
    /// problems: https://leetcode-cn.com/problems/delete-operation-for-two-strings/
    /// date: 20210925
    /// </summary>
    public static class Solution583
    {
        public static int MinDistance(string word1, string word2) {
            int m = word1.Length, n = word2.Length;
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++) {
                char c1 = word1[i - 1];
                for (int j = 1; j <= n; j++) {
                    char c2 = word2[j - 1];
                    if (c1 == c2) 
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else 
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
            
            return m + n - 2 * dp[m, n];
        }
    }
}