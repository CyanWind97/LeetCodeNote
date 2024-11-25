using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3206
/// title: 交替组 I
/// problems: https://leetcode.cn/problems/alternating-groups-i
/// date: 20241126
/// </summary>
public static class Solution3206
{
    public static int NumberOfAlternatingGroups(int[] colors) {
        int length = colors.Length;
        int count = 0;
        for (int i = 0; i < length; i++) {
            if (colors[i] == colors[(i + 1) % length]
            || colors[i] != colors[(i + 2) % length]) 
                continue;
            
            count++;
        }

        return count;
    }
}
