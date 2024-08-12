using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3151
/// title: 特殊数组 I
/// problems: https://leetcode.cn/problems/special-array-i
/// date: 20240813
/// </summary>
public static class Solution3151
{
    public static bool IsArraySpecial(int[] nums) {
        int n = nums.Length;
        for(int i = 1; i < n; i++){
            if (((nums[i]  - nums[i - 1]) & 1) == 0)
                return false;
        }

        return true;
    }
}
