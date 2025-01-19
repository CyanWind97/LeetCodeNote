using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2239
/// title: 找到最接近 0 的数字
/// problems: https://leetcode.cn/problems/find-the-maximum-sequence-value-of-array
/// date: 20250120
/// </summary>
public static class Solution2239
{
    public static int FindClosestNumber(int[] nums) {
        return nums
                .OrderBy(x => Math.Abs(x))
                .ThenByDescending(x => x)
                .First();
    }
}
