using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3251
/// title: 单调数组对的数目 II
/// problems: https://leetcode.cn/problems/find-the-count-of-monotonic-pairs-ii
/// date: 20241129
/// </summary>
public static class Solution3251
{
    public static int CountOfPairs(int[] nums) {
        int n = nums.Length;
        int m = nums.Max();
        int mod = (int)(1e9 + 7);
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++) {
            dp[i] = new int[m + 1];
        }
        for (int a = 0; a <= nums[0]; a++) {
            dp[0][a] = 1;
        }
        for (int i = 1; i < n; i++) {
            int d = Math.Max(0, nums[i] - nums[i - 1]);
            for (int j = d; j <= nums[i]; j++) {
                if (j == 0) {
                    dp[i][j] = dp[i - 1][j - d];
                } else {
                    dp[i][j] = (dp[i][j - 1] + dp[i - 1][j - d]) % mod;
                }
            }
        }
        int res = 0;
        foreach(int num in dp[n - 1]) {
            res = (res + num) % mod;
        }
        
        return res;

    }
}
