using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2717
/// title: 半有序排列
/// problems: https://leetcode.cn/problems/semi-ordered-permutation
/// date: 20241211
/// </summary>
public static class Solution2717
{
    public static int SemiOrderedPermutation(int[] nums) {
        int length = nums.Length;
        int first = 0;
        int last = 0;
        for (int i = 0; i < length; i++) {
            if (nums[i] == 1) 
                first = i;

            if (nums[i] == length) 
                last = i;
        }

        return first + length - last - 1 - (last < first ? 1 : 0);
    }
}
