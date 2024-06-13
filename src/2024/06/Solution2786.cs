using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2786
/// title: 子序列最大优雅度
/// problems: https://leetcode.cn/problems/maximum-elegance-of-a-k-length-subsequence
/// date: 20240614
/// </summary>
public static class Solution2786
{
    public static long MaxScore(int[] nums, int x) {
        var maxOdd = 0L;
        var maxEven = 0L;
        int n = nums.Length;

        maxOdd = maxEven = nums[0];

        if (nums[0] % 2 == 1)
            maxEven -= x;
        else
            maxOdd -= x;

        for(int i = 1; i < n; i++) {
            bool isOdd = nums[i] % 2 == 1;

            if (isOdd)
                maxOdd = Math.Max(maxOdd, maxEven - x) + nums[i];
            else
                maxEven = Math.Max(maxEven, maxOdd - x) + nums[i];
        }

        return Math.Max(maxOdd, maxEven);
    }
}
