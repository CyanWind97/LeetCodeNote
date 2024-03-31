using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 813
    /// title: 最大平均值和的分组
    /// problems: https://leetcode.cn/problems/largest-sum-of-averages/
    /// date: 20221128
    /// </summary>
    public static class Solution813
    {
        public static double LargestSumOfAverages(int[] nums, int k) {
            int n = nums.Length;
            var prefix = new double[n + 1];
            for (int i = 0; i < n; i++) {
                prefix[i + 1] = prefix[i] + nums[i];
            }

            var dp = new double[n + 1];
            for (int i = 1; i <= n; i++) {
                dp[i] = prefix[i] / i;
            }
            
            for (int j = 2; j <= k; j++) {
                for (int i = n; i >= j; i--) {
                    for (int x = j - 1; x < i; x++) {
                        dp[i] = Math.Max(dp[i], dp[x] + (prefix[i] - prefix[x]) / (i - x));
                    }
                }
            }

            return dp[n];
        }
    }
}