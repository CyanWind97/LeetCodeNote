using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 1014
/// title: 最佳观光组合
/// problems: https://leetcode.cn/problems/best-sightseeing-pair
/// date: 20240923
/// </summary>
public static class Solution1014
{
    public static int MaxScoreSightseeingPair(int[] values) {
        int length = values.Length;
        int max = 0;
        int i = 0;
        for(int j = 1; j < length; j++){
            max = Math.Max(max, values[i] + i + values[j] - j);
            if(values[i] + i < values[j] + j)
                i = j;
        }

        return max;
    }
}
