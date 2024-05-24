using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2903
/// title: 找出满足差值条件的下标 I
/// problems: https://leetcode.cn/problems/find-indices-with-index-and-value-difference-i
/// date: 20240525
/// </summary>
public static class Solution2903
{
    public static int[] FindIndices(int[] nums, int indexDifference, int valueDifference) {
        int length = nums.Length;
        for(int i = 0; i < length - indexDifference; i++){
            for(int j = i + indexDifference; j < length; j++){
                if(Math.Abs(nums[i] - nums[j]) >= valueDifference)
                    return [i, j];
            }
        }

        return [-1, -1];
    }
}
