using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1953
/// title: 你可以工作的最大周数
/// problems: https://leetcode.cn/problems/maximum-number-of-weeks-for-which-you-can-work
/// date: 20240516
/// </summary>
public static class Solution1953
{
    public static long NumberOfWeeks(int[] milestones) {
        int max = milestones[0];
        long sum = 0;

        foreach(var milestone in milestones){
            sum += milestone;
            if(milestone > max)
                max = milestone;
        }

        sum -= max;

        return max > sum + 1 
            ? sum * 2 + 1 
            : sum + max;
    }
}
