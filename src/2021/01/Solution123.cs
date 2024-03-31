using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 123
    /// title: 买卖股票的最佳时机 III
    /// problems: https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-iii/
    /// date: 20210109
    /// </summary>
    public static partial class Solution123
    {
        
        public static int MaxProfit(int[] prices) {
            int length = prices.Length;
            if(length == 1)
                return 0;
            
            int[, ,] profits = new int[length, 2, 2];
            profits[0, 0, 0] = 0;
            profits[0, 0, 1] = -prices[0];

            for(int i = 1; i < length; i++){
                profits[i, 0, 1] = Math.Max(profits[i - 1, 0, 1], -prices[i]); 
                profits[i, 0, 0] = Math.Max(profits[i - 1, 0, 0], profits[i - 1, 0, 1] + prices[i]);
            }

            profits[0, 1, 0] = 0;
            profits[0, 1, 1] = -prices[0];

            for(int i = 1; i < length; i++){
                profits[i, 1, 0] = Math.Max(profits[i - 1, 1, 1] + prices[i], profits[i - 1, 1, 0]);
                profits[i, 1, 1] = Math.Max(profits[i - 1, 0, 0] - prices[i], profits[i - 1, 1, 1]);
            }
            
            return profits[length - 1, 1, 0];
        }


        // 参考解答 优化
        public static int MaxProfit_1(int[] prices){
            int length = prices.Length;
            if(length == 1)
                return 0;
            
            int buy1 = -prices[0], sell1 = 0;
            int buy2 = -prices[0], sell2 = 0;

            for(int i = 1; i < length; i++){
                buy1 = Math.Max(buy1, -prices[i]);
                sell1 = Math.Max(sell1, buy1 + prices[i]);
                buy2 = Math.Max(buy2, sell1 - prices[i]);
                sell2 = Math.Max(sell2, buy2 + prices[i]);
            }

            return sell2;
        }
    }
}