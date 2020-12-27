using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 188
    /// title: 买卖股票的最佳时机 IV
    /// problems: https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-iv/
    /// date: 20201228
    /// </summary>
    public static class Solution188
    {
        public static int MaxProfit(int k, int[] prices) {
            if(k == 0)
                return k;
            int length = prices.Length;
            if(length <= 1)
                return 0;
            int[] profits = new int[length];
            int[] delta = new int[length];
            int buy = prices[0], sell = prices[0];
            int preBuy = prices[0], preSell = prices[0];

            for(int i = 1; i < length; i++){
                if(prices[i] < prices[i - 1]){
                    if(sell > buy){
                        if(sell > preSell && buy >= preBuy){
                            delta[i] = preSell - buy;
                            preSell = sell;
                        }else if(sell <= preSell && sell - buy < preSell -preBuy){
                            delta[i] = sell - buy;
                        }else{
                            delta[i] = preSell - preBuy;
                            preBuy = buy;
                            preSell = sell;
                        }
                    }

                    profits[i - 1] = sell - buy;
                    buy = prices[i];
                    sell = prices[i];
                }else if(prices[i] > sell){
                    sell = prices[i];
                }
            }

            if(sell > buy ){
                profits[length - 1] = sell - buy;
                delta[length - 1] = sell > preSell
                        ? buy < preBuy
                            ? preSell - preBuy
                            : preSell - buy
                        : Math.Min(sell - buy, preSell - preBuy);
            }
            
            int count = 0;
            int result = 0;
            for(int i = 0; i < length; i++){
                if(profits[i] > 0){
                    count++;
                    result += profits[i];
                }
            }
            if(k < count)
                result -= delta.Where(x => x > 0).OrderBy(x => x).Take(count - k).Sum();


            return result;
        }

        public static int MaxProfit_1(int k, int[] prices) {
            if(k == 0)
                return k;
            int length = prices.Length;
            if(length <= 1)
                return 0;
            
            List<int> buys = new List<int>();
            List<int> sells = new List<int>();
            int buy = prices[0], sell = prices[0];

            for(int i = 1; i < length; i++){
                if(prices[i] < prices[i - 1]){
                    if(sell > buy){
                        buys.Add(buy);
                        sells.Add(sell);
                    }
                    buy = prices[i];
                    sell = prices[i];
                }else if(prices[i] > sell){
                    sell = prices[i];
                }
            }

            if(sell > buy ){
                buys.Add(buy);
                sells.Add(sell);
            }
            
            int count = buys.Count;

            if(k < count){
                int[] remove = new int[k - count];
                for(int i = 0; i < k - count; i++){

                }
            }

            return sells.Sum() - buys.Sum();
        }
    }
}