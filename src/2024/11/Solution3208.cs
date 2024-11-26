using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3208
/// title: 交替组 II
/// problems: https://leetcode.cn/problems/alternating-groups-ii
/// date: 20241127
/// </summary>
public static class Solution3208
{
    public static int NumberOfAlternatingGroups(int[] colors, int k) {
        int length = colors.Length;
        int count = 0;
        int range = 1;
        for(int i = -k + 2; i < length; i++){
            if (colors[(i+ length) % length] != colors[(i - 1 + length) % length])
                range++;
            else
                range = 1;
            
            if (range >= k)
                count++;
            
        }
        
        return count;
    }
}
