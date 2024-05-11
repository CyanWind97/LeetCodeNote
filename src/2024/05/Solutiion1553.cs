using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1553
/// title: 吃掉 N 个橘子的最少天数
/// problems: https://leetcode.cn/problems/minimum-number-of-days-to-eat-n-oranges
/// date: 20240512
/// </summary>
public static class Solutiion1553
{
    public static int MinDays(int n) {
        var  memo = new Dictionary<int, int>();

        int Calc(int x){
            if (x <= 1)
                return x;
            
            if (memo.TryGetValue(x, out var result))
                return result;
            
            memo[x] = 1 + Math.Min(x % 2 + Calc(x / 2), x % 3 + Calc(x / 3));

            return memo[x];
        }

        return Calc(n);
    }
}
