using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2274
/// title: 不含特殊楼层的最大连续楼层数
/// problems: https://leetcode.cn/problems/maximum-consecutive-floors-without-special-floors
/// date: 20250106
/// </summary>
public static class Solution2274
{
    public static int MaxConsecutive(int bottom, int top, int[] special) {
        Array.Sort(special);
        bottom--;
        int max = 0;
        for(int i = 0; i < special.Length; i++){
            max = Math.Max(max, special[i] - bottom - 1);
            bottom = special[i];
        }

        return Math.Max(max, top - bottom);
    }
}
