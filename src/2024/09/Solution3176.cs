using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3176
/// title:  求出最长好子序列 I
/// problems: https://leetcode.cn/problems/find-the-maximum-length-of-a-good-subsequence-i
/// date: 20240906
/// </summary>
public static class Solution3176
{
    public static int MaximumLength(int[] nums, int k) {
        int length = nums.Length;
        var dp = new Dictionary<int, int[]>();
        var zd = new int[k + 1];

        for (int i = 0; i < length; i++){
            int num = nums[i];
            dp.TryAdd(num, new int[k + 1]);

            var tmp = dp[num];
            tmp[0]++;
            for (int j = 1; j <= k; j++){
                tmp[j] = Math.Max(++tmp[j], zd[j - 1] + 1);
            }

            zd[0] = Math.Max(zd[0], tmp[0]);
            for (int j = 1; j <= k; j++){
                zd[j] = Math.Max(Math.Max(zd[j], tmp[j]), zd[j - 1]);
            }
        }

        return zd[k];
    }
}
