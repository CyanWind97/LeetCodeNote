using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 516
    /// title: 最长回文子序列
    /// problems: https://leetcode-cn.com/problems/longest-palindromic-subsequence/
    /// date: 20210812
    /// </summary>
    public static class Solution516
    {
        public static int LongestPalindromeSubseq(string s) {
            int length = s.Length;
            int[,] dp = new int[length, length];
            for(int i = length - 1; i >= 0; i--){
                dp[i, i] = 1;
                char c = s[i];
                for(int j = i + 1; j < length; j++){
                    if(c == s[j])
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    else
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);

                }
            }
            
            return dp[0, length - 1];
        }
    }
}