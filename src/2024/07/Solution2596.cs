using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2065
/// title: 找到两个数组中的公共元素
/// problems: https://leetcode.cn/problems/find-common-elements-between-two-arrays
/// date: 20240716
/// </summary>
public static partial class Solution2596
{
    public static int[] FindIntersectionValues(int[] nums1, int[] nums2) {
        var set1 = new HashSet<int>(nums1);
        var set2 = new HashSet<int>(nums2);

        return [nums1.Where(set2.Contains).Count(), nums2.Where(set1.Contains).Count()];
    }
}
