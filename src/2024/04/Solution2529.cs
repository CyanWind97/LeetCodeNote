using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 2529
/// title: 正整数和负整数的最大计数
/// problems: https://leetcode.cn/problems/maximum-count-of-positive-integer-and-negative-integer
/// date: 20240409
/// </summary>
public static class Solution2529
{
    public static int MaximumCount(int[] nums) {
        var index = Array.BinarySearch(nums, 0);
        int pos = 0;
        int neg = 0;

        if (index < 0) {
            neg = ~index;
            pos = nums.Length - neg;
        } else {
            neg = index;
            while (neg >= 0 && nums[neg] == 0) {
                neg--;
            }
            neg++;

            pos = index;
            while (pos < nums.Length && nums[pos] == 0) {
                pos++;
            }
            pos = nums.Length - pos;
        }

        return Math.Max(pos, neg);
    }
}
