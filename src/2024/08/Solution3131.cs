using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3131
/// title: 找出与数组相加的整数 I
/// problems: https://leetcode.cn/problems/find-the-integer-added-to-array-i
/// date: 20240808
/// </summary>
public static class Solution3131
{
    public static int AddedInteger(int[] nums1, int[] nums2) {
        return nums2.Min() - nums1.Min();
    }
}
