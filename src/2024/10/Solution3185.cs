using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 3185
/// title: 构成整天的下标对数目 II
/// problems: https://leetcode.cn/problems/count-pairs-that-form-a-complete-day-ii
/// date: 20241023
/// </summary>
public static class Solution3185
{
    public static long CountCompleteDayPairs(int[] hours) {
        var count = new int[24];
        var result = 0L;
        foreach(var hour in hours){
            var curr = hour % 24;
            result += curr == 0 ? count[0] : count[24 - curr];
            count[curr]++;
        }

        return result;
    }
}
