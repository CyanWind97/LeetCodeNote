using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 1143
    /// title: 最长公共子序列
    /// problems: https://leetcode-cn.com/problems/longest-common-subsequence/
    /// date: 20210403
    /// </summary>
    public static class Solution1143
    {
        public static int LongestCommonSubsequence(string text1, string text2) {
            int m = text1.Length;
            int n = text2.Length;
            int[,] matrix = new int[m + 1, n + 1];

            for(int i = 1; i <= m; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    if(text1[i - 1] == text2[j - 1])
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    else
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                }
            }

            return  matrix[m, n];
        }
    }
}