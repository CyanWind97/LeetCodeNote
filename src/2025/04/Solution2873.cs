using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2873
/// title: 有序三元组中的最大值 I
/// problems: https://leetcode.cn/problems/maximum-value-of-an-ordered-triplet-i
/// date: 20250402
/// </summary>
public static class Solution2873
{
    public static long MaximumTripletValue(int[] nums) {
        int n = nums.Length;
        long res = 0, imax = 0, dmax = 0;
        for (int k = 0; k < n; k++) {
            res = Math.Max(res, dmax * nums[k]);
            dmax = Math.Max(dmax, imax - nums[k]);
            imax = Math.Max(imax, nums[k]);
        }
        
        return res;
    }
}
