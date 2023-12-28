using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2706
    /// title: 购买两块巧克力
    /// problems: https://leetcode.cn/problems/buy-two-chocolates/
    /// date: 20231229
    /// </summary>
    public static class Solution2706
    {
        public static int BuyChoco(int[] prices, int money) {
            int length = prices.Length;
            int min1 = money;
            int min2 = money;

            for(int i = 0; i < length; i++){
                if(prices[i] < min1){
                    min2 = min1;
                    min1 = prices[i];
                }else if(prices[i] < min2){
                    min2 = prices[i];
                }
            }

            return money < min1 + min2 
                ? money
                : money - min1 - min2;
        }   
    }
}