using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2742
/// title: 给墙壁刷油漆
/// problems: https://leetcode.cn/problems/painting-the-walls
/// date: 20240627
/// </summary>
public static class Solution2742
{
    // 参考解答
    public static int PaintWalls(int[] cost, int[] time) {
        int length = cost.Length;
        var dp = new int[length + 2];
        Array.Fill(dp, int.MaxValue >> 1);
        dp[0] = 0;
        for(int i = 0; i < length; i++){
            for(int j = length + 1; j >= 0; j--){
                int key = Math.Min(j + time[i], length) + 1;
                dp[key] = Math.Min(dp[key], dp[j] + cost[i]);
            }
        }
        
        return Math.Min(dp[length + 1], dp[length]);
    }
}
