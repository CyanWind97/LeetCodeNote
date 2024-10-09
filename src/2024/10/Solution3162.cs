using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3162
/// title: 优质数对的总数 I
/// problems: https://leetcode.cn/problems/find-the-number-of-good-pairs-i
/// date: 20241010
/// </summary>
public static class Solution3162
{
    public static int NumberOfPairs(int[] nums1, int[] nums2, int k) {
        return Enumerable.Range(0, nums1.Length)
            .Sum(i => nums2.Where(y =>  nums1[i]  % (y * k) == 0).Count());
    }
}
