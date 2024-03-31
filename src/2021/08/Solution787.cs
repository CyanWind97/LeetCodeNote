using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 787
    /// title: K 站中转内最便宜的航班
    /// problems: https://leetcode-cn.com/problems/cheapest-flights-within-k-stops/
    /// date: 20210824
    /// </summary>
    public static class Solution787
    {
        public static int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
            int maxPrice = 10001 * n; 
            int[,] matrix = new int[n, n];
            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    matrix[i, j] = maxPrice;
                }
                matrix[i, i] = 0;
            }
            
            foreach(var flight in flights){
                matrix[flight[0], flight[1]] = flight[2];
            }
            
            int[] prices = new int[n];
            for(int i = 0; i < n; i++){
                prices[i] = matrix[src, i];
            }

            for(int l = 0; l < k; l++){
                int[] newPrices = new int[n];
                Array.Copy(prices, newPrices, n);
                for(int i = 0; i < n; i++){
                    for(int j = 0; j < n; j++){
                        newPrices[i] = Math.Min(newPrices[i], prices[j] + matrix[j, i]);
                    }
                }
                prices = newPrices;
            }

            return prices[dst] == maxPrice ? -1 : prices[dst];
        }
    }
}