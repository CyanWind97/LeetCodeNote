using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    // <summary>
    /// no: 122
    /// title: 买卖股票的最佳时机 II
    /// problems: https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-ii/
    /// date: 20231002
    /// </summary>
    public static class Solution122
    {
        public static int MaxProfit(int[] prices) {

            return Enumerable.Range(1, prices.Length - 1)
                    .Sum(i => Math.Max(0, prices[i] - prices[i - 1]));
        }
    }
}