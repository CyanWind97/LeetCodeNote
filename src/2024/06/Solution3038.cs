using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3038
/// title: 相同分数的最大操作数目 I
/// problems: https://leetcode.cn/problems/maximum-number-of-operations-with-the-same-score-i
/// date: 20240607
/// </summary>
public static class Solution3038
{
    public static int MaxOperations(int[] nums) {
        int length = nums.Length;
        int count = 1;
        int sum = nums[0] + nums[1];

        for(int i = 2; i < length - 1; i += 2){
            if (nums[i] + nums[i + 1] == sum)
                count++;
            else
                break;
        }

        return count;
    }
}
