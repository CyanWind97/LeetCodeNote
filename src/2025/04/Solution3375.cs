using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3375
/// title: 使数组的值全部为 K 的最少操作次数
/// problems: https://leetcode.cn/problems/minimum-operations-to-make-array-values-equal-to-k
/// date: 20250409
/// </summary>
public static class Solution3375
{
    public static int MinOperations(int[] nums, int k) {
        var values = nums.Distinct().Order().ToArray();
        return values[0] < k
            ? -1
            : values.Length - (values[0] == k ? 1 : 0);
                
    }
}
