using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 123
    /// title:  买卖股票的最佳时机 III
    /// problems: https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-iii/
    /// date: 20220518
    /// priority: 0081
    /// time: 00:04:49.64 timeout
    /// </summary>
    public static class CodeTop123
    {
        // 参考解答
        public static int MaxProfit(int[] prices) {
            int length = prices.Length;
            int buy1 = -prices[0];
            int buy2 = -prices[0];
            int sell1 = 0;
            int sell2 = 0;

            for(int i = 0; i < length; i++){
                buy1 = Math.Max(buy1, -prices[i]);
                sell1 = Math.Max(sell1, buy1 + prices[i]);
                buy2 = Math.Max(buy2, sell1 - prices[i]);
                sell2 = Math.Max(sell2, buy2 + prices[i]);
            }

            return sell2;
        }
        
    }
}