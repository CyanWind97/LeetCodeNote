using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3184
/// title: 构成整天的下标对数目 I
/// problems: https://leetcode.cn/problems/count-pairs-that-form-a-complete-day-i
/// date: 20241022
/// </summary>
public static class Solution3184
{
    public static int CountCompleteDayPairs(int[] hours) {
        var count = new int[24];
        int result = 0;
        foreach (var hour in hours) {
            var curr = hour % 24;
            result += curr == 0 ? count[0] : count[24 - curr];
            count[curr]++;
        }

        return result;
    }
}
