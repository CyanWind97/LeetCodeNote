using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1833
    /// title: 雪糕的最大数量
    /// problems: https://leetcode-cn.com/problems/maximum-ice-cream-bars/
    /// date: 20210702
    /// </summary>
    public static class Solution1833
    {
        public static int MaxIceCream(int[] costs, int coins) {
            Array.Sort(costs);
            int count = 0;
            int length = costs.Length;
            for(int i = 0; i < length; i++){
                int cost = costs[i];
                if(coins >= cost){
                    coins -= cost;
                    count++;
                }else{
                    break;
                }
            }

            return count;
        }
    }
}