using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2270
/// title: 分割数组的方案数
/// problems: https://leetcode.cn/problems/number-of-ways-to-split-array
/// date: 20250113
/// </summary>
public static class Solution2270
{
    public static int WaysToSplitArray(int[] nums) {
        long sum = nums.Sum(x => (long)x);
        int result = 0;
        long current = 0;
        
        for(int i = 0; i < nums.Length - 1; i++){
            current += nums[i];
            if(current  >= sum - current)
                result++;
        }

        return result;
    }
}
