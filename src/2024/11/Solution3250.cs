using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3250
/// title: 单调数组对的数目 I
/// problems: https://leetcode.cn/problems/find-the-count-of-monotonic-pairs-i
/// date: 20241128
/// </summary>
public static class Solution3250
{
    public static int CountOfPairs(int[] nums) {
        int n = nums.Length;
        int MOD = 1000000007;
        int[,] dp = new int[n, 51];

        for (int v = 0; v <= nums[0]; v++) {
            dp[0, v] = 1;
        }

        for (int i = 1; i < n; i++) {
            for (int v2 = 0; v2 <= nums[i]; v2++) {
                for (int v1 = 0; v1 <= v2; v1++) {
                    if (nums[i - 1] - v1 >= nums[i] - v2 && nums[i] - v2 >= 0) {
                        dp[i, v2] = (dp[i, v2] + dp[i - 1, v1]) % MOD;
                    }
                }
            }
        }

        int result = 0;
        for (int v = 0; v < 51; v++) {
            result = (result +  dp[n - 1, v]) % MOD;
        }

        return result;
    }
}
