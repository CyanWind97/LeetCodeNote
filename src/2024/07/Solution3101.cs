using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3101
/// title: 交替子数组计数
/// problems: https://leetcode.cn/problems/count-alternating-subarrays
/// date: 20240706
/// </summary>
public static class Solution3101
{
    public static long CountAlternatingSubarrays(int[] nums) {
        long result = 0;
        long curr = 0;
        int pre = -1;
        foreach(var num in nums){
            curr = (pre != num) ? curr + 1 : 1;
            pre = num;
            result += curr;
        }

        return result;
    }
}
