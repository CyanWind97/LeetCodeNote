using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3396
/// title: 使数组元素互不相同所需的最少操作次数
/// problems: https://leetcode.cn/problems/minimum-number-of-operations-to-make-elements-in-array-distinct
/// date: 20250408
/// </summary>
public static class Solution3396
{
    public static int MinimumOperations(int[] nums) {
        int length = nums.Length;
        var set = new HashSet<int>();
        for (int i = length - 1; i >= 0; i--) {
            if(!set.Add(nums[i]))
                return i / 3 + 1;
        }

        return 0;
    }
}
