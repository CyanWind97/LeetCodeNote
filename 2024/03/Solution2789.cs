using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2789
/// title: 合并后数组中的最大元素
/// problems: https://leetcode.cn/problems/largest-element-in-an-array-after-merge-operations
/// date: 20240314
/// </summary>
public static class Solution2789
{
    public static long MaxArrayValue(int[] nums) {
        long sum = nums[^1];
        for (int i = 2; i <= nums.Length; i++)
        {
            sum = nums[^i] <= sum ? nums[^i] + sum : nums[^i];
        }

        return sum;
    }
}
