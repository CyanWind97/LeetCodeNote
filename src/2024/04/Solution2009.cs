using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2009
/// title: 使数组连续的最少操作数
/// problems: https://leetcode.cn/problems/minimum-number-of-operations-to-make-array-continuous
/// date: 20240408
/// </summary>
public static class Solution2009
{
    public static int MinOperations(int[] nums) {
        int n = nums.Length;
        var sorted = nums.Distinct().OrderBy(x => x).ToArray();
        var result = n;
        int j = 0;
        for (int i = 0; i < sorted.Length; ++i) {
            var left = sorted[i];
            var right = left + n - 1;

            while (j < sorted.Length && sorted[j] <= right) {
                ++j;
            }
            
            result = Math.Min(result, n - (j - i));
        }
        
        return result;
    }
}
