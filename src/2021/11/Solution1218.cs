using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1218
    /// title: 最长定差子序列
    /// problems: https://leetcode-cn.com/problems/longest-arithmetic-subsequence-of-given-difference/
    /// date: 20211105
    /// </summary>
    public static class Solution1218
    {
        public static int LongestSubsequence(int[] arr, int difference) {
            int max = 0;
            var dp = new Dictionary<int, int>();
            foreach (int v in arr) {
                int prev = dp.ContainsKey(v - difference) ? dp[v - difference] : 0;
                if (dp.ContainsKey(v)) 
                    dp[v] = prev + 1;
                else
                    dp.Add(v, prev + 1);
                
                max = Math.Max(max, dp[v]);
            }
            
            return max;
        }
    }
}