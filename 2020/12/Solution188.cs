using System.Net;
using System.IO;
using System.Text;
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
                int[] delta = new int[count];
                int[] type = new int[count];
                delta[0] = sells[0] - buys[0];
                for(int i = 1; i < count; i++){
                    if(sells[i] > sells[i - 1] && buys[i] >= buys[i - 1]){
                        delta[i] = sells[i - 1] - buys[i];
                        type[i] = 1;
                    }else if(sells[i] <= sells[i - 1] 
                        && sells[i] - buys[i] < sells[i - 1] - buys[i - 1]){
                        delta[i] = sells[i] - buys[i];
                    }else{
                        if(delta[i - 1] == 0 || sells[i - 1] - buys[i - 1] < delta[i - 1]){
                            delta[i] = 0;
                            delta[i - 1] = sells[i - 1] - buys[i - 1];
                            type[i - 1] = 0;
                        }
                    }
                }
                while(count > k){
                    int min = 0;
                    int index = 0;
                    for(int j = 0; j < count; j++){
                        if(delta[j] > 0){
                            if(delta[j] < min || min == 0){
                                min = delta[j];
                                index = j;
                            }else if(delta[j] == min && sells[index] > sells[j])
                                index = j;
                        }
                    }
                    
                    int tmpType = type[index];
                    for(int j = index; j < count - 1; j++){
                        delta[j] = delta[j + 1];
                        type[j] = type[j + 1];
                    }
                    
                    buys.RemoveAt(index);
                    int maxIndex = index;
                    if(tmpType == 1){
                        index--;
                        delta[index] = sells[0] - buys[0];
                    }
                    sells.RemoveAt(index);
                    
                    count--;
                    if(k == count )
                        break;

                    if(index == 0){
                        delta[0] = sells[0] - buys[0];
                        type[0] = 0;
                        continue;
                    }

                    for(int j = index; j <= count - 1 && j <= maxIndex; j++){
                        if(sells[j] > sells[j - 1] && buys[j] >= buys[j - 1]){
                            delta[j] = sells[j - 1] - buys[j];
                            type[j] = 1;
                        }else{
                            if(sells[j] - buys[j] >= sells[j - 1] - buys[j - 1] 
                            && sells[j - 1] - buys[j - 1] < delta[j - 1]){
                                delta[j - 1] = sells[j - 1] - buys[j - 1];
                                type[j - 1] = 0;
                            }
                            delta[j] = sells[j] - buys[j];
                            type[j] = 0;
                        }
                    }
                }
            }

            return sells.Sum() - buys.Sum();
        }
    
        // 参考解答, 官方解答, 动态规划
        public static int MaxProfit_1(int k, int[] prices) {

            int n = prices.Length;
            if (n==0) 
                return 0;
            if (k > n/2) 
                k = n/2; 

            int[,,] dp = new int[n,k+1,2];

            for(int i=0; i<n; i++)
            {
                for (int j=0;j<=k;j++)
                {
                    // Base case1: day1
                    if (i==0)
                    {
                        dp[i,j,0] = 0;          // hold NO stock on day1: profit=0
                        dp[i,j,1] = -prices[0]; // hold stock on day1: profit=-price[0]
                        continue;
                    }
                    //Base case2: no transaction
                    if (j==0)
                    {
                        dp[i,0,0] = 0;            // hold NO stock before first transaction: profit=0
                        dp[i,0,1] = int.MinValue; // hold stock before first transaction: impossible
                        continue;
                    }

                    // all other cases:, where i-1 and j-1 are valid
                    // if I have NO stock in hand by the end of today, I either
                    // sold my stock, if I had some yesterday
                    // or just hold, if I had none yesterday
                    dp[i,j,0] = Math.Max(         
                        dp[i-1,j,1] + prices[i],  // I had stock yesterday, I sell it today
                        dp[i-1,j,0]               // I had no stock yesterday, I hold today
                    );

                    // if I DO have stock in hand by the end of today, I either
                    // buy new stock, if I had none yesterday (#transactions+1)
                    // or just hold, if I had some yesterday
                    dp[i,j,1] = Math.Max(
                        dp[i-1,j-1,0] - prices[i],  // I had no stock yesterday, I buy today
                        dp[i-1,j,1]                 // I had stock yesterday, I hold today
                    );
                }
            }

            return dp[n-1,k,0];
        }
        
        // 更简洁的写法
        // 当天买入再卖出收益为0，不影响解答
        public static int MaxProfit_2(int k, int[] prices) {
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