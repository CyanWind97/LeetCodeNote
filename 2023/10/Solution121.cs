using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 121
    /// title: 买卖股票的最佳时机
    /// problems: https://leetcode.cn/problems/best-time-to-buy-and-sell-stock/
    /// date: 20231001
    /// </summary>
    public class Solution121
    {
        public static int MaxProfit(int[] prices) {
            int length = prices.Length;
            int min = prices[0];
            int max = prices[0];
            int result = 0;

            for(int i = 1; i < length; i++){
                if(prices[i] > max){
                    max = prices[i];
                }else if(prices[i] < min){
                    result = Math.Max(max - min, result);
                    min = prices[i];
                    max = prices[i];
                }
            }
            
            return  Math.Max(result, max - min);
        }
    }
}