using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2680
/// title: 最大或值
/// problems: https://leetcode.cn/problems/maximum-or
/// date: 20250321
/// </summary>
public static class Solution2680
{
    public static long MaximumOr(int[] nums, int k) {
        long orSum = 0, multiBits = 0;
        foreach (int x in nums) {
            multiBits |= x & orSum;
            orSum |= x;
        }
        long res = 0;
        foreach (int x in nums) {
            res = Math.Max(res, (orSum ^ x) | ((long)x << k) | multiBits);
        }
        return res;
    }
}
