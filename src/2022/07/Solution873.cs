using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 873
    /// title: 最长的斐波那契子序列的长度
    /// problems: https://leetcode.cn/problems/length-of-longest-fibonacci-subsequence/
    /// date: 20220709
    /// </summary>
    public static class Solution873
    {
        public static int LenLongestFibSubseq(int[] arr) {
            var indices = new Dictionary<int, int>();
            int length = arr.Length;
            for (int i = 0; i < length; i++) {
                indices.Add(arr[i], i);
            }
            var dp = new int[length, length];
            int result = 0;
            for (int i = 0; i < length; i++) {
                for (int j = i - 1; j >= 0 && arr[j] * 2 > arr[i]; j--) {
                    int k = indices.ContainsKey(arr[i] - arr[j]) ? indices[arr[i] - arr[j]] : -1;
                    if (k >= 0) 
                        dp[j, i] = Math.Max(dp[k, j] + 1, 3);
                    
                    result = Math.Max(result, dp[j, i]);
                }
            }
            return result;
        }
    }
}