using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1599
    /// title: 经营摩天轮的最大利润
    /// problems: https://leetcode.cn/problems/maximum-profit-of-operating-a-centennial-wheel/
    /// date: 20230305
    /// </summary>
    public static partial class Solution1599
    {
        public static int MinOperationsMaxProfit(int[] customers, int boardingCost, int runningCost) {
            if(4 * boardingCost <= runningCost)
                return -1;

            int maxProfit = int.MinValue;
            int profit = 0;
            int wait = 0;
            int result = 0;
            int operation = 0;

            int n = customers.Length;
            for(int i = 0; i < n || wait > 0; i++){
                if(i < n)
                    wait += customers[i];
                
                int cur = Math.Min(4, wait);
                wait -= cur;
                profit += cur * boardingCost - runningCost;
                operation++;
                if(profit > maxProfit){
                    result = operation;
                    maxProfit = profit;
                }
            }

            return maxProfit > 0 ? result : -1;
        }
    }
}