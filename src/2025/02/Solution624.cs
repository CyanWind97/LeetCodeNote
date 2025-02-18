using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 624
/// title: 数组列表中的最大距离
/// problems: https://leetcode.cn/problems/maximum-distance-in-arrays
/// date: 20250219
/// </summary>
public static class Solution624
{
    public static int MaxDistance(IList<IList<int>> arrays) {
        int min = arrays[0][0];
        int max = arrays[0][^1];
        int result = 0;

        for(int i = 1; i < arrays.Count; i++){
            int first = arrays[i][0];
            int last = arrays[i][^1];

            result = Math.Max(result, Math.Max(max - first, last - min));

            max = Math.Max(max, last);
            min = Math.Min(min, first);
        }   

        return result;
    }
}
