using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 312
/// title: 戳气球
/// problems: https://leetcode.cn/problems/burst-balloons
/// date: 20240609
/// </summary>
public static class Solution312
{
    // 参考解答
    // 动态规划
    public static int MaxCoins(int[] nums) {
        int n = nums.Length;
        var result = new int[n + 2, n + 2];
        var val = new int[n + 2];
        val[0] = val[n + 1] = 1;

        for (int i = 1; i <= n; i++) {
            val[i] = nums[i - 1];
        }

        for (int i = n - 1; i >= 0; i--) {
            for (int j = i + 2; j <= n + 1; j++) {
                for (int k = i + 1; k < j; k++) {
                    int sum = val[i] * val[k] * val[j];
                    sum += result[i, k] + result[k, j];
                    result[i, j] = Math.Max(result[i, j], sum);
                }
            }
        }

        return result[0, n + 1];
    }
}
