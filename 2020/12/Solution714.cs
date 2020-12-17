using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 714
    /// title: 买卖股票的最佳时机含手续费
    /// problems: https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/
    /// date: 20201217
    /// </summary>
    public static class Solution714
    {
        public static int MaxProfit(int[] prices, int fee) {
            int profit = 0;
            int low = prices[0];
            int high = prices[0];
            int length = prices.Length;
            int diff = 0;
            for(int i = 1; i < length; i++) {
                int price = prices[i];
                if(price >= high) {
                    high = price;
                }else{
                    if(high - price > fee){
                        diff = high - low - fee;
                        if(diff > 0)
                            profit += diff;
                    }else if(price >= low){
                        continue;
                    }
                    
                    low = price;
                    high = price;
                }
            }
            diff = high - low - fee;
            if(diff > 0)
                profit += diff;

            return profit;
        }

        
        // 官方解答: 贪心算法
        public static int MaxProfit_1(int[] prices, int fee) {
            int profit = 0;
            int buy = prices[0] + fee;
            int length = prices.Length;
            for(int i = 1; i < length; i++) {
                if(prices[i] + fee < buy) {
                    buy = prices[i] + fee;
                }else if(prices[i] > buy){
                    profit += prices[i] - buy;
                    buy = prices[i];
                }
            }

            return profit;
        }

        // 官方解答：动态规划
        public static int MaxProfit_2(int[] prices, int fee) {
            int sell = 0, buy = -prices[0];
            int length = prices.Length;
            for(int i = 1; i < length; i++) {
                sell = Math.Max(sell, buy + prices[i] - fee);
                buy = Math.Max(buy, sell - prices[i]);
            }

            return sell;
        }
    }
}