using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2073
/// title: 买票需要的时间
/// problems: https://leetcode.cn/problems/time-needed-to-buy-tickets
/// date: 20240929
/// </summary>
public static class Solution2073
{
    public static int TimeRequiredToBuy(int[] tickets, int k) {
        int n = tickets.Length;
        int result = 0;
        for (int i = 0; i < n; i++) {
            result += Math.Min(tickets[i], i <= k ? tickets[k] : tickets[k] - 1);
        }

        return result;
    }
}
