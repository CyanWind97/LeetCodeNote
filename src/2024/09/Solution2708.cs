using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2708
/// title:  一个小组的最大实力值
/// problems: https://leetcode.cn/problems/maximum-strength-of-a-group
/// date: 20240903
/// </summary>
public static class Solution2708
{
    public static long MaxStrength(int[] nums) {
        if (nums.Length == 1)
            return nums[0];

        long result = 1;
        var maxNeg = -10;
        var zeroCount = 0;

        foreach(var num in nums){
            if (num == 0){
                zeroCount++;
                continue;
            }

            if(num < 0)
                maxNeg = Math.Max(maxNeg, num);
            
            result *= num;
        }

        if (zeroCount == nums.Length
            || (zeroCount == nums.Length - 1 && maxNeg != -10))
            return 0;

        if(result < 0)
            result /= maxNeg;
        
        return result;
    }
}
