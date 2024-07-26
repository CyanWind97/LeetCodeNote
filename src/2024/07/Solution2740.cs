using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2740
/// title: 找出分区值
/// problems: https://leetcode.cn/problems/find-the-value-of-the-partition
/// date: 20240726
/// </summary>
public static class Solution2740
{
    public static int FindValueOfPartition(int[] nums) {
        Array.Sort(nums);

        return Enumerable.Range(0, nums.Length - 1)
                .Min(i => nums[i + 1] - nums[i]);
    }
}
