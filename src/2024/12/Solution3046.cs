using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3046
/// title: 分割数组
/// problems: https://leetcode.cn/problems/split-the-array
/// date: 20241228
/// </summary>
public static class Solution3046
{
    public static bool IsPossibleToSplit(int[] nums) {
        return nums.GroupBy(x => x).All(g => g.Count() <= 2);
    }
}
