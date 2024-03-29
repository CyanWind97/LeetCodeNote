using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2952
/// title: 需要添加的硬币的最小数量
/// problems: https://leetcode.cn/problems/minimum-number-of-coins-to-be-added
/// date: 20240330
/// </summary>
public static class Solution2952
{
    public static int MinimumAddedCoins(int[] coins, int target) {
        Array.Sort(coins);
        int result = 0;
        int x = 1;
        foreach(var coin in coins){
            while(x < target && coin > x){
                x *= 2;
                result++;
            }
            
            x += coin;
            if (x >= target)
                return result;
        }

        while(x <= target){
            x *= 2;
            result++;
        }

        return result;
    }
}
