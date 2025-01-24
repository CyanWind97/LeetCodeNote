using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2412
/// title: 完成所有交易的初始最少钱数
/// problems: https://leetcode.cn/problems/minimum-money-required-before-transactions
/// date: 20250125
/// </summary>
public static class Solution2412
{
    public static long MinimumMoney(int[][] transactions) {
        long totalLose = 0;
        int res = 0;
        foreach (var t in transactions) {
            int cost = t[0];
            int cashback = t[1];
            totalLose += Math.Max(cost - cashback, 0);
            res = Math.Max(res, Math.Min(cost, cashback));
        }
        return totalLose + res;
    }
}
