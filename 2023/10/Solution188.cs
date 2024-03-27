using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 188
    /// title: 买卖股票的最佳时机 IV
    /// problems: https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-iv/?envType=daily-question&envId=2023-10-04
    /// date: 20231004
    /// </summary>
    public static partial class Solution188
    {
        public static int MaxProfit_3(int k, int[] prices) {
            int length = prices.Length;
            if (length <= 1 || k == 0) 
                return 0;

            if (k > length/2) 
                k = length/2;

            int[] buys = new int[k];
            int[] sells = new int[k];
            
            for(int i = 0; i < k; i++){
                buys[i] = -prices[0];
                sells[i] = 0;
            }

            for(int i = 1; i < length; i++){
                buys[0] = Math.Max(buys[0], -prices[i]);
                sells[0] = Math.Max(sells[0], buys[0] + prices[i]);

                for(int j = 1; j < k; j++){
                    buys[j] = Math.Max(buys[j], sells[j - 1] - prices[i]);
                    sells[j] = Math.Max(sells[j], buys[j] + prices[i]);
                }
            }

            return sells[k - 1];
        }   
    }
}