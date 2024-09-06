using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3177
/// title:  求出最长好子序列 II
/// problems: https://leetcode.cn/problems/find-the-maximum-length-of-a-good-subsequence-ii
/// date: 20240907
/// </summary>
public static class Solution3177
{
    public static int MaximumLength(int[] nums, int k) {
        int len = nums.Length;
        var dp = new Dictionary<int, int[]>();
        int[] zd = new int[k + 1];

        for (int i = 0; i < len; i++) {
            int v = nums[i];
            dp.TryAdd(v, new int[k + 1]);

            int[] tmp = dp[v];
            for (int j = 0; j <= k; j++) {
                tmp[j] = tmp[j] + 1;
                if (j > 0) {
                    tmp[j] = Math.Max(tmp[j], zd[j - 1] + 1);
                }
            }
            for (int j = 0; j <= k; j++) {
                zd[j] = Math.Max(zd[j], tmp[j]);
            }
        }
        
        return zd[k];
    }
}
