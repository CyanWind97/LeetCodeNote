using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3194
/// title: 最小元素和最大元素的最小平均值
/// problems: https://leetcode.cn/problems/minimum-average-of-smallest-and-largest-elements
/// date: 20241016
/// </summary>
public static class Solution3194
{
    public static double MinimumAverage(int[] nums) {
        Array.Sort(nums);
        int length = nums.Length;
        var min = double.MaxValue;
        for(int i = 0; i < length / 2; i++){
            min = Math.Min(min, (nums[i] + nums[^(i + 1)]) / 2.0);
        }

        return min;
    }
}
