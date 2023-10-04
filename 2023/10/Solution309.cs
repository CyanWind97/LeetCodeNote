using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 309
    /// title: 买卖股票的最佳时机含冷冻期
    /// problems: https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-with-cooldown/?envType=daily-question&envId=2023-10-05
    /// date: 20231005
    /// </summary>

    public static class Solution309
    {
        public static int MaxProfit(int[] prices) {
            int length = prices.Length;

            int f0 = -prices[0];
            int f1 = 0;
            int f2 = 0;
            for(int i = 1; i < length; i++){
                int nF0 = Math.Max(f0, f2 - prices[i]);
                int nF1 = f0 + prices[i];
                int nF2 = Math.Max(f1, f2);
                (f0, f1, f2) = (nF0, nF1, nF2);
            }

            return Math.Max(f1, f2);
        }
    }
}