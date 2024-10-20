using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 910
/// title: 最小差值 II
/// problems: https://leetcode.cn/problems/smallest-range-ii
/// date: 20241021
/// </summary>
public static class Solution910
{
    public static int SmallestRangeII(int[] nums, int k) {
        Array.Sort(nums);
        int length = nums.Length;
        int result = nums[length - 1] - nums[0];
        for (int i = 0; i < length - 1; i++) {
            int max = Math.Max(nums[length - 1] - k, nums[i] + k);
            int min = Math.Min(nums[0] + k, nums[i + 1] - k);
            result = Math.Min(result, max - min);
        }
        
        return result;
    }
}
