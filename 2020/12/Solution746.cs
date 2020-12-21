using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 746
    /// title: 使用最小花费爬楼梯
    /// problems: https://leetcode-cn.com/problems/min-cost-climbing-stairs/
    /// date: 20201221
    /// </summary>
    public static class Solution746
    {
        public static int MinCostClimbingStairs(int[] cost) {
            int length = cost.Length;
            for(int i = 2; i < length; i++) {
                cost[i] += Math.Min(cost[i-1], cost[i-2]);
            }

            return Math.Min(cost[length-1], cost[length-2]);
        }
    }
}